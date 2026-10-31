using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;

namespace TallerElectronico.Desktop
{
    public partial class FrmUsuario : Form
    {
        private readonly UsuarioBL _usuarioBL = new UsuarioBL();
        private bool cargandoUsuarios = false;

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

                dgvUsuario.DataSource = null;
                dgvUsuario.DataSource = _usuarioBL.SelectAll();
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
                if (hijo == btnNuevo || hijo == btnEditar || hijo == btnEliminar)
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
    }
}