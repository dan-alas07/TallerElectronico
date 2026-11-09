using System;
using System.Collections.Generic;

namespace TallerElectronico.Entities
{
    public class ReparacionDTO
    {
        // Identificador 
        public int ReparacionId { get; set; }
        public string CodigoSeguimiento { get; set; }

        public string Modelo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public decimal CostoManoObra { get; set; }
        public decimal TotalReparacion { get; set; }

        public string EstadoNombre { get; set; }
        public string TipoEquipoNombre { get; set; }
        public string MarcaNombre { get; set; }

        // Datos de Cliente
        public string ClienteNombre { get; set; }
        public string ClienteApellido { get; set; }
        public string ClienteNombreCompleto => $"{ClienteNombre} {ClienteApellido}".Trim();

        public string Correo { get; set; }
        public string TecnicoNombre { get; set; }

        // Propiedad para el pdf
        public string EquipoCompleto { get; set; }

        // Lista de detalle
        public List<DetalleReparacionDTO> Detalles { get; set; } = new List<DetalleReparacionDTO>();
    }

    public class KpiDashboardDTO
    {
        public int OrdenesAbiertas { get; set; }
        public int OrdenesListas { get; set; }
        public int OrdenesEntregadas { get; set; }
    }
}