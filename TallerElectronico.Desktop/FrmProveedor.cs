using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmProveedor : Form
    {
        private readonly ProveedorBL _proveedorBL = new ProveedorBL();
        private bool cargandoProveedores = false;
        private readonly Timer _timerBusqueda = new Timer();

        public FrmProveedor()
        {
            InitializeComponent();

            RegistrarEventos(this);

            dgvProveedor.AutoGenerateColumns = false;
            dgvProveedor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedor.MultiSelect = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvProveedor.SelectionChanged += dgvProveedor_SelectionChanged;

            // Configurar el temporizador (300 milisegundos de espera)
            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;

            if (txtBuscar != null)
            {
                txtBuscar.TextChanged += txtBuscar_TextChanged;
            }
            if (btnBuscar != null)
            {
                btnBuscar.Click += btnBuscar_Click;
            }
        }


        private void FrmProveedor_Load(object sender, EventArgs e)
        {
            CargarProveedores();

            // Garantiza que la deselección se aplique tras renderizar los controles
            BeginInvoke((MethodInvoker)delegate
            {
                RestablecerBotones();
            });
        }

        private void CargarProveedores()
        {
            try
            {
                cargandoProveedores = true;

                string criterio = txtBuscar != null ? txtBuscar.Text.Trim() : string.Empty;

                dgvProveedor.DataSource = null;

                if (string.IsNullOrWhiteSpace(criterio))
                {
                    dgvProveedor.DataSource = _proveedorBL.SelectAll();
                }
                else
                {
                    dgvProveedor.DataSource = _proveedorBL.Search(criterio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoProveedores = false;
                RestablecerBotones();
            }
        }

        private void dgvProveedor_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoProveedores) return;

            bool proveedorSeleccionado = dgvProveedor.SelectedRows.Count > 0;

            btnNuevo.Enabled = !proveedorSeleccionado;
            btnEditar.Enabled = proveedorSeleccionado;
            btnEliminar.Enabled = proveedorSeleccionado;
        }

        private void RegistrarEventos(Control control)
        {
            control.MouseDown += Control_MouseDown;

            foreach (Control hijo in control.Controls)
            {
                if (hijo == btnNuevo || hijo == btnEditar || hijo == btnEliminar || hijo == txtBuscar || hijo == btnBuscar)
                    continue;

                RegistrarEventos(hijo);
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;

            if (control == null || control == dgvProveedor)
                return;

            RestablecerBotones();
        }

        private void RestablecerBotones()
        {
            if (dgvProveedor != null)
            {
                dgvProveedor.ClearSelection();
                dgvProveedor.CurrentCell = null;
            }

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private int? ObtenerProveedorSeleccionado()
        {
            if (dgvProveedor.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un proveedor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            object valorId = dgvProveedor.SelectedRows[0].Cells["ColumnCode"].Value;

            if (valorId == null || valorId == DBNull.Value)
            {
                MessageBox.Show("No se pudo obtener el código del proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return Convert.ToInt32(valorId);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmCreateProveedor frm = new FrmCreateProveedor())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarProveedores();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? proveedorId = ObtenerProveedorSeleccionado();
            if (!proveedorId.HasValue) return;

            using (FrmEditProveedor frm = new FrmEditProveedor(proveedorId.Value))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarProveedores();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? proveedorId = ObtenerProveedorSeleccionado();
            if (!proveedorId.HasValue) return;

            string nombre = Convert.ToString(dgvProveedor.SelectedRows[0].Cells["ColumnName"].Value);

            DialogResult confirm = MessageBox.Show($"¿Seguro que desea eliminar al proveedor {nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _proveedorBL.Delete(proveedorId.Value);
                MessageBox.Show("El proveedor se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Reinicia el reloj a cada tecla. Solo cuando te detengas 300ms se consultará a la DAL
            _timerBusqueda.Stop();
            _timerBusqueda.Start();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _timerBusqueda.Stop();
            CargarProveedores();
        }
        private void TimerBusqueda_Tick(object sender, EventArgs e)
        {
            _timerBusqueda.Stop();
            CargarProveedores(); // Llama a la DAL cuando el usuario pausó el tipeo
        }
    }
}