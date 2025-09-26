namespace PrestamoEmpresasVinculadas
{
    partial class GenerarPrestamo
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
            this.lblAcreedor = new System.Windows.Forms.Label();
            this.lblDeudor = new System.Windows.Forms.Label();
            this.comboAcreedor = new System.Windows.Forms.ComboBox();
            this.comboDeudor = new System.Windows.Forms.ComboBox();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.lblMonto = new System.Windows.Forms.Label();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.btnGenerarPrestamo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComentarioAcreedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtComentarioDeudor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblAcreedor
            // 
            this.lblAcreedor.AutoSize = true;
            this.lblAcreedor.Location = new System.Drawing.Point(10, 50);
            this.lblAcreedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAcreedor.Name = "lblAcreedor";
            this.lblAcreedor.Size = new System.Drawing.Size(53, 13);
            this.lblAcreedor.TabIndex = 0;
            this.lblAcreedor.Text = "Acreedor:";
            // 
            // lblDeudor
            // 
            this.lblDeudor.AutoSize = true;
            this.lblDeudor.Location = new System.Drawing.Point(10, 75);
            this.lblDeudor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeudor.Name = "lblDeudor";
            this.lblDeudor.Size = new System.Drawing.Size(45, 13);
            this.lblDeudor.TabIndex = 1;
            this.lblDeudor.Text = "Deudor:";
            // 
            // comboAcreedor
            // 
            this.comboAcreedor.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
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
            this.comboAcreedor.Location = new System.Drawing.Point(65, 47);
            this.comboAcreedor.Margin = new System.Windows.Forms.Padding(2);
            this.comboAcreedor.Name = "comboAcreedor";
            this.comboAcreedor.Size = new System.Drawing.Size(208, 21);
            this.comboAcreedor.TabIndex = 0;
            this.comboAcreedor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboAcreedor_DrawItem);
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
            this.comboDeudor.Location = new System.Drawing.Point(65, 72);
            this.comboDeudor.Margin = new System.Windows.Forms.Padding(2);
            this.comboDeudor.Name = "comboDeudor";
            this.comboDeudor.Size = new System.Drawing.Size(208, 21);
            this.comboDeudor.TabIndex = 1;
            this.comboDeudor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboDeudor_DrawItem);
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(9, 104);
            this.lblMoneda.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(49, 13);
            this.lblMoneda.TabIndex = 4;
            this.lblMoneda.Text = "Moneda:";
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Location = new System.Drawing.Point(409, 239);
            this.lblMonto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(40, 13);
            this.lblMonto.TabIndex = 5;
            this.lblMonto.Text = "Monto:";
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Items.AddRange(new object[] {
            "SOL",
            "USD"});
            this.cmbMoneda.Location = new System.Drawing.Point(65, 102);
            this.cmbMoneda.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(77, 21);
            this.cmbMoneda.TabIndex = 2;
            this.cmbMoneda.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbMoneda_DrawItem);
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(461, 237);
            this.txtMonto.Margin = new System.Windows.Forms.Padding(2);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(94, 20);
            this.txtMonto.TabIndex = 6;
            this.txtMonto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMonto_KeyPress);
            // 
            // btnGenerarPrestamo
            // 
            this.btnGenerarPrestamo.BackgroundImage = global::PrestamoEmpresasVinculadas.Properties.Resources.btn_enfasis;
            this.btnGenerarPrestamo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerarPrestamo.FlatAppearance.BorderSize = 0;
            this.btnGenerarPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarPrestamo.Location = new System.Drawing.Point(12, 232);
            this.btnGenerarPrestamo.Margin = new System.Windows.Forms.Padding(2);
            this.btnGenerarPrestamo.Name = "btnGenerarPrestamo";
            this.btnGenerarPrestamo.Size = new System.Drawing.Size(115, 25);
            this.btnGenerarPrestamo.TabIndex = 7;
            this.btnGenerarPrestamo.Text = "Generar Prestamo";
            this.btnGenerarPrestamo.UseVisualStyleBackColor = true;
            this.btnGenerarPrestamo.Click += new System.EventHandler(this.btnGenerarPrestamo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 141);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Comentario Acreedor:";
            // 
            // txtComentarioAcreedor
            // 
            this.txtComentarioAcreedor.Location = new System.Drawing.Point(12, 161);
            this.txtComentarioAcreedor.Margin = new System.Windows.Forms.Padding(2);
            this.txtComentarioAcreedor.Multiline = true;
            this.txtComentarioAcreedor.Name = "txtComentarioAcreedor";
            this.txtComentarioAcreedor.Size = new System.Drawing.Size(261, 58);
            this.txtComentarioAcreedor.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(286, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Fecha Prestamo:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(375, 48);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(180, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // txtComentarioDeudor
            // 
            this.txtComentarioDeudor.Location = new System.Drawing.Point(289, 161);
            this.txtComentarioDeudor.Margin = new System.Windows.Forms.Padding(2);
            this.txtComentarioDeudor.Multiline = true;
            this.txtComentarioDeudor.Name = "txtComentarioDeudor";
            this.txtComentarioDeudor.Size = new System.Drawing.Size(266, 58);
            this.txtComentarioDeudor.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(287, 141);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Comentario Deudor:";
            // 
            // GenerarPrestamo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 271);
            this.Controls.Add(this.txtComentarioDeudor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtComentarioAcreedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerarPrestamo);
            this.Controls.Add(this.txtMonto);
            this.Controls.Add(this.cmbMoneda);
            this.Controls.Add(this.lblMonto);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.comboDeudor);
            this.Controls.Add(this.comboAcreedor);
            this.Controls.Add(this.lblDeudor);
            this.Controls.Add(this.lblAcreedor);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GenerarPrestamo";
            this.Text = "Generar Prestamo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GenerarPrestamo_FormClosed);
            this.Load += new System.EventHandler(this.GenerarPrestamo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAcreedor;
        private System.Windows.Forms.Label lblDeudor;
        private System.Windows.Forms.ComboBox comboAcreedor;
        private System.Windows.Forms.ComboBox comboDeudor;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Button btnGenerarPrestamo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComentarioAcreedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtComentarioDeudor;
        private System.Windows.Forms.Label label3;
    }
}