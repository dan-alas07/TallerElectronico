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
        public List<Empleado> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Empleado.AsNoTracking()
                                  .Where(e => e.Estado == "A")
                                  .ToList();
            }
        }

        public Empleado SelectById(int idEmpleado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Empleado.AsNoTracking()
                                  .FirstOrDefault(e => e.EmpleadoId == idEmpleado && e.Estado == "A");
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
    }
}
