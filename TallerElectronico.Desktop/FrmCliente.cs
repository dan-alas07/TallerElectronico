using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmCliente : Form
    {
        private readonly ClienteBL _clienteBL = new ClienteBL();
        private bool cargandoClientes = false;
        private readonly Timer _timerBusqueda = new Timer();
        private readonly bool _esRecepcionista = false;

        public FrmCliente()
        {
            InitializeComponent();

            _esRecepcionista = SesionUsuario.RolNombre != null && SesionUsuario.RolNombre.Trim().Equals("Recepcionista", StringComparison.OrdinalIgnoreCase);
            RegistrarEventos(this);

            dgvCliente.AutoGenerateColumns = false;
            dgvCliente.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCliente.MultiSelect = false;

            AplicarPermisosRol();

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvCliente.SelectionChanged += dgvCliente_SelectionChanged;

            // Configurar el temporizador (300 milisegundos de espera)
            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;
        }

        private void AplicarPermisosRol()
        {
            if (_esRecepcionista)
            {
                btnEliminar.Visible = false;
            }
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            CargarClientes();

            // Garantiza que la deselección se aplique tras renderizar los controles
            BeginInvoke((MethodInvoker)delegate
            {
                RestablecerBotones();
            });
        }

        private void CargarClientes()
        {
            try
            {
                cargandoClientes = true;

                string criterio = txtBuscar != null ? txtBuscar.Text.Trim() : string.Empty;

                dgvCliente.DataSource = null;

                if (string.IsNullOrWhiteSpace(criterio))
                {
                    dgvCliente.DataSource = _clienteBL.SelectAll();
                }
                else
                {
                    dgvCliente.DataSource = _clienteBL.Search(criterio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los clientes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoClientes = false;
                RestablecerBotones();
            }
        }

        private void dgvCliente_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoClientes) return;

            bool clienteSeleccionado = dgvCliente.SelectedRows.Count > 0;

            btnNuevo.Enabled = !clienteSeleccionado;
            btnEditar.Enabled = clienteSeleccionado;
            btnEliminar.Enabled = clienteSeleccionado;
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

            if (control == null || control == dgvCliente)
                return;

            RestablecerBotones();
        }

        private void RestablecerBotones()
        {
            if (dgvCliente != null)
            {
                dgvCliente.ClearSelection();
                dgvCliente.CurrentCell = null;
            }

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private int? ObtenerClienteSeleccionado()
        {
            if (dgvCliente.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un cliente.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            object valorId = dgvCliente.SelectedRows[0].Cells["ColumnCode"].Value;

            if (valorId == null || valorId == DBNull.Value)
            {
                MessageBox.Show("No se pudo obtener el código del cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return Convert.ToInt32(valorId);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmCreateCliente frm = new FrmCreateCliente())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarClientes();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? clienteId = ObtenerClienteSeleccionado();
            if (!clienteId.HasValue) return;

            using (FrmEditCliente frm = new FrmEditCliente(clienteId.Value))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarClientes();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? clienteId = ObtenerClienteSeleccionado();
            if (!clienteId.HasValue) return;

            string nombre = Convert.ToString(dgvCliente.SelectedRows[0].Cells["ColumnName"].Value);
            string apellido = Convert.ToString(dgvCliente.SelectedRows[0].Cells["ColumnLastName"].Value);

            DialogResult confirm = MessageBox.Show($"¿Seguro que desea eliminar al cliente {nombre} {apellido}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _clienteBL.Delete(clienteId.Value);
                MessageBox.Show("El cliente se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el cliente: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            CargarClientes(); // Llama a la DAL cuando el usuario pausó el tipeo
        }
    }
}
