using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmCreateDetalleReparacion : Form
    {
        private readonly DetalleReparacionBL _detalleReparacionBL = new DetalleReparacionBL();
        private readonly ReparacionBL _reparacionBL = new ReparacionBL();
        private readonly ProductoBL _productoBL = new ProductoBL();

        private readonly int? _reparacionIdInicial;

        public FrmCreateDetalleReparacion()
        {
            InitializeComponent();
        }

        public FrmCreateDetalleReparacion(int reparacionId) : this()
        {
            _reparacionIdInicial = reparacionId;
        }

        private void FrmCreateDetalleReparacion_Load(object sender, EventArgs e)
        {
            dtpFechaUso.Value = DateTime.Now;

            CargarCatalogos();

            if (_reparacionIdInicial.HasValue)
            {
                cmbReparacion.SelectedValue = _reparacionIdInicial.Value;
                cmbReparacion.Enabled = false;
            }
        }

        private void CargarCatalogos()
        {
            try
            {
                // Cargar reparaciones
                cmbReparacion.DisplayMember = "CodigoSeguimiento";
                cmbReparacion.ValueMember = "ReparacionId";
                cmbReparacion.DataSource = _reparacionBL.SelectAll();
                cmbReparacion.SelectedIndex = -1;

                // Cargar productos / repuestos
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "ProductoId";
                cmbProducto.DataSource = _productoBL.SelectAll();
                cmbProducto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los catálogos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProducto.SelectedIndex == -1 || cmbProducto.SelectedItem == null)
            {
                txtPrecioUnitario.Text = "0.00";
                CalcularSubtotal();
                return;
            }

            try
            {
                if (cmbProducto.SelectedItem is Producto producto)
                {
                    txtPrecioUnitario.Text = producto.PrecioUnitario.ToString("N2");
                }
                else
                {
                    dynamic item = cmbProducto.SelectedItem;
                    decimal precio = Convert.ToDecimal(item.PrecioUnitario);
                    txtPrecioUnitario.Text = precio.ToString("N2");
                }

                CalcularSubtotal();
            }
            catch
            {
                txtPrecioUnitario.Text = "0.00";
                CalcularSubtotal();
            }
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void CalcularSubtotal()
        {
            decimal.TryParse(txtPrecioUnitario.Text.Trim(), out decimal precio);
            int cantidad = (int)nudCantidad.Value;

            if (cantidad > 0 && precio > 0)
            {
                decimal subtotal = cantidad * precio;
                txtSubtotal.Text = subtotal.ToString("N2"); // Para mostrar o visualizar unicamente
            }
            else
            {
                txtSubtotal.Text = "0.00";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("¿Desea agregar este repuesto o insumo al detalle de la reparación?",
                "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                int reparacionId = cmbReparacion.SelectedValue != null ? Convert.ToInt32(cmbReparacion.SelectedValue) : 0;
                int productoId = cmbProducto.SelectedValue != null ? Convert.ToInt32(cmbProducto.SelectedValue) : 0;
                int cantidad = (int)nudCantidad.Value;
                decimal.TryParse(txtPrecioUnitario.Text.Trim(), out decimal precioUnitario);
                DateTime fechaUso = dtpFechaUso.Value;

                DetalleReparacion detalle = new DetalleReparacion
                {
                    ReparacionId = reparacionId,
                    ProductoId = productoId,
                    CantidadUtilizada = cantidad,
                    PrecioUnitarioHistorico = precioUnitario,
                    FechaUso = fechaUso,
                    UsuarioCreacionId = SesionUsuario.UsuarioId,
                    FechaModificacion = null,
                    UsuarioModificacionId = null
                };

                DetalleReparacion nuevoDetalle = _detalleReparacionBL.Insert(detalle);

                if (nuevoDetalle != null && nuevoDetalle.DetalleReparacionId > 0)
                {
                    MessageBox.Show(
                        "El repuesto o insumo ha sido registrado exitosamente.",
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
                MessageBox.Show("Ocurrió un error inesperado al registrar el detalle: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}