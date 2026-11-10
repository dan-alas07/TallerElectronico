namespace TallerElectronico.Desktop
{
    partial class FrmInicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.lblBienvenido = new System.Windows.Forms.Label();
            this.pnlKpiAbiertas = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblKpiAbiertas = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.pnlKpiListas = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblKpiListas = new System.Windows.Forms.Label();
            this.lbl4 = new System.Windows.Forms.Label();
            this.pnlKpiReparadas = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblKpiEntregadas = new System.Windows.Forms.Label();
            this.lbl5 = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.dgvReparaciones = new System.Windows.Forms.DataGridView();
            this.ColumnCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEquipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnResponsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlKpiAbiertas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlKpiListas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.pnlKpiReparadas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReparaciones)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.label1.Location = new System.Drawing.Point(27, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "Taller / Ordenes";
            // 
            // lblBienvenido
            // 
            this.lblBienvenido.AutoSize = true;
            this.lblBienvenido.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenido.Location = new System.Drawing.Point(40, 114);
            this.lblBienvenido.Name = "lblBienvenido";
            this.lblBienvenido.Size = new System.Drawing.Size(241, 31);
            this.lblBienvenido.TabIndex = 1;
            this.lblBienvenido.Text = "Bienvenido/a: Admin";
            // 
            // pnlKpiAbiertas
            // 
            this.pnlKpiAbiertas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.pnlKpiAbiertas.Controls.Add(this.pictureBox1);
            this.pnlKpiAbiertas.Controls.Add(this.lblKpiAbiertas);
            this.pnlKpiAbiertas.Controls.Add(this.lbl3);
            this.pnlKpiAbiertas.Location = new System.Drawing.Point(48, 180);
            this.pnlKpiAbiertas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlKpiAbiertas.Name = "pnlKpiAbiertas";
            this.pnlKpiAbiertas.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.pnlKpiAbiertas.Size = new System.Drawing.Size(373, 150);
            this.pnlKpiAbiertas.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(257, 22);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 110);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblKpiAbiertas
            // 
            this.lblKpiAbiertas.AutoSize = true;
            this.lblKpiAbiertas.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiAbiertas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblKpiAbiertas.Location = new System.Drawing.Point(88, 46);
            this.lblKpiAbiertas.Name = "lblKpiAbiertas";
            this.lblKpiAbiertas.Size = new System.Drawing.Size(70, 81);
            this.lblKpiAbiertas.TabIndex = 1;
            this.lblKpiAbiertas.Text = "0";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl3.Location = new System.Drawing.Point(19, 22);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(203, 28);
            this.lbl3.TabIndex = 0;
            this.lbl3.Text = "ÓRDENES ABIERTAS";
            // 
            // pnlKpiListas
            // 
            this.pnlKpiListas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(250)))), ((int)(((byte)(242)))));
            this.pnlKpiListas.Controls.Add(this.pictureBox2);
            this.pnlKpiListas.Controls.Add(this.lblKpiListas);
            this.pnlKpiListas.Controls.Add(this.lbl4);
            this.pnlKpiListas.Location = new System.Drawing.Point(455, 180);
            this.pnlKpiListas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlKpiListas.Name = "pnlKpiListas";
            this.pnlKpiListas.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.pnlKpiListas.Size = new System.Drawing.Size(373, 150);
            this.pnlKpiListas.TabIndex = 3;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(256, 22);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(95, 110);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // lblKpiListas
            // 
            this.lblKpiListas.AutoSize = true;
            this.lblKpiListas.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiListas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblKpiListas.Location = new System.Drawing.Point(83, 46);
            this.lblKpiListas.Name = "lblKpiListas";
            this.lblKpiListas.Size = new System.Drawing.Size(70, 81);
            this.lblKpiListas.TabIndex = 3;
            this.lblKpiListas.Text = "0";
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl4.Location = new System.Drawing.Point(27, 18);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(173, 28);
            this.lbl4.TabIndex = 2;
            this.lbl4.Text = "ÓRDENES LISTAS";
            // 
            // pnlKpiReparadas
            // 
            this.pnlKpiReparadas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.pnlKpiReparadas.Controls.Add(this.pictureBox3);
            this.pnlKpiReparadas.Controls.Add(this.lblKpiEntregadas);
            this.pnlKpiReparadas.Controls.Add(this.lbl5);
            this.pnlKpiReparadas.Location = new System.Drawing.Point(861, 180);
            this.pnlKpiReparadas.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlKpiReparadas.Name = "pnlKpiReparadas";
            this.pnlKpiReparadas.Padding = new System.Windows.Forms.Padding(11, 10, 11, 10);
            this.pnlKpiReparadas.Size = new System.Drawing.Size(373, 150);
            this.pnlKpiReparadas.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.InitialImage = null;
            this.pictureBox3.Location = new System.Drawing.Point(267, 22);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(95, 110);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // lblKpiEntregadas
            // 
            this.lblKpiEntregadas.AutoSize = true;
            this.lblKpiEntregadas.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKpiEntregadas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.lblKpiEntregadas.Location = new System.Drawing.Point(101, 46);
            this.lblKpiEntregadas.Name = "lblKpiEntregadas";
            this.lblKpiEntregadas.Size = new System.Drawing.Size(70, 81);
            this.lblKpiEntregadas.TabIndex = 3;
            this.lblKpiEntregadas.Text = "0";
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl5.Location = new System.Drawing.Point(19, 18);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(241, 28);
            this.lbl5.TabIndex = 2;
            this.lbl5.Text = "ÓRDENES ENTREGADAS";
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.btnNuevo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.btnNuevo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(4, 4);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(208, 55);
            this.btnNuevo.TabIndex = 51;
            this.btnNuevo.Text = "Nueva Reparación";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.DarkGray;
            this.btnEditar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkGray;
            this.btnEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(220, 4);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(208, 55);
            this.btnEditar.TabIndex = 52;
            this.btnEditar.Text = "Editar Reparación";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // dgvReparaciones
            // 
            this.dgvReparaciones.AllowUserToAddRows = false;
            this.dgvReparaciones.AllowUserToDeleteRows = false;
            this.dgvReparaciones.AllowUserToResizeColumns = false;
            this.dgvReparaciones.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(252)))));
            this.dgvReparaciones.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvReparaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReparaciones.BackgroundColor = System.Drawing.Color.White;
            this.dgvReparaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvReparaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvReparaciones.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvReparaciones.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvReparaciones.ColumnHeadersHeight = 42;
            this.dgvReparaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvReparaciones.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnCode,
            this.ColumnStatus,
            this.ColumnEquipo,
            this.ColumnCliente,
            this.ColumnResponsable,
            this.ColumnTotal});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(72)))));
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(41)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvReparaciones.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvReparaciones.EnableHeadersVisualStyles = false;
            this.dgvReparaciones.GridColor = System.Drawing.Color.White;
            this.dgvReparaciones.Location = new System.Drawing.Point(45, 473);
            this.dgvReparaciones.Margin = new System.Windows.Forms.Padding(4);
            this.dgvReparaciones.MultiSelect = false;
            this.dgvReparaciones.Name = "dgvReparaciones";
            this.dgvReparaciones.ReadOnly = true;
            this.dgvReparaciones.RowHeadersVisible = false;
            this.dgvReparaciones.RowHeadersWidth = 51;
            this.dgvReparaciones.RowTemplate.Height = 36;
            this.dgvReparaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReparaciones.Size = new System.Drawing.Size(1329, 311);
            this.dgvReparaciones.TabIndex = 54;
            // 
            // ColumnCode
            // 
            this.ColumnCode.DataPropertyName = "CodigoSeguimiento";
            this.ColumnCode.FillWeight = 65F;
            this.ColumnCode.HeaderText = "Código";
            this.ColumnCode.MinimumWidth = 6;
            this.ColumnCode.Name = "ColumnCode";
            this.ColumnCode.ReadOnly = true;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.DataPropertyName = "EstadoNombre";
            this.ColumnStatus.FillWeight = 75F;
            this.ColumnStatus.HeaderText = "Estado";
            this.ColumnStatus.MinimumWidth = 6;
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            // 
            // ColumnEquipo
            // 
            this.ColumnEquipo.DataPropertyName = "MarcaNombre";
            this.ColumnEquipo.FillWeight = 85F;
            this.ColumnEquipo.HeaderText = "Equipo";
            this.ColumnEquipo.MinimumWidth = 6;
            this.ColumnEquipo.Name = "ColumnEquipo";
            this.ColumnEquipo.ReadOnly = true;
            // 
            // ColumnCliente
            // 
            this.ColumnCliente.DataPropertyName = "ClienteNombre";
            this.ColumnCliente.FillWeight = 85F;
            this.ColumnCliente.HeaderText = "Cliente";
            this.ColumnCliente.MinimumWidth = 6;
            this.ColumnCliente.Name = "ColumnCliente";
            this.ColumnCliente.ReadOnly = true;
            // 
            // ColumnResponsable
            // 
            this.ColumnResponsable.DataPropertyName = "TecnicoNombre";
            this.ColumnResponsable.FillWeight = 85F;
            this.ColumnResponsable.HeaderText = "Responsable";
            this.ColumnResponsable.MinimumWidth = 6;
            this.ColumnResponsable.Name = "ColumnResponsable";
            this.ColumnResponsable.ReadOnly = true;
            // 
            // ColumnTotal
            // 
            this.ColumnTotal.DataPropertyName = "TotalReparacion";
            this.ColumnTotal.FillWeight = 85F;
            this.ColumnTotal.HeaderText = "Total";
            this.ColumnTotal.MinimumWidth = 6;
            this.ColumnTotal.Name = "ColumnTotal";
            this.ColumnTotal.ReadOnly = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNuevo);
            this.flowLayoutPanel1.Controls.Add(this.btnEditar);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(48, 364);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(449, 69);
            this.flowLayoutPanel1.TabIndex = 55;
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1399, 808);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.dgvReparaciones);
            this.Controls.Add(this.pnlKpiReparadas);
            this.Controls.Add(this.pnlKpiListas);
            this.Controls.Add(this.pnlKpiAbiertas);
            this.Controls.Add(this.lblBienvenido);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmInicio";
            this.ShowIcon = false;
            this.Load += new System.EventHandler(this.FrmInicio_Load);
            this.pnlKpiAbiertas.ResumeLayout(false);
            this.pnlKpiAbiertas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlKpiListas.ResumeLayout(false);
            this.pnlKpiListas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.pnlKpiReparadas.ResumeLayout(false);
            this.pnlKpiReparadas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReparaciones)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblBienvenido;
        private System.Windows.Forms.Panel pnlKpiAbiertas;
        private System.Windows.Forms.Panel pnlKpiListas;
        private System.Windows.Forms.Panel pnlKpiReparadas;
        private System.Windows.Forms.Label lbl3;
        private System.Windows.Forms.Label lblKpiAbiertas;
        private System.Windows.Forms.Label lblKpiListas;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.Label lblKpiEntregadas;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DataGridView dgvReparaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEquipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnResponsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTotal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}