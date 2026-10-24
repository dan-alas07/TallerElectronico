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
    public partial class FrmCliente : Form
    {
        private readonly ClienteBL _clienteBL = new ClienteBL();

        public FrmCliente()
        {
            InitializeComponent();
            dgvCliente.AutoGenerateColumns = false;
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                dgvCliente.DataSource = _clienteBL.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al cargar los clientes: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmCreateCliente frm = new FrmCreateCliente())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarClientes();
                }
            }
        }
    }
}
