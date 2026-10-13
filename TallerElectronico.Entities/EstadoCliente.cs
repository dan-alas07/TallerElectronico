using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class EstadoCliente
    {
        public int EstadoClienteId { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public EstadoCliente()
        {
        }

        public EstadoCliente(string nombre, bool activo)
        {
            Nombre = nombre;
            Activo = activo;
        }

        public EstadoCliente(int estadoClienteId, string nombre, bool activo)
        {
            EstadoClienteId = estadoClienteId;
            Nombre = nombre;
            Activo = activo;
        }
    }
}