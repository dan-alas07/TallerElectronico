using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmCreateCliente : Form
    {
        private readonly ClienteBL _clienteBL = new ClienteBL();

        public FrmCreateCliente()
        {
            InitializeComponent();
        }

        private void FrmCreateCliente_Load(object sender, EventArgs e)
        {
            cmbTipoDocumento.SelectedIndex = -1;
            cmbEstado.SelectedIndex = 0;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "¿Desea guardar este nuevo cliente?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                string tipoDoc = cmbTipoDocumento.SelectedItem?.ToString();

                string duiValor = null;
                string carnetValor = null;

                if (tipoDoc == "DUI")
                {
                    // Si no está la máscara completa, se envía null a la BL
                    duiValor = string.IsNullOrWhiteSpace(mtxtDUI.Text) || !mtxtDUI.MaskCompleted ? null : mtxtDUI.Text.Trim();
                }
                else if (tipoDoc == "CarnetExtranjero")
                {
                    carnetValor = string.IsNullOrWhiteSpace(txtCarnet.Text) ? null : txtCarnet.Text.Trim();
                }

                Cliente cliente = new Cliente
                {
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    Telefono = mtxtTelefono.Text.Trim(),
                    Correo = string.IsNullOrWhiteSpace(txtCorreo.Text) ? null : txtCorreo.Text.Trim(),
                    TipoDocumento = tipoDoc,
                    DUI = duiValor,
                    CarnetExtranjero = carnetValor,
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                Cliente nuevoCliente = _clienteBL.Insert(cliente);

                if (nuevoCliente != null && nuevoCliente.ClienteId > 0)
                {
                    MessageBox.Show(
                        "El cliente ha sido registrado correctamente.",
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
                MessageBox.Show("Ocurrió un error inesperado al crear el cliente: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}