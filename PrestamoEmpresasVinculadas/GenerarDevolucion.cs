using Entidad;
using Negocio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIEsys;
using Util;

namespace PrestamoEmpresasVinculadas
{
    public partial class GenerarDevolucion : Form
    {

        Utilidades util = new Utilidades();

        public GenerarDevolucion()
        {
            InitializeComponent();
            UISAP.Form(this, null, null, null, null, "Generar Devolución", "Golden", "Exit", "3");
            UISAP.Grid(dgvPrestamos, false, "Change", false);
            UISAP.Grid(dgvDevolucion, false, "Change", false);
        }

        private void GenerarDevolucion_Load(object sender, EventArgs e)
        {
            this.AutoValidate = AutoValidate.EnablePreventFocusChange;
            dgvDevolucion.CausesValidation = true;
            btnGenerarDevolucion.CausesValidation = true;

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

                string BD_acreedor = comboAcreedor.SelectedValue.ToString();
                string BD_deudor = comboDeudor.SelectedValue.ToString();

                Dictionary<string, object> _par = new Dictionary<string, object>() {
                    { "@MONEDA", cmbMoneda.SelectedValue.ToString() },
                    { "@EMPRESA_ACREEDORA" , BD_acreedor },
                    { "@EMPRESA_DEUDORA" , BD_deudor }
                };

                dgvPrestamos.DataSource = AccesoLogica.SP_SQL_DataTable("SP_PRESTAMOS_PENDIENTES", BD_deudor, _par);
                AjusteGrillaPrestamos();
                AjusteGrillaDevoluciones();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerarDevolucion_Click(object sender, EventArgs e)
        {
            try
            {
                dgvDevolucion.EndEdit();
                if (!this.ValidateChildren()) return;

                /*** VALIDACIONES INTERNAS ***/
                string msgError = Validaciones();
                if (!msgError.Equals("0"))
                {
                    MessageBox.Show(msgError, "GMI System Validations", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var r = MessageBox.Show(
                    this,                                   
                    "¿Desea generar la Devolución?",        
                    "Confirmación",                         
                    MessageBoxButtons.YesNo,                
                    MessageBoxIcon.Question,                
                    MessageBoxDefaultButton.Button2);       

                if (r == DialogResult.Yes)
                {
                    string BD_acreedor = comboAcreedor.SelectedValue.ToString();
                    string BD_deudor = comboDeudor.SelectedValue.ToString();
                    string RZ_acreedor = comboAcreedor.GetItemText(comboAcreedor.SelectedItem);

                    /*** PROCESO DE DEVOLUCION ***/
                    string DocNumPP = string.Empty, DocNumPR = string.Empty;

                    PP_EmpresaDeudora(ref DocNumPP, BD_deudor, RZ_acreedor);
                    PR_EmpresaAcreedora(ref DocNumPR, DocNumPP, BD_acreedor);

                    foreach (DataGridViewRow row in dgvDevolucion.Rows)
                    {
                        Dictionary<string, object> _par = new Dictionary<string, object>() {
                            { "@NRO_PRESTAMO", row.Cells["DocNum"].Value.ToString() },
                            { "@EMPRESA_PP", BD_deudor },
                            { "@DOCNUM_PP", DocNumPP },
                            { "@EMPRESA_PR", BD_acreedor },
                            { "@DOCNUM_PR", DocNumPR }
                        };

                        AccesoLogica.SP_A_U_SQL("SP_LOG_DEVOLUCIONES", BD_deudor, _par);
                    }

                    MessageBox.Show("Proceso de Devolución creado de manera exitosa.", "Exito!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpieza();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool PP_EmpresaDeudora(ref string DocNumPP, string BD_deudor, string RZ_acreedor)
        {
            try
            {
                //** CREACION DE PAGO EFECTUADO PRESTAMO **
                csSAP.LoginSAP_All(BD_deudor);

                OVPM objOVPM = new OVPM();
                objOVPM.DocDate = DateTime.Parse(dtpFecha.Text);
                objOVPM.DocTotal = double.Parse(lblTotalDevolucion.Text);
                objOVPM.Comments = txtComentario.Text.ToString();
                objOVPM.CardName = RZ_acreedor;
                objOVPM.DocCurr = cmbMoneda.SelectedValue.ToString();

                objOVPM.Lineas = new List<VPM4>();
                foreach (DataGridViewRow row in dgvDevolucion.Rows)
                {
                    if (row.IsNewRow) continue;
                    VPM4 objVPM4 = new VPM4(0, row.Cells["DocNum"].Value.ToString(), row.Cells["Comentario Prestamo"].Value.ToString(), double.Parse(row.Cells["MontoDevolucion"].Value.ToString()));
                    objOVPM.Lineas.Add(objVPM4);
                }

                csSAP.AddPayment_Devolucion(ref DocNumPP, objOVPM);

                DesconexionConexionSAP();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool PR_EmpresaAcreedora(ref string DocNumPR, string DocNumPP, string BD_acreedor)
        {
            try
            {
                //** CREACION DE PAGO RECIBIDO PRESTAMO **

                csSAP.LoginSAP_All(BD_acreedor);

                ORCT objORCT = new ORCT();
                objORCT.DocDate = DateTime.Parse(dtpFecha.Text);
                objORCT.DocTotal = double.Parse(lblTotalDevolucion.Text);
                objORCT.Comments = txtComentario.Text.ToString();
                objORCT.DocCurr = cmbMoneda.SelectedValue.ToString();

                objORCT.Lineas = new List<RCT4>();
                foreach (DataGridViewRow row in dgvDevolucion.Rows)
                {
                    if (row.IsNewRow) continue;
                    RCT4 objRCT4 = new RCT4(0, row.Cells["DocNum"].Value.ToString(), row.Cells["Comentario Prestamo"].Value.ToString(), double.Parse(row.Cells["MontoDevolucion"].Value.ToString()));
                    objORCT.Lineas.Add(objRCT4);
                }

                csSAP.AddPaymentReceived_Devolucion(ref DocNumPR, objORCT, DocNumPP);

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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarGrid(dgvPrestamos);
            LimpiarGrid(dgvDevolucion);
        }

        private void btnAgregarGrilla_Click(object sender, EventArgs e)
        {
            if (dgvPrestamos.SelectedRows.Count > 0) {

                var sel = dgvPrestamos.SelectedRows
                          .Cast<DataGridViewRow>()
                          .Where(r => !r.IsNewRow)
                          .OrderBy(r => r.Index)
                          .ToList();

                foreach (var src in sel)
                {
                    var doc = src.Cells["DocNum"].Value?.ToString() ?? "";
                    bool existe = dgvDevolucion.Rows
                                     .Cast<DataGridViewRow>()
                                     .Any(r => !r.IsNewRow &&
                                               (r.Cells["DocNum"].Value?.ToString() ?? "") == doc);
                    if (existe) continue;

                    var newRow = (DataGridViewRow)src.Clone();
                    for (int i = 0; i < src.Cells.Count; i++)
                        newRow.Cells[i].Value = src.Cells[i].Value;

                    dgvDevolucion.Rows.Add(newRow);
                }

                foreach (var r in sel.OrderByDescending(x => x.Index))
                    dgvPrestamos.Rows.RemoveAt(r.Index);

            }
            SumarTotalesFilas();
        }

        private void btnRetirarGrilla_Click(object sender, EventArgs e)
        {
            if (dgvDevolucion.SelectedRows.Count > 0)
            {

                var dtSrc = dgvPrestamos.DataSource as DataTable;
                if (dtSrc == null) { MessageBox.Show("El grid de origen no está enlazado a DataTable."); return; }

                if (dtSrc.PrimaryKey.Length == 0 && dtSrc.Columns.Contains("DocNum"))
                    dtSrc.PrimaryKey = new[] { dtSrc.Columns["DocNum"] };

                var sel = dgvDevolucion.SelectedRows.Cast<DataGridViewRow>().OrderByDescending(r => r.Index).ToList();

                foreach (var src in sel)
                {
                    if (src.IsNewRow) continue;

                    object key = src.Cells["DocNum"].Value;
                    if (dtSrc.Columns.Contains("DocNum") && dtSrc.PrimaryKey.Length > 0 && key != null)
                        if (dtSrc.Rows.Find(key) != null) { dgvDevolucion.Rows.RemoveAt(src.Index); continue; }

                    DataRow dr = dtSrc.NewRow();
                    foreach (DataGridViewColumn c in dgvPrestamos.Columns)
                        dr[c.Name] = src.Cells[c.Name].Value ?? DBNull.Value;

                    dtSrc.Rows.Add(dr);                   // <- agregar al DataTable, no al grid
                    dgvDevolucion.Rows.RemoveAt(src.Index);
                }

            }
            SumarTotalesFilas();
        }

        private void SumarTotalesFilas()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in dgvDevolucion.Rows)
            {
                // Evitar la fila de nueva entrada si está habilitada
                if (row.IsNewRow) continue;

                // Sumar solo si el valor no es nulo
                if (row.Cells["MontoDevolucion"].Value != null &&
                    decimal.TryParse(row.Cells["MontoDevolucion"].Value.ToString(), out decimal valor))
                {
                    total += valor;
                }
            }
            lblTotalDevolucion.Text = total.ToString("N2");
        }

        private void AjusteGrillaPrestamos()
        {
            dgvPrestamos.Columns[0].Visible = false;
            dgvPrestamos.Columns[1].Width = 54;
            dgvPrestamos.Columns[2].Width = 70;
            dgvPrestamos.Columns[3].Width = 168;
            dgvPrestamos.Columns[4].Width = 50;
            dgvPrestamos.Columns[5].Width = 90;
            dgvPrestamos.Columns[6].Width = 70;
        }

        private void AjusteGrillaDevoluciones()
        {
            if (dgvDevolucion.Columns.Count == 0)
            {
                foreach (DataGridViewColumn col in dgvPrestamos.Columns)
                {
                    var clone = (DataGridViewColumn)col.Clone();
                    clone.Name = col.Name;
                    clone.HeaderText = col.HeaderText;
                    dgvDevolucion.Columns.Add(clone);
                }

            }

            //dgvDevolucion.Columns.Add("MontoDevolucion", "MontoDevolucion");

            if (dgvDevolucion.Columns["MontoDevolucion"] == null)
            {
                var col = new DataGridViewTextBoxColumn
                {
                    Name = "MontoDevolucion",
                    HeaderText = "Monto Devolución",
                    ValueType = typeof(decimal)
                };
                col.DefaultCellStyle.Format = "N2";
                dgvDevolucion.Columns.Add(col);
            }


            dgvDevolucion.Columns[0].Visible = false;
            dgvDevolucion.Columns[1].Width = 54;
            dgvDevolucion.Columns[2].Visible = false;
            dgvDevolucion.Columns[3].Width = 168;
            dgvDevolucion.Columns[4].Width = 50;
            dgvDevolucion.Columns[5].Visible = false;
            dgvDevolucion.Columns[6].Width = 70;

            dgvDevolucion.Columns[0].ReadOnly = true;
            dgvDevolucion.Columns[1].ReadOnly = true;
            dgvDevolucion.Columns[2].ReadOnly = true;
            dgvDevolucion.Columns[3].ReadOnly = true;
            dgvDevolucion.Columns[4].ReadOnly = true;
            dgvDevolucion.Columns[5].ReadOnly = true;
            dgvDevolucion.Columns[6].ReadOnly = true;

        }

        private void GenerarDevolucion_FormClosed(object sender, FormClosedEventArgs e)
        {
            Menu frmMenu = new Menu();
            frmMenu.Show();
            this.Hide();
        }

        private void Limpieza()
        {

            if (dgvPrestamos.Rows.Count > 0){ dgvPrestamos.Rows.Clear(); }
            if (dgvDevolucion.Rows.Count > 0) { dgvDevolucion.Rows.Clear(); }
            txtComentario .Text = "";
            lblTotalDevolucion.Text = "0.00";
            comboAcreedor.SelectedIndex = -1;
            comboDeudor.SelectedIndex = -1;
            cmbMoneda.SelectedIndex = -1;
            dtpFecha.Value = DateTime.Now;
        }

        private void LimpiarGrid(DataGridView gv, bool quitarColumnas = false)
        {
            if (gv.DataSource is BindingSource bs)
            {
                if (bs.DataSource is DataTable dt)          // DataTable enlazado vía BindingSource
                    dt.Clear();
                else if (bs.DataSource is IList list)       // List<T> u otra colección
                {
                    list.Clear();
                    bs.ResetBindings(false);
                }
                else
                {
                    bs.DataSource = null;
                }
            }
            else if (gv.DataSource is DataTable dt)         // DataTable directo
            {
                dt.Clear();
            }
            else                                            // Grid NO enlazado
            {
                gv.Rows.Clear();
            }

            if (quitarColumnas)
            {
                gv.DataSource = null;
                gv.Columns.Clear();
            }

            gv.ClearSelection();
            gv.Refresh();
        }

        private string Validaciones()
        {

            if (comboAcreedor.SelectedItem == null || comboAcreedor.SelectedItem.ToString() == "")
            {
                return "Debe de Ingresar el Acreedor a quien se le hara la Devolución.";
            }
            else if (comboDeudor.SelectedItem == null || comboDeudor.SelectedItem.ToString() == "")
            {
                return "Debe de Ingresar el Deudor que hara la Devolución.";
            }
            else if (cmbMoneda.SelectedItem == null || cmbMoneda.SelectedItem.ToString() == "")
            {
                return "Debe de Ingresar la Moneda de la Devolución.";
            }
            else if (lblTotalDevolucion.Text == null || lblTotalDevolucion.Text == "" || lblMoneda.Text == "0.00")
            {
                return "La Devolución debe de tener un monto mayor a 0.00.";
            }
            else if (dgvDevolucion.Rows.Count <= 0)
            {
                return "Debe de seleccionar Prestamos de la grilla para porder generar la Devolución.";
            }
            else if (comboAcreedor.SelectedValue.ToString() == comboDeudor.SelectedValue.ToString())
            {
                return "El Acreedor y el Deudor no puede ser el mismo.";
            }

            return "0";
        }

        private string ValidacionesBusqueda()
        {

            if (comboAcreedor.SelectedItem == null || comboAcreedor.SelectedItem.ToString() == "")
            {
                return "Debe de Ingresar el Acreedor a quien se le hara la Devolución.";
            }
            else if (comboDeudor.SelectedItem == null || comboDeudor.SelectedItem.ToString() == "")
            {
                return "Debe de Ingresar el Deudor que hara la Devolución.";
            }
            else if (cmbMoneda.SelectedItem == null || cmbMoneda.SelectedItem.ToString() == "")
            {
                return "Debe de Ingresar la Moneda de la Devolución.";
            }
            else if (comboAcreedor.SelectedValue.ToString() == comboDeudor.SelectedValue.ToString())
            {
                return "El Acreedor y el Deudor no puede ser el mismo.";
            }

            return "0";
        }

        private void dgvDevolucion_EditModeChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvDevolucion_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            
        }

        private void dgvDevolucion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SumarTotalesFilas();
        }

        private void dgvDevolucion_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvDevolucion.Columns[e.ColumnIndex].Name != "MontoDevolucion") return;

            // Obtén el saldo de la fila
            decimal saldo = 0m;
            decimal.TryParse(Convert.ToString(
                dgvDevolucion.Rows[e.RowIndex].Cells["Saldo"].Value), out saldo);

            // Valida número y regla
            bool invalido = !decimal.TryParse(Convert.ToString(e.FormattedValue), out decimal montoDev)
                            || montoDev > saldo
                            || montoDev < 0m; // evita negativos si aplica

            if (invalido)
            {
                dgvDevolucion.Rows[e.RowIndex].Cells["MontoDevolucion"].ErrorText =
                    "Monto inválido (numérico, ≥ 0 y ≤ Saldo).";

                // Escribe 0.00 en el control de edición y mantiene el foco en la celda
                if (dgvDevolucion.EditingControl is DataGridViewTextBoxEditingControl tb)
                {
                    tb.Text = "0.00";
                    tb.SelectAll();  // para que el usuario reescriba fácil
                }

                e.Cancel = true; // <-- NO permite salir de la celda ni hacer clic en el botón
                return;
            }

            // OK
            dgvDevolucion.Rows[e.RowIndex].Cells["MontoDevolucion"].ErrorText = string.Empty;
        }

        private void dgvDevolucion_CurrentCellChanged(object sender, EventArgs e)
        {
            SumarTotalesFilas();
        }

        private void dgvDevolucion_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (dgvDevolucion.Columns[e.ColumnIndex].Name != "MontoDevolucion") return;

            if (Equals(dgvDevolucion.Rows[e.RowIndex].Tag, "RESET_DEVOLUCION"))
            {
                dgvDevolucion.Rows[e.RowIndex].Cells["MontoDevolucion"].Value = 0.00m;
                dgvDevolucion.Rows[e.RowIndex].Cells["MontoDevolucion"].ErrorText = string.Empty;
                dgvDevolucion.Rows[e.RowIndex].Tag = null;
            }
        }

        private void comboDeudor_DrawItem(object sender, DrawItemEventArgs e)
        {
            util.FormatearCombo(sender, e, "RazonSocial");
        }

        private void comboAcreedor_DrawItem(object sender, DrawItemEventArgs e)
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
