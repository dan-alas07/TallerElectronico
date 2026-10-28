
using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmEditProveedor : Form
    {
        private readonly ProveedorBL _proveedorBL = new ProveedorBL();
        private int _proveedorId;

        public FrmEditProveedor()
        {
            InitializeComponent();
        }

        public FrmEditProveedor(int proveedorId) : this()
        {
            _proveedorId = proveedorId;
            CargarDatosProveedor();
        }

        private void CargarDatosProveedor()
        {
            try
            {
                Proveedor proveedor = _proveedorBL.SelectById(_proveedorId);

                if (proveedor == null)
                {
                    MessageBox.Show(
                        "No se encontró el proveedor seleccionado.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtCodigo.Text = proveedor.ProveedorId.ToString();
                txtNombre.Text = proveedor.Nombre;
                cmbTipo.Text = proveedor.TipoProveedor;
                txtTelefono.Text = proveedor.Telefono;

                txtCorreo.Text = proveedor.Email;

                txtDireccion.Text = proveedor.Direccion;
                txtCorreo.Text = proveedor.DUI;
                txtNIT.Text = proveedor.NIT;
                txtNRC.Text = proveedor.NRC;

                if (proveedor.Estado == "A")
                {
                    cmbEstado.SelectedIndex = 0;
                }
                else if (proveedor.Estado == "I")
                {
                    cmbEstado.SelectedIndex = 1;
                }
                else
                {
                    cmbEstado.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los datos del proveedor: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(cmbTipo.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                    string.IsNullOrWhiteSpace(txtNIT.Text) ||
                    string.IsNullOrWhiteSpace(txtNRC.Text) ||
                    cmbEstado.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Completa todos los campos.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                Proveedor proveedor = new Proveedor
                {
                    ProveedorId = _proveedorId,
                    Nombre = txtNombre.Text.Trim(),
                    TipoProveedor = cmbTipo.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    DUI = txtCorreo.Text.Trim(),
                    NIT = txtNIT.Text.Trim(),
                    NRC = txtNRC.Text.Trim(),
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                _proveedorBL.Update(proveedor);

                MessageBox.Show(
                    "Los datos del proveedor se actualizaron correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron actualizar los datos del proveedor: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
