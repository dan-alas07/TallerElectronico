using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class EstadoProducto
    {
        public int EstadoProductoId { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public EstadoProducto()
        {
        }

        public EstadoProducto(string nombre, bool activo)
        {
            Nombre = nombre;
            Activo = activo;
        }

        public EstadoProducto(int estadoProductoId, string nombre, bool activo)
        {
            EstadoProductoId = estadoProductoId;
            Nombre = nombre;
            Activo = activo;
        }
    }
}