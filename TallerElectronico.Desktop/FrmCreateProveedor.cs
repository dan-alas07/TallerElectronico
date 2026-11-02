using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmCreateProveedor : Form
    {
        private readonly ProveedorBL _proveedorBL = new ProveedorBL();

        public FrmCreateProveedor()
        {
            InitializeComponent();
        }

        private void FrmCreateProveedor_Load(object sender, EventArgs e)
        {
            cmbTipo.SelectedIndex = -1;
            cmbEstado.SelectedIndex = 0;
        }


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                cmbTipo.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show(
                    "Por favor, completa todos los campos obligatorios.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "¿Desea guardar este nuevo usuario?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                Proveedor proveedor = new Proveedor
                {
                    Nombre = txtNombre.Text.Trim(),
                    TipoProveedor = cmbTipo.SelectedIndex == 0 ? "PN" : "PJ",
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    DUI = string.IsNullOrWhiteSpace(txtDUI.Text) ? null : txtDUI.Text.Trim(),
                    NIT = string.IsNullOrWhiteSpace(txtNIT.Text) ? null : txtNIT.Text.Trim(),
                    NRC = string.IsNullOrWhiteSpace(txtNRC.Text) ? null : txtNRC.Text.Trim(),
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                Proveedor nuevoProveedor = _proveedorBL.Insert(proveedor);

                if (nuevoProveedor != null && nuevoProveedor.ProveedorId > 0)
                {
                    MessageBox.Show(
                        "El proveedor ha sido registrado correctamente.",
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
                MessageBox.Show("Ocurrió un error inesperado al crear el proveedor: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}