
using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;

namespace TallerElectronico.Desktop
{
    public partial class FrmProducto : Form
    {
        private readonly ProductoBL _productoBL = new ProductoBL();
        private bool cargandoProductos = false;
        private readonly Timer _timerBusqueda = new Timer();

        public FrmProducto()
        {
            InitializeComponent();

            RegistrarEventos(this);

            dgvProducto.AutoGenerateColumns = false;
            dgvProducto.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProducto.MultiSelect = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvProducto.SelectionChanged += dgvProducto_SelectionChanged;

            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarProductos();

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
                    //dgvProducto.DataSource = _productoBL.Search(criterio);
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

            string nombre = Convert.ToString(dgvProducto.SelectedRows[0].Cells["ColumnName"].Value);
            string apellido = Convert.ToString(dgvProducto.SelectedRows[0].Cells["ColumnLastName"].Value);

            DialogResult confirm = MessageBox.Show($"¿Seguro que desea eliminar el producto {nombre} {apellido}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _productoBL.Delete(productoId.Value);
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
            // Reinicia el reloj a cada tecla. Solo cuando te detengas 300ms se consultará a la DAL
            _timerBusqueda.Stop();
            _timerBusqueda.Start();
        }

        private void TimerBusqueda_Tick(object sender, EventArgs e)
        {
            _timerBusqueda.Stop();
            CargarProductos(); // Llama a la DAL cuando el usuario pausó el tipeo
        }
    }
}
