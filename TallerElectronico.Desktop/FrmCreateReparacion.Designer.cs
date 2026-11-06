namespace TallerElectronico.Desktop
{
    partial class FrmCreateReparacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnGenerarCodigo = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.lblCodigoSeguimiento = new System.Windows.Forms.Label();
            this.txtCodigoSeguimiento = new System.Windows.Forms.TextBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblTipoEquipo = new System.Windows.Forms.Label();
            this.cmbTipoEquipo = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblCostoManoObra = new System.Windows.Forms.Label();
            this.txtCostoManoObra = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblUsuarioCreacion = new System.Windows.Forms.Label();
            this.txtUsuarioCreacion = new System.Windows.Forms.TextBox();
            this.lblDiagnosticoInicial = new System.Windows.Forms.Label();
            this.txtDiagnosticoInicial = new System.Windows.Forms.TextBox();
            this.pnlHeader.SuspendLayout();
            this.pnlCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.DarkBlue;
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(880, 101);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
            this.lblSubtitulo.Location = new System.Drawing.Point(40, 53);
            this.lblSubtitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(437, 21);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Completa los datos necesarios para registrar la recepción del equipo";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(37, 12);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(378, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nueva Recepción de Equipo";
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.txtDiagnosticoInicial);
            this.pnlCard.Controls.Add(this.lblDiagnosticoInicial);
            this.pnlCard.Controls.Add(this.txtUsuarioCreacion);
            this.pnlCard.Controls.Add(this.lblUsuarioCreacion);
            this.pnlCard.Controls.Add(this.cmbEstado);
            this.pnlCard.Controls.Add(this.lblEstado);
            this.pnlCard.Controls.Add(this.txtCostoManoObra);
            this.pnlCard.Controls.Add(this.lblCostoManoObra);
            this.pnlCard.Controls.Add(this.txtModelo);
            this.pnlCard.Controls.Add(this.lblModelo);
            this.pnlCard.Controls.Add(this.cmbMarca);
            this.pnlCard.Controls.Add(this.lblMarca);
            this.pnlCard.Controls.Add(this.cmbTipoEquipo);
            this.pnlCard.Controls.Add(this.lblTipoEquipo);
            this.pnlCard.Controls.Add(this.cmbCliente);
            this.pnlCard.Controls.Add(this.lblCliente);
            this.pnlCard.Controls.Add(this.txtCodigoSeguimiento);
            this.pnlCard.Controls.Add(this.lblCodigoSeguimiento);
            this.pnlCard.Controls.Add(this.pnlLinea);
            this.pnlCard.Controls.Add(this.lblSeccion);
            this.pnlCard.Location = new System.Drawing.Point(40, 120);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(800, 560);
            this.pnlCard.TabIndex = 1;
            // 
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSeccion.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSeccion.Location = new System.Drawing.Point(40, 17);
            this.lblSeccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(262, 25);
            this.lblSeccion.TabIndex = 0;
            this.lblSeccion.Text = "Información del Ingreso";
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(242)))));
            this.pnlLinea.Location = new System.Drawing.Point(40, 52);
            this.pnlLinea.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(720, 1);
            this.pnlLinea.TabIndex = 1;
            // 
            // lblCodigoSeguimiento
            // 
            this.lblCodigoSeguimiento.AutoSize = true;
            this.lblCodigoSeguimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCodigoSeguimiento.Location = new System.Drawing.Point(40, 71);
            this.lblCodigoSeguimiento.Name = "lblCodigoSeguimiento";
            this.lblCodigoSeguimiento.Size = new System.Drawing.Size(165, 20);
            this.lblCodigoSeguimiento.TabIndex = 2;
            this.lblCodigoSeguimiento.Text = "Código Seguimiento *";
            // 
            // txtCodigoSeguimiento
            // 
            this.txtCodigoSeguimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoSeguimiento.Enabled = false;
            this.txtCodigoSeguimiento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigoSeguimiento.Location = new System.Drawing.Point(40, 96);
            this.txtCodigoSeguimiento.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoSeguimiento.MaxLength = 20;
            this.txtCodigoSeguimiento.Name = "txtCodigoSeguimiento";
            this.txtCodigoSeguimiento.Size = new System.Drawing.Size(333, 30);
            this.txtCodigoSeguimiento.TabIndex = 3;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliente.Location = new System.Drawing.Point(426, 71);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(69, 20);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Cliente *";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(426, 95);
            this.cmbCliente.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(333, 31);
            this.cmbCliente.TabIndex = 5;
            // 
            // lblTipoEquipo
            // 
            this.lblTipoEquipo.AutoSize = true;
            this.lblTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoEquipo.Location = new System.Drawing.Point(40, 148);
            this.lblTipoEquipo.Name = "lblTipoEquipo";
            this.lblTipoEquipo.Size = new System.Drawing.Size(104, 20);
            this.lblTipoEquipo.TabIndex = 6;
            this.lblTipoEquipo.Text = "Tipo Equipo *";
            // 
            // cmbTipoEquipo
            // 
            this.cmbTipoEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipoEquipo.FormattingEnabled = true;
            this.cmbTipoEquipo.Location = new System.Drawing.Point(40, 172);
            this.cmbTipoEquipo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoEquipo.Name = "cmbTipoEquipo";
            this.cmbTipoEquipo.Size = new System.Drawing.Size(333, 31);
            this.cmbTipoEquipo.TabIndex = 7;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMarca.Location = new System.Drawing.Point(426, 148);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(63, 20);
            this.lblMarca.TabIndex = 8;
            this.lblMarca.Text = "Marca *";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(426, 172);
            this.cmbMarca.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(333, 31);
            this.cmbMarca.TabIndex = 9;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblModelo.Location = new System.Drawing.Point(40, 224);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(73, 20);
            this.lblModelo.TabIndex = 10;
            this.lblModelo.Text = "Modelo *";
            // 
            // txtModelo
            // 
            this.txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtModelo.Location = new System.Drawing.Point(40, 248);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(4);
            this.txtModelo.MaxLength = 50;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(333, 30);
            this.txtModelo.TabIndex = 11;
            // 
            // lblCostoManoObra
            // 
            this.lblCostoManoObra.AutoSize = true;
            this.lblCostoManoObra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCostoManoObra.Location = new System.Drawing.Point(426, 224);
            this.lblCostoManoObra.Name = "lblCostoManoObra";
            this.lblCostoManoObra.Size = new System.Drawing.Size(142, 20);
            this.lblCostoManoObra.TabIndex = 12;
            this.lblCostoManoObra.Text = "Costo Mano Obra *";
            // 
            // txtCostoManoObra
            // 
            this.txtCostoManoObra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostoManoObra.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCostoManoObra.Location = new System.Drawing.Point(426, 248);
            this.txtCostoManoObra.Margin = new System.Windows.Forms.Padding(4);
            this.txtCostoManoObra.MaxLength = 10;
            this.txtCostoManoObra.Name = "txtCostoManoObra";
            this.txtCostoManoObra.Size = new System.Drawing.Size(333, 30);
            this.txtCostoManoObra.TabIndex = 13;
            this.txtCostoManoObra.Text = "0.00";
            this.txtCostoManoObra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostoManoObra_KeyPress);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(40, 300);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(67, 20);
            this.lblEstado.TabIndex = 14;
            this.lblEstado.Text = "Estado *";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(40, 324);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(333, 31);
            this.cmbEstado.TabIndex = 15;
            // 
            // lblUsuarioCreacion
            // 
            this.lblUsuarioCreacion.AutoSize = true;
            this.lblUsuarioCreacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioCreacion.Location = new System.Drawing.Point(426, 300);
            this.lblUsuarioCreacion.Name = "lblUsuarioCreacion";
            this.lblUsuarioCreacion.Size = new System.Drawing.Size(138, 20);
            this.lblUsuarioCreacion.TabIndex = 16;
            this.lblUsuarioCreacion.Text = "Usuario Creación *";
            // 
            // txtUsuarioCreacion
            // 
            this.txtUsuarioCreacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarioCreacion.Enabled = false;
            this.txtUsuarioCreacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsuarioCreacion.Location = new System.Drawing.Point(426, 324);
            this.txtUsuarioCreacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuarioCreacion.Name = "txtUsuarioCreacion";
            this.txtUsuarioCreacion.Size = new System.Drawing.Size(333, 30);
            this.txtUsuarioCreacion.TabIndex = 17;
            // 
            // lblDiagnosticoInicial
            // 
            this.lblDiagnosticoInicial.AutoSize = true;
            this.lblDiagnosticoInicial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiagnosticoInicial.Location = new System.Drawing.Point(40, 374);
            this.lblDiagnosticoInicial.Name = "lblDiagnosticoInicial";
            this.lblDiagnosticoInicial.Size = new System.Drawing.Size(149, 20);
            this.lblDiagnosticoInicial.TabIndex = 18;
            this.lblDiagnosticoInicial.Text = "Diagnóstico Inicial *";
            // 
            // txtDiagnosticoInicial
            // 
            this.txtDiagnosticoInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiagnosticoInicial.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiagnosticoInicial.Location = new System.Drawing.Point(40, 398);
            this.txtDiagnosticoInicial.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiagnosticoInicial.MaxLength = 400;
            this.txtDiagnosticoInicial.Multiline = true;
            this.txtDiagnosticoInicial.Name = "txtDiagnosticoInicial";
            this.txtDiagnosticoInicial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnosticoInicial.Size = new System.Drawing.Size(719, 125);
            this.txtDiagnosticoInicial.TabIndex = 19;
            // 
            // btnGenerarCodigo
            // 
            this.btnGenerarCodigo.BackColor = System.Drawing.Color.Orange;
            this.btnGenerarCodigo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarCodigo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerarCodigo.ForeColor = System.Drawing.Color.White;
            this.btnGenerarCodigo.Location = new System.Drawing.Point(273, 703);
            this.btnGenerarCodigo.Name = "btnGenerarCodigo";
            this.btnGenerarCodigo.Size = new System.Drawing.Size(174, 52);
            this.btnGenerarCodigo.TabIndex = 2;
            this.btnGenerarCodigo.Text = "Generar Código";
            this.btnGenerarCodigo.UseVisualStyleBackColor = false;
            this.btnGenerarCodigo.Click += new System.EventHandler(this.btnGenerarCodigo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(466, 703);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(173, 52);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(657, 703);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 52);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmCreateReparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 793);
            this.Controls.Add(this.btnGenerarCodigo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCreateReparacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nueva Recepción";
            this.Load += new System.EventHandler(this.FrmCreateReparacion_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.Label lblCodigoSeguimiento;
        private System.Windows.Forms.TextBox txtCodigoSeguimiento;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblTipoEquipo;
        private System.Windows.Forms.ComboBox cmbTipoEquipo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblCostoManoObra;
        private System.Windows.Forms.TextBox txtCostoManoObra;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblUsuarioCreacion;
        private System.Windows.Forms.TextBox txtUsuarioCreacion;
        private System.Windows.Forms.Label lblDiagnosticoInicial;
        private System.Windows.Forms.TextBox txtDiagnosticoInicial;
        private System.Windows.Forms.Button btnGenerarCodigo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}