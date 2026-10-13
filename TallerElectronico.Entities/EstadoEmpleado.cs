using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class EstadoEmpleado
    {
        public int EstadoEmpleadoId { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public EstadoEmpleado()
        {
        }

        public EstadoEmpleado(string nombre, bool activo)
        {
            Nombre = nombre;
            Activo = activo;
        }

        public EstadoEmpleado(int estadoEmpleadoId, string nombre, bool activo)
        {
            EstadoEmpleadoId = estadoEmpleadoId;
            Nombre = nombre;
            Activo = activo;
        }
    }
}