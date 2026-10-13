using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class TipoEquipo
    {
        public int TipoEquipoId { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public TipoEquipo()
        {
        }

        public TipoEquipo(string nombre, bool activo)
        {
            Nombre = nombre;
            Activo = activo;
        }

        public TipoEquipo(int tipoEquipoId, string nombre, bool activo)
        {
            TipoEquipoId = tipoEquipoId;
            Nombre = nombre;
            Activo = activo;
        }
    }
}
