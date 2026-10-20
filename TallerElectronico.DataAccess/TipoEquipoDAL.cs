using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class TipoEquipoDAL
    {
        public List<TipoEquipo> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.TipoEquipo.AsNoTracking()
                                    .Where(t => t.Estado == "A")
                                    .ToList();
            }
        }

        public TipoEquipo SelectById(int idTipoEquipo)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.TipoEquipo.AsNoTracking()
                                    .FirstOrDefault(t => t.TipoEquipoId == idTipoEquipo && t.Estado == "A");
            }
        }

        public TipoEquipo Insert(TipoEquipo tipoEquipo)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var nuevoTipoEquipo = db.TipoEquipo.Add(tipoEquipo);
                db.SaveChanges();
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
                    tipoEquipoExistente.Estado = tipoEquipoModificado.Estado;

                    db.SaveChanges();
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
    }
}