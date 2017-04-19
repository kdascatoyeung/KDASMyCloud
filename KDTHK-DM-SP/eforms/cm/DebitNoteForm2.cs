using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using KDTHK_DM_SP.eforms.cm.subforms;
using KDTHK_DM_SP.utils;
using CustomUtil.utils.authentication;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using CustomUtil.utils.import;

namespace KDTHK_DM_SP.eforms.cm
{
    public partial class DebitNoteForm2 : Form
    {
        double _rate = 0;

        List<string> reasonList;

        string _formType = "";

        string _mode = ""; string _docId = "";

        public DebitNoteForm2(string type, string mode, string docId)
        {
            InitializeComponent();

            _formType = type;

            _mode = mode;

            _docId = docId;

            //GlobalService.User = AdUtil.getUsername("kmhk.local");

            this.Text = type == "debit" ? "Debit Note Application Form" : "Credit Note Application Form";

            lblTitle.Text = type == "debit" ? "Debit Note Request Form" : "Credit Note Request Form";

            reasonList = new List<string>();

            Application.Idle += new EventHandler(Application_Idle);

            txtInvTotal1.LostFocus += new EventHandler(TextBoxLostFocus);
            txtInvTotal2.LostFocus += new EventHandler(TextBoxLostFocus);
            txtInvTotal3.LostFocus += new EventHandler(TextBoxLostFocus);
            txtInvTotal4.LostFocus += new EventHandler(TextBoxLostFocus);
            txtInvTotal5.LostFocus += new EventHandler(TextBoxLostFocus);

            txtInvTotal1_1.LostFocus += new EventHandler(TextBoxLostFocus);
            txtInvTotal2_1.LostFocus += new EventHandler(TextBoxLostFocus);
            txtInvTotal3_1.LostFocus += new EventHandler(TextBoxLostFocus);
            txtInvTotal4_1.LostFocus += new EventHandler(TextBoxLostFocus);
            txtInvTotal5_1.LostFocus += new EventHandler(TextBoxLostFocus);

            LoadAccountCode();

            LoadCostCentre();

            LoadRateMonth();

            if (mode == "view")
            {
                LoadData(docId);
                //LoadCustomerInfo(txtCustName.Text.Trim());
            }
            btnDelete.Visible = mode == "view" ? true : false;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            if (!txtCustName.Text.ToLower().Contains("kyocera"))
            {
                txtCustDiv.Enabled = false;
                txtCustDiv.BackColor = Color.Gray;

                txtDivname.Enabled = false;
                txtDivname.BackColor = Color.Gray;

                txtIncharge.Enabled = false;
                txtIncharge.BackColor = Color.Gray;
            }
            else
            {
                txtCustDiv.Enabled = true;
                txtCustDiv.BackColor = SystemColors.ControlLightLight;
                txtDivname.Enabled = true;
                txtDivname.BackColor = SystemColors.ControlLightLight;
                txtIncharge.Enabled = true;
                txtIncharge.BackColor = SystemColors.ControlLightLight;
            }

            if (txtCustCurr.Text != "")
            {
                if (txtCustCurr.Text == "HKD")
                {
                    cbDnCurr1.Enabled = false;
                    panel4.Visible = true;
                    cbDnCurr2.Enabled = true;
                    panel5.Visible = false;
                }
                else
                {
                    cbDnCurr1.Enabled = true;
                    panel4.Visible = false;
                    cbDnCurr2.Enabled = false;
                    panel5.Visible = true;
                }
            }

            panel6.Visible = cbRateMonth.Enabled ? false : true;
        }

        private void LoadData(string docId)
        {
            int id = 0;

            string query = string.Format("select d_reqdate, d_reqoffice, d_reqcostcentre, d_custcode, d_custname, d_custcurr, d_payterm, d_duedate, d_custdiv, d_divname" +
                ", d_incharge, d_items, d_reason, d_custreason, d_invno, d_ringino, d_exmonth, d_id, d_dntotal1, d_dntotal2 from TB_CM_DEBIT where d_docno = '{0}'", docId);

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    dtpDate.Value = DateTime.Today;//Convert.ToDateTime(reader.GetString(0).Trim());
                    txtReqOffice.Text = reader.GetString(1).Trim();
                    txtReqCostcentre.Text = reader.GetString(2).Trim();
                    txtCustCode.Text = reader.GetString(3).Trim();
                    txtCustName.Text = reader.GetString(4).Trim();
                    txtCustCurr.Text = reader.GetString(5).Trim();
                    txtPayTerm.Text = reader.GetString(6).Trim();
                    txtDueDate.Text = reader.GetString(7).Trim();
                    txtCustDiv.Text = reader.GetString(8).Trim();
                    txtDivname.Text = reader.GetString(9).Trim();
                    txtIncharge.Text = reader.GetString(10).Trim();
                    txtReqItem.Text = reader.GetString(11).Trim();
                    txtReason.Text = reader.GetString(12).Trim();
                    txtManual.Text = reader.GetString(13).Trim();
                    txtInvNo.Text = reader.GetString(14).Trim();
                    txtRingiNo.Text = reader.GetString(15).Trim();
                    cbRateMonth.Text = reader.GetString(16).Trim();
                    id = reader.GetInt32(17);
                    txtDnTotal1.Text = reader.GetString(18).Trim();
                    txtDnTotal2.Text = reader.GetString(19).Trim();
                }
            }

            if (txtCustCurr.Text != "HKD")
            {
                CmsService.CustomerCurr = txtCustCurr.Text.Trim();

                cbDnCurr1.Text = CmsService.CustomerCurr;

                cbInvCurr1.Text = cbInvCurr2.Text = cbInvCurr3.Text = cbInvCurr4.Text = cbInvCurr5.Text = CmsService.CustomerCurr;

                cbInvCurr1.Items.Add(CmsService.CustomerCurr);
                cbInvCurr2.Items.Add(CmsService.CustomerCurr);
                cbInvCurr3.Items.Add(CmsService.CustomerCurr);
                cbInvCurr4.Items.Add(CmsService.CustomerCurr);
                cbInvCurr5.Items.Add(CmsService.CustomerCurr);

                string[] items = { "HKD", "USD", "JPY", "RMB", "EUR" };
                foreach (string item in items)
                {
                    if (item == CmsService.CustomerCurr) continue;

                    cbInvCurr1_1.Items.Add(item);
                    cbInvCurr2_1.Items.Add(item);
                    cbInvCurr3_1.Items.Add(item);
                    cbInvCurr4_1.Items.Add(item);
                    cbInvCurr5_1.Items.Add(item);
                }
            }
            else
            {
                cbDnCurr2.Text = "HKD";

                cbInvCurr1_1.Text = cbInvCurr2_1.Text = cbInvCurr3_1.Text = cbInvCurr4_1.Text = cbInvCurr5_1.Text = "HKD";

                cbInvCurr1_1.Items.Add("HKD");
                cbInvCurr2_1.Items.Add("HKD");
                cbInvCurr3_1.Items.Add("HKD");
                cbInvCurr4_1.Items.Add("HKD");
                cbInvCurr5_1.Items.Add("HKD");

                string[] items = { "USD", "JPY", "RMB", "EUR" };
                foreach (string item in items)
                {
                    cbInvCurr1.Items.Add(item);
                    cbInvCurr2.Items.Add(item);
                    cbInvCurr3.Items.Add(item);
                    cbInvCurr4.Items.Add(item);
                    cbInvCurr5.Items.Add(item);
                }
            }

            string text = string.Format("select t_reason, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2 from TB_CM_DEBIT_TRANSACTION where t_debitid = '{0}'", id);

