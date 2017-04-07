using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using KDTHK_DM_SP.utils;
using CustomUtil.utils.authentication;
using KDTHK_DM_SP.eforms.cm.subforms;
using System.Diagnostics;
using System.IO;

namespace KDTHK_DM_SP.eforms.cm
{
    public partial class DebitNoteForm : Form
    {
        double _rate = 0;
        string _selectedTextBox = "";
        string _formType = "";
         
        List<string> reasonList;

        public DebitNoteForm(string type)
        {
            InitializeComponent();

            CmsService.AttachmentList = new List<services.Attachment>();

            _formType = type;

            //GlobalService.User = AdUtil.getUsername("kmhk.local");

            Application.Idle += new EventHandler(Application_Idle);

            reasonList = new List<string>();

            LoadAccountCode();

            LoadCostCentre();

            LoadRateMonth();

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

            this.Text = _formType == "debit" ? "Debit Note Application Form" : "Credit Note Application Form";

            lblTitle.Text = _formType == "debit" ? "Debit Note Application Form" : "Credit Note Application Form";

        }

        void Application_Idle(object sender, EventArgs e)
        {
            if (!txtCustName.Text.ToLower().Contains("kyocera"))
            {
                txtCustDiv.Text = "-";
                txtCustDiv.Enabled = false;

                cbDivname.Text = "-";
                cbDivname.Enabled = false;

                cbIncharge.Text = "-";
                cbIncharge.Enabled = false;
            }
            else
            {
                txtCustDiv.Enabled = true;
                cbDivname.Enabled = true;
                cbIncharge.Enabled = true;
            }

            if (txtCustCurr.Text != "")
            {
                if (txtCustCurr.Text == "HKD")
                {
                    cbDnCurr1.Enabled = false;
                    cbDnCurr2.Enabled = true;
                }
                else
                {
                    cbDnCurr1.Enabled = true;
                    cbDnCurr2.Enabled = false;
                }
            }
           // this.Refresh();
        }

