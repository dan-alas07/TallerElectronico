using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmCreateUsuario : Form
    {
        private readonly UsuarioBL _usuarioBL = new UsuarioBL();
        private readonly EmpleadoBL _empleadoBL = new EmpleadoBL();
        private readonly RolBL _rolBL = new RolBL();

        public FrmCreateUsuario()
        {
            InitializeComponent();
            cmbEmpleado.Format += cmbEmpleado_Format;
        }

        private void FrmCreateUsuario_Load(object sender, EventArgs e)
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

        private void CargarDatosUsuario ()
        {
            try
            {
                // Limpiar DisplayMember para obligarlo a pasar por cmbEmpleado_Format
                cmbEmpleado.DisplayMember = null;
                cmbEmpleado.DataSource = _empleadoBL.SelectAll();
                cmbEmpleado.ValueMember = "EmpleadoId";
                cmbEmpleado.SelectedIndex = -1;

                cmbRol.DataSource = _rolBL.SelectAll();
                cmbRol.DisplayMember = "Nombre";
                cmbRol.ValueMember = "RolId";
                cmbRol.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtClave.Text) ||
                cmbEmpleado.SelectedValue == null ||
                cmbRol.SelectedValue == null)
            {
                MessageBox.Show(
                    "Por favor, completa todos los campos obligatorios.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "¿Desea guardar este nuevo usuario?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                Usuario usuario = new Usuario
                {
                    Nombre = txtNombre.Text.Trim(),
                    Clave = txtClave.Text.Trim(), // La BL se encarga del Hash
                    EmpleadoId = Convert.ToInt32(cmbEmpleado.SelectedValue),
                    RolId = Convert.ToInt32(cmbRol.SelectedValue)
                };

                Usuario nuevoUsuario = _usuarioBL.Insert(usuario);

                if (nuevoUsuario != null && nuevoUsuario.UsuarioId > 0)
                {
                    MessageBox.Show(
                        "El usuario ha sido registrado correctamente.",
                        "Éxito",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
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
                MessageBox.Show("Ocurrió un error inesperado al crear el usuario: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}