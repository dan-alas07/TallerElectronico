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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.txtTotalReparacion = new System.Windows.Forms.TextBox();
            this.lblTotalReparacion = new System.Windows.Forms.Label();
            this.txtCostoManoObra = new System.Windows.Forms.TextBox();
            this.lblCostoManoObra = new System.Windows.Forms.Label();
            this.txtDiagnosticoFinal = new System.Windows.Forms.TextBox();
            this.lblDiagnosticoFinal = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cmbTecnico = new System.Windows.Forms.ComboBox();
            this.lblTecnico = new System.Windows.Forms.Label();
            this.txtDiagnosticoInicial = new System.Windows.Forms.TextBox();
            this.lblDiagnosticoInicial = new System.Windows.Forms.Label();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.lblModelo = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.cmbTipoEquipo = new System.Windows.Forms.ComboBox();
            this.lblTipoEquipo = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCodigoSeguimiento = new System.Windows.Forms.TextBox();
            this.lblCodigoSeguimiento = new System.Windows.Forms.Label();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
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
            this.btnCancelar.Location = new System.Drawing.Point(987, 636);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 46);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
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
            this.btnGuardar.Location = new System.Drawing.Point(787, 636);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(173, 46);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnGenerarCodigo
            // 
            this.btnGenerarCodigo.BackColor = System.Drawing.Color.Orange;
            this.btnGenerarCodigo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarCodigo.FlatAppearance.BorderSize = 0;
            this.btnGenerarCodigo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarCodigo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerarCodigo.ForeColor = System.Drawing.Color.White;
            this.btnGenerarCodigo.Location = new System.Drawing.Point(573, 636);
            this.btnGenerarCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.btnGenerarCodigo.Name = "btnGenerarCodigo";
            this.btnGenerarCodigo.Size = new System.Drawing.Size(193, 46);
            this.btnGenerarCodigo.TabIndex = 2;
            this.btnGenerarCodigo.Text = "Generar Código";
            this.btnGenerarCodigo.UseVisualStyleBackColor = false;
            this.btnGenerarCodigo.Click += new System.EventHandler(this.btnGenerarCodigo_Click);
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.dtpFechaEntrega);
            this.pnlCard.Controls.Add(this.lblFechaEntrega);
            this.pnlCard.Controls.Add(this.txtTotalReparacion);
            this.pnlCard.Controls.Add(this.lblTotalReparacion);
            this.pnlCard.Controls.Add(this.txtCostoManoObra);
            this.pnlCard.Controls.Add(this.lblCostoManoObra);
            this.pnlCard.Controls.Add(this.txtDiagnosticoFinal);
            this.pnlCard.Controls.Add(this.lblDiagnosticoFinal);
            this.pnlCard.Controls.Add(this.cmbEstado);
            this.pnlCard.Controls.Add(this.lblEstado);
            this.pnlCard.Controls.Add(this.cmbTecnico);
            this.pnlCard.Controls.Add(this.lblTecnico);
            this.pnlCard.Controls.Add(this.txtDiagnosticoInicial);
            this.pnlCard.Controls.Add(this.lblDiagnosticoInicial);
            this.pnlCard.Controls.Add(this.txtModelo);
            this.pnlCard.Controls.Add(this.lblModelo);
            this.pnlCard.Controls.Add(this.cmbMarca);
            this.pnlCard.Controls.Add(this.lblMarca);
            this.pnlCard.Controls.Add(this.cmbTipoEquipo);
            this.pnlCard.Controls.Add(this.lblTipoEquipo);
            this.pnlCard.Controls.Add(this.dtpFechaIngreso);
            this.pnlCard.Controls.Add(this.lblFechaIngreso);
            this.pnlCard.Controls.Add(this.cmbCliente);
            this.pnlCard.Controls.Add(this.lblCliente);
            this.pnlCard.Controls.Add(this.txtCodigoSeguimiento);
            this.pnlCard.Controls.Add(this.lblCodigoSeguimiento);
            this.pnlCard.Controls.Add(this.pnlLinea);
            this.pnlCard.Controls.Add(this.lblSeccion);
            this.pnlCard.Location = new System.Drawing.Point(40, 134);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(1120, 460);
            this.pnlCard.TabIndex = 1;
            // 
            // dtpFechaEntrega
            // 
            this.dtpFechaEntrega.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaEntrega.Enabled = false;
            this.dtpFechaEntrega.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaEntrega.Location = new System.Drawing.Point(760, 407);
            this.dtpFechaEntrega.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaEntrega.Name = "dtpFechaEntrega";
            this.dtpFechaEntrega.Size = new System.Drawing.Size(329, 29);
            this.dtpFechaEntrega.TabIndex = 29;
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaEntrega.Location = new System.Drawing.Point(760, 384);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(107, 20);
            this.lblFechaEntrega.TabIndex = 28;
            this.lblFechaEntrega.Text = "Fecha Entrega";
            // 
            // txtTotalReparacion
            // 
            this.txtTotalReparacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalReparacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTotalReparacion.Location = new System.Drawing.Point(395, 407);
            this.txtTotalReparacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotalReparacion.MaxLength = 10;
            this.txtTotalReparacion.Name = "txtTotalReparacion";
            this.txtTotalReparacion.Size = new System.Drawing.Size(330, 29);
            this.txtTotalReparacion.TabIndex = 27;
            this.txtTotalReparacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostoManoObra_KeyPress);
            // 
            // lblTotalReparacion
            // 
            this.lblTotalReparacion.AutoSize = true;
            this.lblTotalReparacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalReparacion.Location = new System.Drawing.Point(395, 384);
            this.lblTotalReparacion.Name = "lblTotalReparacion";
            this.lblTotalReparacion.Size = new System.Drawing.Size(126, 20);
            this.lblTotalReparacion.TabIndex = 26;
            this.lblTotalReparacion.Text = "Total Reparación";
            // 
            // txtCostoManoObra
            // 
            this.txtCostoManoObra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostoManoObra.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCostoManoObra.Location = new System.Drawing.Point(29, 407);
            this.txtCostoManoObra.Margin = new System.Windows.Forms.Padding(4);
            this.txtCostoManoObra.MaxLength = 10;
            this.txtCostoManoObra.Name = "txtCostoManoObra";
            this.txtCostoManoObra.Size = new System.Drawing.Size(330, 29);
            this.txtCostoManoObra.TabIndex = 25;
            this.txtCostoManoObra.Text = "0.00";
            this.txtCostoManoObra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostoManoObra_KeyPress);
            // 
            // lblCostoManoObra
            // 
            this.lblCostoManoObra.AutoSize = true;
            this.lblCostoManoObra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCostoManoObra.Location = new System.Drawing.Point(29, 384);
            this.lblCostoManoObra.Name = "lblCostoManoObra";
            this.lblCostoManoObra.Size = new System.Drawing.Size(142, 20);
            this.lblCostoManoObra.TabIndex = 24;
            this.lblCostoManoObra.Text = "Costo Mano Obra *";
            // 
            // txtDiagnosticoFinal
            // 
            this.txtDiagnosticoFinal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtDiagnosticoFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiagnosticoFinal.Enabled = false;
            this.txtDiagnosticoFinal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiagnosticoFinal.Location = new System.Drawing.Point(29, 331);
            this.txtDiagnosticoFinal.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiagnosticoFinal.MaxLength = 300;
            this.txtDiagnosticoFinal.Multiline = true;
            this.txtDiagnosticoFinal.Name = "txtDiagnosticoFinal";
            this.txtDiagnosticoFinal.ReadOnly = true;
            this.txtDiagnosticoFinal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnosticoFinal.Size = new System.Drawing.Size(1061, 45);
            this.txtDiagnosticoFinal.TabIndex = 23;
            // 
            // lblDiagnosticoFinal
            // 
            this.lblDiagnosticoFinal.AutoSize = true;
            this.lblDiagnosticoFinal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiagnosticoFinal.Location = new System.Drawing.Point(29, 308);
            this.lblDiagnosticoFinal.Name = "lblDiagnosticoFinal";
            this.lblDiagnosticoFinal.Size = new System.Drawing.Size(129, 20);
            this.lblDiagnosticoFinal.TabIndex = 22;
            this.lblDiagnosticoFinal.Text = "Diagnóstico Final";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(395, 271);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(329, 29);
            this.cmbEstado.TabIndex = 19;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(395, 249);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(67, 20);
            this.lblEstado.TabIndex = 18;
            this.lblEstado.Text = "Estado *";
            // 
            // cmbTecnico
            // 
            this.cmbTecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTecnico.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTecnico.FormattingEnabled = true;
            this.cmbTecnico.Location = new System.Drawing.Point(29, 271);
            this.cmbTecnico.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTecnico.Name = "cmbTecnico";
            this.cmbTecnico.Size = new System.Drawing.Size(329, 29);
            this.cmbTecnico.TabIndex = 17;
            // 
            // lblTecnico
            // 
            this.lblTecnico.AutoSize = true;
            this.lblTecnico.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTecnico.Location = new System.Drawing.Point(29, 249);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(131, 20);
            this.lblTecnico.TabIndex = 16;
            this.lblTecnico.Text = "Técnico Asignado";
            // 
            // txtDiagnosticoInicial
            // 
            this.txtDiagnosticoInicial.BackColor = System.Drawing.Color.White;
            this.txtDiagnosticoInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiagnosticoInicial.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiagnosticoInicial.Location = new System.Drawing.Point(29, 198);
            this.txtDiagnosticoInicial.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiagnosticoInicial.Multiline = true;
            this.txtDiagnosticoInicial.Name = "txtDiagnosticoInicial";
            this.txtDiagnosticoInicial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnosticoInicial.Size = new System.Drawing.Size(1061, 41);
            this.txtDiagnosticoInicial.TabIndex = 15;
            // 
            // lblDiagnosticoInicial
            // 
            this.lblDiagnosticoInicial.AutoSize = true;
            this.lblDiagnosticoInicial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiagnosticoInicial.Location = new System.Drawing.Point(29, 175);
            this.lblDiagnosticoInicial.Name = "lblDiagnosticoInicial";
            this.lblDiagnosticoInicial.Size = new System.Drawing.Size(148, 20);
            this.lblDiagnosticoInicial.TabIndex = 14;
            this.lblDiagnosticoInicial.Text = "Diagnóstico Inicial *";
            // 
            // txtModelo
            // 
            this.txtModelo.BackColor = System.Drawing.Color.White;
            this.txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtModelo.Location = new System.Drawing.Point(760, 138);
            this.txtModelo.Margin = new System.Windows.Forms.Padding(4);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(330, 29);
            this.txtModelo.TabIndex = 13;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblModelo.Location = new System.Drawing.Point(760, 114);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(73, 20);
            this.lblModelo.TabIndex = 12;
            this.lblModelo.Text = "Modelo *";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(395, 138);
            this.cmbMarca.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(329, 29);
            this.cmbMarca.TabIndex = 11;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMarca.Location = new System.Drawing.Point(395, 114);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(63, 20);
            this.lblMarca.TabIndex = 10;
            this.lblMarca.Text = "Marca *";
            // 
            // cmbTipoEquipo
            // 
            this.cmbTipoEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTipoEquipo.FormattingEnabled = true;
            this.cmbTipoEquipo.Location = new System.Drawing.Point(29, 138);
            this.cmbTipoEquipo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoEquipo.Name = "cmbTipoEquipo";
            this.cmbTipoEquipo.Size = new System.Drawing.Size(329, 29);
            this.cmbTipoEquipo.TabIndex = 9;
            // 
            // lblTipoEquipo
            // 
            this.lblTipoEquipo.AutoSize = true;
            this.lblTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoEquipo.Location = new System.Drawing.Point(29, 114);
            this.lblTipoEquipo.Name = "lblTipoEquipo";
            this.lblTipoEquipo.Size = new System.Drawing.Size(103, 20);
            this.lblTipoEquipo.TabIndex = 8;
            this.lblTipoEquipo.Text = "Tipo Equipo *";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaIngreso.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(760, 78);
            this.dtpFechaIngreso.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(329, 29);
            this.dtpFechaIngreso.TabIndex = 7;
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaIngreso.Location = new System.Drawing.Point(760, 55);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(117, 20);
            this.lblFechaIngreso.TabIndex = 6;
            this.lblFechaIngreso.Text = "Fecha Ingreso *";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(395, 78);
            this.cmbCliente.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(329, 29);
            this.cmbCliente.TabIndex = 5;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliente.Location = new System.Drawing.Point(395, 55);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(68, 20);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Cliente *";
            // 
            // txtCodigoSeguimiento
            // 
            this.txtCodigoSeguimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtCodigoSeguimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoSeguimiento.Enabled = false;
            this.txtCodigoSeguimiento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCodigoSeguimiento.Location = new System.Drawing.Point(29, 78);
            this.txtCodigoSeguimiento.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoSeguimiento.Name = "txtCodigoSeguimiento";
            this.txtCodigoSeguimiento.Size = new System.Drawing.Size(330, 29);
            this.txtCodigoSeguimiento.TabIndex = 3;
            // 
            // lblCodigoSeguimiento
            // 
            this.lblCodigoSeguimiento.AutoSize = true;
            this.lblCodigoSeguimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCodigoSeguimiento.Location = new System.Drawing.Point(29, 55);
            this.lblCodigoSeguimiento.Name = "lblCodigoSeguimiento";
            this.lblCodigoSeguimiento.Size = new System.Drawing.Size(161, 20);
            this.lblCodigoSeguimiento.TabIndex = 2;
            this.lblCodigoSeguimiento.Text = "Código Seguimiento *";
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(242)))));
            this.pnlLinea.Location = new System.Drawing.Point(29, 46);
            this.pnlLinea.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(1060, 1);
            this.pnlLinea.TabIndex = 1;
            // 
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSeccion.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSeccion.Location = new System.Drawing.Point(29, 15);
            this.lblSeccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(227, 25);
            this.lblSeccion.TabIndex = 0;
            this.lblSeccion.Text = "Información del Ingreso";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(33, 11);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(372, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nueva Recepción de Equipo";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Black;
            this.lblSubtitulo.Location = new System.Drawing.Point(36, 48);
            this.lblSubtitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(482, 21);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Completa los datos necesarios para registrar la recepción del equipo";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.DarkBlue;
            this.pnlHeader.Controls.Add(this.label1);
            this.pnlHeader.Controls.Add(this.label2);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 101);
            this.pnlHeader.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(41, 52);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(444, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Completa los datos necesarios para registrar un tipo de equipo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(37, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(326, 41);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nuevo tipo de equipo";
            // 
            // FrmCreateReparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 710);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.btnGenerarCodigo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FrmCreateReparacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Recepción";
            this.Load += new System.EventHandler(this.FrmCreateReparacion_Load);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.Label lblCodigoSeguimiento;
        private System.Windows.Forms.TextBox txtCodigoSeguimiento;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Label lblTipoEquipo;
        private System.Windows.Forms.ComboBox cmbTipoEquipo;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label lblModelo;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.Label lblDiagnosticoInicial;
        private System.Windows.Forms.TextBox txtDiagnosticoInicial;
        private System.Windows.Forms.Label lblTecnico;
        private System.Windows.Forms.ComboBox cmbTecnico;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblDiagnosticoFinal;
        private System.Windows.Forms.TextBox txtDiagnosticoFinal;
        private System.Windows.Forms.Label lblCostoManoObra;
        private System.Windows.Forms.TextBox txtCostoManoObra;
        private System.Windows.Forms.Label lblTotalReparacion;
        private System.Windows.Forms.TextBox txtTotalReparacion;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
        private System.Windows.Forms.Button btnGenerarCodigo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}