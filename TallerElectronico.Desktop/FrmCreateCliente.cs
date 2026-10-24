using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmCreateCliente : Form
    {
        private readonly ClienteBL _clienteBL = new ClienteBL();

        public FrmCreateCliente()
        {
            InitializeComponent();
            cboEstado.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Nombre = txtNombre.Text,
                Apellido = txtApellido.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text,
                TipoDocumento = txtTipoDocumento.Text,
                DUI = txtDUI.Text,
                CarnetExtranjero = txtCarnet.Text,
                FechaRegistro = dtpFechaContratacion.Value.Date
            };

            btnGuardar.Enabled = false;
            Cursor = Cursors.WaitCursor;

            try
            {
                _clienteBL.Insert(cliente);

                MessageBox.Show("Cliente guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Datos inválidos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado en el sistema:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                btnGuardar.Enabled = true;
            }
        }
    }
}