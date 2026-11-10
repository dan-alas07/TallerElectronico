using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class MarcaDAL
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

        public List<Marca> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                var lista = db.Marca
                              .AsNoTracking()
                              .ToList();

                lista.ForEach(m => m.Estado = TransformarEstadoParaUI(m.Estado));
                return lista;
            }
        }

        public Marca SelectById(int idMarca)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var marca = db.Marca
                              .AsNoTracking()
                              .FirstOrDefault(m => m.MarcaId == idMarca);

                if (marca != null)
                {
                    marca.Estado = TransformarEstadoParaUI(marca.Estado);
                }

                return marca;
            }
        }

        public Marca Insert(Marca marca)
        {
            using (var db = new TallerElectronicoEntities())
            {
                marca.Estado = NormalizarEstadoParaBD(marca.Estado);

                var nuevaMarca = db.Marca.Add(marca);
                db.SaveChanges();

                nuevaMarca.Estado = TransformarEstadoParaUI(nuevaMarca.Estado);
                return nuevaMarca;
            }
        }

        public Marca Update(Marca marcaModificada)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var marcaExistente = db.Marca.Find(marcaModificada.MarcaId);

                if (marcaExistente != null)
                {
                    marcaExistente.Nombre = marcaModificada.Nombre;
                    marcaExistente.Estado = NormalizarEstadoParaBD(marcaModificada.Estado);

                    db.SaveChanges();

                    marcaExistente.Estado = TransformarEstadoParaUI(marcaExistente.Estado);
                }

                return marcaExistente;
            }
        }

        public bool Delete(int idMarca)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var marca = db.Marca.Find(idMarca);

                if (marca != null)
                {
                    marca.Estado = "I";
                    return db.SaveChanges() > 0;
                }

                return false;
            }
        }

        public bool ExistsByNombre(string nombre, int? excludeMarcaId = null)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Marca.Any(m =>
                    m.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase) &&
                    m.Estado == "A" &&
                    (!excludeMarcaId.HasValue || m.MarcaId != excludeMarcaId.Value));
            }
        }

        public List<Marca> Search(string criterio)
        {
            using (var db = new TallerElectronicoEntities())
            {
                IQueryable<Marca> query = db.Marca.AsNoTracking();

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim();

                    int idBusqueda;
                    bool esNumero = int.TryParse(criterio, out idBusqueda);

                    query = query.Where(m =>
                        (esNumero && m.MarcaId == idBusqueda) ||
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