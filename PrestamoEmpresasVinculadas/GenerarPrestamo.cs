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
    public partial class GenerarPrestamo : Form
    {

        Utilidades util = new Utilidades();

        public GenerarPrestamo()
        {
            InitializeComponent();
            UISAP.Form(this, null, null, null, null, "Generar Prestamo", "Golden", "Exit", "3");
        }

        private void GenerarPrestamo_Load(object sender, EventArgs e)
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

            cmbMoneda.DataSource = Utilidades.GetMonedas();
            cmbMoneda.DisplayMember = "moneda";
            cmbMoneda.ValueMember = "moneda";
            cmbMoneda.SelectedIndex = -1;
        }

        private void btnGenerarPrestamo_Click(object sender, EventArgs e)
        {
            try
            {

                /*** VALIDACIONES INTERNAS ***/
                string msgError = Validaciones();
                if (!msgError.Equals("0"))
                {
                    MessageBox.Show(msgError, "GMI System Validations", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                var r = MessageBox.Show(
                    this,
                    "¿Desea generar el Prestamo?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);


                if (r == DialogResult.Yes)
                {

                    string BD_acreedor = comboAcreedor.SelectedValue.ToString();
                    string BD_deudor = comboDeudor.SelectedValue.ToString();
                    string RZ_deudor = comboDeudor.GetItemText(comboDeudor.SelectedItem);

                    /*** PROCESO DE PRESTAMO ***/
                    string DocNumPP = string.Empty, DocNumPR = string.Empty;
                        
                    PP_EmpresaAcreedora(ref DocNumPP, BD_acreedor, RZ_deudor);
                    PR_EmpresaDeudora(ref DocNumPR, DocNumPP, BD_deudor);

                    Dictionary<string, object> _par = new Dictionary<string, object>() {
                        { "@EMPRESA_PP", BD_acreedor },
                        { "@DOCNUM_PP", DocNumPP },
                        { "@EMPRESA_PR", BD_deudor },
                        { "@DOCNUM_PR", DocNumPR }
                    };

                    AccesoLogica.SP_A_U_SQL("SP_LOG_PRESTAMOS", BD_acreedor, _par);

                    MessageBox.Show("Proceso de Prestamo creado de manera exitosa.", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpieza();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool PP_EmpresaAcreedora(ref string DocNumPP, string BD_acreedor, string RZ_deudor)
        {
            try
            {

                //** CREACION DE PAGO EFECTUADO PRESTAMO **

                csSAP.LoginSAP_All(BD_acreedor);

                OVPM objOVPM = new OVPM();
                objOVPM.DocDate = DateTime.Parse(dtpFecha.Text);
                objOVPM.DocTotal = double.Parse(txtMonto.Text);
                objOVPM.Comments = txtComentarioAcreedor.Text.ToString();
                objOVPM.CardName = RZ_deudor;
                objOVPM.DocCurr = cmbMoneda.SelectedValue.ToString();

                csSAP.AddPayment_Prestamo(ref DocNumPP, objOVPM);

                DesconexionConexionSAP();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool PR_EmpresaDeudora(ref string DocNumPR, string DocNumPP, string BD_deudor)
        {
            try
            {

                //** CREACION DE PAGO RECIBIDO PRESTAMO **

                csSAP.LoginSAP_All(BD_deudor);

                ORCT objORCT = new ORCT();
                objORCT.DocDate = DateTime.Parse(dtpFecha.Text);
                objORCT.DocTotal = double.Parse(txtMonto.Text);
                objORCT.Comments = txtComentarioDeudor.Text.ToString();
                objORCT.DocCurr = cmbMoneda.SelectedValue.ToString();
                objORCT.Lineas = new List<RCT4>();
                RCT4 objRCT4 = new RCT4(0, DocNumPP, txtComentarioDeudor.Text.ToString(), double.Parse(txtMonto.Text));
                objORCT.Lineas.Add(objRCT4);

                csSAP.AddPaymentReceived_Prestamo(ref DocNumPR, objORCT);

                DesconexionConexionSAP();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ConexionSAP(string database)
        {
            try
            {
                csCompany objCompany = new csCompany();

                objCompany.ServerBD = "192.168.1.3";// this.txtServerBD.Text;
                objCompany.UserBD = "sa";// this.txtUserBD.Text;
                objCompany.PassBD = "B1Admin";//this.txtPassBD.Text;
                objCompany.ServerLicense = "192.168.1.2:30000";//this.txtServerLic.Text;
                objCompany.NameBD = database; // "Z_SBO_MEGA_29072025";//this.txtNameBD.Text;
                objCompany.UserSAP = "manager";//this.txtUserSAP.Text;
                objCompany.PassSAP = "6m1.";//this.txtPassSAP.Text;
                objCompany.ServerType = 1;//this.cboServerType.SelectedIndex;

                if (csSAP.LoginSAP(objCompany))
                {
                   // MessageBox.Show("Conexion a SAP exitosa");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void txtMonto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true; //No permitir el carácter
            }

            //Solo permitir un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true; //No permitir el carácter
            }
        }

        private void GenerarPrestamo_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu frmMenu = new Menu();
            frmMenu.Show();
            this.Hide();
        }

        private string Validaciones()
        {

            if (comboAcreedor.SelectedItem == null || comboAcreedor.SelectedItem.ToString() == "")
            {
                return "Debe de Ingresar el Acreedor del Prestamo.";
            }
            else if (comboDeudor.SelectedItem == null || comboDeudor.SelectedItem.ToString() == "")
            {
                return "Debe de Ingresar el Deudor del Prestamo.";
            }
            else if (cmbMoneda.SelectedItem == null || cmbMoneda.SelectedItem.ToString() == "")
            {
                return "Debe de Ingresar la Moneda del Prestamo.";
            }
            else if (txtMonto.Text == null || txtMonto.Text == "")
            {
                return "Debe de Ingresar el Deudor del Prestamo.";
            }
            else if (comboAcreedor.SelectedValue.ToString() == comboDeudor.SelectedValue.ToString())
            {
                return "El Acreedor y el Deudor no puede ser el mismo.";
            }

            return "0";
        }

        private void Limpieza()
        {
            txtComentarioAcreedor.Text = "";
            txtComentarioDeudor.Text = "";
            txtMonto.Text = "";
            comboAcreedor.SelectedIndex = -1;
            comboDeudor.SelectedIndex = -1;
            cmbMoneda.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
        }

        private void comboAcreedor_DrawItem(object sender, DrawItemEventArgs e)
        {
            util.FormatearCombo(sender, e, "RazonSocial");
        }

        private void comboDeudor_DrawItem(object sender, DrawItemEventArgs e)
        {
            util.FormatearCombo(sender, e, "RazonSocial");
        }

        private void cmbMoneda_DrawItem(object sender, DrawItemEventArgs e)
        {
            util.FormatearCombo(sender, e, "moneda");
        }
        
        #endregion 
    }
}
