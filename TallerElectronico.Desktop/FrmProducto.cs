using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmProducto : Form
    {
        private readonly ProductoBL _productoBL = new ProductoBL();
        private bool cargandoProductos = false;
        private readonly Timer _timerBusqueda = new Timer();
        private readonly bool _esTecnico = false;

        public FrmProducto()
        {
            InitializeComponent();

            RegistrarEventos(this);

            // Validacion de Rol 
            _esTecnico = SesionUsuario.RolNombre != null && SesionUsuario.RolNombre.Trim().Equals("Tecnico", StringComparison.OrdinalIgnoreCase);

            dgvProducto.AutoGenerateColumns = false;
            dgvProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducto.MultiSelect = false;

            // Mapeo explicito de DataPropertyName a ProductoDTO para evitar que se vacie
            MapearColumnasDTO();

            AplicarPermisosRol();

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvProducto.SelectionChanged += dgvProducto_SelectionChanged;

            // Configurar el temporizador (300 milisegundos de espera)
            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;
        }

        private void AplicarPermisosRol()
        {
            if (_esTecnico)
            {
                if (flpBotonesProductos != null)
                {
                    flpBotonesProductos.Visible = false;
                }
            }
        }

        private void MapearColumnasDTO()
        {
            // Ajusta los nombres de las columnas en tu DataGridView si difieren
            if (dgvProducto.Columns["ColumnCode"] != null)
                dgvProducto.Columns["ColumnCode"].DataPropertyName = nameof(ProductoDTO.ProductoId);

            if (dgvProducto.Columns["ColumnCodigo"] != null)
                dgvProducto.Columns["ColumnCodigo"].DataPropertyName = nameof(ProductoDTO.Codigo);

            if (dgvProducto.Columns["ColumnNombre"] != null)
                dgvProducto.Columns["ColumnNombre"].DataPropertyName = nameof(ProductoDTO.Nombre);

            if (dgvProducto.Columns["ColumnDescripcion"] != null)
                dgvProducto.Columns["ColumnDescripcion"].DataPropertyName = nameof(ProductoDTO.Descripcion);

            if (dgvProducto.Columns["ColumnStock"] != null)
                dgvProducto.Columns["ColumnStock"].DataPropertyName = nameof(ProductoDTO.CantidadStock);

            if (dgvProducto.Columns["ColumnPrecio"] != null)
                dgvProducto.Columns["ColumnPrecio"].DataPropertyName = nameof(ProductoDTO.PrecioUnitario);

            if (dgvProducto.Columns["ColumnEstado"] != null)
                dgvProducto.Columns["ColumnEstado"].DataPropertyName = nameof(ProductoDTO.Estado);

            if (dgvProducto.Columns["ColumnProveedor"] != null)
                dgvProducto.Columns["ColumnProveedor"].DataPropertyName = nameof(ProductoDTO.ProveedorNombre);

            if (dgvProducto.Columns["ColumnUsuario"] != null)
                dgvProducto.Columns["ColumnUsuario"].DataPropertyName = nameof(ProductoDTO.UsuarioCreacionNombre);
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarProductos();

            // Garantiza que la deselección se aplique tras renderizar los controles
            BeginInvoke((MethodInvoker)delegate
            {
                RestablecerBotones();
            });
        }

        private void CargarProductos()
        {
            try
            {
                cargandoProductos = true;

                string criterio = txtBuscar != null ? txtBuscar.Text.Trim() : string.Empty;

                dgvProducto.DataSource = null;

                if (string.IsNullOrWhiteSpace(criterio))
                {
                    dgvProducto.DataSource = _productoBL.SelectAll();
                }
                else
                {
                    dgvProducto.DataSource = _productoBL.Search(criterio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los productos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoProductos = false;
                RestablecerBotones();
            }
        }

        private void dgvProducto_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoProductos) return;

            bool productoSeleccionado = dgvProducto.SelectedRows.Count > 0;

            btnNuevo.Enabled = !productoSeleccionado;
            btnEditar.Enabled = productoSeleccionado;
            btnEliminar.Enabled = productoSeleccionado;
        }

        private void RegistrarEventos(Control control)
        {
            control.MouseDown += Control_MouseDown;

            foreach (Control hijo in control.Controls)
            {
                if (hijo == btnNuevo || hijo == btnEditar || hijo == btnEliminar || hijo == txtBuscar)
                    continue;

                RegistrarEventos(hijo);
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;

            if (control == null || control == dgvProducto)
                return;

            RestablecerBotones();
        }

        private void RestablecerBotones()
        {
            if (dgvProducto != null)
            {
                dgvProducto.ClearSelection();
                dgvProducto.CurrentCell = null;
            }

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private int? ObtenerProductoSeleccionado()
        {
            if (dgvProducto.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un producto.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            object valorId = dgvProducto.SelectedRows[0].Cells["ColumnCode"].Value;

            if (valorId == null || valorId == DBNull.Value)
            {
                MessageBox.Show("No se pudo obtener el código del producto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return Convert.ToInt32(valorId);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmCreateProducto frm = new FrmCreateProducto())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarProductos();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? productoId = ObtenerProductoSeleccionado();
            if (!productoId.HasValue) return;

            using (FrmEditProducto frm = new FrmEditProducto(productoId.Value))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarProductos();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? productoId = ObtenerProductoSeleccionado();
            if (!productoId.HasValue) return;

            string nombre = Convert.ToString(dgvProducto.SelectedRows[0].Cells["ColumnNombre"].Value);

            DialogResult confirm = MessageBox.Show($"¿Seguro que desea eliminar el producto {nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                // Reemplazar con el ID de usuario autenticado si manejas sesión (ej: SesionUsuario.UsuarioId)
                int usuarioActualId = 1;

                _productoBL.Delete(productoId.Value, usuarioActualId);
                MessageBox.Show("El producto se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            _timerBusqueda.Stop();
            _timerBusqueda.Start();
        }

        private void TimerBusqueda_Tick(object sender, EventArgs e)
        {
            _timerBusqueda.Stop();
            CargarProductos();
        }
    }
}