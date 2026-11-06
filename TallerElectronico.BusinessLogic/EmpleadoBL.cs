using System;
using System.Collections.Generic;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class EmpleadoBL
    {
        private readonly EmpleadoDAL _empleadoDAL = new EmpleadoDAL();

        public List<Empleado> SelectAll()
        {
            return _empleadoDAL.SelectAll();
        }

        public Empleado SelectById(int idEmpleado)
        {
            if (idEmpleado <= 0)
                throw new ArgumentException("El ID de empleado proporcionado no es válido.");

            return _empleadoDAL.SelectById(idEmpleado);
        }

        public Empleado Insert(Empleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException(nameof(empleado), "Los datos del empleado son requeridos.");

            return _empleadoDAL.Insert(empleado);
        }

        public Empleado Update(Empleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException(nameof(empleado), "Los datos del empleado son requeridos.");

            return _empleadoDAL.Update(empleado);
        }

        public bool Delete(int idEmpleado)
        {
            if (idEmpleado <= 0)
                throw new ArgumentException("El ID de empleado no es válido.");

            return _empleadoDAL.Delete(idEmpleado);
        }

        public List<Empleado> Search(string criterio)
        {
            return _empleadoDAL.Search(criterio);
        }
    }
}