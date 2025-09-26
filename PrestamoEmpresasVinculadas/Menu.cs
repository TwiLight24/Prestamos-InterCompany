
using log4net.Repository.Hierarchy;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using log4net.Config;

namespace PrestamoEmpresasVinculadas
{
    public partial class Menu : Form
    {

        private static readonly ILog logger = LogManager.GetLogger(typeof(Menu));

        public Menu()
        {
            
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerarPrestamo_Click(object sender, EventArgs e)
        {
            
            logger.Info("Entering application.");
            GenerarPrestamo frmPrestamo = new GenerarPrestamo();
            frmPrestamo.Show();
            this.Hide();
            
        }

        private void btnGenerarDevolucion_Click(object sender, EventArgs e)
        {
            GenerarDevolucion frmDevolucion = new GenerarDevolucion();
            frmDevolucion.Show();
            this.Hide();
        }

        private void btnGenerarReconciliacion_Click(object sender, EventArgs e)
        {
            GenerarReconciliacion frmReconciliacion = new GenerarReconciliacion();
            frmReconciliacion.Show();
            this.Hide();
        }

        private void btnCancelarProceso_Click(object sender, EventArgs e)
        {
            CancelarPrestamosDevoluciones frmCancelarProceso = new CancelarPrestamosDevoluciones();
            frmCancelarProceso.Show();
            this.Hide();
        }
    }
}
