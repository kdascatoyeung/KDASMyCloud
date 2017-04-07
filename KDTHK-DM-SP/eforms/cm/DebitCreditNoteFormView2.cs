using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using CustomUtil.utils.authentication;
using KDTHK_DM_SP.utils;
using System.Diagnostics;

namespace KDTHK_DM_SP.eforms.cm
{
    public partial class DebitCreditNoteFormView2 : Form
    {
        string _status = "";
        string _docno = "";
        string _id = "";

        List<Attachment> _attachmentList;

        public DebitCreditNoteFormView2(string docno, string mode)
        {
            InitializeComponent();

            _docno = docno;

            this.Text = "Debit Note Application: " + docno;

            LoadData(docno);

            if (mode == "view")
            {
                btnApprove.Enabled = false;
                btnReject.Enabled = false;
            }
            else
            {
                btnCancel.Enabled = false;
            }

            SignalChanged(docno);

            ckbPdf.Enabled = false;
            ckbDeduct.Enabled = false;

            btnRecall.Enabled = _status != "經管檢查中" && _status != "經管承認中" && _status != "取消確認中" && GlobalService.User == CmUtil.GetApplicant(_docno) ? true : false;
            btnCancel.Enabled = _status != "經管檢查中" && _status != "經管承認中" && _status != "取消確認中" && GlobalService.User == CmUtil.GetApplicant(_docno) ? true : false;

            if (_status == "取消確認中")
                pb1st.BackgroundImage = Properties.Resources.circle_gray;
        }

