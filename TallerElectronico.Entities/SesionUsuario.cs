using System;

namespace TallerElectronico.Entities
{
    public static class SesionUsuario
    {
        // Propiedades de identidad y sesión
        public static int UsuarioId { get; private set; }
        public static string NombreUsuario { get; private set; }
        public static int? EmpleadoId { get; private set; }
        public static string NombreEmpleado { get; private set; }
        public static int? RolId { get; private set; }
        public static string RolNombre { get; private set; }
        public static bool EstaAutenticado { get; private set; }

        public static void IniciarSesion(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "No se proporcionó una instancia válida de usuario.");

            UsuarioId = usuario.UsuarioId;
            NombreUsuario = usuario.Nombre;
            EmpleadoId = usuario.EmpleadoId;
            RolId = usuario.RolId;

            // Lee la navegación virtual Empleado cargada por EF; si viene nula toma el nombre de cuenta
            NombreEmpleado = usuario.Empleado != null ? $"{usuario.Empleado.Nombre} {usuario.Empleado.Apellido}".Trim() : usuario.Nombre;

            RolNombre = usuario.Rol != null ? usuario.Rol.Nombre : "Sin Rol";

            EstaAutenticado = true;
        }

        public static void CerrarSesion()
        {
            UsuarioId = 0;
            NombreUsuario = null;
            EmpleadoId = null;
            NombreEmpleado = null;
            RolId = null;
            RolNombre = null;
            EstaAutenticado = false;
        }
    }
}