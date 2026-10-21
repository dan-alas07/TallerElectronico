using System;
using System.Collections.Generic;
using System.Linq;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class RolBL
    {
        private readonly RolDAL _rolDal = new RolDAL();

        public List<Rol> SelectAll()
        {
            return _rolDal.SelectAll();
        }

        public Rol SelectById(int idRol)
        {
            if (idRol <= 0)
                throw new ArgumentException("El ID de rol proporcionado no es válido.");

            return _rolDal.SelectById(idRol);
        }

        public Rol Insert(Rol rol)
        {
            if (rol == null)
                throw new ArgumentNullException(nameof(rol), "Los datos del rol son requeridos.");

            if (string.IsNullOrWhiteSpace(rol.Nombre))
                throw new ArgumentException("El nombre del rol es obligatorio.");

            rol.Nombre = rol.Nombre.Trim();

            // Validar longitud de Nombre según el esquema SQL
            if (rol.Nombre.Length > 50)
                throw new ArgumentException("El nombre del rol no puede superar los 50 caracteres.");

            // Validar unicidad de Nombre
            var listaRoles = _rolDal.SelectAll();
            if (listaRoles.Any(r => r.Nombre.Equals(rol.Nombre, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"El rol '{rol.Nombre}' ya se encuentra registrado.");

            rol.Estado = "A";

            return _rolDal.Insert(rol);
        }

        public Rol Update(Rol rolModificado)
        {
            if (rolModificado == null)
                throw new ArgumentNullException(nameof(rolModificado), "Los datos del rol son requeridos.");

            if (rolModificado.RolId <= 0)
                throw new ArgumentException("El ID de rol no es válido.");

            if (string.IsNullOrWhiteSpace(rolModificado.Nombre))
                throw new ArgumentException("El nombre del rol es obligatorio.");

            rolModificado.Nombre = rolModificado.Nombre.Trim();

            // Validar longitud de Nombre
            if (rolModificado.Nombre.Length > 50)
                throw new ArgumentException("El nombre del rol no puede superar los 50 caracteres.");

            var listaRoles = _rolDal.SelectAll();

            // Validar que el nombre no pertenezca a otro rol diferente
            if (listaRoles.Any(r => r.Nombre.Equals(rolModificado.Nombre, StringComparison.OrdinalIgnoreCase)
                                 && r.RolId != rolModificado.RolId))
            {
                throw new InvalidOperationException($"El rol '{rolModificado.Nombre}' ya está siendo usado por otro registro.");
            }

            var rolExistente = _rolDal.SelectById(rolModificado.RolId);
            if (rolExistente == null)
                throw new InvalidOperationException($"El rol con ID {rolModificado.RolId} no existe o se encuentra inactivo.");

            return _rolDal.Update(rolModificado);
        }

        public bool Delete(int idRol)
        {
            if (idRol <= 0)
                throw new ArgumentException("El ID de rol no es válido.");

            var rolExistente = _rolDal.SelectById(idRol);
            if (rolExistente == null)
                throw new InvalidOperationException($"El rol con ID {idRol} no existe o ya se encuentra inactivo.");

            return _rolDal.Delete(idRol);
        }
    }
}