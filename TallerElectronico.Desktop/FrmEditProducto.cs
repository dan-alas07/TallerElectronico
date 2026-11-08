using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmEditProducto : Form
    {
        private readonly ProductoBL _productoBL = new ProductoBL();
        private readonly ProveedorBL _proveedorBL = new ProveedorBL();
        private readonly int _productoId;

        public FrmEditProducto()
        {
            InitializeComponent();
        }

        public FrmEditProducto(int productoId) : this()
        {
            _productoId = productoId;
        }

        private void FrmEditProducto_Load(object sender, EventArgs e)
        {
            CargarDatosProducto();
        }

        private void CargarDatosProducto()
        {
            try
            {
                // Cargar DTO del producto a editar mediante su ID
                ProductoDTO producto = _productoBL.SelectById(_productoId);

                if (producto == null)
                {
                    MessageBox.Show("No se encontró el producto seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                // Cargar ComboBox de Proveedores
                cmbProveedor.DataSource = _proveedorBL.SelectAll();
                cmbProveedor.DisplayMember = "Nombre";
                cmbProveedor.ValueMember = "ProveedorId";

                // Asignar datos a los controles
                txtCodigo.Text = producto.ProductoId.ToString();
                txtCodigoProducto.Text = producto.Codigo;
                txtNombre.Text = producto.Nombre;
                txtDescripcion.Text = producto.Descripcion;

                // Asignar valores numéricos
                nudCantidadStock.Value = producto.CantidadStock;
                txtPrecioUnitario.Text = producto.PrecioUnitario.ToString("F2");

                // Seleccionar clave foránea de Proveedor
                cmbProveedor.SelectedValue = producto.ProveedorId;

                // Estado (A = Activo, I = Inactivo)
                cmbEstado.SelectedIndex = (producto.Estado == "A" || producto.Estado == "Activo") ? 0 : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos, tecla de borrado (Backspace) y un punto decimal
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
            // Validación de campo requerido de precio
            if (string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
            {
                MessageBox.Show("Debe ingresar el precio unitario del producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioUnitario.Focus();
                return;
            }

            if (!decimal.TryParse(txtPrecioUnitario.Text.Trim(), out decimal precio) || precio <= 0)
            {
                MessageBox.Show("Ingrese un precio unitario válido mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrecioUnitario.Focus();
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "¿Desea actualizar los datos de este producto?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                int proveedorId = cmbProveedor.SelectedValue != null ? Convert.ToInt32(cmbProveedor.SelectedValue) : 0;
                int stock = Convert.ToInt32(nudCantidadStock.Value);

                Producto producto = new Producto
                {
                    ProductoId = _productoId,
                    Codigo = txtCodigoProducto.Text.Trim(),
                    Nombre = txtNombre.Text.Trim(),
                    Descripcion = string.IsNullOrWhiteSpace(txtDescripcion.Text) ? null : txtDescripcion.Text.Trim(),
                    CantidadStock = stock,
                    PrecioUnitario = precio,
                    ProveedorId = proveedorId,
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I",

                    // Se asigna el ID del usuario que realiza la modificación
                    UsuarioModificacionId = SesionUsuario.UsuarioId
                };

                // Llamada directa al método Update de la BL
                _productoBL.Update(producto);

                MessageBox.Show(
                    "Los datos del producto se actualizaron correctamente.",
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
                MessageBox.Show("Ocurrió un error inesperado al actualizar el producto: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}