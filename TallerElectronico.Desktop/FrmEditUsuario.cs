
using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmEditUsuario : Form
    {
        private readonly UsuarioBL _usuarioBL = new UsuarioBL();
        private int _usuarioId;

        public FrmEditUsuario()
        {
            InitializeComponent();
        }

        public FrmEditUsuario(int usuarioId) : this()
        {
            _usuarioId = usuarioId;
            CargarDatosUsuario();
        }

        private void CargarDatosUsuario()
        {
            try
            {
                Usuario usuario = _usuarioBL.SelectById(_usuarioId);

                if (usuario == null)
                {
                    MessageBox.Show(
                        "No se encontró el usuario seleccionado.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtCodigo.Text = usuario.UsuarioId.ToString();
                txtNombre.Text = usuario.Nombre;
                txtClave.Text = usuario.Clave;

                // Código del empleado relacionado
                txtCodigoEmpleado.Text = usuario.EmpleadoId.ToString();

                // Nombre del rol relacionado
                cmbRol.Text = usuario.Rol != null
                    ? usuario.Rol.Nombre
                    : "";

                // Estado del usuario
                if (usuario.Estado == "A")
                {
                    cmbEstado.SelectedIndex = 0;
                }
                else if (usuario.Estado == "I")
                {
                    cmbEstado.SelectedIndex = 1;
                }
                else
                {
                    cmbEstado.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar los datos del usuario: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtClave.Text) ||
                    string.IsNullOrWhiteSpace(txtCodigoEmpleado.Text) ||
                    string.IsNullOrWhiteSpace(cmbRol.Text) ||
                    cmbEstado.SelectedIndex == -1)
                {
                    MessageBox.Show(
                        "Completa todos los campos.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                if (!int.TryParse(
                    txtCodigoEmpleado.Text.Trim(),
                    out int empleadoId))
                {
                    MessageBox.Show(
                        "El código del empleado no es válido.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    return;
                }

                Usuario usuario = new Usuario
                {
                    UsuarioId = _usuarioId,
                    EmpleadoId = empleadoId,
                    Nombre = txtNombre.Text.Trim(),
                    Clave = txtClave.Text.Trim(),
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                // IMPORTANTE:
                // UsuarioBL.Update debe recibir el objeto Usuario
                // y gestionar correctamente el rol seleccionado.
                _usuarioBL.Update(usuario);

                MessageBox.Show(
                    "Los datos del usuario se actualizaron correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron actualizar los datos del usuario: "
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
