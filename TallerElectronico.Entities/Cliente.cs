using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string TipoDocumento { get; set; }
        public string DUI { get; set; }
        public string CarnetExtranjero { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int EstadoClienteId { get; set; }

        public Cliente()
        {
        }

        public Cliente(string nombre, string apellido, string telefono,
            string correo, string tipoDocumento, string dui,
            string carnetExtranjero, DateTime fechaRegistro,
            int estadoClienteId)
        {
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Correo = correo;
            TipoDocumento = tipoDocumento;
            DUI = dui;
            CarnetExtranjero = carnetExtranjero;
            FechaRegistro = fechaRegistro;
            EstadoClienteId = estadoClienteId;
        }

        public Cliente(int clienteId, string nombre, string apellido,
            string telefono, string correo, string tipoDocumento,
            string dui, string carnetExtranjero, DateTime fechaRegistro,
            int estadoClienteId)
        {
            ClienteId = clienteId;
            Nombre = nombre;
            Apellido = apellido;
            Telefono = telefono;
            Correo = correo;
            TipoDocumento = tipoDocumento;
            DUI = dui;
            CarnetExtranjero = carnetExtranjero;
            FechaRegistro = fechaRegistro;
            EstadoClienteId = estadoClienteId;
        }
    }
}