        private void LoadData(string docno)
        {
            string query = string.Format("select d_reqdate, d_reqoffice, d_reqcostcentre, d_custcode, d_custname, d_custcurr, d_payterm, d_duedate, d_custdiv" +
                ", d_divname, d_incharge, d_reason, d_invno, d_ringino, d_exmonth, d_exrate, d_dntotal1, d_dncurr, d_dntotal2, d_pdf, d_deduct, d_mention" +
                ", d_createdby, d_created, d_sect, d_sectapproval, d_sectdate, d_div, d_divapproval, d_divdate, d_dept, d_deptapproval, d_deptdate, d_id"+
                ", d_mcstaff, d_mcstaffapproval, d_mcstaffdate, d_mcreviewer, d_mcreviewerapproval, d_mcreviewerdate, d_mcfinal, d_mcfinalapproval, d_mcfinaldate from TB_CM_DEBIT where d_docno = '{0}'", docno);

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    txtReqDate.Text = reader.GetString(0).Trim();
                    txtReqOffice.Text = reader.GetString(1).Trim();
                    txtReqCostcentre.Text = reader.GetString(2).Trim();

                    txtCustCode.Text = reader.GetString(3).Trim();
                    txtCustName.Text = reader.GetString(4).Trim();
                    txtCustCurr.Text = reader.GetString(5).Trim();
                    txtPayTerm.Text = reader.GetString(6).Trim();
                    txtDueDate.Text = reader.GetString(7).Trim();
                    txtCustDiv.Text = reader.GetString(8).Trim();
                    txtDivName.Text = reader.GetString(9).Trim();
                    txtIncharge.Text = reader.GetString(10).Trim();

                    txtReason.Text = reader.GetString(11).Trim();
                    txtInvNo.Text = reader.GetString(12).Trim();
                    txtRingiNo.Text = reader.GetString(13).Trim();

                    txtExMonth.Text = reader.GetString(14).Trim();
                    txtExRate.Text = reader.GetString(15).Trim();

                    string curr = reader.GetString(17).Trim();
                    if (curr == "HKD") txtDnCurr2.Text = "HKD";
                    else txtDnCurr1.Text = curr;

                    txtDnTotal1.Text = reader.GetString(16).Trim();
                    //txtDnCurr2.Text = reader.GetString(17).Trim();
                    txtDnTotal2.Text = reader.GetString(18).Trim();

                    string pdf = reader.GetString(19).Trim();
                    string deduct = reader.GetString(20).Trim();
                    txtMention.Text = reader.GetString(21).Trim();

                    string createdby = reader.GetString(22).Trim();
                    string created = reader.GetString(23).Trim();
                    lblRequester.Text = created != "" ? "Form was created by " + createdby + " on " + Convert.ToDateTime(created).ToString("yyyy/MM/dd") + " at " + Convert.ToDateTime(created).ToString("hh:mm tt") : "-";

                    string sect = reader.GetString(24).Trim();
                    string sectapp = reader.GetString(25).Trim();
                    string sectdate = reader.GetString(26).Trim();
                    lblSection.Text = sectdate != "" && sectapp == "Yes" ? "Form was approved by " + sect + " on " + Convert.ToDateTime(sectdate).ToString("yyyy/MM/dd") + " at " + Convert.ToDateTime(sectdate).ToString("hh:mm tt")
                        : sectdate != "" && sectapp == "No" ? "Form was rejected by " + sect + " on " + Convert.ToDateTime(sectdate).ToString("yyyy/MM/dd") + " at " + Convert.ToDateTime(sectdate).ToString("hh:mm tt") : "-";

                    string div = reader.GetString(27).Trim();
                    string divapp = reader.GetString(28).Trim();
                    string divdate = reader.GetString(29).Trim();
                    lblDivision.Text = divdate != "" && divapp == "Yes" ? "Form was approved by " + div + " on " + Convert.ToDateTime(divdate).ToString("yyyy/MM/dd") + " at " + Convert.ToDateTime(divdate).ToString("hh:mm tt")
                        : divdate != "" && divapp == "No" ? "Form was rejected by " + div + " on " + Convert.ToDateTime(divdate).ToString("yyyy/MM/dd") + " at " + Convert.ToDateTime(divdate).ToString("hh:mm tt") : "-";

                    string dept = reader.GetString(30).Trim();
                    string deptapp = reader.GetString(31).Trim();
                    string deptdate = reader.GetString(32).Trim();
                    lblDepartment.Text = deptdate != "" && deptapp == "Yes" ? "Form was approved by " + dept + " on " + Convert.ToDateTime(deptdate).ToString("yyyy/MM/dd") + " at " + Convert.ToDateTime(deptdate).ToString("hh:mm tt")
                        : deptdate != "" && deptapp == "No" ? "Form was rejected by " + dept + " on " + Convert.ToDateTime(deptdate).ToString("yyyy/MM/dd") + " at " + Convert.ToDateTime(deptdate).ToString("hh:mm tt") : "-";

                    _id = reader.GetInt32(33).ToString().Trim();

                    string mcstaff = reader.GetString(34).Trim();
                    string mcstaffapp = reader.GetString(35).Trim();
                    string mcstaffdate = reader.GetString(36).Trim();
                    lblInput.Text = mcstaffdate != "" && mcstaffapp == "Yes" ? "Information was entered by " + mcstaff + " on " + Convert.ToDateTime(mcstaffdate).ToString("yyyy/MM/dd") + " at " + Convert.ToDateTime(mcstaffdate).ToString("hh:mm tt")
                        : mcstaffdate != "" && mcstaffapp == "No" ? "Form was rejected by " + mcstaff + " on " + Convert.ToDateTime(mcstaffdate).ToString("yyyy/MM/dd") + " at " + Convert.ToDateTime(mcstaffdate).ToString("hh:mm tt") : "-";

                    string mcreview = reader.GetString(37).Trim();
                    string mcreviewapp = reader.GetString(38).Trim();
                    string mcreviewdate = reader.GetString(39).Trim();
                    lblReview.Text = mcreviewdate != "" && mcreviewapp == "Yes" ? "Information was checked by " + mcreview + " on " + Convert.ToDateTime(mcreviewdate).ToString("yyyy/MM/dd") + " at " + Convert.ToDateTime(mcreviewdate).ToString("hh:mm tt")
                        : mcreviewdate != "" && mcreviewapp == "No" ? "Form was rejected by " + mcreview + " on " + Convert.ToDateTime(mcreviewdate).ToString("yyyy/MM/dd") + " at " + Convert.ToDateTime(mcreviewdate).ToString("hh:mm tt") : "-";

                    string mcfinal = reader.GetString(40).Trim();
                    string mcfinalapp = reader.GetString(41).Trim();
                    string mcfinaldate = reader.GetString(42).Trim();
                    lblApprove.Text = mcfinaldate != "" && mcfinalapp == "Yes" ? "Form was approved by " + mcfinal + " on " + Convert.ToDateTime(mcfinaldate).ToString("yyyy/MM/dd") + " at " + Convert.ToDateTime(mcfinaldate).ToString("hh:mm tt")
                        : mcreviewdate != "" && mcfinalapp == "No" ? "Form was rejected by " + mcfinal + " on " + Convert.ToDateTime(mcfinaldate).ToString("yyyy/MM/dd") + " at " + Convert.ToDateTime(mcfinaldate).ToString("hh:mm tt") : "-";
                }
            }

            LoadTransaction(_id);

