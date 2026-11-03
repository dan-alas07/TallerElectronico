using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class ClienteDAL
    {
        public List<Cliente> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Cliente
                         .AsNoTracking()
                         .Where(c => c.Estado == "A")
                         .ToList()
                         .Select(c => new Cliente
                         {
                             ClienteId = c.ClienteId,
                             Nombre = c.Nombre,
                             Apellido = c.Apellido,
                             Telefono = c.Telefono,
                             Correo = c.Correo,
                             TipoDocumento = c.TipoDocumento == "DUI" ? "DUI" : (c.TipoDocumento == "CarnetExtranjero" ? "Carnet de Extranjería" : c.TipoDocumento),
                             DUI = c.DUI,
                             CarnetExtranjero = c.CarnetExtranjero,
                             FechaRegistro = c.FechaRegistro,
                             Estado = c.Estado == "A" ? "Activo" : "Inactivo"
                         })
                         .OrderBy(c => c.Nombre)
                         .ThenBy(c => c.Apellido)
                         .ToList();
            }
        }

        public Cliente SelectById(int idCliente)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Cliente.AsNoTracking()
                                 .FirstOrDefault(c => c.ClienteId == idCliente && c.Estado == "A");
            }
        }

        public Cliente Insert(Cliente cliente)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var nuevoCliente = db.Cliente.Add(cliente);
                db.SaveChanges();
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
                    clienteExistente.Estado = clienteModificado.Estado;

                    db.SaveChanges();
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


        public List<Cliente> Search(string criterio)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var query = db.Cliente
                              .AsNoTracking()
                              .Where(c => c.Estado == "A");

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim().ToLower();
                    int idBusqueda;
                    bool esNumero = int.TryParse(criterio, out idBusqueda);

                    query = query.Where(c =>
                        (esNumero && c.ClienteId == idBusqueda) ||
                        (c.Nombre != null && c.Nombre.ToLower().Contains(criterio)) ||
                        (c.Apellido != null && c.Apellido.ToLower().Contains(criterio)) ||
                        (c.Telefono != null && c.Telefono.ToLower().Contains(criterio)) ||
                        (c.Correo != null && c.Correo.ToLower().Contains(criterio)) ||
                        (c.TipoDocumento != null && c.TipoDocumento.ToLower().Contains(criterio)) ||
                        (c.DUI != null && c.DUI.ToLower().Contains(criterio)) ||
                        (c.CarnetExtranjero != null && c.CarnetExtranjero.ToLower().Contains(criterio))
                    );
                }

                return query.OrderBy(c => c.Nombre)
                            .ThenBy(c => c.Apellido)
                            .ToList();
            }
        }
    }
}