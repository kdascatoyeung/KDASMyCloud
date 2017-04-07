using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomUtil.utils.import;
using KDTHK_DM_SP.services;
using KDTHK_DM_SP.eforms.acc.subforms;
using System.Diagnostics;
using CustomUtil.utils.export;
using CustomUtil.utils.authentication;
using KDTHK_DM_SP.utils;

namespace KDTHK_DM_SP.eforms.acc
{
    public partial class OutstandingForm : Form
    {
        public OutstandingForm()
        {
            InitializeComponent();

            cbCurr.SelectedIndex = 0;

            //GlobalService.User = AdUtil.getUsername("kmhk.local");

            txtInvoice.LostFocus += new EventHandler(txtInvoice_LostFocus);

            txtVendorCode.LostFocus += new EventHandler(txtInvoice_LostFocus);

            string costCentre = MasterUtil.CostCentre();

            DataGridViewComboBoxColumn colAccountCode = (DataGridViewComboBoxColumn)dgvOutstanding.Columns[0];
            colAccountCode.DataSource = AccountCodeColumn(costCentre);

            DataGridViewComboBoxColumn colCostCentre = (DataGridViewComboBoxColumn)dgvOutstanding.Columns[2];
            colCostCentre.DataSource = CostCentreColumn();
        }

        private List<string> AccountCodeColumn(string costcentre)
        {
            List<string> list = new List<string>();
            
            string query = "select a_code, a_name from TB_CM_MASTER_ACCOUNTCODE order by a_code asc";

            list.Add("");

            bool isAc5 = costcentre != "" ? MasterUtil.IsAc5(costcentre) : true;
            bool isAc6 = costcentre != "" ? MasterUtil.IsAc6(costcentre) : true;

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string code = reader.GetString(0).Trim();
                    string name = reader.GetString(1).Trim();

                    if (code.StartsWith("5") && isAc5)
                    {
                        list.Add(code + " (" + name + ")");
                        list.Add("1003070001 (PREPAID EXPENSES THIRD PARTY)");
                        list.Add("1003090001 (SUSPENSE PAYMENT - STAFF)");
                        list.Add("1104010001 (GUARANTEE MONEY)");
                        list.Add("2001190001 (ACCRUED EXPENSES - THIRD PARTY)");
                        list.Add("6005010002 (TEMPORARY ACCOUNT FOR KDTCN)");
                        list.Add("6005010003 (TEMPORARY ACCOUNT FOR KDC)");
                        list.Add("6005010004 (TEMPORARY ACCOUNT FOR VENDOR)");
                        list.Add("6005010005 (TEMPORARY ACCOUNT FOR KDAS)");
                        list.Add("6005010006 (TEMPORARY ACCOUNT FOR KDTVN)");
                    }

                    else if (code.StartsWith("6") && isAc6)
                        list.Add(code + " (" + name + ")");

                    /*else
                    {
                        list.Add(code + " (" + name + ")");
                        list.Add("1003070001 (PREPAID EXPENSES THIRD PARTY)");
                        list.Add("1003090001 (SUSPENSE PAYMENT - STAFF)");
                        list.Add("1104010001 (GUARANTEE MONEY)");
                        list.Add("2001190001 (ACCRUED EXPENSES - THIRD PARTY)");
                        list.Add("6005010002 (TEMPORARY ACCOUNT FOR KDTCN)");
                        list.Add("6005010003 (TEMPORARY ACCOUNT FOR KDC)");
                        list.Add("6005010004 (TEMPORARY ACCOUNT FOR VENDOR)");
                        list.Add("6005010005 (TEMPORARY ACCOUNT FOR KDAS)");
                        list.Add("6005010006 (TEMPORARY ACCOUNT FOR KDTVN)");
                    }*/

                }
            }

            list = list.Distinct().ToList();
            list.Sort();

            foreach (string item in list)
                Debug.WriteLine(item);

