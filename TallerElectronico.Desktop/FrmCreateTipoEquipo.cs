using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Entities;


namespace TallerElectronico.Desktop
{
    public partial class FrmCreateTipoEquipo : Form
    {
        private readonly TipoEquipoBL _tipoEquipoBL = new TipoEquipoBL();

        public FrmCreateTipoEquipo()
        {
            InitializeComponent();
        }

        private void FrmCreateTipoEquipo_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "¿Desea guardar este nuevo tipo de equipo?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                TipoEquipo tipoEquipo = new TipoEquipo
                {
                    Nombre = txtNombre.Text.Trim(),
                    Estado = cmbEstado.SelectedIndex == 0 ? "A" : "I"
                };

                TipoEquipo nuevoTipoEquipo = _tipoEquipoBL.Insert(tipoEquipo);

                if (nuevoTipoEquipo != null && nuevoTipoEquipo.TipoEquipoId > 0)
                {
                    MessageBox.Show(
                        "El tipo de equipo ha sido registrado correctamente.",
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
                MessageBox.Show("Ocurrió un error inesperado al crear el tipo de equipo: " + ex.Message, "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
