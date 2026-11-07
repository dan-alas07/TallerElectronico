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

namespace TallerElectronico.Desktop
{
    public partial class FrmEditDetalleReparacion : Form
    {
        private readonly DetalleReparacionBL _detalleReparacionBL = new DetalleReparacionBL();
        private int _detalleReparacionId;

        public FrmEditDetalleReparacion()
        {
            InitializeComponent();
        }

        private void FrmEditDetalleReparacion_Load(object sender, EventArgs e)
        {

        }

        public FrmEditDetalleReparacion(int detalleReparacionId) : this()
        {
            _detalleReparacionId = detalleReparacionId;
        }
    }
}
