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
        private readonly UsuarioBL _usuarioBL = new UsuarioBL();
        private readonly EstadoReparacionBL _estadoReparacionBL = new EstadoReparacionBL();

        public FrmCreateReparacion()
        {
            InitializeComponent();
        }

        private void FrmCreateReparacion_Load(object sender, EventArgs e)
        {
            // Bloquea la edición manual del código de seguimiento
            txtCodigoSeguimiento.ReadOnly = true;

            CargarCombos();

            // Asigna la fecha y hora actual de ingreso
            dtpFechaIngreso.Value = DateTime.Now;

            // Genera el código automáticamente con la fecha y hora detallada
            GenerarCodigoSeguimiento();
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
                cmbCliente.SelectedIndex = -1;

                // TipoEquipo
                cmbTipoEquipo.DisplayMember = "Nombre";
                cmbTipoEquipo.ValueMember = "TipoEquipoId";
                cmbTipoEquipo.DataSource = _tipoEquipoBL.SelectAll();
                cmbTipoEquipo.SelectedIndex = -1;

                // Marca
                cmbMarca.DisplayMember = "Nombre";
                cmbMarca.ValueMember = "MarcaId";
                cmbMarca.DataSource = _marcaBL.SelectAll();
                cmbMarca.SelectedIndex = -1;

                // Técnico / UsuarioDTO
                cmbTecnico.DisplayMember = "EmpleadoNombre";
                cmbTecnico.ValueMember = "Id";
                cmbTecnico.DataSource = _usuarioBL.SelectAll();
                cmbTecnico.SelectedIndex = -1;

                // EstadoReparacion
                cmbEstado.DisplayMember = "Nombre";
                cmbEstado.ValueMember = "EstadoReparacionId";
                cmbEstado.DataSource = _estadoReparacionBL.SelectAll();
                cmbEstado.SelectedIndex = -1;
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

        private void GenerarCodigoSeguimiento()
        {

            string codigo = "REP-" + DateTime.Now.ToString("yyyyMMddHHmmss");
            txtCodigoSeguimiento.Text = codigo;
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
            // Validaciones básicas
            if (cmbCliente.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un cliente.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbTipoEquipo.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un tipo de equipo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMarca.SelectedValue == null)
            {
                MessageBox.Show("Selecciona una marca.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            {
                MessageBox.Show("Ingresa el modelo del equipo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiagnosticoInicial.Text))
            {
                MessageBox.Show("Ingresa el diagnóstico inicial.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbEstado.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un estado inicial.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "¿Desea registrar la nueva recepción de reparación?",
                "Confirmar Registro",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                decimal.TryParse(txtCostoManoObra.Text.Trim(), out decimal costoManoObra);
                decimal? totalReparacion = null;
                if (decimal.TryParse(txtTotalReparacion.Text.Trim(), out decimal totalParsed))
                {
                    totalReparacion = totalParsed;
                }

                // Extracción del técnico
                int? tecnicoId = null;
                if (cmbTecnico.SelectedValue is int idTecnico)
                {
                    tecnicoId = idTecnico;
                }
                else if (cmbTecnico.SelectedValue is UsuarioDTO usuario)
                {
                    tecnicoId = usuario.Id;
                }

                Reparacion nuevaReparacion = new Reparacion
                {
                    CodigoSeguimiento = txtCodigoSeguimiento.Text.Trim(),
                    ClienteId = Convert.ToInt32(cmbCliente.SelectedValue),
                    TipoEquipoId = Convert.ToInt32(cmbTipoEquipo.SelectedValue),
                    MarcaId = Convert.ToInt32(cmbMarca.SelectedValue),
                    Modelo = txtModelo.Text.Trim(),
                    DiagnosticoInicial = txtDiagnosticoInicial.Text.Trim(),
                    DiagnosticoFinal = string.IsNullOrWhiteSpace(txtDiagnosticoFinal.Text) ? null : txtDiagnosticoFinal.Text.Trim(),
                    TecnicoAsignadoId = tecnicoId,
                    EstadoReparacionId = Convert.ToInt32(cmbEstado.SelectedValue),
                    CostoManoObra = costoManoObra,
                    TotalReparacion = totalReparacion,
                    FechaIngreso = dtpFechaIngreso.Value,
                    FechaEntrega = dtpFechaEntrega.Checked ? dtpFechaEntrega.Value : (DateTime?)null,
                    UsuarioCreacionId = SesionUsuario.UsuarioId
                };

                Reparacion resultado = _reparacionBL.Insert(nuevaReparacion);

                if (resultado != null)
                {
                    MessageBox.Show(
                        "La recepción de equipo ha sido registrada exitosamente.",
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
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al guardar la recepción: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}