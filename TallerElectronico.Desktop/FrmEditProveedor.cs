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
                mtxtTelefono.Text = proveedor.Telefono;
                txtCorreo.Text = proveedor.Email;
                txtDireccion.Text = proveedor.Direccion;
                mtxtDUI.Text = proveedor.DUI ?? "";
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "¿Desea actualizar los datos de este proveedor?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                Proveedor proveedor = new Proveedor
                {
                    ProveedorId = _proveedorId,
                    Nombre = txtNombre.Text.Trim(),
                    TipoProveedor = cmbTipo.SelectedIndex == 0 ? "PN" : (cmbTipo.SelectedIndex == 1 ? "PJ" : ""),
                    Telefono = mtxtTelefono.Text.Trim(),
                    Email = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    DUI = string.IsNullOrWhiteSpace(mtxtDUI.Text) ? null : mtxtDUI.Text.Trim(),
                    NIT = string.IsNullOrWhiteSpace(txtNIT.Text) ? null : txtNIT.Text.Trim(),
                    NRC = string.IsNullOrWhiteSpace(txtNRC.Text) ? null : txtNRC.Text.Trim(),
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                _proveedorBL.Update(proveedor);

                MessageBox.Show("Los datos del proveedor se actualizaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
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
                MessageBox.Show("Ocurrió un error inesperado al actualizar el proveedor: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}