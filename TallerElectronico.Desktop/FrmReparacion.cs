using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TallerElectronico.BusinessLogic;
using TallerElectronico.Desktop.Reportes;
using TallerElectronico.Entities;

namespace TallerElectronico.Desktop
{
    public partial class FrmReparacion : Form
    {
        private readonly ReparacionBL _reparacionBL = new ReparacionBL();
        private bool cargandoReparaciones = false;
        private readonly Timer _timerBusqueda = new Timer();

        public FrmReparacion()
        {
            InitializeComponent();

            RegistrarEventos(this);

            dgvReparaciones.AutoGenerateColumns = false;
            dgvReparaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvReparaciones.MultiSelect = false;

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnAnular.Enabled = false;

            dgvReparaciones.SelectionChanged += dgvReparaciones_SelectionChanged;

            // Configurar el temporizador para la búsqueda (300 ms de espera tras tipear)
            _timerBusqueda.Interval = 300;
            _timerBusqueda.Tick += TimerBusqueda_Tick;
        }

        private void FrmReparacion_Load(object sender, EventArgs e)
        {
            CargarReparaciones();

            // Garantiza la deselección de filas tras renderizar los controles
            BeginInvoke((MethodInvoker)delegate
            {
                RestablecerBotones();
            });
        }

        private void CargarReparaciones()
        {
            try
            {
                cargandoReparaciones = true;

                string criterio = txtBuscar != null ? txtBuscar.Text.Trim() : string.Empty;

                dgvReparaciones.DataSource = null;

                if (string.IsNullOrWhiteSpace(criterio))
                {
                    dgvReparaciones.DataSource = _reparacionBL.SelectAll();
                }
                else
                {
                    dgvReparaciones.DataSource = _reparacionBL.Search(criterio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cargar las reparaciones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cargandoReparaciones = false;
                RestablecerBotones();
            }
        }

        private void dgvReparaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (cargandoReparaciones) return;

            bool reparacionSeleccionada = dgvReparaciones.SelectedRows.Count > 0;

            btnNuevo.Enabled = !reparacionSeleccionada;
            btnEditar.Enabled = reparacionSeleccionada;
            btnAnular.Enabled = reparacionSeleccionada;
        }

        private void RegistrarEventos(Control control)
        {
            control.MouseDown += Control_MouseDown;

            foreach (Control hijo in control.Controls)
            {
                // se agregan los botones para que los tome como eventos
                if (hijo == btnNuevo || hijo == btnEditar || hijo == btnAnular || hijo == btnImprimir || hijo == txtBuscar)
                    continue;

                RegistrarEventos(hijo);
            }
        }

        private void Control_MouseDown(object sender, MouseEventArgs e)
        {
            Control control = sender as Control;

            if (control == null || control == dgvReparaciones)
                return;

            RestablecerBotones();
        }

        private void RestablecerBotones()
        {
            if (dgvReparaciones != null)
            {
                dgvReparaciones.ClearSelection();
                dgvReparaciones.CurrentCell = null;
            }

            btnNuevo.Enabled = true;
            btnEditar.Enabled = false;
            btnAnular.Enabled = false;
        }

        private ReparacionDTO ObtenerReparacionSeleccionada()
        {
            if (dgvReparaciones.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona una reparación de la lista.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            if (dgvReparaciones.SelectedRows[0].DataBoundItem is ReparacionDTO dto)
            {
                return dto;
            }

            MessageBox.Show("No se pudo obtener la información de la reparación seleccionada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            using (FrmCreateReparacion frm = new FrmCreateReparacion())
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarReparaciones();
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ReparacionDTO seleccion = ObtenerReparacionSeleccionada();
            if (seleccion == null) return;

            using (FrmEditReparacion frm = new FrmEditReparacion(seleccion.ReparacionId))
            {
                if (frm.ShowDialog(this) == DialogResult.OK)
                {
                    CargarReparaciones();
                }
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            ReparacionDTO seleccion = ObtenerReparacionSeleccionada();
            if (seleccion == null) return;

            DialogResult confirm = MessageBox.Show(
                $"¿Seguro que desea cancelar la reparación '{seleccion.CodigoSeguimiento}' ({seleccion.EquipoCompleto})?",
                "Confirmar Cancelación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question
            );

            if (confirm != DialogResult.Yes) return;

            try
            {
                _reparacionBL.Cancelar(seleccion.ReparacionId, SesionUsuario.UsuarioId);

                MessageBox.Show("La reparación se canceló correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarReparaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Reinicia el reloj con cada tecla presionada; ejecuta la búsqueda tras 300 ms de inactividad
            _timerBusqueda.Stop();
            _timerBusqueda.Start();
        }

        private void TimerBusqueda_Tick(object sender, EventArgs e)
        {
            _timerBusqueda.Stop();
            CargarReparaciones();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            ReparacionDTO seleccion = ObtenerReparacionSeleccionada();
            if (seleccion == null) return;

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Documento PDF (*.pdf)|*.pdf";
                sfd.FileName = $"Orden_Reparacion_{seleccion.CodigoSeguimiento}.pdf";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //Generar PDF
                        ReportesPdf.GenerarPDF(sfd.FileName, seleccion);

                        //Enviar Correo al cliente
                        if (!string.IsNullOrWhiteSpace(seleccion.Correo))
                        {
                            DialogResult enviar = MessageBox.Show(
                                $"¿Deseas enviar este reporte PDF por correo a {seleccion.Correo}?",
                                "Enviar Correo",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question
                            );

                            if (enviar == DialogResult.Yes)
                            {
                                Cursor = Cursors.WaitCursor;
                                CorreoPdf.EnviarOrdenPDF(sfd.FileName, seleccion);
                                Cursor = Cursors.Default;

                                MessageBox.Show("El correo fue enviado al cliente.",
                                                "Correo Enviado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El reporte PDF fue generado, pero el cliente no posee correo registrado para el envío automático.",
                                            "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    catch (Exception ex)
                    {
                        Cursor = Cursors.Default;
                        MessageBox.Show($"Ocurrió un error: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}