using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class ReparacionDAL
    {
        public List<ReparacionDTO> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Reparacion.AsNoTracking()
                    .OrderByDescending(r => r.FechaIngreso)
                    .Where(r => r.EstadoReparacion.Nombre != "Cancelado")
                    .Select(r => new ReparacionDTO
                    {
                        ReparacionId = r.ReparacionId,
                        CodigoSeguimiento = r.CodigoSeguimiento,
                        Modelo = r.Modelo,
                        FechaIngreso = r.FechaIngreso,
                        FechaEntrega = r.FechaEntrega,
                        CostoManoObra = r.CostoManoObra,
                        TotalReparacion = r.TotalReparacion ?? 0.00m,

                        EstadoNombre = r.EstadoReparacion.Nombre,
                        TipoEquipoNombre = r.TipoEquipo.Nombre,
                        MarcaNombre = r.Marca.Nombre,
                        ClienteNombre = r.Cliente.Nombre,
                        ClienteApellido = r.Cliente.Apellido,
                        Correo = r.Cliente.Correo,
                        TecnicoNombre = r.Usuario != null && r.Usuario.Empleado != null
                            ? r.Usuario.Empleado.Nombre + " " + r.Usuario.Empleado.Apellido
                            : "Sin Asignar",

                        // Concatenado para el pdf
                        EquipoCompleto = r.TipoEquipo.Nombre + " " + r.Marca.Nombre + " " + r.Modelo,

                        // Mapeo de detalles y repuestos utilizados
                        Detalles = r.DetalleReparacion.Select(d => new DetalleReparacionDTO
                        {
                            DetalleReparacionId = d.DetalleReparacionId,
                            ReparacionId = d.ReparacionId,
                            ProductoId = d.ProductoId,
                            CantidadUtilizada = d.CantidadUtilizada,
                            PrecioUnitarioHistorico = d.PrecioUnitarioHistorico,
                            Subtotal = d.Subtotal ?? 0.00m,
                            FechaUso = d.FechaUso,
                            ProductoNombre = d.Producto != null ? d.Producto.Nombre : ""
                        }).ToList()
                    })
                    .ToList();
            }
        }

        public KpiDashboardDTO GetKpis()
        {
            using (var db = new TallerElectronicoEntities())
            {
                var query = db.Reparacion.AsNoTracking();

                return new KpiDashboardDTO
                {
                    OrdenesAbiertas = query.Count(r => r.EstadoReparacion.Nombre != "Entregado" &&
                                                       r.EstadoReparacion.Nombre != "Cancelado"),

                    OrdenesListas = query.Count(r => r.EstadoReparacion.Nombre == "Reparado"),

                    OrdenesEntregadas = query.Count(r => r.EstadoReparacion.Nombre == "Entregado")
                };
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
                                    .Include(r => r.Usuario)
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

        public bool Cancelar(int idReparacion, int idUsuarioModificacion)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var reparacion = db.Reparacion.Find(idReparacion);

                if (reparacion != null)
                {
                    var estadoCancelado = db.EstadoReparacion.FirstOrDefault(e => e.Nombre == "Cancelado");

                    if (estadoCancelado != null)
                    {
                        reparacion.EstadoReparacionId = estadoCancelado.EstadoReparacionId;
                        reparacion.FechaModificacion = DateTime.Now;
                        reparacion.UsuarioModificacionId = idUsuarioModificacion;

                        return db.SaveChanges() > 0;
                    }
                }

                return false;
            }
        }

        public List<ReparacionDTO> Search(string criterio)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var query = db.Reparacion.AsNoTracking()
                    .Where(r => r.EstadoReparacion.Nombre != "Cancelado");

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim();

                    int idBusqueda;
                    bool esNumero = int.TryParse(criterio, out idBusqueda);

                    query = query.Where(r =>
                        (esNumero && r.ReparacionId == idBusqueda) ||
                        (r.CodigoSeguimiento != null && r.CodigoSeguimiento.Contains(criterio)) ||
                        (r.Modelo != null && r.Modelo.Contains(criterio)) ||
                        (r.TipoEquipo.Nombre != null && r.TipoEquipo.Nombre.Contains(criterio)) ||
                        (r.Marca.Nombre != null && r.Marca.Nombre.Contains(criterio)) ||
                        (r.EstadoReparacion.Nombre != null && r.EstadoReparacion.Nombre.Contains(criterio)) ||
                        ((r.Cliente.Nombre + " " + r.Cliente.Apellido).Contains(criterio)) ||
                        (r.Usuario != null && r.Usuario.Empleado != null &&
                         (r.Usuario.Empleado.Nombre + " " + r.Usuario.Empleado.Apellido).Contains(criterio))
                    );
                }

                return query.OrderByDescending(r => r.FechaIngreso)
                    .Select(r => new ReparacionDTO
                    {
                        ReparacionId = r.ReparacionId,
                        CodigoSeguimiento = r.CodigoSeguimiento,
                        Modelo = r.Modelo,
                        FechaIngreso = r.FechaIngreso,
                        FechaEntrega = r.FechaEntrega,
                        CostoManoObra = r.CostoManoObra,
                        TotalReparacion = r.TotalReparacion ?? 0.00m,

                        EstadoNombre = r.EstadoReparacion.Nombre,
                        TipoEquipoNombre = r.TipoEquipo.Nombre,
                        MarcaNombre = r.Marca.Nombre,
                        ClienteNombre = r.Cliente.Nombre,
                        ClienteApellido = r.Cliente.Apellido,
                        Correo = r.Cliente.Correo,
                        TecnicoNombre = r.Usuario != null && r.Usuario.Empleado != null ? r.Usuario.Empleado.Nombre + " " + r.Usuario.Empleado.Apellido : "Sin Asignar",

                        EquipoCompleto = r.TipoEquipo.Nombre + " " + r.Marca.Nombre + " " + r.Modelo,

                        // Mapeo de detalles y repuestos utilizados
                        Detalles = r.DetalleReparacion.Select(d => new DetalleReparacionDTO
                        {
                            DetalleReparacionId = d.DetalleReparacionId,
                            ReparacionId = d.ReparacionId,
                            ProductoId = d.ProductoId,
                            CantidadUtilizada = d.CantidadUtilizada,
                            PrecioUnitarioHistorico = d.PrecioUnitarioHistorico,
                            Subtotal = d.Subtotal ?? 0.00m,
                            FechaUso = d.FechaUso,
                            ProductoNombre = d.Producto != null ? d.Producto.Nombre : ""
                        }).ToList()
                    }).ToList();
            }
        }

        public List<ReparacionDTO> SelectByFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            using (var db = new TallerElectronicoEntities())
            {
                // Ajustar la fecha final al último segundo del día (23:59:59)
                DateTime inicio = fechaInicio.Date;
                DateTime fin = fechaFin.Date.AddDays(1).AddTicks(-1);

                return db.Reparacion.AsNoTracking()
                    .Where(r => r.FechaIngreso >= inicio && r.FechaIngreso <= fin && r.EstadoReparacion.Nombre != "Cancelado")
                    .OrderByDescending(r => r.FechaIngreso)
                    .Select(r => new ReparacionDTO
                    {
                        ReparacionId = r.ReparacionId,
                        CodigoSeguimiento = r.CodigoSeguimiento,
                        Modelo = r.Modelo,
                        FechaIngreso = r.FechaIngreso,
                        FechaEntrega = r.FechaEntrega,
                        CostoManoObra = r.CostoManoObra,
                        TotalReparacion = r.TotalReparacion ?? 0.00m,

                        EstadoNombre = r.EstadoReparacion.Nombre,
                        TipoEquipoNombre = r.TipoEquipo.Nombre,
                        MarcaNombre = r.Marca.Nombre,
                        ClienteNombre = r.Cliente.Nombre,
                        ClienteApellido = r.Cliente.Apellido,
                        Correo = r.Cliente.Correo,
                        TecnicoNombre = r.Usuario != null && r.Usuario.Empleado != null
                            ? r.Usuario.Empleado.Nombre + " " + r.Usuario.Empleado.Apellido
                            : "Sin Asignar",

                        EquipoCompleto = r.TipoEquipo.Nombre + " " + r.Marca.Nombre + " " + r.Modelo,

                        Detalles = r.DetalleReparacion.Select(d => new DetalleReparacionDTO
                        {
                            DetalleReparacionId = d.DetalleReparacionId,
                            ReparacionId = d.ReparacionId,
                            ProductoId = d.ProductoId,
                            CantidadUtilizada = d.CantidadUtilizada,
                            PrecioUnitarioHistorico = d.PrecioUnitarioHistorico,
                            Subtotal = d.Subtotal ?? 0.00m,
                            FechaUso = d.FechaUso,
                            ProductoNombre = d.Producto != null ? d.Producto.Nombre : ""
                        }).ToList()
                    }).ToList();
            }
        }
    }
}