using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmCreateEmpleado : Form
    {
        private readonly EmpleadoBL _empleadoBL = new EmpleadoBL();
        private bool _guardado = false;

        public FrmCreateEmpleado()
        {
            InitializeComponent();

            cboEstado.SelectedIndex = 0;
            cboEstado.Enabled = false;

            btnGuardar.Click -= btnGuardar_Click;
            btnGuardar.Click += btnGuardar_Click;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (_guardado) return;

            Empleado empleado = new Empleado
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                DUI = txtDUI.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                Direccion = txtDireccion.Text,
                FechaContratacion = dtpFechaContratacion.Value.Date,
                Estado = "A"
            };

            btnGuardar.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                _empleadoBL.Insert(empleado);
                _guardado = true;

                MessageBox.Show("Empleado guardado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
            }
            catch (ArgumentException ex)        
            {
                MessageBox.Show(ex.Message, "Datos inválidos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)  
            {
                MessageBox.Show(ex.Message, "No se pudo guardar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)       
            {
                MessageBox.Show("No se pudo guardar el empleado:\n" + ex.GetBaseException().Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                if (!_guardado) btnGuardar.Enabled = true;
            }
        }
    }
}