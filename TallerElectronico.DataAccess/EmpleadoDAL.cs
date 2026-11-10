using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class EmpleadoDAL
    {
        private string NormalizarEstadoParaBD(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado)) return "I";
            return estado.Equals("Activo", StringComparison.OrdinalIgnoreCase) || estado == "A" ? "A" : "I";
        }

        private string TransformarEstadoParaUI(string estado)
        {
            return estado == "A" ? "Activo" : "Inactivo";
        }

        public List<Empleado> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                var empleados = db.Empleado
                                  .AsNoTracking()
                                  .ToList();

                empleados.ForEach(e => e.Estado = TransformarEstadoParaUI(e.Estado));
                return empleados;
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
                    empleado.Estado = TransformarEstadoParaUI(empleado.Estado);
                }

                return empleado;
            }
        }

        public Empleado Insert(Empleado empleado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                empleado.Estado = NormalizarEstadoParaBD(empleado.Estado);

                var nuevoEmpleado = db.Empleado.Add(empleado);
                db.SaveChanges();

                nuevoEmpleado.Estado = TransformarEstadoParaUI(nuevoEmpleado.Estado);
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

                    empleadoExistente.Estado = NormalizarEstadoParaBD(empleadoModificado.Estado);

                    db.SaveChanges();

                    empleadoExistente.Estado = TransformarEstadoParaUI(empleadoExistente.Estado);
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
                    e.Estado == "A" &&
                    (!excludeEmpleadoId.HasValue || e.EmpleadoId != excludeEmpleadoId.Value));
            }
        }

        public bool ExistsByEmail(string email, int? excludeEmpleadoId = null)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Empleado.Any(e =>
                    e.Correo == email &&
                    e.Estado == "A" &&
                    (!excludeEmpleadoId.HasValue || e.EmpleadoId != excludeEmpleadoId.Value));
            }
        }

        public List<Empleado> Search(string criterio)
        {
            using (var db = new TallerElectronicoEntities())
            {
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

                var lista = query.OrderBy(e => e.Nombre)
                                 .ThenBy(e => e.Apellido)
                                 .ToList();

                lista.ForEach(e => e.Estado = TransformarEstadoParaUI(e.Estado));
                return lista;
            }
        }
    }
}