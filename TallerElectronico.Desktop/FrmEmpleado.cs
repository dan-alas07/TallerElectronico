
using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;

namespace TallerElectronico.Desktop
{
    public partial class FrmEmpleado : Form
    {
        private readonly EmpleadoBL _empleadoBL = new EmpleadoBL();
        private bool cargandoEmpleados = false;
        private readonly Timer _timerBusqueda = new Timer();

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

            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;
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

                string criterio = txtBuscar != null ? txtBuscar.Text.Trim() : string.Empty;

                dgvEmpleado.DataSource = null;

                if (string.IsNullOrWhiteSpace(criterio))
                {
                    dgvEmpleado.DataSource = _empleadoBL.SelectAll();
                }
                else
                {
                    dgvEmpleado.DataSource = _empleadoBL.Search(criterio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoEmpleados = false;
                RestablecerBotones();
            }
        }

        private void dgvEmpleado_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoEmpleados) return;

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
                if (hijo == btnNuevo || hijo == btnEditar || hijo == btnEliminar || hijo == txtBuscar)
                    continue;

                RegistrarEventos(hijo);
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;

            if (control == null || control == dgvEmpleado)
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

        private int? ObtenerEmpleadoSeleccionado()
        {
            if (dgvEmpleado.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un empleado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            object valorId = dgvEmpleado.SelectedRows[0].Cells["ColumnCode"].Value;

            if (valorId == null || valorId == DBNull.Value)
            {
                MessageBox.Show("No se pudo obtener el código del empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return Convert.ToInt32(valorId);
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
            int? empleadoId = ObtenerEmpleadoSeleccionado();
            if (!empleadoId.HasValue) return;

            using (FrmEditEmpleado frm = new FrmEditEmpleado(empleadoId.Value))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarEmpleados();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? empleadoId = ObtenerEmpleadoSeleccionado();
            if (!empleadoId.HasValue) return;

            string nombre = Convert.ToString(dgvEmpleado.SelectedRows[0].Cells["ColumnName"].Value);
            string apellido = Convert.ToString(dgvEmpleado.SelectedRows[0].Cells["ColumnLastName"].Value);

            DialogResult confirm = MessageBox.Show($"¿Seguro que desea eliminar al empleado {nombre} {apellido}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _empleadoBL.Delete(empleadoId.Value);
                MessageBox.Show("El empleado se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Reinicia el reloj a cada tecla. Solo cuando te detengas 300ms se consultará a la DAL
            _timerBusqueda.Stop();
            _timerBusqueda.Start();
        }

        private void TimerBusqueda_Tick(object sender, EventArgs e)
        {
            _timerBusqueda.Stop();
            CargarEmpleados(); // Llama a la DAL cuando el usuario pausó el tipeo
        }
    }
}
