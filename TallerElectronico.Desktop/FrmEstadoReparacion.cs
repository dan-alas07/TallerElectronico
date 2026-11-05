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
    public partial class FrmEstadoReparacion : Form
    {
        private readonly EstadoReparacionBL _estadoReparacionBL = new EstadoReparacionBL();
        private bool cargandoEstados = false;
        private readonly Timer _timerBusqueda = new Timer();

        public FrmEstadoReparacion()
        {
            InitializeComponent();

            RegistrarEventos(this);

            dgvEstadoReparacion.AutoGenerateColumns = false;
            dgvEstadoReparacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEstadoReparacion.MultiSelect = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvEstadoReparacion.SelectionChanged += dgvEstadoReparacion_SelectionChanged;

            // Configurar el temporizador (300 milisegundos de espera)
            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;
        }

        private void FrmEstadoReparacion_Load(object sender, EventArgs e)
        {
            CargarEstados();
            BeginInvoke((MethodInvoker)delegate
            {
                RestablecerBotones();
            });
        }

        private void CargarEstados()
        {
            try
            {
                cargandoEstados = true;

                string criterio = txtBuscar != null ? txtBuscar.Text.Trim() : string.Empty;

                dgvEstadoReparacion.DataSource = null;

                if (string.IsNullOrWhiteSpace(criterio))
                {
                    dgvEstadoReparacion.DataSource = _estadoReparacionBL.SelectAll();
                }
                else
                {
                    dgvEstadoReparacion.DataSource = _estadoReparacionBL.Search(criterio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar las marcas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoEstados = false;
                RestablecerBotones();
            }
        }

        private void dgvEstadoReparacion_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoEstados) return;

            bool marcaSeleccionada = dgvEstadoReparacion.SelectedRows.Count > 0;

            btnNuevo.Enabled = !marcaSeleccionada;
            btnEditar.Enabled = marcaSeleccionada;
            btnEliminar.Enabled = marcaSeleccionada;
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

            if (control == null || control == dgvEstadoReparacion)
                return;

            RestablecerBotones();
        }

        private void RestablecerBotones()
        {
            if (dgvEstadoReparacion != null)
            {
                dgvEstadoReparacion.ClearSelection();
                dgvEstadoReparacion.CurrentCell = null;
            }

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private int? ObtenerEstadoSeleccionado()
        {
            if (dgvEstadoReparacion.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una marca.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            object valorId = dgvEstadoReparacion.SelectedRows[0].Cells["ColumnCode"].Value;

            if (valorId == null || valorId == DBNull.Value)
            {
                MessageBox.Show("No se pudo obtener el código del estado reparación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return Convert.ToInt32(valorId);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmCreateEstadoReparacion frm = new FrmCreateEstadoReparacion())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarEstados();
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? estadoReparacionId = ObtenerEstadoSeleccionado();
            if (!estadoReparacionId.HasValue) return;

            using (FrmEditEstadoReparacion frm = new FrmEditEstadoReparacion(estadoReparacionId.Value))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarEstados();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? estadoReparacionId = ObtenerEstadoSeleccionado();
            if (!estadoReparacionId.HasValue) return;

            string nombre = Convert.ToString(dgvEstadoReparacion.SelectedRows[0].Cells["ColumnName"].Value);

            DialogResult confirm = MessageBox.Show($"¿Seguro que desea eliminar el estado: {nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _estadoReparacionBL.Delete(estadoReparacionId.Value);
                MessageBox.Show("El estado se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEstados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el estado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            CargarEstados(); // Llama a la DAL cuando el usuario pausó el tipeo
        }
    }
}
