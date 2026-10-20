using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class ProductoDAL
    {
        public List<Producto> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Producto.AsNoTracking()
                                  .Include(p => p.Proveedor)
                                  .Where(p => p.Estado == "A")
                                  .ToList();
            }
        }

        public Producto SelectById(int idProducto)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Producto.AsNoTracking()
                                  .Include(p => p.Proveedor)
                                  .FirstOrDefault(p => p.ProductoId == idProducto && p.Estado == "A");
            }
        }

        public Producto Insert(Producto producto)
        {
            using (var db = new TallerElectronicoEntities())
            {
                producto.Proveedor = null;

                if (producto.FechaCreacion == default(DateTime))
                {
                    producto.FechaCreacion = DateTime.Now;
                }

                var nuevoProducto = db.Producto.Add(producto);
                db.SaveChanges();
                return nuevoProducto;
            }
        }

        public Producto Update(Producto productoModificado)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var productoExistente = db.Producto.Find(productoModificado.ProductoId);

                if (productoExistente != null)
                {
                    productoExistente.Codigo = productoModificado.Codigo;
                    productoExistente.Nombre = productoModificado.Nombre;
                    productoExistente.Descripcion = productoModificado.Descripcion;
                    productoExistente.CantidadStock = productoModificado.CantidadStock;
                    productoExistente.PrecioUnitario = productoModificado.PrecioUnitario;
                    productoExistente.ProveedorId = productoModificado.ProveedorId;
                    productoExistente.Estado = productoModificado.Estado;

                    productoExistente.FechaModificacion = DateTime.Now;
                    productoExistente.UsuarioModificacionId = productoModificado.UsuarioModificacionId;

                    db.SaveChanges();
                }

                return productoExistente;
            }
        }

        public bool Delete(int idProducto, int? idUsuarioModificacion = null)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var producto = db.Producto.Find(idProducto);

                if (producto != null)
                {
                    producto.Estado = "I";
                    producto.FechaModificacion = DateTime.Now;

                    if (idUsuarioModificacion.HasValue)
                    {
                        producto.UsuarioModificacionId = idUsuarioModificacion.Value;
                    }

                    return db.SaveChanges() > 0;
                }

                return false;
            }
        }
    }
}