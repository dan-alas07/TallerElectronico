using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class ProductoDAL
    {
        private string NormalizarEstadoParaBD(string estado)
        {
            if (string.IsNullOrWhiteSpace(estado)) return "I";
            return estado.Equals("Activo", StringComparison.OrdinalIgnoreCase) || estado == "A" ? "A" : "I";
        }

        private string TransformarEstadoParaUI(string estado)
        {
            return estado == "A" ? "Activo" : "Inactivo";
        }

        private IQueryable<ProductoDTO> MapearAProductoDTO(IQueryable<Producto> query)
        {
            return query.Select(p => new ProductoDTO
            {
                ProductoId = p.ProductoId,
                Codigo = p.Codigo,
                Nombre = p.Nombre,
                Descripcion = p.Descripcion,
                CantidadStock = p.CantidadStock,
                PrecioUnitario = p.PrecioUnitario,
                Estado = p.Estado == "A" ? "Activo" : "Inactivo",

                ProveedorId = p.ProveedorId,
                UsuarioCreacionId = p.UsuarioCreacionId,

                ProveedorNombre = p.Proveedor != null ? p.Proveedor.Nombre : "Sin Proveedor",

                UsuarioCreacionNombre = p.Usuario != null
                    ? (p.Usuario.Empleado != null
                        ? p.Usuario.Empleado.Nombre + " " + p.Usuario.Empleado.Apellido
                        : p.Usuario.Nombre)
                    : "Sin Usuario"
            });
        }

        public List<ProductoDTO> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                var query = db.Producto
                              .AsNoTracking()

                return MapearAProductoDTO(query).ToList();
            }
        }

        public ProductoDTO SelectById(int idProducto)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var query = db.Producto
                              .AsNoTracking()
                              .Where(p => p.ProductoId == idProducto);

                return MapearAProductoDTO(query).FirstOrDefault();
            }
        }

        public ProductoDTO SelectByCodigo(string codigo)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var query = db.Producto
                              .AsNoTracking()
                              .Where(p => p.Codigo == codigo);

                return MapearAProductoDTO(query).FirstOrDefault();
            }
        }

        public Producto Insert(Producto producto)
        {
            using (var db = new TallerElectronicoEntities())
            {
                producto.Proveedor = null;
                producto.Usuario = null;

                producto.Estado = NormalizarEstadoParaBD(producto.Estado);

                if (producto.FechaCreacion == default(DateTime))
                {
                    producto.FechaCreacion = DateTime.Now;
                }

                var nuevoProducto = db.Producto.Add(producto);
                db.SaveChanges();

                nuevoProducto.Estado = TransformarEstadoParaUI(nuevoProducto.Estado);
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

                    productoExistente.Estado = NormalizarEstadoParaBD(productoModificado.Estado);
                    productoExistente.FechaModificacion = DateTime.Now;
                    productoExistente.UsuarioModificacionId = productoModificado.UsuarioModificacionId;

                    db.SaveChanges();

                    productoExistente.Estado = TransformarEstadoParaUI(productoExistente.Estado);
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

        public bool ExistsByCodigo(string codigo, int? excludeProductoId = null)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Producto.Any(p =>
                    p.Codigo == codigo &&
                    p.Estado == "A" &&
                    (!excludeProductoId.HasValue || p.ProductoId != excludeProductoId.Value));
            }
        }

        public int ObtenerUltimoId()
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Producto.Max(p => (int?)p.ProductoId) ?? 0;
            }
        }

        public List<ProductoDTO> Search(string criterio)
        {
            using (var db = new TallerElectronicoEntities())
            {
                IQueryable<Producto> query = db.Producto.AsNoTracking();

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim();

                    int idBusqueda;
                    bool esNumero = int.TryParse(criterio, out idBusqueda);

                    query = query.Where(p =>
                        (esNumero && p.ProductoId == idBusqueda) ||
                        (p.Codigo != null && p.Codigo.Contains(criterio)) ||
                        (p.Nombre != null && p.Nombre.Contains(criterio)) ||
                        (p.Descripcion != null && p.Descripcion.Contains(criterio)) ||
                        (p.Proveedor != null && p.Proveedor.Nombre.Contains(criterio))
                    );
                }

                var queryOrdenada = query.OrderBy(p => p.Nombre);

                return MapearAProductoDTO(queryOrdenada).ToList();
            }
        }
    }
}