using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class Producto
    {
        public int ProductoId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int CantidadStock { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int ProveedorId { get; set; }
        public int EstadoProductoId { get; set; }

        public Producto()
        {
        }

        public Producto(string codigo, string nombre,
            string descripcion, int cantidadStock,
            decimal precioUnitario, int proveedorId,
            int estadoProductoId)
        {
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            CantidadStock = cantidadStock;
            PrecioUnitario = precioUnitario;
            ProveedorId = proveedorId;
            EstadoProductoId = estadoProductoId;
        }

        public Producto(int productoId, string codigo,
            string nombre, string descripcion, int cantidadStock,
            decimal precioUnitario, int proveedorId,
            int estadoProductoId)
        {
            ProductoId = productoId;
            Codigo = codigo;
            Nombre = nombre;
            Descripcion = descripcion;
            CantidadStock = cantidadStock;
            PrecioUnitario = precioUnitario;
            ProveedorId = proveedorId;
            EstadoProductoId = estadoProductoId;
        }
    }
}