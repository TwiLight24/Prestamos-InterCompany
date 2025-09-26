using Entidad;
using Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIEsys;
using Util;

namespace PrestamoEmpresasVinculadas
{
    public partial class CancelarPrestamosDevoluciones : Form
    {
        Utilidades util = new Utilidades();

        public CancelarPrestamosDevoluciones()
        {
            InitializeComponent();
            UISAP.Form(this, null, null, null, null, "Cancelar Prestamos y Devoluciones", "Golden", "Exit", "3");
            UISAP.Grid(dgvPrestamos, false, "Golden", false);
            UISAP.Grid(dgvDevolucion, false, "Golden", false);
            UISAP.Grid(dgvReconciliacion, false, "Golden", false);
        }

        private void CancelarPrestamosDevoluciones_Load(object sender, EventArgs e)
        {
            DataTable dtEmpresaAcreedor = AccesoLogica.SP_SQL_DataTable("SP_CONSULTA_DATABASE", "", null);

            comboAcreedor.DataSource = dtEmpresaAcreedor;
            comboAcreedor.DisplayMember = "RazonSocial";
            comboAcreedor.ValueMember = "DataBaseName";
            comboAcreedor.SelectedIndex = -1;

            DataTable dtEmpresaDeudor = AccesoLogica.SP_SQL_DataTable("SP_CONSULTA_DATABASE", "", null);

            comboDeudor.DataSource = dtEmpresaDeudor;
            comboDeudor.DisplayMember = "RazonSocial";
            comboDeudor.ValueMember = "DataBaseName";
            comboDeudor.SelectedIndex = -1;
        }

