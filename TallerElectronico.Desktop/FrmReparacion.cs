using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;

namespace TallerElectronico.Desktop
{
    public partial class FrmReparacion : Form
    {
        private readonly ReparacionBL _reparacionBL = new ReparacionBL();

        public FrmReparacion()
        {
            InitializeComponent();

            dgvReparaciones.AutoGenerateColumns = false;
            dgvReparaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReparaciones.MultiSelect = false;
        }

        private void FrmReparacion_Load(object sender, EventArgs e)
        {
            CargarReparaciones();
        }

        private void CargarReparaciones()
        {
            try
            {
                dgvReparaciones.DataSource = null;
                dgvReparaciones.DataSource = _reparacionBL.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar las reparaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}