using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class ClienteBL
    {
        private readonly ClienteDAL _clienteDal = new ClienteDAL();

        public List<Cliente> SelectAll()
        {
            return _clienteDal.SelectAll();
        }

        public Cliente SelectById(int idCliente)
        {
            if (idCliente <= 0)
                throw new ArgumentException("El ID de cliente proporcionado no es válido.");

            return _clienteDal.SelectById(idCliente);
        }

        public Cliente Insert(Cliente cliente)
        {
            if (cliente == null)
                throw new ArgumentNullException(nameof(cliente), "Los datos del cliente son requeridos.");

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.Apellido))
                throw new ArgumentException("El apellido del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.Telefono))
                throw new ArgumentException("El teléfono es obligatorio.");

            if (string.IsNullOrWhiteSpace(cliente.TipoDocumento))
                throw new ArgumentException("El tipo de documento es obligatorio.");

            cliente.Nombre = cliente.Nombre.Trim();
            cliente.Apellido = cliente.Apellido.Trim();
            cliente.Telefono = cliente.Telefono.Trim();
            cliente.TipoDocumento = cliente.TipoDocumento.Trim();

            // Validaciones de longitud
            if (cliente.Nombre.Length > 100)
                throw new ArgumentException("El nombre no puede superar los 100 caracteres.");

            if (cliente.Apellido.Length > 100)
                throw new ArgumentException("El apellido no puede superar los 100 caracteres.");

            if (cliente.Telefono.Length > 15)
                throw new ArgumentException("El teléfono no puede superar los 15 caracteres.");

            if (!string.IsNullOrWhiteSpace(cliente.Correo))
            {
                cliente.Correo = cliente.Correo.Trim();
                if (cliente.Correo.Length > 100)
                    throw new ArgumentException("El correo electrónico no puede superar los 100 caracteres.");
            }

            // Validaciones según el Constraint CK_Cliente_Documento
            if (cliente.TipoDocumento == "DUI")
            {
                if (string.IsNullOrWhiteSpace(cliente.DUI))
                    throw new ArgumentException("El número de DUI es obligatorio cuando el tipo de documento es 'DUI'.");

                cliente.DUI = cliente.DUI.Trim();

                if (!Regex.IsMatch(cliente.DUI, @"^\d{8}-\d{1}$"))
                    throw new ArgumentException("El formato del DUI debe ser 00000000-0.");

                cliente.CarnetExtranjero = null;
            }
            else if (cliente.TipoDocumento == "CarnetExtranjero")
            {
                if (string.IsNullOrWhiteSpace(cliente.CarnetExtranjero))
                    throw new ArgumentException("El Carnet de Extranjero es obligatorio cuando el tipo de documento es 'CarnetExtranjero'.");

                cliente.CarnetExtranjero = cliente.CarnetExtranjero.Trim();

                if (cliente.CarnetExtranjero.Length > 20)
                    throw new ArgumentException("El Carnet de Extranjero no puede superar los 20 caracteres.");

                cliente.DUI = null;
            }
            else
            {
                throw new ArgumentException("El tipo de documento debe ser 'DUI' o 'CarnetExtranjero'.");
            }

            cliente.FechaRegistro = DateTime.Now;
            cliente.Estado = "A";

            return _clienteDal.Insert(cliente);
        }

        public Cliente Update(Cliente clienteModificado)
        {
            if (clienteModificado == null)
                throw new ArgumentNullException(nameof(clienteModificado), "Los datos del cliente son requeridos.");

            if (clienteModificado.ClienteId <= 0)
                throw new ArgumentException("El ID de cliente no es válido.");

            if (string.IsNullOrWhiteSpace(clienteModificado.Nombre))
                throw new ArgumentException("El nombre del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(clienteModificado.Apellido))
                throw new ArgumentException("El apellido del cliente es obligatorio.");

            if (string.IsNullOrWhiteSpace(clienteModificado.Telefono))
                throw new ArgumentException("El teléfono es obligatorio.");

            if (string.IsNullOrWhiteSpace(clienteModificado.TipoDocumento))
                throw new ArgumentException("El tipo de documento es obligatorio.");

            clienteModificado.Nombre = clienteModificado.Nombre.Trim();
            clienteModificado.Apellido = clienteModificado.Apellido.Trim();
            clienteModificado.Telefono = clienteModificado.Telefono.Trim();
            clienteModificado.TipoDocumento = clienteModificado.TipoDocumento.Trim();

            // Validaciones de longitud
            if (clienteModificado.Nombre.Length > 100)
                throw new ArgumentException("El nombre no puede superar los 100 caracteres.");

            if (clienteModificado.Apellido.Length > 100)
                throw new ArgumentException("El apellido no puede superar los 100 caracteres.");

            if (clienteModificado.Telefono.Length > 15)
                throw new ArgumentException("El teléfono no puede superar los 15 caracteres.");

            if (!string.IsNullOrWhiteSpace(clienteModificado.Correo))
            {
                clienteModificado.Correo = clienteModificado.Correo.Trim();
                if (clienteModificado.Correo.Length > 100)
                    throw new ArgumentException("El correo electrónico no puede superar los 100 caracteres.");
            }

            // Validaciones según el Constraint CK_Cliente_Documento
            if (clienteModificado.TipoDocumento == "DUI")
            {
                if (string.IsNullOrWhiteSpace(clienteModificado.DUI))
                    throw new ArgumentException("El número de DUI es obligatorio cuando el tipo de documento es 'DUI'.");

                clienteModificado.DUI = clienteModificado.DUI.Trim();

                if (!Regex.IsMatch(clienteModificado.DUI, @"^\d{8}-\d{1}$"))
                    throw new ArgumentException("El formato del DUI debe ser 00000000-0.");

                clienteModificado.CarnetExtranjero = null;
            }
            else if (clienteModificado.TipoDocumento == "CarnetExtranjero")
            {
                if (string.IsNullOrWhiteSpace(clienteModificado.CarnetExtranjero))
                    throw new ArgumentException("El Carnet de Extranjero es obligatorio cuando el tipo de documento es 'CarnetExtranjero'.");

                clienteModificado.CarnetExtranjero = clienteModificado.CarnetExtranjero.Trim();

                if (clienteModificado.CarnetExtranjero.Length > 20)
                    throw new ArgumentException("El Carnet de Extranjero no puede superar los 20 caracteres.");

                clienteModificado.DUI = null;
            }
            else
            {
                throw new ArgumentException("El tipo de documento debe ser 'DUI' o 'CarnetExtranjero'.");
            }

            var clienteExistente = _clienteDal.SelectById(clienteModificado.ClienteId);
            if (clienteExistente == null)
                throw new InvalidOperationException($"El cliente con ID {clienteModificado.ClienteId} no existe o se encuentra inactivo.");

            return _clienteDal.Update(clienteModificado);
        }

        public bool Delete(int idCliente)
        {
            if (idCliente <= 0)
                throw new ArgumentException("El ID de cliente no es válido.");

            var clienteExistente = _clienteDal.SelectById(idCliente);
            if (clienteExistente == null)
                throw new InvalidOperationException($"El cliente con ID {idCliente} no existe o ya se encuentra inactivo.");

            return _clienteDal.Delete(idCliente);
        }
    }
}
