namespace TallerElectronico.Desktop
{
    partial class FrmReparacion
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.dgvCliente = new System.Windows.Forms.DataGridView();
            this.ColumnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTrackingCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnClientCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBrand = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAssignedTechnician = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInitialDiagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEntryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFinalDiagnosis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRepairCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotalCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCreateUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDateModified = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEditUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.White;
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBuscar.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtBuscar.Location = new System.Drawing.Point(21, 127);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(358, 27);
            this.txtBuscar.TabIndex = 46;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(17, 111);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(43, 13);
            this.lblBuscar.TabIndex = 45;
            this.lblBuscar.Text = "Buscar:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(32, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(401, 20);
            this.label8.TabIndex = 44;
            this.label8.Text = "Consulta, registra, edita o elimina reparaciones del taller";
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
            this.btnEditar.Location = new System.Drawing.Point(170, 189);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(145, 42);
            this.btnEditar.TabIndex = 43;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
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
            this.btnEliminar.Location = new System.Drawing.Point(321, 189);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(145, 42);
            this.btnEliminar.TabIndex = 42;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(78)))), ((int)(((byte)(120)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnBuscar.ForeColor = System.Drawing.Color.White;
            this.btnBuscar.Location = new System.Drawing.Point(384, 127);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 47;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
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
            this.btnNuevo.Location = new System.Drawing.Point(19, 189);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(145, 42);
            this.btnNuevo.TabIndex = 41;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(404, 50);
            this.lblTitle.TabIndex = 40;
            this.lblTitle.Text = "Gestión de reparación";
            // 
            // dgvCliente
            // 
            this.dgvCliente.AllowUserToAddRows = false;
            this.dgvCliente.AllowUserToDeleteRows = false;
            this.dgvCliente.AllowUserToResizeColumns = false;
            this.dgvCliente.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.dgvCliente.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCliente.BackgroundColor = System.Drawing.Color.White;
            this.dgvCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCliente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCliente.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCliente.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCliente.ColumnHeadersHeight = 42;
            this.dgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCode,
            this.ColumnTrackingCode,
            this.ColumnClientCode,
            this.ColumnDeviceType,
            this.ColumnBrand,
            this.ColumnModel,
            this.ColumnAssignedTechnician,
            this.ColumnInitialDiagnosis,
            this.ColumnEntryDate,
            this.ColumnFinalDiagnosis,
            this.ColumnDeliveryDate,
            this.ColumnRepairCost,
            this.ColumnTotalCost,
            this.ColumnCreateUser,
            this.ColumnDateModified,
            this.ColumnEditUser,
            this.ColumnStatus});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCliente.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCliente.EnableHeadersVisualStyles = false;
            this.dgvCliente.GridColor = System.Drawing.Color.White;
            this.dgvCliente.Location = new System.Drawing.Point(19, 248);
            this.dgvCliente.MultiSelect = false;
            this.dgvCliente.Name = "dgvCliente";
            this.dgvCliente.ReadOnly = true;
            this.dgvCliente.RowHeadersVisible = false;
            this.dgvCliente.RowHeadersWidth = 51;
            this.dgvCliente.RowTemplate.Height = 36;
            this.dgvCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCliente.Size = new System.Drawing.Size(1080, 215);
            this.dgvCliente.TabIndex = 39;
            // 
            // ColumnCode
            // 
            this.ColumnCode.DataPropertyName = "ReparacionId";
            this.ColumnCode.FillWeight = 65F;
            this.ColumnCode.HeaderText = "Código";
            this.ColumnCode.MinimumWidth = 6;
            this.ColumnCode.Name = "ColumnCode";
            this.ColumnCode.ReadOnly = true;
            // 
            // ColumnTrackingCode
            // 
            this.ColumnTrackingCode.DataPropertyName = "CodigoSeguimiento";
            this.ColumnTrackingCode.FillWeight = 85F;
            this.ColumnTrackingCode.HeaderText = "Codigo de seguimiento";
            this.ColumnTrackingCode.MinimumWidth = 6;
            this.ColumnTrackingCode.Name = "ColumnTrackingCode";
            this.ColumnTrackingCode.ReadOnly = true;
            // 
            // ColumnClientCode
            // 
            this.ColumnClientCode.DataPropertyName = "ClienteId";
            this.ColumnClientCode.FillWeight = 85F;
            this.ColumnClientCode.HeaderText = "Código Cliente";
            this.ColumnClientCode.MinimumWidth = 6;
            this.ColumnClientCode.Name = "ColumnClientCode";
            this.ColumnClientCode.ReadOnly = true;
            // 
            // ColumnDeviceType
            // 
            this.ColumnDeviceType.DataPropertyName = "TipoEquipoId";
            this.ColumnDeviceType.FillWeight = 85F;
            this.ColumnDeviceType.HeaderText = "Tipo Equipo";
            this.ColumnDeviceType.MinimumWidth = 6;
            this.ColumnDeviceType.Name = "ColumnDeviceType";
            this.ColumnDeviceType.ReadOnly = true;
            // 
            // ColumnBrand
            // 
            this.ColumnBrand.DataPropertyName = "MarcaId";
            this.ColumnBrand.FillWeight = 85F;
            this.ColumnBrand.HeaderText = "Marca";
            this.ColumnBrand.MinimumWidth = 6;
            this.ColumnBrand.Name = "ColumnBrand";
            this.ColumnBrand.ReadOnly = true;
            // 
            // ColumnModel
            // 
            this.ColumnModel.DataPropertyName = "Modelo";
            this.ColumnModel.FillWeight = 125F;
            this.ColumnModel.HeaderText = "Modelo";
            this.ColumnModel.MinimumWidth = 6;
            this.ColumnModel.Name = "ColumnModel";
            this.ColumnModel.ReadOnly = true;
            // 
            // ColumnAssignedTechnician
            // 
            this.ColumnAssignedTechnician.DataPropertyName = "TecnicoAsignadoId";
            this.ColumnAssignedTechnician.FillWeight = 120F;
            this.ColumnAssignedTechnician.HeaderText = "Tecnico Asignado";
            this.ColumnAssignedTechnician.MinimumWidth = 6;
            this.ColumnAssignedTechnician.Name = "ColumnAssignedTechnician";
            this.ColumnAssignedTechnician.ReadOnly = true;
            // 
            // ColumnInitialDiagnosis
            // 
            this.ColumnInitialDiagnosis.DataPropertyName = "DiagnosticoInicial";
            this.ColumnInitialDiagnosis.FillWeight = 110F;
            this.ColumnInitialDiagnosis.HeaderText = "Diagnostico Inicial";
            this.ColumnInitialDiagnosis.MinimumWidth = 6;
            this.ColumnInitialDiagnosis.Name = "ColumnInitialDiagnosis";
            this.ColumnInitialDiagnosis.ReadOnly = true;
            // 
            // ColumnEntryDate
            // 
            this.ColumnEntryDate.DataPropertyName = "FechaIngreso";
            this.ColumnEntryDate.FillWeight = 75F;
            this.ColumnEntryDate.HeaderText = "Fecha Ingreso";
            this.ColumnEntryDate.MinimumWidth = 6;
            this.ColumnEntryDate.Name = "ColumnEntryDate";
            this.ColumnEntryDate.ReadOnly = true;
            // 
            // ColumnFinalDiagnosis
            // 
            this.ColumnFinalDiagnosis.DataPropertyName = "DiagnosticoFinal";
            this.ColumnFinalDiagnosis.HeaderText = "Diagnostico Final";
            this.ColumnFinalDiagnosis.Name = "ColumnFinalDiagnosis";
            this.ColumnFinalDiagnosis.ReadOnly = true;
            // 
            // ColumnDeliveryDate
            // 
            this.ColumnDeliveryDate.DataPropertyName = "FechaEntrega";
            this.ColumnDeliveryDate.HeaderText = "Fecha Entrega";
            this.ColumnDeliveryDate.Name = "ColumnDeliveryDate";
            this.ColumnDeliveryDate.ReadOnly = true;
            // 
            // ColumnRepairCost
            // 
            this.ColumnRepairCost.DataPropertyName = "CostoManoObra";
            this.ColumnRepairCost.HeaderText = "Costo Servicio";
            this.ColumnRepairCost.Name = "ColumnRepairCost";
            this.ColumnRepairCost.ReadOnly = true;
            // 
            // ColumnTotalCost
            // 
            this.ColumnTotalCost.DataPropertyName = "TotalReparacion";
            this.ColumnTotalCost.HeaderText = "Total Reparación";
            this.ColumnTotalCost.Name = "ColumnTotalCost";
            this.ColumnTotalCost.ReadOnly = true;
            // 
            // ColumnCreateUser
            // 
            this.ColumnCreateUser.DataPropertyName = "UsuarioCreacionId";
            this.ColumnCreateUser.HeaderText = "Creado";
            this.ColumnCreateUser.Name = "ColumnCreateUser";
            this.ColumnCreateUser.ReadOnly = true;
            // 
            // ColumnDateModified
            // 
            this.ColumnDateModified.DataPropertyName = "FechaModificacion";
            this.ColumnDateModified.HeaderText = "Fecha Modificación";
            this.ColumnDateModified.Name = "ColumnDateModified";
            this.ColumnDateModified.ReadOnly = true;
            // 
            // ColumnEditUser
            // 
            this.ColumnEditUser.DataPropertyName = "UsuarioModicacionId";
            this.ColumnEditUser.HeaderText = "Modificado";
            this.ColumnEditUser.Name = "ColumnEditUser";
            this.ColumnEditUser.ReadOnly = true;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.DataPropertyName = "Estado";
            this.ColumnStatus.HeaderText = "Estado";
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            // 
            // FrmReparacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 470);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvCliente);
            this.Name = "FrmReparacion";
            this.Text = "FrmReparacion";
            this.Load += new System.EventHandler(this.FrmReparacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTrackingCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnClientCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeviceType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBrand;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAssignedTechnician;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInitialDiagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEntryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFinalDiagnosis;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeliveryDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRepairCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotalCost;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCreateUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDateModified;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEditUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
    }
}