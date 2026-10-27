using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmEditCliente : Form
    {
        private readonly ClienteBL _clienteBL = new ClienteBL();
        private int _clienteId;

        public FrmEditCliente()
        {
            InitializeComponent();
        }

        public FrmEditCliente(int clienteId) : this()
        {
            _clienteId = clienteId;
            CargarDatosCliente();
        }

        private void CargarDatosCliente()
        {
            try
            {
                Cliente cliente = _clienteBL.SelectById(_clienteId);

                if (cliente == null)
                {
                    MessageBox.Show(
                        "No se encontró el cliente seleccionado.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtCodigo.Text = cliente.ClienteId.ToString();
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtDUI.Text = cliente.DUI;
                txtTelefono.Text = cliente.Telefono;
                txtCorreo.Text = cliente.Correo;
                txtDireccion.Text = cliente.Direccion;

                dtpFechaContratacion.Value =
                    cliente.FechaContratacion.Date;

                if (cliente.Estado == "A")
                {
                    cmbEstado.SelectedIndex = 0;
                }
                else if (cliente.Estado == "I")
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
                    "Error al cargar los datos del cliente: " + ex.Message,
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

                Cliente cliente = new Cliente
                {
                    ClienteId = _clienteId,
                    Nombre = txtNombre.Text.Trim(),
                    Apellido = txtApellido.Text.Trim(),
                    DUI = txtDUI.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    FechaContratacion = dtpFechaContratacion.Value.Date,
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                _clienteBL.Update(cliente);

                MessageBox.Show(
                    "Los datos del cliente se actualizaron correctamente.",
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
                    "No se pudieron actualizar los datos del cliente: "
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
