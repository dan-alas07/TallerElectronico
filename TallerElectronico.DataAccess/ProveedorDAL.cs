using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class ProveedorDAL
    {
        public List<Proveedor> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Proveedor
                         .AsNoTracking()
                         .Where(p => p.Estado == "A")
                         .ToList()
                         .Select(p => new Proveedor
                         {
                             ProveedorId = p.ProveedorId,
                             Nombre = p.Nombre,
                             Telefono = p.Telefono,
                             Email = p.Email,
                             Direccion = p.Direccion,
                             DUI = p.DUI,
                             NIT = p.NIT,
                             NRC = p.NRC,
                             TipoProveedor = p.TipoProveedor == "PN" ? "Persona Natural" : (p.TipoProveedor == "PJ" ? "Persona Jurídica" : p.TipoProveedor),
                             Estado = p.Estado == "A" ? "Activo" : "Inactivo"
                         })
                         .ToList();
            }
        }

        public Proveedor SelectById(int idProveedor)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Proveedor.AsNoTracking()
                                   .FirstOrDefault(p => p.ProveedorId == idProveedor && p.Estado == "A");
            }
        }

        public Proveedor Insert(Proveedor proveedor)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var nuevoProveedor = db.Proveedor.Add(proveedor);
                db.SaveChanges();
                return nuevoProveedor;
            }
        }

        public Proveedor Update(Proveedor proveedorModificado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var proveedorExistente = db.Proveedor.Find(proveedorModificado.ProveedorId);

                if (proveedorExistente != null)
                {
                    proveedorExistente.Nombre = proveedorModificado.Nombre;
                    proveedorExistente.TipoProveedor = proveedorModificado.TipoProveedor;
                    proveedorExistente.Telefono = proveedorModificado.Telefono;
                    proveedorExistente.Email = proveedorModificado.Email;
                    proveedorExistente.Direccion = proveedorModificado.Direccion;
                    proveedorExistente.DUI = proveedorModificado.DUI;
                    proveedorExistente.NIT = proveedorModificado.NIT;
                    proveedorExistente.NRC = proveedorModificado.NRC;
                    proveedorExistente.Estado = proveedorModificado.Estado;

                    db.SaveChanges();
                }

                return proveedorExistente;
            }
        }

        public bool Delete(int idProveedor)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var proveedor = db.Proveedor.Find(idProveedor);

                if (proveedor != null)
                {
                    proveedor.Estado = "I";
                    return db.SaveChanges() > 0;
                }

                return false;
            }
        }

        public List<Proveedor> Search(string criterio)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var query = db.Proveedor
                              .AsNoTracking()
                              .Where(p => p.Estado == "A");

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim().ToLower();
                    int idBusqueda;
                    bool esNumero = int.TryParse(criterio, out idBusqueda);

                    query = query.Where(p =>
                        (esNumero && p.ProveedorId == idBusqueda) ||
                        (p.Nombre != null && p.Nombre.ToLower().Contains(criterio)) ||
                        (p.Telefono != null && p.Telefono.ToLower().Contains(criterio)) ||
                        (p.Email != null && p.Email.ToLower().Contains(criterio)) ||
                        (p.Direccion != null && p.Direccion.ToLower().Contains(criterio)) ||
                        (p.DUI != null && p.DUI.ToLower().Contains(criterio)) ||
                        (p.NIT != null && p.NIT.ToLower().Contains(criterio)) ||
                        (p.NRC != null && p.NRC.ToLower().Contains(criterio))
                    );
                }
                return query.OrderBy(p => p.Nombre).ToList();
            }
        }
    
    }
}