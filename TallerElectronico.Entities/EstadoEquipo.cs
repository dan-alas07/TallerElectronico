using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class EstadoEquipo
    {
        public int EstadoEquipoId { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public EstadoEquipo()
        {
        }

        public EstadoEquipo(string nombre, bool activo)
        {
            Nombre = nombre;
            Activo = activo;
        }

        public EstadoEquipo(int estadoEquipoId, string nombre, bool activo)
        {
            EstadoEquipoId = estadoEquipoId;
            Nombre = nombre;
            Activo = activo;
        }
    }
}