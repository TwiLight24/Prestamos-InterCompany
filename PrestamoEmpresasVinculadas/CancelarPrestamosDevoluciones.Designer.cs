namespace PrestamoEmpresasVinculadas
{
    partial class CancelarPrestamosDevoluciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CancelarPrestamosDevoluciones));
            this.btnCancelarProceso = new System.Windows.Forms.Button();
            this.dgvDevolucion = new System.Windows.Forms.DataGridView();
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            this.comboAcreedor = new System.Windows.Forms.ComboBox();
            this.lblAcreedor = new System.Windows.Forms.Label();
            this.comboDeudor = new System.Windows.Forms.ComboBox();
            this.lblDeudor = new System.Windows.Forms.Label();
            this.btnBuscarPrestamos = new System.Windows.Forms.Button();
            this.lblRegistrosPrestamos = new System.Windows.Forms.Label();
            this.lblDevolucion = new System.Windows.Forms.Label();
            this.cmbPrestamos = new System.Windows.Forms.ComboBox();
            this.lblPrestamos = new System.Windows.Forms.Label();
            this.btnCancelarDevolucion = new System.Windows.Forms.Button();
            this.btnCancelarReconciliacion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReconciliacion = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevolucion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReconciliacion)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelarProceso
            // 
            this.btnCancelarProceso.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarProceso.BackgroundImage")));
            this.btnCancelarProceso.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelarProceso.FlatAppearance.BorderSize = 0;
            this.btnCancelarProceso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarProceso.Location = new System.Drawing.Point(680, 281);
            this.btnCancelarProceso.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarProceso.Name = "btnCancelarProceso";
            this.btnCancelarProceso.Size = new System.Drawing.Size(132, 31);
            this.btnCancelarProceso.TabIndex = 10;
            this.btnCancelarProceso.Text = "Cancelar Pres.";
            this.btnCancelarProceso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarProceso.UseVisualStyleBackColor = true;
            this.btnCancelarProceso.Click += new System.EventHandler(this.btnCancelarProceso_Click);
            // 
            // dgvDevolucion
            // 
            this.dgvDevolucion.AllowUserToAddRows = false;
            this.dgvDevolucion.AllowUserToDeleteRows = false;
            this.dgvDevolucion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDevolucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevolucion.Location = new System.Drawing.Point(21, 360);
            this.dgvDevolucion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvDevolucion.Name = "dgvDevolucion";
            this.dgvDevolucion.ReadOnly = true;
            this.dgvDevolucion.RowHeadersWidth = 51;
            this.dgvDevolucion.RowTemplate.Height = 24;
            this.dgvDevolucion.Size = new System.Drawing.Size(791, 144);
            this.dgvDevolucion.TabIndex = 22;
            // 
            // dgvPrestamos
            // 
            this.dgvPrestamos.AllowUserToAddRows = false;
            this.dgvPrestamos.AllowUserToDeleteRows = false;
            this.dgvPrestamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamos.Location = new System.Drawing.Point(21, 202);
            this.dgvPrestamos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.ReadOnly = true;
            this.dgvPrestamos.RowHeadersWidth = 51;
            this.dgvPrestamos.RowTemplate.Height = 24;
            this.dgvPrestamos.Size = new System.Drawing.Size(791, 75);
            this.dgvPrestamos.TabIndex = 21;
            // 
            // comboAcreedor
            // 
            this.comboAcreedor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboAcreedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAcreedor.Font = new System.Drawing.Font("Tahoma", 7.4F);
            this.comboAcreedor.FormattingEnabled = true;
            this.comboAcreedor.Items.AddRange(new object[] {
            "RUMI IMPORT S.A.",
            "MEGA ESTRUCTURAS S.A",
            "Industrias del Zinc S.A.",
            "Manufacturas Industriales Mendoza S.A.",
            "Postes y Estructuras S.A.C.",
            "STEEL FORM S.A.C."});
            this.comboAcreedor.Location = new System.Drawing.Point(125, 51);
            this.comboAcreedor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboAcreedor.Name = "comboAcreedor";
            this.comboAcreedor.Size = new System.Drawing.Size(226, 20);
            this.comboAcreedor.TabIndex = 24;
            this.comboAcreedor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboAcreedor_DrawItem);
            // 
            // lblAcreedor
            // 
            this.lblAcreedor.AutoSize = true;
            this.lblAcreedor.Location = new System.Drawing.Point(25, 54);
            this.lblAcreedor.Name = "lblAcreedor";
            this.lblAcreedor.Size = new System.Drawing.Size(66, 16);
            this.lblAcreedor.TabIndex = 23;
            this.lblAcreedor.Text = "Acreedor:";
            // 
            // comboDeudor
            // 
            this.comboDeudor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboDeudor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDeudor.FormattingEnabled = true;
            this.comboDeudor.Items.AddRange(new object[] {
            "RUMI IMPORT S.A.",
            "MEGA ESTRUCTURAS S.A",
            "Industrias del Zinc S.A.",
            "Manufacturas Industriales Mendoza S.A.",
            "Postes y Estructuras S.A.C.",
            "STEEL FORM S.A.C."});
            this.comboDeudor.Location = new System.Drawing.Point(125, 88);
            this.comboDeudor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboDeudor.Name = "comboDeudor";
            this.comboDeudor.Size = new System.Drawing.Size(226, 23);
            this.comboDeudor.TabIndex = 26;
            this.comboDeudor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboDeudor_DrawItem);
            // 
            // lblDeudor
            // 
            this.lblDeudor.AutoSize = true;
            this.lblDeudor.Location = new System.Drawing.Point(26, 92);
            this.lblDeudor.Name = "lblDeudor";
            this.lblDeudor.Size = new System.Drawing.Size(55, 16);
            this.lblDeudor.TabIndex = 25;
            this.lblDeudor.Text = "Deudor:";
            // 
            // btnBuscarPrestamos
            // 
            this.btnBuscarPrestamos.BackgroundImage = global::PrestamoEmpresasVinculadas.Properties.Resources.btn_enfasis;
            this.btnBuscarPrestamos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarPrestamos.FlatAppearance.BorderSize = 0;
            this.btnBuscarPrestamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPrestamos.Location = new System.Drawing.Point(379, 69);
            this.btnBuscarPrestamos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarPrestamos.Name = "btnBuscarPrestamos";
            this.btnBuscarPrestamos.Size = new System.Drawing.Size(107, 31);
            this.btnBuscarPrestamos.TabIndex = 27;
            this.btnBuscarPrestamos.Text = "Buscar";
            this.btnBuscarPrestamos.UseVisualStyleBackColor = true;
            this.btnBuscarPrestamos.Click += new System.EventHandler(this.btnBuscarPrestamos_Click);
            // 
            // lblRegistrosPrestamos
            // 
            this.lblRegistrosPrestamos.AutoSize = true;
            this.lblRegistrosPrestamos.Location = new System.Drawing.Point(18, 168);
            this.lblRegistrosPrestamos.Name = "lblRegistrosPrestamos";
            this.lblRegistrosPrestamos.Size = new System.Drawing.Size(111, 16);
            this.lblRegistrosPrestamos.TabIndex = 28;
            this.lblRegistrosPrestamos.Text = "Detalle Prestamo";
            // 
            // lblDevolucion
            // 
            this.lblDevolucion.AutoSize = true;
            this.lblDevolucion.Location = new System.Drawing.Point(18, 326);
            this.lblDevolucion.Name = "lblDevolucion";
            this.lblDevolucion.Size = new System.Drawing.Size(78, 16);
            this.lblDevolucion.TabIndex = 29;
            this.lblDevolucion.Text = "Devolución:";
            // 
            // cmbPrestamos
            // 
            this.cmbPrestamos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPrestamos.FormattingEnabled = true;
            this.cmbPrestamos.Location = new System.Drawing.Point(125, 126);
            this.cmbPrestamos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPrestamos.Name = "cmbPrestamos";
            this.cmbPrestamos.Size = new System.Drawing.Size(226, 24);
            this.cmbPrestamos.TabIndex = 30;
            this.cmbPrestamos.SelectedIndexChanged += new System.EventHandler(this.cmbPrestamos_SelectedIndexChanged);
            // 
            // lblPrestamos
            // 
            this.lblPrestamos.AutoSize = true;
            this.lblPrestamos.Location = new System.Drawing.Point(25, 129);
            this.lblPrestamos.Name = "lblPrestamos";
            this.lblPrestamos.Size = new System.Drawing.Size(75, 16);
            this.lblPrestamos.TabIndex = 31;
            this.lblPrestamos.Text = "Prestamos:";
            // 
            // btnCancelarDevolucion
            // 
            this.btnCancelarDevolucion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarDevolucion.BackgroundImage")));
            this.btnCancelarDevolucion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelarDevolucion.FlatAppearance.BorderSize = 0;
            this.btnCancelarDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarDevolucion.Location = new System.Drawing.Point(680, 508);
            this.btnCancelarDevolucion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarDevolucion.Name = "btnCancelarDevolucion";
            this.btnCancelarDevolucion.Size = new System.Drawing.Size(132, 31);
            this.btnCancelarDevolucion.TabIndex = 32;
            this.btnCancelarDevolucion.Text = "Cancelar Devo.";
            this.btnCancelarDevolucion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarDevolucion.UseVisualStyleBackColor = true;
            this.btnCancelarDevolucion.Click += new System.EventHandler(this.btnCancelarDevolucion_Click);
            // 
            // btnCancelarReconciliacion
            // 
            this.btnCancelarReconciliacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancelarReconciliacion.BackgroundImage")));
            this.btnCancelarReconciliacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelarReconciliacion.FlatAppearance.BorderSize = 0;
            this.btnCancelarReconciliacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarReconciliacion.Location = new System.Drawing.Point(680, 662);
            this.btnCancelarReconciliacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelarReconciliacion.Name = "btnCancelarReconciliacion";
            this.btnCancelarReconciliacion.Size = new System.Drawing.Size(132, 31);
            this.btnCancelarReconciliacion.TabIndex = 35;
            this.btnCancelarReconciliacion.Text = "Cancelar Recon.";
            this.btnCancelarReconciliacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelarReconciliacion.UseVisualStyleBackColor = true;
            this.btnCancelarReconciliacion.Click += new System.EventHandler(this.btnCancelarReconciliacion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 549);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 34;
            this.label1.Text = "Reconciliación:";
            // 
            // dgvReconciliacion
            // 
            this.dgvReconciliacion.AllowUserToAddRows = false;
            this.dgvReconciliacion.AllowUserToDeleteRows = false;
            this.dgvReconciliacion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReconciliacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReconciliacion.Location = new System.Drawing.Point(21, 583);
            this.dgvReconciliacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvReconciliacion.Name = "dgvReconciliacion";
            this.dgvReconciliacion.ReadOnly = true;
            this.dgvReconciliacion.RowHeadersWidth = 51;
            this.dgvReconciliacion.RowTemplate.Height = 24;
            this.dgvReconciliacion.Size = new System.Drawing.Size(791, 75);
            this.dgvReconciliacion.TabIndex = 33;
            // 
            // CancelarPrestamosDevoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 714);
            this.Controls.Add(this.btnCancelarReconciliacion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvReconciliacion);
            this.Controls.Add(this.btnCancelarDevolucion);
            this.Controls.Add(this.lblPrestamos);
            this.Controls.Add(this.cmbPrestamos);
            this.Controls.Add(this.lblDevolucion);
            this.Controls.Add(this.lblRegistrosPrestamos);
            this.Controls.Add(this.btnBuscarPrestamos);
            this.Controls.Add(this.comboDeudor);
            this.Controls.Add(this.lblDeudor);
            this.Controls.Add(this.comboAcreedor);
            this.Controls.Add(this.lblAcreedor);
            this.Controls.Add(this.dgvDevolucion);
            this.Controls.Add(this.dgvPrestamos);
            this.Controls.Add(this.btnCancelarProceso);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "CancelarPrestamosDevoluciones";
            this.Text = "Cancelar Prestamos y Devoluciones";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CancelarProceso_FormClosed);
            this.Load += new System.EventHandler(this.CancelarPrestamosDevoluciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevolucion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReconciliacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelarProceso;
        private System.Windows.Forms.DataGridView dgvDevolucion;
        private System.Windows.Forms.DataGridView dgvPrestamos;
        private System.Windows.Forms.ComboBox comboAcreedor;
        private System.Windows.Forms.Label lblAcreedor;
        private System.Windows.Forms.ComboBox comboDeudor;
        private System.Windows.Forms.Label lblDeudor;
        private System.Windows.Forms.Button btnBuscarPrestamos;
        private System.Windows.Forms.Label lblRegistrosPrestamos;
        private System.Windows.Forms.Label lblDevolucion;
        private System.Windows.Forms.ComboBox cmbPrestamos;
        private System.Windows.Forms.Label lblPrestamos;
        private System.Windows.Forms.Button btnCancelarDevolucion;
        private System.Windows.Forms.Button btnCancelarReconciliacion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReconciliacion;
    }
}