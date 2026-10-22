using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;

namespace TallerElectronico.Desktop
{
    public partial class FrmEmpleado : Form
    {
        private readonly EmpleadoBL _empleadoBL = new EmpleadoBL();

        public FrmEmpleado()
        {
            InitializeComponent();
            dgvEmpleado.AutoGenerateColumns = false;
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            try
            {
                dgvEmpleado.DataSource = _empleadoBL.SelectAll();
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

        private void btnCreate_Click(object sender, EventArgs e)
        {
            using (FrmCreateEmpleado frm = new FrmCreateEmpleado())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarEmpleados();
                }
            }
        }

    }
}