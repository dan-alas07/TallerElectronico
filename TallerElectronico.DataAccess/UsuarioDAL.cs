using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerElectronico.Entities;

namespace TallerElectronico.DataAccess
{
    public class UsuarioDAL
    {
        public Usuario ValidarLogin(string nombreUsuario, string clave)
        {
            using (var db = new TallerElectronicoEntities())
            {
                var usuario = db.Usuario
                                .Include("Rol")
                                .Include("Empleado")
                                .FirstOrDefault(u => u.Nombre == nombreUsuario && u.Clave == clave && u.Estado == "A");
                return usuario;
            }
        }
    }
}
