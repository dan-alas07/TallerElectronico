using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class EstadoProveedor
    {
        public int EstadoProveedorId { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public EstadoProveedor()
        {
        }

        public EstadoProveedor(string nombre, bool activo)
        {
            Nombre = nombre;
            Activo = activo;
        }

        public EstadoProveedor(int estadoProveedorId, string nombre, bool activo)
        {
            EstadoProveedorId = estadoProveedorId;
            Nombre = nombre;
            Activo = activo;
        }
    }
}