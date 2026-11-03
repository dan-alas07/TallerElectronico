using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmEditUsuario : Form
    {
        private readonly UsuarioBL _usuarioBL = new UsuarioBL();
        private readonly EmpleadoBL _empleadoBL = new EmpleadoBL();
        private readonly RolBL _rolBL = new RolBL();
        private readonly int _usuarioId;

        public FrmEditUsuario()
        {
            InitializeComponent();
            cmbEmpleado.Format += cmbEmpleado_Format;
        }

        public FrmEditUsuario(int usuarioId) : this()
        {
            _usuarioId = usuarioId;
        }

        private void FrmEditUsuario_Load(object sender, EventArgs e)
        {
            CargarDatosUsuario();
        }

        private void cmbEmpleado_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem is Empleado empleado)
            {
                e.Value = $"{empleado.Nombre} {empleado.Apellido}";
            }
        }

        private void CargarDatosUsuario()
        {
            try
            {
                UsuarioDTO usuario = _usuarioBL.SelectById(_usuarioId);

                if (usuario == null)
                {
                    MessageBox.Show("No se encontró el usuario seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                // Cargar ComboBox de Empleados
                cmbEmpleado.DataSource = _empleadoBL.SelectAll();
                cmbEmpleado.ValueMember = "EmpleadoId";

                // Cargar ComboBox de Roles
                cmbRol.DataSource = _rolBL.SelectAll();
                cmbRol.DisplayMember = "Nombre";
                cmbRol.ValueMember = "RolId";

                // Asignar datos a controles
                txtCodigo.Text = usuario.Id.ToString();
                txtNombre.Text = usuario.Nombre;
                txtClave.Text = usuario.Clave;

                // Seleccionar claves foráneas
                cmbEmpleado.SelectedValue = usuario.EmpleadoId.HasValue ? usuario.EmpleadoId.Value : -1;
                cmbRol.SelectedValue = usuario.RolId.HasValue ? usuario.RolId.Value : -1;

                // Estado
                cmbEstado.SelectedIndex = (usuario.Estado == "A" || usuario.Estado == "Activo") ? 0 : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("¿Desea actualizar los datos de este usuario?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                int empleadoId = cmbEmpleado.SelectedValue != null ? Convert.ToInt32(cmbEmpleado.SelectedValue) : 0;
                int rolId = cmbRol.SelectedValue != null ? Convert.ToInt32(cmbRol.SelectedValue) : 0;

                Usuario usuario = new Usuario
                {
                    UsuarioId = _usuarioId,
                    EmpleadoId = empleadoId,
                    RolId = rolId,
                    Nombre = txtNombre.Text.Trim(),
                    Clave = string.IsNullOrWhiteSpace(txtClave.Text) ? null : txtClave.Text.Trim(),
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                _usuarioBL.Update(usuario);

                MessageBox.Show(
                    "Los datos del usuario se actualizaron correctamente.",
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
                MessageBox.Show("Ocurrió un error inesperado al actualizar el usuario: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}