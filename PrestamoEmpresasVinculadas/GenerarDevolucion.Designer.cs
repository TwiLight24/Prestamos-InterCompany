namespace PrestamoEmpresasVinculadas
{
    partial class GenerarDevolucion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenerarDevolucion));
            this.comboDeudor = new System.Windows.Forms.ComboBox();
            this.comboAcreedor = new System.Windows.Forms.ComboBox();
            this.lblDeudor = new System.Windows.Forms.Label();
            this.lblAcreedor = new System.Windows.Forms.Label();
            this.btnGenerarDevolucion = new System.Windows.Forms.Button();
            this.dgvPrestamos = new System.Windows.Forms.DataGridView();
            this.lblRegistrosPrestamos = new System.Windows.Forms.Label();
            this.lblDevolucion = new System.Windows.Forms.Label();
            this.cmbMoneda = new System.Windows.Forms.ComboBox();
            this.lblMoneda = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscarPrestamos = new System.Windows.Forms.Button();
            this.dgvDevolucion = new System.Windows.Forms.DataGridView();
            this.btnAgregarGrilla = new System.Windows.Forms.Button();
            this.btnRetirarGrilla = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.lblTotalDevolucion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevolucion)).BeginInit();
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
            this.comboDeudor.Location = new System.Drawing.Point(70, 43);
            this.comboDeudor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboDeudor.Name = "comboDeudor";
            this.comboDeudor.Size = new System.Drawing.Size(138, 21);
            this.comboDeudor.TabIndex = 0;
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
            this.comboAcreedor.Location = new System.Drawing.Point(69, 76);
            this.comboAcreedor.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboAcreedor.Name = "comboAcreedor";
            this.comboAcreedor.Size = new System.Drawing.Size(138, 21);
            this.comboAcreedor.TabIndex = 1;
            this.comboAcreedor.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboAcreedor_DrawItem);
            // 
            // lblDeudor
            // 
            this.lblDeudor.AutoSize = true;
            this.lblDeudor.Location = new System.Drawing.Point(14, 46);
            this.lblDeudor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDeudor.Name = "lblDeudor";
            this.lblDeudor.Size = new System.Drawing.Size(45, 13);
            this.lblDeudor.TabIndex = 5;
            this.lblDeudor.Text = "Deudor:";
            // 
            // lblAcreedor
            // 
            this.lblAcreedor.AutoSize = true;
            this.lblAcreedor.Location = new System.Drawing.Point(13, 79);
            this.lblAcreedor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAcreedor.Name = "lblAcreedor";
            this.lblAcreedor.Size = new System.Drawing.Size(53, 13);
            this.lblAcreedor.TabIndex = 4;
            this.lblAcreedor.Text = "Acreedor:";
            // 
            // btnGenerarDevolucion
            // 
            this.btnGenerarDevolucion.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGenerarDevolucion.BackgroundImage")));
            this.btnGenerarDevolucion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerarDevolucion.FlatAppearance.BorderSize = 0;
            this.btnGenerarDevolucion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarDevolucion.Location = new System.Drawing.Point(15, 443);
            this.btnGenerarDevolucion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGenerarDevolucion.Name = "btnGenerarDevolucion";
            this.btnGenerarDevolucion.Size = new System.Drawing.Size(115, 25);
            this.btnGenerarDevolucion.TabIndex = 6;
            this.btnGenerarDevolucion.Text = "Generar Devolucion";
            this.btnGenerarDevolucion.UseVisualStyleBackColor = true;
            this.btnGenerarDevolucion.Click += new System.EventHandler(this.btnGenerarDevolucion_Click);
            // 
            // dgvPrestamos
            // 
            this.dgvPrestamos.AllowUserToAddRows = false;
            this.dgvPrestamos.AllowUserToDeleteRows = false;
            this.dgvPrestamos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrestamos.Location = new System.Drawing.Point(15, 181);
            this.dgvPrestamos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvPrestamos.Name = "dgvPrestamos";
            this.dgvPrestamos.ReadOnly = true;
            this.dgvPrestamos.RowHeadersWidth = 51;
            this.dgvPrestamos.RowTemplate.Height = 24;
            this.dgvPrestamos.Size = new System.Drawing.Size(572, 224);
            this.dgvPrestamos.TabIndex = 10;
            // 
            // lblRegistrosPrestamos
            // 
            this.lblRegistrosPrestamos.AutoSize = true;
            this.lblRegistrosPrestamos.Location = new System.Drawing.Point(13, 157);
            this.lblRegistrosPrestamos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRegistrosPrestamos.Name = "lblRegistrosPrestamos";
            this.lblRegistrosPrestamos.Size = new System.Drawing.Size(106, 13);
            this.lblRegistrosPrestamos.TabIndex = 12;
            this.lblRegistrosPrestamos.Text = "Registros Prestamos:";
            // 
            // lblDevolucion
            // 
            this.lblDevolucion.AutoSize = true;
            this.lblDevolucion.Location = new System.Drawing.Point(626, 157);
            this.lblDevolucion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDevolucion.Name = "lblDevolucion";
            this.lblDevolucion.Size = new System.Drawing.Size(64, 13);
            this.lblDevolucion.TabIndex = 13;
            this.lblDevolucion.Text = "Devolución:";
            // 
            // cmbMoneda
            // 
            this.cmbMoneda.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoneda.FormattingEnabled = true;
            this.cmbMoneda.Items.AddRange(new object[] {
            "SOL",
            "USD"});
            this.cmbMoneda.Location = new System.Drawing.Point(304, 76);
            this.cmbMoneda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbMoneda.Name = "cmbMoneda";
            this.cmbMoneda.Size = new System.Drawing.Size(77, 21);
            this.cmbMoneda.TabIndex = 3;
            this.cmbMoneda.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbMoneda_DrawItem);
            // 
            // lblMoneda
            // 
            this.lblMoneda.AutoSize = true;
            this.lblMoneda.Location = new System.Drawing.Point(248, 79);
            this.lblMoneda.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMoneda.Name = "lblMoneda";
            this.lblMoneda.Size = new System.Drawing.Size(49, 13);
            this.lblMoneda.TabIndex = 14;
            this.lblMoneda.Text = "Moneda:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(335, 42);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(209, 20);
            this.dtpFecha.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(246, 43);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Fecha Prestamo:";
            // 
            // btnBuscarPrestamos
            // 
            this.btnBuscarPrestamos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBuscarPrestamos.BackgroundImage")));
            this.btnBuscarPrestamos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarPrestamos.FlatAppearance.BorderSize = 0;
            this.btnBuscarPrestamos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPrestamos.Location = new System.Drawing.Point(20, 115);
            this.btnBuscarPrestamos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscarPrestamos.Name = "btnBuscarPrestamos";
            this.btnBuscarPrestamos.Size = new System.Drawing.Size(80, 25);
            this.btnBuscarPrestamos.TabIndex = 5;
            this.btnBuscarPrestamos.Text = "Buscar";
            this.btnBuscarPrestamos.UseVisualStyleBackColor = true;
            this.btnBuscarPrestamos.Click += new System.EventHandler(this.btnBuscarPrestamos_Click);
            // 
            // dgvDevolucion
            // 
            this.dgvDevolucion.AllowUserToAddRows = false;
            this.dgvDevolucion.AllowUserToDeleteRows = false;
            this.dgvDevolucion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDevolucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevolucion.Location = new System.Drawing.Point(628, 181);
            this.dgvDevolucion.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvDevolucion.Name = "dgvDevolucion";
            this.dgvDevolucion.RowHeadersWidth = 51;
            this.dgvDevolucion.RowTemplate.Height = 24;
            this.dgvDevolucion.Size = new System.Drawing.Size(560, 224);
            this.dgvDevolucion.TabIndex = 20;
            this.dgvDevolucion.EditModeChanged += new System.EventHandler(this.dgvDevolucion_EditModeChanged);
            this.dgvDevolucion.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevolucion_CellEndEdit);
            this.dgvDevolucion.CellStateChanged += new System.Windows.Forms.DataGridViewCellStateChangedEventHandler(this.dgvDevolucion_CellStateChanged);
            this.dgvDevolucion.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDevolucion_CellValidating);
            this.dgvDevolucion.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDevolucion_CellValueChanged);
            this.dgvDevolucion.CurrentCellChanged += new System.EventHandler(this.dgvDevolucion_CurrentCellChanged);
            // 
            // btnAgregarGrilla
            // 
            this.btnAgregarGrilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarGrilla.Location = new System.Drawing.Point(592, 235);
            this.btnAgregarGrilla.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAgregarGrilla.Name = "btnAgregarGrilla";
            this.btnAgregarGrilla.Size = new System.Drawing.Size(33, 32);
            this.btnAgregarGrilla.TabIndex = 21;
            this.btnAgregarGrilla.Text = ">";
            this.btnAgregarGrilla.UseVisualStyleBackColor = true;
            this.btnAgregarGrilla.Click += new System.EventHandler(this.btnAgregarGrilla_Click);
            // 
            // btnRetirarGrilla
            // 
            this.btnRetirarGrilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetirarGrilla.Location = new System.Drawing.Point(592, 310);
            this.btnRetirarGrilla.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRetirarGrilla.Name = "btnRetirarGrilla";
            this.btnRetirarGrilla.Size = new System.Drawing.Size(33, 32);
            this.btnRetirarGrilla.TabIndex = 22;
            this.btnRetirarGrilla.Text = "<";
            this.btnRetirarGrilla.UseVisualStyleBackColor = true;
            this.btnRetirarGrilla.Click += new System.EventHandler(this.btnRetirarGrilla_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.BackgroundImage")));
            this.btnLimpiar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Location = new System.Drawing.Point(112, 115);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(80, 25);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // lblTotalDevolucion
            // 
            this.lblTotalDevolucion.AutoSize = true;
            this.lblTotalDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDevolucion.Location = new System.Drawing.Point(1125, 428);
            this.lblTotalDevolucion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalDevolucion.Name = "lblTotalDevolucion";
            this.lblTotalDevolucion.Size = new System.Drawing.Size(32, 13);
            this.lblTotalDevolucion.TabIndex = 24;
            this.lblTotalDevolucion.Text = "0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(566, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Comentario:";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(644, 45);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(275, 61);
            this.txtComentario.TabIndex = 4;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(1000, 428);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(108, 13);
            this.lblTotal.TabIndex = 27;
            this.lblTotal.Text = "Total Devolución:";
            // 
            // GenerarDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 477);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotalDevolucion);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnRetirarGrilla);
            this.Controls.Add(this.btnAgregarGrilla);
            this.Controls.Add(this.dgvDevolucion);
            this.Controls.Add(this.btnBuscarPrestamos);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMoneda);
            this.Controls.Add(this.lblMoneda);
            this.Controls.Add(this.lblDevolucion);
            this.Controls.Add(this.lblRegistrosPrestamos);
            this.Controls.Add(this.dgvPrestamos);
            this.Controls.Add(this.btnGenerarDevolucion);
            this.Controls.Add(this.comboDeudor);
            this.Controls.Add(this.comboAcreedor);
            this.Controls.Add(this.lblDeudor);
            this.Controls.Add(this.lblAcreedor);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GenerarDevolucion";
            this.Text = "Generar Devolución Prestamo";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GenerarDevolucion_FormClosed);
            this.Load += new System.EventHandler(this.GenerarDevolucion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrestamos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevolucion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboDeudor;
        private System.Windows.Forms.ComboBox comboAcreedor;
        private System.Windows.Forms.Label lblDeudor;
        private System.Windows.Forms.Label lblAcreedor;
        private System.Windows.Forms.Button btnGenerarDevolucion;
        private System.Windows.Forms.DataGridView dgvPrestamos;
        private System.Windows.Forms.Label lblRegistrosPrestamos;
        private System.Windows.Forms.Label lblDevolucion;
        private System.Windows.Forms.ComboBox cmbMoneda;
        private System.Windows.Forms.Label lblMoneda;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscarPrestamos;
        private System.Windows.Forms.DataGridView dgvDevolucion;
        private System.Windows.Forms.Button btnAgregarGrilla;
        private System.Windows.Forms.Button btnRetirarGrilla;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblTotalDevolucion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label lblTotal;
    }
}