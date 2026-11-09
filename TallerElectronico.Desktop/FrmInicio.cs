using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmInicio : Form
    {
        private readonly ReparacionBL _reparacionBL = new ReparacionBL();
        private readonly bool _esTecnico = false;
        private bool _cargandoOrdenes = false;

        public FrmInicio()
        {
            InitializeComponent();

            _esTecnico = SesionUsuario.RolNombre != null &&
                         SesionUsuario.RolNombre.Trim().Equals("Tecnico", StringComparison.OrdinalIgnoreCase);

            RegistrarEventos(this);

            dgvReparaciones.AutoGenerateColumns = false;
            dgvReparaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReparaciones.MultiSelect = false;
            dgvReparaciones.ReadOnly = true;

            AplicarPermisosRol();

            dgvReparaciones.SelectionChanged += dgvReparaciones_SelectionChanged;
        }

        private void AplicarPermisosRol()
        {
            if (_esTecnico)
            {
                btnNuevo.Visible = false;
            }
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            MostrarSaludoUsuario();
            CargarDashboard();

            BeginInvoke((MethodInvoker)delegate
            {
                RestablecerBotones();
            });
        }

        private void MostrarSaludoUsuario()
        {
            if (SesionUsuario.EstaAutenticado)
            {
                lblBienvenido.Text = $"Bienvenido/a: {SesionUsuario.RolNombre} - {SesionUsuario.NombreEmpleado}";
            }
            else
            {
                lblBienvenido.Text = "Bienvenido/a: Invitado";
            }
        }

        private void CargarDashboard()
        {
            CargarKpis();
            CargarOrdenes();
        }

        private void CargarKpis()
        {
            try
            {
                KpiDashboardDTO kpis = _reparacionBL.GetKpis();

                lblKpiAbiertas.Text = kpis.OrdenesAbiertas.ToString();
                lblKpiListas.Text = kpis.OrdenesListas.ToString();
                lblKpiEntregadas.Text = kpis.OrdenesEntregadas.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las métricas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarOrdenes()
        {
            try
            {
                _cargandoOrdenes = true;

                dgvReparaciones.DataSource = null;
                dgvReparaciones.DataSource = _reparacionBL.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las órdenes de trabajo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _cargandoOrdenes = false;
                RestablecerBotones();
            }
        }

        private void dgvReparaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (_cargandoOrdenes) return;

            bool reparacionSeleccionada = dgvReparaciones.SelectedRows.Count > 0;

            if (_esTecnico)
            {
                btnEditar.Enabled = reparacionSeleccionada;
            }
            else
            {
                btnNuevo.Enabled = !reparacionSeleccionada;
                btnEditar.Enabled = reparacionSeleccionada;
            }
        }

        private void RegistrarEventos(Control control)
        {
            control.MouseDown += Control_MouseDown;

            foreach (Control hijo in control.Controls)
            {
                if (hijo == btnNuevo || hijo == btnEditar)
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

            if (_esTecnico)
            {
                btnEditar.Enabled = false;
            }
            else
            {
                btnNuevo.Enabled = true;
                btnEditar.Enabled = false;
            }
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
            if (_esTecnico) return;

            using (FrmCreateReparacion frm = new FrmCreateReparacion())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarDashboard();
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
                    CargarDashboard();
                }
            }
        }
    }
}