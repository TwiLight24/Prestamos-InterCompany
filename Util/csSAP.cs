using Entidad;
using SAPbobsCOM;
using SAPbouiCOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Util
{
    public class csSAP
    {
        public static SAPbobsCOM.Company oCompany;
        public static int iRet;
        public static int iErrCod;
        public static string sErrMsg;

        public static string UserSAP;
        public static string PasswordSAP;

        public static bool LoginSAP(csCompany objCompany)
        {
            try
            {
                if (oCompany == null || !oCompany.Connected)
                {
                    oCompany = new SAPbobsCOM.Company();
                    oCompany.Server = objCompany.ServerBD;
                    oCompany.DbUserName = objCompany.UserBD;
                    oCompany.DbPassword = objCompany.PassBD;
                    if(objCompany.ServerLicense != "") oCompany.LicenseServer = objCompany.ServerLicense;
                    oCompany.CompanyDB = objCompany.NameBD;
                    oCompany.UserName = objCompany.UserSAP;
                    oCompany.Password = objCompany.PassSAP;
                    oCompany.UseTrusted = false;
                    switch (objCompany.ServerType)
                    {
                        case 0:
                            oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2014;
                            break;
                        case 1:
                            oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2017;
                            break;
                        case 2:
                            oCompany.DbServerType = BoDataServerTypes.dst_HANADB;
                            break;
                    }

                    iRet = oCompany.Connect();
                    if (iRet == 0)
                    {
                        return true;
                    }
                    else
                    {
                        oCompany.GetLastError(out iErrCod, out sErrMsg);
                        throw new Exception(String.Concat(iErrCod.ToString(), ": ", sErrMsg));
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool LoginSAP_All(string Company)
        {
            try
            {
                if (oCompany == null || !oCompany.Connected)
                {
                    oCompany = new SAPbobsCOM.Company();
                    oCompany.Server = "192.168.1.3";
                    oCompany.DbUserName = "analista2";
                    oCompany.DbPassword = "GMI4n4l2st@@2";
                    oCompany.LicenseServer = "192.168.1.2:30000";
                    oCompany.CompanyDB = Company;
                    oCompany.UserName = UserSAP;// "manager";
                    oCompany.Password = PasswordSAP;//"6m1.";
                    oCompany.UseTrusted = false;
                    oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2017;
                    iRet = oCompany.Connect();
                    if (iRet == 0)
                    {
                        return true;
                    }
                    else
                    {
                        oCompany.GetLastError(out iErrCod, out sErrMsg);
                        throw new Exception(String.Concat(iErrCod.ToString(), ": ", sErrMsg));
                    }
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static bool DisconnectSAP()
        {
            try
            {
                if (oCompany != null && oCompany.Connected)
                    oCompany.Disconnect();

                if (oCompany != null)
                {
                    Marshal.FinalReleaseComObject(oCompany);
                    oCompany = null;
                }
                GC.Collect(); GC.WaitForPendingFinalizers();
                GC.Collect(); GC.WaitForPendingFinalizers();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        /********************* PRESTAMO ************************/
        public static bool AddPayment_Prestamo(ref string DocNumPP, OVPM objOVPM)
        {
            try
            {
                Payments pay = (SAPbobsCOM.Payments)oCompany.GetBusinessObject(BoObjectTypes.oVendorPayments);

                pay.DocType = SAPbobsCOM.BoRcptTypes.rAccount;
                //pay.Series = 66;
                pay.DocCurrency = objOVPM.DocCurr;

                pay.DocDate = objOVPM.DocDate;
                pay.TaxDate = objOVPM.DocDate;
                pay.DueDate = objOVPM.DocDate;

                pay.TransferSum = objOVPM.DocTotal;
                pay.TransferDate = objOVPM.DocDate;
                pay.TransferReference = (objOVPM.Comments.Length > 21)? objOVPM.Comments.Substring(0,22): objOVPM.Comments;
                pay.TransferAccount = (objOVPM.DocCurr == "SOL") ? "104101" : "104102"; //104102 PARA DOLARES , 104101 PARA SOLES

                pay.JournalRemarks = objOVPM.Comments;
                pay.Remarks = objOVPM.Comments;
                pay.CardName = objOVPM.CardName;

                pay.AccountPayments.AccountCode = "171201";
                pay.AccountPayments.Decription = objOVPM.Comments;
                pay.AccountPayments.SumPaid = objOVPM.DocTotal;

                iRet = pay.Add();

                if (iRet == 0)
                {
                    int docEntry = int.Parse(oCompany.GetNewObjectKey());

                    SAPbobsCOM.Payments oPayGet =  (SAPbobsCOM.Payments)oCompany.GetBusinessObject(BoObjectTypes.oVendorPayments);

                    if (oPayGet.GetByKey(docEntry))
                    {
                        DocNumPP = oPayGet.DocNum.ToString();
                    }

                    return true;
                }
                else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);
                    throw new Exception(String.Concat(iErrCod.ToString(), ": ", sErrMsg));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddPaymentReceived_Prestamo(ref string DocNumPR, ORCT objORCT)
        {
            try
            {
                Payments pay = (SAPbobsCOM.Payments)oCompany.GetBusinessObject(BoObjectTypes.oIncomingPayments);

                pay.DocType = SAPbobsCOM.BoRcptTypes.rAccount;
                pay.DocCurrency = objORCT.DocCurr;

                pay.DocDate = objORCT.DocDate;
                pay.TaxDate = objORCT.DocDate;
                pay.DueDate = objORCT.DocDate;

                pay.TransferSum = objORCT.DocTotal;
                pay.TransferDate = objORCT.DocDate;
                pay.TransferReference = (objORCT.Comments.Length > 21) ? objORCT.Comments.Substring(0, 22) : objORCT.Comments;
                pay.TransferAccount = (objORCT.DocCurr == "SOL") ? "104101" : "104102"; //104102 PARA DOLARES , 104101 PARA SOLES

                pay.JournalRemarks = objORCT.Comments;
                pay.Remarks = objORCT.Comments;

                pay.UserFields.Fields.Item("U_BPP_TRAN").Value = "001";
                pay.UserFields.Fields.Item("U_VS_RUBRO").Value = "03";

                if (objORCT.Lineas.Count() > 0)
                {

                    foreach (RCT4 newObj in objORCT.Lineas)
                    {
                        pay.AccountPayments.AccountCode = "471003";
                        pay.AccountPayments.Decription = newObj.LineMemo;
                        pay.AccountPayments.SumPaid = newObj.LineTotal;
                        pay.AccountPayments.UserFields.Fields.Item("U_GMI_PAGORELACION").Value = newObj.U_GMI_PAGORELACION;
                        pay.AccountPayments.Add();
                    }

                }

                iRet = pay.Add();

                if (iRet == 0)
                {
                    int docEntry = int.Parse(oCompany.GetNewObjectKey());

                    SAPbobsCOM.Payments oPayGet = (SAPbobsCOM.Payments)oCompany.GetBusinessObject(BoObjectTypes.oIncomingPayments);

                    if (oPayGet.GetByKey(docEntry))
                    {
                        DocNumPR = oPayGet.DocNum.ToString();
                    }

                    return true;
                }
                else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);
                    throw new Exception(String.Concat(iErrCod.ToString(), ": ", sErrMsg));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*******************************************************/



        /******************** DEVOLUCION ************************/
        public static bool AddPayment_Devolucion(ref string DocNumPP, OVPM objOVPM)
        {
            try
            {
                Payments pay = (SAPbobsCOM.Payments)oCompany.GetBusinessObject(BoObjectTypes.oVendorPayments);

                pay.DocType = SAPbobsCOM.BoRcptTypes.rAccount;
                //pay.Series = 66;
                pay.DocCurrency = objOVPM.DocCurr;

                pay.DocDate = objOVPM.DocDate;
                pay.TaxDate = objOVPM.DocDate;
                pay.DueDate = objOVPM.DocDate;

                pay.TransferSum = objOVPM.DocTotal;
                pay.TransferDate = objOVPM.DocDate;
                pay.TransferReference = (objOVPM.Comments.Length > 21) ? objOVPM.Comments.Substring(0, 22) : objOVPM.Comments; // objOVPM.Comments.Substring(0, 22);
                pay.TransferAccount = (objOVPM.DocCurr == "SOL") ? "104101" : "104102"; //104102 PARA DOLARES , 104101 PARA SOLES

                pay.JournalRemarks = objOVPM.Comments;
                pay.Remarks = objOVPM.Comments;
                pay.CardName = objOVPM.CardName;

                if (objOVPM.Lineas.Count() > 0)
                {

                    foreach (VPM4 newObj in objOVPM.Lineas)
                    {
                        pay.AccountPayments.AccountCode = "471003";
                        pay.AccountPayments.Decription = newObj.LineMemo;
                        pay.AccountPayments.SumPaid = newObj.LineTotal;
                        pay.AccountPayments.UserFields.Fields.Item("U_GMI_PAGORELACION").Value = newObj.U_GMI_PAGORELACION;
                        pay.AccountPayments.Add();
                    }

                }

                iRet = pay.Add();

                if (iRet == 0)
                {
                    int docEntry = int.Parse(oCompany.GetNewObjectKey());

                    SAPbobsCOM.Payments oPayGet = (SAPbobsCOM.Payments)oCompany.GetBusinessObject(BoObjectTypes.oVendorPayments);

                    if (oPayGet.GetByKey(docEntry))
                    {
                        DocNumPP = oPayGet.DocNum.ToString();
                    }

                    return true;
                }
                else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);
                    throw new Exception(String.Concat(iErrCod.ToString(), ": ", sErrMsg));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool AddPaymentReceived_Devolucion(ref string DocNumPR, ORCT objORCT, string DocNumPP)
        {
            try
            {
                Payments pay = (SAPbobsCOM.Payments)oCompany.GetBusinessObject(BoObjectTypes.oIncomingPayments);

                pay.DocType = SAPbobsCOM.BoRcptTypes.rAccount;
                pay.DocCurrency = objORCT.DocCurr;

                pay.DocDate = objORCT.DocDate;
                pay.TaxDate = objORCT.DocDate;
                pay.DueDate = objORCT.DocDate;

                pay.TransferSum = objORCT.DocTotal;
                pay.TransferDate = objORCT.DocDate;
                pay.TransferReference = (objORCT.Comments.Length > 21) ? objORCT.Comments.Substring(0, 22) : objORCT.Comments;
                pay.TransferAccount = (objORCT.DocCurr == "SOL") ? "104101" : "104102"; //104102 PARA DOLARES , 104101 PARA SOLES

                pay.JournalRemarks = objORCT.Comments;
                pay.Remarks = objORCT.Comments;

                pay.UserFields.Fields.Item("U_BPP_TRAN").Value = "001";
                pay.UserFields.Fields.Item("U_VS_RUBRO").Value = "03";

                if (objORCT.Lineas.Count() > 0)
                {

                    foreach (RCT4 newObj in objORCT.Lineas)
                    {
                        pay.AccountPayments.AccountCode = "171201";
                        pay.AccountPayments.Decription = newObj.LineMemo;
                        pay.AccountPayments.SumPaid = newObj.LineTotal;
                        pay.AccountPayments.UserFields.Fields.Item("U_GMI_PAGORELACION").Value = newObj.U_GMI_PAGORELACION;
                        pay.AccountPayments.UserFields.Fields.Item("U_GMI_PAGORELACION_DEV").Value = DocNumPP;
                        pay.AccountPayments.Add();
                    }

                }

                iRet = pay.Add();

                if (iRet == 0)
                {
                    int docEntry = int.Parse(oCompany.GetNewObjectKey());

                    SAPbobsCOM.Payments oPayGet = (SAPbobsCOM.Payments)oCompany.GetBusinessObject(BoObjectTypes.oIncomingPayments);

                    if (oPayGet.GetByKey(docEntry))
                    {
                        DocNumPR = oPayGet.DocNum.ToString();
                    }

                    return true;
                }
                else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);
                    throw new Exception(String.Concat(iErrCod.ToString(), ": ", sErrMsg));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*******************************************************/



        /****************** RECONCILIACION **********************/
        public static bool MadeInternalReconciliation(ref int numRecon, System.Data.DataTable dataTable)
        {

            try
            {

                CompanyService companyService = oCompany.GetCompanyService();
                InternalReconciliationsService service = companyService.GetBusinessService(ServiceTypes.InternalReconciliationsService);

                InternalReconciliationOpenTrans openTrans =
               (InternalReconciliationOpenTrans)service.GetDataInterface(InternalReconciliationsServiceDataInterfaces.irsInternalReconciliationOpenTrans);

                // Reconciliación por CUENTA
                openTrans.CardOrAccount = CardOrAccountEnum.coaAccount;
                openTrans.ReconDate = (DateTime.Today);


                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    DataRow row = dataTable.Rows[i];
                    openTrans.InternalReconciliationOpenTransRows.Add();
                    openTrans.InternalReconciliationOpenTransRows.Item(i).Selected = BoYesNoEnum.tYES;
                    openTrans.InternalReconciliationOpenTransRows.Item(i).TransId = Convert.ToInt32(row["TransId"]); // 669515; // orctTransId;
                    openTrans.InternalReconciliationOpenTransRows.Item(i).TransRowId = Convert.ToInt32(row["Line_ID"]); // 0; // orctLineId;
                    openTrans.InternalReconciliationOpenTransRows.Item(i).ReconcileAmount = Convert.ToDouble(row["Monto"]); // 1200; // decimal.Parse(1200);
                }

                try
                {
                    InternalReconciliationParams reconParams = service.Add(openTrans);
                    numRecon = reconParams.ReconNum;
                    return true;
                }
                catch (Exception)
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);
                    throw new Exception(String.Concat(iErrCod.ToString(), ": ", sErrMsg));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*******************************************************/



        /******************* CANCELACION ***********************/

        public static bool CancelPayment(int DocEntryPP)
        {
            try
            {
                Payments pay = null;

                pay = (Payments)oCompany.GetBusinessObject(BoObjectTypes.oVendorPayments);
                if (!pay.GetByKey(DocEntryPP))
                    return false;


                int rc = pay.Cancel();
                if (rc == 0)
                {

                    return true;
                }
                else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);
                    throw new Exception(String.Concat(iErrCod.ToString(), ": ", sErrMsg));
                }
                        
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool CancelPaymentReceived(int DocEntryPR)
        {
            try
            {
                Payments pay = null;

                pay = (Payments)oCompany.GetBusinessObject(BoObjectTypes.oIncomingPayments);
                if (!pay.GetByKey(DocEntryPR))
                    return false;


                int rc = pay.Cancel();
                if (rc == 0)
                {

                    return true;
                }
                else
                {
                    oCompany.GetLastError(out iErrCod, out sErrMsg);
                    throw new Exception(String.Concat(iErrCod.ToString(), ": ", sErrMsg));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*******************************************************/


        public static bool CancelInternalRecon(int reconNum)
        {
            CompanyService companyService = oCompany.GetCompanyService();

            InternalReconciliationsService irService =
                (InternalReconciliationsService)companyService.GetBusinessService(ServiceTypes.InternalReconciliationsService);

            InternalReconciliationParams cancelParams =
                (InternalReconciliationParams)irService.GetDataInterface(
                    InternalReconciliationsServiceDataInterfaces.irsInternalReconciliationParams);

            cancelParams.ReconNum = reconNum;

            try
            {
                irService.Cancel(cancelParams);
                return true;
            }
            catch (Exception ex)
            {
                oCompany.GetLastError(out int errCode, out string errDesc);
                string sdkMsg = string.IsNullOrWhiteSpace(errDesc) ? ex.Message : $"[{errCode}] {errDesc}";
                throw new ApplicationException($"No se pudo cancelar la reconciliación {reconNum}. Detalle: {sdkMsg}", ex);
            }
        }

    }
}
