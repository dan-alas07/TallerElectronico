namespace TallerElectronico.Desktop
{
    partial class FrmEmpleado
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
            this.dgvEmpleado = new System.Windows.Forms.DataGridView();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ColumnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDUI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTelephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHiringDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCreate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleado)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmpleado
            // 
            this.dgvEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCode,
            this.ColumnName,
            this.ColumnLastName,
            this.ColumnDUI,
            this.ColumnTelephone,
            this.ColumnEmail,
            this.ColumnAddress,
            this.ColumnHiringDate,
            this.ColumnStatus});
            this.dgvEmpleado.Location = new System.Drawing.Point(40, 324);
            this.dgvEmpleado.Name = "dgvEmpleado";
            this.dgvEmpleado.Size = new System.Drawing.Size(973, 79);
            this.dgvEmpleado.TabIndex = 1;
            this.dgvEmpleado.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(36, 285);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(176, 21);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Listado de Empleados";
            // 
            // ColumnCode
            // 
            this.ColumnCode.HeaderText = "Código";
            this.ColumnCode.Name = "ColumnCode";
            this.ColumnCode.Width = 80;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "Nombre";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnLastName
            // 
            this.ColumnLastName.HeaderText = "Apellido";
            this.ColumnLastName.Name = "ColumnLastName";
            // 
            // ColumnDUI
            // 
            this.ColumnDUI.HeaderText = "DUI";
            this.ColumnDUI.Name = "ColumnDUI";
            // 
            // ColumnTelephone
            // 
            this.ColumnTelephone.HeaderText = "Teléfono";
            this.ColumnTelephone.Name = "ColumnTelephone";
            // 
            // ColumnEmail
            // 
            this.ColumnEmail.HeaderText = "Correo";
            this.ColumnEmail.Name = "ColumnEmail";
            // 
            // ColumnAddress
            // 
            this.ColumnAddress.HeaderText = "Dirección";
            this.ColumnAddress.Name = "ColumnAddress";
            // 
            // ColumnHiringDate
            // 
            this.ColumnHiringDate.HeaderText = "Fecha de Contratación";
            this.ColumnHiringDate.Name = "ColumnHiringDate";
            this.ColumnHiringDate.Width = 150;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.HeaderText = "Estado";
            this.ColumnStatus.Name = "ColumnStatus";
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.SystemColors.Window;
            this.btnCreate.Location = new System.Drawing.Point(40, 259);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "NUEVO";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // FrmEmpleado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1029, 450);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvEmpleado);
            this.Name = "FrmEmpleado";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FrmEmpleado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvEmpleado;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDUI;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTelephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnHiringDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.Button btnCreate;
    }
}