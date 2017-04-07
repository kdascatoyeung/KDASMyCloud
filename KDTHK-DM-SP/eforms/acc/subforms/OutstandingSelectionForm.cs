using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomUtil.utils.export;
using CustomUtil.utils.import;
using KDTHK_DM_SP.services;
using System.Data.SqlClient;
using KDTHK_DM_SP.utils;
using CustomUtil.utils.authentication;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace KDTHK_DM_SP.eforms.acc.subforms
{
    public partial class OutstandingSelectionForm : Form
    {
        public OutstandingSelectionForm()
        {
            InitializeComponent();

            //GlobalService.User = AdUtil.getUsername("kmhk.local");
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            OutstandingForm form = new OutstandingForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private DataTable VendorTable()
        {
            DataTable table = new DataTable();

            string[] headers = { "Code", "Name", "Payterm", "Currency", "Description" };

            foreach (string header in headers)
                table.Columns.Add(header);

            string query = "select v_code as Code, v_name as Name, v_payterm as Payterm, v_currency as Currency, v_description as Description from TB_ACC_MASTER_VENDOR";

            SqlDataAdapter sda = new SqlDataAdapter(query, DataServiceCM.GetInstance().Connection);
            sda.Fill(table);

            return table;
        }

        private DataTable AccountCodeTable()
        {
            DataTable table = new DataTable();

            string[] headers = { "AccountCode", "AccountName" };

            foreach (string header in headers)
                table.Columns.Add(header);

            string query = "select a_code as AccountCode, a_name as AccountName from TB_CM_MASTER_ACCOUNTCODE";

            SqlDataAdapter sda = new SqlDataAdapter(query, DataServiceCM.GetInstance().Connection);
            sda.Fill(table);

            return table;
        }

        private DataTable CostCentreTable()
        {
            DataTable table = new DataTable();

            string[] headers = { "CostCentre", "CostCentreName" };

            foreach (string header in headers)
                table.Columns.Add(header);

            string query = "select c_code as CostCentre, c_name as CostCentreName from TB_CM_MASTER_COSTCENTRE";

            SqlDataAdapter sda = new SqlDataAdapter(query, DataServiceCM.GetInstance().Connection);
            sda.Fill(table);

            return table;
        }
        
        private void btnTemplate_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            string[] headers = { "Vendor Code", "Invoice", "Account Code", "CostCentre", "Currency", "Amount", "Remarks 1", "Remarks 2", "Remarks 3", "Remarks 4", "Remarks 5" };

            foreach (string header in headers)
                table.Columns.Add(header);

            DataSet ds = new DataSet();

            ds.Tables.Add(VendorTable());
            ds.Tables.Add(AccountCodeTable());
            ds.Tables.Add(CostCentreTable());
            ds.Tables.Add(table);

            ExportExcelUtil.ExportMultiSheetsForOutStanding(ds);
        }

        private void UploadData2()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            DataTable tbUpload = new DataTable();

            string[] simHeaders = { "code", "name", "invoice", "total", "detail" };
            foreach (string header in simHeaders)
                tbUpload.Columns.Add(header);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = ofd.FileName.EndsWith(".xlsx") ? ImportExcel2007.TranslateToTable(ofd.FileName, "Template") : ImportExcel2003.TranslateToTable(ofd.FileName, "Template");
 
                bool isValid = true;

                int index = 1;

                List<OutstandingError> errorList = new List<OutstandingError>();

                List<Outstanding> list = new List<Outstanding>();

                foreach (DataRow row in table.Rows)
                {
                    string code = row.ItemArray[0].ToString().Trim();
                    if (code.Length == 9 && code.StartsWith("23")) code = "0" + code;
                    string invoice = row.ItemArray[1].ToString().Trim();
                    string acccode = row.ItemArray[2].ToString().Trim();
                    string costcentre = row.ItemArray[3].ToString().Trim();
                    string currency = row.ItemArray[4].ToString().Trim().ToUpper();
                    string amount = row.ItemArray[5].ToString().Trim();
                    string desc1 = row.ItemArray[6].ToString().Trim();
                    string desc2 = row.ItemArray[7].ToString().Trim();
                    string desc3 = row.ItemArray[8].ToString().Trim();
                    string desc4 = row.ItemArray[9].ToString().Trim();
                    string desc5 = row.ItemArray[10].ToString().Trim();

                    string vcurr = AccUtil.GetVendorCurrency(code);

                    double amt;
                    //double tmpAmt = Convert.ToDouble(amount.Replace("-", ""));
                    bool isNumeric = double.TryParse(amount, out amt);

                    if (AccUtil.IsInvoiceExists(invoice, code))
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Invoice: " + invoice + " has been used" });
                        isValid = false;
                    }

                    if (!AccUtil.IsVendorExists(code))
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Vendor code: " + code + " does not exist" });
                        isValid = false;
                    }

                    if (!AccUtil.IsAccountCodeExists(acccode))
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Account Code: " + acccode + " does not exist" });
                        isValid = false;
                    }

                    if (!AccUtil.IsCostCentreExists(costcentre))
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "CostCentre: " + costcentre + " does not exist" });
                        isValid = false;
                    }

                    if (currency != "HKD" && currency != "USD" && currency != "JPY" && currency != "EUR" && currency != "RMB")
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Invalid currency format" });
                        isValid = false;
                    }

                    if (currency != vcurr)
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Mismatched currency. The correct currency is " + vcurr });
                        isValid = false;
                    }

                    if (!isNumeric)
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Amount: " + amount + " is not valid" });
                        isValid = false;
                    }

                    amount = string.Format("{0:0.00}", Convert.ToDouble(amount));

                    var regex = new Regex(@"^\d+\.\d{2}?$");
                    if (!regex.IsMatch(amount) && !amount.StartsWith("-"))
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Amount: " + amount + " is not valid" });
                        isValid = false;
                    }

                    if (desc1.Length == 0)
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Remarks 1 must be input" });
                        isValid = false;
                    }

                    if (desc1.Length > 50 || desc2.Length > 50 || desc3.Length > 50 || desc4.Length > 50 || desc5.Length > 50)
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Each remarks field length cannot over 50 characters" });
                        isValid = false;
                    }

                    if (isValid)
                        list.Add(new Outstanding { VendorCode = code, Invoice = invoice, AccountCode = acccode, CostCentre = costcentre, Amount = amount, Desc1 = desc1, Desc2 = desc2, Desc3 = desc3, Desc4 = desc4, Desc5 = desc5 });

                    index++;
                }

                if (errorList.Count > 0)
                {
                    OutstandingErrorBox form = new OutstandingErrorBox(errorList);
                    form.ShowDialog();
                }
                else
                {
                    var groupedList = from x in list
                                      group x by new
                                      {
                                          x.Invoice,
                                          x.VendorCode,
                                      } into g
                                      select new
                                      {
                                          Invoice = g.Key.Invoice,
                                          VendorCode = g.Key.VendorCode,
                                          Value = g.Sum(y => Convert.ToDecimal(y.Amount))
                                      };

                    foreach (var item in groupedList)
                    {
                        string query = string.Format("select v_name from TB_ACC_MASTER_VENDOR where v_code = '{0}'", item.VendorCode);
                        string name = DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();

                        //Debug.WriteLine(item.Value.ToString());
                        tbUpload.Rows.Add(item.VendorCode, name, item.Invoice, item.Value.ToString(), "Detail");
                    }

                    OutstandingPreviewForm form = new OutstandingPreviewForm(tbUpload, list);
                    form.ShowDialog();
                }
            }
        }

        /*private void UploadData()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            DataTable tbUpload = new DataTable();

            string[] headers = { "code", "name", "invoice", "ac", "acname", "cc", "ccname", "currency", "amount", "remarks1", "remarks2", "remarks3", "remarks4", "remarks5" };
            foreach (string header in headers)
                tbUpload.Columns.Add(header);

            DataTable tbSimple = new DataTable();
            string[] simHeaders = { "code", "name", "invoice", "total" };
            foreach (string header in simHeaders)
                tbSimple.Columns.Add(header);

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = ofd.FileName.EndsWith(".xlsx") ? ImportExcel2007.TranslateToTable(ofd.FileName, "Template") : ImportExcel2003.TranslateToTable(ofd.FileName, "Template");

                bool isValid = true;

                int index = 1;

                List<OutstandingError> errorList = new List<OutstandingError>();

                List<Outstanding> list = new List<Outstanding>();

                foreach (DataRow row in table.Rows)
                {
                    string code = row.ItemArray[0].ToString().Trim();
                    if (code.Length == 9 && code.StartsWith("23")) code = "0" + code;
                    string invoice = row.ItemArray[1].ToString().Trim();
                    string acccode = row.ItemArray[2].ToString().Trim();
                    string costcentre = row.ItemArray[3].ToString().Trim();
                    string currency = row.ItemArray[4].ToString().Trim().ToUpper();
                    string amount = row.ItemArray[5].ToString().Trim();
                    string desc1 = row.ItemArray[6].ToString().Trim();
                    string desc2 = row.ItemArray[7].ToString().Trim();
                    string desc3 = row.ItemArray[8].ToString().Trim();
                    string desc4 = row.ItemArray[9].ToString().Trim();
                    string desc5 = row.ItemArray[10].ToString().Trim();

                    double amt;
                    bool isNumeric = double.TryParse(amount, out amt);

                    if (AccUtil.IsInvoiceExists(invoice, code))
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Invoice: " + invoice + " has been used" });
                        isValid = false;
                    }

                    if (!AccUtil.IsVendorExists(code))
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Vendor code: " + code + " does not exist" });
                        isValid = false;
                    }

                    if (!AccUtil.IsAccountCodeExists(acccode))
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Account Code: " + acccode + " does not exist" });
                        isValid = false;
                    }

                    if (!AccUtil.IsCostCentreExists(costcentre))
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "CostCentre: " + costcentre + " does not exist" });
                        isValid = false;
                    }

                    if (currency != "HKD" && currency != "USD" && currency != "JPY" && currency != "EUR" && currency != "RMB")
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Invalid currency format" });
                        isValid = false;
                    }

                    if (!isNumeric)
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Amount: " + amount + " is not valid" });
                        isValid = false;
                    }

                    if (desc1.Length == 0)
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Remarks 1 must be input" });
                        isValid = false;
                    }

                    if (desc1.Length > 50 || desc2.Length > 50 || desc3.Length > 50 || desc4.Length > 50 || desc5.Length > 50)
                    {
                        errorList.Add(new OutstandingError { index = index, Message = "Each remarks field length cannot over 50 characters" });
                        isValid = false;
                    }

                    if (isValid)
                        list.Add(new Outstanding { VendorCode = code, Invoice = invoice, AccountCode = acccode, CostCentre = costcentre, Amount = amount, Desc1 = desc1, Desc2 = desc2, Desc3 = desc3, Desc4 = desc4, Desc5 = desc5 });

                    index++;
                }

                if (errorList.Count > 0)
                {
                    OutstandingErrorBox form = new OutstandingErrorBox(errorList);
                    form.ShowDialog();
                }
                else
                {
                    var groupedList = from x in list
                                      group x by new
                                      {
                                          x.Invoice,
                                          x.VendorCode,
                                      } into g
                                      select new
                                      {
                                          Invoice = g.Key.Invoice,
                                          VendorCode = g.Key.VendorCode,
                                          Value = g.Sum(y => Convert.ToDecimal(y.Amount))
                                      };

                    string today = DateTime.Today.ToString("yyyy/MM/dd");

                    string cm1st = "Lee Suk Ha(李淑霞,Zoe)";
                    string cm2nd = "Ogata Shuka (尾形秋香)";

                    string div = KDTHK_DM_SP.utils.EformUtil.GetHead(GlobalService.User);

                    foreach (var item in groupedList)
                    {
                        string code = item.VendorCode;
                        string invoice = item.Invoice;
                        string sum = DoFormat(item.Value.ToString());

                        string invoiceText = string.Format("insert into TB_ACC_MASTER_INVOICE (i_invoice, i_vendor) values ('{0}', '{1}')", invoice, code);
                        DataServiceCM.GetInstance().ExecuteNonQuery(invoiceText);

                        string name = AccUtil.GetVendorName(code);
                        string currency = AccUtil.GetVendorCurrency(code);
                        string payterm = AccUtil.GetVendorPayTerm(code);

                        string paydate = AccUtil.PayDate(Convert.ToDateTime(today), payterm);

                        string query = string.Format("insert into TB_ACC_OUTSTANDING (o_invoice, o_vendor, o_vendorname, o_inputdate, o_paymentdate, o_currency, o_amount, o_createdby" +
                            ", o_created, o_div, o_staff, o_acc) values ('{0}', '{1}', N'{2}', '{3}', '{4}', '{5}', '{6}', N'{7}', '{8}', N'{9}', N'{10}', N'{11}')", invoice, code, name, today, paydate, currency, sum,
                            GlobalService.User, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), div, cm1st, cm2nd);
                        DataServiceCM.GetInstance().ExecuteNonQuery(query);
                    }

                    foreach (Outstanding item in list)
                    {
                        int id = AccUtil.GetOutstandingIdByInvoice(item.Invoice);
                        string accname = AccUtil.GetAccountName(item.AccountCode);
                        string costcentrename = AccUtil.GetCostCentreName(item.CostCentre);

                        string desc = (item.Desc1 + item.Desc2 + item.Desc3 + item.Desc4 + item.Desc5);
                        desc = desc.Substring(0, Math.Min(desc.Length, 50));

                        string query = string.Format("insert into TB_ACC_OUTSTANDING_DETAIL (od_o_id, od_accountcode, od_accountname, od_costcentre, od_costcentrename, od_amount" +
                            ", od_desc1, od_desc2, od_desc3, od_desc4, od_desc5, od_display) values ('{0}', '{1}', N'{2}', '{3}', N'{4}', '{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}')", id, item.AccountCode,
                            accname, item.CostCentre, costcentrename, DoFormat(item.Amount), item.Desc1, item.Desc2, item.Desc3, item.Desc4, item.Desc5, desc);
                        DataServiceCM.GetInstance().ExecuteNonQuery(query);
                    }

                    if (list.Count > 0)
                        KDTHK_DM_SP.utils.EformUtil.SendApprovalEmail("", GlobalService.User, AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local"), AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local"), "", "Outstanding Slip");

                    DialogResult = DialogResult.OK;
                }

                
            }
        }*/

        private void btnUpload_Click(object sender, EventArgs e)
        {
            UploadData2();

            /*OpenFileDialog ofd = new OpenFileDialog();

            bool isValid = true;

            string msg = "";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = ofd.FileName.EndsWith(".xlsx") ? ImportExcel2007.TranslateToTable(ofd.FileName, 0) : ImportExcel2003.TranslateToTable(ofd.FileName, 0);

                List<Outstanding> list = new List<Outstanding>();

                List<string> tmpInvoiceList = new List<string>();

                foreach (DataRow row in table.Rows)
                {
                    isValid = true;

                    string code = row.ItemArray[0].ToString().Trim();
                    if (code.Length == 9 && code.StartsWith("23")) code = "0" + code;
                    string invoice = row.ItemArray[1].ToString().Trim();
                    string acccode = row.ItemArray[2].ToString().Trim();
                    string costcentre = row.ItemArray[3].ToString().Trim();
                    string currency = row.ItemArray[4].ToString().Trim().ToUpper();
                    string amount = row.ItemArray[5].ToString().Trim();
                    double amt;
                    bool isNumeric = double.TryParse(amount, out amt);
                    string desc1 = row.ItemArray[6].ToString().Trim();
                    string desc2 = row.ItemArray[7].ToString().Trim();
                    string desc3 = row.ItemArray[8].ToString().Trim();
                    string desc4 = row.ItemArray[9].ToString().Trim();
                    string desc5 = row.ItemArray[10].ToString().Trim();

                    if (!AccUtil.IsVendorExists(code))
                    {
                        msg = "Vendor code: " + code + " does not exist;\n";
                        isValid = false;
                    }

                    if (AccUtil.IsInvoiceExists(invoice))
                    {
                        if (!tmpInvoiceList.Contains(invoice))
                        {
                            tmpInvoiceList.Add(invoice);
                            msg = msg + "Invoice: " + invoice + " has been used;\n";
                        }
                        isValid = false;
                    }

                    if (!AccUtil.IsAccountCodeExists(acccode))
                    {
                        msg = msg + "Account Code: " + acccode + " does not exist;\n";
                        isValid = false;
                    }

                    if (!AccUtil.IsCostCentreExists(costcentre))
                    {
                        msg = msg + "CostCentre: " + costcentre + " does not exist;\n";
                        isValid = false;
                    }

                    if (currency != "HKD" && currency != "USD" && currency != "JPY" && currency != "EUR" && currency != "RMB")
                    {

                    }

                    if (!isNumeric)
                    {
                        msg = msg + "Amount: " + amount + " is not valid;\n";
                        isValid = false;
                    }

                    if (desc1.Length > 50 || desc2.Length > 50 || desc3.Length > 50 || desc4.Length > 50 || desc5.Length > 50)
                    {
                        msg = msg + "Each remarks field length cannot over 50 characters.";
                        isValid = false;
                    }

                    list.Add(new Outstanding { VendorCode = code, Invoice = invoice, AccountCode = acccode, CostCentre = costcentre, Amount = amount, Desc1 = desc1, Desc2 = desc2, Desc3 = desc3, Desc4 = desc4, Desc5 = desc5 });
                }

                if (!isValid)
                {
                    MessageBox.Show(msg, "Error found", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    var groupedList = from x in list
                                      group x by new
                                      {
                                          x.Invoice,
                                          x.VendorCode,
                                      } into g
                                      select new
                                      {
                                          Invoice = g.Key.Invoice,
                                          VendorCode = g.Key.VendorCode,
                                          Value = g.Sum(y => Convert.ToDecimal(y.Amount))
                                      };

                    string today = DateTime.Today.ToString("yyyy/MM/dd");

                    string cm1st = "Ng Wai Kwan(吳蕙君,Wendy)";
                    string cm2nd = "Ogata Shuka (尾形秋香)";

                    string div = KDTHK_DM_SP.utils.EformUtil.GetHead(GlobalService.User);

                    foreach (var item in groupedList)
                    {
                        string code = item.VendorCode;
                        string invoice = item.Invoice;
                        string sum = DoFormat(item.Value.ToString());

                        string invoiceText = string.Format("insert into TB_ACC_MASTER_INVOICE (i_invoice) values ('{0}')", invoice);
                        DataServiceCM.GetInstance().ExecuteNonQuery(invoiceText);

                        string name = AccUtil.GetVendorName(code);
                        string currency = AccUtil.GetVendorCurrency(code);
                        string payterm = AccUtil.GetVendorPayTerm(code);

                        string paydate = AccUtil.PayDate(Convert.ToDateTime(today), payterm);

                        string query = string.Format("insert into TB_ACC_OUTSTANDING (o_invoice, o_vendor, o_vendorname, o_inputdate, o_paymentdate, o_currency, o_amount, o_createdby" +
                            ", o_created, o_div, o_staff, o_acc) values ('{0}', '{1}', N'{2}', '{3}', '{4}', '{5}', '{6}', N'{7}', '{8}', N'{9}', N'{10}', N'{11}')", invoice, code, name, today, paydate, currency, sum,
                            GlobalService.User, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), div, cm1st, cm2nd);
                        DataServiceCM.GetInstance().ExecuteNonQuery(query);
                    }

                    foreach (Outstanding item in list)
                    {
                        int id = AccUtil.GetOutstandingIdByInvoice(item.Invoice);
                        string accname = AccUtil.GetAccountName(item.AccountCode);
                        string costcentrename = AccUtil.GetCostCentreName(item.CostCentre);
                        
                        string desc = (item.Desc1 + item.Desc2 + item.Desc3 + item.Desc4 + item.Desc5);
                        desc = desc.Substring(0, Math.Min(desc.Length, 50));

                        string query = string.Format("insert into TB_ACC_OUTSTANDING_DETAIL (od_o_id, od_accountcode, od_accountname, od_costcentre, od_costcentrename, od_amount" +
                            ", od_desc1, od_desc2, od_desc3, od_desc4, od_desc5, od_display) values ('{0}', '{1}', N'{2}', '{3}', N'{4}', '{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}')", id, item.AccountCode,
                            accname, item.CostCentre, costcentrename, DoFormat(item.Amount), item.Desc1, item.Desc2, item.Desc3, item.Desc4, item.Desc5, desc);
                        DataServiceCM.GetInstance().ExecuteNonQuery(query);
                    }

                    KDTHK_DM_SP.utils.EformUtil.SendApprovalEmail("", GlobalService.User, AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local"), AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local"), "", "Outstanding Slip");

                    MessageBox.Show("Record has been uploaded");
                }
            }*/
        }

        private string DoFormat(string text)
        {
            var s = string.Format("{0:0.00}", Convert.ToDouble(text));

            s = StringUtil.Calculation(s, 50);

            return s;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = @"c:\temp\ostest.pdf";

            List<OutstandingDetailData> list = new List<OutstandingDetailData>();
            list.Add(new OutstandingDetailData { AccountCode = "ac1", CostCentre = "cc1", Amount = "1000", Remarks1 = "Rm1", Remarks2 = "Rm2", Remarks3 = "Rm3", Remarks4 = "Rm4", Remarks5 = "Rm5" });
            list.Add(new OutstandingDetailData { AccountCode = "ac2", CostCentre = "cc2", Amount = "2000", Remarks1 = "Rm1", Remarks2 = "Rm2", Remarks3 = "Rm3", Remarks4 = "Rm4", Remarks5 = "Rm5" });

            PdfUtil.ExportOutstandingForm(filename, "vendor", "vendorname", "invoice", "inputdate", "paydate", "currency", "total", "applicant", "2016/12/16 13:02:20", "sect", "sectapptime",
                "div", "divapptime", "dept", "deptapptime", list);

            Process.Start(filename);
        }
    }

    public class Outstanding
    {
        public string VendorCode { get; set; }
        public string Invoice { get; set; }
        public string AccountCode { get; set; }
        public string CostCentre { get; set; }
        public string Amount { get; set; }
        public string Desc1 { get; set; }
        public string Desc2 { get; set; }
        public string Desc3 { get; set; }
        public string Desc4 { get; set; }
        public string Desc5 { get; set; }
    }

    public class OutstandingError
    {
        public int index { get; set; }
        public string Message { get; set; }
    }
}
