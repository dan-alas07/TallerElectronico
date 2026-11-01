using System;

namespace TallerElectronico.Entities
{
    public class ReparacionDTO
    {
        // Identificador primario
        public int ReparacionId { get; set; }
        public string CodigoSeguimiento { get; set; }

        // Campos propios necesarios para listados y vistas
        public string Modelo { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public decimal CostoManoObra { get; set; }
        public decimal TotalReparacion { get; set; }

        // Textos resueltos mediante JOINs (para evitar navegación diferida en la UI)
        public string EstadoNombre { get; set; }        // EstadoReparacion.Nombre
        public string TipoEquipoNombre { get; set; }    // TipoEquipo.Nombre
        public string MarcaNombre { get; set; }         // Marca.Nombre
        public string ClienteNombre { get; set; }       // Cliente.Nombre + " " + Cliente.Apellido
        public string TecnicoNombre { get; set; }       // Empleado.Nombre + " " + Empleado.Apellido (o "Sin Asignar")

        // Propiedad combinada útil para la grilla compacta de Inicio
        public string EquipoCompleto { get; set; }      // TipoEquipo + " " + Marca + " " + Modelo
    }

    public class KpiDashboardDTO
    {
        public int OrdenesAbiertas { get; set; }
        public int OrdenesListas { get; set; }
        public int OrdenesEntregadas { get; set; }
    }
}