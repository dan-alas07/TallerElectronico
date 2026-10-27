using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmEditEmpleado : Form
    {
        private readonly EmpleadoBL _empleadoBL = new EmpleadoBL();
        private int _empleadoId;

        public FrmEditEmpleado()
        {
            InitializeComponent();
        }

        public FrmEditEmpleado(int empleadoId) : this()
        {
            _empleadoId = empleadoId;
            CargarDatosEmpleado();
        }

        private void CargarDatosEmpleado()
        {
            try
            {
                Empleado empleado = _empleadoBL.SelectById(_empleadoId);

                if (empleado == null)
                {
                    MessageBox.Show(
                        "No se encontró el empleado seleccionado.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtCodigo.Text = empleado.EmpleadoId.ToString();
                txtNombre.Text = empleado.Nombre;
                txtApellido.Text = empleado.Apellido;
                txtDUI.Text = empleado.DUI;
                txtTelefono.Text = empleado.Telefono;
                txtCorreo.Text = empleado.Correo;
                txtDireccion.Text = empleado.Direccion;

                dtpFechaContratacion.Value =
                    empleado.FechaContratacion.Date;

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
                    "Error al cargar los datos del empleado: " + ex.Message,
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

                Empleado empleado = new Empleado
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

                _empleadoBL.Update(empleado);

                MessageBox.Show(
                    "Los datos del empleado se actualizaron correctamente.",
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
                    "No se pudieron actualizar los datos del empleado: "
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