            LoadAttachment(_id);
        }

        private void LoadTransaction(string id)
        {
            List<Transaction> list = new List<Transaction>();

            string query = string.Format("select t_accountcode, t_costcentre, t_invcurr1, t_invtotal1, t_invcurr2, t_invtotal2 from TB_CM_DEBIT_TRANSACTION where t_debitid = '{0}'", id);

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    list.Add(new Transaction { AccountCode = reader.GetString(0), CostCentre = reader.GetString(1), InvCurr1 = reader.GetString(2), InvTotal1 = reader.GetString(3), InvCurr2 = reader.GetString(4), InvTotal2 = reader.GetString(5) });
            }

            if (list.Count > 4)
            {
                txtAccountCode5.Text = list[4].AccountCode;
                txtCostCentre5.Text = list[4].CostCentre;
                txtInvCurr5.Text = list[4].InvCurr1;
                txtInvTotal5.Text = list[4].InvTotal1;
                txtInvCurr5_1.Text = list[4].InvCurr2;
                txtInvTotal5_1.Text = list[4].InvTotal2;
            }

            if (list.Count > 3)
            {
                txtAccountCode4.Text = list[3].AccountCode;
                txtCostCentre4.Text = list[3].CostCentre;
                txtInvCurr4.Text = list[3].InvCurr1;
                txtInvTotal4.Text = list[3].InvTotal1;
                txtInvCurr4_1.Text = list[3].InvCurr2;
                txtInvTotal4_1.Text = list[3].InvTotal2;
            }

            if (list.Count > 2)
            {
                txtAccountCode3.Text = list[2].AccountCode;
                txtCostCentre3.Text = list[2].CostCentre;
                txtInvCurr3.Text = list[2].InvCurr1;
                txtInvTotal3.Text = list[2].InvTotal1;
                txtInvCurr3_1.Text = list[2].InvCurr2;
                txtInvTotal3_1.Text = list[2].InvTotal2;
            }

            if (list.Count > 1)
            {
                txtAccountCode2.Text = list[1].AccountCode;
                txtCostCentre2.Text = list[1].CostCentre;
                txtInvCurr2.Text = list[1].InvCurr1;
                txtInvTotal2.Text = list[1].InvTotal1;
                txtInvCurr2_1.Text = list[1].InvCurr2;
                txtInvTotal2_1.Text = list[1].InvTotal2;
            }

            if (list.Count > 0)
            {
                txtAccountCode1.Text = list[0].AccountCode;
                txtCostCentre1.Text = list[0].CostCentre;
                txtInvCurr1.Text = list[0].InvCurr1;
                txtInvTotal1.Text = list[0].InvTotal1;
                txtInvCurr1_1.Text = list[0].InvCurr2;
                txtInvTotal1_1.Text = list[0].InvTotal2;
            }
        }

        private void LoadAttachment(string id)
        {
            _attachmentList = new List<Attachment>();

            string query = string.Format("select a_name, a_attachment from TB_CM_DEBIT_ATTACHMENT where a_debitid = '{0}'", id);

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    _attachmentList.Add(new Attachment { Name = reader.GetString(0).Trim(), Path = reader.GetString(1).Trim() });
            }

            foreach (Attachment item in _attachmentList)
                lbAttachment.Items.Add(item.Name);
        }

        private void SignalChanged(string docno)
        {
            string query = string.Format("select d_status from TB_CM_DEBIT where d_docno = '{0}'", docno);

            string status = DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();

            _status = status;

            pb1st.BackgroundImage = Properties.Resources.circle;

            if (status == "係責承認中")
                pb2nd.BackgroundImage = Properties.Resources.circle_orange;

            if (status == "科責承認中")
            {
                pb2nd.BackgroundImage = Properties.Resources.circle;
                pb3rd.BackgroundImage = Properties.Resources.circle_orange;
                pb4th.BackgroundImage = Properties.Resources.circle_gray;
            }

            if (status == "部責承認中")
            {
                pb2nd.BackgroundImage = Properties.Resources.circle;
                pb3rd.BackgroundImage = Properties.Resources.circle;
                pb4th.BackgroundImage = Properties.Resources.circle_orange;
                pb5th.BackgroundImage = Properties.Resources.circle_gray;
            }

            if (status == "經管確認中")
            {
                pb2nd.BackgroundImage = Properties.Resources.circle;
                pb3rd.BackgroundImage = Properties.Resources.circle;
                pb4th.BackgroundImage = Properties.Resources.circle;
                pb5th.BackgroundImage = Properties.Resources.circle_orange;
                pb6th.BackgroundImage = Properties.Resources.circle_gray;
            }

            if (status == "經管檢查中")
            {
                pb2nd.BackgroundImage = Properties.Resources.circle;
                pb3rd.BackgroundImage = Properties.Resources.circle;
                pb4th.BackgroundImage = Properties.Resources.circle;
                pb5th.BackgroundImage = Properties.Resources.circle;
                pb6th.BackgroundImage = Properties.Resources.circle_orange;
                pb7th.BackgroundImage = Properties.Resources.circle_gray;
            }

            if (status == "經管承認中")
            {
                pb2nd.BackgroundImage = Properties.Resources.circle;
                pb3rd.BackgroundImage = Properties.Resources.circle;
                pb4th.BackgroundImage = Properties.Resources.circle;
                pb5th.BackgroundImage = Properties.Resources.circle;
                pb6th.BackgroundImage = Properties.Resources.circle;
                pb7th.BackgroundImage = Properties.Resources.circle_orange;
            }
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnApprove_MouseEnter(object sender, EventArgs e)
        {
            if (_status == "係責承認中")
            {
                pb2nd.BackgroundImage = Properties.Resources.circle;
                pb3rd.BackgroundImage = Properties.Resources.circle_orange;
            }

            if (_status == "科責承認中")
            {
                pb3rd.BackgroundImage = Properties.Resources.circle;
                pb4th.BackgroundImage = Properties.Resources.circle_orange;
            }

            if (_status == "部責承認中")
            {
                pb4th.BackgroundImage = Properties.Resources.circle;
                pb5th.BackgroundImage = Properties.Resources.circle_orange;
            }

            if (_status == "經管確認中")
            {
                pb5th.BackgroundImage = Properties.Resources.circle;
                pb6th.BackgroundImage = Properties.Resources.circle_orange;
            }

            if (_status == "經管檢查中")
            {
                pb6th.BackgroundImage = Properties.Resources.circle;
                pb7th.BackgroundImage = Properties.Resources.circle_orange;
            }

            if (_status == "經管承認中")
            {
                pb7th.BackgroundImage = Properties.Resources.circle;
            }
        }

        private void btnApprove_MouseLeave(object sender, EventArgs e)
        {
            SignalChanged(_docno);
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            string query = string.Format("select d_div, d_dept, d_mcstaff, d_mcreviewer, d_mcfinal, d_createdby, d_reason from TB_CM_DEBIT where d_docno = '{0}'", _docno);

            string target = "";
            string applicant = "";
            string reason = "";

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    target = _status == "係責承認中" ? reader.GetString(0).Trim()
                        : _status == "科責承認中" ? reader.GetString(1).Trim()
                        : _status == "部責承認中" ? reader.GetString(2).Trim()
                        : _status == "經管確認中" ? reader.GetString(3).Trim()
                        : _status == "經管檢查中" ? reader.GetString(4).Trim() : "";

                    applicant = reader.GetString(5).Trim();
                    reason = reader.GetString(6).Trim();
                }
            }

            string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string text = _status == "係責承認中" ? string.Format("update TB_CM_DEBIT set d_status = N'科責承認中', d_sectapproval = 'Yes', d_sectdate = '{0}' where d_docno = '{1}'", now, _docno)
                        : _status == "科責承認中" ? string.Format("update TB_CM_DEBIT set d_status = N'部責承認中', d_divapproval = 'Yes', d_divdate = '{0}' where d_docno = '{1}'", now, _docno)
                        : _status == "部責承認中" ? string.Format("update TB_CM_DEBIT set d_status = N'經管確認中', d_deptapproval = 'Yes', d_deptdate = '{0}' where d_docno = '{1}'", now, _docno)
                        : _status == "經管檢查中" ? string.Format("update TB_CM_DEBIT set d_status = N'經管承認中', d_mcreviewerapproval = 'Yes', d_mcreviewerdate = '{0}' where d_docno = '{1}'", now, _docno)
                        : string.Format("update TB_CM_DEBIT set d_status = '申請處理完成', d_mcfinalapproval = 'Yes', d_mcfinaldate = '{0}' where d_docno = '{1}'", now, _docno);

            DataServiceCM.GetInstance().ExecuteNonQuery(text);

            string email = AdUtil.GetEmailByUsername(target, "kmhk.local");
            string fromEmail = AdUtil.GetEmailByUsername(applicant, "kmhk.local");

            if (_status == "部責承認中")
                EformUtil.SendApprovalEmail(_docno, applicant, fromEmail, email, reason, "Debit Note Application Approval Required: " + _docno);
            else
                EformUtil.SendDebitNotificationEmail(_docno, applicant, fromEmail, email, "Received a Debit/Credit Note Application Form\n\nPlease check in Management Console");

            DialogResult = DialogResult.OK;
        }

        private void lbAttachment_DoubleClick(object sender, EventArgs e)
        {
            string path = _attachmentList.Where(x => x.Name == lbAttachment.SelectedItem.ToString().Trim()).First().Path;
            Process.Start(path);
        }

        private void btnReject_MouseEnter(object sender, EventArgs e)
        {
            if (_status == "係責承認中") pb2nd.BackgroundImage = Properties.Resources.circle_red;

            if (_status == "科責承認中") pb3rd.BackgroundImage = Properties.Resources.circle_red;

            if (_status == "部責承認中") pb4th.BackgroundImage = Properties.Resources.circle_red;

            if (_status == "經管確認中") pb5th.BackgroundImage = Properties.Resources.circle_red;

            if (_status == "經管檢查中") pb6th.BackgroundImage = Properties.Resources.circle_red;

            if (_status == "經管承認中") pb7th.BackgroundImage = Properties.Resources.circle_red;
        }

        private void btnReject_MouseLeave(object sender, EventArgs e)
        {
            SignalChanged(_docno);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            string query = string.Format("update TB_CM_DEBIT set d_status = N'拒絕承認' where d_docno = '{0}'", _docno);
            DataServiceCM.GetInstance().ExecuteNonQuery(query);

            string sect = "";
            string div = "";
            string dept = "";
            string createdby = "";

            string text = string.Format("select d_sect, d_div, d_dept, d_createdby from TB_CM_DEBIT where d_docno = '{0}'", _docno);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(text))
            {
                while (reader.Read())
                {
                    sect = reader.GetString(0).Trim();
                    div = reader.GetString(1).Trim();
                    dept = reader.GetString(2).Trim();
                    createdby = reader.GetString(3).Trim();
                }
            }

            string subject = "Debit/Credit Note Application has been Rejected";

            string content = "Dear Sir/Madam,\n\nYour Debit/Credit Note Application has been Rejected. Please go to MyCloud to revise or apply a new application.\n\nThis is system message, please do not reply.";

            EformUtil.SendRejectEmail(_docno, GlobalService.User, AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local"), AdUtil.GetEmailByUsername(createdby, "kmhk.local"), subject, content);//cc?

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Are you sure to cancel the form " + _docno + " ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:

                    //string section = UserUtil.GetSectionHead(UserUtil.GetSect(GlobalService.User));
                    //string division = UserUtil.GetDivisionHead(UserUtil.GetDiv(GlobalService.User));
                    //string department = UserUtil.GetDepartmentHead(UserUtil.GetDept(GlobalService.User));

                    //string query = string.Format("insert into TB_CM_DEBIT_CANCEL (c_docno, c_applicant, c_created, c_sect, c_div, c_dept, c_targetsect, c_targetdept)" +
                       // " values ('{0}', N'{1}', '{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}')", _docno, GlobalService.User, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), section, division, department, "", "");
                    //DataServiceCM.GetInstance().ExecuteNonQuery(query);

                    string text = string.Format("update TB_CM_DEBIT set d_status = N'取消確認中' where d_docno = '{0}'", _docno);
                    DataServiceCM.GetInstance().ExecuteNonQuery(text);

                    DialogResult = DialogResult.OK;
                    break;

                case DialogResult.No:
                    break;
            }
        }

        private void btnRecall_Click(object sender, EventArgs e)
        {
            string query = string.Format("update TB_CM_DEBIT set d_status = N'申請中', d_sectapproval = '-', d_divapproval = '-', d_deptapproval = '-' where d_docno = '{0}'", _docno);
            DataServiceCM.GetInstance().ExecuteNonQuery(query);

            DialogResult = DialogResult.OK;
        }

        private void btnRecall_MouseEnter(object sender, EventArgs e)
        {
            pb1st.BackgroundImage = Properties.Resources.circle_orange;
            pb2nd.BackgroundImage = Properties.Resources.circle_gray;
            pb3rd.BackgroundImage = Properties.Resources.circle_gray;
            pb4th.BackgroundImage = Properties.Resources.circle_gray;
            pb5th.BackgroundImage = Properties.Resources.circle_gray;
        }

        private void btnRecall_MouseLeave(object sender, EventArgs e)
        {
            SignalChanged(_docno);
        }

    }

    public class Transaction
    {
        public string AccountCode { get; set; }
        public string CostCentre { get; set; }
        public string InvCurr1 { get; set; }
        public string InvTotal1 { get; set; }
        public string InvCurr2 { get; set; }
        public string InvTotal2 { get; set; }
    }

    public class Attachment
    {
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
