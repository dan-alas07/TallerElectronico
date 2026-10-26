using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;

namespace TallerElectronico.Desktop
{
    public partial class FrmEmpleado : Form
    {
        private readonly EmpleadoBL _empleadoBL = new EmpleadoBL();
        private bool cargandoEmpleados = false;

        public FrmEmpleado()
        {
            InitializeComponent();
            RegistrarEventos(this);

            dgvEmpleado.AutoGenerateColumns = false;
            dgvEmpleado.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmpleado.MultiSelect = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            // Detectar cambios 
            dgvEmpleado.SelectionChanged += dgvEmpleado_SelectionChanged;
        }


        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            CargarEmpleados();

            this.BeginInvoke((MethodInvoker)delegate
            {
                dgvEmpleado.ClearSelection();
                dgvEmpleado.CurrentCell = null;

                btnNuevo.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            });
        }



        private void CargarEmpleados()
        {
            try
            {
                // Evitar que se cambien los botones
                cargandoEmpleados = true;

                dgvEmpleado.DataSource = _empleadoBL.SelectAll();

                // Quitar la selección automatica
                dgvEmpleado.ClearSelection();
                dgvEmpleado.CurrentCell = null;
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
            finally
            {
                // Terminar la carga incluso si ocurre un error
                cargandoEmpleados = false;

                // Dejar los botones en su estado inicial
                btnNuevo.Enabled = true;
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void dgvEmpleado_SelectionChanged(object sender, EventArgs e)
        {

            if (cargandoEmpleados)
                return;

            bool empleadoSeleccionado = dgvEmpleado.SelectedRows.Count > 0;

            btnNuevo.Enabled = !empleadoSeleccionado;
            btnEditar.Enabled = empleadoSeleccionado;
            btnEliminar.Enabled = empleadoSeleccionado;
        }


        private void RegistrarEventos(Control control)
        {
            control.MouseDown += Control_MouseDown;

            foreach (Control hijo in control.Controls)
            {

                if (hijo == btnNuevo ||
                    hijo == btnEditar ||
                    hijo == btnEliminar)
                {
                    continue;
                }

                RegistrarEventos(hijo);
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;

            if (control == null)
                return;
            if (control == dgvEmpleado || dgvEmpleado.Contains(control))
                return;
            RestablecerBotones();
        }

        private void RestablecerBotones()
        {
            dgvEmpleado.ClearSelection();
            dgvEmpleado.CurrentCell = null;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmCreateEmpleado frm = new FrmCreateEmpleado())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarEmpleados();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            using (FrmEditEmpleado frm = new FrmEditEmpleado())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarEmpleados();
                }
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Empleado eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}