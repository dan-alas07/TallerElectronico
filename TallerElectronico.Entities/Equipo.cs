using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class Equipo
    {
        public int EquipoId { get; set; }
        public string CodigoSeguimiento { get; set; }
        public int TipoEquipoId { get; set; }
        public int MarcaId { get; set; }
        public string Modelo { get; set; }
        public string DiagnosticoInicial { get; set; }
        public string Observaciones { get; set; }
        public int EstadoEquipoId { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public int ClienteId { get; set; }
        public int? TecnicoAsignadoId { get; set; }

        public Equipo()
        {
        }

        public Equipo(string codigoSeguimiento, int tipoEquipoId,
            int marcaId, string modelo, string diagnosticoInicial,
            string observaciones, int estadoEquipoId,
            DateTime fechaIngreso, DateTime? fechaEntrega,
            int clienteId, int? tecnicoAsignadoId)
        {
            CodigoSeguimiento = codigoSeguimiento;
            TipoEquipoId = tipoEquipoId;
            MarcaId = marcaId;
            Modelo = modelo;
            DiagnosticoInicial = diagnosticoInicial;
            Observaciones = observaciones;
            EstadoEquipoId = estadoEquipoId;
            FechaIngreso = fechaIngreso;
            FechaEntrega = fechaEntrega;
            ClienteId = clienteId;
            TecnicoAsignadoId = tecnicoAsignadoId;
        }

        public Equipo(int equipoId, string codigoSeguimiento,
            int tipoEquipoId, int marcaId, string modelo,
            string diagnosticoInicial, string observaciones,
            int estadoEquipoId, DateTime fechaIngreso,
            DateTime? fechaEntrega, int clienteId,
            int? tecnicoAsignadoId)
        {
            EquipoId = equipoId;
            CodigoSeguimiento = codigoSeguimiento;
            TipoEquipoId = tipoEquipoId;
            MarcaId = marcaId;
            Modelo = modelo;
            DiagnosticoInicial = diagnosticoInicial;
            Observaciones = observaciones;
            EstadoEquipoId = estadoEquipoId;
            FechaIngreso = fechaIngreso;
            FechaEntrega = fechaEntrega;
            ClienteId = clienteId;
            TecnicoAsignadoId = tecnicoAsignadoId;
        }
    }
}