using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    namespace TallerElectronico.Entities
    {
        public class Marca
        {
            public int MarcaId { get; set; }
            public string Nombre { get; set; }
            public bool Activo { get; set; }

            public Marca()
            {
            }

            public Marca(string nombre, bool activo)
            {
                Nombre = nombre;
                Activo = activo;
            }

            public Marca(int marcaId, string nombre, bool activo)
            {
                MarcaId = marcaId;
                Nombre = nombre;
                Activo = activo;
            }
        }
    }
}
