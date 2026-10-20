using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class EstadoReparacionDAL
    {
        public List<EstadoReparacion> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.EstadoReparacion.AsNoTracking()
                                          .Where(e => e.Estado == "A")
                                          .ToList();
            }
        }

        public EstadoReparacion SelectById(int idEstadoReparacion)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.EstadoReparacion.AsNoTracking()
                                          .FirstOrDefault(e => e.EstadoReparacionId == idEstadoReparacion && e.Estado == "A");
            }
        }

        public EstadoReparacion Insert(EstadoReparacion estadoReparacion)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var nuevoEstadoReparacion = db.EstadoReparacion.Add(estadoReparacion);
                db.SaveChanges();
                return nuevoEstadoReparacion;
            }
        }

        public EstadoReparacion Update(EstadoReparacion estadoReparacionModificado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var estadoReparacionExistente = db.EstadoReparacion.Find(estadoReparacionModificado.EstadoReparacionId);

                if (estadoReparacionExistente != null)
                {
                    estadoReparacionExistente.Nombre = estadoReparacionModificado.Nombre;
                    estadoReparacionExistente.Estado = estadoReparacionModificado.Estado;

                    db.SaveChanges();
                }

                return estadoReparacionExistente;
            }
        }

        public bool Delete(int idEstadoReparacion)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var estadoReparacion = db.EstadoReparacion.Find(idEstadoReparacion);

                if (estadoReparacion != null)
                {
                    estadoReparacion.Estado = "I";
                    return db.SaveChanges() > 0;
                }

                return false;
            }
        }
    }
}