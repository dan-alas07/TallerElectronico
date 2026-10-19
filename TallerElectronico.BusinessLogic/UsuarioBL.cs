using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TallerElectronico.DataAccess;
using TallerElectronico.Entities;

namespace TallerElectronico.BusinessLogic
{
    public class UsuarioBL
    {
        private UsuarioDAL _usuarioDal = new UsuarioDAL();

        public Usuario Login(string nombreUsuario, string clave)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
            {
                throw new ArgumentException("El nombre de usuario es obligatorio.");
            }

            if (string.IsNullOrWhiteSpace(clave))
            {
                throw new ArgumentException("La contraseña es obligatoria.");
            }

            return _usuarioDal.ValidarLogin(nombreUsuario, clave);
        }
    }
}
