namespace TallerElectronico.Desktop
{
    partial class FrmCreateProducto
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
            this.nudCantidadStock = new System.Windows.Forms.NumericUpDown();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.lblPrecioUnitario = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblCantidadStock = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblProveedorId = new System.Windows.Forms.Label();
            this.txtCodigoProducto = new System.Windows.Forms.TextBox();
            this.lblCodigoProducto = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.pnlLinea = new System.Windows.Forms.Panel();
            this.lblSeccion = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadStock)).BeginInit();
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
            this.btnCancelar.Location = new System.Drawing.Point(657, 703);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(173, 52);
            this.btnCancelar.TabIndex = 6;
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
            this.btnGuardar.Location = new System.Drawing.Point(467, 703);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(173, 52);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pnlCard
            // 
            this.pnlCard.BackColor = System.Drawing.Color.White;
            this.pnlCard.Controls.Add(this.nudCantidadStock);
            this.pnlCard.Controls.Add(this.txtNombre);
            this.pnlCard.Controls.Add(this.cmbProveedor);
            this.pnlCard.Controls.Add(this.cmbEstado);
            this.pnlCard.Controls.Add(this.txtPrecioUnitario);
            this.pnlCard.Controls.Add(this.lblPrecioUnitario);
            this.pnlCard.Controls.Add(this.txtDescripcion);
            this.pnlCard.Controls.Add(this.lblDescripcion);
            this.pnlCard.Controls.Add(this.lblCantidadStock);
            this.pnlCard.Controls.Add(this.lblNombre);
            this.pnlCard.Controls.Add(this.lblProveedorId);
            this.pnlCard.Controls.Add(this.txtCodigoProducto);
            this.pnlCard.Controls.Add(this.lblCodigoProducto);
            this.pnlCard.Controls.Add(this.lblEstado);
            this.pnlCard.Controls.Add(this.txtCodigo);
            this.pnlCard.Controls.Add(this.lblCodigo);
            this.pnlCard.Controls.Add(this.pnlLinea);
            this.pnlCard.Controls.Add(this.lblSeccion);
            this.pnlCard.Location = new System.Drawing.Point(40, 146);
            this.pnlCard.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlCard.Name = "pnlCard";
            this.pnlCard.Size = new System.Drawing.Size(800, 523);
            this.pnlCard.TabIndex = 4;
            // 
            // nudCantidadStock
            // 
            this.nudCantidadStock.Location = new System.Drawing.Point(40, 332);
            this.nudCantidadStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudCantidadStock.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidadStock.Name = "nudCantidadStock";
            this.nudCantidadStock.ReadOnly = true;
            this.nudCantidadStock.Size = new System.Drawing.Size(333, 22);
            this.nudCantidadStock.TabIndex = 64;
            this.nudCantidadStock.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtNombre
            // 
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(40, 249);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.MaxLength = 100;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(333, 30);
            this.txtNombre.TabIndex = 61;
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProveedor.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Items.AddRange(new object[] {
            "Persona Natural",
            "Persona Jurídica"});
            this.cmbProveedor.Location = new System.Drawing.Point(427, 249);
            this.cmbProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(333, 31);
            this.cmbProveedor.TabIndex = 60;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstado.Location = new System.Drawing.Point(427, 325);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(333, 31);
            this.cmbEstado.TabIndex = 50;
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecioUnitario.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecioUnitario.Location = new System.Drawing.Point(427, 174);
            this.txtPrecioUnitario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPrecioUnitario.MaxLength = 10;
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(333, 30);
            this.txtPrecioUnitario.TabIndex = 17;
            this.txtPrecioUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioUnitario_KeyPress);
            // 
            // lblPrecioUnitario
            // 
            this.lblPrecioUnitario.AutoSize = true;
            this.lblPrecioUnitario.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblPrecioUnitario.ForeColor = System.Drawing.Color.Black;
            this.lblPrecioUnitario.Location = new System.Drawing.Point(427, 148);
            this.lblPrecioUnitario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecioUnitario.Name = "lblPrecioUnitario";
            this.lblPrecioUnitario.Size = new System.Drawing.Size(124, 20);
            this.lblPrecioUnitario.TabIndex = 18;
            this.lblPrecioUnitario.Text = "Precio Unitario *";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDescripcion.Location = new System.Drawing.Point(40, 398);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescripcion.MaxLength = 250;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(719, 30);
            this.txtDescripcion.TabIndex = 7;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDescripcion.ForeColor = System.Drawing.Color.Black;
            this.lblDescripcion.Location = new System.Drawing.Point(40, 374);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(101, 20);
            this.lblDescripcion.TabIndex = 10;
            this.lblDescripcion.Text = "Descripción *";
            // 
            // lblCantidadStock
            // 
            this.lblCantidadStock.AutoSize = true;
            this.lblCantidadStock.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCantidadStock.ForeColor = System.Drawing.Color.Black;
            this.lblCantidadStock.Location = new System.Drawing.Point(40, 300);
            this.lblCantidadStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidadStock.Name = "lblCantidadStock";
            this.lblCantidadStock.Size = new System.Drawing.Size(82, 20);
            this.lblCantidadStock.TabIndex = 8;
            this.lblCantidadStock.Text = "Cantidad *";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNombre.ForeColor = System.Drawing.Color.Black;
            this.lblNombre.Location = new System.Drawing.Point(40, 224);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(78, 20);
            this.lblNombre.TabIndex = 6;
            this.lblNombre.Text = "Nombre *";
            // 
            // lblProveedorId
            // 
            this.lblProveedorId.AutoSize = true;
            this.lblProveedorId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblProveedorId.ForeColor = System.Drawing.Color.Black;
            this.lblProveedorId.Location = new System.Drawing.Point(427, 225);
            this.lblProveedorId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProveedorId.Name = "lblProveedorId";
            this.lblProveedorId.Size = new System.Drawing.Size(92, 20);
            this.lblProveedorId.TabIndex = 5;
            this.lblProveedorId.Text = "Proveedor *";
            // 
            // txtCodigoProducto
            // 
            this.txtCodigoProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoProducto.Enabled = false;
            this.txtCodigoProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigoProducto.Location = new System.Drawing.Point(40, 172);
            this.txtCodigoProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCodigoProducto.MaxLength = 50;
            this.txtCodigoProducto.Name = "txtCodigoProducto";
            this.txtCodigoProducto.Size = new System.Drawing.Size(333, 30);
            this.txtCodigoProducto.TabIndex = 1;
            // 
            // lblCodigoProducto
            // 
            this.lblCodigoProducto.AutoSize = true;
            this.lblCodigoProducto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCodigoProducto.ForeColor = System.Drawing.Color.Black;
            this.lblCodigoProducto.Location = new System.Drawing.Point(40, 148);
            this.lblCodigoProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigoProducto.Name = "lblCodigoProducto";
            this.lblCodigoProducto.Size = new System.Drawing.Size(137, 20);
            this.lblCodigoProducto.TabIndex = 4;
            this.lblCodigoProducto.Text = "Código Producto *";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEstado.ForeColor = System.Drawing.Color.Black;
            this.lblEstado.Location = new System.Drawing.Point(427, 300);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(56, 20);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.Location = new System.Drawing.Point(40, 96);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.pnlLinea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.lblSeccion.Size = new System.Drawing.Size(243, 25);
            this.lblSeccion.TabIndex = 0;
            this.lblSeccion.Text = "Información del producto";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.DarkBlue;
            this.pnlHeader.Controls.Add(this.lblSubtitulo);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(880, 101);
            this.pnlHeader.TabIndex = 7;
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblSubtitulo.ForeColor = System.Drawing.Color.White;
            this.lblSubtitulo.Location = new System.Drawing.Point(40, 53);
            this.lblSubtitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(407, 21);
            this.lblSubtitulo.TabIndex = 1;
            this.lblSubtitulo.Text = "Completa los datos necesarios para registrar un producto";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(37, 12);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(247, 41);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Nuevo Producto";
            // 
            // FrmCreateProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 790);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pnlCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "FrmCreateProducto";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmCreateProducto_Load);
            this.pnlCard.ResumeLayout(false);
            this.pnlCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadStock)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Panel pnlCard;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblCantidadStock;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblProveedorId;
        private System.Windows.Forms.TextBox txtCodigoProducto;
        private System.Windows.Forms.Label lblCodigoProducto;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Panel pnlLinea;
        private System.Windows.Forms.Label lblSeccion;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.Label lblPrecioUnitario;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.NumericUpDown nudCantidadStock;
    }
}