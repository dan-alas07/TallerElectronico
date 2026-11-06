using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class EmpleadoDAL
    {
        public List<Empleado> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                var list = db.Empleado
                             .AsNoTracking()
                             .OrderBy(e => e.Nombre)
                             .ToList();

                NormalizarEstado(list);
                return list;
            }
        }

        public Empleado SelectById(int idEmpleado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var empleado = db.Empleado
                                 .AsNoTracking()
                                 .FirstOrDefault(e => e.EmpleadoId == idEmpleado);

                if (empleado != null)
                {
                    empleado.Estado = MapearEstadoLegible(empleado.Estado);
                }

                return empleado;
            }
        }

        public Empleado Insert(Empleado empleado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                empleado.Estado = MapearEstadoBD(empleado.Estado);

                var nuevoEmpleado = db.Empleado.Add(empleado);
                db.SaveChanges();

                nuevoEmpleado.Estado = MapearEstadoLegible(nuevoEmpleado.Estado);
                return nuevoEmpleado;
            }
        }

        public Empleado Update(Empleado empleadoModificado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var empleadoExistente = db.Empleado.Find(empleadoModificado.EmpleadoId);

                if (empleadoExistente != null)
                {
                    empleadoExistente.Nombre = empleadoModificado.Nombre;
                    empleadoExistente.Apellido = empleadoModificado.Apellido;
                    empleadoExistente.DUI = empleadoModificado.DUI;
                    empleadoExistente.Telefono = empleadoModificado.Telefono;
                    empleadoExistente.Correo = empleadoModificado.Correo;
                    empleadoExistente.Direccion = empleadoModificado.Direccion;
                    empleadoExistente.FechaContratacion = empleadoModificado.FechaContratacion;
                    empleadoExistente.Estado = MapearEstadoBD(empleadoModificado.Estado);

                    db.SaveChanges();
                    empleadoExistente.Estado = MapearEstadoLegible(empleadoExistente.Estado);
                }

                return empleadoExistente;
            }
        }

        public bool Delete(int idEmpleado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var empleado = db.Empleado.Find(idEmpleado);

                if (empleado != null)
                {
                    empleado.Estado = "I";
                    return db.SaveChanges() > 0;
                }

                return false;
            }
        }

        public bool ExistsByDui(string dui, int? excludeEmpleadoId = null)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Empleado.Any(e =>
                    e.DUI == dui &&
                    (!excludeEmpleadoId.HasValue || e.EmpleadoId != excludeEmpleadoId.Value));
            }
        }

        public bool ExistsByEmail(string email, int? excludeEmpleadoId = null)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Empleado.Any(e =>
                    e.Correo == email &&
                    (!excludeEmpleadoId.HasValue || e.EmpleadoId != excludeEmpleadoId.Value));
            }
        }

        public List<Empleado> Search(string criterio)
        {
            using (var db = new TallerElectronicoEntities())
            {
                // Tipado explícito como IQueryable<Empleado> para evitar DbQuery mismatch
                IQueryable<Empleado> query = db.Empleado.AsNoTracking();

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim();

                    int idBusqueda;
                    bool esNumero = int.TryParse(criterio, out idBusqueda);

                    query = query.Where(e =>
                        (esNumero && e.EmpleadoId == idBusqueda) ||
                        (e.Nombre != null && e.Nombre.Contains(criterio)) ||
                        (e.Apellido != null && e.Apellido.Contains(criterio)) ||
                        (e.DUI != null && e.DUI.Contains(criterio)) ||
                        (e.Telefono != null && e.Telefono.Contains(criterio)) ||
                        (e.Correo != null && e.Correo.Contains(criterio)) ||
                        (e.Direccion != null && e.Direccion.Contains(criterio))
                    );
                }

                var list = query.OrderBy(e => e.Nombre).ToList();
                NormalizarEstado(list);
                return list;
            }
        }

        #region Métodos Auxiliares de Mapeo
        private static string MapearEstadoLegible(string estadoBD)
        {
            return estadoBD == "A" ? "Activo" : "Inactivo";
        }

        private static string MapearEstadoBD(string estadoLegible)
        {
            if (string.IsNullOrWhiteSpace(estadoLegible)) return "I";
            return (estadoLegible.Equals("Activo", StringComparison.OrdinalIgnoreCase) || estadoLegible == "A") ? "A" : "I";
        }

        private static void NormalizarEstado(IEnumerable<Empleado> empleados)
        {
            foreach (var emp in empleados)
            {
                emp.Estado = MapearEstadoLegible(emp.Estado);
            }
        }
        #endregion
    }
}