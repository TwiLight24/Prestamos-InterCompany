namespace PrestamoEmpresasVinculadas
{
    partial class GenerarReconciliacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerarReconciliacion));
            this.comboDeudor = new System.Windows.Forms.ComboBox();
            this.comboAcreedor = new System.Windows.Forms.ComboBox();
            this.lblDeudor = new System.Windows.Forms.Label();
            this.lblAcreedor = new System.Windows.Forms.Label();
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            this.btnGenerarReconciliacion = new System.Windows.Forms.Button();
            this.btnBuscarPrestamos = new System.Windows.Forms.Button();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.lblMoneda = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            this.SuspendLayout();
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
            this.comboDeudor.Location = new System.Drawing.Point(73, 77);
            this.comboDeudor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboDeudor.Name = "comboDeudor";
            this.comboDeudor.Size = new System.Drawing.Size(143, 21);
            this.comboDeudor.TabIndex = 1;
            this.comboDeudor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboDeudor_DrawItem);
            // 
            // comboAcreedor
            // 
            this.comboAcreedor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboAcreedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAcreedor.FormattingEnabled = true;
            this.comboAcreedor.Items.AddRange(new object[] {
            "RUMI IMPORT S.A.",
            "MEGA ESTRUCTURAS S.A",
            "Industrias del Zinc S.A.",
            "Manufacturas Industriales Mendoza S.A.",
            "Postes y Estructuras S.A.C.",
            "STEEL FORM S.A.C."});
            this.comboAcreedor.Location = new System.Drawing.Point(73, 52);
            this.comboAcreedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboAcreedor.Name = "comboAcreedor";
            this.comboAcreedor.Size = new System.Drawing.Size(143, 21);
            this.comboAcreedor.TabIndex = 0;
            this.comboAcreedor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboAcreedor_DrawItem);
            // 
            // lblDeudor
            // 
            this.lblDeudor.AutoSize = true;
            this.lblDeudor.Location = new System.Drawing.Point(17, 80);
            this.lblDeudor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeudor.Name = "lblDeudor";
            this.lblDeudor.Size = new System.Drawing.Size(45, 13);
            this.lblDeudor.TabIndex = 5;
            this.lblDeudor.Text = "Deudor:";
            // 
            // lblAcreedor
            // 
            this.lblAcreedor.AutoSize = true;
            this.lblAcreedor.Location = new System.Drawing.Point(17, 54);
            this.lblAcreedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAcreedor.Name = "lblAcreedor";
            this.lblAcreedor.Size = new System.Drawing.Size(53, 13);
            this.lblAcreedor.TabIndex = 4;
            this.lblAcreedor.Text = "Acreedor:";
            // 
            // dgvPrestamos
            // 
            this.dgvPrestamos.AllowUserToAddRows = false;
            this.dgvPrestamos.AllowUserToDeleteRows = false;
            this.dgvPrestamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamos.Location = new System.Drawing.Point(20, 117);
            this.dgvPrestamos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.ReadOnly = true;
            this.dgvPrestamos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvPrestamos.RowTemplate.Height = 24;
            this.dgvPrestamos.Size = new System.Drawing.Size(727, 234);
            this.dgvPrestamos.TabIndex = 8;
            // 
            // btnGenerarReconciliacion
            // 
            this.btnGenerarReconciliacion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerarReconciliacion.BackgroundImage")));
            this.btnGenerarReconciliacion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerarReconciliacion.FlatAppearance.BorderSize = 0;
            this.btnGenerarReconciliacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReconciliacion.Location = new System.Drawing.Point(20, 365);
            this.btnGenerarReconciliacion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerarReconciliacion.Name = "btnGenerarReconciliacion";
            this.btnGenerarReconciliacion.Size = new System.Drawing.Size(135, 25);
            this.btnGenerarReconciliacion.TabIndex = 4;
            this.btnGenerarReconciliacion.Text = "Generar Reconciliacion";
            this.btnGenerarReconciliacion.UseVisualStyleBackColor = true;
            this.btnGenerarReconciliacion.Click += new System.EventHandler(this.btnGenerarReconciliacion_Click);
            // 
            // btnBuscarPrestamos
            // 
            this.btnBuscarPrestamos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarPrestamos.BackgroundImage")));
            this.btnBuscarPrestamos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarPrestamos.FlatAppearance.BorderSize = 0;
            this.btnBuscarPrestamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPrestamos.Location = new System.Drawing.Point(255, 77);
            this.btnBuscarPrestamos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscarPrestamos.Name = "btnBuscarPrestamos";
            this.btnBuscarPrestamos.Size = new System.Drawing.Size(80, 25);
            this.btnBuscarPrestamos.TabIndex = 3;
            this.btnBuscarPrestamos.Text = "Buscar";
            this.btnBuscarPrestamos.UseVisualStyleBackColor = true;
            this.btnBuscarPrestamos.Click += new System.EventHandler(this.btnBuscarPrestamos_Click);
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Items.AddRange(new object[] {
            "SOL",
            "USD"});
            this.cmbMoneda.Location = new System.Drawing.Point(286, 52);
            this.cmbMoneda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(77, 21);
            this.cmbMoneda.TabIndex = 2;
            this.cmbMoneda.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbMoneda_DrawItem);
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(231, 54);
            this.lblMoneda.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(49, 13);
            this.lblMoneda.TabIndex = 21;
            this.lblMoneda.Text = "Moneda:";
            // 
            // GenerarReconciliacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 402);
            this.Controls.Add(this.cmbMoneda);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.btnBuscarPrestamos);
            this.Controls.Add(this.btnGenerarReconciliacion);
            this.Controls.Add(this.dgvPrestamos);
            this.Controls.Add(this.comboDeudor);
            this.Controls.Add(this.comboAcreedor);
            this.Controls.Add(this.lblDeudor);
            this.Controls.Add(this.lblAcreedor);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GenerarReconciliacion";
            this.Text = "Generar Reconciliacion";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GenerarReconciliacion_FormClosed);
            this.Load += new System.EventHandler(this.GenerarReconciliacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboDeudor;
        private System.Windows.Forms.ComboBox comboAcreedor;
        private System.Windows.Forms.Label lblDeudor;
        private System.Windows.Forms.Label lblAcreedor;
        private System.Windows.Forms.DataGridView dgvPrestamos;
        private System.Windows.Forms.Button btnGenerarReconciliacion;
        private System.Windows.Forms.Button btnBuscarPrestamos;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.Label lblMoneda;
    }
}