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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}