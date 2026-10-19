using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmLogin : Form
    {
        private UsuarioBL _usuarioBL = new UsuarioBL();

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuarioTxt = txtUsuario.Text.Trim();
                string claveTxt = txtClave.Text.Trim();


                Usuario usuarioEncontrado = _usuarioBL.Login(usuarioTxt, claveTxt);

                if (usuarioEncontrado != null)
                {
                    MessageBox.Show($"¡Conexión exitosa!\nBienvenido: {usuarioEncontrado.Empleado.Nombre} {usuarioEncontrado.Empleado.Apellido}\nRol: {usuarioEncontrado.Rol.Nombre}",
                                    "Acceso Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas o usuario inactivo.",
                                    "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en el servidor de base de datos:\n{ex.Message}\n\nDetalle: {ex.InnerException?.Message}",
                                "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
