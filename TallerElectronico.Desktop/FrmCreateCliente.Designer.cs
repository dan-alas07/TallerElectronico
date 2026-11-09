namespace TallerElectronico.Desktop
{
    partial class FrmCreateCliente
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
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlCard = new System.Windows.Forms.Panel();
            this.mtxtDUI = new System.Windows.Forms.MaskedTextBox();
            this.mtxtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblDUI = new System.Windows.Forms.Label();
            this.dtpFechaContratacion = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCarnet = new System.Windows.Forms.TextBox();
            this.lblCarnet = new System.Windows.Forms.Label();
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
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
            this.pnlHeader.TabIndex = 1;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
            this.lblSubtitulo.Location = new System.Drawing.Point(40, 53);
            this.lblSubtitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(389, 21);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Completa los datos necesarios para registrar un cliente";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(37, 12);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(217, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Cliente";
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.mtxtDUI);
            this.pnlCard.Controls.Add(this.mtxtTelefono);
            this.pnlCard.Controls.Add(this.cmbEstado);
            this.pnlCard.Controls.Add(this.cmbTipoDocumento);
            this.pnlCard.Controls.Add(this.lblEstado);
            this.pnlCard.Controls.Add(this.lblDUI);
            this.pnlCard.Controls.Add(this.dtpFechaContratacion);
            this.pnlCard.Controls.Add(this.lblFecha);
            this.pnlCard.Controls.Add(this.txtCorreo);
            this.pnlCard.Controls.Add(this.lblCorreo);
            this.pnlCard.Controls.Add(this.txtCarnet);
            this.pnlCard.Controls.Add(this.lblCarnet);
            this.pnlCard.Controls.Add(this.lblTipo);
            this.pnlCard.Controls.Add(this.lblTelefono);
            this.pnlCard.Controls.Add(this.txtApellido);
            this.pnlCard.Controls.Add(this.lblApellido);
            this.pnlCard.Controls.Add(this.txtNombre);
            this.pnlCard.Controls.Add(this.lblNombre);
            this.pnlCard.Controls.Add(this.txtCodigo);
            this.pnlCard.Controls.Add(this.lblCodigo);
            this.pnlCard.Controls.Add(this.pnlLinea);
            this.pnlCard.Controls.Add(this.lblSeccion);
            this.pnlCard.Location = new System.Drawing.Point(40, 117);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(4);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(800, 482);
            this.pnlCard.TabIndex = 2;
            this.pnlCard.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCentral_Paint);
            // 
            // mtxtDUI
            // 
            this.mtxtDUI.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.mtxtDUI.HidePromptOnLeave = true;
            this.mtxtDUI.Location = new System.Drawing.Point(431, 326);
            this.mtxtDUI.Mask = "00000000-0";
            this.mtxtDUI.Name = "mtxtDUI";
            this.mtxtDUI.PromptChar = ' ';
            this.mtxtDUI.Size = new System.Drawing.Size(328, 29);
            this.mtxtDUI.TabIndex = 53;
            this.mtxtDUI.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxtDUI_MaskInputRejected);
            // 
            // mtxtTelefono
            // 
            this.mtxtTelefono.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.mtxtTelefono.HidePromptOnLeave = true;
            this.mtxtTelefono.Location = new System.Drawing.Point(40, 247);
            this.mtxtTelefono.Mask = "0000-0000";
            this.mtxtTelefono.Name = "mtxtTelefono";
            this.mtxtTelefono.PromptChar = ' ';
            this.mtxtTelefono.Size = new System.Drawing.Size(333, 29);
            this.mtxtTelefono.TabIndex = 52;
            this.mtxtTelefono.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtxtTelefono_MaskInputRejected);
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstado.Location = new System.Drawing.Point(431, 96);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(328, 31);
            this.cmbEstado.TabIndex = 51;
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDocumento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Items.AddRange(new object[] {
            "DUI",
            "CarnetExtranjero"});
            this.cmbTipoDocumento.Location = new System.Drawing.Point(40, 324);
            this.cmbTipoDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoDocumento.MaxLength = 20;
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(333, 31);
            this.cmbTipoDocumento.TabIndex = 34;
            this.cmbTipoDocumento.SelectedIndexChanged += new System.EventHandler(this.cmbTipoDocumento_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(427, 70);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(56, 20);
            this.lblEstado.TabIndex = 21;
            this.lblEstado.Text = "Estado";
            // 
            // lblDUI
            // 
            this.lblDUI.AutoSize = true;
            this.lblDUI.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDUI.ForeColor = System.Drawing.Color.Black;
            this.lblDUI.Location = new System.Drawing.Point(427, 300);
            this.lblDUI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDUI.Name = "lblDUI";
            this.lblDUI.Size = new System.Drawing.Size(36, 20);
            this.lblDUI.TabIndex = 19;
            this.lblDUI.Text = "DUI";
            // 
            // dtpFechaContratacion
            // 
            this.dtpFechaContratacion.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaContratacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaContratacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaContratacion.Location = new System.Drawing.Point(427, 401);
            this.dtpFechaContratacion.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaContratacion.Name = "dtpFechaContratacion";
            this.dtpFechaContratacion.Size = new System.Drawing.Size(332, 30);
            this.dtpFechaContratacion.TabIndex = 16;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.Black;
            this.lblFecha.Location = new System.Drawing.Point(427, 377);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(129, 20);
            this.lblFecha.TabIndex = 17;
            this.lblFecha.Text = "Fecha de registro";
            // 
            // txtCorreo
            // 
            this.txtCorreo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCorreo.Location = new System.Drawing.Point(427, 249);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCorreo.MaxLength = 100;
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(333, 30);
            this.txtCorreo.TabIndex = 14;
            // 
            // lblCorreo
            // 
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCorreo.ForeColor = System.Drawing.Color.Black;
            this.lblCorreo.Location = new System.Drawing.Point(427, 224);
            this.lblCorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(148, 20);
            this.lblCorreo.TabIndex = 15;
            this.lblCorreo.Text = "Correo electrónico *";
            // 
            // txtCarnet
            // 
            this.txtCarnet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCarnet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCarnet.Location = new System.Drawing.Point(40, 401);
            this.txtCarnet.Margin = new System.Windows.Forms.Padding(4);
            this.txtCarnet.MaxLength = 20;
            this.txtCarnet.Name = "txtCarnet";
            this.txtCarnet.Size = new System.Drawing.Size(333, 30);
            this.txtCarnet.TabIndex = 7;
            // 
            // lblCarnet
            // 
            this.lblCarnet.AutoSize = true;
            this.lblCarnet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCarnet.ForeColor = System.Drawing.Color.Black;
            this.lblCarnet.Location = new System.Drawing.Point(40, 377);
            this.lblCarnet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCarnet.Name = "lblCarnet";
            this.lblCarnet.Size = new System.Drawing.Size(59, 20);
            this.lblCarnet.TabIndex = 10;
            this.lblCarnet.Text = "Carnet ";
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTipo.ForeColor = System.Drawing.Color.Black;
            this.lblTipo.Location = new System.Drawing.Point(40, 300);
            this.lblTipo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(137, 20);
            this.lblTipo.TabIndex = 7;
            this.lblTipo.Text = "Tipo Documento *";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblTelefono.ForeColor = System.Drawing.Color.Black;
            this.lblTelefono.Location = new System.Drawing.Point(40, 224);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(81, 20);
            this.lblTelefono.TabIndex = 6;
            this.lblTelefono.Text = "Teléfono *";
            // 
            // txtApellido
            // 
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtApellido.Location = new System.Drawing.Point(427, 172);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.MaxLength = 100;
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(333, 30);
            this.txtApellido.TabIndex = 2;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblApellido.ForeColor = System.Drawing.Color.Black;
            this.lblApellido.Location = new System.Drawing.Point(427, 148);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(78, 20);
            this.lblApellido.TabIndex = 5;
            this.lblApellido.Text = "Apellido *";
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(40, 172);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(333, 30);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(40, 148);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(78, 20);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Nombre *";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.Location = new System.Drawing.Point(40, 96);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(333, 30);
            this.txtCodigo.TabIndex = 11;
            this.txtCodigo.TabStop = false;
            this.txtCodigo.Text = "Automático";
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.ForeColor = System.Drawing.Color.Black;
            this.lblCodigo.Location = new System.Drawing.Point(40, 71);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(99, 20);
            this.lblCodigo.TabIndex = 2;
            this.lblCodigo.Text = "Identificador";
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
            // lblSeccion
            // 
            this.lblSeccion.AutoSize = true;
            this.lblSeccion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblSeccion.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblSeccion.Location = new System.Drawing.Point(40, 17);
            this.lblSeccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeccion.Name = "lblSeccion";
            this.lblSeccion.Size = new System.Drawing.Size(217, 25);
            this.lblSeccion.TabIndex = 0;
            this.lblSeccion.Text = "Información del cliente";
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
            this.btnCancelar.Location = new System.Drawing.Point(667, 630);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 52);
            this.btnCancelar.TabIndex = 5;
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
            this.btnGuardar.Location = new System.Drawing.Point(480, 630);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(173, 52);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmCreateCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 697);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnlCard);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmCreateCliente";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCreateCliente_Load);
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
        private System.Windows.Forms.TextBox txtCarnet;
        private System.Windows.Forms.Label lblCarnet;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.Label lblDUI;
        private System.Windows.Forms.DateTimePicker dtpFechaContratacion;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbTipoDocumento;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.MaskedTextBox mtxtDUI;
        private System.Windows.Forms.MaskedTextBox mtxtTelefono;
    }
}