using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class ProveedorBL
    {
        private readonly ProveedorDAL _proveedorDal = new ProveedorDAL();

        public List<Proveedor> SelectAll()
        {
            return _proveedorDal.SelectAll();
        }

        public Proveedor SelectById(int idProveedor)
        {
            if (idProveedor <= 0)
                throw new ArgumentException("El ID de proveedor proporcionado no es válido.");

            return _proveedorDal.SelectById(idProveedor);
        }

        public Proveedor Insert(Proveedor proveedor)
        {
            if (proveedor == null)
                throw new ArgumentNullException(nameof(proveedor), "Los datos del proveedor son requeridos.");

            if (string.IsNullOrWhiteSpace(proveedor.Nombre))
                throw new ArgumentException("El nombre del proveedor es obligatorio.");

            if (string.IsNullOrWhiteSpace(proveedor.TipoProveedor))
                throw new ArgumentException("El tipo de proveedor es obligatorio.");

            if (string.IsNullOrWhiteSpace(proveedor.Telefono))
                throw new ArgumentException("El teléfono es obligatorio.");

            if (string.IsNullOrWhiteSpace(proveedor.Email))
                throw new ArgumentException("El correo electrónico es obligatorio.");

            if (string.IsNullOrWhiteSpace(proveedor.Direccion))
                throw new ArgumentException("La dirección es obligatoria.");

            proveedor.Nombre = proveedor.Nombre.Trim();
            proveedor.TipoProveedor = proveedor.TipoProveedor.Trim().ToUpper();
            proveedor.Telefono = proveedor.Telefono.Trim();
            proveedor.Email = proveedor.Email.Trim();
            proveedor.Direccion = proveedor.Direccion.Trim();

            // Validaciones de longitud según el esquema SQL
            if (proveedor.Nombre.Length > 100)
                throw new ArgumentException("El nombre del proveedor no puede superar los 100 caracteres.");

            if (proveedor.TipoProveedor != "PN" && proveedor.TipoProveedor != "PJ")
                throw new ArgumentException("El tipo de proveedor debe ser 'PN' (Persona Natural) o 'PJ' (Persona Jurídica).");

            if (proveedor.Telefono.Length > 15)
                throw new ArgumentException("El teléfono no puede superar los 15 caracteres.");

            if (proveedor.Email.Length > 100)
                throw new ArgumentException("El correo electrónico no puede superar los 100 caracteres.");

            if (!Regex.IsMatch(proveedor.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("El formato del correo electrónico no es válido.");

            if (proveedor.Direccion.Length > 255)
                throw new ArgumentException("La dirección no puede superar los 255 caracteres.");

            // Validaciones opcionales de documentos
            if (!string.IsNullOrWhiteSpace(proveedor.DUI))
            {
                proveedor.DUI = proveedor.DUI.Trim();
                if (proveedor.DUI.Length > 10)
                    throw new ArgumentException("El DUI no puede superar los 10 caracteres.");

                if (!Regex.IsMatch(proveedor.DUI, @"^\d{8}-\d{1}$"))
                    throw new ArgumentException("El formato del DUI debe ser 00000000-0.");
            }

            if (!string.IsNullOrWhiteSpace(proveedor.NIT))
            {
                proveedor.NIT = proveedor.NIT.Trim();
                if (proveedor.NIT.Length > 20)
                    throw new ArgumentException("El NIT no puede superar los 20 caracteres.");
            }

            if (!string.IsNullOrWhiteSpace(proveedor.NRC))
            {
                proveedor.NRC = proveedor.NRC.Trim();
                if (proveedor.NRC.Length > 20)
                    throw new ArgumentException("El NRC no puede superar los 20 caracteres.");
            }

            // Validar unicidad del Email
            var listaProveedores = _proveedorDal.SelectAll();
            if (listaProveedores.Any(p => p.Email.Equals(proveedor.Email, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"El correo '{proveedor.Email}' ya se encuentra registrado por otro proveedor.");

            proveedor.Estado = "A";

            return _proveedorDal.Insert(proveedor);
        }

        public Proveedor Update(Proveedor proveedorModificado)
        {
            if (proveedorModificado == null)
                throw new ArgumentNullException(nameof(proveedorModificado), "Los datos del proveedor son requeridos.");

            if (proveedorModificado.ProveedorId <= 0)
                throw new ArgumentException("El ID del proveedor no es válido.");

            if (string.IsNullOrWhiteSpace(proveedorModificado.Nombre))
                throw new ArgumentException("El nombre del proveedor es obligatorio.");

            if (string.IsNullOrWhiteSpace(proveedorModificado.TipoProveedor))
                throw new ArgumentException("El tipo de proveedor es obligatorio.");

            if (string.IsNullOrWhiteSpace(proveedorModificado.Telefono))
                throw new ArgumentException("El teléfono es obligatorio.");

            if (string.IsNullOrWhiteSpace(proveedorModificado.Email))
                throw new ArgumentException("El correo electrónico es obligatorio.");

            if (string.IsNullOrWhiteSpace(proveedorModificado.Direccion))
                throw new ArgumentException("La dirección es obligatoria.");

            proveedorModificado.Nombre = proveedorModificado.Nombre.Trim();
            proveedorModificado.TipoProveedor = proveedorModificado.TipoProveedor.Trim().ToUpper();
            proveedorModificado.Telefono = proveedorModificado.Telefono.Trim();
            proveedorModificado.Email = proveedorModificado.Email.Trim();
            proveedorModificado.Direccion = proveedorModificado.Direccion.Trim();

            if (proveedorModificado.Nombre.Length > 100)
                throw new ArgumentException("El nombre del proveedor no puede superar los 100 caracteres.");

            if (proveedorModificado.TipoProveedor != "PN" && proveedorModificado.TipoProveedor != "PJ")
                throw new ArgumentException("El tipo de proveedor debe ser 'PN' (Persona Natural) o 'PJ' (Persona Jurídica).");

            if (proveedorModificado.Telefono.Length > 15)
                throw new ArgumentException("El teléfono no puede superar los 15 caracteres.");

            if (proveedorModificado.Email.Length > 100)
                throw new ArgumentException("El correo electrónico no puede superar los 100 caracteres.");

            if (!Regex.IsMatch(proveedorModificado.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("El formato del correo electrónico no es válido.");

            if (proveedorModificado.Direccion.Length > 255)
                throw new ArgumentException("La dirección no puede superar los 255 caracteres.");

            if (!string.IsNullOrWhiteSpace(proveedorModificado.DUI))
            {
                proveedorModificado.DUI = proveedorModificado.DUI.Trim();
                if (proveedorModificado.DUI.Length > 10)
                    throw new ArgumentException("El DUI no puede superar los 10 caracteres.");

                if (!Regex.IsMatch(proveedorModificado.DUI, @"^\d{8}-\d{1}$"))
                    throw new ArgumentException("El formato del DUI debe ser 00000000-0.");
            }

            if (!string.IsNullOrWhiteSpace(proveedorModificado.NIT))
            {
                proveedorModificado.NIT = proveedorModificado.NIT.Trim();
                if (proveedorModificado.NIT.Length > 20)
                    throw new ArgumentException("El NIT no puede superar los 20 caracteres.");
            }

            if (!string.IsNullOrWhiteSpace(proveedorModificado.NRC))
            {
                proveedorModificado.NRC = proveedorModificado.NRC.Trim();
                if (proveedorModificado.NRC.Length > 20)
                    throw new ArgumentException("El NRC no puede superar los 20 caracteres.");
            }

            var listaProveedores = _proveedorDal.SelectAll();

            // Validar que el correo no pertenezca a otro proveedor diferente
            if (listaProveedores.Any(p => p.Email.Equals(proveedorModificado.Email, StringComparison.OrdinalIgnoreCase)
                                       && p.ProveedorId != proveedorModificado.ProveedorId))
            {
                throw new InvalidOperationException($"El correo '{proveedorModificado.Email}' ya está siendo usado por otro proveedor.");
            }

            var proveedorExistente = _proveedorDal.SelectById(proveedorModificado.ProveedorId);
            if (proveedorExistente == null)
                throw new InvalidOperationException($"El proveedor con ID {proveedorModificado.ProveedorId} no existe o se encuentra inactivo.");

            return _proveedorDal.Update(proveedorModificado);
        }

        public bool Delete(int idProveedor)
        {
            if (idProveedor <= 0)
                throw new ArgumentException("El ID del proveedor no es válido.");

            var proveedorExistente = _proveedorDal.SelectById(idProveedor);
            if (proveedorExistente == null)
                throw new InvalidOperationException($"El proveedor con ID {idProveedor} no existe o ya se encuentra inactivo.");

            return _proveedorDal.Delete(idProveedor);
        }
    }
}