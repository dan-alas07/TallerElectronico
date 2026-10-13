using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class DetalleProductoEquipo
    {
        public int DetalleProductoId { get; set; }
        public int EquipoId { get; set; }
        public int ProductoId { get; set; }
        public int CantidadUtilizada { get; set; }
        public decimal PrecioAplicado { get; set; }
        public DateTime FechaUso { get; set; }

        public DetalleProductoEquipo()
        {
        }

        public DetalleProductoEquipo(int equipoId, int productoId,
            int cantidadUtilizada, decimal precioAplicado,
            DateTime fechaUso)
        {
            EquipoId = equipoId;
            ProductoId = productoId;
            CantidadUtilizada = cantidadUtilizada;
            PrecioAplicado = precioAplicado;
            FechaUso = fechaUso;
        }

        public DetalleProductoEquipo(int detalleProductoId,
            int equipoId, int productoId, int cantidadUtilizada,
            decimal precioAplicado, DateTime fechaUso)
        {
            DetalleProductoId = detalleProductoId;
            EquipoId = equipoId;
            ProductoId = productoId;
            CantidadUtilizada = cantidadUtilizada;
            PrecioAplicado = precioAplicado;
            FechaUso = fechaUso;
        }
    }
}