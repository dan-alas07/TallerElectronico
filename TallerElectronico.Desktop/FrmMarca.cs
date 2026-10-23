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
    public partial class FrmMarca : Form
    {
        private readonly MarcaBL _marcaBL = new MarcaBL();

        public FrmMarca()
        {
            InitializeComponent();
            dgvMarca.AutoGenerateColumns = false;
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            CargarMarcas();
        }

        private void CargarMarcas()
        {
            try
            {
                dgvMarca.DataSource = _marcaBL.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al cargar los empleados: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmCreateMarca frm = new FrmCreateMarca())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarMarcas();
                }
            }
        }
    }
}
