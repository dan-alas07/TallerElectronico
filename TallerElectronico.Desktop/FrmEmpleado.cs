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
                    "Error al cargar los empleados: " + ex.GetBaseException().Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dataGridView1_CellContentClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            //que vamos a hacer en las celdas
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}