using System;

namespace TallerElectronico.Entities
{
    public class ProductoDTO
    {
        // Identificador del producto
        public int ProductoId { get; set; }

        // Datos propios del producto
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CantidadStock { get; set; }
        public decimal PrecioUnitario { get; set; }
        public string Estado { get; set; }

        // Claves Foráneas
        public int ProveedorId { get; set; }
        public int UsuarioCreacionId { get; set; }

        // Nombres descriptivos traídos mediante JOIN para el DataGridView
        public string ProveedorNombre { get; set; }
        public string UsuarioCreacionNombre { get; set; }
    }
}