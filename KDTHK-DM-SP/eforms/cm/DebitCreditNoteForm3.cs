using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.utils;
using KDTHK_DM_SP.services;
using KDTHK_DM_SP.eforms.cm.subforms;
using CustomUtil.utils.authentication;
using System.Diagnostics;
using System.IO;

namespace KDTHK_DM_SP.eforms.cm
{
    public partial class DebitCreditNoteForm3 : Form
    {
        string _formType = "";
        string _currType = "";

        List<string> reasonList;

        public DebitCreditNoteForm3(string formType)
        {
            InitializeComponent();

            CmsService.AttachmentList = new List<services.Attachment>();

            reasonList = new List<string>();

            LoadAccountCode();

            LoadCostCentre();

            //LoadRateMonth();

            txtDnTotal1.LostFocus += new EventHandler(txtDnTotal1_LostFocus);
            txtInvTotal1.LostFocus += new EventHandler(txtInvTotal1_LostFocus);
            txtInvTotal2.LostFocus += new EventHandler(txtInvTotal2_LostFocus);
            txtInvTotal3.LostFocus += new EventHandler(txtInvTotal3_LostFocus);
            txtInvTotal4.LostFocus += new EventHandler(txtInvTotal4_LostFocus);
            txtInvTotal5.LostFocus += new EventHandler(txtInvTotal5_LostFocus);

            txtDnTotal2.LostFocus += new EventHandler(txtDnTotal2_LostFocus);
            txtInvTotal1_1.LostFocus += new EventHandler(txtInvTotal1_1_LostFocus);
            txtInvTotal2_1.LostFocus += new EventHandler(txtInvTotal2_1_LostFocus);
            txtInvTotal3_1.LostFocus += new EventHandler(txtInvTotal3_1_LostFocus);
            txtInvTotal4_1.LostFocus += new EventHandler(txtInvTotal4_1_LostFocus);
            txtInvTotal5_1.LostFocus += new EventHandler(txtInvTotal5_1_LostFocus);

            _formType = formType;

            this.Text = _formType == "debit" ? "Debit Note Application Form" : "Credit Note Application Form";

            lblTitle.Text = _formType == "debit" ? "Debit Note Application Form" : "Credit Note Application Form";

            if (formType == "credit")
            {
                pbInv.BackColor = Color.SpringGreen;
                lblDebit.Text = "Credit";
                lblTotal1.Text = "CN Total Amount";
                lblTotal2.Text = "CN Total Amount";
            }

            cbTranReason2.SelectedIndex = 0;
            cbTranReason3.SelectedIndex = 0;
            cbTranReason4.SelectedIndex = 0;
            cbTranReason5.SelectedIndex = 0;

            Application.Idle += new EventHandler(Application_Idle);
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

            if (txtCustCurr.Text == txtDnCurr2.Text && txtCustCurr.Text != "HKD")
            {
                txtDnTotal1.ReadOnly = true;
                txtDnTotal2.ReadOnly = false;
            }
            else
            {
                if (txtCustCurr.Text == txtDnCurr1.Text)
                {
                    txtDnTotal1.ReadOnly = false;
                    txtDnTotal2.ReadOnly = true;
                }
            }
        }

        private void LoadAccountCode()
        {
            string query = "select a_code from TB_CM_MASTER_ACCOUNTCODE";

            cbAc1.Items.Add("-");
            cbAc2.Items.Add("-");
            cbAc3.Items.Add("-");
            cbAc4.Items.Add("-");
            cbAc5.Items.Add("-");

            cbAc2.Items.Add("同上");
            cbAc3.Items.Add("同上");
            cbAc4.Items.Add("同上");
            cbAc5.Items.Add("同上");

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    cbAc1.Items.Add(reader.GetString(0).Trim());
                    cbAc2.Items.Add(reader.GetString(0).Trim());
                    cbAc3.Items.Add(reader.GetString(0).Trim());
                    cbAc4.Items.Add(reader.GetString(0).Trim());
                    cbAc5.Items.Add(reader.GetString(0).Trim());
                }
            }

