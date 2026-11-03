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
        }

        private void FrmEditEmpleado_Load(object sender, EventArgs e)
        {
            CargarDatosEmpleado();
        }


        private void CargarDatosEmpleado()
        {
            try
            {
                Empleado empleado = _empleadoBL.SelectById(_empleadoId);

                if (empleado == null)
                {
                    MessageBox.Show("No se encontró el empleado seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtCodigo.Text = empleado.EmpleadoId.ToString();
                txtNombre.Text = empleado.Nombre;
                txtApellido.Text = empleado.Apellido;
                mtxtDUI.Text = empleado.DUI;
                mtxtTelefono.Text = empleado.Telefono;
                txtCorreo.Text = empleado.Correo;
                txtDireccion.Text = empleado.Direccion;
                dtpFechaContratacion.Value = empleado.FechaContratacion;
                cmbEstado.SelectedIndex = (empleado.Estado == "A" || empleado.Estado == "Activo") ? 0 : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void panelCentral_Paint(object sender, PaintEventArgs e)
        {
            if (!mtxtTelefono.MaskFull && mtxtTelefono.Text.Trim() == "-")
                mtxtTelefono.SelectionStart = 0;

            if (!mtxtDUI.MaskFull && mtxtDUI.Text.Trim() == "-")
                mtxtDUI.SelectionStart = 0;
        }

        private void mtxtTelefono_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!mtxtTelefono.MaskFull) mtxtTelefono.Clear();
        }

        private void mtxtDUI_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            if (!mtxtDUI.MaskFull) mtxtDUI.Clear();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "¿Desea actualizar los datos de este empleado?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                Empleado empleado = new Empleado
                {
                    EmpleadoId = _empleadoId,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    DUI = mtxtDUI.Text.Trim(),
                    Telefono = mtxtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    FechaContratacion = dtpFechaContratacion.Value,
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                _empleadoBL.Update(empleado);

                MessageBox.Show("Los datos del empleado se actualizaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
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
                MessageBox.Show("Ocurrió un error inesperado al actualizar el empleado: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
