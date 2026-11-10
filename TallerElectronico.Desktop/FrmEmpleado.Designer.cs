namespace TallerElectronico.Desktop
{
    partial class FrmEmpleado
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.dgvEmpleado = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDUI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCorreo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHiringDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleado)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 37);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(513, 62);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Gestión de Empleados";
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
            this.btnNuevo.Location = new System.Drawing.Point(36, 249);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(193, 52);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
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
            this.btnEliminar.Location = new System.Drawing.Point(438, 249);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(193, 52);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
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
            this.btnEditar.Location = new System.Drawing.Point(237, 249);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(193, 52);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.Location = new System.Drawing.Point(31, 113);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(483, 28);
            this.label8.TabIndex = 26;
            this.label8.Text = "Consulta, registra, edita o elimina empleados del taller";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(31, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 28);
            this.label6.TabIndex = 48;
            this.label6.Text = "Buscador:";
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.White;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBuscar.Location = new System.Drawing.Point(169, 180);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(477, 32);
            this.txtBuscar.TabIndex = 47;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // dgvEmpleado
            // 
            this.dgvEmpleado.AllowUserToAddRows = false;
            this.dgvEmpleado.AllowUserToDeleteRows = false;
            this.dgvEmpleado.AllowUserToResizeColumns = false;
            this.dgvEmpleado.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.dgvEmpleado.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmpleado.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmpleado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvEmpleado.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmpleado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmpleado.ColumnHeadersHeight = 42;
            this.dgvEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEmpleado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnLastName,
            this.ColumnDUI,
            this.ColumnTelephone,
            this.ColumnCorreo,
            this.ColumnAddress,
            this.ColumnHiringDate,
            this.ColumnEstado});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmpleado.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEmpleado.EnableHeadersVisualStyles = false;
            this.dgvEmpleado.GridColor = System.Drawing.Color.White;
            this.dgvEmpleado.Location = new System.Drawing.Point(36, 327);
            this.dgvEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEmpleado.MultiSelect = false;
            this.dgvEmpleado.Name = "dgvEmpleado";
            this.dgvEmpleado.ReadOnly = true;
            this.dgvEmpleado.RowHeadersVisible = false;
            this.dgvEmpleado.RowHeadersWidth = 51;
            this.dgvEmpleado.RowTemplate.Height = 36;
            this.dgvEmpleado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpleado.Size = new System.Drawing.Size(1250, 424);
            this.dgvEmpleado.TabIndex = 49;
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "Nombre";
            this.ColumnName.FillWeight = 30.28736F;
            this.ColumnName.HeaderText = "Nombre";
            this.ColumnName.MinimumWidth = 6;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            this.ColumnName.Width = 125;
            // 
            // ColumnLastName
            // 
            this.ColumnLastName.DataPropertyName = "Apellido";
            this.ColumnLastName.FillWeight = 30.28736F;
            this.ColumnLastName.HeaderText = "Apellido";
            this.ColumnLastName.MinimumWidth = 6;
            this.ColumnLastName.Name = "ColumnLastName";
            this.ColumnLastName.ReadOnly = true;
            this.ColumnLastName.Width = 125;
            // 
            // ColumnDUI
            // 
            this.ColumnDUI.DataPropertyName = "DUI";
            this.ColumnDUI.FillWeight = 42.75862F;
            this.ColumnDUI.HeaderText = "DUI";
            this.ColumnDUI.MinimumWidth = 6;
            this.ColumnDUI.Name = "ColumnDUI";
            this.ColumnDUI.ReadOnly = true;
            this.ColumnDUI.Width = 85;
            // 
            // ColumnTelephone
            // 
            this.ColumnTelephone.DataPropertyName = "Telefono";
            this.ColumnTelephone.FillWeight = 30.28736F;
            this.ColumnTelephone.HeaderText = "Teléfono";
            this.ColumnTelephone.MinimumWidth = 6;
            this.ColumnTelephone.Name = "ColumnTelephone";
            this.ColumnTelephone.ReadOnly = true;
            this.ColumnTelephone.Width = 85;
            // 
            // ColumnCorreo
            // 
            this.ColumnCorreo.DataPropertyName = "Correo";
            this.ColumnCorreo.FillWeight = 30.28736F;
            this.ColumnCorreo.HeaderText = "Correo";
            this.ColumnCorreo.MinimumWidth = 6;
            this.ColumnCorreo.Name = "ColumnCorreo";
            this.ColumnCorreo.ReadOnly = true;
            this.ColumnCorreo.Width = 185;
            // 
            // ColumnAddress
            // 
            this.ColumnAddress.DataPropertyName = "Direccion";
            this.ColumnAddress.FillWeight = 44.54023F;
            this.ColumnAddress.HeaderText = "Dirección";
            this.ColumnAddress.MinimumWidth = 6;
            this.ColumnAddress.Name = "ColumnAddress";
            this.ColumnAddress.ReadOnly = true;
            this.ColumnAddress.Width = 115;
            // 
            // ColumnHiringDate
            // 
            this.ColumnHiringDate.DataPropertyName = "FechaContratacion";
            this.ColumnHiringDate.FillWeight = 39.1954F;
            this.ColumnHiringDate.HeaderText = "Fecha Contratación";
            this.ColumnHiringDate.MinimumWidth = 6;
            this.ColumnHiringDate.Name = "ColumnHiringDate";
            this.ColumnHiringDate.ReadOnly = true;
            this.ColumnHiringDate.Width = 85;
            // 
            // ColumnEstado
            // 
            this.ColumnEstado.DataPropertyName = "Estado";
            this.ColumnEstado.FillWeight = 26.72414F;
            this.ColumnEstado.HeaderText = "Estado";
            this.ColumnEstado.MinimumWidth = 6;
            this.ColumnEstado.Name = "ColumnEstado";
            this.ColumnEstado.ReadOnly = true;
            this.ColumnEstado.Width = 125;
            // 
            // FrmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1503, 817);
            this.Controls.Add(this.dgvEmpleado);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblTitle);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmEmpleado";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Empleados";
            this.Load += new System.EventHandler(this.FrmEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridView dgvEmpleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDUI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCorreo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHiringDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEstado;
    }
}