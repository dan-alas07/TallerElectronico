using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class EmpleadoBL
    {
        private readonly EmpleadoDAL _empleadoDal = new EmpleadoDAL();

        public List<Empleado> SelectAll()
        {
            return _empleadoDal.SelectAll();
        }

        public Empleado SelectById(int idEmpleado)
        {
            if (idEmpleado <= 0)
                throw new ArgumentException("El ID de empleado proporcionado no es válido.");

            return _empleadoDal.SelectById(idEmpleado);
        }

        public Empleado Insert(Empleado empleado)
        {
            if (empleado == null)
                throw new ArgumentNullException(nameof(empleado), "Los datos del empleado son requeridos.");

            if (string.IsNullOrWhiteSpace(empleado.Nombre))
                throw new ArgumentException("El nombre del empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleado.Apellido))
                throw new ArgumentException("El apellido del empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleado.DUI))
                throw new ArgumentException("El DUI es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleado.Telefono))
                throw new ArgumentException("El teléfono es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleado.Correo))
                throw new ArgumentException("El correo es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleado.Direccion))
                throw new ArgumentException("La dirección es obligatoria.");

            empleado.Nombre = empleado.Nombre.Trim();
            empleado.Apellido = empleado.Apellido.Trim();
            empleado.DUI = empleado.DUI.Trim();
            empleado.Telefono = empleado.Telefono.Trim();
            empleado.Correo = empleado.Correo.Trim();
            empleado.Direccion = empleado.Direccion.Trim();

            // Validaciones de longitud
            if (empleado.Nombre.Length > 50)
                throw new ArgumentException("El nombre no puede superar los 50 caracteres.");

            if (empleado.Apellido.Length > 50)
                throw new ArgumentException("El apellido no puede superar los 50 caracteres.");

            if (empleado.DUI.Length > 10)
                throw new ArgumentException("El DUI no puede superar los 10 caracteres.");

            if (!Regex.IsMatch(empleado.DUI, @"^\d{8}-\d{1}$"))
                throw new ArgumentException("El formato del DUI debe ser 00000000-0.");

            if (empleado.Telefono.Length > 9)
                throw new ArgumentException("El teléfono no puede superar los 9 caracteres.");

            if (empleado.Correo.Length > 100)
                throw new ArgumentException("El correo no puede superar los 100 caracteres.");

            if (!Regex.IsMatch(empleado.Correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("El formato del correo electrónico no es válido.");

            if (empleado.Direccion.Length > 255)
                throw new ArgumentException("La dirección no puede superar los 255 caracteres.");

            if (empleado.FechaContratacion == default(DateTime))
                throw new ArgumentException("Debe seleccionar una fecha de contratación válida.");

            // Validar unicidad de DUI
            var listaEmpleados = _empleadoDal.SelectAll();
            if (listaEmpleados.Any(e => e.DUI.Equals(empleado.DUI, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"El DUI '{empleado.DUI}' ya se encuentra registrado.");

            // Validar unicidad de Correo
            if (listaEmpleados.Any(e => e.Correo.Equals(empleado.Correo, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"El correo '{empleado.Correo}' ya se encuentra registrado.");

            empleado.Estado = "A";

            return _empleadoDal.Insert(empleado);
        }

        public Empleado Update(Empleado empleadoModificado)
        {
            if (empleadoModificado == null)
                throw new ArgumentNullException(nameof(empleadoModificado), "Los datos del empleado son requeridos.");

            if (empleadoModificado.EmpleadoId <= 0)
                throw new ArgumentException("El ID de empleado no es válido.");

            if (string.IsNullOrWhiteSpace(empleadoModificado.Nombre))
                throw new ArgumentException("El nombre del empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleadoModificado.Apellido))
                throw new ArgumentException("El apellido del empleado es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleadoModificado.DUI))
                throw new ArgumentException("El DUI es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleadoModificado.Telefono))
                throw new ArgumentException("El teléfono es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleadoModificado.Correo))
                throw new ArgumentException("El correo es obligatorio.");

            if (string.IsNullOrWhiteSpace(empleadoModificado.Direccion))
                throw new ArgumentException("La dirección es obligatoria.");

            empleadoModificado.Nombre = empleadoModificado.Nombre.Trim();
            empleadoModificado.Apellido = empleadoModificado.Apellido.Trim();
            empleadoModificado.DUI = empleadoModificado.DUI.Trim();
            empleadoModificado.Telefono = empleadoModificado.Telefono.Trim();
            empleadoModificado.Correo = empleadoModificado.Correo.Trim();
            empleadoModificado.Direccion = empleadoModificado.Direccion.Trim();

            // Validaciones de longitud
            if (empleadoModificado.Nombre.Length > 50)
                throw new ArgumentException("El nombre no puede superar los 50 caracteres.");

            if (empleadoModificado.Apellido.Length > 50)
                throw new ArgumentException("El apellido no puede superar los 50 caracteres.");

            if (empleadoModificado.DUI.Length > 10)
                throw new ArgumentException("El DUI no puede superar los 10 caracteres.");

            if (!Regex.IsMatch(empleadoModificado.DUI, @"^\d{8}-\d{1}$"))
                throw new ArgumentException("El formato del DUI debe ser 00000000-0.");

            if (empleadoModificado.Telefono.Length > 9)
                throw new ArgumentException("El teléfono no puede superar los 9 caracteres.");

            if (empleadoModificado.Correo.Length > 100)
                throw new ArgumentException("El correo no puede superar los 100 caracteres.");

            if (!Regex.IsMatch(empleadoModificado.Correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("El formato del correo electrónico no es válido.");

            if (empleadoModificado.Direccion.Length > 255)
                throw new ArgumentException("La dirección no puede superar los 255 caracteres.");

            if (empleadoModificado.FechaContratacion == default(DateTime))
                throw new ArgumentException("Debe seleccionar una fecha de contratación válida.");

            var listaEmpleados = _empleadoDal.SelectAll();

            // Validar duplicado de DUI en otra cuenta
            if (listaEmpleados.Any(e => e.DUI.Equals(empleadoModificado.DUI, StringComparison.OrdinalIgnoreCase) && e.EmpleadoId != empleadoModificado.EmpleadoId))
                throw new InvalidOperationException($"El DUI '{empleadoModificado.DUI}' ya está registrado para otro empleado.");

            // Validar duplicado de Correo en otra cuenta
            if (listaEmpleados.Any(e => e.Correo.Equals(empleadoModificado.Correo, StringComparison.OrdinalIgnoreCase) && e.EmpleadoId != empleadoModificado.EmpleadoId))
                throw new InvalidOperationException($"El correo '{empleadoModificado.Correo}' ya está registrado para otro empleado.");

            var empleadoExistente = _empleadoDal.SelectById(empleadoModificado.EmpleadoId);
            if (empleadoExistente == null)
                throw new InvalidOperationException($"El empleado con ID {empleadoModificado.EmpleadoId} no existe o se encuentra inactivo.");

            return _empleadoDal.Update(empleadoModificado);
        }

        public bool Delete(int idEmpleado)
        {
            if (idEmpleado <= 0)
                throw new ArgumentException("El ID de empleado no es válido.");

            var empleadoExistente = _empleadoDal.SelectById(idEmpleado);
            if (empleadoExistente == null)
                throw new InvalidOperationException($"El empleado con ID {idEmpleado} no existe o ya se encuentra inactivo.");

            return _empleadoDal.Delete(idEmpleado);
        }
    }
}