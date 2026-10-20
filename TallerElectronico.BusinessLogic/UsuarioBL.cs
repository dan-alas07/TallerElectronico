using System;
using System.Collections.Generic;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class UsuarioBL
    {
        private readonly UsuarioDAL _usuarioDal = new UsuarioDAL();

        public Usuario Login(string nombreUsuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            if (string.IsNullOrWhiteSpace(clave))
                throw new ArgumentException("La contraseña es obligatoria.");

            var usuario = _usuarioDal.SelectByUsername(nombreUsuario.Trim());

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(clave, usuario.Clave))
            {
                return null;
            }

            return usuario;
        }

        public List<Usuario> SelectAll()
        {
            return _usuarioDal.SelectAll();
        }

        public Usuario SelectById(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new ArgumentException("El ID de usuario proporcionado no es válido.");

            return _usuarioDal.SelectById(idUsuario);
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

            var usuarioExistente = _usuarioDal.SelectByUsername(usuario.Nombre);
            if (usuarioExistente != null)
                throw new InvalidOperationException($"El nombre de usuario '{usuario.Nombre}' ya se encuentra registrado.");

            usuario.Clave = BCrypt.Net.BCrypt.HashPassword(usuario.Clave);
            usuario.Estado = "A";

            return _usuarioDal.Insert(usuario);
        }

        public Usuario Update(Usuario usuarioModificado)
        {
            if (usuarioModificado == null)
                throw new ArgumentNullException(nameof(usuarioModificado), "Los datos del usuario son requeridos.");

            if (usuarioModificado.UsuarioId <= 0)
                throw new ArgumentException("El ID de usuario no es válido.");

            if (string.IsNullOrWhiteSpace(usuarioModificado.Nombre))
                throw new ArgumentException("El nombre de usuario es obligatorio.");

            usuarioModificado.Nombre = usuarioModificado.Nombre.Trim();

            // Validacion de longitud
            if (usuarioModificado.Nombre.Length > 50)
                throw new ArgumentException("El nombre de usuario no puede superar los 50 caracteres.");

            if (usuarioModificado.RolId <= 0)
                throw new ArgumentException("Debe seleccionar un rol válido.");

            if (usuarioModificado.EmpleadoId <= 0)
                throw new ArgumentException("Debe asociar un empleado válido.");

            var usuarioConMismoNombre = _usuarioDal.SelectByUsername(usuarioModificado.Nombre);
            if (usuarioConMismoNombre != null && usuarioConMismoNombre.UsuarioId != usuarioModificado.UsuarioId)
            {
                throw new InvalidOperationException($"El nombre de usuario '{usuarioModificado.Nombre}' ya está siendo usado por otra cuenta.");
            }

            if (!string.IsNullOrWhiteSpace(usuarioModificado.Clave))
            {
                if (usuarioModificado.Clave.Length > 70)
                    throw new ArgumentException("La nueva contraseña no puede superar los 70 caracteres.");

                usuarioModificado.Clave = BCrypt.Net.BCrypt.HashPassword(usuarioModificado.Clave);
            }
            else
            {
                usuarioModificado.Clave = null;
            }

            return _usuarioDal.Update(usuarioModificado);
        }

        public bool Delete(int idUsuario)
        {
            if (idUsuario <= 0)
                throw new ArgumentException("El ID de usuario no es válido.");

            return _usuarioDal.Delete(idUsuario);
        }
    }
}
