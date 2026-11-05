using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class ProductoDAL
    {

        public List<ProductoDTO> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Producto.AsNoTracking()
                    .OrderBy(p => p.Nombre)
                    .Select(p => new ProductoDTO
                    {
                        ProductoId = p.ProductoId,
                        Codigo = p.Codigo,
                        Nombre = p.Nombre,
                        Descripcion = p.Descripcion,
                        CantidadStock = p.CantidadStock,
                        PrecioUnitario = p.PrecioUnitario,
                        Estado = p.Estado == "A" ? "Activo" : "Inactivo",

                        // Claves Foráneas para edición y control interno
                        ProveedorId = p.ProveedorId,
                        UsuarioCreacionId = p.UsuarioCreacionId,

                        // Uniones (JOINs implícitos mediante propiedades de navegación)
                        ProveedorNombre = p.Proveedor != null ? p.Proveedor.Nombre : "Sin Proveedor",

                        // Mapea el nombre del usuario que creó el producto (accediendo a Empleado si aplica o a su Nombre directo)
                        UsuarioCreacionNombre = p.Usuario != null
                            ? (p.Usuario.Empleado != null
                                ? p.Usuario.Empleado.Nombre + " " + p.Usuario.Empleado.Apellido
                                : p.Usuario.Nombre)
                            : "Sin Usuario"
                    })
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