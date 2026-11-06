using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class DetalleReparacionDAL
    {
        public List<DetalleReparacionDTO> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.DetalleReparacion.AsNoTracking()
                    .OrderByDescending(d => d.FechaUso)
                    .Select(d => new DetalleReparacionDTO
                    {
                        DetalleReparacionId = d.DetalleReparacionId,
                        ReparacionId = d.ReparacionId,
                        ProductoId = d.ProductoId,
                        CantidadUtilizada = d.CantidadUtilizada,
                        PrecioUnitarioHistorico = d.PrecioUnitarioHistorico,
                        Subtotal = d.CantidadUtilizada * d.PrecioUnitarioHistorico, // O d.Subtotal si Entity Framework lo reconoce directamente
                        FechaUso = d.FechaUso,

                        // Campos de auditoría
                        UsuarioCreacionId = d.UsuarioCreacionId,
                        FechaModificacion = d.FechaModificacion,
                        UsuarioModificacionId = d.UsuarioModificacionId,

                        // Uniones (JOINs implícitos mediante propiedades de navegación)
                        ReparacionCodigo = d.Reparacion != null ? d.Reparacion.CodigoSeguimiento : "Sin Código",
                        ProductoNombre = d.Producto != null ? d.Producto.Nombre : "Producto Desconocido",

                        // Mapeo del usuario que registró el uso del repuesto/producto
                        UsuarioCreacionNombre = d.Usuario != null
                            ? (d.Usuario.Empleado != null
                                ? d.Usuario.Empleado.Nombre + " " + d.Usuario.Empleado.Apellido
                                : d.Usuario.Nombre)
                            : "Sin Usuario"
                    })
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

        public DetalleReparacionDTO SelectById(int idDetalleReparacion)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.DetalleReparacion
                         .AsNoTracking()
                         .Where(d => d.DetalleReparacionId == idDetalleReparacion)
                         .Select(d => new DetalleReparacionDTO
                         {
                             DetalleReparacionId = d.DetalleReparacionId,
                             ReparacionId = d.ReparacionId,
                             ProductoId = d.ProductoId,
                             CantidadUtilizada = d.CantidadUtilizada,
                             PrecioUnitarioHistorico = d.PrecioUnitarioHistorico,
                             Subtotal = d.CantidadUtilizada * d.PrecioUnitarioHistorico,
                             FechaUso = d.FechaUso,

                             // Campos de auditoría
                             UsuarioCreacionId = d.UsuarioCreacionId,
                             FechaModificacion = d.FechaModificacion,
                             UsuarioModificacionId = d.UsuarioModificacionId,

                             // Relaciones descriptivas
                             ReparacionCodigo = d.Reparacion != null ? d.Reparacion.CodigoSeguimiento : "Sin Código",
                             ProductoNombre = d.Producto != null ? d.Producto.Nombre : "Producto Desconocido",

                             UsuarioCreacionNombre = d.Usuario != null
                                 ? (d.Usuario.Empleado != null
                                     ? d.Usuario.Empleado.Nombre + " " + d.Usuario.Empleado.Apellido
                                     : d.Usuario.Nombre)
                                 : "Sin Usuario"
                         })
                         .FirstOrDefault();
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