using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;

namespace TallerElectronico.Desktop
{
    public partial class FrmReparacion : Form
    {
        private readonly ReparacionBL _reparacionBL = new ReparacionBL();
        private bool cargandoReparaciones = false;
        private readonly Timer _timerBusqueda = new Timer();

        public FrmReparacion()
        {
            InitializeComponent();

            RegistrarEventos(this);

            dgvReparaciones.AutoGenerateColumns = false;
            dgvReparaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReparaciones.MultiSelect = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvReparaciones.SelectionChanged += dgvReparaciones_SelectionChanged;

            // Configurar el temporizador (300 milisegundos de espera)
            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;
        }

        private void FrmReparacion_Load(object sender, EventArgs e)
        {
            CargarReparaciones();

            // Garantiza que la deselección se aplique tras renderizar los controles
            BeginInvoke((MethodInvoker)delegate
            {
                RestablecerBotones();
            });
        }

        private void CargarReparaciones()
        {
            try
            {
                cargandoReparaciones = true;

                string criterio = txtBuscar != null ? txtBuscar.Text.Trim() : string.Empty;

                dgvReparaciones.DataSource = null;

                if (string.IsNullOrWhiteSpace(criterio))
                {
                    dgvReparaciones.DataSource = _reparacionBL.SelectAll();
                }
                else
                {
                    //dgvReparaciones.DataSource = _reparacionBL.Search(criterio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar las reparaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoReparaciones = false;
                RestablecerBotones();
            }
        }

        private void dgvReparaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoReparaciones) return;

            bool reparacionSeleccionada = dgvReparaciones.SelectedRows.Count > 0;

            btnNuevo.Enabled = !reparacionSeleccionada;
            btnEditar.Enabled = reparacionSeleccionada;
            btnEliminar.Enabled = reparacionSeleccionada;
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

            if (control == null || control == dgvReparaciones)
                return;

            RestablecerBotones();
        }

        private void RestablecerBotones()
        {
            if (dgvReparaciones != null)
            {
                dgvReparaciones.ClearSelection();
                dgvReparaciones.CurrentCell = null;
            }

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private int? ObtenerReparacionSeleccionada()
        {
            if (dgvReparaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una reparación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            object valorId = dgvReparaciones.SelectedRows[0].Cells["ColumnCode"].Value;

            if (valorId == null || valorId == DBNull.Value)
            {
                MessageBox.Show("No se pudo obtener el código de la reparación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return Convert.ToInt32(valorId);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //using (FrmCreateReparacion frm = new FrmCreateReparacion())
            //{
            //    if (frm.ShowDialog(this) == DialogResult.OK)
            //    {
            //        CargarReparaciones();
            //    }
            //}
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? reparacionId = ObtenerReparacionSeleccionada();
            if (!reparacionId.HasValue) return;

            //using (FrmEditReparacion frm = new FrmEditReparacion(reparacionId.Value))
            //{
            //    if (frm.ShowDialog(this) == DialogResult.OK)
            //    {
            //        CargarReparaciones();
            //    }
            //}
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? reparacionId = ObtenerReparacionSeleccionada();
            if (!reparacionId.HasValue) return;

            string nombre = Convert.ToString(dgvReparaciones.SelectedRows[0].Cells["ColumnName"].Value);

            DialogResult confirm = MessageBox.Show($"¿Seguro que desea eliminar la reparación {nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _reparacionBL.Delete(reparacionId.Value);
                MessageBox.Show("La reparación se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarReparaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar la reparación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            CargarReparaciones(); // Llama a la DAL cuando el usuario pausó el tipeo
        }
    }
}