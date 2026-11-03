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
    public partial class FrmMarca : Form
    {
        private readonly MarcaBL _marcaBL = new MarcaBL();
        private bool cargandoMarcas = false;
        private readonly Timer _timerBusqueda = new Timer();

        public FrmMarca()
        {
            InitializeComponent();

            RegistrarEventos(this);

            dgvMarca.AutoGenerateColumns = false;
            dgvMarca.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMarca.MultiSelect = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvMarca.SelectionChanged += dgvMarca_SelectionChanged;

            // Configurar el temporizador (300 milisegundos de espera)
            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;
        }

        private void FrmMarca_Load(object sender, EventArgs e)
        {
            CargarMarcas();
            BeginInvoke((MethodInvoker)delegate
            {
                RestablecerBotones();
            });
        }

        private void CargarMarcas()
        {
            try
            {
                cargandoMarcas = true;

                string criterio = txtBuscar != null ? txtBuscar.Text.Trim() : string.Empty;

                dgvMarca.DataSource = null;

                if (string.IsNullOrWhiteSpace(criterio))
                {
                    dgvMarca.DataSource = _marcaBL.SelectAll();
                }
                else
                {
                    dgvMarca.DataSource = _marcaBL.Search(criterio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar las marcas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoMarcas = false;
                RestablecerBotones();
            }
        }

        private void dgvMarca_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoMarcas) return;

            bool marcaSeleccionada = dgvMarca.SelectedRows.Count > 0;

            btnNuevo.Enabled = !marcaSeleccionada;
            btnEditar.Enabled = marcaSeleccionada;
            btnEliminar.Enabled = marcaSeleccionada;
        }

        private void RegistrarEventos(Control control)
        {
            control.MouseDown += Control_MouseDown;

            foreach (Control hijo in control.Controls)
            {
                if (hijo == btnNuevo || hijo == btnEditar || hijo == btnEliminar || hijo == txtBuscar)
                    continue;

                RegistrarEventos(hijo);
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;

            if (control == null || control == dgvMarca)
                return;

            RestablecerBotones();
        }

        private void RestablecerBotones()
        {
            if (dgvMarca != null)
            {
                dgvMarca.ClearSelection();
                dgvMarca.CurrentCell = null;
            }

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private int? ObtenerMarcaSeleccionada()
        {
            if (dgvMarca.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una marca.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            object valorId = dgvMarca.SelectedRows[0].Cells["ColumnCode"].Value;

            if (valorId == null || valorId == DBNull.Value)
            {
                MessageBox.Show("No se pudo obtener el código de la marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return Convert.ToInt32(valorId);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmCreateMarca frm = new FrmCreateMarca())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarMarcas();
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? marcaId = ObtenerMarcaSeleccionada();
            if (!marcaId.HasValue) return;

            using (FrmEditMarca frm = new FrmEditMarca(marcaId.Value))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarMarcas();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? marcaId = ObtenerMarcaSeleccionada();
            if (!marcaId.HasValue) return;

            string nombre = Convert.ToString(dgvMarca.SelectedRows[0].Cells["ColumnName"].Value);

            DialogResult confirm = MessageBox.Show($"¿Seguro que desea eliminar la marca {nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _marcaBL.Delete(marcaId.Value);
                MessageBox.Show("La marca se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarMarcas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar la marca: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Reinicia el reloj a cada tecla. Solo cuando te detengas 300ms se consultará a la DAL
            _timerBusqueda.Stop();
            _timerBusqueda.Start();
        }

        private void TimerBusqueda_Tick(object sender, EventArgs e)
        {
            _timerBusqueda.Stop();
            CargarMarcas(); // Llama a la DAL cuando el usuario pausó el tipeo
        }
    }
}
