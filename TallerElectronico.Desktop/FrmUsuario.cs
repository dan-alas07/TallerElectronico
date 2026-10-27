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

namespace TallerElectronico.Desktop
{
    public partial class FrmUsuario : Form
    {
        private readonly UsuarioBL _usuarioBL = new UsuarioBL();

        public FrmUsuario()
        {
            InitializeComponent();
            dgvUsuarios.AutoGenerateColumns = false;
        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }
        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource = _usuarioBL.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al cargar los proveedores: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmCreateUsuario frm = new FrmCreateUsuario())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
        }
    }
}