        private void btnBuscarPrestamos_Click(object sender, EventArgs e)
        {
            try
            {
                string msgError = ValidacionesBusqueda();
                if (!msgError.Equals("0"))
                {
                    MessageBox.Show(msgError, "GMI System Validations", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                BusquedaCombo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelarProceso_Click(object sender, EventArgs e)
        {            
            string msgError = ValidacionesBusqueda();
            if (!msgError.Equals("0"))
            {
                MessageBox.Show(msgError, "GMI System Validations", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvDevolucion.Rows.Count > 0) { MessageBox.Show("No deben de haber Devoluciones para poder cancelar el Prestamo.", "GMI System Validations", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var row = dgvPrestamos.CurrentRow;      // o dataGridView1.SelectedRows[0]
            if (row == null) return;

            var r = MessageBox.Show(
                    this,
                    "¿Desea reelizar la Cancelación del Prestamo?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

            if (r == DialogResult.Yes)
            {
                
                string BD_acreedor = comboAcreedor.SelectedValue.ToString();
                string BD_deudor = comboDeudor.SelectedValue.ToString();

                Dictionary<string, object> _par = new Dictionary<string, object>() {
                    { "@DOCNUM_PP", row.Cells["Nro Prestamo PP"].Value.ToString() }
                };

                csSAP.LoginSAP_All(BD_acreedor);
                string DocEntryPP = AccesoLogica.SP_SQL_Cadena("SP_OBTENER_DOCENTRY_PP", BD_acreedor, _par);
                csSAP.CancelPayment(int.Parse(DocEntryPP));

                DesconexionConexionSAP();

                //*************************************************************

                Dictionary<string, object> _par2 = new Dictionary<string, object>() {
                    { "@DOCNUM_PR", row.Cells["Nro Prestamo PR"].Value.ToString() }
                };

                csSAP.LoginSAP_All(BD_deudor);
                string DocEntryPR = AccesoLogica.SP_SQL_Cadena("SP_OBTENER_DOCENTRY_PR", BD_deudor, _par2);
                csSAP.CancelPaymentReceived(int.Parse(DocEntryPR));

                DesconexionConexionSAP();

                Dictionary<string, object> _par3 = new Dictionary<string, object>() {
                        { "@DOCNUM_PP", row.Cells["Nro Prestamo PP"].Value.ToString() },
                        { "@DOCNUM_PR", row.Cells["Nro Prestamo PR"].Value.ToString() }
                    };

                AccesoLogica.SP_A_U_SQL("SP_ACTUALIZA_LOG_PRESTAMOS", BD_acreedor, _par3);

                BuscarPrestamosxCodigo();
                //BusquedaCombo();
                Limpieza();

                MessageBox.Show("Proceso de Cancelacion realizado de manera exitosa.", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelarDevolucion_Click(object sender, EventArgs e)
        {

            string msgError = ValidacionesBusqueda();
            if (!msgError.Equals("0"))
            {
                MessageBox.Show(msgError, "GMI System Validations", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvReconciliacion.Rows.Count > 0) { MessageBox.Show("No deben de haber Reconciliaciones para poder cancelar alguna Devolución.", "GMI System Validations", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }


            var row = dgvDevolucion.CurrentRow;      // o dataGridView1.SelectedRows[0]
            if (row == null) return;


            var r = MessageBox.Show(
                    this,
                    "¿Desea reelizar la Cancelación de la Devolución?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);


            if (r == DialogResult.Yes)
            {
                string BD_acreedor = comboAcreedor.SelectedValue.ToString();
                string BD_deudor = comboDeudor.SelectedValue.ToString();

                Dictionary<string, object> _par = new Dictionary<string, object>() {
                    { "@DOCNUM_PP", row.Cells["Nro Devolucion PP"].Value.ToString() }
                };

                csSAP.LoginSAP_All(BD_deudor);
                string DocEntryPP = AccesoLogica.SP_SQL_Cadena("SP_OBTENER_DOCENTRY_PP", BD_deudor, _par);
                csSAP.CancelPayment(int.Parse(DocEntryPP));

                DesconexionConexionSAP();

                //*************************************************************

                Dictionary<string, object> _par2 = new Dictionary<string, object>() {
                    { "@DOCNUM_PR", row.Cells["Nro Devolucion PR"].Value.ToString() }
                };

                csSAP.LoginSAP_All(BD_acreedor);
                string DocEntryPR = AccesoLogica.SP_SQL_Cadena("SP_OBTENER_DOCENTRY_PR", BD_acreedor, _par2);
                csSAP.CancelPaymentReceived(int.Parse(DocEntryPR));

                DesconexionConexionSAP();

                Dictionary<string, object> _par3 = new Dictionary<string, object>() {
                        { "@DOCNUM_PP", row.Cells["Nro Devolucion PP"].Value.ToString() },
                        { "@DOCNUM_PR", row.Cells["Nro Devolucion PR"].Value.ToString() }
                    };

                AccesoLogica.SP_A_U_SQL("SP_ACTUALIZA_LOG_DEVOLUCION", BD_deudor, _par3);


                BuscarPrestamosxCodigo();

                MessageBox.Show("Proceso de Cancelacion realizado de manera exitosa.", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

        }

        private void btnCancelarReconciliacion_Click(object sender, EventArgs e)
        {
            string msgError = ValidacionesBusqueda();
            if (!msgError.Equals("0"))
            {
                MessageBox.Show(msgError, "GMI System Validations", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var row = dgvReconciliacion.CurrentRow;      // o dataGridView1.SelectedRows[0]
            if (row == null) return;


            var r = MessageBox.Show(
                    this,
                    "¿Desea reelizar la Cancelación de la Reconciliación?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);


            if (r == DialogResult.Yes)
            {
                string BD_acreedor = comboAcreedor.SelectedValue.ToString();
                string BD_deudor = comboDeudor.SelectedValue.ToString();

                csSAP.LoginSAP_All(BD_deudor);
                csSAP.CancelInternalRecon(int.Parse(row.Cells["Nro Recon. Deudor"].Value.ToString()));
                DesconexionConexionSAP();

                //*************************************************************

                csSAP.LoginSAP_All(BD_acreedor);
                csSAP.CancelInternalRecon(int.Parse(row.Cells["Nro Recon. Acreedor"].Value.ToString()));
                DesconexionConexionSAP();

                Dictionary<string, object> _par3 = new Dictionary<string, object>() {
                        { "@RECNUM_DEUDOR", row.Cells["Nro Recon. Deudor"].Value.ToString() },
                        { "@RECNUM_ACREEDOR", row.Cells["Nro Recon. Acreedor"].Value.ToString() }
                };

                AccesoLogica.SP_A_U_SQL("SP_ACTUALIZA_LOG_RECONCILIACION", BD_acreedor, _par3);

                BuscarPrestamosxCodigo();

                MessageBox.Show("Proceso de Cancelacion realizado de manera exitosa.", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DesconexionConexionSAP()
        {
            try
            {
                csSAP.DisconnectSAP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        #region Metodos Complementarios
        
        private void cmbPrestamos_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                BuscarPrestamosxCodigo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BusquedaCombo()
        {
            try
            {
                //Dictionary<string, object> _par4 = new Dictionary<string, object>() {
                //        { "@RAZON_SOCIAL", comboAcreedor.SelectedItem.ToString() }
                //    };
                //string BD_acreedor = AccesoLogica.SP_SQL_Cadena("SP_RETORNAR_NOMBRE_BD", "Z_SBO_RUMI_25072025_2", _par4);
                //Dictionary<string, object> _par = new Dictionary<string, object>() { };

                string BD_acreedor = comboAcreedor.SelectedValue.ToString();
                cmbPrestamos.DataSource = AccesoLogica.SP_SQL_DataTable("SP_VISUALIZAR_TODOS_PRESTAMOS", BD_acreedor, null);
                cmbPrestamos.DisplayMember = "Nro Prestamo PP";
                cmbPrestamos.ValueMember = "Nro Prestamo PP";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Limpieza()
        {

            comboAcreedor.SelectedIndex = -1;
            comboDeudor.SelectedIndex = -1;
            //cmbPrestamos.DataSource = null;    // corta el binding
            //cmbPrestamos.Items.Clear();        // por si quedó algo
            //cmbPrestamos.SelectedIndex = -1;
            //cmbPrestamos.Text = "";
            if (dgvPrestamos.Rows.Count > 0) { dgvPrestamos.Rows.Clear(); }
        }

        private void BuscarPrestamosxCodigo()
        {
            try
            {
                //Dictionary<string, object> _par4 = new Dictionary<string, object>() {
                //        { "@RAZON_SOCIAL", comboAcreedor.SelectedItem.ToString() }
                //    };
                //string BD_acreedor = AccesoLogica.SP_SQL_Cadena("SP_RETORNAR_NOMBRE_BD", "Z_SBO_RUMI_25072025_2", _par4);

                //Dictionary<string, object> _par5 = new Dictionary<string, object>() {
                //        { "@RAZON_SOCIAL", comboDeudor.SelectedItem.ToString() }
                //    };
                //string BD_deudor = AccesoLogica.SP_SQL_Cadena("SP_RETORNAR_NOMBRE_BD", "Z_SBO_RUMI_25072025_2", _par5);

                string BD_acreedor = comboAcreedor.SelectedValue.ToString();
                string BD_deudor = comboDeudor.SelectedValue.ToString();

                Dictionary<string, object> _par = new Dictionary<string, object>() { { "@Nro_Prestamo", cmbPrestamos.SelectedValue.ToString() } };

                dgvPrestamos.DataSource = AccesoLogica.SP_SQL_DataTable("SP_VISUALIZAR_LOG_PRESTAMOS", BD_acreedor, _par);
                dgvDevolucion.DataSource = AccesoLogica.SP_SQL_DataTable("SP_VISUALIZAR_LOG_DEVOLUCIONES", BD_deudor, _par);
                dgvReconciliacion.DataSource = AccesoLogica.SP_SQL_DataTable("SP_VISUALIZAR_LOG_RECONCILIACION", BD_acreedor, _par);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string ValidacionesBusqueda()
        {

            if (comboAcreedor.SelectedItem == null || comboAcreedor.SelectedItem.ToString() == "")
            {
                return "Debe de Seleccionar el Acreedor.";
            }
            else if (comboDeudor.SelectedItem == null || comboDeudor.SelectedItem.ToString() == "")
            {
                return "Debe de Seleccionar el Deudor.";
            }
            else if (comboAcreedor.SelectedValue.ToString() == comboDeudor.SelectedValue.ToString())
            {
                return "El Acreedor y el Deudor no puede ser el mismo.";
            }

            return "0";
        }

        private void CancelarProceso_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu frmMenu = new Menu();
            frmMenu.Show();
            this.Hide();
        }

        private void comboDeudor_DrawItem(object sender, DrawItemEventArgs e)
        {
            util.FormatearCombo(sender, e, "RazonSocial");
        }

        private void comboAcreedor_DrawItem(object sender, DrawItemEventArgs e)
        {
            util.FormatearCombo(sender, e, "RazonSocial");
        }

        #endregion
    }
}
