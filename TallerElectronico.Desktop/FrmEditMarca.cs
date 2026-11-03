using System;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmEditMarca : Form
    {
        private readonly MarcaBL _marcaBL = new MarcaBL();
        private int _marcaId;

        public FrmEditMarca()
        {
            InitializeComponent();
        }

        public FrmEditMarca(int marcaId) : this()
        {
            _marcaId = marcaId;
        }

        private void FrmEditMarca_Load(object sender, EventArgs e)
        {
            CargarDatosMarca();
        }

        private void CargarDatosMarca()
        {
            try
            {
                Marca marca = _marcaBL.SelectById(_marcaId);

                if (marca == null)
                {
                    MessageBox.Show("No se encontró la marca seleccionada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DialogResult = DialogResult.Cancel;
                    Close();
                    return;
                }

                txtCodigo.Text = marca.MarcaId.ToString();
                txtNombre.Text = marca.Nombre;
                cmbEstado.SelectedIndex = (marca.Estado == "A" || marca.Estado == "Activo") ? 0 : 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de la marca: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "¿Desea actualizar los datos de esta marca?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                Marca marca = new Marca
                {
                    MarcaId = _marcaId,
                    Nombre = txtNombre.Text.Trim(),
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                _marcaBL.Update(marca);

                MessageBox.Show("Los datos de la marca se actualizaron correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
