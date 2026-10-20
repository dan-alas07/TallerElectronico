using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class RolDAL
    {
        public List<Rol> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Rol.AsNoTracking()
                             .Where(r => r.Estado == "A")
                             .ToList();
            }
        }

        public Rol SelectById(int idRol)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Rol.AsNoTracking()
                             .FirstOrDefault(r => r.RolId == idRol && r.Estado == "A");
            }
        }

        public Rol Insert(Rol rol)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var nuevoRol = db.Rol.Add(rol);
                db.SaveChanges();
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
                    rolExistente.Estado = rolModificado.Estado;

                    db.SaveChanges();
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
    }
}