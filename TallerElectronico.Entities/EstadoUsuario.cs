using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class EstadoUsuario
    {
        public int EstadoUsuarioId { get; set; }
        public string Nombre { get; set; }
        public bool Activo { get; set; }

        public EstadoUsuario()
        {
        }

        public EstadoUsuario(string nombre, bool activo)
        {
            Nombre = nombre;
            Activo = activo;
        }

        public EstadoUsuario(int estadoUsuarioId, string nombre, bool activo)
        {
            EstadoUsuarioId = estadoUsuarioId;
            Nombre = nombre;
            Activo = activo;
        }
    }
}