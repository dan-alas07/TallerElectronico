using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmUsuario : Form
    {
        private readonly UsuarioBL _usuarioBL = new UsuarioBL();
        private bool cargandoUsuarios = false;

        private readonly Timer _timerBusqueda = new Timer();

        public FrmUsuario()
        {
            InitializeComponent();

            RegistrarEventos(this);

            dgvUsuario.AutoGenerateColumns = false;
            dgvUsuario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuario.MultiSelect = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvUsuario.SelectionChanged += dgvUsuarios_SelectionChanged;

            // Configurar el temporizador (300 milisegundos de espera)
            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;

        }


        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            CargarUsuarios();

            // Garantiza que la deselección se aplique tras renderizar los controles
            BeginInvoke((MethodInvoker)delegate
            {
                RestablecerBotones();
            });
        }

        private void CargarUsuarios()
        {
            try
            {
                cargandoUsuarios = true;

                string criterio = txtBuscar != null ? txtBuscar.Text.Trim() : string.Empty;

                // Forzar refresco completo del DataGridView
                dgvUsuario.DataSource = null;

                // Si la caja de texto tiene contenido consulta mediante la BL el método Search, sino trae SelectAll()
                if (string.IsNullOrWhiteSpace(criterio))
                {
                    dgvUsuario.DataSource = _usuarioBL.SelectAll();
                }
                else
                {
                    dgvUsuario.DataSource = _usuarioBL.Search(criterio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoUsuarios = false;
                RestablecerBotones();
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoUsuarios) return;

            bool usuarioSeleccionado = dgvUsuario.SelectedRows.Count > 0;

            btnNuevo.Enabled = !usuarioSeleccionado;
            btnEditar.Enabled = usuarioSeleccionado;
            btnEliminar.Enabled = usuarioSeleccionado;
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

            if (control == null || control == dgvUsuario)
                return;

            RestablecerBotones();
        }

        private void RestablecerBotones()
        {
            if (dgvUsuario != null)
            {
                dgvUsuario.ClearSelection();
                dgvUsuario.CurrentCell = null;
            }

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private int? ObtenerUsuarioSeleccionado()
        {
            if (dgvUsuario.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuario.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            object valorId = dgvUsuario.SelectedRows[0].Cells["ColumnCode"].Value;

            if (valorId == null || valorId == DBNull.Value)
            {
                MessageBox.Show("No se pudo obtener el código del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return Convert.ToInt32(valorId);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmCreateUsuario frm = new FrmCreateUsuario())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? usuarioId = ObtenerUsuarioSeleccionado();
            if (!usuarioId.HasValue) return;

            using (FrmEditUsuario frm = new FrmEditUsuario(usuarioId.Value))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarUsuarios();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? usuarioId = ObtenerUsuarioSeleccionado();
            if (!usuarioId.HasValue) return;

            string nombre = Convert.ToString(dgvUsuario.SelectedRows[0].Cells["ColumnName"].Value);

            DialogResult confirm = MessageBox.Show($"¿Seguro que desea eliminar al usuario {nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _usuarioBL.Delete(usuarioId.Value);
                MessageBox.Show("El usuario se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            CargarUsuarios(); // Llama a la DAL cuando el usuario pausó el tipeo
        }
    }
}