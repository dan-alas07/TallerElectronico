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
                return db.Marca.AsNoTracking()
                               .Where(m => m.Estado == "A")
                               .ToList();
            }
        }

        public Marca SelectById(int idMarca)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Marca.AsNoTracking()
                               .FirstOrDefault(m => m.MarcaId == idMarca && m.Estado == "A");
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
    }
}