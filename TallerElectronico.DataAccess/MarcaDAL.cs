using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class MarcaDAL
    {
        public List<Marca> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Marca
                         .AsNoTracking()
                         .ToList()
                         .Select(p => new Marca
                         {
                             MarcaId = p.MarcaId,
                             Nombre = p.Nombre,
                             Estado = p.Estado == "A" ? "Activo" : "Inactivo"
                         })
                         .ToList();
            }
        }

        public Marca SelectById(int idMarca)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Marca.AsNoTracking()
                               .FirstOrDefault(m => m.MarcaId == idMarca);
            }
        }

        public Marca Insert(Marca marca)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var nuevaMarca = db.Marca.Add(marca);
                db.SaveChanges();
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
                    marcaExistente.Estado = marcaModificada.Estado;

                    db.SaveChanges();
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
        public List<Marca> Search(string criterio)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var query = db.Marca
                              .AsNoTracking()
                              .Where(p => p.Estado == "A");

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim().ToLower();
                    int idBusqueda;
                    bool esNumero = int.TryParse(criterio, out idBusqueda);

                    query = query.Where(p =>
                        (esNumero && p.MarcaId == idBusqueda) ||
                        (p.Nombre != null && p.Nombre.ToLower().Contains(criterio))
                    );
                }
                return query.OrderBy(p => p.Nombre).ToList();
            }
        }
    }
}