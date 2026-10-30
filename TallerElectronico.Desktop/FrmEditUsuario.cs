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

            // Usamos el evento Format para no depender de propiedades calculadas en el modelo
            cmbEmpleado.Format += cmbEmpleado_Format;
        }

        public FrmEditUsuario(int usuarioId) : this()
        {
            _usuarioId = usuarioId;
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

                // 2. Cargar ComboBox de Empleados
                cmbEmpleado.DataSource = _empleadoBL.SelectAll();
                cmbEmpleado.ValueMember = "EmpleadoId";

                // 3. Cargar ComboBox de Roles
                cmbRol.DataSource = _rolBL.SelectAll();
                cmbRol.DisplayMember = "Nombre";
                cmbRol.ValueMember = "RolId";

                // 4. Asignar datos del DTO a los controles
                txtCodigo.Text = usuario.Id.ToString();
                txtNombre.Text = usuario.Nombre;
                txtClave.Text = usuario.Clave;

                // 5. Seleccionar claves foráneas mediante SelectedValue
                if (usuario.EmpleadoId.HasValue)
                {
                    cmbEmpleado.SelectedValue = usuario.EmpleadoId.Value;
                }
                else
                {
                    cmbEmpleado.SelectedIndex = -1;
                }

                if (usuario.RolId.HasValue)
                {
                    cmbRol.SelectedValue = usuario.RolId.Value;
                }
                else
                {
                    cmbRol.SelectedIndex = -1;
                }

                // 6. Estado
                cmbEstado.SelectedIndex = (usuario.Estado == "A" || usuario.Estado == "Activo") ? 0 : 1;
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
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text) ||
                cmbEmpleado.SelectedValue == null ||
                cmbRol.SelectedValue == null ||
                cmbEstado.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, completa todos los campos requeridos.",
                    "Validación de formulario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                int empleadoId = Convert.ToInt32(cmbEmpleado.SelectedValue);
                int rolId = Convert.ToInt32(cmbRol.SelectedValue);

                Usuario usuario = new Usuario
                {
                    UsuarioId = _usuarioId,
                    EmpleadoId = empleadoId,
                    RolId = rolId,
                    Nombre = txtNombre.Text.Trim(),
                    Clave = txtClave.Text.Trim(),
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                // Enviar a la capa de negocio
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
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message,"Regla de negocio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado al actualizar el usuario: " + ex.Message,
                    "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}