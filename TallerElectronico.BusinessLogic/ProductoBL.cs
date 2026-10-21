using System;
using System.Collections.Generic;
using System.Linq;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class ProductoBL
    {
        private readonly ProductoDAL _productoDal = new ProductoDAL();
        private readonly ProveedorDAL _proveedorDal = new ProveedorDAL();

        public List<Producto> SelectAll()
        {
            return _productoDal.SelectAll();
        }

        public Producto SelectById(int idProducto)
        {
            if (idProducto <= 0)
                throw new ArgumentException("El ID de producto proporcionado no es válido.");

            return _productoDal.SelectById(idProducto);
        }

        public Producto Insert(Producto producto)
        {
            if (producto == null)
                throw new ArgumentNullException(nameof(producto), "Los datos del producto son requeridos.");

            if (string.IsNullOrWhiteSpace(producto.Codigo))
                throw new ArgumentException("El código del producto es obligatorio.");

            if (string.IsNullOrWhiteSpace(producto.Nombre))
                throw new ArgumentException("El nombre del producto es obligatorio.");

            producto.Codigo = producto.Codigo.Trim();
            producto.Nombre = producto.Nombre.Trim();

            // Validaciones de longitud según esquema SQL
            if (producto.Codigo.Length > 50)
                throw new ArgumentException("El código del producto no puede superar los 50 caracteres.");

            if (producto.Nombre.Length > 100)
                throw new ArgumentException("El nombre del producto no puede superar los 100 caracteres.");

            if (!string.IsNullOrWhiteSpace(producto.Descripcion))
            {
                producto.Descripcion = producto.Descripcion.Trim();
                if (producto.Descripcion.Length > 250)
                    throw new ArgumentException("La descripción del producto no puede superar los 250 caracteres.");
            }

            if (producto.CantidadStock < 0)
                throw new ArgumentException("La cantidad en stock no puede ser negativa.");

            if (producto.PrecioUnitario <= 0.00m)
                throw new ArgumentException("El precio unitario debe ser mayor a 0.00.");

            if (producto.ProveedorId <= 0)
                throw new ArgumentException("Debe seleccionar un proveedor válido.");

            if (producto.UsuarioCreacionId <= 0)
                throw new ArgumentException("Debe asociar el usuario que crea el registro.");

            // Validar que el proveedor realmente exista
            var proveedorExistente = _proveedorDal.SelectById(producto.ProveedorId);
            if (proveedorExistente == null)
                throw new InvalidOperationException($"El proveedor con ID {producto.ProveedorId} no existe o está inactivo.");

            // Validar unicidad del Código de Producto
            var listaProductos = _productoDal.SelectAll();
            if (listaProductos.Any(p => p.Codigo.Equals(producto.Codigo, StringComparison.OrdinalIgnoreCase)))
                throw new InvalidOperationException($"El código de producto '{producto.Codigo}' ya se encuentra registrado.");

            // Asignación de valores por defecto / auditoría
            if (producto.FechaCreacion == default(DateTime))
            {
                producto.FechaCreacion = DateTime.Now;
            }

            producto.Estado = "A";

            return _productoDal.Insert(producto);
        }

        public Producto Update(Producto productoModificado)
        {
            if (productoModificado == null)
                throw new ArgumentNullException(nameof(productoModificado), "Los datos del producto son requeridos.");

            if (productoModificado.ProductoId <= 0)
                throw new ArgumentException("El ID del producto no es válido.");

            if (string.IsNullOrWhiteSpace(productoModificado.Codigo))
                throw new ArgumentException("El código del producto es obligatorio.");

            if (string.IsNullOrWhiteSpace(productoModificado.Nombre))
                throw new ArgumentException("El nombre del producto es obligatorio.");

            productoModificado.Codigo = productoModificado.Codigo.Trim();
            productoModificado.Nombre = productoModificado.Nombre.Trim();

            if (productoModificado.Codigo.Length > 50)
                throw new ArgumentException("El código del producto no puede superar los 50 caracteres.");

            if (productoModificado.Nombre.Length > 100)
                throw new ArgumentException("El nombre del producto no puede superar los 100 caracteres.");

            if (!string.IsNullOrWhiteSpace(productoModificado.Descripcion))
            {
                productoModificado.Descripcion = productoModificado.Descripcion.Trim();
                if (productoModificado.Descripcion.Length > 250)
                    throw new ArgumentException("La descripción del producto no puede superar los 250 caracteres.");
            }

            if (productoModificado.CantidadStock < 0)
                throw new ArgumentException("La cantidad en stock no puede ser negativa.");

            if (productoModificado.PrecioUnitario <= 0.00m)
                throw new ArgumentException("El precio unitario debe ser mayor a 0.00.");

            if (productoModificado.ProveedorId <= 0)
                throw new ArgumentException("Debe seleccionar un proveedor válido.");

            if (!productoModificado.UsuarioModificacionId.HasValue || productoModificado.UsuarioModificacionId.Value <= 0)
                throw new ArgumentException("Debe especificar el usuario que realiza la modificación.");

            var productoExistente = _productoDal.SelectById(productoModificado.ProductoId);
            if (productoExistente == null)
                throw new InvalidOperationException($"El producto con ID {productoModificado.ProductoId} no existe o se encuentra inactivo.");

            // Validar que el proveedor exista
            var proveedorExistente = _proveedorDal.SelectById(productoModificado.ProveedorId);
            if (proveedorExistente == null)
                throw new InvalidOperationException($"El proveedor con ID {productoModificado.ProveedorId} no existe o está inactivo.");

            var listaProductos = _productoDal.SelectAll();

            // Validar que el código no pertenezca a otro producto diferente
            if (listaProductos.Any(p => p.Codigo.Equals(productoModificado.Codigo, StringComparison.OrdinalIgnoreCase)
                                     && p.ProductoId != productoModificado.ProductoId))
            {
                throw new InvalidOperationException($"El código de producto '{productoModificado.Codigo}' ya está siendo usado por otro registro.");
            }

            // Asignar auditoría de modificación explícita
            productoModificado.FechaModificacion = DateTime.Now;

            return _productoDal.Update(productoModificado);
        }

        public bool Delete(int idProducto, int? idUsuarioModificacion = null)
        {
            if (idProducto <= 0)
                throw new ArgumentException("El ID del producto no es válido.");

            if (idUsuarioModificacion.HasValue && idUsuarioModificacion.Value <= 0)
                throw new ArgumentException("El ID del usuario de modificación proporcionado no es válido.");

            var productoExistente = _productoDal.SelectById(idProducto);
            if (productoExistente == null)
                throw new InvalidOperationException($"El producto con ID {idProducto} no existe o ya se encuentra inactivo.");

            return _productoDal.Delete(idProducto, idUsuarioModificacion);
        }
    }
}