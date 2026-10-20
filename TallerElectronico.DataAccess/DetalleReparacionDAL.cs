using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class DetalleReparacionDAL
    {
        public List<DetalleReparacion> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.DetalleReparacion.AsNoTracking()
                                           .Include(d => d.Reparacion)
                                           .Include(d => d.Producto)
                                           .ToList();
            }
        }

        public List<DetalleReparacion> SelectByReparacionId(int idReparacion)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.DetalleReparacion.AsNoTracking()
                                           .Include(d => d.Producto)
                                           .Where(d => d.ReparacionId == idReparacion)
                                           .ToList();
            }
        }

        public DetalleReparacion SelectById(int idDetalleReparacion)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.DetalleReparacion.AsNoTracking()
                                           .Include(d => d.Reparacion)
                                           .Include(d => d.Producto)
                                           .FirstOrDefault(d => d.DetalleReparacionId == idDetalleReparacion);
            }
        }

        public DetalleReparacion Insert(DetalleReparacion detalleReparacion)
        {
            using (var db = new TallerElectronicoEntities())
            {
                detalleReparacion.Reparacion = null;
                detalleReparacion.Producto = null;
                detalleReparacion.Usuario = null;   // Desvincula navegacion de UsuarioCreacionId
                detalleReparacion.Usuario1 = null;  // Desvincula navegacion de UsuarioModificacionId

                if (detalleReparacion.FechaUso == default(DateTime))
                {
                    detalleReparacion.FechaUso = DateTime.Now;
                }

                var nuevoDetalle = db.DetalleReparacion.Add(detalleReparacion);
                db.SaveChanges();
                return nuevoDetalle;
            }
        }

        public DetalleReparacion Update(DetalleReparacion detalleReparacionModificado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var detalleExistente = db.DetalleReparacion.Find(detalleReparacionModificado.DetalleReparacionId);

                if (detalleExistente != null)
                {
                    detalleExistente.ReparacionId = detalleReparacionModificado.ReparacionId;
                    detalleExistente.ProductoId = detalleReparacionModificado.ProductoId;
                    detalleExistente.CantidadUtilizada = detalleReparacionModificado.CantidadUtilizada;
                    detalleExistente.PrecioUnitarioHistorico = detalleReparacionModificado.PrecioUnitarioHistorico;

                    detalleExistente.FechaModificacion = DateTime.Now;
                    detalleExistente.UsuarioModificacionId = detalleReparacionModificado.UsuarioModificacionId;

                    db.SaveChanges();
                }

                return detalleExistente;
            }
        }

        public bool Delete(int idDetalleReparacion)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var detalle = db.DetalleReparacion.Find(idDetalleReparacion);

                if (detalle != null)
                {
                    db.DetalleReparacion.Remove(detalle);
                    return db.SaveChanges() > 0;
                }

                return false;
            }
        }
    }
}