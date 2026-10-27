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

                txtCodigo.Text = usuario.EmpleadoId.ToString();
                txtNombre.Text = usuario.Nombre;
                txtApellido.Text = usuario.Apellido;
                txtDUI.Text = usuario.DUI;
                txtTelefono.Text = usuario.Telefono;
                txtCorreo.Text = usuario.Correo;
                txtDireccion.Text = usuario.Direccion;

                dtpFechaContratacion.Value =
                    usuario.FechaContratacion.Date;

                if (empleado.Estado == "A")
                {
                    cmbEstado.SelectedIndex = 0;
                }
                else if (empleado.Estado == "I")
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
                    "Error al cargar los datos del usuario: " + ex.Message,
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
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtDUI.Text) ||
                    string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                    string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                    string.IsNullOrWhiteSpace(txtDireccion.Text) ||
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

                Usuario usuario = new Usuario
                {
                    EmpleadoId = _empleadoId,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    DUI = txtDUI.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    FechaContratacion = dtpFechaContratacion.Value.Date,
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
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
