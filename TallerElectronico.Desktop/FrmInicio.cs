using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmInicio : Form
    {
        private readonly ReparacionBL _reparacionBL = new ReparacionBL();

        public FrmInicio()
        {
            InitializeComponent();
            dgvReparaciones.AutoGenerateColumns = false;
        }

        private void FrmInicio_Load(object sender, EventArgs e)
        {
            CargarDashboard();
            MostrarSaludoUsuario();
        }

        private void MostrarSaludoUsuario()
        {
            if (SesionUsuario.EstaAutenticado)
            {
                // Ejemplo: "Bienvenido/a: Administrador - Rodrigo Martínez"
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
                dgvReparaciones.DataSource = null;
                dgvReparaciones.DataSource = _reparacionBL.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las órdenes de trabajo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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