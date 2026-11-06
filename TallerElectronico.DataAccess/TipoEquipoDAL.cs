using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class TipoEquipoDAL
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

        public List<TipoEquipo> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                var lista = db.TipoEquipo
                              .AsNoTracking()
                              .OrderBy(t => t.Nombre)
                              .ToList();

                lista.ForEach(t => t.Estado = TransformarEstadoParaUI(t.Estado));
                return lista;
            }
        }

        public TipoEquipo SelectById(int idTipoEquipo)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var tipoEquipo = db.TipoEquipo
                                   .AsNoTracking()
                                   .FirstOrDefault(t => t.TipoEquipoId == idTipoEquipo);

                if (tipoEquipo != null)
                {
                    tipoEquipo.Estado = TransformarEstadoParaUI(tipoEquipo.Estado);
                }

                return tipoEquipo;
            }
        }

        public TipoEquipo Insert(TipoEquipo tipoEquipo)
        {
            using (var db = new TallerElectronicoEntities())
            {
                tipoEquipo.Estado = NormalizarEstadoParaBD(tipoEquipo.Estado);

                var nuevoTipoEquipo = db.TipoEquipo.Add(tipoEquipo);
                db.SaveChanges();

                nuevoTipoEquipo.Estado = TransformarEstadoParaUI(nuevoTipoEquipo.Estado);
                return nuevoTipoEquipo;
            }
        }

        public TipoEquipo Update(TipoEquipo tipoEquipoModificado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var tipoEquipoExistente = db.TipoEquipo.Find(tipoEquipoModificado.TipoEquipoId);

                if (tipoEquipoExistente != null)
                {
                    tipoEquipoExistente.Nombre = tipoEquipoModificado.Nombre;
                    tipoEquipoExistente.Estado = NormalizarEstadoParaBD(tipoEquipoModificado.Estado);

                    db.SaveChanges();

                    tipoEquipoExistente.Estado = TransformarEstadoParaUI(tipoEquipoExistente.Estado);
                }

                return tipoEquipoExistente;
            }
        }

        public bool Delete(int idTipoEquipo)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var tipoEquipo = db.TipoEquipo.Find(idTipoEquipo);

                if (tipoEquipo != null)
                {
                    tipoEquipo.Estado = "I";
                    return db.SaveChanges() > 0;
                }

                return false;
            }
        }

        public bool ExistsByNombre(string nombre, int? excludeTipoEquipoId = null)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.TipoEquipo.Any(t =>
                    t.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                    t.Estado == "A" &&
                    (!excludeTipoEquipoId.HasValue || t.TipoEquipoId != excludeTipoEquipoId.Value));
            }
        }

        public List<TipoEquipo> Search(string criterio)
        {
            using (var db = new TallerElectronicoEntities())
            {
                IQueryable<TipoEquipo> query = db.TipoEquipo.AsNoTracking();

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim();

                    int idBusqueda;
                    bool esNumero = int.TryParse(criterio, out idBusqueda);

                    query = query.Where(t =>
                        (esNumero && t.TipoEquipoId == idBusqueda) ||
                        (t.Nombre != null && t.Nombre.Contains(criterio))
                    );
                }

                var lista = query.OrderBy(t => t.Nombre)
                                 .ToList();

                lista.ForEach(t => t.Estado = TransformarEstadoParaUI(t.Estado));
                return lista;
            }
        }
    }
}