namespace TallerElectronico.Desktop
{
    partial class FrmEditDetalleReparacion
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
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblReparacion = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.cmbReparacion = new System.Windows.Forms.ComboBox();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.dtpFechaUso = new System.Windows.Forms.DateTimePicker();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.nudCantidadStock = new System.Windows.Forms.NumericUpDown();
            this.txtUsuarioModificacion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadStock)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProducto
            // 
            this.cmbProducto.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbProducto.FormattingEnabled = true;
            this.cmbProducto.Location = new System.Drawing.Point(59, 329);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new System.Drawing.Size(386, 31);
            this.cmbProducto.TabIndex = 48;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 23F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblTitulo.Location = new System.Drawing.Point(50, 38);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(486, 52);
            this.lblTitulo.TabIndex = 34;
            this.lblTitulo.Text = "Editar Detalle Reparación";
            // 
            // lblReparacion
            // 
            this.lblReparacion.AutoSize = true;
            this.lblReparacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReparacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblReparacion.Location = new System.Drawing.Point(56, 212);
            this.lblReparacion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblReparacion.Name = "lblReparacion";
            this.lblReparacion.Size = new System.Drawing.Size(104, 23);
            this.lblReparacion.TabIndex = 36;
            this.lblReparacion.Text = "Reparación:";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProducto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblProducto.Location = new System.Drawing.Point(56, 297);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(88, 23);
            this.lblProducto.TabIndex = 39;
            this.lblProducto.Text = "Producto:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCantidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblCantidad.Location = new System.Drawing.Point(56, 392);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(157, 23);
            this.lblCantidad.TabIndex = 40;
            this.lblCantidad.Text = "Cantidad utlizada:";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPrecio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblPrecio.Location = new System.Drawing.Point(506, 130);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(206, 23);
            this.lblPrecio.TabIndex = 41;
            this.lblPrecio.Text = "Precio unitario histórico:";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblSubtotal.Location = new System.Drawing.Point(510, 215);
            this.lblSubtotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(84, 23);
            this.lblSubtotal.TabIndex = 42;
            this.lblSubtotal.Text = "Subtotal:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblFecha.Location = new System.Drawing.Point(506, 310);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(117, 23);
            this.lblFecha.TabIndex = 46;
            this.lblFecha.Text = "Fecha de uso:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrecio.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPrecio.Location = new System.Drawing.Point(510, 165);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecio.MaxLength = 50;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(386, 30);
            this.txtPrecio.TabIndex = 35;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(510, 524);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(193, 52);
            this.btnGuardar.TabIndex = 44;
            this.btnGuardar.Text = "Guardar cambios";
            this.btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(228)))), ((int)(((byte)(233)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(716, 524);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(193, 52);
            this.btnCancelar.TabIndex = 45;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            // 
            // cmbReparacion
            // 
            this.cmbReparacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbReparacion.FormattingEnabled = true;
            this.cmbReparacion.Location = new System.Drawing.Point(59, 247);
            this.cmbReparacion.Name = "cmbReparacion";
            this.cmbReparacion.Size = new System.Drawing.Size(386, 31);
            this.cmbReparacion.TabIndex = 49;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubtotal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSubtotal.Location = new System.Drawing.Point(510, 247);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubtotal.MaxLength = 50;
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(386, 30);
            this.txtSubtotal.TabIndex = 50;
            // 
            // dtpFechaUso
            // 
            this.dtpFechaUso.CalendarFont = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaUso.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaUso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaUso.Location = new System.Drawing.Point(510, 337);
            this.dtpFechaUso.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaUso.Name = "dtpFechaUso";
            this.dtpFechaUso.Size = new System.Drawing.Size(386, 30);
            this.dtpFechaUso.TabIndex = 51;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCodigo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblCodigo.Location = new System.Drawing.Point(55, 130);
            this.lblCodigo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(158, 23);
            this.lblCodigo.TabIndex = 52;
            this.lblCodigo.Text = "Código de detalle:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.White;
            this.txtCodigo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigo.Enabled = false;
            this.txtCodigo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCodigo.Location = new System.Drawing.Point(59, 165);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(386, 30);
            this.txtCodigo.TabIndex = 53;
            this.txtCodigo.TabStop = false;
            // 
            // nudCantidadStock
            // 
            this.nudCantidadStock.Location = new System.Drawing.Point(60, 427);
            this.nudCantidadStock.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCantidadStock.Name = "nudCantidadStock";
            this.nudCantidadStock.ReadOnly = true;
            this.nudCantidadStock.Size = new System.Drawing.Size(385, 22);
            this.nudCantidadStock.TabIndex = 76;
            this.nudCantidadStock.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtUsuarioModificacion
            // 
            this.txtUsuarioModificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarioModificacion.Enabled = false;
            this.txtUsuarioModificacion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsuarioModificacion.Location = new System.Drawing.Point(510, 419);
            this.txtUsuarioModificacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtUsuarioModificacion.MaxLength = 50;
            this.txtUsuarioModificacion.Name = "txtUsuarioModificacion";
            this.txtUsuarioModificacion.Size = new System.Drawing.Size(386, 30);
            this.txtUsuarioModificacion.TabIndex = 85;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.label1.Location = new System.Drawing.Point(506, 392);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 23);
            this.label1.TabIndex = 86;
            this.label1.Text = "Usuario Modificacion:";
            // 
            // FrmEditDetalleReparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 615);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsuarioModificacion);
            this.Controls.Add(this.nudCantidadStock);
            this.Controls.Add(this.lblCodigo);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.dtpFechaUso);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.cmbReparacion);
            this.Controls.Add(this.cmbProducto);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblReparacion);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblSubtotal);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Name = "FrmEditDetalleReparacion";
            this.ShowIcon = false;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FrmEditDetalleReparacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblReparacion;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ComboBox cmbReparacion;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.DateTimePicker dtpFechaUso;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.NumericUpDown nudCantidadStock;
        private System.Windows.Forms.TextBox txtUsuarioModificacion;
        private System.Windows.Forms.Label label1;
    }
}