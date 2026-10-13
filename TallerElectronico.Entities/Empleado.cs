using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TallerElectronico.Entities
{
    public class Empleado
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DUI { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int EstadoEmpleadoId { get; set; }
        public DateTime FechaContratacion { get; set; }

        public Empleado()
        {
        }

        public Empleado(string nombre, string apellido, string dui,
            string telefono, string correo, string direccion,
            int estadoEmpleadoId, DateTime fechaContratacion)
        {
            Nombre = nombre;
            Apellido = apellido;
            DUI = dui;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            EstadoEmpleadoId = estadoEmpleadoId;
            FechaContratacion = fechaContratacion;
        }

        public Empleado(int empleadoId, string nombre, string apellido,
            string dui, string telefono, string correo, string direccion,
            int estadoEmpleadoId, DateTime fechaContratacion)
        {
            EmpleadoId = empleadoId;
            Nombre = nombre;
            Apellido = apellido;
            DUI = dui;
            Telefono = telefono;
            Correo = correo;
            Direccion = direccion;
            EstadoEmpleadoId = estadoEmpleadoId;
            FechaContratacion = fechaContratacion;
        }
    }
}