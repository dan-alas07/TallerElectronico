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
            OcultarUsuarioModificacion();
            CargarCombos();
            CargarReparacion();
        }

        private void OcultarUsuarioModificacion()
        {
            // Oculta el control de usuario a nivel visual si existe en el formulario
            Control[] txtUser = Controls.Find("txtUsuarioModificacion", true);
            if (txtUser.Length > 0) txtUser[0].Visible = false;

            Control[] lblUser = Controls.Find("lblUsuarioModificacion", true);
            if (lblUser.Length > 0) lblUser[0].Visible = false;
        }

        private void CargarCombos()
        {
            try
            {
                // Cliente: formato concatenado (Nombre + Apellido)
                cmbCliente.ValueMember = "ClienteId";
                cmbCliente.FormattingEnabled = true;
                cmbCliente.Format -= cmbCliente_Format;
                cmbCliente.Format += cmbCliente_Format;
                cmbCliente.DataSource = _clienteBL.SelectAll();

                // TipoEquipo
                cmbTipoEquipo.DisplayMember = "Nombre";
                cmbTipoEquipo.ValueMember = "TipoEquipoId";
                cmbTipoEquipo.DataSource = _tipoEquipoBL.SelectAll();

                // Marca
                cmbMarca.DisplayMember = "Nombre";
                cmbMarca.ValueMember = "MarcaId";
                cmbMarca.DataSource = _marcaBL.SelectAll();

                // Técnico / UsuarioDTO
                cmbTecnico.DisplayMember = "EmpleadoNombre";
                cmbTecnico.ValueMember = "Id";
                cmbTecnico.DataSource = _usuarioBL.SelectAll();
                cmbTecnico.SelectedIndex = -1;

                // EstadoReparacion
                cmbEstado.DisplayMember = "Nombre";
                cmbEstado.ValueMember = "EstadoReparacionId";
                cmbEstado.DataSource = _estadoReparacionBL.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los catálogos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCliente_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Cliente c)
            {
                e.Value = $"{c.Nombre} {c.Apellido}";
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
                txtCodigoSeguimiento.Enabled = false;

                Control[] txtFecha = Controls.Find("txtFechaIngreso", true);
                if (txtFecha.Length > 0 && txtFecha[0] is TextBox tbIngreso)
                {
                    tbIngreso.Text = _reparacionActual.FechaIngreso.ToString("dd/MM/yyyy HH:mm");
                    tbIngreso.ReadOnly = true;
                    tbIngreso.Enabled = false;
                }
                else
                {
                    Control[] dtpFecha = Controls.Find("dtpFechaIngreso", true);
                    if (dtpFecha.Length > 0 && dtpFecha[0] is DateTimePicker dtpIngreso)
                    {
                        dtpIngreso.Value = _reparacionActual.FechaIngreso;
                        dtpIngreso.Enabled = false;
                    }
                }

                // Cargar resto de campos de la recepción
                cmbCliente.SelectedValue = _reparacionActual.ClienteId;
                cmbTipoEquipo.SelectedValue = _reparacionActual.TipoEquipoId;
                cmbMarca.SelectedValue = _reparacionActual.MarcaId;
                txtModelo.Text = _reparacionActual.Modelo;
                txtDiagnosticoInicial.Text = _reparacionActual.DiagnosticoInicial;

                // Técnico Asignado
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

        private void txtCostoManoObra_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtMonto_KeyPress(sender, e);
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
                // Extracción del ID del técnico
                int? tecnicoId = null;
                if (cmbTecnico.SelectedValue is int idInt)
                {
                    tecnicoId = idInt;
                }
                else if (cmbTecnico.SelectedValue is UsuarioDTO usuario)
                {
                    tecnicoId = usuario.Id;
                }

                // Extracción del Estado ID
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

                // Actualización de propiedades
                _reparacionActual.TecnicoAsignadoId = tecnicoId;
                _reparacionActual.EstadoReparacionId = estadoId;
                _reparacionActual.DiagnosticoFinal = string.IsNullOrWhiteSpace(txtDiagnosticoFinal.Text) ? null : txtDiagnosticoFinal.Text.Trim();
                _reparacionActual.CostoManoObra = costoManoObra;
                _reparacionActual.TotalReparacion = totalReparacion;
                _reparacionActual.FechaEntrega = fechaEntrega;

                // Auditoría interna 
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
    }
}