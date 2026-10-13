using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public int RolId { get; set; }
        public int EstadoUsuarioId { get; set; }

        public Usuario()
        {
        }

        public Usuario(int empleadoId, string nombre, string clave,
            int rolId, int estadoUsuarioId)
        {
            EmpleadoId = empleadoId;
            Nombre = nombre;
            Clave = clave;
            RolId = rolId;
            EstadoUsuarioId = estadoUsuarioId;
        }

        public Usuario(int usuarioId, int empleadoId, string nombre,
            string clave, int rolId, int estadoUsuarioId)
        {
            UsuarioId = usuarioId;
            EmpleadoId = empleadoId;
            Nombre = nombre;
            Clave = clave;
            RolId = rolId;
            EstadoUsuarioId = estadoUsuarioId;
        }
    }
}