using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TallerElectronico.Desktop
{
    public partial class FrmMain : Form
    {
        private Form formularioActual;

        public FrmMain()
        {
            InitializeComponent();

            OpenFrm(new FrmInicio());
        }

        private void OpenFrm(Form formulario)
        {
            try
            {
                if (formularioActual != null && formularioActual.GetType() == formulario.GetType())
                {
                    return;
                }

                if (formularioActual != null)
                {
                    formularioActual.Close();
                    formularioActual.Dispose();
                }

                pnlContainer.Controls.Clear();

                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;

                formularioActual = formulario;
                pnlContainer.Controls.Add(formularioActual);

                formularioActual.Show();
                formularioActual.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo abrir el formulario.\n\n" + ex.Message,
                    "Error al abrir módulo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            OpenFrm(new FrmEmpleado());
        }

        private void btnMain_Click(object sender, EventArgs e)
        {

            OpenFrm(new FrmInicio());
        }
    }
}