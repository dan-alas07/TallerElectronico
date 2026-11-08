using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmEditCliente : Form
    {
        private readonly ClienteBL _clienteBL = new ClienteBL();
        private readonly int _clienteId;

        public FrmEditCliente()
        {
            InitializeComponent();
        }

        public FrmEditCliente(int clienteId) : this()
        {
            _clienteId = clienteId;
        }

        private void FrmEditCliente_Load(object sender, EventArgs e)
        {
            CargarDatosCliente();
        }

        private void panelCentral_Paint(object sender, PaintEventArgs e)
        {
            if (!mtxtTelefono.MaskFull && mtxtTelefono.Text.Trim() == "-")
                mtxtTelefono.SelectionStart = 0;

            if (!mtxtDUI.MaskFull && mtxtDUI.Text.Trim() == "-")
                mtxtDUI.SelectionStart = 0;
        }

        private void mtxtTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!mtxtTelefono.MaskFull) mtxtTelefono.Clear();
        }

        private void mtxtDUI_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!mtxtDUI.MaskFull) mtxtDUI.Clear();
        }

        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seleccion = cmbTipoDocumento.SelectedItem?.ToString();

            if (seleccion == "DUI")
            {
                mtxtDUI.Enabled = true;
                txtCarnet.Enabled = false;
                txtCarnet.Clear();
            }
            else if (seleccion == "CarnetExtranjero")
            {
                txtCarnet.Enabled = true;
                mtxtDUI.Enabled = false;
                mtxtDUI.Clear();
            }
            else
            {
                mtxtDUI.Enabled = false;
                txtCarnet.Enabled = false;
                mtxtDUI.Clear();
                txtCarnet.Clear();
            }
        }

        private void CargarDatosCliente()
        {
            try
            {
                Cliente cliente = _clienteBL.SelectById(_clienteId);

                if (cliente == null)
                {
                    MessageBox.Show(
                        "No se encontró el cliente seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning
                    );

                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtCodigo.Text = cliente.ClienteId.ToString();
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                mtxtTelefono.Text = cliente.Telefono;
                txtCorreo.Text = cliente.Correo;
                dtpFechaRegistro.Value = cliente.FechaRegistro;
                cmbTipoDocumento.SelectedItem = cliente.TipoDocumento;

                if (cliente.TipoDocumento == "DUI")
                {
                    mtxtDUI.Text = cliente.DUI;
                }
                else if (cliente.TipoDocumento == "CarnetExtranjero")
                {
                    txtCarnet.Text = cliente.CarnetExtranjero;
                }

                cmbEstado.SelectedIndex = (cliente.Estado == "A") ? 0 : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los datos del cliente: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                );

                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("¿Desea actualizar los datos de este cliente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                string tipoDoc = cmbTipoDocumento.SelectedItem?.ToString();

                string duiValor = null;
                string carnetValor = null;

                if (tipoDoc == "DUI")
                {
                    duiValor = string.IsNullOrWhiteSpace(mtxtDUI.Text) || !mtxtDUI.MaskCompleted ? null : mtxtDUI.Text.Trim();
                }
                else if (tipoDoc == "CarnetExtranjero")
                {
                    carnetValor = string.IsNullOrWhiteSpace(txtCarnet.Text) ? null : txtCarnet.Text.Trim();
                }

                Cliente cliente = new Cliente
                {
                    ClienteId = _clienteId,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Telefono = mtxtTelefono.Text.Trim(),
                    Correo = string.IsNullOrWhiteSpace(txtCorreo.Text) ? null : txtCorreo.Text.Trim(),
                    TipoDocumento = tipoDoc,
                    DUI = duiValor,
                    CarnetExtranjero = carnetValor,
                    FechaRegistro = dtpFechaRegistro.Value,
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                _clienteBL.Update(cliente);

                MessageBox.Show(
                    "Los datos del cliente se actualizaron correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
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
                MessageBox.Show("Ocurrió un error inesperado al actualizar el cliente: " + ex.Message,
                    "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
