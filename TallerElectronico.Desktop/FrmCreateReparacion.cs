using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmCreateReparacion : Form
    {
        private readonly ReparacionBL _reparacionBL = new ReparacionBL();
        private readonly ClienteBL _clienteBL = new ClienteBL();
        private readonly TipoEquipoBL _tipoEquipoBL = new TipoEquipoBL();
        private readonly MarcaBL _marcaBL = new MarcaBL();
        private readonly EstadoReparacionBL _estadoReparacionBL = new EstadoReparacionBL();

        private static readonly Random generador = new Random();

        public FrmCreateReparacion()
        {
            InitializeComponent();
        }

        private void FrmCreateReparacion_Load(object sender, EventArgs e)
        {
            CargarDatosIniciales();

            if (SesionUsuario.EstaAutenticado)
            {
                txtUsuarioCreacion.Text = SesionUsuario.NombreEmpleado;
            }

            txtCodigoSeguimiento.Text = GenerarCodigoSeguimiento();
        }

        private void CargarDatosIniciales()
        {
            try
            {
                // Se definen DisplayMember y ValueMember ANTES de asignar el DataSource
                cmbCliente.DisplayMember = "Nombre";
                cmbCliente.ValueMember = "ClienteId";
                cmbCliente.DataSource = _clienteBL.SelectAll();
                cmbCliente.SelectedIndex = -1;

                cmbTipoEquipo.DisplayMember = "Nombre";
                cmbTipoEquipo.ValueMember = "TipoEquipoId";
                cmbTipoEquipo.DataSource = _tipoEquipoBL.SelectAll();
                cmbTipoEquipo.SelectedIndex = -1;

                cmbMarca.DisplayMember = "Nombre";
                cmbMarca.ValueMember = "MarcaId";
                cmbMarca.DataSource = _marcaBL.SelectAll();
                cmbMarca.SelectedIndex = -1;

                cmbEstado.DisplayMember = "Nombre";
                cmbEstado.ValueMember = "EstadoReparacionId";
                cmbEstado.DataSource = _estadoReparacionBL.SelectAll();
                cmbEstado.SelectedValue = 1; // ID 1: Estado inicial ("Ingresado")
                cmbEstado.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los catálogos iniciales: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerarCodigoSeguimiento()
        {
            string codigo = "";
            int intentos = 0;

            while (intentos < 10)
            {
                codigo = "REP-" + generador.Next(10000, 99999);

                if (_reparacionBL.SelectByTrackingCode(codigo) == null)
                {
                    return codigo;
                }

                intentos++;
            }

            return null; 
        }

        private void btnGenerarCodigo_Click(object sender, EventArgs e)
        {
            txtCodigoSeguimiento.Text = GenerarCodigoSeguimiento();
        }

        private void txtCostoManoObra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "¿Desea registrar esta nueva recepción de reparación?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                int clienteId = cmbCliente.SelectedValue != null ? Convert.ToInt32(cmbCliente.SelectedValue) : 0;
                int tipoEquipoId = cmbTipoEquipo.SelectedValue != null ? Convert.ToInt32(cmbTipoEquipo.SelectedValue) : 0;
                int marcaId = cmbMarca.SelectedValue != null ? Convert.ToInt32(cmbMarca.SelectedValue) : 0;
                int estadoId = cmbEstado.SelectedValue != null ? Convert.ToInt32(cmbEstado.SelectedValue) : 1;

                decimal.TryParse(txtCostoManoObra.Text.Trim(), out decimal costoManoObra);

                Reparacion reparacion = new Reparacion
                {
                    CodigoSeguimiento = string.IsNullOrWhiteSpace(txtCodigoSeguimiento.Text) ? null : txtCodigoSeguimiento.Text.Trim(),
                    ClienteId = clienteId,
                    TipoEquipoId = tipoEquipoId,
                    MarcaId = marcaId,
                    Modelo = txtModelo.Text.Trim(),
                    DiagnosticoInicial = txtDiagnosticoInicial.Text.Trim(),
                    EstadoReparacionId = estadoId,
                    FechaIngreso = DateTime.Now,
                    CostoManoObra = costoManoObra,
                    UsuarioCreacionId = SesionUsuario.UsuarioId,

                    TecnicoAsignadoId = null,
                    DiagnosticoFinal = null,
                    FechaEntrega = null,
                    TotalReparacion = null,
                    FechaModificacion = null,
                    UsuarioModificacionId = null
                };

                Reparacion nuevaReparacion = _reparacionBL.Insert(reparacion);

                if (nuevaReparacion != null && nuevaReparacion.ReparacionId > 0)
                {
                    MessageBox.Show(
                        "La reparación ha sido registrada correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Validación de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Regla de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al crear la reparación: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}