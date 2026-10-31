using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class UsuarioDAL
    {
        public Usuario SelectByUsername(string username)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Usuario.AsNoTracking()
                                 .FirstOrDefault(u => u.Nombre == username && u.Estado == "A");
            }
        }

        public List<UsuarioDTO> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Usuario
                         .AsNoTracking()
                         .Where(u => u.Estado == "A")
                         .Select(u => new UsuarioDTO
                         {
                             Id = u.UsuarioId,
                             Nombre = u.Nombre,
                             Clave = string.Empty, // No enviamos el hash a la interfaz
                             EmpleadoNombre = u.Empleado != null ? u.Empleado.Nombre + " " + u.Empleado.Apellido : "Sin Asignar",
                             RolNombre = u.Rol != null ? u.Rol.Nombre : "Sin Rol",
                             Estado = u.Estado == "A" ? "Activo" : "Inactivo"
                         }).ToList();
            }
        }

        public UsuarioDTO SelectById(int idUsuario)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Usuario
                         .AsNoTracking()
                         .Where(u => u.UsuarioId == idUsuario && u.Estado == "A")
                         .Select(u => new UsuarioDTO
                         {
                             Id = u.UsuarioId,
                             Nombre = u.Nombre,
                             Clave = string.Empty, // Dejar vacío para el formulario de edición
                             EmpleadoId = u.EmpleadoId,
                             RolId = u.RolId,
                             EmpleadoNombre = u.Empleado != null ? u.Empleado.Nombre + " " + u.Empleado.Apellido : "Sin Asignar",
                             RolNombre = u.Rol != null ? u.Rol.Nombre : "Sin Rol",
                             Estado = u.Estado
                         })
                         .FirstOrDefault();
            }
        }

        public Usuario Insert(Usuario usuario)
        {
            using (var db = new TallerElectronicoEntities())
            {
                usuario.Rol = null;
                usuario.Empleado = null;

                var nuevoUsuario = db.Usuario.Add(usuario);
                db.SaveChanges();
                return nuevoUsuario;
            }
        }

        public Usuario Update(Usuario usuarioModificado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var usuarioExistente = db.Usuario.Find(usuarioModificado.UsuarioId);

                if (usuarioExistente != null)
                {
                    usuarioExistente.Nombre = usuarioModificado.Nombre;
                    usuarioExistente.EmpleadoId = usuarioModificado.EmpleadoId;
                    usuarioExistente.RolId = usuarioModificado.RolId;
                    usuarioExistente.Estado = usuarioModificado.Estado;

                    // Si se ingresó una nueva clave (que viene ya hasheada desde la BL), se actualiza
                    if (!string.IsNullOrWhiteSpace(usuarioModificado.Clave))
                    {
                        usuarioExistente.Clave = usuarioModificado.Clave;
                    }

                    db.SaveChanges();
                }

                return usuarioExistente;
            }
        }

        public bool Delete(int idUsuario)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var usuario = db.Usuario.Find(idUsuario);

                if (usuario != null)
                {
                    usuario.Estado = "I";
                    return db.SaveChanges() > 0;
                }

                return false;
            }
        }
    }
}