using System;

namespace TallerElectronico.Entities
{
    public class DetalleReparacionDTO
    {
        // Clave primaria
        public int DetalleReparacionId { get; set; }

        // Claves Foráneas de control interno (para búsquedas y ediciones)
        public int ReparacionId { get; set; }
        public int ProductoId { get; set; }

        // Datos del detalle de uso
        public int CantidadUtilizada { get; set; }
        public decimal PrecioUnitarioHistorico { get; set; }
        public decimal Subtotal { get; set; }
        public DateTime FechaUso { get; set; }

        // Campos de auditoría
        public int UsuarioCreacionId { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public int? UsuarioModificacionId { get; set; }

        // Propiedades descriptivas traídas mediante JOIN para el DataGridView
        public string ReparacionCodigo { get; set; } // Ejemplo: "REP-20261101-001"
        public string ProductoNombre { get; set; }   // Nombre del repuesto/producto
        public string UsuarioCreacionNombre { get; set; }
    }
}