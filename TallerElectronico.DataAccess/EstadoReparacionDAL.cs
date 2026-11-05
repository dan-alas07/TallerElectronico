using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class EstadoReparacionDAL
    {
        public List<EstadoReparacion> Search(string criterio)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var query = db.EstadoReparacion
                              .AsNoTracking()
                              .Where(p => p.Estado == "A" || p.Estado == "I");

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim().ToLower();

                    if (int.TryParse(criterio, out int idBusqueda))
                    {
                        query = query.Where(p => p.EstadoReparacionId == idBusqueda ||
                                                 (p.Nombre != null && p.Nombre.ToLower().Contains(criterio)));
                    }
                    else
                    {
                        query = query.Where(p => p.Nombre != null && p.Nombre.ToLower().Contains(criterio));
                    }
                }

                // Materializamos primero en memoria
                var lista = query.OrderBy(p => p.Nombre).ToList();

                // Formateamos el valor en memoria
                foreach (var item in lista)
                {
                    item.Estado = item.Estado == "A" ? "Activo" : "Inactivo";
                }

                return lista;
            }
        }

        public List<EstadoReparacion> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.EstadoReparacion
                          .AsNoTracking()
                          .ToList()
                          .Select(p => new EstadoReparacion
                          {
                              EstadoReparacionId = p.EstadoReparacionId,
                              Nombre = p.Nombre,
                              Estado = p.Estado == "A" ? "Activo" : "Inactivo"
                          })
                          .ToList();
            }
        }

        public EstadoReparacion SelectById(int idEstadoReparacion)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.EstadoReparacion.AsNoTracking()
                                          .FirstOrDefault(e => e.EstadoReparacionId == idEstadoReparacion);
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