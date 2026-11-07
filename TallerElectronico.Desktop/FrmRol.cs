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
    public partial class FrmRol : Form
    {
        private readonly RolBL _rolBL = new RolBL();
        private bool cargandoRoles = false;
        private readonly Timer _timerBusqueda = new Timer();

        public FrmRol()
        {
            InitializeComponent();

            RegistrarEventos(this);

            dgvRol.AutoGenerateColumns = false;
            dgvRol.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRol.MultiSelect = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvRol.SelectionChanged += dgvMarca_SelectionChanged;

            // Configurar el temporizador (300 milisegundos de espera)
            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;
        }

        private void FrmRol_Load(object sender, EventArgs e)
        {
            CargarRoles();
            BeginInvoke((MethodInvoker)delegate
            {
                RestablecerBotones();
            });
        }

        private void CargarRoles()
        {
            try
            {
                cargandoRoles = true;

                string criterio = txtBuscar != null ? txtBuscar.Text.Trim() : string.Empty;

                dgvRol.DataSource = null;

                if (string.IsNullOrWhiteSpace(criterio))
                {
                    dgvRol.DataSource = _rolBL.SelectAll();
                }
                else
                {
                    dgvRol.DataSource = _rolBL.Search(criterio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoRoles = false;
                RestablecerBotones();
            }
        }

        private void dgvMarca_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoRoles) return;

            bool rolSeleccionada = dgvRol.SelectedRows.Count > 0;

            btnNuevo.Enabled = !rolSeleccionada;
            btnEditar.Enabled = rolSeleccionada;
            btnEliminar.Enabled = rolSeleccionada;
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

            if (control == null || control == dgvRol)
                return;

            RestablecerBotones();
        }

        private void RestablecerBotones()
        {
            if (dgvRol != null)
            {
                dgvRol.ClearSelection();
                dgvRol.CurrentCell = null;
            }

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private int? ObtenerMarcaSeleccionada()
        {
            if (dgvRol.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un rol.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            object valorId = dgvRol.SelectedRows[0].Cells["ColumnCode"].Value;

            if (valorId == null || valorId == DBNull.Value)
            {
                MessageBox.Show("No se pudo obtener el código del rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return Convert.ToInt32(valorId);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmCreateRol frm = new FrmCreateRol())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarRoles();
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? rolId = ObtenerMarcaSeleccionada();
            if (!rolId.HasValue) return;

            using (FrmEditRol frm = new FrmEditRol(rolId.Value))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarRoles();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? rolId = ObtenerMarcaSeleccionada();
            if (!rolId.HasValue) return;

            string nombre = Convert.ToString(dgvRol.SelectedRows[0].Cells["ColumnName"].Value);

            DialogResult confirm = MessageBox.Show($"¿Seguro que desea eliminar el rol {nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _rolBL.Delete(rolId.Value);
                MessageBox.Show("El rol se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarRoles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el rol: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            CargarRoles(); // Llama a la DAL cuando el usuario pausó el tipeo
        }
    }
}
