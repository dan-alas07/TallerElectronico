using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class ReparacionDAL
    {
        public List<Reparacion> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Reparacion.AsNoTracking()
                                    .Include(r => r.Cliente)
                                    .Include(r => r.TipoEquipo)
                                    .Include(r => r.Marca)
                                    .Include(r => r.EstadoReparacion)
                                    .Include(r => r.Usuario) // Técnico asignado
                                    .ToList();
            }
        }

        public Reparacion SelectById(int idReparacion)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Reparacion.AsNoTracking()
                                    .Include(r => r.Cliente)
                                    .Include(r => r.TipoEquipo)
                                    .Include(r => r.Marca)
                                    .Include(r => r.EstadoReparacion)
                                    .Include(r => r.Usuario) // Técnico asignado
                                    .FirstOrDefault(r => r.ReparacionId == idReparacion);
            }
        }

        public Reparacion SelectByTrackingCode(string codigoSeguimiento)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Reparacion.AsNoTracking()
                                    .Include(r => r.Cliente)
                                    .Include(r => r.TipoEquipo)
                                    .Include(r => r.Marca)
                                    .Include(r => r.EstadoReparacion)
                                    .Include(r => r.Usuario) // Técnico asignado
                                    .FirstOrDefault(r => r.CodigoSeguimiento == codigoSeguimiento);
            }
        }

        public Reparacion Insert(Reparacion reparacion)
        {
            using (var db = new TallerElectronicoEntities())
            {
                reparacion.Cliente = null;
                reparacion.TipoEquipo = null;
                reparacion.Marca = null;
                reparacion.EstadoReparacion = null;
                reparacion.Usuario = null;   // TecnicoAsignadoId
                reparacion.Usuario1 = null;  // UsuarioCreacionId
                reparacion.Usuario2 = null;  // UsuarioModificacionId

                if (reparacion.FechaIngreso == default(DateTime))
                {
                    reparacion.FechaIngreso = DateTime.Now;
                }

                var nuevaReparacion = db.Reparacion.Add(reparacion);
                db.SaveChanges();
                return nuevaReparacion;
            }
        }

        public Reparacion Update(Reparacion reparacionModificada)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var reparacionExistente = db.Reparacion.Find(reparacionModificada.ReparacionId);

                if (reparacionExistente != null)
                {
                    reparacionExistente.ClienteId = reparacionModificada.ClienteId;
                    reparacionExistente.TipoEquipoId = reparacionModificada.TipoEquipoId;
                    reparacionExistente.MarcaId = reparacionModificada.MarcaId;
                    reparacionExistente.Modelo = reparacionModificada.Modelo;
                    reparacionExistente.TecnicoAsignadoId = reparacionModificada.TecnicoAsignadoId;
                    reparacionExistente.DiagnosticoInicial = reparacionModificada.DiagnosticoInicial;
                    reparacionExistente.EstadoReparacionId = reparacionModificada.EstadoReparacionId;
                    reparacionExistente.FechaEntrega = reparacionModificada.FechaEntrega;
                    reparacionExistente.DiagnosticoFinal = reparacionModificada.DiagnosticoFinal;
                    reparacionExistente.CostoManoObra = reparacionModificada.CostoManoObra;
                    reparacionExistente.TotalReparacion = reparacionModificada.TotalReparacion;

                    reparacionExistente.FechaModificacion = DateTime.Now;
                    reparacionExistente.UsuarioModificacionId = reparacionModificada.UsuarioModificacionId;

                    db.SaveChanges();
                }

                return reparacionExistente;
            }
        }

        public bool Delete(int idReparacion)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var reparacion = db.Reparacion.Find(idReparacion);

                if (reparacion != null)
                {
                    db.Reparacion.Remove(reparacion);
                    return db.SaveChanges() > 0;
                }

                return false;
            }
        }
    }
}