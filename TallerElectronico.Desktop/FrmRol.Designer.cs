namespace TallerElectronico.Desktop
{
    partial class FrmRol
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvRol = new System.Windows.Forms.DataGridView();
            this.ColumnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRol)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label8.Location = new System.Drawing.Point(29, 113);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(348, 28);
            this.label8.TabIndex = 44;
            this.label8.Text = "Consulta, registra, edita o elimina roles";
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
            this.btnEditar.Location = new System.Drawing.Point(237, 236);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(193, 52);
            this.btnEditar.TabIndex = 43;
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
            this.btnNuevo.Location = new System.Drawing.Point(34, 236);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(193, 52);
            this.btnNuevo.TabIndex = 41;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblTitle.Location = new System.Drawing.Point(25, 34);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(381, 62);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "Gestión de roles";
            // 
            // dgvRol
            // 
            this.dgvRol.AllowUserToAddRows = false;
            this.dgvRol.AllowUserToDeleteRows = false;
            this.dgvRol.AllowUserToResizeColumns = false;
            this.dgvRol.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.dgvRol.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvRol.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRol.BackgroundColor = System.Drawing.Color.White;
            this.dgvRol.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRol.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRol.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRol.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRol.ColumnHeadersHeight = 42;
            this.dgvRol.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvRol.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCode,
            this.ColumnName,
            this.ColumnStatus});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRol.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRol.EnableHeadersVisualStyles = false;
            this.dgvRol.GridColor = System.Drawing.Color.White;
            this.dgvRol.Location = new System.Drawing.Point(34, 324);
            this.dgvRol.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRol.MultiSelect = false;
            this.dgvRol.Name = "dgvRol";
            this.dgvRol.ReadOnly = true;
            this.dgvRol.RowHeadersVisible = false;
            this.dgvRol.RowHeadersWidth = 51;
            this.dgvRol.RowTemplate.Height = 36;
            this.dgvRol.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRol.Size = new System.Drawing.Size(1229, 375);
            this.dgvRol.TabIndex = 39;
            // 
            // ColumnCode
            // 
            this.ColumnCode.DataPropertyName = "RolId";
            this.ColumnCode.FillWeight = 65F;
            this.ColumnCode.HeaderText = "Identificador";
            this.ColumnCode.MinimumWidth = 6;
            this.ColumnCode.Name = "ColumnCode";
            this.ColumnCode.ReadOnly = true;
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "Nombre";
            this.ColumnName.FillWeight = 85F;
            this.ColumnName.HeaderText = "Nombre";
            this.ColumnName.MinimumWidth = 6;
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.ReadOnly = true;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.DataPropertyName = "Estado";
            this.ColumnStatus.HeaderText = "Estado";
            this.ColumnStatus.MinimumWidth = 6;
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 167);
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
            this.txtBuscar.Location = new System.Drawing.Point(150, 167);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(477, 32);
            this.txtBuscar.TabIndex = 47;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            // 
            // FrmRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1383, 726);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvRol);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmRol";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FrmRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRol)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvRol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
    }
}