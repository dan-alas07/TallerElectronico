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

        public List<Usuario> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Usuario.AsNoTracking()
                                 .Include(u => u.Rol)
                                 .Include(u => u.Empleado)
                                 .Where(u => u.Estado == "A")
                                 .ToList();
            }
        }

        public Usuario SelectById(int idUsuario)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Usuario.AsNoTracking()
                                 .Include(u => u.Rol)
                                 .Include(u => u.Empleado)
                                 .FirstOrDefault(u => u.UsuarioId == idUsuario && u.Estado == "A");
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

                    if (!string.IsNullOrEmpty(usuarioModificado.Clave))
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
