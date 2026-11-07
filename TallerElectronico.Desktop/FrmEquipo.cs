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
    public partial class FrmEquipo : Form
    {
        private readonly TipoEquipoBL _equipoBL = new TipoEquipoBL();
        private bool cargandoEquipos = false;
        private readonly Timer _timerBusqueda = new Timer();

        public FrmEquipo()
        {
            InitializeComponent();

            RegistrarEventos(this);

            dgvEquipo.AutoGenerateColumns = false;
            dgvEquipo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEquipo.MultiSelect = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;

            dgvEquipo.SelectionChanged += dgvEquipo_SelectionChanged;

            // Configurar el temporizador (300 milisegundos de espera)
            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;
        }

        private void FrmEquipo_Load(object sender, EventArgs e)
        {
            CargarEquipos();
            BeginInvoke((MethodInvoker)delegate
            {
                RestablecerBotones();
            });
        }

        private void CargarEquipos()
        {
            try
            {
                cargandoEquipos = true;

                string criterio = txtBuscar != null ? txtBuscar.Text.Trim() : string.Empty;

                dgvEquipo.DataSource = null;

                if (string.IsNullOrWhiteSpace(criterio))
                {
                    dgvEquipo.DataSource = _equipoBL.SelectAll();
                }
                else
                {
                    dgvEquipo.DataSource = _equipoBL.Search(criterio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar los equipos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoEquipos = false;
                RestablecerBotones();
            }
        }

        private void dgvEquipo_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoEquipos) return;

            bool equipoSeleccionado = dgvEquipo.SelectedRows.Count > 0;

            btnNuevo.Enabled = !equipoSeleccionado;
            btnEditar.Enabled = equipoSeleccionado;
            btnEliminar.Enabled = equipoSeleccionado;
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

            if (control == null || control == dgvEquipo)
                return;

            RestablecerBotones();
        }

        private void RestablecerBotones()
        {
            if (dgvEquipo != null)
            {
                dgvEquipo.ClearSelection();
                dgvEquipo.CurrentCell = null;
            }

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnEliminar.Enabled = false;
        }

        private int? ObtenerEquipoSeleccionado()
        {
            if (dgvEquipo.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un equipo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            object valorId = dgvEquipo.SelectedRows[0].Cells["ColumnCode"].Value;

            if (valorId == null || valorId == DBNull.Value)
            {
                MessageBox.Show("No se pudo obtener el código del equipo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return Convert.ToInt32(valorId);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmCreateTipoEquipo frm = new FrmCreateTipoEquipo())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarEquipos();
                }
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            int? equipoId = ObtenerEquipoSeleccionado();
            if (!equipoId.HasValue) return;

            using (FrmEditTipoEquipo frm = new FrmEditTipoEquipo(equipoId.Value))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarEquipos();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int? equipoId = ObtenerEquipoSeleccionado();
            if (!equipoId.HasValue) return;

            string nombre = Convert.ToString(dgvEquipo.SelectedRows[0].Cells["ColumnName"].Value);

            DialogResult confirm = MessageBox.Show($"¿Seguro que desea eliminar el equipo {nombre}?", "Confirmar", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            try
            {
                _equipoBL.Delete(equipoId.Value);
                MessageBox.Show("El equipo se eliminó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEquipos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el equipo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            CargarEquipos(); // Llama a la DAL cuando el usuario pausó el tipeo
        }
    }
}
