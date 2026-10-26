using System;
using System.Windows.Forms;

namespace TallerElectronico.Desktop
{
    public partial class FrmMain : Form
    {
        private Form formularioActual;

        public FrmMain()
        {
            InitializeComponent();

            this.FormClosed += FrmMain_FormClosed;

            OpenFrm(new FrmInicio());
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void OpenFrm(Form formulario)
        {
            try
            {
                if (formularioActual != null && formularioActual.GetType() == formulario.GetType())
                {
                    formulario.Dispose();
                    return;
                }

                // Cierra y destruye el formulario previo
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
                formulario?.Dispose();
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

        private void btnCliente_Click(object sender, EventArgs e)
        {
            OpenFrm(new FrmCliente());
        }
        private void btnEquipo_Click(object sender, EventArgs e)
        {
            OpenFrm(new FrmEquipo());
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            OpenFrm(new FrmUsuario());
        }

        private void btnProveedor_Click(object sender, EventArgs e)
        {
            OpenFrm(new FrmProveedor());
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            OpenFrm(new FrmMarca());
        }

        private void btnReparacion_Click(object sender, EventArgs e)
        {
            OpenFrm(new FrmReparacion());
        }
    }
}