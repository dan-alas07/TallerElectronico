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
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void CargarEmpleados()
        {
            try
            {
                dgvEmpleado.AutoGenerateColumns = false;
                dgvEmpleado.DataSource = null;
                dgvEmpleado.DataSource = _empleadoBL.SelectAll();

                dgvEmpleado.ReadOnly = true;
                dgvEmpleado.AllowUserToAddRows = false;
                dgvEmpleado.AllowUserToDeleteRows = false;
                dgvEmpleado.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;
                dgvEmpleado.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los empleados: " + ex.Message,
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
            // Aquí podrás agregar posteriormente
            // acciones al seleccionar una celda.
        }

        // Botón para crear un empleado
        private void btnCreate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Aquí se abrirá el formulario para registrar un nuevo empleado.",
                "Registrar empleado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}