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
                return db.Cliente.AsNoTracking()
                                 .Where(c => c.Estado == "A")
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
    }
}