            cbAc1.SelectedIndex = 0;
            cbAc2.SelectedIndex = 0;
            cbAc3.SelectedIndex = 0;
            cbAc4.SelectedIndex = 0;
            cbAc5.SelectedIndex = 0;
        }

        private void LoadCostCentre()
        {
            string query = "select c_code from TB_CM_MASTER_COSTCENTRE";

            cbCostCentre1.Items.Add("-");
            cbCostCentre2.Items.Add("-");
            cbCostCentre3.Items.Add("-");
            cbCostCentre4.Items.Add("-");
            cbCostCentre5.Items.Add("-");

            cbCostCentre2.Items.Add("同上");
            cbCostCentre3.Items.Add("同上");
            cbCostCentre4.Items.Add("同上");
            cbCostCentre5.Items.Add("同上");

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    cbCostCentre1.Items.Add(reader.GetString(0).Trim());
                    cbCostCentre2.Items.Add(reader.GetString(0).Trim());
                    cbCostCentre3.Items.Add(reader.GetString(0).Trim());
                    cbCostCentre4.Items.Add(reader.GetString(0).Trim());
                    cbCostCentre5.Items.Add(reader.GetString(0).Trim());
                }
            }

            cbCostCentre1.SelectedIndex = 0;
            cbCostCentre2.SelectedIndex = 0;
            cbCostCentre3.SelectedIndex = 0;
            cbCostCentre4.SelectedIndex = 0;
            cbCostCentre5.SelectedIndex = 0;
        }

        private void LoadRateMonth()
        {
            cbRateMonth.Items.Clear();

            string query = "select cu_month from TB_CM_MASTER_CURRENCY group by cu_month order by cu_month desc";
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    cbRateMonth.Items.Add(reader.GetString(0).Trim());
            }

            cbRateMonth.SelectedIndex = 0;
        }

        private void txtDnTotal1_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (txtExRate.Text != "")
                    if (txtDnTotal1.Text != "")
                    {
                        double total = Convert.ToDouble(txtDnTotal1.Text);
                        txtDnTotal2.Text = Math.Round(Convert.ToDecimal(total) / decimal.Parse(CmsService.Rate), 2).ToString();
                    }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Please input valid amount.");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void txtDnTotal2_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if(txtExRate.Text!="")
                    if (txtDnTotal2.Text != "" && txtDnTotal1.Text == "")
                    {
                        double total = Convert.ToDouble(txtDnTotal2.Text);
                        txtDnTotal1.Text = Math.Round(Convert.ToDecimal(total) * decimal.Parse(CmsService.Rate), 2).ToString();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input valid amount.");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void txtInvTotal1_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (CmsService.Rate != "")
                    if (txtInvTotal1.Text != "")
                        txtInvTotal1_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal1.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input valid amount.");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void txtInvTotal2_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (CmsService.Rate != "")
                    if (txtInvTotal2.Text != "")
                        txtInvTotal2_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal2.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input valid amount.");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void txtInvTotal3_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (CmsService.Rate != "")
                    if (txtInvTotal3.Text != "")
                        txtInvTotal3_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal3.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input valid amount.");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void txtInvTotal4_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (CmsService.Rate != "")
                    if (txtInvTotal4.Text != "")
                        txtInvTotal4_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal4.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input valid amount.");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void txtInvTotal5_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (CmsService.Rate != "")
                    if (txtInvTotal5.Text != "")
                        txtInvTotal5_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal5.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input valid amount.");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void txtInvTotal1_1_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (CmsService.Rate != "")
                    if (txtInvTotal1_1.Text != "" && txtInvTotal1.Text == "")
                        txtInvTotal1.Text = Math.Round(Convert.ToDecimal(txtInvTotal1_1.Text) * Convert.ToDecimal(CmsService.Rate), 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input valid amount.");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void txtInvTotal2_1_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (CmsService.Rate != "")
                    if (txtInvTotal2_1.Text != "" && txtInvTotal2.Text == "")
                        txtInvTotal2.Text = Math.Round(Convert.ToDecimal(txtInvTotal2_1.Text) * Convert.ToDecimal(CmsService.Rate), 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input valid amount.");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void txtInvTotal3_1_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (CmsService.Rate != "")
                    if (txtInvTotal3_1.Text != "" && txtInvTotal3.Text == "")
                        txtInvTotal3.Text = Math.Round(Convert.ToDecimal(txtInvTotal3_1.Text) * Convert.ToDecimal(CmsService.Rate), 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input valid amount.");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void txtInvTotal4_1_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (CmsService.Rate != "")
                    if (txtInvTotal4_1.Text != "" && txtInvTotal4.Text == "")
                        txtInvTotal4.Text = Math.Round(Convert.ToDecimal(txtInvTotal4_1.Text) * Convert.ToDecimal(CmsService.Rate), 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input valid amount.");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void txtInvTotal5_1_LostFocus(object sender, EventArgs e)
        {
            try
            {
                if (CmsService.Rate != "")
                    if (txtInvTotal5_1.Text != "" && txtInvTotal5.Text == "")
                        txtInvTotal5.Text = Math.Round(Convert.ToDecimal(txtInvTotal5_1.Text) * Convert.ToDecimal(CmsService.Rate), 2).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please input valid amount.");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
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
            string dnCurr1 = txtDnCurr1.Text.Trim();
            string dnTotal1 = txtDnTotal1.Text.Trim();
            string dnCurr2 = txtDnCurr2.Text.Trim();
            string dnTotal2 = txtDnTotal2.Text.Trim();

            string reason1 = txtTranReason.Text.Trim();
            string acCode1 = cbAc1.SelectedItem.ToString().Trim();
            string ccCode1 = cbCostCentre1.SelectedItem.ToString().Trim();
            string invCurr1 = txtCurr1.Text;// cbInvCurr1.SelectedItem.ToString().Trim();
            string invTotal1 = txtInvTotal1.Text.Trim();
            string invCurr1_1 = txtInvCurr1.Text.Trim();
            string invTotal1_1 = txtInvTotal1_1.Text.Trim();

            string reason2 = cbTranReason2.Text.Trim();
            string acCode2 = cbAc2.SelectedItem.ToString().Trim();
            string ccCode2 = cbCostCentre2.SelectedItem.ToString().Trim();
            string invCurr2 = txtCurr2.Text;// cbInvCurr2.SelectedItem.ToString().Trim();
            string invTotal2 = txtInvTotal2.Text.Trim();
            string invCurr2_1 = txtInvCurr2.Text.Trim();
            string invTotal2_1 = txtInvTotal2_1.Text.Trim();

            string reason3 = cbTranReason3.Text.Trim();
            string acCode3 = cbAc3.SelectedItem.ToString().Trim();
            string ccCode3 = cbCostCentre3.SelectedItem.ToString().Trim();
            string invCurr3 = txtCurr3.Text;// cbInvCurr3.SelectedItem.ToString().Trim();
            string invTotal3 = txtInvTotal3.Text.Trim();
            string invCurr3_1 = txtInvCurr3.Text.Trim();
            string invTotal3_1 = txtInvTotal3_1.Text.Trim();

            string reason4 = cbTranReason4.Text.Trim();
            string acCode4 = cbAc4.SelectedItem.ToString().Trim();
            string ccCode4 = cbCostCentre4.SelectedItem.ToString().Trim();
            string invCurr4 = txtCurr4.Text;// cbInvCurr4.SelectedItem.ToString().Trim();
            string invTotal4 = txtInvTotal4.Text.Trim();
            string invCurr4_1 = txtInvCurr4.Text.Trim();
            string invTotal4_1 = txtInvTotal4_1.Text.Trim();

            string reason5 = cbTranReason5.Text.Trim();
            string acCode5 = cbAc5.SelectedItem.ToString().Trim();
            string ccCode5 = cbCostCentre5.SelectedItem.ToString().Trim();
            string invCurr5 = txtCurr5.Text;// cbInvCurr5.SelectedItem.ToString().Trim();
            string invTotal5 = txtInvTotal5.Text.Trim();
            string invCurr5_1 = txtInvCurr5.Text.Trim();
            string invTotal5_1 = txtInvTotal5_1.Text.Trim();

            string reqPdf = ckbPdf.Checked ? "Yes" : "No";

            string reqDeduct = ckbDeduct.Checked ? "Yes" : "No";

            if (acCode1 != "-" && ccCode1 != "-")
                if (invCurr1 == "-" || invTotal1 == "" || invCurr1_1 == "-" || invTotal1_1 == "")
                {
                    isDataOK = false;
                }

            if (acCode2 != "-" && ccCode2 != "-")
                if (invCurr2 == "-" || invTotal2 == "" || invCurr2_1 == "-" || invTotal2_1 == "")
                {
                    isDataOK = false;
                }

            if (acCode3 != "-" && ccCode3 != "-")
                if (invCurr3 == "-" || invTotal3 == "" || invCurr3_1 == "-" || invTotal3_1 == "")
                {
                    isDataOK = false;
                }

            if (acCode4 != "-" && ccCode4 != "-")
                if (invCurr4 == "-" || invTotal4 == "" || invCurr4_1 == "-" || invTotal4_1 == "")
                {
                    isDataOK = false;
                }

            if (acCode5 != "-" && ccCode5 != "-")
                if (invCurr5 == "-" || invTotal5 == "" || invCurr5_1 == "-" || invTotal5_1 == "")
                {
                    isDataOK = false;
                }

            try
            {
                double t1 = txtInvTotal1.Text == "" ? 0 : Convert.ToDouble(txtInvTotal1.Text);
                double t2 = txtInvTotal2.Text == "" ? 0 : Convert.ToDouble(txtInvTotal2.Text);
                double t3 = txtInvTotal3.Text == "" ? 0 : Convert.ToDouble(txtInvTotal3.Text);
                double t4 = txtInvTotal4.Text == "" ? 0 : Convert.ToDouble(txtInvTotal4.Text);
                double t5 = txtInvTotal5.Text == "" ? 0 : Convert.ToDouble(txtInvTotal5.Text);

                if (txtDnTotal1.Text != (t1 + t2 + t3 + t4 + t5).ToString())
                    isDataOK = false;
            }
            catch
            {
                isDataOK = false;
            }

            try
            {
                double t1_1 = txtInvTotal1_1.Text == "" ? 0 : Convert.ToDouble(txtInvTotal1_1.Text);
                double t2_1 = txtInvTotal2_1.Text == "" ? 0 : Convert.ToDouble(txtInvTotal2_1.Text);
                double t3_1 = txtInvTotal3_1.Text == "" ? 0 : Convert.ToDouble(txtInvTotal3_1.Text);
                double t4_1 = txtInvTotal4_1.Text == "" ? 0 : Convert.ToDouble(txtInvTotal4_1.Text);
                double t5_1 = txtInvTotal5_1.Text == "" ? 0 : Convert.ToDouble(txtInvTotal5_1.Text);

                if (txtDnTotal2.Text != (t1_1 + t2_1 + t3_1 + t4_1 + t5_1).ToString())
                    isDataOK = false;
            }
            catch
            {
                isDataOK = false;
            }

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

            string mcStaff = "Pang Yuk Ying, Yaffa (彭鈺螢)";
            string mcReview = "Yeung Shing Yee(楊成意,Joey)";
            string mcFinal = "Lai King Ho(黎景豪,Ken)";

            string docNo = McUtil.GetNextDocNo();
            string docId = McUtil.GetId().ToString();

            string formType = _formType == "debit" ? "Debit" : "Credit";

            string query = string.Format("insert into TB_CM_DEBIT (d_status, d_docno, d_reqdate, d_reqoffice, d_reqcostcentre, d_custcode, d_custname" +
                ", d_custcurr, d_payterm, d_duedate, d_custdiv, d_divname, d_incharge, d_reason, d_invno, d_ringino, d_exmonth, d_exrate, d_dntotal1" +
                ", d_dncurr, d_dntotal2, d_pdf, d_deduct, d_createdby, d_created, d_sect, d_div, d_dept, d_mcstaff, d_mcreviewer, d_mcfinal, d_type, d_custreason) values " +
                "(N'{0}', '{1}', '{2}', N'{3}', '{4}', '{5}', N'{6}', '{7}', '{8}', '{9}', '{10}', N'{11}', N'{12}', N'{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}'" +
                ", '{21}', '{22}', N'{23}', '{24}', N'{25}', N'{26}', N'{27}', N'{28}', N'{29}', N'{30}', '{31}', N'{32}')", "係責承認中", docNo, reqDate, reqOffice, reqCostCentre,
                custCode, custName, custCurr, payTerm, dueDate, divCode, divName, inCharge, reason, invNo, ringiNo, cbRateMonth.SelectedItem.ToString().Trim(), exRate, dnTotal1,
                dnCurr2, dnTotal2, reqPdf, reqDeduct, GlobalService.User, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), sectHead, divHead, deptHead, mcStaff, mcReview, mcFinal, formType, txtManual.Text.Trim());

            DataServiceCM.GetInstance().ExecuteNonQuery(query);

            if (acCode1 != "-" && ccCode1 != "-")
            {
                string text = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                    " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", docId, acCode1, ccCode1, invCurr1, invTotal1, invCurr1_1, invTotal1_1, reason1);
                DataServiceCM.GetInstance().ExecuteNonQuery(text);
            }

            if (acCode2 != "-" && ccCode2 != "-")
            {
                string text = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                    " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", docId, acCode2, ccCode2, invCurr2, invTotal2, invCurr2_1, invTotal2_1, reason2);
                DataServiceCM.GetInstance().ExecuteNonQuery(text);
            }

            if (acCode3 != "-" && ccCode3 != "-")
            {
                string text = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                    " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", docId, acCode3, ccCode3, invCurr3, invTotal3, invCurr3_1, invTotal3_1, reason3);
                DataServiceCM.GetInstance().ExecuteNonQuery(text);
            }

            if (acCode4 != "-" && ccCode4 != "-")
            {
                string text = string.Format("insert into TB_CM_DEBIT_TRANSACTION (t_debitid, t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2, t_reason)" +
                    " values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', N'{7}')", docId, acCode4, ccCode4, invCurr4, invTotal4, invCurr4_1, invTotal4_1, reason4);
                DataServiceCM.GetInstance().ExecuteNonQuery(text);
            }

            if (acCode5 != "-" && ccCode5 != "-")
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

        private void btnCustSearch_Click(object sender, EventArgs e)
        {
            CustomerSearchForm form = new CustomerSearchForm(txtCustName.Text.Trim());
            if (form.ShowDialog() == DialogResult.OK)
            {
                txtCustCode.Text = CmsService.CustomerCode;
                txtCustName.Text = CmsService.CustomerName;
                txtCustCurr.Text = CmsService.CustomerCurr;
                txtPayTerm.Text = CmsService.CustomerPayTerm;

                txtCustCode.BackColor = Color.Gray;
                txtCustName.BackColor = Color.Gray;
                txtCustCurr.BackColor = Color.Gray;
                txtPayTerm.BackColor = Color.Gray;

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

                if (txtCustCurr.Text != "HKD")
                {
                    txtDnCurr2.Text = CmsService.CustomerCurr;

                    txtInvCurr1.Text = CmsService.CustomerCurr;
                    txtInvCurr2.Text = CmsService.CustomerCurr;
                    txtInvCurr3.Text = CmsService.CustomerCurr;
                    txtInvCurr4.Text = CmsService.CustomerCurr;
                    txtInvCurr5.Text = CmsService.CustomerCurr;
                }
                LoadRateMonth();
            }
        }

        private void txtCustName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CustomerSearchForm form = new CustomerSearchForm(txtCustName.Text.Trim());
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

                    txtDnCurr2.Text = CmsService.CustomerCurr;

                    txtInvCurr1.Text = CmsService.CustomerCurr;
                    txtInvCurr2.Text = CmsService.CustomerCurr;
                    txtInvCurr3.Text = CmsService.CustomerCurr;
                    txtInvCurr4.Text = CmsService.CustomerCurr;
                    txtInvCurr5.Text = CmsService.CustomerCurr;

                    /*string query = string.Format("select cu_currency from TB_CM_MASTER_CURRENCY where cu_month = '{0}' and cu_type = '{1}' and cu_description = N'{2}'", cbRateMonth.SelectedItem.ToString().Trim(), CmsService.CurrencyType, CmsService.CurrencyDesc);
                    try
                    {
                        txtExRate.Text = DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
                        CmsService.Rate = txtExRate.Text;
                    }
                    catch
                    {
                        string text = string.Format("select cu_currency from TB_CM_MASTER_CURRENCY where cu_month = '{0}' and cu_type = '{1}'", cbRateMonth.SelectedItem.ToString().Trim(), CmsService.CurrencyType);
                        txtExRate.Text = DataServiceCM.GetInstance().ExecuteScalar(text).ToString().Trim();
                        CmsService.Rate = txtExRate.Text;
                    }*/

                    LoadRateMonth();
                }
            }
        }

        private void btnOfficeName_Click(object sender, EventArgs e)
        {
            txtReqOffice.Text = UserUtil.GetDiv(GlobalService.User);
        }

        private void btnCostCentre_Click(object sender, EventArgs e)
        {
            string division = UserUtil.GetDiv(GlobalService.User);

            string query = string.Format("select c_code from TB_CM_MASTER_COSTCENTRE where c_name = N'{0}'", division);
            txtReqCostcentre.Text = DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        private void btnRateMonth_Click(object sender, EventArgs e)
        {
            if (txtInvCurr1.Text == "")
            {
                MessageBox.Show("Please input customer information first.");
                return;
            }

            CurrencySearchForm form = new CurrencySearchForm(CmsService.CurrencyType);
            if (form.ShowDialog() == DialogResult.OK)
            {
                //txtExMonth.Text = CmsService.RateMonth;
                txtExRate.Text = CmsService.RateItem + " ( " + CmsService.Rate + " )";

                txtDnCurr2.Text = txtExRate.Text.Substring(0, 3);

                if (txtDnTotal1.Text != "")
                {
                    double dnTotal = Convert.ToDouble(txtDnTotal1.Text);
                    
                    txtDnTotal2.Text = Math.Round(Convert.ToDecimal(dnTotal) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
                }

                if (txtInvTotal1.Text != "") txtInvTotal1_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal1.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
                if (txtInvTotal2.Text != "") txtInvTotal2_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal2.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
                if (txtInvTotal3.Text != "") txtInvTotal3_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal3.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
                if (txtInvTotal4.Text != "") txtInvTotal4_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal4.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
                if (txtInvTotal5.Text != "") txtInvTotal5_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal5.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
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

                foreach (services.Attachment item in CmsService.AttachmentList)
                    lbAttachment.Items.Add(item.Filename);
            }
        }

        private void lbAttachment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = lbAttachment.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    CmsService.AttachmentList.RemoveAll(x => x.Filename == lbAttachment.SelectedItem.ToString());
                    lbAttachment.Items.RemoveAt(lbAttachment.SelectedIndices[i]);
                }

            }
        }

        string _input = "";

        private void txtReason_TextChanged(object sender, EventArgs e)
        {
            string text = txtReason.Text.Trim();

            if (text.Contains("disposal parts charge")) _input = "disposal";
            else if (text.Contains("machine cost")) _input = "machine";
            else if (text.Contains("material charge")) _input = "material";
            else if (text.Contains("parts charge") && !text.Contains("disposal")) _input = "parts";
            else if (text.Contains("shilong return parts to japan")) _input = "return";
            else if (text.Contains("air freight charge")) _input = "freight";
            else if (text.Contains("disposal charge")) _input = "disposalcharge";
            else if (text.Contains("electricity fee for 16/f")) _input = "elect";
            else if (text.Contains("global call idd charge")) _input = "idd";
            else if (text.Contains("kyocera philosophy edu charge")) _input = "edu";
            else if (text.Contains("ocean freight charge")) _input = "ocean";
            else if (text.Contains("rework charge")) _input = "rework";
            else if (text.Contains("transportation charge")) _input = "trans";
            else if (text.Contains("trial charge")) _input = "trial";
            else if (text.Contains("駐石龍香港職員薪金") || text.Contains("hk staff salary")) _input = "salary";
            else if (text.Contains("claim for defective parts")) _input = "defective";
            else if (text.Contains("expense parts sales")) _input = "expense";
            else if (text.Contains("monthly service charge")) _input = "monthly";
            else if (text.Contains("price difference")) _input = "price";
            else if (text.Contains("stocktake adjustment")) _input = "stocktake";
            else
                _input = "";

            this.Refresh();
        }

        private void DebitCreditNoteForm3_Paint(object sender, PaintEventArgs e)
        {
            pbAccountNote.BackColor = SystemColors.ControlLightLight;
            pbRingi.BackColor = SystemColors.ControlLightLight;
            pbEmail.BackColor = SystemColors.ControlLightLight;
            pbInv.BackColor = SystemColors.ControlLightLight;
            pbReport.BackColor = SystemColors.ControlLightLight;
            pbOutstanding.BackColor = SystemColors.ControlLightLight;
            pbVendor.BackColor = SystemColors.ControlLightLight;
            pbDisposal.BackColor = SystemColors.ControlLightLight;
            pbChange.BackColor = SystemColors.ControlLightLight;
            pbStock.BackColor = SystemColors.ControlLightLight;
            pbRequest.BackColor = SystemColors.ControlLightLight;

            if (_input == "disposal")
            {
                pbAccountNote.BackColor = Color.SpringGreen;
                pbRingi.BackColor = Color.SpringGreen;
                pbDisposal.BackColor = Color.SpringGreen;
                pbRequest.BackColor = Color.SpringGreen;
            }
            else if (_input == "machine")
            {
                pbAccountNote.BackColor = Color.SpringGreen;
                pbInv.BackColor = Color.SpringGreen;
            }
            else if (_input == "material")
            {
                pbAccountNote.BackColor = Color.SpringGreen;
                pbInv.BackColor = Color.SpringGreen;
            }
            else if (_input == "parts")
            {
                pbAccountNote.BackColor = Color.SpringGreen;
                pbInv.BackColor = Color.SpringGreen;
            }
            else if (_input == "return")
            {
                pbAccountNote.BackColor = Color.SpringGreen;
                pbInv.BackColor = Color.SpringGreen;
            }
            else if (_input == "freight")
            {
                pbVendor.BackColor = Color.SpringGreen;
                pbOutstanding.BackColor = Color.SpringGreen;
                pbInv.BackColor = Color.SpringGreen;
            }
            else if (_input == "disposalcharge")
            {
                pbVendor.BackColor = Color.SpringGreen;
                pbOutstanding.BackColor = Color.SpringGreen;
                pbRingi.BackColor = Color.SpringGreen;
            }
            else if (_input == "elect")
            {
                pbVendor.BackColor = Color.SpringGreen;
                pbOutstanding.BackColor = Color.SpringGreen;
            }
            else if (_input == "idd")
            {
                pbVendor.BackColor = Color.SpringGreen;
                pbOutstanding.BackColor = Color.SpringGreen;
            }
            else if (_input == "edu")
            {
                pbVendor.BackColor = Color.SpringGreen;
                pbOutstanding.BackColor = Color.SpringGreen;
            }
            else if (_input == "ocean")
            {
                pbVendor.BackColor = Color.SpringGreen;
                pbOutstanding.BackColor = Color.SpringGreen;
                pbInv.BackColor = Color.SpringGreen;
            }
            else if (_input == "rework")
            {
                pbVendor.BackColor = Color.SpringGreen;
                pbOutstanding.BackColor = Color.SpringGreen;
                pbRequest.BackColor = Color.SpringGreen;
            }
            else if (_input == "trans")
            {
                pbVendor.BackColor = Color.SpringGreen;
                pbOutstanding.BackColor = Color.SpringGreen;
            }
            else if (_input == "trial")
            {
                pbVendor.BackColor = Color.SpringGreen;
                pbOutstanding.BackColor = Color.SpringGreen;
                pbRequest.BackColor = Color.SpringGreen;
            }
            else if (_input == "salary")
            {

            }
            else if (_input == "defective")
            {
                pbDisposal.BackColor = Color.SpringGreen;
                pbStock.BackColor = Color.SpringGreen;
            }
            else if (_input == "expense")
            {

            }
            else if (_input == "monthly")
            {

            }
            else if (_input == "price")
            {

            }
            else if (_input == "stocktake")
            {
                pbDisposal.BackColor = Color.SpringGreen;
            }
            else { }
        }

        private void txtCustDiv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string custCode = txtCustDiv.Text.Trim();

                cbDivname.Items.Clear();
                cbIncharge.Items.Clear();

                string q1 = string.Format("select distinct ar_divname from TB_CM_MASTER_AR where ar_divcode = '{0}'", custCode);
                using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q1))
                {
                    while (reader.Read())
                        cbDivname.Items.Add(reader.GetString(0).Trim());
                }

                string q2 = string.Format("select distinct ar_incharge from TB_CM_MASTER_AR where ar_divcode = '{0}'", custCode);
                using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q2))
                {
                    while (reader.Read())
                        cbIncharge.Items.Add(reader.GetString(0).Trim());
                }

                if (cbDivname.Items.Count > 0) cbDivname.SelectedIndex = 0;
                if (cbIncharge.Items.Count > 0) cbIncharge.SelectedIndex = 0;
            }
        }

        private void cbRateMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

            string query = string.Format("select cu_currency from TB_CM_MASTER_CURRENCY where cu_month = '{0}' and cu_type = '{1}' and cu_description = N'{2}'", cbRateMonth.SelectedItem.ToString().Trim(), CmsService.CurrencyType, CmsService.CurrencyDesc);
            try
            {
                txtExRate.Text = DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
                CmsService.Rate = txtExRate.Text;
            }
            catch
            {
                string text = string.Format("select cu_currency from TB_CM_MASTER_CURRENCY where cu_month = '{0}' and cu_type = '{1}'", cbRateMonth.SelectedItem.ToString().Trim(), CmsService.CurrencyType);
                txtExRate.Text = DataServiceCM.GetInstance().ExecuteScalar(text).ToString().Trim();
                CmsService.Rate = txtExRate.Text;
            }

            if (txtDnTotal1.Text != "") txtDnTotal2.Text = Math.Round(Convert.ToDecimal(txtDnTotal1.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
            if (txtInvTotal1.Text != "") txtInvTotal1_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal1.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
            if (txtInvTotal2.Text != "") txtInvTotal2_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal2.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
            if (txtInvTotal3.Text != "") txtInvTotal3_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal3.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
            if (txtInvTotal4.Text != "") txtInvTotal4_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal4.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
            if (txtInvTotal5.Text != "") txtInvTotal5_1.Text = Math.Round(Convert.ToDecimal(txtInvTotal5.Text) / Convert.ToDecimal(CmsService.Rate), 2).ToString();
        }

        private void cbAc2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAc2.SelectedIndex == 1)
                cbAc2.Text = cbAc1.Text;
        }

        private void cbAc3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAc3.SelectedIndex == 1)
                cbAc3.Text = cbAc2.Text;
        }

        private void cbAc4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAc4.SelectedIndex == 1)
                cbAc4.Text = cbAc3.Text;
        }

        private void cbAc5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAc5.SelectedIndex == 1)
                cbAc5.Text = cbAc4.Text;
        }

        private void cbCostCentre2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCostCentre2.SelectedIndex == 1)
                cbCostCentre2.Text = cbCostCentre1.Text;
        }

        private void cbCostCentre3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCostCentre3.SelectedIndex == 1)
                cbCostCentre3.Text = cbCostCentre2.Text;
        }

        private void cbCostCentre4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCostCentre4.SelectedIndex == 1)
                cbCostCentre4.Text = cbCostCentre3.Text;
        }

        private void cbCostCentre5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCostCentre5.SelectedIndex == 1)
                cbCostCentre5.Text = cbCostCentre4.Text;
        }

        private void PopulateReasonList(string reason1, string reason2, string reason3, string reason4, string reason5)
        {
            reasonList = new List<string>();

            reasonList.Add(reason1);

            if (reason2 != "-") reasonList.Add(reason2);

            if (reason3 != "-") reasonList.Add(reason3);

            if (reason4 != "-") reasonList.Add(reason4);

            if (reason5 != "-") reasonList.Add(reason5);
        }

        private void btnTranReason1_Click(object sender, EventArgs e)
        {
            DescriptionSelectionForm form = new DescriptionSelectionForm(txtTranReason.Text);
            if (form.ShowDialog() == DialogResult.OK)
            {
                reasonList = new List<string>();

                txtTranReason.Text = CmsService.TransactionReason;

                reasonList.Add(CmsService.TransactionReason);

                if (cbTranReason2.SelectedIndex == 1)
                {
                    if (!cbTranReason2.Items.Contains(CmsService.TransactionReason))
                        cbTranReason2.Items.Add(CmsService.TransactionReason);

                    cbTranReason2.Text = CmsService.TransactionReason;
                }

                if (cbTranReason3.SelectedIndex == 1)
                {
                    if (!cbTranReason3.Items.Contains(CmsService.TransactionReason))
                        cbTranReason3.Items.Add(CmsService.TransactionReason);

                    cbTranReason3.Text = CmsService.TransactionReason;
                }

                if (cbTranReason4.SelectedIndex == 1)
                {
                    if (!cbTranReason4.Items.Contains(CmsService.TransactionReason))
                        cbTranReason4.Items.Add(CmsService.TransactionReason);

                    cbTranReason4.Text = CmsService.TransactionReason;
                }

                if (cbTranReason5.SelectedIndex == 1)
                {
                    if (!cbTranReason5.Items.Contains(CmsService.TransactionReason))
                        cbTranReason5.Items.Add(CmsService.TransactionReason);

                    cbTranReason5.Text = CmsService.TransactionReason;
                }

                PopulateReasonList(txtTranReason.Text, cbTranReason2.Text, cbTranReason3.Text, cbTranReason4.Text, cbTranReason5.Text);

                reasonList = reasonList.Distinct().ToList();
                txtReason.Text = string.Join("&", reasonList.ToArray());
            }
        }

        private void btnTranReason2_Click(object sender, EventArgs e)
        {
            if (cbTranReason2.Text != "-" && cbTranReason2.Text != "同上")
            {
                DescriptionSelectionForm form = new DescriptionSelectionForm(cbTranReason2.Text);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    cbTranReason2.Text = CmsService.TransactionReason;

                    PopulateReasonList(txtTranReason.Text, cbTranReason2.Text, cbTranReason3.Text, cbTranReason4.Text, cbTranReason5.Text);

                    reasonList = reasonList.Distinct().ToList();
                    txtReason.Text = string.Join("&", reasonList.ToArray());
                }
            }
        }

        private void btnTranReason3_Click(object sender, EventArgs e)
        {
            if (cbTranReason3.Text != "-" && cbTranReason3.Text != "同上")
            {
                DescriptionSelectionForm form = new DescriptionSelectionForm(cbTranReason3.Text);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    cbTranReason3.Text = CmsService.TransactionReason;

                    PopulateReasonList(txtTranReason.Text, cbTranReason2.Text, cbTranReason3.Text, cbTranReason4.Text, cbTranReason5.Text);

                    reasonList = reasonList.Distinct().ToList();
                    txtReason.Text = string.Join("&", reasonList.ToArray());
                }
            }
        }

        private void btnTranReason4_Click(object sender, EventArgs e)
        {
            if (cbTranReason4.Text != "-" && cbTranReason4.Text != "同上")
            {
                DescriptionSelectionForm form = new DescriptionSelectionForm(cbTranReason4.Text);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    cbTranReason4.Text = CmsService.TransactionReason;

                    PopulateReasonList(txtTranReason.Text, cbTranReason2.Text, cbTranReason3.Text, cbTranReason4.Text, cbTranReason5.Text);

                    reasonList = reasonList.Distinct().ToList();
                    txtReason.Text = string.Join("&", reasonList.ToArray());
                }
            }
        }

        private void btnTranReason5_Click(object sender, EventArgs e)
        {
            if (cbTranReason5.Text != "-" && cbTranReason5.Text != "同上")
            {
                DescriptionSelectionForm form = new DescriptionSelectionForm(cbTranReason5.Text);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    cbTranReason5.Text = CmsService.TransactionReason;

                    PopulateReasonList(txtTranReason.Text, cbTranReason2.Text, cbTranReason3.Text, cbTranReason4.Text, cbTranReason5.Text);

                    reasonList = reasonList.Distinct().ToList();
                    txtReason.Text = string.Join("&", reasonList.ToArray());
                }
            }
        }

        private void cbTranReason2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTranReason2.SelectedIndex == 1)
            {
                if (!cbTranReason2.Items.Contains(txtTranReason.Text.Trim()))
                    cbTranReason2.Items.Add(txtTranReason.Text.Trim());

                cbTranReason2.Text = txtTranReason.Text;
            }

            PopulateReasonList(txtTranReason.Text, cbTranReason2.Text, cbTranReason3.Text, cbTranReason4.Text, cbTranReason5.Text);

            reasonList = reasonList.Distinct().ToList();
            txtReason.Text = string.Join("&", reasonList.ToArray());
        }

        private void cbTranReason3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTranReason3.SelectedIndex == 1)
            {
                if (!cbTranReason3.Items.Contains(cbTranReason2.Text.Trim()))
                    cbTranReason3.Items.Add(cbTranReason2.Text.Trim());

                cbTranReason3.Text = cbTranReason2.Text;
            }

            PopulateReasonList(txtTranReason.Text, cbTranReason2.Text, cbTranReason3.Text, cbTranReason4.Text, cbTranReason5.Text);

            reasonList = reasonList.Distinct().ToList();
            txtReason.Text = string.Join("&", reasonList.ToArray());
        }

        private void cbTranReason4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTranReason4.SelectedIndex == 1)
            {
                if (!cbTranReason4.Items.Contains(cbTranReason3.Text.Trim()))
                    cbTranReason4.Items.Add(cbTranReason3.Text.Trim());

                cbTranReason4.Text = cbTranReason3.Text;
            }

            PopulateReasonList(txtTranReason.Text, cbTranReason2.Text, cbTranReason3.Text, cbTranReason4.Text, cbTranReason5.Text);

            reasonList = reasonList.Distinct().ToList();
            txtReason.Text = string.Join("&", reasonList.ToArray());
        }

        private void cbTranReason5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTranReason5.SelectedIndex == 1)
            {
                if (!cbTranReason5.Items.Contains(cbTranReason4.Text.Trim()))
                    cbTranReason5.Items.Add(cbTranReason4.Text.Trim());

                cbTranReason5.Text = cbTranReason4.Text;
            }

            PopulateReasonList(txtTranReason.Text, cbTranReason2.Text, cbTranReason3.Text, cbTranReason4.Text, cbTranReason5.Text);

            reasonList = reasonList.Distinct().ToList();
            txtReason.Text = string.Join("&", reasonList.ToArray());
        }

    }
}
