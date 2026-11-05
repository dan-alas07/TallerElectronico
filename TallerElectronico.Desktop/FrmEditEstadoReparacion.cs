using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmEditEstadoReparacion : Form
    {
        private readonly EstadoReparacionBL _estadoReparacionBL = new EstadoReparacionBL();
        private int _estadoReparacionId;

        public FrmEditEstadoReparacion()
        {
            InitializeComponent();
        }

        public FrmEditEstadoReparacion(int estadoReparacionId) : this()
        {
            _estadoReparacionId = estadoReparacionId;
        }

        private void FrmEditMarca_Load(object sender, EventArgs e)
        {
            CargarDatosMarca();
        }

        private void CargarDatosMarca()
        {
            try
            {
                EstadoReparacion estadoReparacion = _estadoReparacionBL.SelectById(_estadoReparacionId);

                if (estadoReparacion == null)
                {
                    MessageBox.Show("No se encontró el estado de reparación seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtCodigo.Text = estadoReparacion.EstadoReparacionId.ToString();
                txtNombre.Text = estadoReparacion.Nombre;
                cmbEstado.SelectedIndex = (estadoReparacion.Estado == "A" || estadoReparacion.Estado == "Activo") ? 0 : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del estado reparación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "¿Desea actualizar los datos de este estado reparación?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                EstadoReparacion marca = new EstadoReparacion
                {
                    EstadoReparacionId = _estadoReparacionId,
                    Nombre = txtNombre.Text.Trim(),
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                _estadoReparacionBL.Update(marca);

                MessageBox.Show("Los datos del estado reparación se actualizaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Ocurrió un error inesperado al actualizar la marca: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
