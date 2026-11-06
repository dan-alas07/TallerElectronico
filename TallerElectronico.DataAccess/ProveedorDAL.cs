using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class ProveedorDAL
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

        private string NormalizarTipoProveedorParaBD(string tipo)
        {
            if (string.IsNullOrWhiteSpace(tipo)) return "PN";
            if (tipo.Equals("Persona Natural", StringComparison.OrdinalIgnoreCase) || tipo == "PN") return "PN";
            if (tipo.Equals("Persona Jurídica", StringComparison.OrdinalIgnoreCase) || tipo == "PJ") return "PJ";
            return tipo;
        }

        private string TransformarTipoProveedorParaUI(string tipo)
        {
            if (tipo == "PN") return "Persona Natural";
            if (tipo == "PJ") return "Persona Jurídica";
            return tipo;
        }

        public List<Proveedor> SelectAll()
        {
            using (var db = new TallerElectronicoEntities())
            {
                var lista = db.Proveedor
                              .AsNoTracking()
                              .OrderBy(p => p.Nombre)
                              .ToList();

                lista.ForEach(p =>
                {
                    p.Estado = TransformarEstadoParaUI(p.Estado);
                    p.TipoProveedor = TransformarTipoProveedorParaUI(p.TipoProveedor);
                });

                return lista;
            }
        }

        public Proveedor SelectById(int idProveedor)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var proveedor = db.Proveedor
                                  .AsNoTracking()
                                  .FirstOrDefault(p => p.ProveedorId == idProveedor);

                if (proveedor != null)
                {
                    proveedor.Estado = TransformarEstadoParaUI(proveedor.Estado);
                    proveedor.TipoProveedor = TransformarTipoProveedorParaUI(proveedor.TipoProveedor);
                }

                return proveedor;
            }
        }

        public Proveedor Insert(Proveedor proveedor)
        {
            using (var db = new TallerElectronicoEntities())
            {
                proveedor.Estado = NormalizarEstadoParaBD(proveedor.Estado);
                proveedor.TipoProveedor = NormalizarTipoProveedorParaBD(proveedor.TipoProveedor);

                var nuevoProveedor = db.Proveedor.Add(proveedor);
                db.SaveChanges();

                nuevoProveedor.Estado = TransformarEstadoParaUI(nuevoProveedor.Estado);
                nuevoProveedor.TipoProveedor = TransformarTipoProveedorParaUI(nuevoProveedor.TipoProveedor);
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
                    proveedorExistente.TipoProveedor = NormalizarTipoProveedorParaBD(proveedorModificado.TipoProveedor);
                    proveedorExistente.Telefono = proveedorModificado.Telefono;
                    proveedorExistente.Email = proveedorModificado.Email;
                    proveedorExistente.Direccion = proveedorModificado.Direccion;
                    proveedorExistente.DUI = proveedorModificado.DUI;
                    proveedorExistente.NIT = proveedorModificado.NIT;
                    proveedorExistente.NRC = proveedorModificado.NRC;
                    proveedorExistente.Estado = NormalizarEstadoParaBD(proveedorModificado.Estado);

                    db.SaveChanges();

                    proveedorExistente.Estado = TransformarEstadoParaUI(proveedorExistente.Estado);
                    proveedorExistente.TipoProveedor = TransformarTipoProveedorParaUI(proveedorExistente.TipoProveedor);
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

        public bool ExistsByEmail(string email, int? excludeProveedorId = null)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Proveedor.Any(p =>
                    p.Email == email &&
                    p.Estado == "A" &&
                    (!excludeProveedorId.HasValue || p.ProveedorId != excludeProveedorId.Value));
            }
        }

        public bool ExistsByDui(string dui, int? excludeProveedorId = null)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Proveedor.Any(p =>
                    p.DUI == dui &&
                    p.Estado == "A" &&
                    (!excludeProveedorId.HasValue || p.ProveedorId != excludeProveedorId.Value));
            }
        }

        public bool ExistsByNit(string nit, int? excludeProveedorId = null)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Proveedor.Any(p =>
                    p.NIT == nit &&
                    p.Estado == "A" &&
                    (!excludeProveedorId.HasValue || p.ProveedorId != excludeProveedorId.Value));
            }
        }

        public bool ExistsByNrc(string nrc, int? excludeProveedorId = null)
        {
            using (var db = new TallerElectronicoEntities())
            {
                return db.Proveedor.Any(p =>
                    p.NRC == nrc &&
                    p.Estado == "A" &&
                    (!excludeProveedorId.HasValue || p.ProveedorId != excludeProveedorId.Value));
            }
        }

        public List<Proveedor> Search(string criterio)
        {
            using (var db = new TallerElectronicoEntities())
            {
                IQueryable<Proveedor> query = db.Proveedor.AsNoTracking();

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    criterio = criterio.Trim();

                    int idBusqueda;
                    bool esNumero = int.TryParse(criterio, out idBusqueda);

                    query = query.Where(p =>
                        (esNumero && p.ProveedorId == idBusqueda) ||
                        (p.Nombre != null && p.Nombre.Contains(criterio)) ||
                        (p.Telefono != null && p.Telefono.Contains(criterio)) ||
                        (p.Email != null && p.Email.Contains(criterio)) ||
                        (p.Direccion != null && p.Direccion.Contains(criterio)) ||
                        (p.DUI != null && p.DUI.Contains(criterio)) ||
                        (p.NIT != null && p.NIT.Contains(criterio)) ||
                        (p.NRC != null && p.NRC.Contains(criterio))
                    );
                }

                var lista = query.OrderBy(p => p.Nombre)
                                 .ToList();

                lista.ForEach(p =>
                {
                    p.Estado = TransformarEstadoParaUI(p.Estado);
                    p.TipoProveedor = TransformarTipoProveedorParaUI(p.TipoProveedor);
                });

                return lista;
            }
        }
    }
}