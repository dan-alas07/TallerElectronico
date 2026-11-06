namespace TallerElectronico.Desktop
{
    partial class FrmEditReparacion
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
            this.pnlCard = new System.Windows.Forms.Panel();
            this.dtpFechaEntrega = new System.Windows.Forms.DateTimePicker();
            this.lblFechaEntrega = new System.Windows.Forms.Label();
            this.txtTotalReparacion = new System.Windows.Forms.TextBox();
            this.lblTotalReparacion = new System.Windows.Forms.Label();
            this.txtCostoManoObra = new System.Windows.Forms.TextBox();
            this.lblCostoManoObra = new System.Windows.Forms.Label();
            this.txtDiagnosticoFinal = new System.Windows.Forms.TextBox();
            this.lblDiagnosticoFinal = new System.Windows.Forms.Label();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.lblUsuarioModificacion = new System.Windows.Forms.Label();
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
            this.txtFechaIngreso = new System.Windows.Forms.TextBox();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.lblCliente = new System.Windows.Forms.Label();
            this.txtCodigoSeguimiento = new System.Windows.Forms.TextBox();
            this.lblCodigoSeguimiento = new System.Windows.Forms.Label();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
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
            this.btnCancelar.Location = new System.Drawing.Point(740, 463);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(130, 37);
            this.btnCancelar.TabIndex = 3;
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
            this.btnGuardar.Location = new System.Drawing.Point(590, 463);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(130, 37);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
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
            this.pnlCard.Controls.Add(this.txtUsuarioModificacion);
            this.pnlCard.Controls.Add(this.lblUsuarioModificacion);
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
            this.pnlCard.Controls.Add(this.txtFechaIngreso);
            this.pnlCard.Controls.Add(this.lblFechaIngreso);
            this.pnlCard.Controls.Add(this.cmbCliente);
            this.pnlCard.Controls.Add(this.lblCliente);
            this.pnlCard.Controls.Add(this.txtCodigoSeguimiento);
            this.pnlCard.Controls.Add(this.lblCodigoSeguimiento);
            this.pnlCard.Controls.Add(this.pnlLinea);
            this.pnlCard.Controls.Add(this.lblSeccion);
            this.pnlCard.Location = new System.Drawing.Point(30, 77);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(840, 374);
            this.pnlCard.TabIndex = 1;
            // 
            // dtpFechaEntrega
            // 
            this.dtpFechaEntrega.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpFechaEntrega.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.dtpFechaEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaEntrega.Location = new System.Drawing.Point(570, 331);
            this.dtpFechaEntrega.Name = "dtpFechaEntrega";
            this.dtpFechaEntrega.ShowCheckBox = true;
            this.dtpFechaEntrega.Size = new System.Drawing.Size(248, 24);
            this.dtpFechaEntrega.TabIndex = 29;
            // 
            // lblFechaEntrega
            // 
            this.lblFechaEntrega.AutoSize = true;
            this.lblFechaEntrega.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaEntrega.Location = new System.Drawing.Point(570, 312);
            this.lblFechaEntrega.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaEntrega.Name = "lblFechaEntrega";
            this.lblFechaEntrega.Size = new System.Drawing.Size(85, 15);
            this.lblFechaEntrega.TabIndex = 28;
            this.lblFechaEntrega.Text = "Fecha Entrega";
            // 
            // txtTotalReparacion
            // 
            this.txtTotalReparacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotalReparacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtTotalReparacion.Location = new System.Drawing.Point(296, 331);
            this.txtTotalReparacion.MaxLength = 10;
            this.txtTotalReparacion.Name = "txtTotalReparacion";
            this.txtTotalReparacion.Size = new System.Drawing.Size(248, 24);
            this.txtTotalReparacion.TabIndex = 27;
            this.txtTotalReparacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // lblTotalReparacion
            // 
            this.lblTotalReparacion.AutoSize = true;
            this.lblTotalReparacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalReparacion.Location = new System.Drawing.Point(296, 312);
            this.lblTotalReparacion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalReparacion.Name = "lblTotalReparacion";
            this.lblTotalReparacion.Size = new System.Drawing.Size(99, 15);
            this.lblTotalReparacion.TabIndex = 26;
            this.lblTotalReparacion.Text = "Total Reparación";
            // 
            // txtCostoManoObra
            // 
            this.txtCostoManoObra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCostoManoObra.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCostoManoObra.Location = new System.Drawing.Point(22, 331);
            this.txtCostoManoObra.MaxLength = 10;
            this.txtCostoManoObra.Name = "txtCostoManoObra";
            this.txtCostoManoObra.Size = new System.Drawing.Size(248, 24);
            this.txtCostoManoObra.TabIndex = 25;
            this.txtCostoManoObra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // lblCostoManoObra
            // 
            this.lblCostoManoObra.AutoSize = true;
            this.lblCostoManoObra.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCostoManoObra.Location = new System.Drawing.Point(22, 312);
            this.lblCostoManoObra.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCostoManoObra.Name = "lblCostoManoObra";
            this.lblCostoManoObra.Size = new System.Drawing.Size(110, 15);
            this.lblCostoManoObra.TabIndex = 24;
            this.lblCostoManoObra.Text = "Costo Mano Obra *";
            // 
            // txtDiagnosticoFinal
            // 
            this.txtDiagnosticoFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiagnosticoFinal.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiagnosticoFinal.Location = new System.Drawing.Point(22, 269);
            this.txtDiagnosticoFinal.MaxLength = 300;
            this.txtDiagnosticoFinal.Multiline = true;
            this.txtDiagnosticoFinal.Name = "txtDiagnosticoFinal";
            this.txtDiagnosticoFinal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnosticoFinal.Size = new System.Drawing.Size(796, 37);
            this.txtDiagnosticoFinal.TabIndex = 23;
            // 
            // lblDiagnosticoFinal
            // 
            this.lblDiagnosticoFinal.AutoSize = true;
            this.lblDiagnosticoFinal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiagnosticoFinal.Location = new System.Drawing.Point(22, 250);
            this.lblDiagnosticoFinal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiagnosticoFinal.Name = "lblDiagnosticoFinal";
            this.lblDiagnosticoFinal.Size = new System.Drawing.Size(100, 15);
            this.lblDiagnosticoFinal.TabIndex = 22;
            this.lblDiagnosticoFinal.Text = "Diagnóstico Final";
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(570, 220);
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(248, 24);
            this.txtUsuarioModificacion.TabIndex = 21;
            // 
            // lblUsuarioModificacion
            // 
            this.lblUsuarioModificacion.AutoSize = true;
            this.lblUsuarioModificacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUsuarioModificacion.Location = new System.Drawing.Point(570, 202);
            this.lblUsuarioModificacion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuarioModificacion.Name = "lblUsuarioModificacion";
            this.lblUsuarioModificacion.Size = new System.Drawing.Size(123, 15);
            this.lblUsuarioModificacion.TabIndex = 20;
            this.lblUsuarioModificacion.Text = "Usuario Modificación";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(296, 220);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(248, 25);
            this.cmbEstado.TabIndex = 19;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(296, 202);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(51, 15);
            this.lblEstado.TabIndex = 18;
            this.lblEstado.Text = "Estado *";
            // 
            // cmbTecnico
            // 
            this.cmbTecnico.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTecnico.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTecnico.FormattingEnabled = true;
            this.cmbTecnico.Location = new System.Drawing.Point(22, 220);
            this.cmbTecnico.Name = "cmbTecnico";
            this.cmbTecnico.Size = new System.Drawing.Size(248, 25);
            this.cmbTecnico.TabIndex = 17;
            // 
            // lblTecnico
            // 
            this.lblTecnico.AutoSize = true;
            this.lblTecnico.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTecnico.Location = new System.Drawing.Point(22, 202);
            this.lblTecnico.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTecnico.Name = "lblTecnico";
            this.lblTecnico.Size = new System.Drawing.Size(102, 15);
            this.lblTecnico.TabIndex = 16;
            this.lblTecnico.Text = "Técnico Asignado";
            // 
            // txtDiagnosticoInicial
            // 
            this.txtDiagnosticoInicial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtDiagnosticoInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiagnosticoInicial.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtDiagnosticoInicial.Location = new System.Drawing.Point(22, 161);
            this.txtDiagnosticoInicial.Multiline = true;
            this.txtDiagnosticoInicial.Name = "txtDiagnosticoInicial";
            this.txtDiagnosticoInicial.ReadOnly = true;
            this.txtDiagnosticoInicial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDiagnosticoInicial.Size = new System.Drawing.Size(796, 34);
            this.txtDiagnosticoInicial.TabIndex = 15;
            // 
            // lblDiagnosticoInicial
            // 
            this.lblDiagnosticoInicial.AutoSize = true;
            this.lblDiagnosticoInicial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDiagnosticoInicial.Location = new System.Drawing.Point(22, 142);
            this.lblDiagnosticoInicial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiagnosticoInicial.Name = "lblDiagnosticoInicial";
            this.lblDiagnosticoInicial.Size = new System.Drawing.Size(107, 15);
            this.lblDiagnosticoInicial.TabIndex = 14;
            this.lblDiagnosticoInicial.Text = "Diagnóstico Inicial";
            // 
            // txtModelo
            // 
            this.txtModelo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtModelo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtModelo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtModelo.Location = new System.Drawing.Point(570, 112);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.ReadOnly = true;
            this.txtModelo.Size = new System.Drawing.Size(248, 24);
            this.txtModelo.TabIndex = 13;
            // 
            // lblModelo
            // 
            this.lblModelo.AutoSize = true;
            this.lblModelo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblModelo.Location = new System.Drawing.Point(570, 93);
            this.lblModelo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblModelo.Name = "lblModelo";
            this.lblModelo.Size = new System.Drawing.Size(49, 15);
            this.lblModelo.TabIndex = 12;
            this.lblModelo.Text = "Modelo";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(296, 112);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(248, 25);
            this.cmbMarca.TabIndex = 11;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblMarca.Location = new System.Drawing.Point(296, 93);
            this.lblMarca.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(41, 15);
            this.lblMarca.TabIndex = 10;
            this.lblMarca.Text = "Marca";
            // 
            // cmbTipoEquipo
            // 
            this.cmbTipoEquipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbTipoEquipo.FormattingEnabled = true;
            this.cmbTipoEquipo.Location = new System.Drawing.Point(22, 112);
            this.cmbTipoEquipo.Name = "cmbTipoEquipo";
            this.cmbTipoEquipo.Size = new System.Drawing.Size(248, 25);
            this.cmbTipoEquipo.TabIndex = 9;
            // 
            // lblTipoEquipo
            // 
            this.lblTipoEquipo.AutoSize = true;
            this.lblTipoEquipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipoEquipo.Location = new System.Drawing.Point(22, 93);
            this.lblTipoEquipo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTipoEquipo.Name = "lblTipoEquipo";
            this.lblTipoEquipo.Size = new System.Drawing.Size(71, 15);
            this.lblTipoEquipo.TabIndex = 8;
            this.lblTipoEquipo.Text = "Tipo Equipo";
            // 
            // txtFechaIngreso
            // 
            this.txtFechaIngreso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtFechaIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFechaIngreso.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtFechaIngreso.Location = new System.Drawing.Point(570, 63);
            this.txtFechaIngreso.Name = "txtFechaIngreso";
            this.txtFechaIngreso.ReadOnly = true;
            this.txtFechaIngreso.Size = new System.Drawing.Size(248, 24);
            this.txtFechaIngreso.TabIndex = 7;
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFechaIngreso.Location = new System.Drawing.Point(570, 45);
            this.lblFechaIngreso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(84, 15);
            this.lblFechaIngreso.TabIndex = 6;
            this.lblFechaIngreso.Text = "Fecha Ingreso";
            // 
            // cmbCliente
            // 
            this.cmbCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCliente.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbCliente.FormattingEnabled = true;
            this.cmbCliente.Location = new System.Drawing.Point(296, 63);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new System.Drawing.Size(248, 25);
            this.cmbCliente.TabIndex = 5;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCliente.Location = new System.Drawing.Point(296, 45);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(46, 15);
            this.lblCliente.TabIndex = 4;
            this.lblCliente.Text = "Cliente";
            // 
            // txtCodigoSeguimiento
            // 
            this.txtCodigoSeguimiento.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtCodigoSeguimiento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoSeguimiento.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtCodigoSeguimiento.Location = new System.Drawing.Point(22, 63);
            this.txtCodigoSeguimiento.Name = "txtCodigoSeguimiento";
            this.txtCodigoSeguimiento.ReadOnly = true;
            this.txtCodigoSeguimiento.Size = new System.Drawing.Size(248, 24);
            this.txtCodigoSeguimiento.TabIndex = 3;
            // 
            // lblCodigoSeguimiento
            // 
            this.lblCodigoSeguimiento.AutoSize = true;
            this.lblCodigoSeguimiento.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCodigoSeguimiento.Location = new System.Drawing.Point(22, 45);
            this.lblCodigoSeguimiento.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodigoSeguimiento.Name = "lblCodigoSeguimiento";
            this.lblCodigoSeguimiento.Size = new System.Drawing.Size(119, 15);
            this.lblCodigoSeguimiento.TabIndex = 2;
            this.lblCodigoSeguimiento.Text = "Código Seguimiento";
            // 
            // pnlLinea
            // 
            this.pnlLinea.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(242)))));
            this.pnlLinea.Location = new System.Drawing.Point(22, 37);
            this.pnlLinea.Name = "pnlLinea";
            this.pnlLinea.Size = new System.Drawing.Size(795, 1);
            this.pnlLinea.TabIndex = 1;
            // 
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSeccion.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSeccion.Location = new System.Drawing.Point(22, 12);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(252, 20);
            this.lblSeccion.TabIndex = 0;
            this.lblSeccion.Text = "Detalles de la Orden de Reparación";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.Black;
            this.lblTitulo.Location = new System.Drawing.Point(25, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(331, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Gestión y Cierre de Reparación";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.Black;
            this.lblSubtitulo.Location = new System.Drawing.Point(27, 39);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(409, 17);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Actualiza el avance técnico, el diagnóstico final y el costo del servicio";
            // 
            // FrmEditReparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 516);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.pnlCard);
            this.Name = "FrmEditReparacion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Reparación";
            this.Load += new System.EventHandler(this.FrmEditReparacion_Load);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
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
        private System.Windows.Forms.TextBox txtFechaIngreso;
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
        private System.Windows.Forms.Label lblUsuarioModificacion;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.Label lblDiagnosticoFinal;
        private System.Windows.Forms.TextBox txtDiagnosticoFinal;
        private System.Windows.Forms.Label lblCostoManoObra;
        private System.Windows.Forms.TextBox txtCostoManoObra;
        private System.Windows.Forms.Label lblTotalReparacion;
        private System.Windows.Forms.TextBox txtTotalReparacion;
        private System.Windows.Forms.Label lblFechaEntrega;
        private System.Windows.Forms.DateTimePicker dtpFechaEntrega;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
    }
}