namespace TallerElectronico.Desktop
{
    partial class FrmDetalleReparacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvDetalleReparacion = new System.Windows.Forms.DataGridView();
            this.ColumnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRepairCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnQuantiyUses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSubtotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUseDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleReparacion)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.White;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBuscar.Location = new System.Drawing.Point(37, 174);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(477, 32);
            this.txtBuscar.TabIndex = 55;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(35, 153);
            this.lblBuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(52, 16);
            this.lblBuscar.TabIndex = 54;
            this.lblBuscar.Text = "Buscar:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.Location = new System.Drawing.Point(31, 110);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(595, 28);
            this.label8.TabIndex = 53;
            this.label8.Text = "Consulta, registra, edita y elimina detalles de reparaciones del taller";
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.DarkGray;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(205, 4);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(193, 52);
            this.btnEditar.TabIndex = 52;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(4, 4);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(193, 52);
            this.btnNuevo.TabIndex = 50;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 33);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(758, 62);
            this.lblTitle.TabIndex = 49;
            this.lblTitle.Text = "Gestión de detalles de reparación";
            // 
            // dgvDetalleReparacion
            // 
            this.dgvDetalleReparacion.AllowUserToAddRows = false;
            this.dgvDetalleReparacion.AllowUserToDeleteRows = false;
            this.dgvDetalleReparacion.AllowUserToResizeColumns = false;
            this.dgvDetalleReparacion.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.dgvDetalleReparacion.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalleReparacion.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalleReparacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDetalleReparacion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDetalleReparacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDetalleReparacion.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDetalleReparacion.ColumnHeadersHeight = 42;
            this.dgvDetalleReparacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetalleReparacion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCode,
            this.ColumnRepairCode,
            this.ColumnProductCode,
            this.ColumnQuantiyUses,
            this.ColumnUnitPrice,
            this.ColumnSubtotal,
            this.ColumnUseDate});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalleReparacion.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvDetalleReparacion.EnableHeadersVisualStyles = false;
            this.dgvDetalleReparacion.GridColor = System.Drawing.Color.White;
            this.dgvDetalleReparacion.Location = new System.Drawing.Point(40, 318);
            this.dgvDetalleReparacion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDetalleReparacion.MultiSelect = false;
            this.dgvDetalleReparacion.Name = "dgvDetalleReparacion";
            this.dgvDetalleReparacion.ReadOnly = true;
            this.dgvDetalleReparacion.RowHeadersVisible = false;
            this.dgvDetalleReparacion.RowHeadersWidth = 51;
            this.dgvDetalleReparacion.RowTemplate.Height = 36;
            this.dgvDetalleReparacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalleReparacion.Size = new System.Drawing.Size(1479, 347);
            this.dgvDetalleReparacion.TabIndex = 48;
            this.dgvDetalleReparacion.SelectionChanged += new System.EventHandler(this.dgvDetalleReparacion_SelectionChanged);
            // 
            // ColumnCode
            // 
            this.ColumnCode.DataPropertyName = "DetalleReparacionId";
            this.ColumnCode.FillWeight = 5.826476F;
            this.ColumnCode.HeaderText = "Identificador";
            this.ColumnCode.MinimumWidth = 6;
            this.ColumnCode.Name = "ColumnCode";
            this.ColumnCode.ReadOnly = true;
            this.ColumnCode.Width = 90;
            // 
            // ColumnRepairCode
            // 
            this.ColumnRepairCode.DataPropertyName = "ReparacionCodigo";
            this.ColumnRepairCode.FillWeight = 32.50875F;
            this.ColumnRepairCode.HeaderText = "Código Reparación";
            this.ColumnRepairCode.MinimumWidth = 6;
            this.ColumnRepairCode.Name = "ColumnRepairCode";
            this.ColumnRepairCode.ReadOnly = true;
            this.ColumnRepairCode.Width = 175;
            // 
            // ColumnProductCode
            // 
            this.ColumnProductCode.DataPropertyName = "ProductoNombre";
            this.ColumnProductCode.FillWeight = 32.50875F;
            this.ColumnProductCode.HeaderText = "Producto";
            this.ColumnProductCode.MinimumWidth = 6;
            this.ColumnProductCode.Name = "ColumnProductCode";
            this.ColumnProductCode.ReadOnly = true;
            this.ColumnProductCode.Width = 250;
            // 
            // ColumnQuantiyUses
            // 
            this.ColumnQuantiyUses.DataPropertyName = "CantidadUtilizada";
            this.ColumnQuantiyUses.FillWeight = 32.50875F;
            this.ColumnQuantiyUses.HeaderText = "Cantidad";
            this.ColumnQuantiyUses.MinimumWidth = 6;
            this.ColumnQuantiyUses.Name = "ColumnQuantiyUses";
            this.ColumnQuantiyUses.ReadOnly = true;
            this.ColumnQuantiyUses.Width = 125;
            // 
            // ColumnUnitPrice
            // 
            this.ColumnUnitPrice.DataPropertyName = "PrecioUnitarioHistorico";
            dataGridViewCellStyle3.Format = "$#,##0.00";
            this.ColumnUnitPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnUnitPrice.FillWeight = 32.50875F;
            this.ColumnUnitPrice.HeaderText = "Precio Unitario";
            this.ColumnUnitPrice.MinimumWidth = 6;
            this.ColumnUnitPrice.Name = "ColumnUnitPrice";
            this.ColumnUnitPrice.ReadOnly = true;
            this.ColumnUnitPrice.Width = 125;
            // 
            // ColumnSubtotal
            // 
            this.ColumnSubtotal.DataPropertyName = "Subtotal";
            dataGridViewCellStyle4.Format = "$#,##0.00";
            this.ColumnSubtotal.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnSubtotal.FillWeight = 47.80698F;
            this.ColumnSubtotal.HeaderText = "Subtotal";
            this.ColumnSubtotal.MinimumWidth = 6;
            this.ColumnSubtotal.Name = "ColumnSubtotal";
            this.ColumnSubtotal.ReadOnly = true;
            this.ColumnSubtotal.Width = 125;
            // 
            // ColumnUseDate
            // 
            this.ColumnUseDate.DataPropertyName = "FechaUso";
            this.ColumnUseDate.FillWeight = 45.8947F;
            this.ColumnUseDate.HeaderText = "Fecha Uso";
            this.ColumnUseDate.MinimumWidth = 6;
            this.ColumnUseDate.Name = "ColumnUseDate";
            this.ColumnUseDate.ReadOnly = true;
            this.ColumnUseDate.Width = 200;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.DarkGray;
            this.btnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnEliminar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(78)))), ((int)(((byte)(216)))));
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(406, 4);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(193, 52);
            this.btnEliminar.TabIndex = 57;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNuevo);
            this.flowLayoutPanel1.Controls.Add(this.btnEditar);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminar);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(36, 230);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(609, 62);
            this.flowLayoutPanel1.TabIndex = 58;
            // 
            // FrmDetalleReparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1685, 695);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvDetalleReparacion);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmDetalleReparacion";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FrmDetalleReparacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleReparacion)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvDetalleReparacion;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRepairCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnQuantiyUses;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSubtotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUseDate;
    }
}