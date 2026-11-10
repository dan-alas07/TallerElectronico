using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmCreateProducto : Form
    {
        private readonly ProductoBL _productoBL = new ProductoBL();
        private readonly ProveedorBL _proveedorBL = new ProveedorBL();

        public FrmCreateProducto()
        {
            InitializeComponent();
        }

        private void FrmCreateProducto_Load(object sender, EventArgs e)
        {
            txtCodigo.ReadOnly = true;
            txtCodigoProducto.ReadOnly = true;

            txtCodigo.Text = "Automático";

            CargarDatosProducto();
            GenerarCodigoProducto();
        }

        private void CargarDatosProducto()
        {
            try
            {
                cmbProveedor.DataSource = _proveedorBL.SelectAll();
                cmbProveedor.DisplayMember = "Nombre";
                cmbProveedor.ValueMember = "ProveedorId";
                cmbProveedor.SelectedIndex = -1;

                cmbEstado.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos iniciales del producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarCodigoProducto()
        {
            try
            {
                // Llamada a la capa DAL
                txtCodigoProducto.Text = _productoBL.ObtenerSiguienteCodigo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el código del producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
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
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Ingresa el nombre del producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbProveedor.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un proveedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "¿Desea guardar este nuevo producto?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                int proveedorId = cmbProveedor.SelectedValue != null ? Convert.ToInt32(cmbProveedor.SelectedValue) : 0;
                decimal.TryParse(txtPrecioUnitario.Text.Trim(), out decimal precio);
                int.TryParse(nudCantidadStock.Value.ToString(), out int stock);

                Producto producto = new Producto
                {
                    Codigo = txtCodigoProducto.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim(),
                    CantidadStock = stock,
                    PrecioUnitario = precio,
                    ProveedorId = proveedorId,
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I",
                    UsuarioCreacionId = SesionUsuario.UsuarioId
                };

                Producto nuevoProducto = _productoBL.Insert(producto);

                if (nuevoProducto != null && nuevoProducto.ProductoId > 0)
                {
                    MessageBox.Show(
                        "El producto ha sido registrado correctamente.",
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
                MessageBox.Show("Ocurrió un error inesperado al crear el producto: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}