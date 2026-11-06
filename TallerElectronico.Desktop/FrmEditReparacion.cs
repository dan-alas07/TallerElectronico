using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmEditReparacion : Form
    {
        private readonly ReparacionBL _reparacionBL = new ReparacionBL();
        private readonly ClienteBL _clienteBL = new ClienteBL();
        private readonly TipoEquipoBL _tipoEquipoBL = new TipoEquipoBL();
        private readonly MarcaBL _marcaBL = new MarcaBL();
        private readonly UsuarioBL _usuarioBL = new UsuarioBL();
        private readonly EstadoReparacionBL _estadoReparacionBL = new EstadoReparacionBL();

        private readonly int _reparacionId;
        private Reparacion _reparacionActual;

        public FrmEditReparacion(int reparacionId)
        {
            InitializeComponent();
            _reparacionId = reparacionId;
        }

        private void FrmEditReparacion_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarReparacion();

            if (SesionUsuario.EstaAutenticado)
            {
                txtUsuarioModificacion.Text = SesionUsuario.NombreEmpleado;
            }
        }

        private void CargarCombos()
        {
            try
            {
                // 1. Cliente
                cmbCliente.DisplayMember = "NombreCompleto";
                cmbCliente.ValueMember = "ClienteId";
                cmbCliente.DataSource = _clienteBL.SelectAll();

                // 2. TipoEquipo
                cmbTipoEquipo.DisplayMember = "Nombre";
                cmbTipoEquipo.ValueMember = "TipoEquipoId";
                cmbTipoEquipo.DataSource = _tipoEquipoBL.SelectAll();

                // 3. Marca
                cmbMarca.DisplayMember = "Nombre";
                cmbMarca.ValueMember = "MarcaId";
                cmbMarca.DataSource = _marcaBL.SelectAll();

                // 4. Técnico / Usuario (Configurar ValueMember y DisplayMember ANTES del DataSource)
                cmbTecnico.DisplayMember = "NombreCompleto";
                cmbTecnico.ValueMember = "UsuarioId";
                cmbTecnico.DataSource = _usuarioBL.SelectAll();
                cmbTecnico.SelectedIndex = -1;

                // 5. EstadoReparacion
                cmbEstado.DisplayMember = "Nombre";
                cmbEstado.ValueMember = "EstadoReparacionId";
                cmbEstado.DataSource = _estadoReparacionBL.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los catálogos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarReparacion()
        {
            try
            {
                _reparacionActual = _reparacionBL.SelectById(_reparacionId);

                if (_reparacionActual == null)
                {
                    MessageBox.Show("No se encontró la reparación seleccionada.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                
                txtCodigoSeguimiento.Text = _reparacionActual.CodigoSeguimiento;
                txtCodigoSeguimiento.ReadOnly = true;

                cmbCliente.SelectedValue = _reparacionActual.ClienteId;
                cmbCliente.Enabled = false;

                cmbTipoEquipo.SelectedValue = _reparacionActual.TipoEquipoId;
                cmbTipoEquipo.Enabled = false;

                cmbMarca.SelectedValue = _reparacionActual.MarcaId;
                cmbMarca.Enabled = false;

                txtModelo.Text = _reparacionActual.Modelo;
                txtModelo.ReadOnly = true;

                txtDiagnosticoInicial.Text = _reparacionActual.DiagnosticoInicial;
                txtDiagnosticoInicial.ReadOnly = true;

                txtFechaIngreso.Text = _reparacionActual.FechaIngreso.ToString("dd/MM/yyyy HH:mm");

                
                if (_reparacionActual.TecnicoAsignadoId.HasValue)
                {
                    cmbTecnico.SelectedValue = _reparacionActual.TecnicoAsignadoId.Value;
                }
                else
                {
                    cmbTecnico.SelectedIndex = -1;
                }

                cmbEstado.SelectedValue = _reparacionActual.EstadoReparacionId;
                txtDiagnosticoFinal.Text = _reparacionActual.DiagnosticoFinal ?? "";
                txtCostoManoObra.Text = _reparacionActual.CostoManoObra.ToString("0.00");
                txtTotalReparacion.Text = _reparacionActual.TotalReparacion.HasValue
                    ? _reparacionActual.TotalReparacion.Value.ToString("0.00")
                    : "";

                if (_reparacionActual.FechaEntrega.HasValue)
                {
                    dtpFechaEntrega.Value = _reparacionActual.FechaEntrega.Value;
                    dtpFechaEntrega.Checked = true;
                }
                else
                {
                    dtpFechaEntrega.Checked = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la reparación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
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
                "¿Desea guardar los cambios en esta reparación?",
                "Confirmar Edición",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                int? tecnicoId = null;

                if (cmbTecnico.SelectedValue is int idInt)
                {
                    tecnicoId = idInt;
                }
                else if (cmbTecnico.SelectedValue is UsuarioDTO usuario)
                {
                    tecnicoId = usuario.Id;
                }
                else if (cmbTecnico.SelectedValue != null && int.TryParse(cmbTecnico.SelectedValue.ToString(), out int parsedId))
                {
                    tecnicoId = parsedId;
                }

                int estadoId = 0;
                if (cmbEstado.SelectedValue is int idEstado)
                {
                    estadoId = idEstado;
                }
                else if (cmbEstado.SelectedValue != null && int.TryParse(cmbEstado.SelectedValue.ToString(), out int parsedEstado))
                {
                    estadoId = parsedEstado;
                }

                decimal.TryParse(txtCostoManoObra.Text.Trim(), out decimal costoManoObra);

                decimal? totalReparacion = null;
                if (decimal.TryParse(txtTotalReparacion.Text.Trim(), out decimal totalParsed))
                {
                    totalReparacion = totalParsed;
                }

                DateTime? fechaEntrega = dtpFechaEntrega.Checked ? dtpFechaEntrega.Value : (DateTime?)null;

               
                _reparacionActual.TecnicoAsignadoId = tecnicoId;
                _reparacionActual.EstadoReparacionId = estadoId;
                _reparacionActual.DiagnosticoFinal = string.IsNullOrWhiteSpace(txtDiagnosticoFinal.Text) ? null : txtDiagnosticoFinal.Text.Trim();
                _reparacionActual.CostoManoObra = costoManoObra;
                _reparacionActual.TotalReparacion = totalReparacion;
                _reparacionActual.FechaEntrega = fechaEntrega;

               
                _reparacionActual.FechaModificacion = DateTime.Now;
                _reparacionActual.UsuarioModificacionId = SesionUsuario.UsuarioId;

                
                Reparacion reparacionActualizada = _reparacionBL.Update(_reparacionActual);

                if (reparacionActualizada != null)
                {
                    MessageBox.Show(
                        "La reparación ha sido actualizada correctamente.",
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
                MessageBox.Show("Ocurrió un error inesperado al actualizar la reparación: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}