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
    public partial class GenerarReconciliacion : Form
    {
        Utilidades util = new Utilidades();

        public GenerarReconciliacion()
        {
            InitializeComponent();
            UISAP.Form(this, null, null, null, null, "Generar Reconciliación", "Golden", "Exit", "3");
            UISAP.Grid(dgvPrestamos, false, "Golden", false);
        }

        private void GenerarReconciliacion_Load(object sender, EventArgs e)
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
                Busqueda();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerarReconciliacion_Click(object sender, EventArgs e)
        {
            try
            {
                string msgError = ValidacionesBusqueda();
                if (!msgError.Equals("0"))
                {
                    MessageBox.Show(msgError, "GMI System Validations", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var row = dgvPrestamos.CurrentRow;
                if (row == null) return;

                var r = MessageBox.Show(
                    this,
                    "¿Desea generar el Reconciliacion del Prestamo?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (r == DialogResult.Yes)
                {
                    int numReconAcreedor = 0, numReconDeudor = 0;
                    string BD_acreedor = comboAcreedor.SelectedValue.ToString();
                    string BD_deudor = comboDeudor.SelectedValue.ToString();

                    Dictionary<string, object> _par = new Dictionary<string, object>() {
                        { "@PRESTAMO", row.Cells["Nro Prestamo"].Value.ToString() },
                        { "@BANCO", row.Cells["Cuenta Banco"].Value.ToString() }
                    };

                    DataTable dtPrestamo = AccesoLogica.SP_SQL_DataTable("SP_PRESTAMO_RECONCILIACION", BD_acreedor, _par);
                    csSAP.LoginSAP_All(BD_acreedor);
                    csSAP.MadeInternalReconciliation(ref numReconAcreedor, dtPrestamo);
                    DesconexionConexionSAP();

                    DataTable dtDevolucion = AccesoLogica.SP_SQL_DataTable("SP_DEVOLUCION_RECONCILIACION", BD_deudor, _par);
                    csSAP.LoginSAP_All(BD_deudor);
                    csSAP.MadeInternalReconciliation(ref numReconDeudor, dtDevolucion);
                    DesconexionConexionSAP();


                    Dictionary<string, object> _par2 = new Dictionary<string, object>() {
                        { "@NRO_PRESTAMO", row.Cells["Nro Prestamo"].Value.ToString() },
                        { "@NUMRECON_PRESTAMO", numReconAcreedor },
                        { "@EMPRESA_PRESTAMO", BD_acreedor },
                        { "@NUMRECON_DEUDOR", numReconDeudor },
                        { "@EMPRESA_DEUDOR", BD_deudor }
                    };

                    AccesoLogica.SP_A_U_SQL("SP_LOG_RECONCILIACION", BD_acreedor, _par2);

                    Busqueda();

                    MessageBox.Show("Proceso de Reconciliación realizado de manera exitosa.", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    //MessageBox.Show("Conexion a SAP exitosa");
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
            else if (cmbMoneda.SelectedItem == null || cmbMoneda.SelectedItem.ToString() == "")
            {
                return "Debe de Seleccionar la Moneda.";
            }
            else if (comboAcreedor.SelectedValue.ToString() == comboDeudor.SelectedValue.ToString())
            {
                return "El Acreedor y el Deudor no puede ser el mismo.";
            }

            return "0";
        }

        private void Busqueda()
        {
            try
            {

                string BD_acreedor = comboAcreedor.SelectedValue.ToString();
                string BD_deudor = comboDeudor.SelectedValue.ToString();

                Dictionary<string, object> _par = new Dictionary<string, object>() {
                    { "@MONEDA", cmbMoneda.SelectedValue.ToString() },
                    { "@EMPRESA_ACREEDORA" , BD_acreedor },
                    { "@EMPRESA_DEUDORA" , BD_deudor }
                };

                dgvPrestamos.DataSource = AccesoLogica.SP_SQL_DataTable("SP_PRESTAMOS_PAGADOS", BD_acreedor, _par);

                AjusteGrillaReconciliaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AjusteGrillaReconciliaciones()
        {
            dgvPrestamos.Columns[0].Visible = false;
        }

        private void GenerarReconciliacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu frmMenu = new Menu();
            frmMenu.Show();
            this.Hide();
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
