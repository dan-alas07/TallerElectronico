using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmEditDetalleReparacion : Form
    {
        private readonly DetalleReparacionBL _detalleReparacionBL = new DetalleReparacionBL();
        private readonly ReparacionBL _reparacionBL = new ReparacionBL();
        private readonly ProductoBL _productoBL = new ProductoBL();

        private readonly int _detalleReparacionId;
        private DetalleReparacionDTO _detalleActual;

        public FrmEditDetalleReparacion(int detalleReparacionId)
        {
            InitializeComponent();
            _detalleReparacionId = detalleReparacionId;
        }

        private void FrmEditDetalleReparacion_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarDetalleReparacion();

        }

        private void CargarCombos()
        {
            try
            {
                // 1. Reparaciones
                cmbReparacion.DisplayMember = "CodigoSeguimiento";
                cmbReparacion.ValueMember = "ReparacionId";
                cmbReparacion.DataSource = _reparacionBL.SelectAll();

                // 2. Productos / Repuestos
                cmbProducto.DisplayMember = "Nombre";
                cmbProducto.ValueMember = "ProductoId";
                cmbProducto.DataSource = _productoBL.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los catálogos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDetalleReparacion()
        {
            try
            {
                _detalleActual = _detalleReparacionBL.SelectById(_detalleReparacionId);

                if (_detalleActual == null)
                {
                    MessageBox.Show("No se encontró el detalle de reparación seleccionado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return;
                }

                txtCodigoDetalle.Text = _detalleActual.DetalleReparacionId.ToString();
                cmbReparacion.SelectedValue = _detalleActual.ReparacionId;
                cmbProducto.SelectedValue = _detalleActual.ProductoId;
                nudCantidad.Value = _detalleActual.CantidadUtilizada;
                txtPrecio.Text = _detalleActual.PrecioUnitarioHistorico.ToString("0.00");
                dtpFechaUso.Value = _detalleActual.FechaUso;

                CalcularSubtotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el detalle de la reparación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudCantidad_ValueChanged(object sender, EventArgs e)
        {
            CalcularSubtotal();
        }

        private void CalcularSubtotal()
        {
            decimal.TryParse(txtPrecio.Text.Trim(), out decimal precio);
            int cantidad = (int)nudCantidad.Value;

            if (cantidad > 0 && precio > 0)
            {
                decimal subtotal = cantidad * precio; // Corregida la multiplicación
                txtSubtotal.Text = subtotal.ToString("N2");
            }
            else
            {
                txtSubtotal.Text = "0.00";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int cantidadNueva = (int)nudCantidad.Value;

            if (cantidadNueva <= 0)
            {
                MessageBox.Show("La cantidad a utilizar debe ser mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var producto = _productoBL.SelectById(_detalleActual.ProductoId);
            if (producto == null)
            {
                MessageBox.Show("No se encontró la información del producto asociado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Stock en BD + lo que este detalle ya tenía reservado
            int stockMaximoPermitido = producto.CantidadStock + _detalleActual.CantidadUtilizada;

            if (cantidadNueva > stockMaximoPermitido)
            {
                MessageBox.Show($"Stock insuficiente. Solo dispone de un máximo de {stockMaximoPermitido} unidades " +
                                $"(Existencia en estante: {producto.CantidadStock}, ya asignadas a este detalle: {_detalleActual.CantidadUtilizada}).",
                                "Stock Insuficiente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show("¿Desea guardar los cambios realizados en este detalle de reparación?", "Confirmar Edición",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                decimal.TryParse(txtPrecio.Text.Trim(), out decimal precioHistorico);

                DetalleReparacion detalleModificado = new DetalleReparacion
                {
                    DetalleReparacionId = _detalleReparacionId,
                    ReparacionId = _detalleActual.ReparacionId,
                    ProductoId = _detalleActual.ProductoId,
                    CantidadUtilizada = cantidadNueva,
                    PrecioUnitarioHistorico = precioHistorico,
                    FechaUso = dtpFechaUso.Value,

                    UsuarioModificacionId = SesionUsuario.UsuarioId,
                    FechaModificacion = DateTime.Now
                };

                DetalleReparacion resultado = _detalleReparacionBL.Update(detalleModificado);

                if (resultado != null)
                {
                    MessageBox.Show("El detalle de la reparación ha sido actualizado correctamente.", "Éxito",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show("Ocurrió un error inesperado al actualizar el detalle: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}