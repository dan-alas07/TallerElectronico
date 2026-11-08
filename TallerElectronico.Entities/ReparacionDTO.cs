using System;

namespace TallerElectronico.Entities
{
    public class ReparacionDTO
    {
        // Identificador 
        public int ReparacionId { get; set; }
        public string CodigoSeguimiento { get; set; }

        // Campos para listados y vistas
        public string Modelo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public decimal CostoManoObra { get; set; }
        public decimal TotalReparacion { get; set; }

        // JOIN
        public string EstadoNombre { get; set; }    
        public string TipoEquipoNombre { get; set; }  
        public string MarcaNombre { get; set; }   
        public string ClienteNombre { get; set; } 
        public string Correo { get; set; }     
        public string TecnicoNombre { get; set; }    

        // Propiedad combinada para el pdf
        public string EquipoCompleto { get; set; }   
    }

    public class KpiDashboardDTO
    {
        public int OrdenesAbiertas { get; set; }
        public int OrdenesListas { get; set; }
        public int OrdenesEntregadas { get; set; }
    }
}