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
    public partial class FrmProveedor : Form
    {
        private readonly ProveedorBL _proveedorBL = new ProveedorBL();

        public FrmProveedor()
        {
            InitializeComponent();
            dgvProveedor.AutoGenerateColumns = false;
        }

        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            CargarProveedores();
        }

        private void CargarProveedores()
        {
            try
            {
                dgvProveedor.DataSource = _proveedorBL.SelectAll();
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
    }
}
