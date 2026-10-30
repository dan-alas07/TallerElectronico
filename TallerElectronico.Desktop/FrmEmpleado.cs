
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

            dgvEmpleado.SelectionChanged += dgvEmpleado_SelectionChanged;
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {
            CargarEmpleados();

            BeginInvoke((MethodInvoker)delegate
            {
                RestablecerBotones();
            });

        }

        private void CargarEmpleados()
        {
            try
            {
                cargandoEmpleados = true;

                dgvEmpleado.DataSource = null;
                dgvEmpleado.DataSource = _empleadoBL.SelectAll();

                dgvEmpleado.ClearSelection();
                dgvEmpleado.CurrentCell = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ocurrió un error al cargar los empleados: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                cargandoEmpleados = false;
                RestablecerBotones();
            }
        }

        private void dgvEmpleado_SelectionChanged(
            object sender, EventArgs e)
        {
            if (cargandoEmpleados)
                return;

            bool empleadoSeleccionado =
                dgvEmpleado.SelectedRows.Count > 0;

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

            if (control == dgvEmpleado)
                return;

            RestablecerBotones();
        }

        private void RestablecerBotones()
        {
            if (dgvEmpleado != null)
            {
                dgvEmpleado.ClearSelection();
                dgvEmpleado.CurrentCell = null;
            }

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
            if (dgvEmpleado.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Selecciona un empleado para editar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            object valorId = dgvEmpleado.SelectedRows[0] .Cells["ColumnCode"].Value;

            if (valorId == null || valorId == DBNull.Value)
            {
                MessageBox.Show(
                    "No se pudo obtener el código del empleado.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            int empleadoId = Convert.ToInt32(valorId);

            using (FrmEditEmpleado frm =
                new FrmEditEmpleado(empleadoId))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarEmpleados();
                    RestablecerBotones();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleado.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Selecciona un empleado para eliminar.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            object valorId = dgvEmpleado.SelectedRows[0].Cells["ColumnCode"].Value;

            if (valorId == null || valorId == DBNull.Value)
            {
                MessageBox.Show(
                    "No se pudo obtener el código del empleado.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                return;
            }

            int empleadoId = Convert.ToInt32(valorId);

            string nombre = Convert.ToString(
                dgvEmpleado.SelectedRows[0]
                    .Cells["ColumnName"].Value
            );

            string apellido = Convert.ToString(
                dgvEmpleado.SelectedRows[0]
                    .Cells["ColumnLastName"].Value
            );

            DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar al empleado "
                + nombre + " " + apellido + "?\n\n"
                + "Esta acción desactivará al empleado.",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                _empleadoBL.Delete(empleadoId);

                MessageBox.Show(
                    "El empleado se eliminó correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                CargarEmpleados();
                RestablecerBotones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo eliminar el empleado: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
