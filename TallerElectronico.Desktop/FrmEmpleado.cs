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
    public partial class FrmEmpleado : Form
    {
        public FrmEmpleado()
        {
            InitializeComponent();
        }

        private void FrmEmpleado_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                        $"¡Mensaje!\n" +
                        $"KLK: " +
                        $"\n" +
                        $"Esto es solo prueba:",
                        "Luego se hace",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
        }
    }
}
