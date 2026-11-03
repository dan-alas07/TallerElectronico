using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmCreateEmpleado : Form
    {
        private readonly EmpleadoBL _empleadoBL = new EmpleadoBL();

        public FrmCreateEmpleado()
        {
            InitializeComponent();
        }

        private void FrmCreateEmpleado_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
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
            DialogResult confirm = MessageBox.Show("¿Desea guardar este nuevo empleado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                Empleado empleado = new Empleado
                { 
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    DUI = mtxtDUI.Text.Trim(),
                    Telefono = mtxtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    FechaContratacion = dtpFechaContratacion.Value,
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                Empleado nuevoEmpleado = _empleadoBL.Insert(empleado);

                if (nuevoEmpleado != null && nuevoEmpleado.EmpleadoId > 0)
                {
                    MessageBox.Show(
                        "El empleado ha sido registrado correctamente.",
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
                MessageBox.Show("Ocurrió un error inesperado al crear el empleado: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}