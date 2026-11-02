using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmEditProveedor : Form
    {
        private readonly ProveedorBL _proveedorBL = new ProveedorBL();
        private readonly int _proveedorId;

        public FrmEditProveedor()
        {
            InitializeComponent();
        }

        public FrmEditProveedor(int proveedorId) : this()
        {
            _proveedorId = proveedorId;
        }

        private void FrmEditProveedor_Load(object sender, EventArgs e)
        {
            CargarDatosProveedor();
        }

        private void CargarDatosProveedor()
        {
            try
            {
                Proveedor proveedor = _proveedorBL.SelectById(_proveedorId);

                if (proveedor == null)
                {
                    MessageBox.Show("No se encontró el proveedor seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtCodigo.Text = proveedor.ProveedorId.ToString();
                txtNombre.Text = proveedor.Nombre;
                cmbTipo.SelectedIndex = (proveedor.TipoProveedor == "PN" || proveedor.TipoProveedor == "Persona Natural") ? 0 : 1;
                txtTelefono.Text = proveedor.Telefono;
                txtCorreo.Text = proveedor.Email;
                txtDireccion.Text = proveedor.Direccion;
                txtDUI.Text = proveedor.DUI ?? "";
                txtNIT.Text = proveedor.NIT ?? "";
                txtNRC.Text = proveedor.NRC ?? "";

                cmbEstado.SelectedIndex = (proveedor.Estado == "A" || proveedor.Estado == "Activo") ? 0 : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(cmbTipo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, completa todos los campos requeridos.", "Validación de formulario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Proveedor proveedor = new Proveedor
                {
                    ProveedorId = _proveedorId,
                    Nombre = txtNombre.Text.Trim(),
                    TipoProveedor = cmbTipo.SelectedIndex == 0 ? "PN" : "PJ",
                    Telefono = txtTelefono.Text.Trim(),
                    Email = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    DUI = txtDUI.Text.Trim(),
                    NIT = txtNIT.Text.Trim(),
                    NRC = txtNRC.Text.Trim(),
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                _proveedorBL.Update(proveedor);

                MessageBox.Show("Los datos del proveedor se actualizaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Regla de negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al actualizar el proveedor: " + ex.Message, "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}