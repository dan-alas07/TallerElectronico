using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class EmpleadoDAL
    {
        //public List<Empleado> SelectAll()
        //{
        //    using (var db = new TallerElectronicoEntities())
        //    {
        //        return db.Empleado.AsNoTracking()
        //                          .Where(e => e.Estado == "A")
        //                          .ToList();
        //    }
        //}

        public List<Empleado> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Empleado
                         .AsNoTracking()
                         .Where(p => p.Estado == "A")
                         .ToList()
                         .Select(p => new Empleado
                         {
                             EmpleadoId = p.EmpleadoId,
                             Nombre = p.Nombre,
                             Apellido = p.Apellido,
                             DUI = p.DUI,
                             Telefono = p.Telefono,
                             Correo = p.Correo,
                             Direccion = p.Direccion,
                             FechaContratacion = p.FechaContratacion,
                             Estado = p.Estado == "A" ? "Activo" : "Inactivo"
                         })
                         .ToList();
            }
        }

        //public Empleado SelectById(int idEmpleado)
        //{
        //    using (var db = new TallerElectronicoEntities())
        //    {
        //        return db.Empleado.AsNoTracking()
        //                          .FirstOrDefault(e => e.EmpleadoId == idEmpleado && e.Estado == "A");
        //    }
        //}

        public Empleado SelectById(int idEmpleado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Empleado
                         .AsNoTracking()
                         .FirstOrDefault(e => e.EmpleadoId == idEmpleado);
            }
        }

        public Empleado Insert(Empleado empleado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var nuevoEmpleado = db.Empleado.Add(empleado);
                db.SaveChanges();
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
                    empleadoExistente.Estado = empleadoModificado.Estado;

                    db.SaveChanges();
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

        // Metodos extras
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
                var query = db.Empleado
                              .AsNoTracking()
                              .Where(p => p.Estado == "A");

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim().ToLower();
                    int idBusqueda;
                    bool esNumero = int.TryParse(criterio, out idBusqueda);

                    query = query.Where(p =>
                        (esNumero && p.EmpleadoId == idBusqueda) ||
                        (p.Nombre != null && p.Nombre.ToLower().Contains(criterio)) ||
                        (p.Apellido != null && p.Apellido.ToLower().Contains(criterio)) ||
                        (p.DUI != null && p.DUI.ToLower().Contains(criterio)) ||
                        (p.Telefono != null && p.Telefono.ToLower().Contains(criterio)) ||
                        (p.Correo != null && p.Correo.ToLower().Contains(criterio)) ||
                        (p.Direccion != null && p.Direccion.ToLower().Contains(criterio))
                    );
                }
                return query.OrderBy(p => p.Nombre).ToList();
            }
        }
    }
}
