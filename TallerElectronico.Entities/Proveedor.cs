using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class Proveedor
    {
        public int ProveedorId { get; set; }
        public string Nombre { get; set; }
        public string TipoProveedor { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string DUI { get; set; }
        public string NIT { get; set; }
        public string NRC { get; set; }
        public int EstadoProveedorId { get; set; }

        public Proveedor()
        {
        }

        public Proveedor(string nombre, string tipoProveedor,
            string telefono, string email, string direccion,
            string dui, string nit, string nrc, int estadoProveedorId)
        {
            Nombre = nombre;
            TipoProveedor = tipoProveedor;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            DUI = dui;
            NIT = nit;
            NRC = nrc;
            EstadoProveedorId = estadoProveedorId;
        }

        public Proveedor(int proveedorId, string nombre,
            string tipoProveedor, string telefono, string email,
            string direccion, string dui, string nit, string nrc,
            int estadoProveedorId)
        {
            ProveedorId = proveedorId;
            Nombre = nombre;
            TipoProveedor = tipoProveedor;
            Telefono = telefono;
            Email = email;
            Direccion = direccion;
            DUI = dui;
            NIT = nit;
            NRC = nrc;
            EstadoProveedorId = estadoProveedorId;
        }
    }
}