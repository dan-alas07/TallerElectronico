using System;
using System.Collections.Generic;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class UsuarioBL
    {
        private readonly UsuarioDAL _usuarioDAL = new UsuarioDAL();

        public Usuario Login(string nombreUsuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La contraseña es obligatoria.");

            var usuario = _usuarioDAL.SelectByUsername(nombreUsuario.Trim());

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(clave, usuario.Clave))
            {
                return null;
            }

            return usuario;
        }

        public List<UsuarioDTO> SelectAll()
        {
            return _usuarioDAL.SelectAll();
        }

        public UsuarioDTO SelectById(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new ArgumentException("El ID de usuario proporcionado no es válido.");

            return _usuarioDAL.SelectById(idUsuario);
        }

        public Usuario Insert(Usuario usuario)
        {
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "Los datos del usuario son requeridos.");

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(usuario.Clave))
                throw new ArgumentException("La contraseña es obligatoria.");

            usuario.Nombre = usuario.Nombre.Trim();

            // Validar longitud de Nombre
            if (usuario.Nombre.Trim().Length > 50)
                throw new ArgumentException("El nombre de usuario no puede superar los 50 caracteres.");

            // Validar longitud de Clave antes del Hash
            if (usuario.Clave.Length > 70)
                throw new ArgumentException("La contraseña no puede superar los 70 caracteres.");

            if (usuario.RolId <= 0)
                throw new ArgumentException("Debe seleccionar un rol válido.");

            if (usuario.EmpleadoId <= 0)
                throw new ArgumentException("Debe asociar un empleado válido.");

            var usuarioExistente = _usuarioDAL.SelectByUsername(usuario.Nombre);
            if (usuarioExistente != null)
                throw new InvalidOperationException($"El nombre de usuario '{usuario.Nombre}' ya se encuentra registrado.");

            usuario.Clave = BCrypt.Net.BCrypt.HashPassword(usuario.Clave);
            usuario.Estado = "A";

            return _usuarioDAL.Insert(usuario);
        }

        public void Update(Usuario usuario)
        {
            // 1. Validaciones de Reglas de Negocio
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "Los datos del usuario no son válidos.");

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new Exception("El nombre de usuario es obligatorio.");

            if (usuario.Nombre.Length < 3)
                throw new Exception("El nombre de usuario debe tener al menos 3 caracteres.");

            if (usuario.EmpleadoId <= 0)
                throw new Exception("Debe seleccionar un empleado válido.");

            if (usuario.RolId <= 0)
                throw new Exception("Debe seleccionar un rol válido.");

            // 2. Validación de duplicados (Ejemplo: Que no exista otro usuario con el mismo nombre)
            var usuarioExistente = _usuarioDAL.SelectByUsername(usuario.Nombre);
            if (usuarioExistente != null && usuarioExistente.UsuarioId != usuario.UsuarioId)
            {
                throw new Exception("El nombre de usuario ya está registrado por otro empleado.");
            }

            // 3. Persistencia
            _usuarioDAL.Update(usuario);
        }

        public bool Delete(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new ArgumentException("El ID de usuario no es válido.");

            return _usuarioDAL.Delete(idUsuario);
        }
    }
}
