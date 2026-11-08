using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class UsuarioDAL
    {
        private string TransformarEstadoParaUI(string estado)
        {
            return estado == "A" ? "Activo" : "Inactivo";
        }
        public Usuario SelectByUsername(string username)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Usuario.AsNoTracking()
                                 .Include(u => u.Empleado)
                                 .Include(u => u.Rol)
                                 .FirstOrDefault(u => u.Nombre == username && u.Estado == "A");
            }
        }

        public List<UsuarioDTO> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Usuario
                         .AsNoTracking()
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
                var usuario = db.Usuario
                        .AsNoTracking()
                         .Where(u => u.UsuarioId == idUsuario && u.Estado == "A")
                         .Select(u => new UsuarioDTO
                         {
                             Id = u.UsuarioId,
                             Nombre = u.Nombre,
                             Clave = string.Empty,
                             EmpleadoId = u.EmpleadoId,
                             RolId = u.RolId,
                             EmpleadoNombre = u.Empleado != null
                                 ? u.Empleado.Nombre + " " + u.Empleado.Apellido
                                 : "Sin Asignar",
                             RolNombre = u.Rol != null ? u.Rol.Nombre : "Sin Rol",
                             Estado = u.Estado
                         })
                         .FirstOrDefault();
                if (usuario != null)
                {
                    usuario.Estado = TransformarEstadoParaUI(usuario.Estado);
                }

                return usuario;
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

        public List<UsuarioDTO> Search(string criterio)
        {
            using (var db = new TallerElectronicoEntities())
            {
                IQueryable<Usuario>  query = db.Usuario
                              .AsNoTracking();

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim().ToLower();
                    int idBusqueda;
                    bool esNumero = int.TryParse(criterio, out idBusqueda);

                    query = query.Where(u =>
                        (esNumero && u.UsuarioId == idBusqueda) ||
                        (u.Nombre != null && u.Nombre.Contains(criterio)) ||
                        (u.Empleado != null && u.Empleado.Nombre.Contains(criterio)) ||
                        (u.Empleado != null && u.Empleado.Apellido.Contains(criterio)) ||
                        (u.Rol != null && u.Rol.Nombre.Contains(criterio))
                    );
                }

                var lista = query.OrderBy(u => u.Nombre)
                                 .Select(u => new UsuarioDTO
                                 {
                                     Id = u.UsuarioId,
                                     Nombre = u.Nombre,
                                     Clave = string.Empty,
                                     EmpleadoNombre = u.Empleado != null
                                 ? u.Empleado.Nombre + " " + u.Empleado.Apellido
                                 : "Sin Asignar",
                                     RolNombre = u.Rol != null ? u.Rol.Nombre : "Sin Rol",
                                     Estado = u.Estado
                                 })
                                 .ToList();

                lista.ForEach(u => u.Estado = TransformarEstadoParaUI(u.Estado));
                return lista;
            }
        }
    }
}