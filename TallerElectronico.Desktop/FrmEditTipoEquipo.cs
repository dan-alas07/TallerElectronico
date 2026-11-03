using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmEditTipoEquipo : Form
    {
        private readonly TipoEquipoBL _tipoEquipoBL = new TipoEquipoBL();
        private int _tipoEquipoId;

        public FrmEditTipoEquipo()
        {
            InitializeComponent();
        }

        public FrmEditTipoEquipo(int tipoEquipoId) : this()
        {
            _tipoEquipoId = tipoEquipoId;
        }

        private void FrmEditTipoEquipo_Load(object sender, EventArgs e)
        {
            CargarDatosTipoEquipo();
        }

        private void CargarDatosTipoEquipo()
        {
            try
            {
                TipoEquipo tipoEquipo = _tipoEquipoBL.SelectById(_tipoEquipoId);

                if (tipoEquipo == null)
                {
                    MessageBox.Show("No se encontró el tipo de equipo seleccionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtCodigo.Text = tipoEquipo.TipoEquipoId.ToString();
                txtNombre.Text = tipoEquipo.Nombre;
                cmbEstado.SelectedIndex = (tipoEquipo.Estado == "A" || tipoEquipo.Estado == "Activo") ? 0 : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos del tipo de equipo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "¿Desea actualizar los datos de este tipo de equipo?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                TipoEquipo tipoEquipo = new TipoEquipo
                {
                    TipoEquipoId = _tipoEquipoId,
                    Nombre = txtNombre.Text.Trim(),
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                _tipoEquipoBL.Update(tipoEquipo);

                MessageBox.Show("Los datos del tipo de equipo se actualizaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Ocurrió un error inesperado al actualizar el tipo de equipo: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
