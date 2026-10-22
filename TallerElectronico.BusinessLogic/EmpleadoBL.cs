using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class EmpleadoBL
    {
        private readonly EmpleadoDAL _empleadoDal = new EmpleadoDAL();

        private static readonly Regex RegexDui = new Regex(@"^\d{8}-\d{1}$", RegexOptions.Compiled);
        private static readonly Regex RegexCorreo = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

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
            ValidarDatosEmpleado(empleado);

            if (_empleadoDal.ExistsByDui(empleado.DUI))
                throw new InvalidOperationException($"El DUI '{empleado.DUI}' ya se encuentra registrado.");

            if (_empleadoDal.ExistsByEmail(empleado.Correo))
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

            ValidarDatosEmpleado(empleadoModificado);

            // Excluye el ID actual para evitar falsos positivos con el mismo registro
            if (_empleadoDal.ExistsByDui(empleadoModificado.DUI, empleadoModificado.EmpleadoId))
                throw new InvalidOperationException($"El DUI '{empleadoModificado.DUI}' ya está registrado para otro empleado.");

            if (_empleadoDal.ExistsByEmail(empleadoModificado.Correo, empleadoModificado.EmpleadoId))
                throw new InvalidOperationException($"El correo '{empleadoModificado.Correo}' ya está registrado para otro empleado.");

            var empleadoActualizado = _empleadoDal.Update(empleadoModificado);
            if (empleadoActualizado == null)
                throw new InvalidOperationException($"El empleado con ID {empleadoModificado.EmpleadoId} no existe o se encuentra inactivo.");

            return empleadoActualizado;
        }

        public bool Delete(int idEmpleado)
        {
            if (idEmpleado <= 0)
                throw new ArgumentException("El ID de empleado no es válido.");

            bool eliminado = _empleadoDal.Delete(idEmpleado);
            if (!eliminado)
                throw new InvalidOperationException($"El empleado con ID {idEmpleado} no existe o ya se encuentra inactivo.");

            return true;
        }

        private void ValidarDatosEmpleado(Empleado empleado)
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

            // Limpieza de espacios
            empleado.Nombre = empleado.Nombre.Trim();
            empleado.Apellido = empleado.Apellido.Trim();
            empleado.DUI = empleado.DUI.Trim();
            empleado.Telefono = empleado.Telefono.Trim();
            empleado.Correo = empleado.Correo.Trim();
            empleado.Direccion = empleado.Direccion.Trim();

            // Validaciones de longitud y formato
            if (empleado.Nombre.Length > 50)
                throw new ArgumentException("El nombre no puede superar los 50 caracteres.");

            if (empleado.Apellido.Length > 50)
                throw new ArgumentException("El apellido no puede superar los 50 caracteres.");

            if (empleado.DUI.Length > 10 || !RegexDui.IsMatch(empleado.DUI))
                throw new ArgumentException("El formato del DUI debe ser 00000000-0.");

            if (empleado.Telefono.Length > 9)
                throw new ArgumentException("El teléfono no puede superar los 9 caracteres.");

            if (empleado.Correo.Length > 100 || !RegexCorreo.IsMatch(empleado.Correo))
                throw new ArgumentException("El formato del correo electrónico no es válido.");

            if (empleado.Direccion.Length > 255)
                throw new ArgumentException("La dirección no puede superar los 255 caracteres.");

            if (empleado.FechaContratacion == default(DateTime))
                throw new ArgumentException("Debe seleccionar una fecha de contratación válida.");
        }
    }
}