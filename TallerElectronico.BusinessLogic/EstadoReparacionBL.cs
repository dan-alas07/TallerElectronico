using System;
using System.Collections.Generic;
using System.Linq;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class EstadoReparacionBL
    {
        private readonly EstadoReparacionDAL _estadoReparacionDal = new EstadoReparacionDAL();

        public List<EstadoReparacion> SelectAll()
        {
            return _estadoReparacionDal.SelectAll();
        }

        public EstadoReparacion SelectById(int idEstadoReparacion)
        {
            if (idEstadoReparacion <= 0)
                throw new ArgumentException("El ID de estado de reparación proporcionado no es válido.");

            return _estadoReparacionDal.SelectById(idEstadoReparacion);
        }

        public EstadoReparacion Insert(EstadoReparacion estadoReparacion)
        {
            if (estadoReparacion == null)
                throw new ArgumentNullException(nameof(estadoReparacion), "Los datos del estado de reparación son requeridos.");

            if (string.IsNullOrWhiteSpace(estadoReparacion.Nombre))
                throw new ArgumentException("El nombre del estado de reparación es obligatorio.");

            estadoReparacion.Nombre = estadoReparacion.Nombre.Trim();

            // Validar longitud del Nombre segun el esquema
            if (estadoReparacion.Nombre.Length > 50)
                throw new ArgumentException("El nombre del estado de reparación no puede superar los 50 caracteres.");

            // Validar unicidad del Nombre
            var listaEstados = _estadoReparacionDal.SelectAll();
            if (listaEstados.Any(e => e.Nombre.Equals(estadoReparacion.Nombre, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"El estado de reparación '{estadoReparacion.Nombre}' ya se encuentra registrado.");

            estadoReparacion.Estado = "A";

            return _estadoReparacionDal.Insert(estadoReparacion);
        }

        public EstadoReparacion Update(EstadoReparacion estadoReparacionModificado)
        {
            if (estadoReparacionModificado == null)
                throw new ArgumentNullException(nameof(estadoReparacionModificado), "Los datos del estado de reparación son requeridos.");

            if (estadoReparacionModificado.EstadoReparacionId <= 0)
                throw new ArgumentException("El ID de estado de reparación no es válido.");

            if (string.IsNullOrWhiteSpace(estadoReparacionModificado.Nombre))
                throw new ArgumentException("El nombre del estado de reparación es obligatorio.");

            estadoReparacionModificado.Nombre = estadoReparacionModificado.Nombre.Trim();

            if (estadoReparacionModificado.Nombre.Length > 50)
                throw new ArgumentException("El nombre del estado de reparación no puede superar los 50 caracteres.");

            var listaEstados = _estadoReparacionDal.SelectAll();

            // Validar que el nombre no pertenezca a otro estado diferente
            if (listaEstados.Any(e => e.Nombre.Equals(estadoReparacionModificado.Nombre, StringComparison.OrdinalIgnoreCase)
                                   && e.EstadoReparacionId != estadoReparacionModificado.EstadoReparacionId))
            {
                throw new InvalidOperationException($"El estado de reparación '{estadoReparacionModificado.Nombre}' ya está siendo usado por otro registro.");
            }

            var estadoExistente = _estadoReparacionDal.SelectById(estadoReparacionModificado.EstadoReparacionId);
            if (estadoExistente == null)
                throw new InvalidOperationException($"El estado de reparación con ID {estadoReparacionModificado.EstadoReparacionId} no existe o está inactivo.");

            return _estadoReparacionDal.Update(estadoReparacionModificado);
        }

        public bool Delete(int idEstadoReparacion)
        {
            if (idEstadoReparacion <= 0)
                throw new ArgumentException("El ID de estado de reparación no es válido.");

            var estadoExistente = _estadoReparacionDal.SelectById(idEstadoReparacion);
            if (estadoExistente == null)
                throw new InvalidOperationException($"El estado de reparación con ID {idEstadoReparacion} no existe o ya está inactivo.");

            return _estadoReparacionDal.Delete(idEstadoReparacion);
        }
    }
}