        private string DoFormat(string text)
        {
            var s = string.Format("{0:0.00}", Convert.ToDouble(text));

            s = StringUtil.Calculation(s, 50);

            return s;
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void TextBoxChanged(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            string tag = textbox.Tag.ToString().Trim();
            if (tag == "custcode") txtCustCode.BackColor = Color.White;
            else if (tag == "custcurr") txtCustCurr.BackColor = Color.White;
            else if (tag == "payterm") txtPayTerm.BackColor = Color.White;
            else if (tag == "duedate") txtDueDate.BackColor = Color.White;
            else return;
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
                catch (Exception ex)
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
                catch (Exception ex)
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
                    : payterm == "HK03" ? new DateTime(date.Year, date.Month, 1).AddMonths(3).AddDays(10).ToString("yyyy/MM/dd")
                    : payterm == "HK06" ? new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(15).ToString("yyyy/MM/dd")
                    : payterm == "HK07" ? new DateTime(date.Year, date.Month, 1).AddMonths(2).AddDays(10).ToString("yyyy/MM/dd")
                    : payterm == "HK08" ? date.AddDays(7).ToString("yyyy/MM/dd")
                    : payterm == "HK09" ? date.AddDays(30).ToString("yyyy/MM/dd") : "";

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

                txtCustCode.BackColor = Color.WhiteSmoke;
                txtCustCurr.BackColor = Color.WhiteSmoke; ;
                txtPayTerm.BackColor = Color.WhiteSmoke; ;
                txtDueDate.BackColor = Color.WhiteSmoke; ;

                _rate = GetRate(CmsService.CurrencyType, CmsService.CurrencyDesc, DateTime.Today.ToString("yyyy/MM"));
            }
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
                : division == "行政科" ? "23100 Administration"
                : division == "採購管理科" ? "13400 Management Div"
                : division == "事業推進科" ? "23700 Corporate Deve"
                : division == "人力資源科" ? "23400 Personnel Div"
                : division == "會計科" ? "22100 Accounting Div"
                : division == "經營管理科" ? "22200 Mana. Con. Div"
                : division == "物流管理科" ? "31120 Logistics Sect" : "";

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

        private void RateButtonClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tag = btn.Tag.ToString().Trim();

            if (!cbRateMonth.Enabled)
            {
                cbRateMonth.Enabled = true;
                cbRateMonth.SelectedIndex = 0;
            }
            else
            {
                if (tag == "rate1")
                {
                    double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr1.Text, cbInvCurr1_1.Text);

                    if (cbInvCurr1.Text != "" && cbInvCurr1_1.Text != "" && txtInvTotal1.Text != "" && txtInvTotal1_1.Text == "")
                        txtInvTotal1_1.Text = Math.Round(Convert.ToDouble(txtInvTotal1.Text) * rate, 2).ToString();
                    else if (cbInvCurr1.Text != "" && cbInvCurr1_1.Text != "" && txtInvTotal1_1.Text != "" && txtInvTotal1.Text == "")
                        txtInvTotal1.Text = Math.Round(Convert.ToDouble(txtInvTotal1_1.Text) / rate, 2).ToString();
                    else if (cbInvCurr1.Text != "" && cbInvCurr1_1.Text != "" && txtInvTotal1.Text != "" && txtInvTotal1_1.Text != "")
                        txtInvTotal1_1.Text = Math.Round(Convert.ToDouble(txtInvTotal1.Text) * rate, 2).ToString();
                    else { }
                }

                if (tag == "rate2")
                {
                    double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr2.Text, cbInvCurr2_1.Text);

                    if (cbInvCurr2.Text != "" && cbInvCurr2_1.Text != "" && txtInvTotal2.Text != "" && txtInvTotal2_1.Text == "")
                        txtInvTotal2_1.Text = Math.Round(Convert.ToDouble(txtInvTotal2.Text) * rate, 2).ToString();
                    else if (cbInvCurr2.Text != "" && cbInvCurr2_1.Text != "" && txtInvTotal2_1.Text != "" && txtInvTotal2.Text == "")
                        txtInvTotal2.Text = Math.Round(Convert.ToDouble(txtInvTotal2_1.Text) / rate, 2).ToString();
                    else if (cbInvCurr2.Text != "" && cbInvCurr2_1.Text != "" && txtInvTotal2.Text != "" && txtInvTotal2_1.Text == "")
                        txtInvTotal2_1.Text = Math.Round(Convert.ToDouble(txtInvTotal2.Text) * rate, 2).ToString();
                    else { }
                }

                if (tag == "rate3")
                {
                    double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr3.Text, cbInvCurr3_1.Text);

                    if (cbInvCurr3.Text != "" && cbInvCurr3_1.Text != "" && txtInvTotal3.Text != "" && txtInvTotal3_1.Text == "")
                        txtInvTotal3_1.Text = Math.Round(Convert.ToDouble(txtInvTotal3.Text) * rate, 2).ToString();
                    else if (cbInvCurr3.Text != "" && cbInvCurr3_1.Text != "" && txtInvTotal3_1.Text != "" && txtInvTotal3.Text == "")
                        txtInvTotal3.Text = Math.Round(Convert.ToDouble(txtInvTotal3_1.Text) / rate, 2).ToString();
                    else if (cbInvCurr3.Text != "" && cbInvCurr3_1.Text != "" && txtInvTotal3.Text != "" && txtInvTotal3_1.Text != "")
                        txtInvTotal3_1.Text = Math.Round(Convert.ToDouble(txtInvTotal3.Text) * rate, 2).ToString();
                    else { }
                }

                if (tag == "rate4")
                {
                    double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr4.Text, cbInvCurr4_1.Text);

