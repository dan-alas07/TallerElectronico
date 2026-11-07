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
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmDetalleReparacion : Form
    {
        private readonly DetalleReparacionBL _detalleReparacionBL = new DetalleReparacionBL();
        private bool cargandoDetalles = false;
        private readonly Timer _timerBusqueda = new Timer();
        public FrmDetalleReparacion()
        {
            InitializeComponent();

            RegistrarEventos(this);

            dgvDetalleReparacion.AutoGenerateColumns = false;
            dgvDetalleReparacion.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleReparacion.MultiSelect = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;

            dgvDetalleReparacion.SelectionChanged += dgvDetalleReparacion_SelectionChanged;

            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;
        }

        private void FrmDetalleReparacion_Load(object sender, EventArgs e)
        {
            CargarDetallesReparacion();

            BeginInvoke((MethodInvoker)delegate
            {
                RestablecerBotones();
            });

        }

        private void CargarDetallesReparacion()
        {
            try
            {
                cargandoDetalles = true;

                string criterio = txtBuscar != null ? txtBuscar.Text.Trim() : string.Empty;

                dgvDetalleReparacion.DataSource = null;

                if (string.IsNullOrWhiteSpace(criterio))
                {
                    dgvDetalleReparacion.DataSource = _detalleReparacionBL.SelectAll();
                }
                else
                {
                    //dgvDetalleReparacion.DataSource = _detalleReparacionBL.Search(criterio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los detalles de reparación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoDetalles = false;
                RestablecerBotones();
            }
        }

        private void dgvDetalleReparacion_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoDetalles) return;

            bool detalleSeleccionado = dgvDetalleReparacion.SelectedRows.Count > 0;

            btnNuevo.Enabled = !detalleSeleccionado;
            btnEditar.Enabled = detalleSeleccionado;
        }

        private void RegistrarEventos(Control control)
        {
            control.MouseDown += Control_MouseDown;

            foreach (Control hijo in control.Controls)
            {
                if (hijo == btnNuevo || hijo == btnEditar || hijo == txtBuscar)
                    continue;

                RegistrarEventos(hijo);
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;

            if (control == null || control == dgvDetalleReparacion)
                return;

            RestablecerBotones();
        }

        private void RestablecerBotones()
        {
            if (dgvDetalleReparacion != null)
            {
                dgvDetalleReparacion.ClearSelection();
                dgvDetalleReparacion.CurrentCell = null;
            }

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
        }

        private int? ObtenerDetalleSeleccionado()
        {
            if (dgvDetalleReparacion.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un detalle de reparación.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            object valorId = dgvDetalleReparacion.SelectedRows[0].Cells["ColumnCode"].Value;

            if (valorId == null || valorId == DBNull.Value)
            {
                MessageBox.Show("No se pudo obtener el código del detalle de reparación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return Convert.ToInt32(valorId);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //using (FrmCreateDetalleReparacion frm = new FrmCreateDetalleReparacion())
            //{
            //    if (frm.ShowDialog(this) == DialogResult.OK)
            //    {
            //        CargarDetallesReparacion();
            //    }
            //}
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? DetalleReparacionId = ObtenerDetalleSeleccionado();
            if (!DetalleReparacionId.HasValue) return;

            using (FrmEditDetalleReparacion frm = new FrmEditDetalleReparacion(DetalleReparacionId.Value))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarDetallesReparacion();
                }
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
            CargarDetallesReparacion(); // Llama a la DAL cuando el usuario pausó el tipeo
        }
    }
}