            return list;
        }

        private List<string> CostCentreColumn()
        {
            List<string> list = new List<string>();

            string query = "select c_code, c_name from TB_CM_MASTER_COSTCENTRE order by c_code";

            list.Add("");

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string code = reader.GetString(0).Trim();
                    string name = reader.GetString(1).Trim();
                    list.Add(code + " (" + name + ")");
                }
            }

            list = list.Distinct().ToList();

            

            return list;
        }

        private void txtInvoice_LostFocus(object sender, EventArgs e)
        {
            pbTick.Visible = false;

            if (txtInvoice.Text == "" || txtVendorCode.Text == "")
                return;

            if(AccUtil.IsInvoiceExists(txtInvoice.Text.Trim(), txtVendorCode.Text.Trim()))
            {
                txtInvoice.BackColor = Color.Yellow;
                dgvOutstanding.Visible = false;
                MessageBox.Show("Invoice : " + txtInvoice.Text.Trim() + " has been used.");
                btnSave.Enabled = false;
            }
            else
            {
                txtInvoice.BackColor = Color.White;
                pbTick.Visible = true;
                dgvOutstanding.Visible = true;
                btnSave.Enabled = true;
            }
        }

        private void GetTotalAmount()
        {
            double result = 0;

            foreach (DataGridViewRow row in dgvOutstanding.Rows)
            {
                try
                {
                    string amount = row.Cells[4].Value.ToString();
                    Debug.WriteLine("Amount: " + amount);

                    result = result + Convert.ToDouble(amount);
                }
                catch
                {
                    continue;
                }
            }

            string minus = result.ToString().StartsWith("-") ? "-" : "";
            txtAmount.Text = minus + DoFormat(result.ToString());
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = ImportExcel2007.TranslateToTable(ofd.FileName);

                List<Outstanding> list = new List<Outstanding>();

                bool isValid = true;

                foreach (DataRow row in table.Rows)
                {
                    string accountcode = row.ItemArray[0].ToString().Trim();
                    string costcentre = row.ItemArray[1].ToString().Trim();
                    string amount = row.ItemArray[2].ToString().Trim();
                    string desc1 = row.ItemArray[3].ToString().Trim();
                    string desc2 = row.ItemArray[4].ToString().Trim();
                    string desc3 = row.ItemArray[5].ToString().Trim();
                    string desc4 = row.ItemArray[6].ToString().Trim();
                    string desc5 = row.ItemArray[7].ToString().Trim();

                    if (!AccUtil.IsAccountCodeExists(accountcode))
                        isValid = false;

                    if (!AccUtil.IsCostCentreExists(costcentre))
                        isValid = false;

                    if (!IsAmountValid(amount))
                        isValid = false;

                    if (desc1.Length > 50 || desc2.Length > 50 || desc3.Length > 50 || desc4.Length > 50 || desc5.Length > 50)
                        isValid = false;

                    //list.Add(new Outstanding { AccountCode = accountcode, AccountName = "", CostCentre = costcentre, CostCentreName = "", Amount = amount, Desc1 = desc1, Desc2 = desc2, Desc3 = desc3, Desc4 = desc4, Desc5 = desc5 });
                }

                if (isValid)
                {
                    foreach (Outstanding item in list)
                        dgvOutstanding.Rows.Add(item.AccountCode, AccUtil.GetAccountName(item.AccountCode), item.CostCentre, AccUtil.GetCostCentreName(item.CostCentre), item.Amount, item.Desc1, item.Desc2, item.Desc3, item.Desc4, item.Desc5);

                    GetTotalAmount();
                }
                else
                {
                    MessageBox.Show("Invalid AccountCode / CostCentre / Amount input. Please revise data.");
                }
            }
        }

        private int currentRow;
        private bool resetRow = false;

        private void dgvOutstanding_SelectionChanged(object sender, EventArgs e)
        {
            if (resetRow)
            {
                resetRow = false;
                dgvOutstanding.CurrentCell = dgvOutstanding.Rows[currentRow].Cells[4];
            }
        }

        private void dgvOutstanding_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dgvOutstanding.SelectionChanged += new EventHandler(dgvOutstanding_SelectionChanged);
        }

        private void dgvOutstanding_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == 4)
            {
                try
                {
                    if (IsAmountValid(dgvOutstanding.CurrentRow.Cells[4].Value.ToString().Trim()))
                    {
                        string minus = dgvOutstanding.CurrentRow.Cells[4].Value.ToString().StartsWith("-") ? "-" : "";

                        dgvOutstanding.CurrentRow.Cells[4].Value = minus + DoFormat(dgvOutstanding.CurrentRow.Cells[4].Value.ToString().Trim());
                        GetTotalAmount();

                        this.Refresh();
                    }
                    else
                    {
                        MessageBox.Show("Wrong amount format. The format should be 2 decimal places.");
                        resetRow = true;
                        currentRow = e.RowIndex;
                    }
                }
                catch  { }
            }
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private bool IsAmountValid(string text)
        {
            var input = text;

            double value;

            if (!double.TryParse(input, out value) || Math.Round(value, 2) != value)
                return false;

            return true;
        }

        private string AmountCalculation(string strValor, int num)
        {
            string strAux = null;
            string strComas = null;
            string strPuntos = null;
            int intX = 0;
            bool bolMenos = false;

            strComas = "";
            if (strValor.Length == 0) return "";
            strValor = strValor.Replace(Application.CurrentCulture.NumberFormat.NumberGroupSeparator, "");
            if (strValor.Contains(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator))
            {
                strAux = strValor.Substring(0, strValor.LastIndexOf(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                strComas = strValor.Substring(strValor.LastIndexOf(Application.CurrentCulture.NumberFormat.NumberDecimalSeparator) + 1);
            }
            else
            {
                strAux = strValor;
            }

            if (strAux.Substring(0, 1) == Application.CurrentCulture.NumberFormat.NegativeSign)
            {
                bolMenos = true;
                strAux = strAux.Substring(1);
            }

            strPuntos = strAux;
            strAux = "";
            while (strPuntos.Length > 3)
            {
                strAux = Application.CurrentCulture.NumberFormat.NumberGroupSeparator + strPuntos.Substring(strPuntos.Length - 3, 3) + strAux;
                strPuntos = strPuntos.Substring(0, strPuntos.Length - 3);
            }
            if (num > 0)
            {
                if (strValor.Contains(Application.CurrentCulture.NumberFormat.PercentDecimalSeparator))
                {
                    strComas = Application.CurrentCulture.NumberFormat.PercentDecimalSeparator + strValor.Substring(strValor.LastIndexOf(Application.CurrentCulture.NumberFormat.PercentDecimalSeparator) + 1);
                    if (strComas.Length > num)
                    {
                        strComas = strComas.Substring(0, num + 1);
                    }
                }
            }
            strAux = strPuntos + strAux + strComas;
            return strAux;
        }

        private void txtInvoice_KeyUp(object sender, KeyEventArgs e)
        {
            //txtInvoice.Text = AmountCalculation(txtInvoice.Text, 50);
            //txtInvoice.Select(txtInvoice.TextLength, 0);
        }

        private void txtVendorCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VendorSearchForm form = new VendorSearchForm(txtVendorCode.Text.Trim(), "code");
                if (form.ShowDialog() == DialogResult.OK)
                {
                    txtVendorCode.Text = AccData.VendorCode;
                    txtVendorName.Text = AccData.VendorName;

                    DateTime inputdate = dtpInput.Value;
                    DateTime paydate = AccData.PayTerm == "HK01" ? new DateTime(inputdate.Year, inputdate.Month, 1).AddMonths(2).AddDays(-1)
                        : AccData.PayTerm == "HK02" ? new DateTime(inputdate.Year, inputdate.Month, 1).AddMonths(3).AddDays(-1)
                        : AccData.PayTerm == "HK05" ? inputdate.AddDays(300)
                        : AccData.PayTerm == "HK08" ? inputdate.AddDays(7)
                        : inputdate.AddDays(30);

                    if (AccData.PayTerm == "HK08" || AccData.PayTerm == "HK09")
                    {
                        switch (paydate.DayOfWeek)
                        {
                            case DayOfWeek.Saturday: paydate = paydate.AddDays(6); break;
                            case DayOfWeek.Sunday: paydate = paydate.AddDays(5); break;
                            case DayOfWeek.Monday: paydate = paydate.AddDays(4); break;
                            case DayOfWeek.Tuesday: paydate = paydate.AddDays(3); break;
                            case DayOfWeek.Wednesday: paydate = paydate.AddDays(2); break;
                            case DayOfWeek.Thursday: paydate = paydate.AddDays(1); break;
                        }
                    }

                    cbCurr.Text = AccData.Currency;

                    dtpPaymentDate.Value = paydate;
                }
            }
        }

        private void btnSearch1_Click(object sender, EventArgs e)
        {
            VendorSearchForm form = new VendorSearchForm(txtVendorCode.Text.Trim(), "code");
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtVendorCode.Text = AccData.VendorCode;
                txtVendorName.Text = AccData.VendorName;

                DateTime inputdate = dtpInput.Value;

                DateTime paydate = AccData.PayTerm == "HK01" ? new DateTime(inputdate.Year, inputdate.Month, 1).AddMonths(2).AddDays(-1)
                    : AccData.PayTerm == "HK02" ? new DateTime(inputdate.Year, inputdate.Month, 1).AddMonths(3).AddDays(-1)
                    : AccData.PayTerm == "HK05" ? inputdate.AddDays(300)
                    : AccData.PayTerm == "HK08" ? inputdate.AddDays(7)
                    : inputdate.AddDays(30);

                if (AccData.PayTerm == "HK08" || AccData.PayTerm == "HK09")
                {
                    switch (paydate.DayOfWeek)
                    {
                        case DayOfWeek.Saturday: paydate = paydate.AddDays(6); break;
                        case DayOfWeek.Sunday: paydate = paydate.AddDays(5); break;
                        case DayOfWeek.Monday: paydate = paydate.AddDays(4); break;
                        case DayOfWeek.Tuesday: paydate = paydate.AddDays(3); break;
                        case DayOfWeek.Wednesday: paydate = paydate.AddDays(2); break;
                        case DayOfWeek.Thursday: paydate = paydate.AddDays(1); break;
                    }
                }

                cbCurr.Text = AccData.Currency;

                dtpPaymentDate.Value = paydate;
            }
        }

        private void txtVendorName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                VendorSearchForm form = new VendorSearchForm(txtVendorName.Text.Trim(), "name");
                if (form.ShowDialog() == DialogResult.OK)
                {
                    txtVendorCode.Text = AccData.VendorCode;
                    txtVendorName.Text = AccData.VendorName;

                    DateTime inputdate = dtpInput.Value;

                    DateTime paydate = AccData.PayTerm == "HK01" ? new DateTime(inputdate.Year, inputdate.Month, 1).AddMonths(2).AddDays(-1)
                        : AccData.PayTerm == "HK02" ? new DateTime(inputdate.Year, inputdate.Month, 1).AddMonths(3).AddDays(-1)
                        : AccData.PayTerm == "HK05" ? inputdate.AddDays(300)
                        : AccData.PayTerm == "HK08" ? inputdate.AddDays(7)
                        : inputdate.AddDays(30);

                    if (AccData.PayTerm == "HK08" || AccData.PayTerm == "HK09")
                    {
                        switch (paydate.DayOfWeek)
                        {
                            case DayOfWeek.Saturday: paydate = paydate.AddDays(6); break;
                            case DayOfWeek.Sunday: paydate = paydate.AddDays(5); break;
                            case DayOfWeek.Monday: paydate = paydate.AddDays(4); break;
                            case DayOfWeek.Tuesday: paydate = paydate.AddDays(3); break;
                            case DayOfWeek.Wednesday: paydate = paydate.AddDays(2); break;
                            case DayOfWeek.Thursday: paydate = paydate.AddDays(1); break;
                        }
                    }

                    cbCurr.Text = AccData.Currency;

                    dtpPaymentDate.Value = paydate;
                }
            }
        }

        private void btnSearch2_Click(object sender, EventArgs e)
        {
            VendorSearchForm form = new VendorSearchForm(txtVendorName.Text.Trim(), "name");
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtVendorCode.Text = AccData.VendorCode;
                txtVendorName.Text = AccData.VendorName;

                DateTime inputdate = dtpInput.Value;

                DateTime paydate = AccData.PayTerm == "HK01" ? new DateTime(inputdate.Year, inputdate.Month, 1).AddMonths(2).AddDays(-1)
                    : AccData.PayTerm == "HK02" ? new DateTime(inputdate.Year, inputdate.Month, 1).AddMonths(3).AddDays(-1)
                    : AccData.PayTerm == "HK05" ? inputdate.AddDays(300)
                    : AccData.PayTerm == "HK08" ? inputdate.AddDays(7)
                    : inputdate.AddDays(30);

                if (AccData.PayTerm == "HK08" || AccData.PayTerm == "HK09")
                {
                    switch (paydate.DayOfWeek)
                    {
                        case DayOfWeek.Saturday: paydate = paydate.AddDays(6); break;
                        case DayOfWeek.Sunday: paydate = paydate.AddDays(5); break;
                        case DayOfWeek.Monday: paydate = paydate.AddDays(4); break;
                        case DayOfWeek.Tuesday: paydate = paydate.AddDays(3); break;
                        case DayOfWeek.Wednesday: paydate = paydate.AddDays(2); break;
                        case DayOfWeek.Thursday: paydate = paydate.AddDays(1); break;
                    }
                }

                cbCurr.Text = AccData.Currency;

                dtpPaymentDate.Value = paydate;
            }
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            string[] headers = { "AccountCode", "CostCentre", "Amount", "Description 1", "Description 2", "Description 3", "Description 4", "Description 5" };
            foreach (string header in headers)
                table.Columns.Add(header);

            ExportExcelUtil.SaveAsExcel(table, "outstanding");
        }

        private void SaveData()
        {
            dgvOutstanding.EndEdit();

            string vendor = txtVendorCode.Text.Trim();
            string vendorname = txtVendorName.Text.Trim();
            string invoice = txtInvoice.Text.Trim();
            string currency = cbCurr.Text;
            string indate = dtpInput.Value.ToString("yyyy/MM/dd");
            string paydate = dtpPaymentDate.Value.ToString("yyyy/MM/dd");
            string total = txtAmount.Text.Trim();

            if (!AccUtil.IsVendorExists(vendor))
            {
                MessageBox.Show("Vendor: " + vendor + " does not exist. Please check your data.");
                return;
            }

            if (AccUtil.IsInvoiceExists(invoice, vendor))
            {
                MessageBox.Show("Invoice: " + invoice + " has been used.");
                return;
            }

            string signal = dtpInput.Value.Month == DateTime.Today.Month ? "True" : "False";

            string sectHead = UserUtil.GetSectionHead(UserUtil.GetSect(GlobalService.User));
            string divHead = UserUtil.GetDivisionHead(UserUtil.GetDivision(GlobalService.User));

            string dept = UserUtil.GetDept(GlobalService.User);

            string deptHead = dept.Contains("RPS") ? UserUtil.GetDepartmentHead(dept) : "";

            string cm1st = "Lee Suk Ha(李淑霞,Zoe)";
            string cm2nd = "Li Yuen Yan(李婉茵,Sharon)";

            bool isValid = true;

            List<Outstanding> list = new List<Outstanding>();

            foreach (DataGridViewRow row in dgvOutstanding.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells[0].Value == null && row.Cells[2].Value == null && row.Cells[4].Value == null && row.Cells[5].Value == null && row.Cells[6].Value == null && row.Cells[7].Value == null && row.Cells[8].Value == null && row.Cells[9].Value == null) continue;

                if (row.Cells[0].Value == null || row.Cells[2].Value == null || row.Cells[4].Value == null || row.Cells[5].Value == null) isValid = false;

                string desc1 = "", desc2 = "", desc3 = "", desc4 = "", desc5 = "";

                try
                {
                    desc1 = row.Cells[5].Value.ToString().Trim();
                    desc2 = row.Cells[6].Value == null ? "" : row.Cells[6].Value.ToString().Trim();
                    desc3 = row.Cells[7].Value == null ? "" : row.Cells[7].Value.ToString().Trim();
                    desc4 = row.Cells[8].Value == null ? "" : row.Cells[8].Value.ToString().Trim();
                    desc5 = row.Cells[9].Value == null ? "" : row.Cells[9].Value.ToString().Trim();
                }
                catch
                {
                    isValid = false;
                }

                string acc = row.Cells[0].Value.ToString().Trim();
                string accountcode = acc.Substring(0, 10);
                string accname = acc.Substring(12);
                accname = accname.Substring(0, accname.Length - 1);

                string cc = row.Cells[2].Value.ToString().Trim();
                string costcentre = cc.Substring(0, 10);
                string costcentrename = cc.Substring(12);
                costcentrename = costcentrename.Substring(0, costcentrename.Length - 1);

                string inputAmount = row.Cells[4].Value.ToString().Trim();

                list.Add(new Outstanding { VendorCode = vendor, Invoice = invoice, AccountCode = accountcode, CostCentre = costcentre, Amount = inputAmount, Desc1 = desc1, Desc2 = desc2, Desc3 = desc3, Desc4 = desc4, Desc5 = desc5 });
            }

            if (!isValid)
            {
                MessageBox.Show("Please check the following:\n1. Select AccountCode & CostCentre.\n2. Input Amount.\n3. Remarks 1 must be input.", "Error found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string invoiceText = string.Format("insert into TB_ACC_MASTER_INVOICE (i_invoice, i_vendor) values ('{0}', '{1}')", invoice, vendor);
                DataServiceCM.GetInstance().ExecuteNonQuery(invoiceText);

                string name = AccUtil.GetVendorName(vendor);
                string curr = AccUtil.GetVendorCurrency(vendor);
                string payterm = AccUtil.GetVendorPayTerm(vendor);

                string query = string.Format("insert into TB_ACC_OUTSTANDING (o_invoice, o_vendor, o_vendorname, o_inputdate, o_paymentdate, o_currency, o_amount, o_createdby" +
                    ", o_created, o_div, o_staff, o_acc, o_sect, o_dept) values ('{0}', '{1}', N'{2}', '{3}', '{4}', '{5}', '{6}', N'{7}', '{8}', N'{9}', N'{10}', N'{11}', N'{12}', N'{13}')", invoice, vendor, name, indate, paydate, currency, total,
                    GlobalService.User, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), divHead, cm1st, cm2nd, sectHead, deptHead);
                DataServiceCM.GetInstance().ExecuteNonQuery(query);

                foreach (Outstanding item in list)
                {
                    int id = AccUtil.GetOutstandingIdByInvoice(item.Invoice);

                    string accname = AccUtil.GetAccountName(item.AccountCode);
                    string costcentrename = AccUtil.GetCostCentreName(item.CostCentre);

                    string desc = (item.Desc1 + item.Desc2 + item.Desc3 + item.Desc4 + item.Desc5);
                    desc = desc.Substring(0, Math.Min(desc.Length, 50));

                    string text = string.Format("insert into TB_ACC_OUTSTANDING_DETAIL (od_o_id, od_accountcode, od_accountname, od_costcentre, od_costcentrename, od_amount" +
                            ", od_desc1, od_desc2, od_desc3, od_desc4, od_desc5, od_display) values ('{0}', '{1}', N'{2}', '{3}', N'{4}', '{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}')", id, item.AccountCode,
                            accname, item.CostCentre, costcentrename, DoFormat(item.Amount), item.Desc1, item.Desc2, item.Desc3, item.Desc4, item.Desc5, desc);
                    DataServiceCM.GetInstance().ExecuteNonQuery(text);
                }

                string content = "Application Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
                string body = "<p><span style=\"font-family: Calibri;\">" + content + "</span></p>";

                KDTHK_DM_SP.utils.EformUtil.SendApprovalEmail(invoice, GlobalService.User, AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local"), AdUtil.GetEmailByUsername(sectHead, "kmhk.local"), body, "Outstanding Slip");

                MessageBox.Show("Record has been saved.");

                DialogResult = DialogResult.OK;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int count = 0;

            foreach (DataGridViewRow row in dgvOutstanding.Rows)
            {
                if (row.IsNewRow) continue;

                count += 1;
            }

            if (count == 0)
            {
                MessageBox.Show("No record detected.");
                return;
            }

            SaveData();
        }

        private string DoFormat(string text)
        {
            var s = string.Format("{0:0.00}", Convert.ToDouble(text));

            s = StringUtil.Calculation(s, 50);

            return s;
        }

        private void dgvOutstanding_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void txtVendorCode_TextChanged(object sender, EventArgs e)
        {
            if (txtVendorCode.Text.Trim().Length == 10)
            {
                try
                {
                    txtVendorCode.BackColor = Color.White;
                    btnSearch1.BackColor = Color.White;
                    txtVendorName.Text = AccUtil.GetVendorName(txtVendorCode.Text.Trim());
                    cbCurr.Text = AccUtil.GetVendorCurrency(txtVendorCode.Text.Trim());

                    string payterm = AccUtil.GetVendorPayTerm(txtVendorCode.Text.Trim());
                    string paydate = AccUtil.PayDate(dtpInput.Value, payterm);

                    dtpPaymentDate.Value = Convert.ToDateTime(paydate);
                }
                catch
                {
                    MessageBox.Show("Invalid Vendor code.");
                    txtVendorCode.BackColor = Color.Yellow;
                    btnSearch1.BackColor = Color.Yellow;
                }
            }
            else
            {
                txtVendorName.Text = "";
                txtVendorCode.BackColor = Color.White;
                btnSearch1.BackColor = Color.White;
            }
        }

        private void dgvOutstanding_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 10)
                e.Value = Properties.Resources.error_16;
        }

        private void dgvOutstanding_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;

            if (dgvOutstanding.CurrentCell.ColumnIndex == 2)
            {
                if (combo != null)
                    combo.SelectedIndexChanged += new EventHandler(combo_SelectedIndexChanged);
            }
        }

        private void combo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvOutstanding.CurrentCell.ColumnIndex == 2)
            {
                ComboBox cb = (ComboBox)sender;
                string item = cb.Text;
                if (item != null && item != "")
                {
                    item = item.Substring(0, 11);

                    DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)dgvOutstanding[0, dgvOutstanding.CurrentRow.Index];
                    cell.DataSource = AccountCodeColumn(item);
                }
            }
        }

        private void dgvOutstanding_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void dgvOutstanding_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //Debug.WriteLine("bb");
        }

        private void dgvOutstanding_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                if (dgvOutstanding.CurrentRow.IsNewRow) return;

                dgvOutstanding.Rows.Remove(dgvOutstanding.CurrentRow);
            }
        }

        private void dgvOutstanding_KeyDown(object sender, KeyEventArgs e)
        {

        }

        
    }

   
}
