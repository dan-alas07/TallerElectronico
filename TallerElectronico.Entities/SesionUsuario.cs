using System;
using System.Linq;

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

        // Propiedades booleanas
        public static bool EsAdmin => string.Equals(RolNombre, "Administrador", StringComparison.OrdinalIgnoreCase);

        public static bool EsTecnico => string.Equals(RolNombre, "Técnico", StringComparison.OrdinalIgnoreCase) ||
                                        string.Equals(RolNombre, "Tecnico", StringComparison.OrdinalIgnoreCase);

        public static bool EsRecepcionista => string.Equals(RolNombre, "Recepcionista", StringComparison.OrdinalIgnoreCase);

        // Método de soporte para evaluar múltiples roles a la vez
        public static bool TieneRol(params string[] roles)
        {
            if (string.IsNullOrWhiteSpace(RolNombre) || roles == null)
                return false;

            return roles.Any(r => string.Equals(r, RolNombre, StringComparison.OrdinalIgnoreCase));
        }

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