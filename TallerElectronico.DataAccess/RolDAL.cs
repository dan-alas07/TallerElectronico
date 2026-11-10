using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class RolDAL
    {

        private string NormalizarEstadoParaBD(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado)) return "I";
            return estado.Equals("Activo", StringComparison.OrdinalIgnoreCase) || estado == "A" ? "A" : "I";
        }

        private string TransformarEstadoParaUI(string estado)
        {
            return estado == "A" ? "Activo" : "Inactivo";
        }

        public List<Rol> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                var lista = db.Rol
                              .AsNoTracking()
                              .ToList();

                lista.ForEach(m => m.Estado = TransformarEstadoParaUI(m.Estado));
                return lista;
            }
        }

        public Rol SelectById(int idRol)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var rol = db.Rol
                            .AsNoTracking()
                            .FirstOrDefault(r => r.RolId == idRol);

                if (rol != null)
                {
                    rol.Estado = TransformarEstadoParaUI(rol.Estado);
                }

                return rol;
            }
        }

        public Rol Insert(Rol rol)
        {
            using (var db = new TallerElectronicoEntities())
            {
                rol.Estado = NormalizarEstadoParaBD(rol.Estado);

                var nuevoRol = db.Rol.Add(rol);
                db.SaveChanges();

                nuevoRol.Estado = TransformarEstadoParaUI(nuevoRol.Estado);
                return nuevoRol;
            }
        }

        public Rol Update(Rol rolModificado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var rolExistente = db.Rol.Find(rolModificado.RolId);

                if (rolExistente != null)
                {
                    rolExistente.Nombre = rolModificado.Nombre;
                    rolExistente.Estado = NormalizarEstadoParaBD(rolModificado.Estado);

                    db.SaveChanges();

                    rolExistente.Estado = TransformarEstadoParaUI(rolExistente.Estado);
                }

                return rolExistente;
            }
        }

        public bool Delete(int idRol)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var rol = db.Rol.Find(idRol);

                if (rol != null)
                {
                    rol.Estado = "I";
                    return db.SaveChanges() > 0;
                }

                return false;
            }
        }

        public bool ExistsByNombre(string nombre, int? excludeRolId = null)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Rol.Any(m =>
                    m.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                    m.Estado == "A" &&
                    (!excludeRolId.HasValue || m.RolId != excludeRolId.Value));
            }
        }

        public List<Rol> Search(string criterio)
        {
            using (var db = new TallerElectronicoEntities())
            {
                IQueryable<Rol> query = db.Rol.AsNoTracking();

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim();

                    int idBusqueda;
                    bool esNumero = int.TryParse(criterio, out idBusqueda);

                    query = query.Where(m =>
                        (esNumero && m.RolId == idBusqueda) ||
                        (m.Nombre != null && m.Nombre.Contains(criterio))
                    );
                }

                var lista = query.OrderBy(m => m.Nombre)
                                 .ToList();

                lista.ForEach(m => m.Estado = TransformarEstadoParaUI(m.Estado));
                return lista;
            }
        }
    }
}