                    if (cbInvCurr4.Text != "" && cbInvCurr4_1.Text != "" && txtInvTotal4.Text != "" && txtInvTotal4_1.Text == "")
                        txtInvTotal4_1.Text = Math.Round(Convert.ToDouble(txtInvTotal4.Text) * rate, 2).ToString();
                    else if (cbInvCurr4.Text != "" && cbInvCurr4_1.Text != "" && txtInvTotal4_1.Text != "" && txtInvTotal4.Text == "")
                        txtInvTotal4.Text = Math.Round(Convert.ToDouble(txtInvTotal4_1.Text) / rate, 2).ToString();
                    else if (cbInvCurr4.Text != "" && cbInvCurr4_1.Text != "" && txtInvTotal4.Text != "" && txtInvTotal4_1.Text != "")
                        txtInvTotal4_1.Text = Math.Round(Convert.ToDouble(txtInvTotal4.Text) * rate, 2).ToString();
                    else { }
                }

                if (tag == "rate5")
                {
                    double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr5.Text, cbInvCurr5_1.Text);

                    if (cbInvCurr5.Text != "" && cbInvCurr5_1.Text != "" && txtInvTotal5.Text != "" && txtInvTotal5_1.Text != "")
                        txtInvTotal5_1.Text = Math.Round(Convert.ToDouble(txtInvTotal5.Text) * rate, 2).ToString();
                    else if (cbInvCurr5.Text != "" && cbInvCurr5_1.Text != "" && txtInvTotal5_1.Text != "" && txtInvTotal5.Text == "")
                        txtInvTotal5.Text = Math.Round(Convert.ToDouble(txtInvTotal5_1.Text) / rate, 2).ToString();
                    else if (cbInvCurr5.Text != "" && cbInvCurr5_1.Text != "" && txtInvTotal5.Text != "" && txtInvTotal5_1.Text != "")
                        txtInvTotal5_1.Text = Math.Round(Convert.ToDouble(txtInvTotal5.Text) * rate, 2).ToString();
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
        }

        private void cbRateMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region
            if (cbInvCurr1.Text != "" && txtInvTotal1.Text != "" && cbInvCurr1_1.Text != "" && txtInvTotal1_1.Text == "")
            {
                double rate = GetCurrencyRate(CmsService.CurrencyDesc, cbRateMonth.SelectedItem.ToString().Trim(), cbInvCurr1.Text, cbInvCurr1_1.Text);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool isDataOK = true;

            #region Input Variables
            string reqDate = dtpDate.Value.ToString("yyyy/MM/dd");
            string reqOffice = txtReqOffice.Text.Trim();
            string reqCostCentre = txtReqCostcentre.Text.Trim();

            string custCode = txtCustCode.Text.Trim();
            string custName = txtCustName.Text.Trim();
            string custCurr = txtCustCurr.Text.Trim();
            string payTerm = txtPayTerm.Text.Trim();
            string dueDate = txtDueDate.Text.Trim();
            string divCode = txtCustDiv.Text.Trim();//txtCustDiv.Text.Trim();
            string divName = cbDivname.Text;//txtDivName.Text.Trim();
            string inCharge = cbIncharge.Text;//txtIncharge.Text.Trim();

            string reason = txtReason.Text.Trim();
            string invNo = txtInvNo.Text.Trim();
            string ringiNo = txtRingiNo.Text.Trim();

            //string exRateMonth = txtExMonth.Text.Trim();
            string exRate = txtExRate.Text.Trim();
            string dnCurr1 = cbDnCurr1.Text.Trim();
            string dnTotal1 = txtDnTotal1.Text.Trim();
            string dnCurr2 = cbDnCurr2.Text.Trim();
            string dnTotal2 = txtDnTotal2.Text.Trim();

            string reason1 = txtTranReason1.Text.Trim();
            string acCode1 = cbAc1.Text.Trim();
            string ccCode1 = cbCostCentre1.Text.Trim();
            string invCurr1 = cbInvCurr1.Text.Trim();
            string invTotal1 = txtInvTotal1.Text.Trim();
            string invCurr1_1 = cbInvCurr1_1.Text.Trim();
            string invTotal1_1 = txtInvTotal1_1.Text.Trim();

            string reason2 = txtTranReason2.Text.Trim();
            string acCode2 = cbAc2.Text.Trim();
            string ccCode2 = cbCostCentre2.Text.Trim();
            string invCurr2 = cbInvCurr2.Text.Trim();
            string invTotal2 = txtInvTotal2.Text.Trim();
            string invCurr2_1 = cbInvCurr2_1.Text.Trim();
            string invTotal2_1 = txtInvTotal2_1.Text.Trim();

            string reason3 = txtTranReason3.Text.Trim();
            string acCode3 = cbAc3.Text.Trim();
            string ccCode3 = cbCostCentre3.Text.Trim();
            string invCurr3 = cbInvCurr3.Text;
            string invTotal3 = txtInvTotal3.Text.Trim();
            string invCurr3_1 = cbInvCurr3_1.Text.Trim();
            string invTotal3_1 = txtInvTotal3_1.Text.Trim();

            string reason4 = txtTranReason4.Text.Trim();
            string acCode4 = cbAc4.Text.Trim();
            string ccCode4 = cbCostCentre4.Text.Trim();
            string invCurr4 = cbInvCurr4.Text;
            string invTotal4 = txtInvTotal4.Text.Trim();
            string invCurr4_1 = cbInvCurr4_1.Text.Trim();
            string invTotal4_1 = txtInvTotal4_1.Text.Trim();

            string reason5 = txtTranReason5.Text.Trim();
            string acCode5 = cbAc5.Text.Trim();
            string ccCode5 = cbCostCentre5.Text.Trim();
            string invCurr5 = cbInvCurr5.Text;
            string invTotal5 = txtInvTotal5.Text.Trim();
            string invCurr5_1 = cbInvCurr5_1.Text.Trim();
            string invTotal5_1 = txtInvTotal5_1.Text.Trim();

            if (txtReason.Text == "") isDataOK = false;
            #endregion

            if (!isDataOK)
            {
                MessageBox.Show("Error found. Please check your data again.");
                return;
            }

            string sectHead = UserUtil.GetSectionHead(UserUtil.GetSect(GlobalService.User));
            string divHead = UserUtil.GetDivisionHead(UserUtil.GetDivision(GlobalService.User));
            string deptHead = UserUtil.GetDepartmentHead(UserUtil.GetDept(GlobalService.User));

            string mcStaff = "Yeung Shing Yee(楊成意,Joey)";
            string mcReview = "Lei Kin Fong(李健芳,Rebecca)";
            string mcFinal = "Lai King Ho(黎景豪,Ken)";

            string docNo = McUtil.GetNextDocNo();
            
            string formType = _formType == "debit" ? "Debit" : "Credit";

            string month = cbRateMonth.Enabled ? cbRateMonth.SelectedItem.ToString().Trim() : DateTime.Today.ToString("yyyy/MM");

            string curr = custCurr == "HKD" ? dnCurr2 : dnCurr1;
            string query = string.Format("insert into TB_CM_DEBIT (d_status, d_docno, d_reqdate, d_reqoffice, d_reqcostcentre, d_custcode, d_custname" +
                ", d_custcurr, d_payterm, d_duedate, d_custdiv, d_divname, d_incharge, d_reason, d_invno, d_ringino, d_exmonth, d_exrate, d_dntotal1" +
                ", d_dncurr, d_dntotal2, d_pdf, d_deduct, d_createdby, d_created, d_sect, d_div, d_dept, d_mcstaff, d_mcreviewer, d_mcfinal, d_type, d_custreason) values " +
                "(N'{0}', '{1}', '{2}', N'{3}', '{4}', '{5}', N'{6}', '{7}', '{8}', '{9}', '{10}', N'{11}', N'{12}', N'{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}'" +
                ", '{21}', '{22}', N'{23}', '{24}', N'{25}', N'{26}', N'{27}', N'{28}', N'{29}', N'{30}', '{31}', N'{32}')", "係責承認中", docNo, reqDate, reqOffice, reqCostCentre,
                custCode, custName, custCurr, payTerm, dueDate, divCode, divName, inCharge, reason, invNo, ringiNo, month, _rate, dnTotal1,
                curr, dnTotal2, "No", "No", GlobalService.User, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), sectHead, divHead, deptHead, mcStaff, mcReview, mcFinal, formType, txtManual.Text.Trim());

            //Debug.WriteLine("Query: " + query);

            DataServiceCM.GetInstance().ExecuteNonQuery(query);

            string docId = McUtil.GetId().ToString();

            if (acCode1 != "" && ccCode1 != "")
            {
                string text = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                    " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", docId, acCode1, ccCode1, invCurr1, invTotal1, invCurr1_1, invTotal1_1, reason1);
                DataServiceCM.GetInstance().ExecuteNonQuery(text);
            }

            if (acCode2 != "" && ccCode2 != "")
            {
                string text = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                    " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", docId, acCode2, ccCode2, invCurr2, invTotal2, invCurr2_1, invTotal2_1, reason2);
                DataServiceCM.GetInstance().ExecuteNonQuery(text);
            }

            if (acCode3 != "" && ccCode3 != "")
            {
                string text = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                    " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", docId, acCode3, ccCode3, invCurr3, invTotal3, invCurr3_1, invTotal3_1, reason3);
                DataServiceCM.GetInstance().ExecuteNonQuery(text);
            }

            if (acCode4 != "" && ccCode4 != "")
            {
                string text = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                    " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", docId, acCode4, ccCode4, invCurr4, invTotal4, invCurr4_1, invTotal4_1, reason4);
                DataServiceCM.GetInstance().ExecuteNonQuery(text);
            }

            if (acCode5 != "" && ccCode5 != "")
            {
                string text = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                    " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", docId, acCode5, ccCode5, invCurr5, invTotal5, invCurr5_1, invTotal5_1, reason5);
                DataServiceCM.GetInstance().ExecuteNonQuery(text);
            }

            foreach (services.Attachment item in CmsService.AttachmentList)
            {
                string targetDirectory = @"\\kdthk-dm1\project\IT System\cms\cm\attachments\" + DateTime.Today.ToString("yyyyMMdd");
                if (!Directory.Exists(targetDirectory))
                    Directory.CreateDirectory(targetDirectory);

                targetDirectory = targetDirectory + @"\" + item.Filename;

                File.Copy(item.Filepath, targetDirectory, true);

                string text = string.Format("insert into TB_CM_DEBIT_ATTACHMENT (a_debitid, a_attachment, a_name) values ('{0}', N'{1}', N'{2}')", docId, item.Filepath, item.Filename);
                DataServiceCM.GetInstance().ExecuteNonQuery(text);
            }

            EformUtil.SendApprovalEmail(docNo, GlobalService.User, AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local"), AdUtil.GetEmailByUsername(sectHead, "kmhk.local"), "", "Debit/Credit Note Application Approval Required");

            DialogResult = DialogResult.OK;
        }

        private void btnAttachment_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string item in ofd.FileNames)
                {
                    string filename = Path.GetFileName(item);
                    CmsService.AttachmentList.Add(new services.Attachment { Filename = filename, Filepath = item });
                }

                //foreach (services.Attachment item in CmsService.AttachmentList)
                   // lbAttachment.Items.Add(item.Filename);
            }
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

        string _input = "";
        bool isEmail = false; bool isVendorInvoice = false; bool isOutstanding = false; bool IsRevise = false; bool IsRingi = false;
        bool isDisposal = false; bool isInvoice = false; bool isDelivery = false; bool isKdc = false; bool isPo = false; bool isRequest = false;

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            foreach (string reason in reasonList)
            {
                string query = string.Format("select top 1 d_email, d_vendorinvoice, d_outstanding, d_revise, d_ringi, d_disposal, d_invoice, d_deliverynote, d_kdc, d_po, d_request from TB_CM_MASTER_DESCRIPTION where d_r3 = '{0}'", reason.ToUpper());
                using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        string email = reader.GetString(0).Trim();
                        string vendorinvoice = reader.GetString(1).Trim();
                        string outstanding = reader.GetString(2).Trim();
                        string revise = reader.GetString(3).Trim();
                        string ringi = reader.GetString(4).Trim();
                        string disposal = reader.GetString(5).Trim();
                        string invoice = reader.GetString(6).Trim();
                        string delivery = reader.GetString(7).Trim();
                        string kdc = reader.GetString(8).Trim();
                        string po = reader.GetString(9).Trim();
                        string request = reader.GetString(10).Trim();

                        if (email == "x") isEmail = true;
                        if (vendorinvoice == "x") isVendorInvoice = true;
                        if (outstanding == "x") isOutstanding = true;
                        if (revise == "x") IsRevise = true;
                        if (ringi == "x") IsRingi = true;
                        if (disposal == "x") isDisposal = true;
                        if (invoice == "x") isInvoice = true;
                        if (delivery == "x") isDelivery = true;
                        if (kdc == "x") isKdc = true;
                        if (po == "x") isPo = true;
                        if (request == "x") isRequest = true;
                    }
                }
            }

            this.Refresh();
        }

        private void DebitNoteForm_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ComboBoxKeyDown(object sender, KeyEventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            string tag = cmb.Tag.ToString().Trim();

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

            string query = string.Format("select cu_currency from TB_CM_MASTER_CURRENCY where cu_type = '{0}' and cu_description = N'{1}' and cu_month = '{2}'", ctype, desc, month);
            Debug.WriteLine("Query: " + query);

            var result = DataServiceCM.GetInstance().ExecuteScalar(query);

            return Convert.ToDouble(result);
        }

        private double GetRate(string type, string desc, string month)
        {
            string query = string.Format("select cu_currency from TB_CM_MASTER_CURRENCY where cu_type = '{0}' and cu_description = N'{1}' and cu_month = '{2}'", type, desc, month);

            var result = DataServiceCM.GetInstance().ExecuteScalar(query);

            return Convert.ToDouble(result);
        }

        private void AmountKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                TextBox textbox = (TextBox)sender;
                string tag = textbox.Tag.ToString().Trim();

                double rate = 0;// GetRate(CmsService.CurrencyType, CmsService.CurrencyDesc, DateTime.Today.ToString("yyyy/MM"));

                try
                {
                    if (!cbRateMonth.Enabled)
                    {
                        cbRateMonth.Enabled = true;
                        cbRateMonth.SelectedIndex = 0;
                    }
                    else
                    {
                        string today = DateTime.Today.ToString("yyyy/MM");

                        if (tag == "foreign1")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr1.Text, cbInvCurr1_1.Text);
                            txtInvTotal1_1.Text = Math.Round(Convert.ToDouble(txtInvTotal1.Text) * rate, 2).ToString();
                        }

                        if (tag == "foreign2")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr2.Text, cbInvCurr2_1.Text);
                            txtInvTotal2_1.Text = Math.Round(Convert.ToDouble(txtInvTotal2.Text) * rate, 2).ToString();
                        }

                        if (tag == "foreign3")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr3.Text, cbInvCurr3_1.Text);
                            txtInvTotal3_1.Text = Math.Round(Convert.ToDouble(txtInvTotal3.Text) * rate, 2).ToString();
                        }

                        if (tag == "foreign4")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr4.Text, cbInvCurr4_1.Text);
                            txtInvTotal4_1.Text = Math.Round(Convert.ToDouble(txtInvTotal4.Text) * rate, 2).ToString();
                        }

                        if (tag == "foreign5")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr5.Text, cbInvCurr5_1.Text);
                            txtInvTotal5_1.Text = Math.Round(Convert.ToDouble(txtInvTotal5.Text) * rate, 2).ToString();
                        }

                        if (tag == "local1")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr1.Text, cbInvCurr1_1.Text);
                            txtInvTotal1.Text = Math.Round(Convert.ToDouble(txtInvTotal1_1.Text) / rate, 2).ToString();
                        }

                        if (tag == "local2")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr2.Text, cbInvCurr2_1.Text);
                            txtInvTotal2.Text = Math.Round(Convert.ToDouble(txtInvTotal2_1.Text) / rate, 2).ToString();
                        }

                        if (tag == "local3")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr3.Text, cbInvCurr3_1.Text);
                            txtInvTotal3.Text = Math.Round(Convert.ToDouble(txtInvTotal3_1.Text) / rate, 2).ToString();
                        }

                        if (tag == "local4")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr4.Text, cbInvCurr4_1.Text);
                            txtInvTotal4.Text = Math.Round(Convert.ToDouble(txtInvTotal4_1.Text) / rate, 2).ToString();
                        }

                        if (tag == "local5")
                        {
                            rate = GetCurrencyRate(CmsService.CurrencyDesc, today, cbInvCurr5.Text, cbInvCurr5_1.Text);
                            txtInvTotal5.Text = Math.Round(Convert.ToDouble(txtInvTotal5_1.Text) / rate, 2).ToString();
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
                }
                catch
                {
                    MessageBox.Show("Please select target currency first.");
                }
            }
        }

        private void AccountCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

        }
    }
}
