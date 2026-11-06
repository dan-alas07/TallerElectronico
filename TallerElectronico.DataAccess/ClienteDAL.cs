using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class ClienteDAL
    {
        // Convierte el valor que viene de la UI ("Activo"/"Inactivo") al formato de BD ("A"/"I")
        private string NormalizarEstadoParaBD(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado)) return "I";
            return estado.Equals("Activo", StringComparison.OrdinalIgnoreCase) || estado == "A" ? "A" : "I";
        }

        // Convierte el valor almacenado en BD ("A"/"I") al formato para la UI ("Activo"/"Inactivo")
        private string TransformarEstadoParaUI(string estado)
        {
            return estado == "A" ? "Activo" : "Inactivo";
        }

        public List<Cliente> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                var clientes = db.Cliente
                                 .AsNoTracking()
                                 .OrderBy(c => c.Nombre)
                                 .ThenBy(c => c.Apellido)
                                 .ToList();

                clientes.ForEach(c => c.Estado = TransformarEstadoParaUI(c.Estado));
                return clientes;
            }
        }

        public Cliente SelectById(int idCliente)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var cliente = db.Cliente
                                .AsNoTracking()
                                .FirstOrDefault(c => c.ClienteId == idCliente);

                if (cliente != null)
                {
                    cliente.Estado = TransformarEstadoParaUI(cliente.Estado);
                }

                return cliente;
            }
        }

        public Cliente Insert(Cliente cliente)
        {
            using (var db = new TallerElectronicoEntities())
            {
                // Asegura guardar "A" o "I" en la BD
                cliente.Estado = NormalizarEstadoParaBD(cliente.Estado);

                var nuevoCliente = db.Cliente.Add(cliente);
                db.SaveChanges();

                nuevoCliente.Estado = TransformarEstadoParaUI(nuevoCliente.Estado);
                return nuevoCliente;
            }
        }

        public Cliente Update(Cliente clienteModificado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var clienteExistente = db.Cliente.Find(clienteModificado.ClienteId);

                if (clienteExistente != null)
                {
                    clienteExistente.Nombre = clienteModificado.Nombre;
                    clienteExistente.Apellido = clienteModificado.Apellido;
                    clienteExistente.Telefono = clienteModificado.Telefono;
                    clienteExistente.Correo = clienteModificado.Correo;
                    clienteExistente.TipoDocumento = clienteModificado.TipoDocumento;
                    clienteExistente.DUI = clienteModificado.DUI;
                    clienteExistente.CarnetExtranjero = clienteModificado.CarnetExtranjero;

                    // Convertir "Activo"/"Inactivo" a "A"/"I" antes de guardar
                    clienteExistente.Estado = NormalizarEstadoParaBD(clienteModificado.Estado);

                    db.SaveChanges();

                    clienteExistente.Estado = TransformarEstadoParaUI(clienteExistente.Estado);
                }

                return clienteExistente;
            }
        }

        public bool Delete(int idCliente)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var cliente = db.Cliente.Find(idCliente);

                if (cliente != null)
                {
                    cliente.Estado = "I";
                    return db.SaveChanges() > 0;
                }

                return false;
            }
        }

        public bool ExistsByDui(string dui, int? excludeClienteId = null)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Cliente.Any(c =>
                    c.DUI == dui &&
                    c.Estado == "A" &&
                    (!excludeClienteId.HasValue || c.ClienteId != excludeClienteId.Value));
            }
        }

        public bool ExistsByEmail(string email, int? excludeClienteId = null)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Cliente.Any(c =>
                    c.Correo == email &&
                    c.Estado == "A" &&
                    (!excludeClienteId.HasValue || c.ClienteId != excludeClienteId.Value));
            }
        }

        public List<Cliente> Search(string criterio)
        {
            using (var db = new TallerElectronicoEntities())
            {
                IQueryable<Cliente> query = db.Cliente.AsNoTracking();

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim();

                    int idBusqueda;
                    bool esNumero = int.TryParse(criterio, out idBusqueda);

                    query = query.Where(c =>
                        (esNumero && c.ClienteId == idBusqueda) ||
                        (c.Nombre != null && c.Nombre.Contains(criterio)) ||
                        (c.Apellido != null && c.Apellido.Contains(criterio)) ||
                        (c.Telefono != null && c.Telefono.Contains(criterio)) ||
                        (c.Correo != null && c.Correo.Contains(criterio)) ||
                        (c.TipoDocumento != null && c.TipoDocumento.Contains(criterio)) ||
                        (c.DUI != null && c.DUI.Contains(criterio)) ||
                        (c.CarnetExtranjero != null && c.CarnetExtranjero.Contains(criterio))
                    );
                }

                var lista = query.OrderBy(c => c.Nombre)
                                 .ThenBy(c => c.Apellido)
                                 .ToList();

                lista.ForEach(c => c.Estado = TransformarEstadoParaUI(c.Estado));
                return lista;
            }
        }
    }
}