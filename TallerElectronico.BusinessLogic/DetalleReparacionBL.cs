using System;
using System.Collections.Generic;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class DetalleReparacionBL
    {
        private readonly DetalleReparacionDAL _detalleReparacionDal = new DetalleReparacionDAL();
        private readonly ReparacionDAL _reparacionDal = new ReparacionDAL();
        private readonly ProductoDAL _productoDal = new ProductoDAL();

        public List<DetalleReparacion> SelectAll()
        {
            return _detalleReparacionDal.SelectAll();
        }

        public List<DetalleReparacion> SelectByReparacionId(int idReparacion)
        {
            if (idReparacion <= 0)
                throw new ArgumentException("El ID de reparación proporcionado no es válido.");

            return _detalleReparacionDal.SelectByReparacionId(idReparacion);
        }

        public DetalleReparacion SelectById(int idDetalleReparacion)
        {
            if (idDetalleReparacion <= 0)
                throw new ArgumentException("El ID de detalle de reparación proporcionado no es válido.");

            return _detalleReparacionDal.SelectById(idDetalleReparacion);
        }

        public DetalleReparacion Insert(DetalleReparacion detalleReparacion)
        {
            if (detalleReparacion == null)
                throw new ArgumentNullException(nameof(detalleReparacion), "Los datos del detalle de reparación son requeridos.");

            if (detalleReparacion.ReparacionId <= 0)
                throw new ArgumentException("Debe asociar una reparación válida.");

            if (detalleReparacion.ProductoId <= 0)
                throw new ArgumentException("Debe seleccionar un producto o repuesto válido.");

            if (detalleReparacion.UsuarioCreacionId <= 0)
                throw new ArgumentException("Debe especificar el usuario que registra el detalle.");

            if (detalleReparacion.CantidadUtilizada <= 0)
                throw new ArgumentException("La cantidad utilizada debe ser un número entero mayor a cero.");

            var reparacionExistente = _reparacionDal.SelectById(detalleReparacion.ReparacionId);
            if (reparacionExistente == null)
                throw new InvalidOperationException($"La reparación con ID {detalleReparacion.ReparacionId} no existe en el sistema.");

            var productoExistente = _productoDal.SelectById(detalleReparacion.ProductoId);
            if (productoExistente == null)
                throw new InvalidOperationException($"El producto o repuesto con ID {detalleReparacion.ProductoId} no existe o está inactivo.");

            // Congelamiento de precio histórico (si no viene asignado explícitamente)
            if (detalleReparacion.PrecioUnitarioHistorico <= 0)
            {
                detalleReparacion.PrecioUnitarioHistorico = productoExistente.PrecioUnitario;
            }

            if (detalleReparacion.PrecioUnitarioHistorico < 0)
                throw new ArgumentException("El precio unitario histórico no puede ser negativo.");

            return _detalleReparacionDal.Insert(detalleReparacion);
        }

        public DetalleReparacion Update(DetalleReparacion detalleReparacionModificado)
        {
            if (detalleReparacionModificado == null)
                throw new ArgumentNullException(nameof(detalleReparacionModificado), "Los datos del detalle de reparación son requeridos.");

            if (detalleReparacionModificado.DetalleReparacionId <= 0)
                throw new ArgumentException("El ID de detalle de reparación no es válido.");

            if (detalleReparacionModificado.ReparacionId <= 0)
                throw new ArgumentException("Debe asociar una reparación válida.");

            if (detalleReparacionModificado.ProductoId <= 0)
                throw new ArgumentException("Debe seleccionar un producto o repuesto válido.");

            if (!detalleReparacionModificado.UsuarioModificacionId.HasValue || detalleReparacionModificado.UsuarioModificacionId.Value <= 0)
                throw new ArgumentException("Debe especificar el usuario que realiza la modificación.");

            if (detalleReparacionModificado.CantidadUtilizada <= 0)
                throw new ArgumentException("La cantidad utilizada debe ser mayor a cero.");

            if (detalleReparacionModificado.PrecioUnitarioHistorico < 0)
                throw new ArgumentException("El precio unitario histórico no puede ser negativo.");

            var detalleExistente = _detalleReparacionDal.SelectById(detalleReparacionModificado.DetalleReparacionId);
            if (detalleExistente == null)
                throw new InvalidOperationException($"El detalle de reparación con ID {detalleReparacionModificado.DetalleReparacionId} no existe.");

            return _detalleReparacionDal.Update(detalleReparacionModificado);
        }

        public bool Delete(int idDetalleReparacion)
        {
            if (idDetalleReparacion <= 0)
                throw new ArgumentException("El ID de detalle de reparación no es válido.");

            var detalleExistente = _detalleReparacionDal.SelectById(idDetalleReparacion);
            if (detalleExistente == null)
                throw new InvalidOperationException($"El detalle de reparación con ID {idDetalleReparacion} no existe o ya fue eliminado.");

            return _detalleReparacionDal.Delete(idDetalleReparacion);
        }
    }
}