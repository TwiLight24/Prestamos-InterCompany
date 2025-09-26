using Entidad;
using SAPbouiCOM;
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
    public partial class Login : System.Windows.Forms.Form
    {
        public Login()
        {
            InitializeComponent();
            UISAP.Form(this, null, null, null, null, "Login", "Golden", "Exit", "0");
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                csCompany objCompany = new csCompany();

                objCompany.ServerBD = "192.168.1.2";
                objCompany.UserBD = "analista2";
                objCompany.PassBD = "GMI4n4l2st@@2";
                objCompany.ServerLicense = "192.168.1.2:30000";
                objCompany.NameBD = "SBO_RumiImport";
                objCompany.UserSAP = txtUsuario.Text;
                objCompany.PassSAP = txtPassword.Text;
                objCompany.ServerType = 1;

                if (csSAP.LoginSAP(objCompany))
                {
                    MessageBox.Show("Conexion a SAP exitosa", "GMI Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    csSAP.UserSAP = txtUsuario.Text;
                    csSAP.PasswordSAP = txtPassword.Text;
                    csSAP.DisconnectSAP();
                    Menu frmMenu = new Menu();
                    frmMenu.Show();
                    this.Hide();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
