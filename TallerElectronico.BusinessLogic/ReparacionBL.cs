using System;
using System.Collections.Generic;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class ReparacionBL
    {
        private readonly ReparacionDAL _reparacionDal = new ReparacionDAL();

        public List<Reparacion> SelectAll()
        {
            return _reparacionDal.SelectAll();
        }

        public Reparacion SelectById(int idReparacion)
        {
            if (idReparacion <= 0)
                throw new ArgumentException("El ID de reparación proporcionado no es válido.");

            return _reparacionDal.SelectById(idReparacion);
        }

        public Reparacion SelectByTrackingCode(string codigoSeguimiento)
        {
            if (string.IsNullOrWhiteSpace(codigoSeguimiento))
                throw new ArgumentException("El código de seguimiento es obligatorio.");

            return _reparacionDal.SelectByTrackingCode(codigoSeguimiento.Trim());
        }

        public Reparacion Insert(Reparacion reparacion)
        {
            if (reparacion == null)
                throw new ArgumentNullException(nameof(reparacion), "Los datos de la reparación son requeridos.");

            // Validaciones de claves foráneas requeridas
            if (reparacion.ClienteId <= 0)
                throw new ArgumentException("Debe seleccionar un cliente válido.");

            if (reparacion.TipoEquipoId <= 0)
                throw new ArgumentException("Debe seleccionar un tipo de equipo válido.");

            if (reparacion.MarcaId <= 0)
                throw new ArgumentException("Debe seleccionar una marca válida.");

            if (reparacion.EstadoReparacionId <= 0)
                throw new ArgumentException("Debe asignar un estado inicial para la reparación.");

            if (reparacion.UsuarioCreacionId <= 0)
                throw new ArgumentException("Debe especificar el usuario que registra la reparación.");

            // Validación de técnico
            if (reparacion.TecnicoAsignadoId.HasValue && reparacion.TecnicoAsignadoId.Value <= 0)
                throw new ArgumentException("El técnico asignado seleccionado no es válido.");

            // Validaciones de campos de texto
            if (string.IsNullOrWhiteSpace(reparacion.Modelo))
                throw new ArgumentException("El modelo del equipo es obligatorio.");

            if (reparacion.Modelo.Trim().Length > 50)
                throw new ArgumentException("El modelo no puede superar los 50 caracteres.");

            if (string.IsNullOrWhiteSpace(reparacion.DiagnosticoInicial))
                throw new ArgumentException("El diagnóstico o descripción inicial del problema es obligatorio.");

            if (reparacion.DiagnosticoInicial.Trim().Length > 400)
                throw new ArgumentException("El diagnóstico inicial no puede superar los 400 caracteres.");

            // Generación o sanitización de Código de Seguimiento
            if (string.IsNullOrWhiteSpace(reparacion.CodigoSeguimiento))
            {
                reparacion.CodigoSeguimiento = GenerateTrackingCode();
            }
            else
            {
                reparacion.CodigoSeguimiento = reparacion.CodigoSeguimiento.Trim().ToUpper();

                if (reparacion.CodigoSeguimiento.Length > 20)
                    throw new ArgumentException("El código de seguimiento no puede exceder los 20 caracteres.");

                var reparacionExistente = _reparacionDal.SelectByTrackingCode(reparacion.CodigoSeguimiento);
                if (reparacionExistente != null)
                    throw new InvalidOperationException($"El código de seguimiento '{reparacion.CodigoSeguimiento}' ya existe.");
            }

            // Normalización de texto y montos iniciales
            reparacion.Modelo = reparacion.Modelo.Trim();
            reparacion.DiagnosticoInicial = reparacion.DiagnosticoInicial.Trim();

            if (reparacion.CostoManoObra < 0)
                throw new ArgumentException("El costo de mano de obra no puede ser negativo.");

            if (reparacion.TotalReparacion.HasValue && reparacion.TotalReparacion.Value < 0)
                throw new ArgumentException("El total de la reparación no puede ser negativo.");

            if (reparacion.FechaIngreso == default(DateTime))
            {
                reparacion.FechaIngreso = DateTime.Now;
            }

            return _reparacionDal.Insert(reparacion);
        }

        public Reparacion Update(Reparacion reparacionModificada)
        {
            if (reparacionModificada == null)
                throw new ArgumentNullException(nameof(reparacionModificada), "Los datos de la reparación son requeridos.");

            if (reparacionModificada.ReparacionId <= 0)
                throw new ArgumentException("El ID de reparación no es válido.");

            if (reparacionModificada.ClienteId <= 0)
                throw new ArgumentException("Debe seleccionar un cliente válido.");

            if (reparacionModificada.TipoEquipoId <= 0)
                throw new ArgumentException("Debe seleccionar un tipo de equipo válido.");

            if (reparacionModificada.MarcaId <= 0)
                throw new ArgumentException("Debe seleccionar una marca válida.");

            if (reparacionModificada.EstadoReparacionId <= 0)
                throw new ArgumentException("Debe asignar un estado válido a la reparación.");

            if (!reparacionModificada.UsuarioModificacionId.HasValue || reparacionModificada.UsuarioModificacionId.Value <= 0)
                throw new ArgumentException("Debe especificar el usuario que realiza la modificación.");

            if (reparacionModificada.TecnicoAsignadoId.HasValue && reparacionModificada.TecnicoAsignadoId.Value <= 0)
                throw new ArgumentException("El técnico asignado seleccionado no es válido.");

            if (string.IsNullOrWhiteSpace(reparacionModificada.Modelo))
                throw new ArgumentException("El modelo del equipo es obligatorio.");

            if (reparacionModificada.Modelo.Trim().Length > 50)
                throw new ArgumentException("El modelo no puede superar los 50 caracteres.");

            if (string.IsNullOrWhiteSpace(reparacionModificada.DiagnosticoInicial))
                throw new ArgumentException("El diagnóstico inicial es obligatorio.");

            if (reparacionModificada.DiagnosticoInicial.Trim().Length > 400)
                throw new ArgumentException("El diagnóstico inicial no puede superar los 400 caracteres.");

            if (!string.IsNullOrWhiteSpace(reparacionModificada.DiagnosticoFinal) && reparacionModificada.DiagnosticoFinal.Trim().Length > 300)
                throw new ArgumentException("El diagnóstico final no puede superar los 300 caracteres.");

            if (reparacionModificada.CostoManoObra < 0)
                throw new ArgumentException("El costo de mano de obra no puede ser negativo.");

            if (reparacionModificada.TotalReparacion.HasValue && reparacionModificada.TotalReparacion.Value < 0)
                throw new ArgumentException("El total de la reparación no puede ser negativo.");

            // Sanitización de textos
            reparacionModificada.Modelo = reparacionModificada.Modelo.Trim();
            reparacionModificada.DiagnosticoInicial = reparacionModificada.DiagnosticoInicial.Trim();
            reparacionModificada.DiagnosticoFinal = string.IsNullOrWhiteSpace(reparacionModificada.DiagnosticoFinal)
                ? null
                : reparacionModificada.DiagnosticoFinal.Trim();

            return _reparacionDal.Update(reparacionModificada);
        }

        public bool Delete(int idReparacion)
        {
            if (idReparacion <= 0)
                throw new ArgumentException("El ID de reparación no es válido.");

            return _reparacionDal.Delete(idReparacion);
        }

        private string GenerateTrackingCode()
        {
            // Formato estándar: REP-yyyyMMdd-XXXX (ej. REP-20261019-A3F2)
            string fecha = DateTime.Now.ToString("yyyyMMdd");
            string aleatorio = Guid.NewGuid().ToString("N").Substring(0, 4).ToUpper();
            return $"REP-{fecha}-{aleatorio}";
        }
    }
}