            List<TransactionData> list = new List<TransactionData>();

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(text))
            {
                while (reader.Read())
                {
                    string reason = reader.GetString(0).Trim();
                    string accountcode = reader.GetString(1).Trim();
                    string costcentre = reader.GetString(2).Trim();
                    string invcurr1 = reader.GetString(3).Trim();
                    string invtotal1 = reader.GetString(4).Trim();
                    string invcurr2 = reader.GetString(5).Trim();
                    string invtotal2 = reader.GetString(6).Trim();

                    list.Add(new TransactionData { Reason = reason, AccountCode = accountcode, CostCentre = costcentre, InvCurr1 = invcurr1, InvTotal1 = invtotal1, InvCurr2 = invcurr2, InvTotal2 = invtotal2 });
                }
            }

            if (list.Count > 0)
            {
                txtTranReason1.Text = list[0].Reason;
                cbAc1.Text = list[0].AccountCode;
                cbCostCentre1.Text = list[0].CostCentre;
                cbInvCurr1.Text = list[0].InvCurr1;
                txtInvTotal1.Text = list[0].InvTotal1;
                cbInvCurr1_1.Text = list[0].InvCurr2;
                txtInvTotal1_1.Text = list[0].InvTotal2;
            }

            if (list.Count > 1)
            {
                txtTranReason2.Text = list[1].Reason;
                cbAc2.Text = list[1].AccountCode;
                cbCostCentre2.Text = list[1].CostCentre;
                cbInvCurr2.Text = list[1].InvCurr1;
                txtInvTotal2.Text = list[1].InvTotal1;
                cbInvCurr2_1.Text = list[1].InvCurr2;
                txtInvTotal2_1.Text = list[1].InvTotal2;
            }

            if (list.Count > 2)
            {
                txtTranReason3.Text = list[2].Reason;
                cbAc3.Text = list[2].AccountCode;
                cbCostCentre3.Text = list[2].CostCentre;
                cbInvCurr3.Text = list[2].InvCurr1;
                txtInvTotal3.Text = list[2].InvTotal1;
                cbInvCurr3_1.Text = list[2].InvCurr2;
                txtInvTotal3_1.Text = list[2].InvTotal2;
            }

            if (list.Count > 3)
            {
                txtTranReason4.Text = list[3].Reason;
                cbAc4.Text = list[3].AccountCode;
                cbCostCentre4.Text = list[3].CostCentre;
                cbInvCurr4.Text = list[3].InvCurr1;
                txtInvTotal4.Text = list[3].InvTotal1;
                cbInvCurr4_1.Text = list[3].InvCurr2;
                txtInvTotal4_1.Text = list[3].InvTotal2;
            }

            if (list.Count > 4)
            {
                txtTranReason5.Text = list[4].Reason;
                cbAc5.Text = list[4].AccountCode;
                cbCostCentre5.Text = list[4].CostCentre;
                cbInvCurr5.Text = list[4].InvCurr1;
                txtInvTotal5.Text = list[4].InvTotal1;
                cbInvCurr5_1.Text = list[4].InvCurr2;
                txtInvTotal5_1.Text = list[4].InvTotal2;
            }
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void LoadAccountCode()
        {
            string query = "select a_code from TB_CM_MASTER_ACCOUNTCODE";

            List<string> accList1 = new List<string>();
            List<string> accList2 = new List<string>();
            List<string> accList3 = new List<string>();
            List<string> accList4 = new List<string>();
            List<string> accList5 = new List<string>();

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    accList1.Add(reader.GetString(0).Trim());
                    accList2.Add(reader.GetString(0).Trim());
                    accList3.Add(reader.GetString(0).Trim());
                    accList4.Add(reader.GetString(0).Trim());
                    accList5.Add(reader.GetString(0).Trim());
                }
            }

            cbAc1.DataSource = accList1;
            cbAc2.DataSource = accList2;
            cbAc3.DataSource = accList3;
            cbAc4.DataSource = accList4;
            cbAc5.DataSource = accList5;

            cbAc1.SelectedItem = null;
            cbAc2.SelectedItem = null;
            cbAc3.SelectedItem = null;
            cbAc4.SelectedItem = null;
            cbAc5.SelectedItem = null;
        }

        private void LoadCostCentre()
        {
            string query = "select c_code from TB_CM_MASTER_COSTCENTRE";

            List<string> ccList1 = new List<string>();
            List<string> ccList2 = new List<string>();
            List<string> ccList3 = new List<string>();
            List<string> ccList4 = new List<string>();
            List<string> ccList5 = new List<string>();

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    ccList1.Add(reader.GetString(0).Trim());
                    ccList2.Add(reader.GetString(0).Trim());
                    ccList3.Add(reader.GetString(0).Trim());
                    ccList4.Add(reader.GetString(0).Trim());
                    ccList5.Add(reader.GetString(0).Trim());
                }
            }

            cbCostCentre1.DataSource = ccList1;
            cbCostCentre2.DataSource = ccList2;
            cbCostCentre3.DataSource = ccList3;
            cbCostCentre4.DataSource = ccList4;
            cbCostCentre5.DataSource = ccList5;

            cbCostCentre1.SelectedItem = null;
            cbCostCentre2.SelectedItem = null;
            cbCostCentre3.SelectedItem = null;
            cbCostCentre4.SelectedItem = null;
            cbCostCentre5.SelectedItem = null;
        }

        private void LoadRateMonth()
        {
            string query = "select cu_month from TB_CM_MASTER_CURRENCY group by cu_month order by cu_month desc";
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    cbRateMonth.Items.Add(reader.GetString(0).Trim());
            }
        }

        private void LoadCustomerInfo(string custName)
        {
            CustomerSearchForm form = new CustomerSearchForm(custName);
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtCustCode.Text = CmsService.CustomerCode;
                txtCustName.Text = CmsService.CustomerName;
                txtCustCurr.Text = CmsService.CustomerCurr;
                txtPayTerm.Text = CmsService.CustomerPayTerm;

                string payterm = txtPayTerm.Text.Trim();
                DateTime date = dtpDate.Value;

                string duedate = payterm == "HK01" ? new DateTime(date.Year, date.Month, 1).AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd")
                    : payterm == "HK02" ? new DateTime(date.Year, date.Month, 1).AddMonths(3).AddDays(-1).ToString("yyyy/MM/dd")
                    : payterm == "HK03" ? new DateTime(date.Year, date.Month, 1).AddMonths(3).AddDays(9).ToString("yyyy/MM/dd")
                    : payterm == "HK06" ? new DateTime(date.Year, date.Month, 1).AddMonths(2).AddDays(14).ToString("yyyy/MM/dd")
                    : payterm == "HK07" ? new DateTime(date.Year, date.Month, 1).AddMonths(2).AddDays(9).ToString("yyyy/MM/dd")
                    : payterm == "HK08" ? date.AddDays(7).ToString("yyyy/MM/dd")
                    : payterm == "HK09" ? date.AddDays(30).ToString("yyyy/MM/dd")
                    : payterm == "HK51" ? new DateTime(date.Year, date.Month, 1).AddMonths(2).AddDays(24).ToString("yyyy/MM/dd")
                    : payterm == "HK52" ? new DateTime(date.Year, date.Month, 1).AddMonths(3).AddDays(-1).ToString("yyyy/MM/dd")
                    : payterm == "HK53" ? new DateTime(date.Year, date.Month, 1).AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd") : "";

                txtDueDate.Text = duedate + " " + txtPayTerm.Text;

                cbInvCurr1.Items.Clear();
                cbInvCurr2.Items.Clear();
                cbInvCurr3.Items.Clear();
                cbInvCurr4.Items.Clear();
                cbInvCurr5.Items.Clear();

                cbInvCurr1_1.Items.Clear();
                cbInvCurr2_1.Items.Clear();
                cbInvCurr3_1.Items.Clear();
                cbInvCurr4_1.Items.Clear();
                cbInvCurr5_1.Items.Clear();

                txtDnTotal1.Clear();
                txtDnTotal2.Clear();

                txtInvTotal1.Clear();
                txtInvTotal2.Clear();
                txtInvTotal3.Clear();
                txtInvTotal4.Clear();
                txtInvTotal5.Clear();

                txtInvTotal1_1.Clear();
                txtInvTotal2_1.Clear();
                txtInvTotal3_1.Clear();
                txtInvTotal4_1.Clear();
                txtInvTotal5_1.Clear();

                if (txtCustCurr.Text != "HKD")
                {
                    cbDnCurr1.Text = CmsService.CustomerCurr;

                    cbInvCurr1.Text = cbInvCurr2.Text = cbInvCurr3.Text = cbInvCurr4.Text = cbInvCurr5.Text = CmsService.CustomerCurr;

                    cbInvCurr1.Items.Add(CmsService.CustomerCurr);
                    cbInvCurr2.Items.Add(CmsService.CustomerCurr);
                    cbInvCurr3.Items.Add(CmsService.CustomerCurr);
                    cbInvCurr4.Items.Add(CmsService.CustomerCurr);
                    cbInvCurr5.Items.Add(CmsService.CustomerCurr);

                    string[] items = { "HKD", "USD", "JPY", "RMB", "EUR" };
                    foreach (string item in items)
                    {
                        if (item == CmsService.CustomerCurr) continue;

                        cbInvCurr1_1.Items.Add(item);
                        cbInvCurr2_1.Items.Add(item);
                        cbInvCurr3_1.Items.Add(item);
                        cbInvCurr4_1.Items.Add(item);
                        cbInvCurr5_1.Items.Add(item);
                    }
                }
                else
                {
                    cbDnCurr2.Text = "HKD";

                    cbInvCurr1_1.Text = cbInvCurr2_1.Text = cbInvCurr3_1.Text = cbInvCurr4_1.Text = cbInvCurr5_1.Text = "HKD";

                    cbInvCurr1_1.Items.Add("HKD");
                    cbInvCurr2_1.Items.Add("HKD");
                    cbInvCurr3_1.Items.Add("HKD");
                    cbInvCurr4_1.Items.Add("HKD");
                    cbInvCurr5_1.Items.Add("HKD");

                    string[] items = { "USD", "JPY", "RMB", "EUR" };
                    foreach (string item in items)
                    {
                        cbInvCurr1.Items.Add(item);
                        cbInvCurr2.Items.Add(item);
                        cbInvCurr3.Items.Add(item);
                        cbInvCurr4.Items.Add(item);
                        cbInvCurr5.Items.Add(item);
                    }
                }

                txtCustCode.BackColor = Color.Gray;
                txtCustCurr.BackColor = Color.Gray; ;
                txtPayTerm.BackColor = Color.Gray; ;
                txtDueDate.BackColor = Color.Gray; ;

                _rate = GetRate(CmsService.CurrencyType, CmsService.CurrencyDesc, DateTime.Today.ToString("yyyy/MM"));
            }
        }

        private double GetRate(string type, string desc, string month)
        {
            string query = string.Format("select cu_currency from TB_CM_MASTER_CURRENCY where cu_type = '{0}' and cu_description = N'{1}' and cu_month = '{2}'", type, desc, month);

            var result = DataServiceCM.GetInstance().ExecuteScalar(query);

            return Convert.ToDouble(result);
        }

        private void btnOfficeName_Click(object sender, EventArgs e)
        {
            txtReqOffice.Text = UserUtil.GetDiv(GlobalService.User);
        }

        private void btnCostCentre_Click(object sender, EventArgs e)
        {
            string division = UserUtil.GetDiv(GlobalService.User);

            string div = division == "MASTER管理科" ? "29900 MCC"
                : division == "RPS管理科" ? "32600 RPS Mgt Divisi"
                : division == "開發採購1科" ? "13100 Procur. Div. 1"
                : division == "開發採購2科" ? "13200 Procur. Div. 2"
                : division == "開發採購3科" ? "13300 Procur. Div. 3"
                : division == "行政科" ? "22300 Administration"
                : division == "採購管理科" ? "13400 Management Div"
                : division == "事業推進科" ? "23700 Corporate Deve"
                : division == "人力資源科" ? "23400 Personnel Div"
                : division == "會計科" ? "22100 Accounting Div"
                : division == "經營管理科" ? "22200 Mana. Con. Div"
                : division == "物流管理科" ? "31120 Logistics Sect" : "";

            Debug.WriteLine("Division: " + division);

            if (division == "倉庫管理1科" || division == "倉庫管理2科")
            {
                string result = UserUtil.GetSect(GlobalService.User);

                div = result == "國內出口部品係" ? "11211 KDTCN Export"
                    : result == "支給部品1係" ? "11221 Parts WH Sec 1"
                    : result == "KDC出口部品係" ? "11251 KDC Export Par"
                    : result == "KDTVN出口部品係" ? "11261 KDTVN Export"
                    : result == "支給部品2係" ? "11271 Parts WH Sec 2" : "";
            }
            string query = string.Format("select c_code from TB_CM_MASTER_COSTCENTRE where c_name = N'{0}'", div);

            Debug.WriteLine("Query: " + query);
            txtReqCostcentre.Text = DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        private void btnCustSearch_Click(object sender, EventArgs e)
        {
            LoadCustomerInfo(txtCustName.Text.Trim());
        }

        private void txtCustName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadCustomerInfo(txtCustName.Text.Trim());
        }

        private void btnInvNo_Click(object sender, EventArgs e)
        {
            NumberInputForm form = new NumberInputForm(txtInvNo.Text, "inv");
            if (form.ShowDialog() == DialogResult.OK)
                txtInvNo.Text = CmsService.InputInvNo;
        }

        private void btnRingiNo_Click(object sender, EventArgs e)
        {
            NumberInputForm form = new NumberInputForm(txtRingiNo.Text, "ringi");
            if (form.ShowDialog() == DialogResult.OK)
                txtRingiNo.Text = CmsService.InputRingiNo;
        }

        private void TextBoxLostFocus(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            string tag = textbox.Tag.ToString();

            if (tag.StartsWith("foreign"))
            {
                try
                {
                    if (txtCustCurr.Text != "HKD")
                        txtDnTotal1.Text = DoFormat(SumUpTotal1().ToString());
                }
                catch
                {
                    MessageBox.Show("You have input invalid amount format.");
                }
            }

            if (tag.StartsWith("local"))
            {
                try
                {
                    if (txtCustCurr.Text == "HKD")
                        txtDnTotal2.Text = DoFormat(SumUpTotal2().ToString());
                }
                catch
                {
                    MessageBox.Show("You have input invalid amount format.");
                }
            }
        }

        private double SumUpTotal1()
        {
            double value1 = txtInvTotal1.Text == "" ? 0 : Convert.ToDouble(txtInvTotal1.Text);
            double value2 = txtInvTotal2.Text == "" ? 0 : Convert.ToDouble(txtInvTotal2.Text);
            double value3 = txtInvTotal3.Text == "" ? 0 : Convert.ToDouble(txtInvTotal3.Text);
            double value4 = txtInvTotal4.Text == "" ? 0 : Convert.ToDouble(txtInvTotal4.Text);
            double value5 = txtInvTotal5.Text == "" ? 0 : Convert.ToDouble(txtInvTotal5.Text);

            return value1 + value2 + value3 + value4 + value5;
        }

        private double SumUpTotal2()
        {
            double value1 = txtInvTotal1_1.Text == "" ? 0 : Convert.ToDouble(txtInvTotal1_1.Text);
            double value2 = txtInvTotal2_1.Text == "" ? 0 : Convert.ToDouble(txtInvTotal2_1.Text);
            double value3 = txtInvTotal3_1.Text == "" ? 0 : Convert.ToDouble(txtInvTotal3_1.Text);
            double value4 = txtInvTotal4_1.Text == "" ? 0 : Convert.ToDouble(txtInvTotal4_1.Text);
            double value5 = txtInvTotal5_1.Text == "" ? 0 : Convert.ToDouble(txtInvTotal5_1.Text);

            return value1 + value2 + value3 + value4 + value5;
        }

        private string DoFormat(string text)
        {
            var s = string.Format("{0:0.00}", Convert.ToDouble(text));

            s = StringUtil.Calculation(s, 50);

            return s;
        }

        private void PopulateReasonList(string reason1, string reason2, string reason3, string reason4, string reason5)
        {
            reasonList = new List<string>();

            reasonList.Add(reason1);

            if (reason2 != "-" && reason2 != "" && reason2 != "同上") reasonList.Add(reason2);

            if (reason3 != "-" && reason3 != "" && reason3 != "同上") reasonList.Add(reason3);

            if (reason4 != "-" && reason4 != "" && reason4 != "同上") reasonList.Add(reason4);

            if (reason5 != "-" && reason5 != "" && reason5 != "同上") reasonList.Add(reason5);
        }

        private void TranReasonButtonClicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string tag = button.Tag.ToString().Trim();

            TextBox textbox = tag == "tr1" ? txtTranReason1
                : tag == "tr2" ? txtTranReason2
                : tag == "tr3" ? txtTranReason3
                : tag == "tr4" ? txtTranReason4
                : tag == "tr5" ? txtTranReason5 : null;

            DescriptionSelectionForm form = new DescriptionSelectionForm(textbox.Text.Trim());

            if (form.ShowDialog() == DialogResult.OK)
            {
                reasonList = new List<string>();

                if (tag == "tr1") txtTranReason1.Text = CmsService.TransactionReason;
                if (tag == "tr2") txtTranReason2.Text = CmsService.TransactionReason;
                if (tag == "tr3") txtTranReason3.Text = CmsService.TransactionReason;
                if (tag == "tr4") txtTranReason4.Text = CmsService.TransactionReason;
                if (tag == "tr5") txtTranReason5.Text = CmsService.TransactionReason;

                PopulateReasonList(txtTranReason1.Text, txtTranReason2.Text, txtTranReason3.Text, txtTranReason4.Text, txtTranReason5.Text);

                reasonList = reasonList.Distinct().ToList();
                if (reasonList.Count == 1)
                    txtReason.Text = reasonList[0].ToString().Trim();
                else if (reasonList.Count > 1)
                    txtReason.Text = string.Join("&", reasonList.ToArray());
                else
                    return;
            }
        }

        private void TranReasonKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                TextBox textbox = (TextBox)sender;
                textbox.Clear();
            }

            if (e.KeyCode == Keys.Enter)
            {
                TextBox textbox = (TextBox)sender;
                string tag = textbox.Tag.ToString().Trim();

                string query = string.Format("select count(*) from TB_CM_MASTER_DESCRIPTION where d_r3 = '{0}'", textbox.Text);
                int result = (int)DataServiceCM.GetInstance().ExecuteScalar(query);

                if (result > 0)
                {
                    reasonList = new List<string>();

                    PopulateReasonList(txtTranReason1.Text, txtTranReason2.Text, txtTranReason3.Text, txtTranReason4.Text, txtTranReason5.Text);

                    reasonList = reasonList.Distinct().ToList();
                    if (reasonList.Count == 1)
                        txtReason.Text = reasonList[0].ToString().Trim();
                    else if (reasonList.Count > 1)
                        txtReason.Text = string.Join("&", reasonList.ToArray());
                    else
                        return;
                }
                else
                {
                    DescriptionSelectionForm form = new DescriptionSelectionForm(textbox.Text.Trim());

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        reasonList = new List<string>();

                        if (tag == "tr1") txtTranReason1.Text = CmsService.TransactionReason;
                        if (tag == "tr2") txtTranReason2.Text = CmsService.TransactionReason;
                        if (tag == "tr3") txtTranReason3.Text = CmsService.TransactionReason;
                        if (tag == "tr4") txtTranReason4.Text = CmsService.TransactionReason;
                        if (tag == "tr5") txtTranReason5.Text = CmsService.TransactionReason;

                        PopulateReasonList(txtTranReason1.Text, txtTranReason2.Text, txtTranReason3.Text, txtTranReason4.Text, txtTranReason5.Text);

                        reasonList = reasonList.Distinct().ToList();
                        if (reasonList.Count == 1)
                            txtReason.Text = reasonList[0].ToString().Trim();
                        else if (reasonList.Count > 1)
                            txtReason.Text = string.Join("&", reasonList.ToArray());
                        else
                            return;
                    }
                }
            }
        }

        private string CurrencyType(string rate1, string rate2)
        {
            string result = "";

            if (rate1 == "USD")
            {
                if (rate2 == "HKD") result = "USD1-HKD";
                if (rate2 == "EUR") result = "EUR1-USD";
                if (rate2 == "JPY") result = "USD1-JPY";
            }

            if (rate1 == "HKD")
            {
                if (rate2 == "USD") result = "USD1-HKD";
                if (rate2 == "JPY") result = "JPY1-HKD";
                if (rate2 == "EUR") result = "EUR1-HKD";
                if (rate2 == "RMB") result = "RMB1-HKD";
            }

            if (rate1 == "JPY")
            {
                if (rate2 == "USD") result = "JPY1-USD";
                if (rate2 == "HKD") result = "JPY1-HKD";
            }

            if (rate1 == "EUR")
            {
                if (rate2 == "HKD") result = "EUR1-HKD";
                if (rate2 == "USD") result = "EUR1-USD";
            }

            if (rate1 == "RMB")
            {
                if (rate2 == "HKD") result = "RMB1-HKD";
            }

            return result;
        }

        private double GetCurrencyRate(string desc, string month, string rate1, string rate2)
        {
            string ctype = CurrencyType(rate1, rate2);

            string query = desc =="1. 三國間" && ctype=="RMB1-HKD"? string.Format("select cu_currency from TB_CM_MASTER_CURRENCY where cu_description = N'{0}' and cu_month = '{1}'", "4. 人民幣運輸費", month)
                :string.Format("select cu_currency from TB_CM_MASTER_CURRENCY where cu_type = '{0}' and cu_description = N'{1}' and cu_month = '{2}'", ctype, desc, month);

            Debug.WriteLine("Query: " + query);

            var result = DataServiceCM.GetInstance().ExecuteScalar(query);

            return Convert.ToDouble(result);
        }

        private void RateButtonClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tag = btn.Tag.ToString().Trim();

            if (!cbRateMonth.Enabled)
            {
                cbRateMonth.Enabled = true;
                cbRateMonth.SelectedIndex = 0;
            }

            string today = cbRateMonth.Enabled ? cbRateMonth.SelectedItem.ToString().Trim() : DateTime.Today.ToString("yyyy/MM");

            if (tag == "rate1")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr1.Text, cbInvCurr1_1.Text);

                if (selectedTextBox == "foreign1")
                {
                    if (cbInvCurr1.Text != "" && cbInvCurr1_1.Text != "")
                        txtInvTotal1_1.Text = Math.Round(Convert.ToDouble(txtInvTotal1.Text) * rate, 2).ToString();
                }
                else if (selectedTextBox == "local1")
                {
                    if (cbInvCurr1.Text != "" && cbInvCurr1_1.Text != "")
                        txtInvTotal1.Text = Math.Round(Convert.ToDouble(txtInvTotal1_1.Text) / rate, 2).ToString();
                }
                else { }
            }

            if (tag == "rate2")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr2.Text, cbInvCurr2_1.Text);

                if (selectedTextBox == "foreign2")
                {
                    if (cbInvCurr2.Text != "" && cbInvCurr2_1.Text != "")
                        txtInvTotal2_1.Text = Math.Round(Convert.ToDouble(txtInvTotal2.Text) * rate, 2).ToString();
                }
                else if (selectedTextBox == "local2")
                {
                    if (cbInvCurr2.Text != "" && cbInvCurr2_1.Text != "")
                        txtInvTotal2.Text = Math.Round(Convert.ToDouble(txtInvTotal2_1.Text) / rate, 2).ToString();
                }
                else { }
            }

            if (tag == "rate3")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr3.Text, cbInvCurr3_1.Text);

                if (selectedTextBox == "foreign3")
                {
                    if (cbInvCurr3.Text != "" && cbInvCurr3_1.Text != "")
                        txtInvTotal3_1.Text = Math.Round(Convert.ToDouble(txtInvTotal3.Text) * rate, 2).ToString();
                }
                else if (selectedTextBox == "local3")
                {
                    if (cbInvCurr3_1.Text != "" && cbInvCurr3_1.Text != "")
                        txtInvTotal3.Text = Math.Round(Convert.ToDouble(txtInvTotal3_1.Text) / rate, 2).ToString();
                }
                else { }
            }

            if (tag == "rate4")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr4.Text, cbInvCurr4_1.Text);

                if (selectedTextBox == "foreign4")
                {
                    if(cbInvCurr4.Text!=""&&cbInvCurr4_1.Text!="")
                        txtInvTotal4_1.Text = Math.Round(Convert.ToDouble(txtInvTotal4.Text) * rate, 2).ToString();
                }
                else if (selectedTextBox == "local4")
                {
                    if(cbInvCurr4.Text!=""&&cbInvCurr4_1.Text!="")
                        txtInvTotal4.Text = Math.Round(Convert.ToDouble(txtInvTotal4_1.Text) / rate, 2).ToString();
                }
                else { }
            }

            if (tag == "rate5")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr5.Text, cbInvCurr5_1.Text);

                if (selectedTextBox == "foreign5")
                {
                    if (cbInvCurr5.Text != "" && cbInvCurr5_1.Text != "")
                        txtInvTotal5_1.Text = Math.Round(Convert.ToDouble(txtInvTotal5.Text) * rate, 2).ToString();
                }
                else if (selectedTextBox == "local5")
                {
                    if (cbInvCurr5.Text != "" && cbInvCurr5_1.Text != "")
                        txtInvTotal5.Text = Math.Round(Convert.ToDouble(txtInvTotal5_1.Text) / rate, 2).ToString();
                }
                else { }
            }

            if (cbDnCurr1.Enabled)
            {
                if (txtCustCurr.Text != "HKD")
                    txtDnTotal1.Text = DoFormat(SumUpTotal1().ToString());
            }
            else
            {
                if (txtCustCurr.Text == "HKD")
                    txtDnTotal2.Text = DoFormat(SumUpTotal2().ToString());
            }
        }

        private void cbRateMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region
            if (cbInvCurr1.Text != "" && txtInvTotal1.Text != "" && cbInvCurr1_1.Text != "" && txtInvTotal1_1.Text == "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr1.Text, cbInvCurr1_1.Text);
                Debug.WriteLine("Rate: " + rate);

                txtInvTotal1_1.Text = Math.Round(Convert.ToDouble(txtInvTotal1.Text) * rate, 2).ToString();
            }
            else if (cbInvCurr2.Text != "" && txtInvTotal2.Text != "" && cbInvCurr2_1.Text != "" && txtInvTotal2_1.Text == "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr2.Text, cbInvCurr2_1.Text);
                txtInvTotal2_1.Text = Math.Round(Convert.ToDouble(txtInvTotal2.Text) * rate, 2).ToString();
            }
            else if (cbInvCurr3.Text != "" && txtInvTotal3.Text != "" && cbInvCurr3_1.Text != "" && txtInvTotal3_1.Text == "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr3.Text, cbInvCurr3_1.Text);
                txtInvTotal3_1.Text = Math.Round(Convert.ToDouble(txtInvTotal3.Text) * rate, 2).ToString();
            }
            else if (cbInvCurr4.Text != "" && txtInvTotal4.Text != "" && cbInvCurr4_1.Text != "" && txtInvTotal4_1.Text == "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr4.Text, cbInvCurr4_1.Text);
                txtInvTotal4_1.Text = Math.Round(Convert.ToDouble(txtInvTotal4.Text) * rate, 2).ToString();
            }
            else if (cbInvCurr5.Text != "" && txtInvTotal5.Text != "" && cbInvCurr5_1.Text != "" && txtInvTotal5_1.Text == "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr5.Text, cbInvCurr5_1.Text);
                txtInvTotal5_1.Text = Math.Round(Convert.ToDouble(txtInvTotal5.Text) * rate, 2).ToString();
            }
            //=====================================================================================================================================
            else if (cbInvCurr1_1.Text != "" && txtInvTotal1_1.Text != "" && cbInvCurr1.Text != "" && txtInvTotal1.Text == "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString(), cbInvCurr1.Text, cbInvCurr1_1.Text);
                txtInvTotal1.Text = Math.Round(Convert.ToDouble(txtInvTotal1_1.Text) / rate, 2).ToString();
            }
            else if (cbInvCurr2_1.Text != "" && txtInvTotal2_1.Text != "" && txtInvTotal2.Text == "" && txtInvTotal2.Text == "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString(), cbInvCurr2.Text, cbInvCurr2_1.Text);
                txtInvTotal2.Text = Math.Round(Convert.ToDouble(txtInvTotal2_1.Text) / rate, 2).ToString();
            }
            else if (cbInvCurr3_1.Text != "" && txtInvTotal3_1.Text != "" && txtInvTotal3.Text == "" && txtInvTotal3.Text == "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString(), cbInvCurr3.Text, cbInvCurr3_1.Text);
                txtInvTotal3.Text = Math.Round(Convert.ToDouble(txtInvTotal3_1.Text) / rate, 2).ToString();
            }
            else if (cbInvCurr4_1.Text != "" && txtInvTotal4_1.Text != "" && txtInvTotal4.Text == "" && txtInvTotal4.Text == "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString(), cbInvCurr4.Text, cbInvCurr4_1.Text);
                txtInvTotal4.Text = Math.Round(Convert.ToDouble(txtInvTotal4_1.Text) / rate, 2).ToString();
            }
            else if (cbInvCurr5_1.Text != "" && txtInvTotal5_1.Text != "" && txtInvTotal5.Text == "" && txtInvTotal5.Text == "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString(), cbInvCurr5.Text, cbInvCurr5_1.Text);
                txtInvTotal5.Text = Math.Round(Convert.ToDouble(txtInvTotal5_1.Text) / rate, 2).ToString();
            }
            //=====================================================================================================================================
            else if (cbInvCurr1.Text != "" && txtInvTotal1.Text != "" && cbInvCurr1_1.Text != "" && txtInvTotal1_1.Text != "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr1.Text, cbInvCurr1_1.Text);
                txtInvTotal1_1.Text = Math.Round(Convert.ToDouble(txtInvTotal1.Text) * rate, 2).ToString();
            }
            else if (cbInvCurr2.Text != "" && txtInvTotal2.Text != "" && cbInvCurr2_1.Text != "" && txtInvTotal2_1.Text != "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr2.Text, cbInvCurr2_1.Text);
                txtInvTotal2_1.Text = Math.Round(Convert.ToDouble(txtInvTotal2.Text) * rate, 2).ToString();
            }
            else if (cbInvCurr3.Text != "" && txtInvTotal3.Text != "" && cbInvCurr3_1.Text != "" && txtInvTotal3_1.Text != "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr3.Text, cbInvCurr3_1.Text);
                txtInvTotal3_1.Text = Math.Round(Convert.ToDouble(txtInvTotal3.Text) * rate, 2).ToString();
            }
            else if (cbInvCurr4.Text != "" && txtInvTotal4.Text != "" && cbInvCurr4_1.Text != "" && txtInvTotal4_1.Text != "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr4.Text, cbInvCurr4_1.Text);
                txtInvTotal4_1.Text = Math.Round(Convert.ToDouble(txtInvTotal4.Text) * rate, 2).ToString();
            }
            else if (cbInvCurr5.Text != "" && txtInvTotal5.Text != "" && cbInvCurr5.Text != "" && txtInvTotal5_1.Text != "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr5.Text, cbInvCurr5_1.Text);
                txtInvTotal5_1.Text = Math.Round(Convert.ToDouble(txtInvTotal5.Text) * rate, 2).ToString();
            }
            else
            { }
            #endregion

            if (cbDnCurr1.Enabled)
            {
                if (txtCustCurr.Text != "HKD")
                    txtDnTotal1.Text = DoFormat(SumUpTotal1().ToString());
            }
            else
            {
                if (txtCustCurr.Text == "HKD")
                    txtDnTotal2.Text = DoFormat(SumUpTotal2().ToString());
            }
        }

        private void AmountKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox textbox = (TextBox)sender;
                string tag = textbox.Tag.ToString().Trim();

                double rate = 0;

                try
                {
                    if (!cbRateMonth.Enabled)
                    {
                        cbRateMonth.Enabled = true;
                        cbRateMonth.SelectedIndex = 0;
                    }
                    string today = cbRateMonth.Enabled ? cbRateMonth.SelectedItem.ToString().Trim() : DateTime.Today.ToString("yyyy/MM");

                    if (tag == "foreign1")
                    {
                        if (cbInvCurr1_1.Text != "")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr1.Text, cbInvCurr1_1.Text);
                            txtInvTotal1_1.Text = Math.Round(Convert.ToDouble(txtInvTotal1.Text) * rate, 2).ToString();
                        }
                    }

                    if (tag == "foreign2")
                    {
                        if (cbInvCurr2_1.Text != "")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr2.Text, cbInvCurr2_1.Text);
                            txtInvTotal2_1.Text = Math.Round(Convert.ToDouble(txtInvTotal2.Text) * rate, 2).ToString();
                        }
                    }

                    if (tag == "foreign3")
                    {
                        if (cbInvCurr3_1.Text != "")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr3.Text, cbInvCurr3_1.Text);
                            txtInvTotal3_1.Text = Math.Round(Convert.ToDouble(txtInvTotal3.Text) * rate, 2).ToString();
                        }
                    }

                    if (tag == "foreign4")
                    {
                        if (cbInvCurr4_1.Text != "")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr4.Text, cbInvCurr4_1.Text);
                            txtInvTotal4_1.Text = Math.Round(Convert.ToDouble(txtInvTotal4.Text) * rate, 2).ToString();
                        }
                    }

                    if (tag == "foreign5")
                    {
                        if (cbInvCurr5_1.Text != "")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr5.Text, cbInvCurr5_1.Text);
                            txtInvTotal5_1.Text = Math.Round(Convert.ToDouble(txtInvTotal5.Text) * rate, 2).ToString();
                        }
                    }

                    if (tag == "local1")
                    {
                        if (cbInvCurr1.Text != "")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr1.Text, cbInvCurr1_1.Text);
                            txtInvTotal1.Text = Math.Round(Convert.ToDouble(txtInvTotal1_1.Text) / rate, 2).ToString();
                        }
                    }

                    if (tag == "local2")
                    {
                        if (cbInvCurr2.Text != "")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr2.Text, cbInvCurr2_1.Text);
                            txtInvTotal2.Text = Math.Round(Convert.ToDouble(txtInvTotal2_1.Text) / rate, 2).ToString();
                        }
                    }

                    if (tag == "local3")
                    {
                        if (cbInvCurr3.Text != "")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr3.Text, cbInvCurr3_1.Text);
                            txtInvTotal3.Text = Math.Round(Convert.ToDouble(txtInvTotal3_1.Text) / rate, 2).ToString();
                        }
                    }

                    if (tag == "local4")
                    {
                        if (cbInvCurr4.Text != "")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr4.Text, cbInvCurr4_1.Text);
                            txtInvTotal4.Text = Math.Round(Convert.ToDouble(txtInvTotal4_1.Text) / rate, 2).ToString();
                        }
                    }

                    if (tag == "local5")
                    {
                        if (cbInvCurr5.Text != "")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr5.Text, cbInvCurr5_1.Text);
                            txtInvTotal5.Text = Math.Round(Convert.ToDouble(txtInvTotal5_1.Text) / rate, 2).ToString();
                        }
                    }

                    try
                    {
                        if (cbDnCurr1.Enabled)
                            txtDnTotal1.Text = DoFormat(SumUpTotal1().ToString()).ToString();

                        if (cbDnCurr2.Enabled)
                            txtDnTotal2.Text = DoFormat(SumUpTotal2().ToString()).ToString();
                    }
                    catch
                    {
                        MessageBox.Show("Please input valid amount.");
                    }
                }
                catch
                {
                    MessageBox.Show("Please select target currency first.");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch(MessageBox.Show("Are you sure to save this form? A new application form will be generated.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:

                    if (ErrorList().Count > 0)
                    {
                        string msg = string.Join("\n", ErrorList().ToArray());

                        MessageBox.Show("Error found. Please review below items:\n" + msg);
                    }
                    else
                    {
                        string reqDate = dtpDate.Value.ToString("yyyy/MM/dd");
                        string reqOffice = txtReqOffice.Text.Trim();
                        string reqCostCentre = txtReqCostcentre.Text.Trim();

                        string custCode = txtCustCode.Text.Trim();
                        string custName = txtCustName.Text.Trim();
                        if (custName.Contains("'")) custName = custName.Replace("'", "''");
                        string custCurr = txtCustCurr.Text.Trim();
                        string payterm = txtPayTerm.Text.Trim();
                        string duedate = txtDueDate.Text.Trim();
                        string custDiv = txtCustDiv.Text.Trim();
                        if (custDiv.Contains("'")) custDiv = custDiv.Replace("'", "''");
                        string divName = txtDivname.Text.Trim();
                        if (divName.Contains("'")) divName = divName.Replace("'", "''");
                        string incharge = txtIncharge.Text.Trim();
                        if (incharge.Contains("'")) incharge = incharge.Replace("'", "''");

                        string reqItem = txtReqItem.Text.Trim();
                        if (reqItem.Contains("'")) reqItem = reqItem.Replace("'", "''");
                        string reason = txtReason.Text.Trim();
                        if (reason.Contains("'")) reason = reason.Replace("'", "''");
                        string manual = txtManual.Text.Trim();
                        if (manual.Contains("'")) manual = manual.Replace("'", "''");

                        string invNo = txtInvNo.Text.Trim();
                        string ringiNo = txtRingiNo.Text.Trim();

                        string rateMonth = cbRateMonth.Text.Trim();
                        string dnCurr1 = cbDnCurr1.Text.Trim();
                        string dnTotal1 = txtDnTotal1.Text.Trim();
                        string dnCurr2 = cbDnCurr2.Text.Trim();
                        string dnTotal2 = txtDnTotal2.Text.Trim();

                        string reason1 = txtTranReason1.Text.Trim();
                        if (reason1.Contains("'")) reason1 = reason1.Replace("'", "''");
                        string acCode1 = cbAc1.Text.Trim();
                        string ccCode1 = cbCostCentre1.Text.Trim();
                        string invCurr1 = cbInvCurr1.Text.Trim();
                        string invTotal1 = txtInvTotal1.Text.Trim();
                        string invCurr1_1 = cbInvCurr1_1.Text.Trim();
                        string invTotal1_1 = txtInvTotal1_1.Text.Trim();

                        string reason2 = txtTranReason2.Text.Trim();
                        if (reason2.Contains("'")) reason2 = reason2.Replace("'", "''");
                        string acCode2 = cbAc2.Text.Trim();
                        string ccCode2 = cbCostCentre2.Text.Trim();
                        string invCurr2 = cbInvCurr2.Text.Trim();
                        string invTotal2 = txtInvTotal2.Text.Trim();
                        string invCurr2_1 = cbInvCurr2_1.Text.Trim();
                        string invTotal2_1 = txtInvTotal2_1.Text.Trim();

                        string reason3 = txtTranReason3.Text.Trim();
                        if (reason3.Contains("'")) reason3 = reason3.Replace("'", "''");
                        string acCode3 = cbAc3.Text.Trim();
                        string ccCode3 = cbCostCentre3.Text.Trim();
                        string invCurr3 = cbInvCurr3.Text;
                        string invTotal3 = txtInvTotal3.Text.Trim();
                        string invCurr3_1 = cbInvCurr3_1.Text.Trim();
                        string invTotal3_1 = txtInvTotal3_1.Text.Trim();

                        string reason4 = txtTranReason4.Text.Trim();
                        if (reason4.Contains("'")) reason4 = reason4.Replace("'", "''");
                        string acCode4 = cbAc4.Text.Trim();
                        string ccCode4 = cbCostCentre4.Text.Trim();
                        string invCurr4 = cbInvCurr4.Text;
                        string invTotal4 = txtInvTotal4.Text.Trim();
                        string invCurr4_1 = cbInvCurr4_1.Text.Trim();
                        string invTotal4_1 = txtInvTotal4_1.Text.Trim();

                        string reason5 = txtTranReason5.Text.Trim();
                        if (reason5.Contains("'")) reason5 = reason5.Replace("'", "''");
                        string acCode5 = cbAc5.Text.Trim();
                        string ccCode5 = cbCostCentre5.Text.Trim();
                        string invCurr5 = cbInvCurr5.Text;
                        string invTotal5 = txtInvTotal5.Text.Trim();
                        string invCurr5_1 = cbInvCurr5_1.Text.Trim();
                        string invTotal5_1 = txtInvTotal5_1.Text.Trim();

                        string docNo = McUtil.GetNextDocNo();

                        string formType = _formType == "debit" ? "Debit" : "Credit";

                        string month = cbRateMonth.Enabled ? cbRateMonth.SelectedItem.ToString().Trim() : DateTime.Today.ToString("yyyy/MM");

                        string curr = custCurr == "HKD" ? dnCurr2 : dnCurr1;

                        string directory = @"C:\temp\debitnote";
                        if (!Directory.Exists(directory))
                            Directory.CreateDirectory(directory);

                        string filename = _formType == "debit" ? "DebitNote_" + DateTime.Now.ToString("yyyyMMddHHmm") + ".pdf" : "CreditNote_" + DateTime.Now.ToString("yyyyMMddHHmm") + ".pdf";

                        filename = directory + @"\" + filename;

                        string query = string.Format("insert into TB_CM_DEBIT (d_type, d_docno, d_reqdate, d_reqoffice, d_reqcostcentre, d_custcode, d_custname, d_custcurr" +
                            ", d_payterm, d_duedate, d_custdiv, d_divname, d_incharge, d_items, d_reason, d_custreason, d_invno, d_ringino, d_exmonth, d_exrate, d_dntotal1" +
                            ", d_dncurr, d_dntotal2, d_createdby, d_created, d_directory) values ('{0}', '{1}', '{2}', N'{3}', '{4}', '{5}', N'{6}', '{7}', '{8}', '{9}', N'{10}', N'{11}', N'{12}', N'{13}', N'{14}'" +
                            ", N'{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', N'{23}', '{24}', N'{25}')", formType, docNo, reqDate, reqOffice, reqCostCentre, custCode, custName, custCurr,
                            payterm, duedate, custDiv, divName, incharge, reqItem, reason, manual, invNo, ringiNo, rateMonth, _rate, dnTotal1, dnCurr1, dnTotal2, GlobalService.User, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), filename);

                        DataServiceCM.GetInstance().ExecuteNonQuery(query);

                        string docId = McUtil.GetId().ToString();

                        if (txtTranReason1.Text != "")
                        {
                            string text = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                                " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", docId, acCode1, ccCode1, invCurr1, invTotal1, invCurr1_1, invTotal1_1, reason1);
                            DataServiceCM.GetInstance().ExecuteNonQuery(text);
                        }

                        if (txtTranReason2.Text != "")
                        {
                            string text = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                                " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", docId, acCode2, ccCode2, invCurr2, invTotal2, invCurr2_1, invTotal2_1, reason2);
                            DataServiceCM.GetInstance().ExecuteNonQuery(text);
                        }

                        if (txtTranReason3.Text != "")
                        {
                            string text = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                                " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", docId, acCode3, ccCode3, invCurr3, invTotal3, invCurr3_1, invTotal3_1, reason3);
                            DataServiceCM.GetInstance().ExecuteNonQuery(text);
                        }

                        if (txtTranReason4.Text != "")
                        {
                            string text = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                                " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", docId, acCode4, ccCode4, invCurr4, invTotal4, invCurr4_1, invTotal4_1, reason4);
                            DataServiceCM.GetInstance().ExecuteNonQuery(text);
                        }

                        if (txtTranReason5.Text != "")
                        {
                            if (acCode5 != "" && ccCode5 != "")
                            {
                                string text = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                                    " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", docId, acCode5, ccCode5, invCurr5, invTotal5, invCurr5_1, invTotal5_1, reason5);
                                DataServiceCM.GetInstance().ExecuteNonQuery(text);
                            }
                        }

                        PdfUtil.ExportForm(filename, _formType, dtpDate.Value.ToString("yyyy/MM/dd"), txtReqOffice.Text, txtReqCostcentre.Text, txtCustCode.Text, txtCustName.Text,
                            txtCustCurr.Text, txtPayTerm.Text, txtDueDate.Text, txtCustDiv.Text, txtDivname.Text, txtIncharge.Text, txtReqItem.Text, txtReason.Text, txtManual.Text,
                            txtInvNo.Text, txtRingiNo.Text, cbRateMonth.Text, cbDnCurr1.Text, txtDnTotal1.Text, cbDnCurr2.Text, txtDnTotal2.Text, txtTranReason1.Text, cbAc1.Text,
                            cbCostCentre1.Text, cbInvCurr1.Text, txtInvTotal1.Text, cbInvCurr1_1.Text, txtInvTotal1_1.Text, txtTranReason2.Text, cbAc2.Text, cbCostCentre2.Text,
                            cbInvCurr2.Text, txtInvTotal2.Text, cbInvCurr2_1.Text, txtInvTotal2_1.Text, txtTranReason3.Text, cbAc3.Text, cbCostCentre3.Text, cbInvCurr3.Text,
                            txtInvTotal3.Text, cbInvCurr3_1.Text, txtInvTotal3_1.Text, txtTranReason4.Text, cbAc4.Text, cbCostCentre4.Text, cbInvCurr4.Text, txtInvTotal4.Text,
                            cbInvCurr4_1.Text, txtInvTotal4_1.Text, txtTranReason5.Text, cbAc5.Text, cbCostCentre5.Text, cbInvCurr5.Text, txtInvTotal5.Text, cbInvCurr5_1.Text, txtInvTotal5_1.Text);

                        //Process.Start(filename);

                        MessageBox.Show("Record has been saved.");
                        DialogResult = DialogResult.OK;
                    }

                    break;

                case DialogResult.No:
                    break;
            }
        }

        List<string> errorList = null;

        private List<string> ErrorList()
        {
            errorList = new List<string>();

            if (string.IsNullOrEmpty(txtReqOffice.Text.Trim())) errorList.Add("Office Name");

            if (string.IsNullOrEmpty(txtReqCostcentre.Text.Trim())) errorList.Add("Cost Centre");

            if (string.IsNullOrEmpty(txtCustCode.Text.Trim())) errorList.Add("Cust. Code");

            if (string.IsNullOrEmpty(txtCustName.Text.Trim())) errorList.Add("Cust. Name");

            if (string.IsNullOrEmpty(txtCustCurr.Text.Trim())) errorList.Add("Cust. Curr");

            if (string.IsNullOrEmpty(txtPayTerm.Text.Trim())) errorList.Add("Payterm");

            if (string.IsNullOrEmpty(txtDueDate.Text.Trim())) errorList.Add("Net Due Date");

            if (string.IsNullOrEmpty(txtTranReason1.Text.Trim())) errorList.Add("Transaction Reason");

            if (!string.IsNullOrEmpty(txtTranReason1.Text.Trim()))
            {
                if (string.IsNullOrEmpty(cbCostCentre1.Text.Trim())) errorList.Add("Transaction 1 : CostCentre");

                if (string.IsNullOrEmpty(txtInvTotal1.Text.Trim()) && string.IsNullOrEmpty(txtInvTotal1_1.Text.Trim())) errorList.Add("Transaction 1 : Inv Total Amount");
            }

            if (!string.IsNullOrEmpty(txtTranReason2.Text.Trim()))
            {
                if (string.IsNullOrEmpty(cbCostCentre2.Text.Trim())) errorList.Add("Transaction 2 : CostCentre");

                if (string.IsNullOrEmpty(txtInvTotal2.Text.Trim()) && string.IsNullOrEmpty(txtInvTotal2_1.Text.Trim())) errorList.Add("Transaction 2 : Inv Total Amount");
            }

            if (!string.IsNullOrEmpty(txtTranReason3.Text.Trim()))
            {
                if (string.IsNullOrEmpty(cbCostCentre3.Text.Trim())) errorList.Add("Transaction 3 : CostCentre");

                if (string.IsNullOrEmpty(txtInvTotal3.Text.Trim()) && string.IsNullOrEmpty(txtInvTotal3_1.Text.Trim())) errorList.Add("Transaction 3 : Inv Total Amount");
            }

            if (!string.IsNullOrEmpty(txtTranReason4.Text.Trim()))
            {
                if (string.IsNullOrEmpty(cbCostCentre4.Text.Trim())) errorList.Add("Transaction 4 : CostCentre");

                if (string.IsNullOrEmpty(txtInvTotal4.Text.Trim()) && string.IsNullOrEmpty(txtInvTotal4_1.Text.Trim())) errorList.Add("Transaction 4 : Inv Total Amount");
            }

            if (!string.IsNullOrEmpty(txtTranReason5.Text.Trim()))
            {
                if (string.IsNullOrEmpty(cbCostCentre5.Text.Trim())) errorList.Add("Transaction 5 : CostCentre");

                if (string.IsNullOrEmpty(txtInvTotal5.Text.Trim()) && string.IsNullOrEmpty(txtInvTotal5_1.Text.Trim())) errorList.Add("Transaction 5 : Inv Total Amount");
            }

            return errorList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string filename = @"C:\temp\test.pdf";

            PdfUtil.ExportForm(filename, _formType, dtpDate.Value.ToString("yyyy/MM/dd"), txtReqOffice.Text, txtReqCostcentre.Text, txtCustCode.Text, txtCustName.Text,
                txtCustCurr.Text, txtPayTerm.Text, txtDueDate.Text, txtCustDiv.Text, txtDivname.Text, txtIncharge.Text, txtReqItem.Text, txtReason.Text, txtManual.Text,
                txtInvNo.Text, txtRingiNo.Text, cbRateMonth.Text, cbDnCurr1.Text, txtDnTotal1.Text, cbDnCurr2.Text, txtDnTotal2.Text, txtTranReason1.Text, cbAc1.Text,
                cbCostCentre1.Text, cbInvCurr1.Text, txtInvTotal1.Text, cbInvCurr1_1.Text, txtInvTotal1_1.Text, txtTranReason2.Text, cbAc2.Text, cbCostCentre2.Text,
                cbInvCurr2.Text, txtInvTotal2.Text, cbInvCurr2_1.Text, txtInvTotal2_1.Text, txtTranReason3.Text, cbAc3.Text, cbCostCentre3.Text, cbInvCurr3.Text,
                txtInvTotal3.Text, cbInvCurr3_1.Text, txtInvTotal3_1.Text, txtTranReason4.Text, cbAc4.Text, cbCostCentre4.Text, cbInvCurr4.Text, txtInvTotal4.Text,
                cbInvCurr4_1.Text, txtInvTotal4_1.Text, txtTranReason5.Text, cbAc5.Text, cbCostCentre5.Text, cbInvCurr5.Text, txtInvTotal5.Text, cbInvCurr5_1.Text, txtInvTotal5_1.Text);

            Process.Start(filename);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Are you sure to delete this record?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:

                    string text = string.Format("select d_id from TB_CM_DEBIT where d_docno = '{0}'", _docId);
                    int id = (int)DataServiceCM.GetInstance().ExecuteScalar(text);

                    string delTransactionText = string.Format("delete from TB_CM_DEBIT_TRANSACTION where t_debitid = '{0}'", id);
                    DataServiceCM.GetInstance().ExecuteNonQuery(delTransactionText);

                    string query = string.Format("delete from TB_CM_DEBIT where d_id = '{0}'", id);
                    DataServiceCM.GetInstance().ExecuteNonQuery(query);

                    MessageBox.Show("Record has been deleted");

                    DialogResult = DialogResult.OK;
                    break;

                case DialogResult.No:
                    break;
            }
        }

        string selectedTextBox = "";

        private void TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            string tag = textbox.Tag.ToString().Trim();

            selectedTextBox = tag;
        }

        private void txtReqItem_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu contextMenu = new ContextMenu();
                MenuItem item = new MenuItem("Paste");
                item.Click += new EventHandler(item_Click);
                contextMenu.MenuItems.Add(item);

                txtReqItem.ContextMenu = contextMenu;
            }
        }

        void item_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
                txtReqItem.Text += Clipboard.GetText(TextDataFormat.Text).ToString();
        }

        private void UploadData()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "Excel 97-03 Files|*.xls";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = ImportExcel2003.TranslateToTable(ofd.FileName);

                List<UploadData> list = new List<UploadData>();

                foreach (DataRow row in table.Rows)
                {
                    string type = row.ItemArray[0].ToString().Trim();
                    string reqOffice = row.ItemArray[1].ToString().Trim();
                    string reqCostCentre = row.ItemArray[2].ToString().Trim();
                    string custCode = row.ItemArray[3].ToString().Trim();
                    string item = row.ItemArray[4].ToString().Trim();
                    string remarks = row.ItemArray[5].ToString().Trim();
                    string invNo = row.ItemArray[6].ToString().Trim();
                    string ringiNo = row.ItemArray[7].ToString().Trim();
                    
                    string r1 = row.ItemArray[8].ToString().Trim();
                    string ac1 = row.ItemArray[9].ToString().Trim();
                    string cc1 = row.ItemArray[10].ToString().Trim();
                    string cu1 = row.ItemArray[11].ToString().Trim();
                    string amt1 = row.ItemArray[12].ToString().Trim();

                    string r2 = row.ItemArray[13].ToString().Trim();
                    string ac2 = row.ItemArray[14].ToString().Trim();
                    string cc2 = row.ItemArray[15].ToString().Trim();
                    string cu2 = row.ItemArray[16].ToString().Trim();
                    string amt2 = row.ItemArray[17].ToString().Trim();

                    string r3 = row.ItemArray[18].ToString().Trim();
                    string ac3 = row.ItemArray[19].ToString().Trim();
                    string cc3 = row.ItemArray[20].ToString().Trim();
                    string cu3 = row.ItemArray[21].ToString().Trim();
                    string amt3 = row.ItemArray[22].ToString().Trim();

                    string r4 = row.ItemArray[23].ToString().Trim();
                    string ac4 = row.ItemArray[24].ToString().Trim();
                    string cc4 = row.ItemArray[25].ToString().Trim();
                    string cu4 = row.ItemArray[26].ToString().Trim();
                    string amt4 = row.ItemArray[27].ToString().Trim();

                    string r5 = row.ItemArray[28].ToString().Trim();
                    string ac5 = row.ItemArray[29].ToString().Trim();
                    string cc5 = row.ItemArray[30].ToString().Trim();
                    string cu5 = row.ItemArray[31].ToString().Trim();
                    string amt5 = row.ItemArray[32].ToString().Trim();

                    list.Add(new UploadData
                    {
                        Type = type,
                        ReqOffice = reqOffice,
                        ReqCostCentre = reqCostCentre,
                        CustCode = custCode,
                        Item = item,
                        Remarks = remarks,
                        InvNo = invNo,
                        RingiNo = ringiNo,
                        Reason1 = r1,
                        AccCode1 = ac1,
                        CostCentre1 = cc1,
                        Curr1 = cu1,
                        Amount1 = amt1,
                        Reason2 = r2,
                        AccCode2 = ac2,
                        CostCentre2 = cc2,
                        Curr2 = cu2,
                        Amount2 = amt2,
                        Reason3 = r3,
                        AccCode3 = ac3,
                        CostCentre3 = cc3,
                        Curr3 = cu3,
                        Amount3 = amt3,
                        Reason4 = r4,
                        AccCode4 = ac4,
                        CostCentre4 = cc4,
                        Curr4 = cu4,
                        Amount4 = amt4,
                        Reason5 = r5,
                        AccCode5 = ac5,
                        CostCentre5 = cc5,
                        Curr5 = cu5,
                        Amount5 = amt5
                    });
                }

                foreach (UploadData data in list)
                {
                    string name = "", curr = "", payterm = "", duedate = "", currDesc = "", currType = "";
                    string text = string.Format("select cust_name, cust_curr, cust_payterm, cust_currType, cust_currDesc from TB_CM_MASTER_CUSTOMER where cust_code = '{0}'", data.CustCode);
                    using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(text))
                    {
                        while (reader.Read())
                        {
                            name = reader.GetString(0).Trim();
                            curr = reader.GetString(1).Trim();
                            payterm = reader.GetString(2).Trim();
                            currType = reader.GetString(3).Trim();
                            currDesc = reader.GetString(4).Trim();
                        }
                    }

                    DateTime date = DateTime.Today;

                    duedate = payterm == "HK01" ? new DateTime(date.Year, date.Month, 1).AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd")
                        : payterm == "HK02" ? new DateTime(date.Year, date.Month, 1).AddMonths(3).AddDays(-1).ToString("yyyy/MM/dd")
                        : payterm == "HK03" ? new DateTime(date.Year, date.Month, 1).AddMonths(3).AddDays(9).ToString("yyyy/MM/dd")
                        : payterm == "HK06" ? new DateTime(date.Year, date.Month, 1).AddMonths(2).AddDays(14).ToString("yyyy/MM/dd")
                        : payterm == "HK07" ? new DateTime(date.Year, date.Month, 1).AddMonths(2).AddDays(9).ToString("yyyy/MM/dd")
                        : payterm == "HK08" ? date.AddDays(7).ToString("yyyy/MM/dd")
                        : payterm == "HK09" ? date.AddDays(30).ToString("yyyy/MM/dd")
                        : payterm == "HK51" ? new DateTime(date.Year, date.Month, 1).AddMonths(2).AddDays(24).ToString("yyyy/MM/dd")
                        : payterm == "HK52" ? new DateTime(date.Year, date.Month, 1).AddMonths(3).AddDays(-1).ToString("yyyy/MM/dd")
                        : payterm == "HK53" ? new DateTime(date.Year, date.Month, 1).AddMonths(2).AddDays(-1).ToString("yyyy/MM/dd") : "";

                    string docNo = McUtil.GetNextDocNo();

                    List<string> reasonList = new List<string>();
                    reasonList.Add(data.Reason1);
                    if (data.Reason2 != "") reasonList.Add(data.Reason2);
                    if (data.Reason3 != "") reasonList.Add(data.Reason3);
                    if (data.Reason4 != "") reasonList.Add(data.Reason4);
                    if (data.Reason5 != "") reasonList.Add(data.Reason5);

                    string reason = reasonList.Count > 1 ? string.Join("&", reasonList.ToArray()) : data.Reason1;

                    double rate = GetRate(currType, currDesc, DateTime.Today.ToString("yyyy/MM"));

                    string directory = @"C:\temp\debitnote";
                    if (!Directory.Exists(directory))
                        Directory.CreateDirectory(directory);

                    string filename = _formType == "credit" ? "CreditNote_CN_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf" : "DebitNote_CN_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf";

                    filename = directory + @"\" + filename;

                    if (name.Contains("'")) name = name.Replace("'", "''");
                    if (reason.Contains("'")) reason = reason.Replace("'", "''");
                    if (data.InvNo.Contains("'")) data.InvNo = data.InvNo.Replace("'", "''");

                    if (data.Amount1 == "") data.Amount1 = "0";
                    if (data.Amount2 == "") data.Amount2 = "0";
                    if (data.Amount3 == "") data.Amount3 = "0";
                    if (data.Amount4 == "") data.Amount4 = "0";
                    if (data.Amount5 == "") data.Amount5 = "0";

                    double total = Convert.ToDouble(data.Amount1) + Convert.ToDouble(data.Amount2) + Convert.ToDouble(data.Amount3) + Convert.ToDouble(data.Amount4) + Convert.ToDouble(data.Amount5);

                    string vendorText = string.Format("select cust_name, cust_curr, cust_payterm from TB_CM_MASTER_CUSTOMER where cust_code = '{0}'", data.CustCode);

                    string custName = "", custCurr = "", custPayterm = "";

                    using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(vendorText))
                    {
                        while (reader.Read())
                        {
                            custName = reader.GetString(0).Trim();
                            custCurr = reader.GetString(1).Trim();
                            custPayterm = reader.GetString(2).Trim();
                        }
                    }

                    if (custName.Contains("'")) custName.Replace("'", "''");

                    string query = string.Format("insert into TB_CM_DEBIT (d_type, d_status, d_docno, d_reqdate, d_reqoffice, d_reqcostcentre, d_custcode, d_custname, d_custcurr, d_payterm" +
                        ", d_duedate, d_custdiv, d_divname, d_incharge, d_items, d_reason, d_invno, d_ringino, d_exmonth, d_exrate, d_dntotal1, d_createdby, d_created, d_directory, d_custname"+
                        ", d_custcurr, d_payterm) values " +
                        " ('{0}', '{1}', '{2}', '{3}', N'{4}', '{5}', '{6}', N'{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', N'{14}', N'{15}', '{16}', '{17}', '{18}', '{19}', '{20}', N'{21}', '{22}', N'{23}', N'{24}', '{25}', '{26}')", data.Type, "已輸入",
                        docNo, date, data.ReqOffice, data.ReqCostCentre, data.CustCode, name, curr, payterm, duedate, "", "", "", data.Item, reason, data.InvNo, data.RingiNo, DateTime.Today.ToString("yyyy/MM"),
                        rate, total, GlobalService.User, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), filename, custName, custCurr, custPayterm);

                    DataServiceCM.GetInstance().ExecuteNonQuery(query);

                    string docText = string.Format("select d_id from TB_CM_DEBIT where d_docno = '{0}'", docNo);
                    int id = (int)DataServiceCM.GetInstance().ExecuteScalar(docText);

                    if (data.Reason1 != "")
                    {
                        string ct = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                            " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", id, data.AccCode1, data.CostCentre1, data.Curr1, data.Amount1, "", "", data.Reason1);
                        DataServiceCM.GetInstance().ExecuteNonQuery(ct);
                    }

                    if (txtTranReason2.Text != "")
                    {
                        string ct = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                            " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", id, data.AccCode2, data.CostCentre2, data.Curr2, data.Amount2, "", "", data.Reason2);
                        DataServiceCM.GetInstance().ExecuteNonQuery(ct);
                    }

                    if (txtTranReason3.Text != "")
                    {
                        string ct = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                            " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", id, data.AccCode3, data.CostCentre3, data.Curr3, data.Amount3, "", "", data.Reason3);
                        DataServiceCM.GetInstance().ExecuteNonQuery(ct);
                    }

                    if (txtTranReason4.Text != "")
                    {
                        string ct = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                            " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", id, data.AccCode4, data.CostCentre4, data.Curr4, data.Amount4, "", "", data.Reason4);
                        DataServiceCM.GetInstance().ExecuteNonQuery(ct);
                    }

                    if (txtTranReason5.Text != "")
                    {
                        string ct = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                            " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", id, data.AccCode5, data.CostCentre5, data.Curr5, data.Amount5, "", "", data.Reason5);
                        DataServiceCM.GetInstance().ExecuteNonQuery(ct);
                    }

                    PdfUtil.ExportForm(filename, _formType, dtpDate.Value.ToString("yyyy/MM/dd"), txtReqOffice.Text, txtReqCostcentre.Text, txtCustCode.Text, txtCustName.Text,
                        txtCustCurr.Text, txtPayTerm.Text, txtDueDate.Text, txtCustDiv.Text, txtDivname.Text, txtIncharge.Text, txtReqItem.Text, txtReason.Text, txtManual.Text,
                        txtInvNo.Text, txtRingiNo.Text, cbRateMonth.Text, cbDnCurr1.Text, txtDnTotal1.Text, cbDnCurr2.Text, txtDnTotal2.Text, txtTranReason1.Text, cbAc1.Text,
                        cbCostCentre1.Text, cbInvCurr1.Text, txtInvTotal1.Text, cbInvCurr1_1.Text, txtInvTotal1_1.Text, txtTranReason2.Text, cbAc2.Text, cbCostCentre2.Text,
                        cbInvCurr2.Text, txtInvTotal2.Text, cbInvCurr2_1.Text, txtInvTotal2_1.Text, txtTranReason3.Text, cbAc3.Text, cbCostCentre3.Text, cbInvCurr3.Text,
                        txtInvTotal3.Text, cbInvCurr3_1.Text, txtInvTotal3_1.Text, txtTranReason4.Text, cbAc4.Text, cbCostCentre4.Text, cbInvCurr4.Text, txtInvTotal4.Text,
                        cbInvCurr4_1.Text, txtInvTotal4_1.Text, txtTranReason5.Text, cbAc5.Text, cbCostCentre5.Text, cbInvCurr5.Text, txtInvTotal5.Text, cbInvCurr5_1.Text, txtInvTotal5_1.Text);
                }

                MessageBox.Show("Record has been uploaded.");
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            UploadData();
        }
    }

    public class TransactionData
    {
        public string Reason { get; set; }
        public string AccountCode { get; set; }
        public string CostCentre { get; set; }
        public string InvCurr1 { get; set; }
        public string InvTotal1 { get; set; }
        public string InvCurr2 { get; set; }
        public string InvTotal2 { get; set; }
    }

    public class UploadData
    {
        public string Type { get; set; }
        public string ReqOffice { get; set; }
        public string ReqCostCentre { get; set; }
        public string CustCode { get; set; }
        public string Item { get; set; }
        public string Remarks { get; set; }
        public string InvNo { get; set; }
        public string RingiNo { get; set; }
        public string Reason1 { get; set; }
        public string AccCode1 { get; set; }
        public string CostCentre1 { get; set; }
        public string Curr1 { get; set; }
        public string Amount1 { get; set; }
        public string Reason2 { get; set; }
        public string AccCode2 { get; set; }
        public string CostCentre2 { get; set; }
        public string Curr2 { get; set; }
        public string Amount2 { get; set; }
        public string Reason3 { get; set; }
        public string AccCode3 { get; set; }
        public string CostCentre3 { get; set; }
        public string Curr3 { get; set; }
        public string Amount3 { get; set; }
        public string Reason4 { get; set; }
        public string AccCode4 { get; set; }
        public string CostCentre4 { get; set; }
        public string Curr4 { get; set; }
        public string Amount4 { get; set; }
        public string Reason5 { get; set; }
        public string AccCode5 { get; set; }
        public string CostCentre5 { get; set; }
        public string Curr5 { get; set; }
        public string Amount5 { get; set; }
    }
}
