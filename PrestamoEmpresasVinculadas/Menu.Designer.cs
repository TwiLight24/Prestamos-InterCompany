namespace PrestamoEmpresasVinculadas
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.btnGenerarPrestamo = new System.Windows.Forms.Button();
            this.btnGenerarDevolucion = new System.Windows.Forms.Button();
            this.btnGenerarReconciliacion = new System.Windows.Forms.Button();
            this.btnCancelarProceso = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerarPrestamo
            // 
            this.btnGenerarPrestamo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarPrestamo.Location = new System.Drawing.Point(27, 115);
            this.btnGenerarPrestamo.Name = "btnGenerarPrestamo";
            this.btnGenerarPrestamo.Size = new System.Drawing.Size(228, 51);
            this.btnGenerarPrestamo.TabIndex = 0;
            this.btnGenerarPrestamo.Text = "Generar Prestamo";
            this.btnGenerarPrestamo.UseVisualStyleBackColor = true;
            this.btnGenerarPrestamo.Click += new System.EventHandler(this.btnGenerarPrestamo_Click);
            // 
            // btnGenerarDevolucion
            // 
            this.btnGenerarDevolucion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarDevolucion.Location = new System.Drawing.Point(27, 185);
            this.btnGenerarDevolucion.Name = "btnGenerarDevolucion";
            this.btnGenerarDevolucion.Size = new System.Drawing.Size(228, 51);
            this.btnGenerarDevolucion.TabIndex = 1;
            this.btnGenerarDevolucion.Text = "Generar Devolucion";
            this.btnGenerarDevolucion.UseVisualStyleBackColor = true;
            this.btnGenerarDevolucion.Click += new System.EventHandler(this.btnGenerarDevolucion_Click);
            // 
            // btnGenerarReconciliacion
            // 
            this.btnGenerarReconciliacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarReconciliacion.Location = new System.Drawing.Point(27, 261);
            this.btnGenerarReconciliacion.Name = "btnGenerarReconciliacion";
            this.btnGenerarReconciliacion.Size = new System.Drawing.Size(228, 57);
            this.btnGenerarReconciliacion.TabIndex = 2;
            this.btnGenerarReconciliacion.Text = "Generar Reconciliacion";
            this.btnGenerarReconciliacion.UseVisualStyleBackColor = true;
            this.btnGenerarReconciliacion.Click += new System.EventHandler(this.btnGenerarReconciliacion_Click);
            // 
            // btnCancelarProceso
            // 
            this.btnCancelarProceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelarProceso.Location = new System.Drawing.Point(27, 343);
            this.btnCancelarProceso.Name = "btnCancelarProceso";
            this.btnCancelarProceso.Size = new System.Drawing.Size(228, 57);
            this.btnCancelarProceso.TabIndex = 3;
            this.btnCancelarProceso.Text = "Cancelar Prestamos y Devoluciones";
            this.btnCancelarProceso.UseVisualStyleBackColor = true;
            this.btnCancelarProceso.Click += new System.EventHandler(this.btnCancelarProceso_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(55, 34);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(71, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(144, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(80, 75);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 418);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnCancelarProceso);
            this.Controls.Add(this.btnGenerarReconciliacion);
            this.Controls.Add(this.btnGenerarDevolucion);
            this.Controls.Add(this.btnGenerarPrestamo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarPrestamo;
        private System.Windows.Forms.Button btnGenerarDevolucion;
        private System.Windows.Forms.Button btnGenerarReconciliacion;
        private System.Windows.Forms.Button btnCancelarProceso;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}