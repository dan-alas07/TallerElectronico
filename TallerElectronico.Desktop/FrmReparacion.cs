using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

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

            // Configurar el temporizador para la búsqueda (300 ms de espera tras tipear)
            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;
        }

        private void FrmReparacion_Load(object sender, EventArgs e)
        {
            CargarReparaciones();

            // Garantiza la deselección de filas tras renderizar los controles
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

                string criterio = txtBuscar != null ? txtBuscar.Text.Trim().ToLower() : string.Empty;

                dgvReparaciones.DataSource = null;

                List<ReparacionDTO> lista = _reparacionBL.SelectAll();

                if (!string.IsNullOrWhiteSpace(criterio))
                {
                    lista = lista.Where(r =>
                        (!string.IsNullOrEmpty(r.CodigoSeguimiento) && r.CodigoSeguimiento.ToLower().Contains(criterio)) ||
                        (!string.IsNullOrEmpty(r.ClienteNombre) && r.ClienteNombre.ToLower().Contains(criterio)) ||
                        (!string.IsNullOrEmpty(r.EquipoCompleto) && r.EquipoCompleto.ToLower().Contains(criterio)) ||
                        (!string.IsNullOrEmpty(r.EstadoNombre) && r.EstadoNombre.ToLower().Contains(criterio))
                    ).ToList();
                }

                dgvReparaciones.DataSource = lista;
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

        private ReparacionDTO ObtenerReparacionSeleccionada()
        {
            if (dgvReparaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una reparación de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (dgvReparaciones.SelectedRows[0].DataBoundItem is ReparacionDTO dto)
            {
                return dto;
            }

            MessageBox.Show("No se pudo obtener la información de la reparación seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmCreateReparacion frm = new FrmCreateReparacion())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarReparaciones();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ReparacionDTO seleccion = ObtenerReparacionSeleccionada();
            if (seleccion == null) return;

            using (FrmEditReparacion frm = new FrmEditReparacion(seleccion.ReparacionId))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarReparaciones();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ReparacionDTO seleccion = ObtenerReparacionSeleccionada();
            if (seleccion == null) return;

            DialogResult confirm = MessageBox.Show(
                $"¿Seguro que desea eliminar la reparación '{seleccion.CodigoSeguimiento}' ({seleccion.EquipoCompleto})?",
                "Confirmar Eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                _reparacionBL.Delete(seleccion.ReparacionId);
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
            // Reinicia el reloj con cada tecla presionada; ejecuta la búsqueda tras 300 ms de inactividad
            _timerBusqueda.Stop();
            _timerBusqueda.Start();
        }

        private void TimerBusqueda_Tick(object sender, EventArgs e)
        {
            _timerBusqueda.Stop();
            CargarReparaciones();
        }
    }
}