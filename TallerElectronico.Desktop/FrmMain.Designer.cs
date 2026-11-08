namespace TallerElectronico.Desktop
{
    partial class FrmMain
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnMain = new System.Windows.Forms.Button();
            this.btnCliente = new System.Windows.Forms.Button();
            this.btnEquipo = new System.Windows.Forms.Button();
            this.btnEmpleado = new System.Windows.Forms.Button();
            this.btnRol = new System.Windows.Forms.Button();
            this.btnUsuario = new System.Windows.Forms.Button();
            this.btnProveedor = new System.Windows.Forms.Button();
            this.btnProducto = new System.Windows.Forms.Button();
            this.btnMarca = new System.Windows.Forms.Button();
            this.btnEstadoReparacion = new System.Windows.Forms.Button();
            this.btnReparacion = new System.Windows.Forms.Button();
            this.btnDetalleReparacion = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.pnlMain.Controls.Add(this.flowLayoutPanel1);
            this.pnlMain.Controls.Add(this.btnSalir);
            this.pnlMain.Controls.Add(this.label1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(293, 922);
            this.pnlMain.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(58)))), ((int)(((byte)(95)))));
            this.flowLayoutPanel1.Controls.Add(this.btnMain);
            this.flowLayoutPanel1.Controls.Add(this.btnCliente);
            this.flowLayoutPanel1.Controls.Add(this.btnEquipo);
            this.flowLayoutPanel1.Controls.Add(this.btnEmpleado);
            this.flowLayoutPanel1.Controls.Add(this.btnRol);
            this.flowLayoutPanel1.Controls.Add(this.btnUsuario);
            this.flowLayoutPanel1.Controls.Add(this.btnProveedor);
            this.flowLayoutPanel1.Controls.Add(this.btnProducto);
            this.flowLayoutPanel1.Controls.Add(this.btnMarca);
            this.flowLayoutPanel1.Controls.Add(this.btnEstadoReparacion);
            this.flowLayoutPanel1.Controls.Add(this.btnReparacion);
            this.flowLayoutPanel1.Controls.Add(this.btnDetalleReparacion);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(27, 123);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(239, 695);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnMain
            // 
            this.btnMain.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMain.FlatAppearance.BorderSize = 0;
            this.btnMain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMain.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMain.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMain.Location = new System.Drawing.Point(4, 4);
            this.btnMain.Margin = new System.Windows.Forms.Padding(4);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(216, 49);
            this.btnMain.TabIndex = 1;
            this.btnMain.Text = "Inicio";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // btnCliente
            // 
            this.btnCliente.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCliente.FlatAppearance.BorderSize = 0;
            this.btnCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCliente.Location = new System.Drawing.Point(4, 61);
            this.btnCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(216, 49);
            this.btnCliente.TabIndex = 3;
            this.btnCliente.Text = "Clientes";
            this.btnCliente.UseVisualStyleBackColor = true;
            this.btnCliente.Click += new System.EventHandler(this.btnCliente_Click);
            // 
            // btnEquipo
            // 
            this.btnEquipo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEquipo.FlatAppearance.BorderSize = 0;
            this.btnEquipo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEquipo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEquipo.ForeColor = System.Drawing.SystemColors.Window;
            this.btnEquipo.Location = new System.Drawing.Point(4, 118);
            this.btnEquipo.Margin = new System.Windows.Forms.Padding(4);
            this.btnEquipo.Name = "btnEquipo";
            this.btnEquipo.Size = new System.Drawing.Size(216, 49);
            this.btnEquipo.TabIndex = 2;
            this.btnEquipo.Text = "Tipo Equipo";
            this.btnEquipo.UseVisualStyleBackColor = true;
            this.btnEquipo.Click += new System.EventHandler(this.btnEquipo_Click);
            // 
            // btnEmpleado
            // 
            this.btnEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmpleado.FlatAppearance.BorderSize = 0;
            this.btnEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmpleado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmpleado.ForeColor = System.Drawing.SystemColors.Window;
            this.btnEmpleado.Location = new System.Drawing.Point(4, 175);
            this.btnEmpleado.Margin = new System.Windows.Forms.Padding(4);
            this.btnEmpleado.Name = "btnEmpleado";
            this.btnEmpleado.Size = new System.Drawing.Size(216, 49);
            this.btnEmpleado.TabIndex = 4;
            this.btnEmpleado.Text = "Empleados";
            this.btnEmpleado.UseVisualStyleBackColor = true;
            this.btnEmpleado.Click += new System.EventHandler(this.btnEmpleado_Click);
            // 
            // btnRol
            // 
            this.btnRol.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRol.FlatAppearance.BorderSize = 0;
            this.btnRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRol.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRol.ForeColor = System.Drawing.SystemColors.Window;
            this.btnRol.Location = new System.Drawing.Point(4, 232);
            this.btnRol.Margin = new System.Windows.Forms.Padding(4);
            this.btnRol.Name = "btnRol";
            this.btnRol.Size = new System.Drawing.Size(216, 49);
            this.btnRol.TabIndex = 14;
            this.btnRol.Text = "Roles";
            this.btnRol.UseVisualStyleBackColor = true;
            this.btnRol.Click += new System.EventHandler(this.btnRol_Click);
            // 
            // btnUsuario
            // 
            this.btnUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuario.FlatAppearance.BorderSize = 0;
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.ForeColor = System.Drawing.SystemColors.Window;
            this.btnUsuario.Location = new System.Drawing.Point(4, 289);
            this.btnUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(216, 49);
            this.btnUsuario.TabIndex = 5;
            this.btnUsuario.Text = "Usuarios";
            this.btnUsuario.UseVisualStyleBackColor = true;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnProveedor
            // 
            this.btnProveedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProveedor.FlatAppearance.BorderSize = 0;
            this.btnProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProveedor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProveedor.ForeColor = System.Drawing.SystemColors.Window;
            this.btnProveedor.Location = new System.Drawing.Point(4, 346);
            this.btnProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Size = new System.Drawing.Size(216, 49);
            this.btnProveedor.TabIndex = 7;
            this.btnProveedor.Text = "Proveedor";
            this.btnProveedor.UseVisualStyleBackColor = true;
            this.btnProveedor.Click += new System.EventHandler(this.btnProveedor_Click);
            // 
            // btnProducto
            // 
            this.btnProducto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProducto.FlatAppearance.BorderSize = 0;
            this.btnProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProducto.ForeColor = System.Drawing.SystemColors.Window;
            this.btnProducto.Location = new System.Drawing.Point(4, 403);
            this.btnProducto.Margin = new System.Windows.Forms.Padding(4);
            this.btnProducto.Name = "btnProducto";
            this.btnProducto.Size = new System.Drawing.Size(216, 49);
            this.btnProducto.TabIndex = 10;
            this.btnProducto.Text = "Producto\r\n";
            this.btnProducto.UseVisualStyleBackColor = true;
            this.btnProducto.Click += new System.EventHandler(this.btnProducto_Click);
            // 
            // btnMarca
            // 
            this.btnMarca.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMarca.FlatAppearance.BorderSize = 0;
            this.btnMarca.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMarca.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMarca.ForeColor = System.Drawing.SystemColors.Window;
            this.btnMarca.Location = new System.Drawing.Point(4, 460);
            this.btnMarca.Margin = new System.Windows.Forms.Padding(4);
            this.btnMarca.Name = "btnMarca";
            this.btnMarca.Size = new System.Drawing.Size(216, 49);
            this.btnMarca.TabIndex = 8;
            this.btnMarca.Text = "Marca";
            this.btnMarca.UseVisualStyleBackColor = true;
            this.btnMarca.Click += new System.EventHandler(this.btnMarca_Click);
            // 
            // btnEstadoReparacion
            // 
            this.btnEstadoReparacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEstadoReparacion.FlatAppearance.BorderSize = 0;
            this.btnEstadoReparacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstadoReparacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstadoReparacion.ForeColor = System.Drawing.SystemColors.Window;
            this.btnEstadoReparacion.Location = new System.Drawing.Point(4, 517);
            this.btnEstadoReparacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnEstadoReparacion.Name = "btnEstadoReparacion";
            this.btnEstadoReparacion.Size = new System.Drawing.Size(217, 49);
            this.btnEstadoReparacion.TabIndex = 11;
            this.btnEstadoReparacion.Text = "Estado Reparación";
            this.btnEstadoReparacion.UseVisualStyleBackColor = true;
            this.btnEstadoReparacion.Click += new System.EventHandler(this.btnEstadoReparacion_Click);
            // 
            // btnReparacion
            // 
            this.btnReparacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReparacion.FlatAppearance.BorderSize = 0;
            this.btnReparacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReparacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReparacion.ForeColor = System.Drawing.SystemColors.Window;
            this.btnReparacion.Location = new System.Drawing.Point(4, 574);
            this.btnReparacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnReparacion.Name = "btnReparacion";
            this.btnReparacion.Size = new System.Drawing.Size(216, 49);
            this.btnReparacion.TabIndex = 9;
            this.btnReparacion.Text = "Reparación";
            this.btnReparacion.UseVisualStyleBackColor = true;
            this.btnReparacion.Click += new System.EventHandler(this.btnReparacion_Click);
            // 
            // btnDetalleReparacion
            // 
            this.btnDetalleReparacion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetalleReparacion.FlatAppearance.BorderSize = 0;
            this.btnDetalleReparacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetalleReparacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalleReparacion.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDetalleReparacion.Location = new System.Drawing.Point(4, 631);
            this.btnDetalleReparacion.Margin = new System.Windows.Forms.Padding(4);
            this.btnDetalleReparacion.Name = "btnDetalleReparacion";
            this.btnDetalleReparacion.Size = new System.Drawing.Size(217, 49);
            this.btnDetalleReparacion.TabIndex = 12;
            this.btnDetalleReparacion.Text = "Detalle Reparación";
            this.btnDetalleReparacion.UseVisualStyleBackColor = true;
            this.btnDetalleReparacion.Click += new System.EventHandler(this.btnDetalleReparacion_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSalir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSalir.FlatAppearance.BorderSize = 0;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSalir.Location = new System.Drawing.Point(27, 860);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(239, 49);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(37, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Taller Electrónico";
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.Color.White;
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(293, 0);
            this.pnlContainer.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(774, 922);
            this.pnlContainer.TabIndex = 1;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1067, 922);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.ShowIcon = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnUsuario;
        private System.Windows.Forms.Button btnProveedor;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEmpleado;
        private System.Windows.Forms.Button btnEquipo;
        private System.Windows.Forms.Button btnMain;
        private System.Windows.Forms.Button btnCliente;
        private System.Windows.Forms.Button btnMarca;
        private System.Windows.Forms.Button btnReparacion;
        private System.Windows.Forms.Button btnProducto;
        private System.Windows.Forms.Button btnEstadoReparacion;
        private System.Windows.Forms.Button btnDetalleReparacion;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnRol;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}