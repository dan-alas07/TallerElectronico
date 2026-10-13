using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class Rol
    {
        public int RolId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }

        public Rol()
        {
        }

        public Rol(string nombre, string descripcion, bool activo)
        {
            Nombre = nombre;
            Descripcion = descripcion;
            Activo = activo;
        }

        public Rol(int rolId, string nombre, string descripcion, bool activo)
        {
            RolId = rolId;
            Nombre = nombre;
            Descripcion = descripcion;
            Activo = activo;
        }
    }
}
