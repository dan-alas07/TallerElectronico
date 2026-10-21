using System;
using System.Collections.Generic;
using System.Linq;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class TipoEquipoBL
    {
        private readonly TipoEquipoDAL _tipoEquipoDal = new TipoEquipoDAL();

        public List<TipoEquipo> SelectAll()
        {
            return _tipoEquipoDal.SelectAll();
        }

        public TipoEquipo SelectById(int idTipoEquipo)
        {
            if (idTipoEquipo <= 0)
                throw new ArgumentException("El ID de tipo de equipo proporcionado no es válido.");

            return _tipoEquipoDal.SelectById(idTipoEquipo);
        }

        public TipoEquipo Insert(TipoEquipo tipoEquipo)
        {
            if (tipoEquipo == null)
                throw new ArgumentNullException(nameof(tipoEquipo), "Los datos del tipo de equipo son requeridos.");

            if (string.IsNullOrWhiteSpace(tipoEquipo.Nombre))
                throw new ArgumentException("El nombre del tipo de equipo es obligatorio.");

            tipoEquipo.Nombre = tipoEquipo.Nombre.Trim();

            // Validar longitud de Nombre según el esquema SQL
            if (tipoEquipo.Nombre.Length > 100)
                throw new ArgumentException("El nombre del tipo de equipo no puede superar los 100 caracteres.");

            // Validar unicidad de Nombre
            var listaTipos = _tipoEquipoDal.SelectAll();
            if (listaTipos.Any(t => t.Nombre.Equals(tipoEquipo.Nombre, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"El tipo de equipo '{tipoEquipo.Nombre}' ya se encuentra registrado.");

            tipoEquipo.Estado = "A";

            return _tipoEquipoDal.Insert(tipoEquipo);
        }

        public TipoEquipo Update(TipoEquipo tipoEquipoModificado)
        {
            if (tipoEquipoModificado == null)
                throw new ArgumentNullException(nameof(tipoEquipoModificado), "Los datos del tipo de equipo son requeridos.");

            if (tipoEquipoModificado.TipoEquipoId <= 0)
                throw new ArgumentException("El ID de tipo de equipo no es válido.");

            if (string.IsNullOrWhiteSpace(tipoEquipoModificado.Nombre))
                throw new ArgumentException("El nombre del tipo de equipo es obligatorio.");

            tipoEquipoModificado.Nombre = tipoEquipoModificado.Nombre.Trim();

            // Validar longitud de Nombre
            if (tipoEquipoModificado.Nombre.Length > 100)
                throw new ArgumentException("El nombre del tipo de equipo no puede superar los 100 caracteres.");

            var listaTipos = _tipoEquipoDal.SelectAll();

            // Validar que el nombre no pertenezca a otro tipo de equipo diferente
            if (listaTipos.Any(t => t.Nombre.Equals(tipoEquipoModificado.Nombre, StringComparison.OrdinalIgnoreCase)
                                 && t.TipoEquipoId != tipoEquipoModificado.TipoEquipoId))
            {
                throw new InvalidOperationException($"El tipo de equipo '{tipoEquipoModificado.Nombre}' ya está siendo usado por otro registro.");
            }

            var tipoExistente = _tipoEquipoDal.SelectById(tipoEquipoModificado.TipoEquipoId);
            if (tipoExistente == null)
                throw new InvalidOperationException($"El tipo de equipo con ID {tipoEquipoModificado.TipoEquipoId} no existe o se encuentra inactivo.");

            return _tipoEquipoDal.Update(tipoEquipoModificado);
        }

        public bool Delete(int idTipoEquipo)
        {
            if (idTipoEquipo <= 0)
                throw new ArgumentException("El ID de tipo de equipo no es válido.");

            var tipoExistente = _tipoEquipoDal.SelectById(idTipoEquipo);
            if (tipoExistente == null)
                throw new InvalidOperationException($"El tipo de equipo con ID {idTipoEquipo} no existe o ya se encuentra inactivo.");

            return _tipoEquipoDal.Delete(idTipoEquipo);
        }
    }
}