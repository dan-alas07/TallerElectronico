using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class UsuarioDTO
    {
        // Identificador del usuario
        public int Id { get; set; }

        // Datos propios del usuario
        public string Nombre { get; set; }
        public string Clave { get; set; }
        public string Estado { get; set; }

        // IDs numéricos (Claves Foráneas) necesarios para los ComboBoxes al editar o crear
        public int? EmpleadoId { get; set; }
        public int? RolId { get; set; }

        // Nombres formateados para las columnas del DataGridView
        public string EmpleadoNombre { get; set; }
        public string RolNombre { get; set; }
    }
}
