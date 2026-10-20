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
                return db.Proveedor.AsNoTracking()
                                   .Where(p => p.Estado == "A")
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
    }
}