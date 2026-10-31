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

            if (usuario.Nombre.Length > 50)
                throw new ArgumentException("El nombre de usuario no puede superar los 50 caracteres.");

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
            if (usuario == null)
                throw new ArgumentNullException(nameof(usuario), "Los datos del usuario no son válidos.");

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
                throw new InvalidOperationException("El nombre de usuario es obligatorio.");

            if (usuario.Nombre.Trim().Length < 3)
                throw new InvalidOperationException("El nombre de usuario debe tener al menos 3 caracteres.");

            if (usuario.EmpleadoId <= 0)
                throw new InvalidOperationException("Debe seleccionar un empleado válido.");

            if (usuario.RolId <= 0)
                throw new InvalidOperationException("Debe seleccionar un rol válido.");

            // Validar si el nombre ya pertenece a otro usuario
            var usuarioExistente = _usuarioDAL.SelectByUsername(usuario.Nombre.Trim());
            if (usuarioExistente != null && usuarioExistente.UsuarioId != usuario.UsuarioId)
            {
                throw new InvalidOperationException("El nombre de usuario ya está registrado por otro empleado.");
            }

            usuario.Nombre = usuario.Nombre.Trim();

            // Manejo de contraseña al editar:
            // Si el campo tiene texto, validamos la longitud y la encriptamos con BCrypt.
            if (!string.IsNullOrWhiteSpace(usuario.Clave))
            {
                if (usuario.Clave.Length > 70)
                    throw new InvalidOperationException("La contraseña no puede superar los 70 caracteres.");

                usuario.Clave = BCrypt.Net.BCrypt.HashPassword(usuario.Clave.Trim());
            }
            else
            {
                // Si viene vacía, se establece como null para que la DAL preserve la clave actual de la BD
                usuario.Clave = null;
            }

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