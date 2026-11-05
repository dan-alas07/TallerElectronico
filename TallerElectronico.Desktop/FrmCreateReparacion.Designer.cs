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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtDiagnosticoInicial = new System.Windows.Forms.TextBox();
            this.lblDiagnosticoInicial = new System.Windows.Forms.Label();
            this.dtpFechaContratacion = new System.Windows.Forms.DateTimePicker();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.lblModelo = new System.Windows.Forms.Label();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblTipoEquipo = new System.Windows.Forms.Label();
            this.lblCliente = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.cmbTipoEquipo = new System.Windows.Forms.ComboBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.cmbTecnico = new System.Windows.Forms.ComboBox();
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
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(660, 82);
            this.pnlHeader.TabIndex = 1;
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.cmbTecnico);
            this.pnlCard.Controls.Add(this.txtModelo);
            this.pnlCard.Controls.Add(this.cmbMarca);
            this.pnlCard.Controls.Add(this.cmbTipoEquipo);
            this.pnlCard.Controls.Add(this.cmbCliente);
            this.pnlCard.Controls.Add(this.cmbEstado);
            this.pnlCard.Controls.Add(this.txtDiagnosticoInicial);
            this.pnlCard.Controls.Add(this.lblDiagnosticoInicial);
            this.pnlCard.Controls.Add(this.dtpFechaContratacion);
            this.pnlCard.Controls.Add(this.lblFechaIngreso);
            this.pnlCard.Controls.Add(this.lblTecnico);
            this.pnlCard.Controls.Add(this.lblModelo);
            this.pnlCard.Controls.Add(this.lblMarca);
            this.pnlCard.Controls.Add(this.lblTipoEquipo);
            this.pnlCard.Controls.Add(this.lblCliente);
            this.pnlCard.Controls.Add(this.lblEstado);
            this.pnlCard.Controls.Add(this.txtCodigo);
            this.pnlCard.Controls.Add(this.lblCodigo);
            this.pnlCard.Controls.Add(this.pnlLinea);
            this.pnlCard.Controls.Add(this.lblSeccion);
            this.pnlCard.Location = new System.Drawing.Point(30, 95);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(600, 438);
            this.pnlCard.TabIndex = 66;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstado.Location = new System.Drawing.Point(320, 78);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(250, 25);
            this.cmbEstado.TabIndex = 65;
            // 
            // txtDiagnosticoInicial
            // 
            this.txtDiagnosticoInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiagnosticoInicial.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiagnosticoInicial.Location = new System.Drawing.Point(30, 326);
            this.txtDiagnosticoInicial.MaxLength = 200;
            this.txtDiagnosticoInicial.Name = "txtDiagnosticoInicial";
            this.txtDiagnosticoInicial.Size = new System.Drawing.Size(540, 25);
            this.txtDiagnosticoInicial.TabIndex = 7;
            // 
            // lblDiagnosticoInicial
            // 
            this.lblDiagnosticoInicial.AutoSize = true;
            this.lblDiagnosticoInicial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiagnosticoInicial.ForeColor = System.Drawing.Color.Black;
            this.lblDiagnosticoInicial.Location = new System.Drawing.Point(30, 306);
            this.lblDiagnosticoInicial.Name = "lblDiagnosticoInicial";
            this.lblDiagnosticoInicial.Size = new System.Drawing.Size(115, 15);
            this.lblDiagnosticoInicial.TabIndex = 10;
            this.lblDiagnosticoInicial.Text = "Diagnostico Inicial *";
            // 
            // dtpFechaContratacion
            // 
            this.dtpFechaContratacion.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaContratacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaContratacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaContratacion.Location = new System.Drawing.Point(320, 264);
            this.dtpFechaContratacion.Name = "dtpFechaContratacion";
            this.dtpFechaContratacion.Size = new System.Drawing.Size(250, 25);
            this.dtpFechaContratacion.TabIndex = 6;
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaIngreso.ForeColor = System.Drawing.Color.Black;
            this.lblFechaIngreso.Location = new System.Drawing.Point(320, 244);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(100, 15);
            this.lblFechaIngreso.TabIndex = 9;
            this.lblFechaIngreso.Text = "Fecha de ingreso";
            // 
            // lblTecnico
            // 
            this.lblTecnico.AutoSize = true;
            this.lblTecnico.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTecnico.ForeColor = System.Drawing.Color.Black;
            this.lblTecnico.Location = new System.Drawing.Point(30, 244);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(110, 15);
            this.lblTecnico.TabIndex = 8;
            this.lblTecnico.Text = "Técnico Asignado *";
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblModelo.ForeColor = System.Drawing.Color.Black;
            this.lblModelo.Location = new System.Drawing.Point(320, 182);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(57, 15);
            this.lblModelo.TabIndex = 7;
            this.lblModelo.Text = "Modelo *";
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMarca.ForeColor = System.Drawing.Color.Black;
            this.lblMarca.Location = new System.Drawing.Point(30, 182);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(49, 15);
            this.lblMarca.TabIndex = 6;
            this.lblMarca.Text = "Marca *";
            // 
            // lblTipoEquipo
            // 
            this.lblTipoEquipo.AutoSize = true;
            this.lblTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoEquipo.ForeColor = System.Drawing.Color.Black;
            this.lblTipoEquipo.Location = new System.Drawing.Point(320, 120);
            this.lblTipoEquipo.Name = "lblTipoEquipo";
            this.lblTipoEquipo.Size = new System.Drawing.Size(79, 15);
            this.lblTipoEquipo.TabIndex = 5;
            this.lblTipoEquipo.Text = "Tipo Equipo *";
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliente.ForeColor = System.Drawing.Color.Black;
            this.lblCliente.Location = new System.Drawing.Point(30, 120);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(54, 15);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Cliente *";
            this.lblCliente.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(320, 58);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(43, 15);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.Location = new System.Drawing.Point(30, 78);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(250, 25);
            this.txtCodigo.TabIndex = 11;
            this.txtCodigo.TabStop = false;
            this.txtCodigo.Text = "Automático";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.ForeColor = System.Drawing.Color.Black;
            this.lblCodigo.Location = new System.Drawing.Point(30, 58);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(45, 15);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Código";
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(242)))));
            this.pnlLinea.Location = new System.Drawing.Point(30, 42);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(540, 1);
            this.pnlLinea.TabIndex = 1;
            // 
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSeccion.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSeccion.Location = new System.Drawing.Point(30, 14);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(210, 20);
            this.lblSeccion.TabIndex = 0;
            this.lblSeccion.Text = "Información de la reparación";
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
            this.btnCancelar.Location = new System.Drawing.Point(500, 557);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 42);
            this.btnCancelar.TabIndex = 69;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(360, 557);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 42);
            this.btnGuardar.TabIndex = 68;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
            this.lblSubtitulo.Location = new System.Drawing.Point(27, 48);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(365, 17);
            this.lblSubtitulo.TabIndex = 3;
            this.lblSubtitulo.Text = "Completa los datos necesarios para registrar una reparación";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(24, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(222, 32);
            this.lblTitulo.TabIndex = 2;
            this.lblTitulo.Text = "Nueva Reparación";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbCliente.Location = new System.Drawing.Point(30, 140);
            this.cmbCliente.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(250, 25);
            this.cmbCliente.TabIndex = 66;
            // 
            // cmbTipoEquipo
            // 
            this.cmbTipoEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipoEquipo.FormattingEnabled = true;
            this.cmbTipoEquipo.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbTipoEquipo.Location = new System.Drawing.Point(320, 139);
            this.cmbTipoEquipo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoEquipo.Name = "cmbTipoEquipo";
            this.cmbTipoEquipo.Size = new System.Drawing.Size(250, 25);
            this.cmbTipoEquipo.TabIndex = 67;
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbMarca.Location = new System.Drawing.Point(30, 201);
            this.cmbMarca.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(250, 25);
            this.cmbMarca.TabIndex = 68;
            // 
            // txtModelo
            // 
            this.txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtModelo.Location = new System.Drawing.Point(320, 202);
            this.txtModelo.MaxLength = 100;
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(250, 25);
            this.txtModelo.TabIndex = 69;
            // 
            // cmbTecnico
            // 
            this.cmbTecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTecnico.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTecnico.FormattingEnabled = true;
            this.cmbTecnico.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbTecnico.Location = new System.Drawing.Point(30, 267);
            this.cmbTecnico.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTecnico.Name = "cmbTecnico";
            this.cmbTecnico.Size = new System.Drawing.Size(250, 25);
            this.cmbTecnico.TabIndex = 70;
            // 
            // FrmCreateReparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 611);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.pnlHeader);
            this.Name = "FrmCreateReparacion";
            this.ShowIcon = false;
            this.Text = "FrmNewReparacion";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.TextBox txtDiagnosticoInicial;
        private System.Windows.Forms.Label lblDiagnosticoInicial;
        private System.Windows.Forms.DateTimePicker dtpFechaContratacion;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.Label lblTecnico;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.Label lblTipoEquipo;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.ComboBox cmbTipoEquipo;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbTecnico;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.ComboBox cmbMarca;
    }
}