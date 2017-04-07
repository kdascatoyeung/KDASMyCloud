using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using System.Data.SqlClient;
using CustomUtil.utils.authentication;
using System.Net.Mail;
using KDTHK_DM_SP.controls;
using System.Diagnostics;
using KDTHK_DM_SP.utils;
using System.Collections;
using KDTHK_DM_SP.eforms.cm;
using KDTHK_DM_SP.eforms.acc;
using KDTHK_DM_SP.eforms.adm;

namespace KDTHK_DM_SP.eforms
{
    public partial class ApprovalView : UserControl
    {
        public event EventHandler SaveEvent;
        public event EventHandler RefreshEvent;

        public ApprovalView()
        {
            InitializeComponent();

            dgvApprove.DisableFilterAndSort(dgvApprove.Columns["Approval"]);

            LoadData3();
        }

        private void LoadData3()
        {
            DataTable table = new DataTable();
            string[] headers = { "app", "chaseno", "type", "title", "created", "createdby", "tablename" };
            foreach (string header in headers)
                table.Columns.Add(header);

            LoadITData(table);

            LoadMCData(table);

            LoadAccData(table);

            LoadAdmData(table);

            //dgvForm.DataSource = table;

            bindingSource1.DataSource = table;

            //dgvApprove.DataSource = table;
        }

        private void LoadITData(DataTable table)
        {
            string q1 = string.Format("select p_chaseno, p_approval, p_created, p_applicant, f_title from TB_FORM_PERMISSION, TB_FORM where p_approver = N'{0}' and p_status = N'上司承認中' and p_refno = f_chaseno", GlobalService.User);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(q1))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "權限及軟件安裝", reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_FORM_PERMISSION");
            }
            string q12 = string.Format("select p_chaseno, p_approval, p_created, p_applicant, f_title from TB_FORM_PERMISSION, TB_FORM where p_itapproval = N'{0}' and p_itapprovaldate IS null  and p_refno = f_chaseno", GlobalService.User);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(q12))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "權限及軟件安裝", reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_FORM_PERMISSION");
            }

            string q2 = string.Format("select l_chaseno, l_approval, l_created, l_applicant, f_title from TB_FORM_LOANING, TB_FORM where l_approver = N'{0}' and l_status = N'上司承認中' and l_refno = f_chaseno", GlobalService.User);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(q2))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "資產外借", reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_FORM_LOANING");
            }

            string q3 = string.Format("select d_chaseno, d_approval, d_created, d_applicant, f_title from TB_FORM_DEVELOP, TB_FORM where d_approver = N'{0}' and d_status = N'上司承認中' and d_refno = f_chaseno", GlobalService.User);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(q3))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "工具開發/修改", reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_FORM_DEVELOP");
            }

            string q4 = string.Format("select f_chaseno, f_approval, f_created, f_applicant, f_title from TB_FORM where f_approver = N'{0}' and f_status = N'上司承認中'", GlobalService.User);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(q4))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "IT綜合申請", reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_FORM");
            }

            string q5 = string.Format("select r_chaseno, r_approval, r_created, r_applicant, r_title from TB_FORM_R3 where (r_approver = N'{0}' and r_status = N'上司承認中') or (r_cmapprover = N'{0}' and r_status = N'經管承認中')", GlobalService.User);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(q5))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "R3申請", reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_FORM_R3");
            }
        }

        private void LoadMCData(DataTable table)
        {
            string q1 = string.Format("select d_docno, d_sectapproval, d_created, d_createdby, d_reason, d_type from TB_CM_DEBIT where d_status = N'係責承認中' and d_sect = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q1))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), reader.GetString(5), reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_CM_DEBIT");
            }

            string q2 = string.Format("select d_docno, d_divapproval, d_created, d_createdby, d_reason, d_type from TB_CM_DEBIT where d_status = N'科責承認中' and d_div = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q2))
            {
                while(reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), reader.GetString(5), reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_CM_DEBIT");
            }

            string q3 = string.Format("select d_docno, d_deptapproval, d_created, d_createdby, d_reason, d_type from TB_CM_DEBIT where d_status = N'部責承認中' and d_dept = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q3))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), reader.GetString(5), reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_CM_DEBIT");
            }

            string q4 = string.Format("select d_docno, d_mcreviewerapproval, d_created, d_createdby, d_reason, d_type from TB_CM_DEBIT where d_status = N'經管檢查中' and d_mcreviewer = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q4))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), reader.GetString(5), reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_CM_DEBIT");
            }

            string q5 = string.Format("select d_docno, d_mcfinalapproval, d_created, d_createdby, d_reason, d_type from TB_CM_DEBIT where d_status = N'經管承認中' and d_mcfinal = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q5))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), reader.GetString(5), reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_CM_DEBIT");
            }

            string q6 = string.Format("select c_docno, c_applicantconfirm, c_created, c_applicant, c_reason from TB_CM_DEBIT_CANCEL where c_status = N'取消確認中' and c_applicantconfirm = '-' and  c_applicant = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q6))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "Debit/Credit Note Cancel", reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_CM_DEBIT_CANCEL");
            }

            string q7 = string.Format("select c_docno, c_sectconfirm, c_created, c_applicant, c_reason from TB_CM_DEBIT_CANCEL where c_status = N'取消確認中' and c_sectconfirm = '-' and c_sect = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q6))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "Debit/Credit Note Cancel", reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_CM_DEBIT_CANCEL");
            }

            string q8 = string.Format("select c_docno, c_divconfirm, c_created, c_applicant, c_reason from TB_CM_DEBIT_CANCEL where c_status = N'取消確認中' and c_divconfirm = '-' and c_div = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q6))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "Debit/Credit Note Cancel", reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_CM_DEBIT_CANCEL");
            }

            string q9 = string.Format("select c_docno, c_deptconfirm, c_created, c_applicant, c_reason from TB_CM_DEBIT_CANCEL where c_status = N'取消確認中' and c_deptconfirm = '-' and c_dept = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q6))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "Debit/Credit Note Cancel", reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_CM_DEBIT_CANCEL");
            }

            string q10 = string.Format("select c_docno, c_targetsectconfirm, c_created, c_applicant, c_reason from TB_CM_DEBIT_CANCEL where c_status = N'取消確認中' and c_targetsectconfirm = '-' and c_targetsect = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q6))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "Debit/Credit Note Cancel", reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_CM_DEBIT_CANCEL");
            }

            string q11 = string.Format("select c_docno, c_targetdeptconfirm, c_created, c_applicant, c_reason from TB_CM_DEBIT_CANCEL where c_status = N'取消確認中' and c_targetdeptconfirm = '-' and c_targetdept = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q6))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "Debit/Credit Note Cancel", reader.GetString(4), reader.GetString(2), reader.GetString(3), "TB_CM_DEBIT_CANCEL");
            }
        }

        private void LoadAccData(DataTable table)
        {
            string q1 = string.Format("select o_invoice, o_divapproval, o_created, o_createdby from TB_ACC_OUTSTANDING where o_status = N'科責承認中' and o_div = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q1))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "Outstanding Slip", reader.GetString(0), reader.GetString(2), reader.GetString(3), "TB_ACC_OUTSTANDING");
            }

            string q4 = string.Format("select o_invoice, o_accapproval, o_created, o_createdby from TB_ACC_OUTSTANDING where o_status = N'係責承認中' and o_sect = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q4))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "Outstanding Slip", reader.GetString(0), reader.GetString(2), reader.GetString(3), "TB_ACC_OUTSTANDING");
            }

           /* string q2 = string.Format("select o_invoice, o_staffapproval, o_created, o_createdby from TB_ACC_OUTSTANDING where o_status = N'會計處理中' and o_staff = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q2))
            {
                while(reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "Outstanding Slip", reader.GetString(0), reader.GetString(2), reader.GetString(3), "TB_ACC_OUTSTANDING");
            }

            string q3 = string.Format("select o_invoice, o_accapproval, o_created, o_createdby from TB_ACC_OUTSTANDING where o_status = N'會計承認中' and o_acc = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q3))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "Outstanding Slip", reader.GetString(0), reader.GetString(2), reader.GetString(3), "TB_ACC_OUTSTANDING");
            }
            string q5 = string.Format("select o_invoice, o_accapproval, o_created, o_createdby from TB_ACC_OUTSTANDING where o_status = N'部責承認中' and o_dept = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q5))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(1), reader.GetString(0), "Outstanding Slip", reader.GetString(0), reader.GetString(2), reader.GetString(3), "TB_ACC_OUTSTANDING");
            }*/
        }

        private void LoadAdmData(DataTable table)
        {
            string admKeyText1 = string.Format("select ak_createdby, ak_created, ak_key, ak_remarks, ak_sectapp, ak_id from TB_ADM_FORM_KEY where ak_status = N'係責承認中' and ak_sect = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admKeyText1))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(4), reader.GetInt32(5), "複製鎖匙申請", reader.GetString(2) + " (" + reader.GetString(3) + ")", reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_KEY");
            }

            string admKeyText2 = string.Format("select ak_createdby, ak_created, ak_key, ak_remarks, ak_divapp, ak_id from TB_ADM_FORM_KEY where ak_status = N'科責承認中' and ak_div = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admKeyText2))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(4), reader.GetInt32(5), "複製鎖匙申請", reader.GetString(2) + " (" + reader.GetString(3) + ")", reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_KEY");
            }

            string admLiftText1 = string.Format("select al_createdby, al_created, al_date, al_from, al_to, al_vendor, al_sectapp, al_id from TB_ADM_FORM_LIFT where al_status = N'係責承認中' and al_sect = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admLiftText1))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(6), reader.GetInt32(7), "使用載貨升降機", reader.GetString(2) + " " + reader.GetString(3) + "-" + reader.GetString(4) + " (" + reader.GetString(5) + ")", reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_LIFT");
            }

            string admLiftText2 = string.Format("select al_createdby, al_created, al_date, al_from, al_to, al_vendor, al_divapp, al_id from TB_ADM_FORM_LIFT where al_status = N'科責承認中' and al_div = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admLiftText2))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(6), reader.GetInt32(7), "使用載貨升降機", reader.GetString(2) + " " + reader.GetString(3) + "-" + reader.GetString(4) + " (" + reader.GetString(5) + ")", reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_LIFT");
            }

            string admParkText1 = string.Format("select ap_createdby, ap_created, ap_date, ap_company, ap_sectapp, ap_id from TB_ADM_FORM_PARK where ap_status = N'係責承認中' and ap_sect = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admParkText1))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(4), reader.GetInt32(5), "訪客車位申請", reader.GetString(3) + " (" + reader.GetString(2) + ")", reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_PARK");
            }

            string admParkText2 = string.Format("select ap_createdby, ap_created, ap_date, ap_company, ap_divapp, ap_id from TB_ADM_FORM_PARK where ap_status = N'科責承認中' and ap_div = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admParkText2))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(4), reader.GetInt32(5), "訪客車位申請", reader.GetString(3) + " (" + reader.GetString(2) + ")", reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_PARK");
            }

            string admPurText1 = string.Format("select ap_createdby, ap_created, ap_remarks, ap_sectapp, ap_id from TB_ADM_FORM_PURCHASE where ap_status = N'係責承認中' and ap_sect = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admPurText1))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(3), reader.GetInt32(4), "購買依賴", reader.GetString(2), reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_PURCHASE");
            }

            string admPurText2 = string.Format("select ap_createdby, ap_created, ap_remarks, ap_divapp, ap_id from TB_ADM_FORM_PURCHASE where ap_status = N'科責承認中' and ap_div = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admPurText2))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(3), reader.GetInt32(4), "購買依賴", reader.GetString(2), reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_PURCHASE");
            }

            string admRepairText1 = string.Format("select ar_createdby, ar_created, ar_fee, ar_content, ar_sectapp, ar_id from TB_ADM_FORM_REPAIR where ar_status = N'係責承認中' and ar_sect = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admRepairText1))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(4), reader.GetInt32(5), "維修依賴", reader.GetString(3) + " ($" + reader.GetString(2) + ")", reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_REPAIR");
            }

            string admRepairText2 = string.Format("select ar_createdby, ar_created, ar_fee, ar_content, ar_divapp, ar_id from TB_ADM_FORM_REPAIR where ar_status = N'科責承認中' and ar_div = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admRepairText2))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(4), reader.GetInt32(5), "維修依賴", reader.GetString(3) + " ($" + reader.GetString(2) + ")", reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_REPAIR");
            }

            string admRepairText3 = string.Format("select ar_createdby, ar_created, ar_fee, ar_content, ar_deptapp, ar_id from TB_ADM_FORM_REPAIR where ar_status = N'部責承認中' and ar_dept = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admRepairText3))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(4), reader.GetInt32(5), "維修依賴", reader.GetString(3) + " ($" + reader.GetString(2) + ")", reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_REPAIR");
            }

            string admStampText1 = string.Format("select as_createdby, as_created, as_total, as_sectapp, as_id from TB_ADM_FORM_STAMP where as_status = N'係責承認中' and as_sect = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admStampText1))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(3), reader.GetInt32(4), "購買郵票", "$" + reader.GetString(2), reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_STAMP");
            }

            string admStampText2 = string.Format("select as_createdby, as_created, as_total, as_divapp, as_id from TB_ADM_FORM_STAMP where as_status = N'科責承認中' and as_div = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admStampText2))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(3), reader.GetInt32(4), "購買郵票", "$" + reader.GetString(2), reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_STAMP");
            }

            string admVisaText1 = string.Format("select av_createdby, av_created, av_reason, av_sectapp, av_id from TB_ADM_FORM_VISA where av_status = N'係責承認中' and av_sect = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admVisaText1))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(3), reader.GetInt32(4), "簽証申請", reader.GetString(2), reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_VISA");
            }

            string admVisaText2 = string.Format("select av_createdby, av_created, av_reason, av_divapp, av_id from TB_ADM_FORM_VISA where av_status = N'科責承認中' and av_div = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(admVisaText2))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(3), reader.GetInt32(4), "簽証申請", reader.GetString(2), reader.GetString(1), reader.GetString(0), "TB_ADM_FORM_VISA");
            }
        }

        private void LoadData2()
        {
            string query = string.Format("select f_approval, f_type, f_content, f_start, f_end, f_created, f_createdby, f_id, f_chaseno from TB_FORM where f_approver = N'{0}' and f_status = N'上司承認中'", GlobalService.User);

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string approval = reader.GetString(0);
                    string type = reader.GetString(1);
                    RichTextBox rtb = new RichTextBox();

                    byte[] content = new Byte[Convert.ToInt32((reader.GetBytes(2, 0, null, 0, Int32.MaxValue)))];
                    long bytesReceived = reader.GetBytes(2, 0, content, 0, content.Length);
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    rtb.Rtf = encoding.GetString(content, 0, Convert.ToInt32(bytesReceived));


                    string start = reader.GetString(3);
                    string end = reader.GetString(4);
                    string created = reader.GetString(5);
                    string createdby = reader.GetString(6);
                    int id = reader.GetInt32(7);
                    string chaseno = reader.GetString(8);

                    dgvForm.Rows.Add(approval, type, rtb.Rtf, start, end, created, createdby, id, chaseno);
                }
            }
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData3();

            if (RefreshEvent != null)
                RefreshEvent(this, new EventArgs());
        }

        private void tsbtnApprove_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dgvForm.Rows)
               // row.Cells[0].Value = "Approve";

            foreach (DataGridViewRow row in dgvApprove.Rows)
                row.Cells[0].Value = "Approve";
        }

        private void tsbtnReject_Click(object sender, EventArgs e)
        {
            //foreach (DataGridViewRow row in dgvForm.Rows)
                //row.Cells[0].Value = "Reject";

            foreach (DataGridViewRow row in dgvApprove.Rows)
                row.Cells[0].Value = "Reject";
        }

        private void tsbtnSave_Click(object sender, EventArgs e)
        {
            dgvApprove.EndEdit();

            bool isSent = false;

            string accSent = "";

            List<EmailSentData> emailList = new List<EmailSentData>();

            List<ApprovedData> approvedList = new List<ApprovedData>();

            foreach (DataGridViewRow row in dgvApprove.Rows)
            {
                string approval = row.Cells[0].Value.ToString();
                string chaseno = row.Cells[1].Value.ToString();
                string type = row.Cells[2].Value.ToString();
                string title = row.Cells[3].Value.ToString();
                string createdby = row.Cells[5].Value.ToString().Trim();
                string tablename = row.Cells[6].Value.ToString();

                string status = type.StartsWith("R3") ? EformUtil.GetR3Status(chaseno) : "";
                //Debug.WriteLine("Status: " + status);

                string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                if (approval == "Reject")
                {
                    if (tablename == "TB_CM_DEBIT")
                    {
                        string text = string.Format("update TB_CM_DEBIT set d_status = N'拒絕承認' where d_docno = '{0}'", chaseno);
                        DataServiceCM.GetInstance().ExecuteNonQuery(text);

                        string applicant = CmUtil.GetApplicant(chaseno);

                        string from = AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local");

                        string to = AdUtil.GetEmailByUsername(applicant, "kmhk.local");

                        string subject = "Debit / Credit Application has been Rejected";
                        string hostname = "Kdmail.km.local";
                        string body = "Your application has been rejected. Please review your application and submit again.\n\nReference no. : " + chaseno;

                        SmtpClient client = new SmtpClient(hostname);
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;

                        MailMessage mail = new MailMessage();
                        mail.From = new MailAddress(from, GlobalService.User, Encoding.UTF8);
                        mail.To.Add(to);
                        mail.Subject = subject;
                        mail.Body = body;

                        client.Send(mail);
                    }
                    else if (tablename == "TB_CM_DEBIT_CANCEL")
                    {
                        string q1 = string.Format("update TB_CM_DEBIT_CANCEL set c_applicantconfirm = 'No', c_applicantconfirmdate = '{0}' where c_docno = '{1}' and c_applicant = N'{2}'", now, chaseno, GlobalService.User);
                        string q2 = string.Format("update TB_CM_DEBIT_CANCEL set c_sectconfirm = 'No', c_sectconfirmdate = '{0}' where c_docno = '{1}' and c_sect = N'{2}'", now, chaseno, GlobalService.User);
                        string q3 = string.Format("update TB_CM_DEBIT_CANCEL set c_divconfirm = 'No', c_divconfirmdate = '{0}' where c_docno = '{1}' and c_div = N'{2}'", now, chaseno, GlobalService.User);
                        string q4 = string.Format("update TB_CM_DEBIT_CANCEL set c_deptconfirm = 'No', c_deptconfirmdate = '{0}' where c_docno = '{1}' and c_dept = N'{2}'", now, chaseno, GlobalService.User);
                        string q5 = string.Format("update TB_CM_DEBIT_CANCEL set c_targetsectconfirm = 'No', c_targetsectconfirmdate = '{0}' where c_docno = '{1}' and c_targetsect = N'{2}'", now, chaseno, GlobalService.User);
                        string q6 = string.Format("update TB_CM_DEBIT_CANCEL set c_targetdeptconfirm = 'No', c_targetdeptconfirmdate = '{0}' where c_docno = '{1}' and c_targetdept = N'{2}'", now, chaseno, GlobalService.User);

                        DataServiceCM.GetInstance().ExecuteNonQuery(q1);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q2);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q3);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q4);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q5);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q6);
                    }
                    else if (tablename == "TB_ACC_OUTSTANDING")
                    {
                        string q1 = string.Format("update TB_ACC_OUTSTANDING set o_divapproval = 'No', o_divapprovaldate = '{0}', o_status = N'科責已拒絕' where o_invoice = '{1}' and o_status = N'科責承認中'", now, chaseno);
                        string q2 = string.Format("update TB_ACC_OUTSTANDING set o_staffapproval = 'No', o_staffapprovaldate = '{0}', o_status = N'會計已拒絕' where o_invoice = '{1}' and o_status = N'會計處理中'", now, chaseno);
                        string q3 = string.Format("update TB_ACC_OUTSTANDING set o_accapproval = 'No', o_accapprovaldate = '{0}', o_status = N'會計已拒絕' where o_invoice = '{1}' and o_status = N'會計承認中'", now, chaseno);

                        DataServiceCM.GetInstance().ExecuteNonQuery(q1);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q2);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q3);
                    }
                    else if (tablename == "TB_ADM_FORM_KEY")
                    {
                        string q1 = string.Format("update TB_ADM_FORM_KEY set ak_sectapp = 'No', ak_sectapptime = '{0}', ak_status = N'係責已拒絕' where ak_id = '{1}' and ak_status = N'係責承認中'", now, chaseno);
                        string q2 = string.Format("update TB_ADM_FORM_KEY set ak_divapp = 'No', ak_divapptime = '{0}', ak_status = N'科責已拒絕' where ak_id = '{1}' and ak_status = N'科責承認中'", now, chaseno);
                        string q3 = string.Format("update TB_ADM_FORM_KEY set ak_adm1stapp = 'No', ak_adm1stdate = '{0}', ak_status = N'行政係責已拒絕' where ak_id = '{1}' and ak_status = N'行政係責承認中'", now, chaseno);
                        string q4 = string.Format("update TB_ADM_FORM_KEY set ak_adm2ndapp = 'No', ak_adm2nddate = '{0}', ak_status = N'行政科責已拒絕' where ak_id = '{1}' and ak_status = N'行政科責承認中'", now, chaseno);

                        DataServiceCM.GetInstance().ExecuteNonQuery(q1);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q2);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q3);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q4);
                    }
                    else if (tablename == "TB_ADM_FORM_LIFT")
                    {
                        string q1 = string.Format("update TB_ADM_FORM_LIFT set al_sectapp = 'No', al_sectapptime = '{0}', al_status = N'係責已拒絕' where al_id = '{1}' and al_status = N'係責承認中'", now, chaseno);
                        string q2 = string.Format("update TB_ADM_FORM_LIFT set al_divapp = 'No', al_divapptime = '{0}', al_status = N'科責已拒絕' where al_id = '{1}' and al_status = N'科責承認中'", now, chaseno);
                        string q3 = string.Format("update TB_ADM_FORM_LIFT set al_adm1stapp = 'No', al_adm1stdate = '{0}', al_status = N'行政係責已拒絕' where al_id = '{1}' and al_status = N'行政係責承認中'", now, chaseno);
                        string q4 = string.Format("update TB_ADM_FORM_LIFT set al_adm2ndapp = 'No', al_adm2nddate = '{0}', al_status = N'行政科責已拒絕' where al_id = '{1}' and al_status = N'行政科責承認中'", now, chaseno);

                        DataServiceCM.GetInstance().ExecuteNonQuery(q1);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q2);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q3);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q4);
                    }
                    else if (tablename == "TB_ADM_FORM_PARK")
                    {
                        string q1 = string.Format("update TB_ADM_FORM_PARK set ap_sectapp = 'No', ap_sectapptime = '{0}', ap_status = N'係責已拒絕' where ap_id = '{1}' and ap_status = N'係責承認中'", now, chaseno);
                        string q2 = string.Format("update TB_ADM_FORM_PARK set ap_divapp = 'No', ap_divapptime = '{0}', ap_status = N'科責已拒絕' where ap_id = '{1}' and ap_status = N'科責承認中'", now, chaseno);
                        string q3 = string.Format("update TB_ADM_FORM_PARK set ap_adm1stapp = 'No', ap_adm1stdate = '{0}', ap_status = N'行政係責已拒絕' where ap_id = '{1}' and ap_status = N'行政係責承認中'", now, chaseno);
                        string q4 = string.Format("update TB_ADM_FORM_PARK set ap_adm2ndapp = 'No', ap_adm2nddate = '{0}', ap_status = N'行政科責已拒絕' where ap_id = '{1}' and ap_status = N'行政科責承認中'", now, chaseno);

                        DataServiceCM.GetInstance().ExecuteNonQuery(q1);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q2);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q3);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q4);
                    }
                    else if (tablename == "TB_ADM_FORM_PURCHASE")
                    {
                        string q1 = string.Format("update TB_ADM_FORM_PURCHASE set ap_sectapp = 'No', ap_sectapptime = '{0}', ap_status = N'係責已拒絕' where ap_id = '{1}' and ap_status = N'係責承認中'", now, chaseno);
                        string q2 = string.Format("update TB_ADM_FORM_PURCHASE set ap_divapp = 'No', ap_divapptime = '{0}', ap_status = N'科責已拒絕' where ap_id = '{1}' and ap_status = N'科責承認中'", now, chaseno);
                        string q3 = string.Format("update TB_ADM_FORM_PURCHASE set ap_adm1stapp = 'No', ap_adm1stdate = '{0}', ap_status = N'行政係責已拒絕' where ap_id = '{1}' and ap_status = N'行政係責承認中'", now, chaseno);
                        string q4 = string.Format("update TB_ADM_FORM_PURCHASE set ap_adm2ndapp = 'No', ap_adm2nddate = '{0}', ap_status = N'行政科責已拒絕' where ap_id = '{1}' and ap_status = N'行政科責承認中'", now, chaseno);

                        DataServiceCM.GetInstance().ExecuteNonQuery(q1);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q2);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q3);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q4);
                    }
                    else if (tablename == "TB_ADM_FORM_REPAIR")
                    {
                        string q1 = string.Format("update TB_ADM_FORM_REPAIR set ar_sectapp = 'No', ar_sectapptime = '{0}', ar_status = N'係責已拒絕' where ar_id = '{1}' and ar_status = N'係責承認中'", now, chaseno);
                        string q2 = string.Format("update TB_ADM_FORM_REPAIR set ar_divapp = 'No', ar_divapptime = '{0}', ar_status = N'科責已拒絕' where ar_id = '{1}' and ar_status = N'科責承認中'", now, chaseno);
                        string q3 = string.Format("update TB_ADM_FORM_REPAIR set ar_adm1stapp = 'No', ar_adm1stdate = '{0}', ar_status = N'行政係責已拒絕' where ar_id = '{1}' and ar_status = N'行政係責承認中'", now, chaseno);
                        string q4 = string.Format("update TB_ADM_FORM_REPAIR set ar_adm2ndapp = 'No', ar_adm2nddate = '{0}', ar_status = N'行政科責已拒絕' where ar_id = '{1}' and ar_status = N'行政科責承認中'", now, chaseno);

                        DataServiceCM.GetInstance().ExecuteNonQuery(q1);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q2);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q3);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q4);
                    }
                    else if (tablename == "TB_ADM_FORM_STAMP")
                    {
                        string q1 = string.Format("update TB_ADM_FORM_STAMP set as_sectapp = 'No', as_sectapptime = '{0}', as_status = N'係責已拒絕' where as_id = '{1}' and as_status = N'係責承認中'", now, chaseno);
                        string q2 = string.Format("update TB_ADM_FORM_STAMP set as_divapp = 'No', as_divapptime = '{0}', as_status = N'科責已拒絕' where as_id = '{1}' and as_status = N'科責承認中'", now, chaseno);
                        string q3 = string.Format("update TB_ADM_FORM_STAMP set as_adm1stapp = 'No', as_adm1stdate = '{0}', as_status = N'行政係責已拒絕' where as_id = '{1}' and as_status = N'行政係責承認中'", now, chaseno);
                        string q4 = string.Format("update TB_ADM_FORM_STAMP set as_adm2ndapp = 'No', as_adm2nddate = '{0}', as_status = N'行政科責已拒絕' where as_id = '{1}' and as_status = N'行政科責承認中'", now, chaseno);

                        DataServiceCM.GetInstance().ExecuteNonQuery(q1);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q2);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q3);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q4);
                    }
                    else if (tablename == "TB_ADM_FORM_VISA")
                    {
                        string q1 = string.Format("update TB_ADM_FORM_VISA set av_sectapp = 'No', av_sectapptime = '{0}', av_status = N'係責已拒絕' where av_id = '{1}' and av_status = N'係責承認中'", now, chaseno);
                        string q2 = string.Format("update TB_ADM_FORM_VISA set av_divapp = 'No', av_divapptime = '{0}', av_status = N'科責已拒絕' where av_id = '{1}' and av_status = N'科責承認中'", now, chaseno);
                        string q3 = string.Format("update TB_ADM_FORM_VISA set av_adm1stapp = 'No', av_adm1stdate = '{0}', av_status = N'行政係責已拒絕' where av_id = '{1}' and av_status = N'行政係責承認中'", now, chaseno);
                        string q4 = string.Format("update TB_ADM_FORM_VISA set av_adm2ndapp = 'No', av_adm2nddate = '{0}', av_status = N'行政科責已拒絕' where av_id = '{1}' and av_status = N'行政科責承認中'", now, chaseno);

                        DataServiceCM.GetInstance().ExecuteNonQuery(q1);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q2);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q3);
                        DataServiceCM.GetInstance().ExecuteNonQuery(q4);
                    }
                    else
                    {
                        string text = tablename == "TB_FORM_PERMISSION" ? string.Format("update " + tablename + " set p_approval = 'Reject', f_approvaldate = '{0}', p_status = N'上司已拒絕' where p_chaseno = '{1}'", now, chaseno)
                            : tablename == "TB_FORM_LOANING" ? string.Format("update " + tablename + " set l_approval = 'Reject', l_approvaldate = '{0}', l_status = N'上司已拒絕' where l_chaseno = '{1}'", now, chaseno)
                            : tablename == "TB_FORM_DEVELOP" ? string.Format("update " + tablename + " set d_approval = 'Reject', d_approvaldate = '{0}', d_status = N'上司已拒絕' where d_chaseno = '{1}'", now, chaseno)
                            : tablename == "TB_FORM_R3" && status == "上司承認中" ? string.Format("update " + tablename + " set r_approval = 'Reject', r_status = N'上司已拒絕' where r_chaseno = '{0}' and r_status = N'上司承認中'", chaseno)
                            : tablename == "TB_FORM_R3" && status == "經管承認中" ? string.Format("update " + tablename + " set r_cmapproval = 'Reject', r_status = N'經管已拒絕' where r_chaseno = '{0}' and r_status = N'經管承認中'", chaseno)
                            : string.Format("update " + tablename + " set f_approval = 'Reject', f_approvaldate = '{0}', f_status = N'上司已拒絕' where f_chaseno = '{1}'", now, chaseno);
                        DataService.GetInstance().ExecuteNonQuery(text);

                        try
                        {
                            string from = "itadmin@dthk.kyocera.com";

                            string to = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(createdby, "kmhk.local"), "kmhk.local");

                            string subject = "IT Application has been Rejected - " + title;
                            string hostname = "Kdmail.km.local";
                            string body = "Your application has been rejected. Please review your application and submit again.\n\nApplication no. : " + chaseno;

                            SmtpClient client = new SmtpClient(hostname);
                            client.DeliveryMethod = SmtpDeliveryMethod.Network;

                            MailMessage mail = new MailMessage();
                            mail.From = new MailAddress(from, "IT Admin", Encoding.UTF8);
                            mail.To.Add(to);
                            mail.Subject = subject;
                            mail.Body = body;

                            client.Send(mail);
                        }
                        catch
                        {
                            //Debug.WriteLine("aaa");
                        }

                        continue;
                    }
                }

                if (approval != "Approve")
                    continue;

                if (tablename == "TB_CM_DEBIT")
                {
                    string cmStatus = CmUtil.GetStatus(chaseno);

                    string text = cmStatus == "係責承認中" ? string.Format("update TB_CM_DEBIT set d_status = N'科責承認中', d_sectapproval = 'Yes', d_sectdate = '{0}' where d_docno = '{1}'", now, chaseno)
                        : cmStatus == "科責承認中" ? string.Format("update TB_CM_DEBIT set d_status = N'部責承認中', d_divapproval = 'Yes', d_divdate = '{0}' where d_docno = '{1}'", now, chaseno)
                        : cmStatus == "部責承認中" ? string.Format("update TB_CM_DEBIT set d_status = N'經管確認中', d_deptapproval = 'Yes', d_deptdate = '{0}' where d_docno = '{1}'", now, chaseno)
                        : cmStatus == "經管檢查中" ? string.Format("update TB_CM_DEBIT set d_status = N'經管承認中', d_mcreviewerapproval = 'Yes', d_mcreviewerdate = '{0}' where d_docno = '{1}'", now, chaseno)
                        : string.Format("update TB_CM_DEBIT set d_status = '申請處理完成', d_mcfinalapproval = 'Yes', d_mcfinaldate = '{0}', d_debitno = '{1}' where d_docno = '{2}'", now, CmUtil.GetLatestDebitNo(), chaseno);

                    DataServiceCM.GetInstance().ExecuteNonQuery(text);

                    string to = cmStatus == "係責承認中" ? CmUtil.GetDiv(chaseno)
                        : cmStatus == "科責承認中" ? CmUtil.GetDept(chaseno)
                        : cmStatus == "部責承認中" ? CmUtil.GetMcStaff(chaseno)
                        : cmStatus == "經管檢查中" ? CmUtil.GetMcApproval(chaseno)
                        : "";

                    string applicant = CmUtil.GetApplicant(chaseno);

                    if (cmStatus == "部責承認中")
                    {
                        EformUtil.SendDebitNotificationEmail(chaseno, applicant, AdUtil.GetEmailByUsername(applicant, "kmhk.local"), AdUtil.GetEmailByUsername(to, "kmhk.local"), "Received a Debit/Credit Note Application Form\n\nPlease check in Management Console");
                    }
                    else
                    {
                        if (to != "")
                            EformUtil.SendApprovalEmail(chaseno, applicant, AdUtil.GetEmailByUsername(applicant, "kmhk.local"), AdUtil.GetEmailByUsername(to, "kmhk.local"), "", "Debit/Credit Note Application Approval Required");
                    }
                }
                else if (tablename == "TB_CM_DEBIT_CANCEL")
                {
                    string q1 = string.Format("update TB_CM_DEBIT_CANCEL set c_applicantconfirm = 'Yes', c_applicantconfirmdate = '{0}' where c_docno = '{1}' and c_applicant = N'{2}'", now, chaseno, GlobalService.User);
                    string q2 = string.Format("update TB_CM_DEBIT_CANCEL set c_sectconfirm = 'Yes', c_sectconfirmdate = '{0}' where c_docno = '{1}' and c_sect = N'{2}'", now, chaseno, GlobalService.User);
                    string q3 = string.Format("update TB_CM_DEBIT_CANCEL set c_divconfirm = 'Yes', c_divconfirmdate = '{0}' where c_docno = '{1}' and c_div = N'{2}'", now, chaseno, GlobalService.User);
                    string q4 = string.Format("update TB_CM_DEBIT_CANCEL set c_deptconfirm = 'Yes', c_deptconfirmdate = '{0}' where c_docno = '{1}' and c_dept = N'{2}'", now, chaseno, GlobalService.User);
                    string q5 = string.Format("update TB_CM_DEBIT_CANCEL set c_targetsectconfirm = 'Yes', c_targetsectconfirmdate = '{0}' where c_docno = '{1}' and c_targetsect = N'{2}'", now, chaseno, GlobalService.User);
                    string q6 = string.Format("update TB_CM_DEBIT_CANCEL set c_targetdeptconfirm = 'Yes', c_targetdeptconfirmdate = '{0}' where c_docno = '{1}' and c_targetdept = N'{2}'", now, chaseno, GlobalService.User);

                    DataServiceCM.GetInstance().ExecuteNonQuery(q1);
                    DataServiceCM.GetInstance().ExecuteNonQuery(q2);
                    DataServiceCM.GetInstance().ExecuteNonQuery(q3);
                    DataServiceCM.GetInstance().ExecuteNonQuery(q4);
                    DataServiceCM.GetInstance().ExecuteNonQuery(q5);
                    DataServiceCM.GetInstance().ExecuteNonQuery(q6);

                    string q7 = "update TB_CM_DEBIT_CANCEL set c_status = N'已取消' where c_applicantconfirm = 'Yes' and c_sectconfirm = 'Yes' and c_divconfirm = 'Yes' and c_deptconfirm = 'Yes'" +
                        " and ((c_targetsect != '-' and c_targetsectconfirm = 'Yes') or c_targetsect = '-') and ((c_targetdept != '-' and c_targetdeptconfirm = 'Yes' or c_targetdept = '-')";

                    DataServiceCM.GetInstance().ExecuteNonQuery(q7);
                }
                else if (tablename == "TB_ACC_OUTSTANDING")
                {
                    isSent = false;

                    string text = string.Format("select o_status from TB_ACC_OUTSTANDING where o_invoice = '{0}'", chaseno);
                    string accStatus = DataServiceCM.GetInstance().ExecuteScalar(text).ToString().Trim();

                    //string deptText = string.Format("select o_dept from TB_ACC_OUTSTANDING where o_invoice = '{0}'", chaseno);
                    //string dept = DataServiceCM.GetInstance().ExecuteScalar(deptText).ToString().Trim();

                    string query = accStatus=="係責承認中"? string.Format("update TB_ACC_OUTSTANDING set o_sectapproval = 'Yes', o_sectapprovaldate = '{0}', o_status = '科責承認中' where o_invoice = '{1}'", now, chaseno)
                    :accStatus == "科責承認中" ? string.Format("update TB_ACC_OUTSTANDING set o_divapproval = 'Yes', o_divapprovaldate = '{0}', o_status = N'待打印' where o_invoice = '{1}'", now, chaseno)
                        : string.Format("update TB_ACC_OUTSTANDING set o_accapproval = 'Yes', o_accapprovaldate = '{0}', o_status = N'申請處理完成' where o_invoice = '{1}'", now, chaseno);

                    DataServiceCM.GetInstance().ExecuteNonQuery(query);

                    string applicant = AccUtil.GetApplicant(chaseno);

                    //string content = "Application Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
                    //string body = "<p><span style=\"font-family: Calibri;\">" + content + "</span></p>";

                    if (accStatus == "係責承認中")
                    {
                        string sectApprover = AccUtil.GetSectionApprover(chaseno);///****
                        if (!emailList.Contains(emailList.Find(x => x.To == sectApprover)))
                            emailList.Add(new EmailSentData { From = applicant, To = sectApprover });
                    }

                    if (accStatus == "科責承認中")
                    {
                        if (!approvedList.Contains(approvedList.Find(x => x.To == applicant)))///***
                            approvedList.Add(new ApprovedData { From = AccUtil.GetDivisionApprover(chaseno), To = applicant });
                    }
                }
                else if (tablename == "TB_ADM_FORM_KEY")
                {
                    string text = string.Format("select ak_status from TB_ADM_FORM_KEY where ak_id = '{0}'", chaseno);
                    string keyStatus = DataServiceCM.GetInstance().ExecuteScalar(text).ToString().Trim();

                    string query = keyStatus == "係責承認中" ? string.Format("update TB_ADM_FORM_KEY set ak_status = N'科責承認中', ak_sectapp = 'Yes', ak_sectapptime = '{0}' where ak_id = '{1}'", now, chaseno)
                        : keyStatus == "科責承認中" ? string.Format("update TB_ADM_FORM_KEY set ak_status = N'行政係責承認中', ak_divapp = 'Yes', ak_divapptime = '{0}' where ak_id = '{1}'", now, chaseno)
                        : keyStatus == "行政係責承認中" ? string.Format("update TB_ADM_FORM_KEY set ak_status = N'行政科責承認中', ak_adm1stapp = 'Yes', ak_adm1stdate = '{0}' where ak_id = '{1}'", now, chaseno)
                        : keyStatus == "行政科責承認中" ? string.Format("update TB_ADM_FORM_KEY set ak_status = N'行政處理中', ak_adm2ndapp = 'Yes', ak_adm2nddate = '{0}' where ak_id = '{1}'", now, chaseno) : "";

                    DataServiceCM.GetInstance().ExecuteNonQuery(query);

                    string applicant = "", sect = "", div = "", adm1st = "", adm2nd = "";

                    string usText = string.Format("select ak_createdby, ak_sect, ak_div, ak_adm1st, ak_adm2nd from TB_ADM_FORM_KEY where ak_id = '{0}'", chaseno);
                    using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(usText))
                    {
                        while (reader.Read())
                        {
                            applicant = reader.GetString(0).Trim();
                            sect = reader.GetString(1).Trim();
                            div = reader.GetString(2).Trim();
                            adm1st = reader.GetString(3).Trim();
                            adm2nd = reader.GetString(4).Trim();
                        }
                    }

                    if (keyStatus == "係責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(sect), "", "Approval required for 複製鎖匙申請");
                    if (keyStatus == "科責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(div), "", "Approval required for 複製鎖匙申請");
                    if (keyStatus == "行政係責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(adm1st), "", "Approval required for 複製鎖匙申請");
                    if (keyStatus == "行政科責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(adm2nd), "", "Approval required for 複製鎖匙申請");

                }
                else if (tablename == "TB_ADM_FORM_LIFT")
                {
                    string text = string.Format("select al_status from TB_ADM_FORM_LIFT where al_id = '{0}'", chaseno);
                    string liftStatus = DataServiceCM.GetInstance().ExecuteScalar(text).ToString().Trim();

                    string query = liftStatus == "係責承認中" ? string.Format("update TB_ADM_FORM_LIFT set al_status = N'科責承認中', al_sectapp = 'Yes', al_sectapptime = '{0}' where al_id = '{1}'", now, chaseno)
                        : liftStatus == "科責承認中" ? string.Format("update TB_ADM_FORM_LIFT set al_status = N'行政係責承認中', al_divapp = 'Yes', al_divapptime = '{0}' where al_id = '{1}'", now, chaseno)
                        : liftStatus == "行政係責承認中" ? string.Format("update TB_ADM_FORM_LIFT set al_status = N'行政科責承認中', al_adm1stapp = 'Yes', al_adm1stdate = '{0}' where al_id = '{1}'", now, chaseno)
                        : liftStatus == "行政科責承認中" ? string.Format("update TB_ADM_FORM_LIFT set al_status = N'行政處理中', al_adm2ndapp = 'Yes', al_adm2nddate = '{0}' where al_id = '{1}'", now, chaseno) : "";

                    DataServiceCM.GetInstance().ExecuteNonQuery(query);

                    string applicant = "", sect = "", div = "", adm1st = "", adm2nd = "";

                    string usText = string.Format("select al_createdby, al_sect, al_div, al_adm1st, al_adm2nd from TB_ADM_FORM_LIFT where al_id = '{0}'", chaseno);
                    using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(usText))
                    {
                        while (reader.Read())
                        {
                            applicant = reader.GetString(0).Trim();
                            sect = reader.GetString(1).Trim();
                            div = reader.GetString(2).Trim();
                            adm1st = reader.GetString(3).Trim();
                            adm2nd = reader.GetString(4).Trim();
                        }
                    }

                    if (liftStatus == "係責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(sect), "", "Approval required for 使用載貨升降機");
                    if (liftStatus == "科責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(div), "", "Approval required for 使用載貨升降機");
                    if (liftStatus == "行政係責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(adm1st), "", "Approval required for 使用載貨升降機");
                    if (liftStatus == "行政科責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(adm2nd), "", "Approval required for 使用載貨升降機");
                }
                else if (tablename == "TB_ADM_FORM_PARK")
                {
                    string text = string.Format("select ap_status from TB_ADM_FORM_PARK where ap_id = '{0}'", chaseno);
                    string liftStatus = DataServiceCM.GetInstance().ExecuteScalar(text).ToString().Trim();

                    string query = liftStatus == "係責承認中" ? string.Format("update TB_ADM_FORM_PARK set ap_status = N'科責承認中', ap_sectapp = 'Yes', ap_sectapptime = '{0}' where ap_id = '{1}'", now, chaseno)
                        : liftStatus == "科責承認中" ? string.Format("update TB_ADM_FORM_PARK set ap_status = N'行政係責承認中', ap_divapp = 'Yes', ap_divapptime = '{0}' where ap_id = '{1}'", now, chaseno)
                        : liftStatus == "行政係責承認中" ? string.Format("update TB_ADM_FORM_PARK set ap_status = N'行政科責承認中', ap_adm1stapp = 'Yes', ap_adm1stdate = '{0}' where ap_id = '{1}'", now, chaseno)
                        : liftStatus == "行政科責承認中" ? string.Format("update TB_ADM_FORM_PARK set ap_status = N'行政處理中', ap_adm2ndapp = 'Yes', ap_adm2nddate = '{0}' where ap_id = '{1}'", now, chaseno) : "";

                    DataServiceCM.GetInstance().ExecuteNonQuery(query);

                    string applicant = "", sect = "", div = "", adm1st = "", adm2nd = "";

                    string usText = string.Format("select ap_createdby, ap_sect, ap_div, ap_adm1st, ap_adm2nd from TB_ADM_FORM_PARK where ap_id = '{0}'", chaseno);
                    using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(usText))
                    {
                        while (reader.Read())
                        {
                            applicant = reader.GetString(0).Trim();
                            sect = reader.GetString(1).Trim();
                            div = reader.GetString(2).Trim();
                            adm1st = reader.GetString(3).Trim();
                            adm2nd = reader.GetString(4).Trim();
                        }
                    }

                    if (liftStatus == "係責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(sect), "", "Approval required for 訪客車位");
                    if (liftStatus == "科責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(div), "", "Approval required for 訪客車位");
                    if (liftStatus == "行政係責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(adm1st), "", "Approval required for 訪客車位");
                    if (liftStatus == "行政科責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(adm2nd), "", "Approval required for 訪客車位");
                }
                else if (tablename == "TB_ADM_FORM_PURCHASE")
                {
                    string text = string.Format("select ap_status from TB_ADM_FORM_PURCHASE where ap_id = '{0}'", chaseno);
                    string liftStatus = DataServiceCM.GetInstance().ExecuteScalar(text).ToString().Trim();

                    string query = liftStatus == "係責承認中" ? string.Format("update TB_ADM_FORM_PURCHASE set ap_status = N'科責承認中', ap_sectapp = 'Yes', ap_sectapptime = '{0}' where ap_id = '{1}'", now, chaseno)
                        : liftStatus == "科責承認中" ? string.Format("update TB_ADM_FORM_PURCHASE set ap_status = N'行政係責承認中', ap_divapp = 'Yes', ap_divapptime = '{0}' where ap_id = '{1}'", now, chaseno)
                        : liftStatus == "行政係責承認中" ? string.Format("update TB_ADM_FORM_PURCHASE set ap_status = N'行政科責承認中', ap_adm1stapp = 'Yes', ap_adm1stdate = '{0}' where ap_id = '{1}'", now, chaseno)
                        : liftStatus == "行政科責承認中" ? string.Format("update TB_ADM_FORM_PURCHASE set ap_status = N'行政處理中', ap_adm2ndapp = 'Yes', ap_adm2nddate = '{0}' where ap_id = '{1}'", now, chaseno) : "";

                    DataServiceCM.GetInstance().ExecuteNonQuery(query);

                    string applicant = "", sect = "", div = "", adm1st = "", adm2nd = "";

                    string usText = string.Format("select ap_createdby, ap_sect, ap_div, ap_adm1st, ap_adm2nd from TB_ADM_FORM_PURCHASE where ap_id = '{0}'", chaseno);
                    using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(usText))
                    {
                        while (reader.Read())
                        {
                            applicant = reader.GetString(0).Trim();
                            sect = reader.GetString(1).Trim();
                            div = reader.GetString(2).Trim();
                            adm1st = reader.GetString(3).Trim();
                            adm2nd = reader.GetString(4).Trim();
                        }
                    }

                    if (liftStatus == "係責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(sect), "", "Approval required for 購買依賴");
                    if (liftStatus == "科責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(div), "", "Approval required for 購買依賴");
                    if (liftStatus == "行政係責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(adm1st), "", "Approval required for 購買依賴");
                    if (liftStatus == "行政科責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(adm2nd), "", "Approval required for 購買依賴");
                }
                else if (tablename == "TB_ADM_FORM_REPAIR")
                {
                    string text = string.Format("select ar_status from TB_ADM_FORM_REPAIR where ar_id = '{0}'", chaseno);
                    string liftStatus = DataServiceCM.GetInstance().ExecuteScalar(text).ToString().Trim();

                    string query = liftStatus == "係責承認中" ? string.Format("update TB_ADM_FORM_REPAIR set ar_status = N'科責承認中', ar_sectapp = 'Yes', ar_sectapptime = '{0}' where ar_id = '{1}'", now, chaseno)
                        : liftStatus == "科責承認中" ? string.Format("update TB_ADM_FORM_REPAIR set ar_status = N'行政係責承認中', ar_divapp = 'Yes', ar_divapptime = '{0}' where ar_id = '{1}'", now, chaseno)
                        : liftStatus == "行政係責承認中" ? string.Format("update TB_ADM_FORM_REPAIR set ar_status = N'行政科責承認中', ar_adm1stapp = 'Yes', ar_adm1stdate = '{0}' where ar_id = '{1}'", now, chaseno)
                        : liftStatus == "行政科責承認中" ? string.Format("update TB_ADM_FORM_REPAIR set ar_status = N'行政處理中', ar_adm2ndapp = 'Yes', ar_adm2nddate = '{0}' where ar_id = '{1}'", now, chaseno) : "";

                    DataServiceCM.GetInstance().ExecuteNonQuery(query);

                    string applicant = "", sect = "", div = "", adm1st = "", adm2nd = "";

                    string usText = string.Format("select ar_createdby, ar_sect, ar_div, ar_adm1st, ar_adm2nd from TB_ADM_FORM_REPAIR where ar_id = '{0}'", chaseno);
                    using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(usText))
                    {
                        while (reader.Read())
                        {
                            applicant = reader.GetString(0).Trim();
                            sect = reader.GetString(1).Trim();
                            div = reader.GetString(2).Trim();
                            adm1st = reader.GetString(3).Trim();
                            adm2nd = reader.GetString(4).Trim();
                        }
                    }

                    if (liftStatus == "係責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(sect), "", "Approval required for 維修依賴");
                    if (liftStatus == "科責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(div), "", "Approval required for 維修依賴");
                    if (liftStatus == "行政係責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(adm1st), "", "Approval required for 維修依賴");
                    if (liftStatus == "行政科責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(adm2nd), "", "Approval required for 維修依賴");
                }
                else if (tablename == "TB_ADM_FORM_STAMP")
                {
                    string text = string.Format("select as_status from TB_ADM_FORM_STAMP where as_id = '{0}'", chaseno);
                    string stampStatus = DataServiceCM.GetInstance().ExecuteScalar(text).ToString().Trim();

                    string query = stampStatus == "係責承認中" ? string.Format("update TB_ADM_FORM_STAMP set as_status = N'科責承認中', as_sectapp = 'Yes', as_sectapptime = '{0}' where as_id = '{1}'", now, chaseno)
                        : stampStatus == "科責承認中" ? string.Format("update TB_ADM_FORM_STAMP set as_status = N'行政係責承認中', as_divapp = 'Yes', as_divapptime = '{0}' where as_id = '{1}'", now, chaseno)
                        : stampStatus == "行政係責承認中" ? string.Format("update TB_ADM_FORM_STAMP set as_status = N'行政科責承認中', as_adm1stapp = 'Yes', as_adm1stdate = '{0}' where as_id = '{1}'", now, chaseno)
                        : stampStatus == "行政科責承認中" ? string.Format("update TB_ADM_FORM_STAMP set as_status = N'行政處理中', as_adm2ndapp = 'Yes', as_adm2nddate = '{0}' where as_id = '{1}'", now, chaseno) : "";

                    DataServiceCM.GetInstance().ExecuteNonQuery(query);

                    string applicant = "", sect = "", div = "", adm1st = "", adm2nd = "";

                    string usText = string.Format("select as_createdby, as_sect, as_div, as_adm1st, as_adm2nd from TB_ADM_FORM_STAMP where as_id = '{0}'", chaseno);
                    using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(usText))
                    {
                        while (reader.Read())
                        {
                            applicant = reader.GetString(0).Trim();
                            sect = reader.GetString(1).Trim();
                            div = reader.GetString(2).Trim();
                            adm1st = reader.GetString(3).Trim();
                            adm2nd = reader.GetString(4).Trim();
                        }
                    }

                    if (stampStatus == "係責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(sect), "", "Approval required for 購買郵票");
                    if (stampStatus == "科責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(div), "", "Approval required for 購買郵票");
                    if (stampStatus == "行政係責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(adm1st), "", "Approval required for 購買郵票");
                    if (stampStatus == "行政科責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(adm2nd), "", "Approval required for 購買郵票");
                }
                else if (tablename == "TB_ADM_FORM_VISA")
                {
                    string text = string.Format("select av_status from TB_ADM_FORM_VISA where av_id = '{0}'", chaseno);
                    string stampStatus = DataServiceCM.GetInstance().ExecuteScalar(text).ToString().Trim();

                    string query = stampStatus == "係責承認中" ? string.Format("update TB_ADM_FORM_VISA set av_status = N'科責承認中', av_sectapp = 'Yes', av_sectapptime = '{0}' where av_id = '{1}'", now, chaseno)
                        : stampStatus == "科責承認中" ? string.Format("update TB_ADM_FORM_VISA set av_status = N'行政係責承認中', av_divapp = 'Yes', av_divapptime = '{0}' where av_id = '{1}'", now, chaseno)
                        : stampStatus == "行政係責承認中" ? string.Format("update TB_ADM_FORM_VISA set av_status = N'行政科責承認中', av_adm1stapp = 'Yes', av_adm1stdate = '{0}' where av_id = '{1}'", now, chaseno)
                        : stampStatus == "行政科責承認中" ? string.Format("update TB_ADM_FORM_VISA set av_status = N'行政處理中', av_adm2ndapp = 'Yes', av_adm2nddate = '{0}' where av_id = '{1}'", now, chaseno) : "";

                    DataServiceCM.GetInstance().ExecuteNonQuery(query);

                    string applicant = "", sect = "", div = "", adm1st = "", adm2nd = "";

                    string usText = string.Format("select av_createdby, av_sect, av_div, av_adm1st, av_adm2nd from TB_ADM_FORM_VISA where av_id = '{0}'", chaseno);
                    using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(usText))
                    {
                        while (reader.Read())
                        {
                            applicant = reader.GetString(0).Trim();
                            sect = reader.GetString(1).Trim();
                            div = reader.GetString(2).Trim();
                            adm1st = reader.GetString(3).Trim();
                            adm2nd = reader.GetString(4).Trim();
                        }
                    }

                    if (stampStatus == "係責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(sect), "", "Approval required for 簽証申請");
                    if (stampStatus == "科責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(div), "", "Approval required for 簽証申請");
                    if (stampStatus == "行政係責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(adm1st), "", "Approval required for 簽証申請");
                    if (stampStatus == "行政科責承認中") EformUtil.SendApprovalEmail("-", applicant, AdmUtil.GetEmail(applicant), AdmUtil.GetEmail(adm2nd), "", "Approval required for 簽証申請");
                }
                else
                {
                    string strItApproval = string.Empty;
                    string strItApprovalDate = string.Empty;

                    string query = string.Empty;
                    if (tablename == "TB_FORM_PERMISSION")
                    {
                        //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        string strSql = string.Format("SELECT p_itapproval, ISNULL(p_itapprovaldate, '') FROM TB_FORM_PERMISSION WHERE p_chaseno = '{0}'", chaseno);

                        using (IDataReader reader = DataService.GetInstance().ExecuteReader(strSql))
                        {
                            while (reader.Read())
                            {
                                strItApproval = reader.GetString(0).Trim();
                                strItApprovalDate = reader.GetString(1).Trim();
                            }
                        }

                        if (strItApproval == GlobalService.User && strItApprovalDate == string.Empty)
                        {
                            query = string.Format("update " + tablename + " set p_itapprovaldate = '{0}' where p_chaseno = '{1}'", now, chaseno);
                        }
                        else
                        { 
                            query = string.Format("update " + tablename + " set p_approval = 'Yes', p_approvaldate = '{0}', p_status = N'申請已發送' where p_chaseno = '{1}'", now, chaseno);
                        }
                    }
                    else
                    {
                        query = tablename == "TB_FORM_LOANING" ? string.Format("update " + tablename + " set l_approval = 'Yes', l_approvaldate = '{0}', l_status = N'申請已發送' where l_chaseno = '{1}'", now, chaseno)
                            : tablename == "TB_FORM_DEVELOP" ? string.Format("update " + tablename + " set d_approval = 'Yes', d_approvaldate = '{0}', d_status = N'申請已發送' where d_chaseno = '{1}'", now, chaseno)
                            : tablename == "TB_FORM_R3" && status == "上司承認中" ? string.Format("update " + tablename + " set r_approval = 'Yes', r_status = N'申請已發送' where r_chaseno = '{0}' and r_status = N'上司承認中'", chaseno)
                                : tablename == "TB_FORM_R3" && status == "經管承認中" ? string.Format("update " + tablename + " set r_cmapproval = 'Yes', r_status = N'申請處理完成' where r_chaseno = '{0}' and r_status = N'經管承認中'", chaseno)
                            : string.Format("update TB_FORM set f_approval = 'Approve', f_approvaldate = '{0}', f_status = N'申請已發送' where f_chaseno = '{1}'", now, chaseno);
                    }
                    //string query = tablename == "TB_FORM_PERMISSION" ? string.Format("update " + tablename + " set p_approval = 'Yes', p_approvaldate = '{0}', p_status = N'申請已發送' where p_chaseno = '{1}'", now, chaseno)
                    //    : tablename == "TB_FORM_LOANING" ? string.Format("update " + tablename + " set l_approval = 'Yes', l_approvaldate = '{0}', l_status = N'申請已發送' where l_chaseno = '{1}'", now, chaseno)
                    //    : tablename == "TB_FORM_DEVELOP" ? string.Format("update " + tablename + " set d_approval = 'Yes', d_approvaldate = '{0}', d_status = N'申請已發送' where d_chaseno = '{1}'", now, chaseno)
                    //    : tablename == "TB_FORM_R3" && status == "上司承認中" ? string.Format("update " + tablename + " set r_approval = 'Yes', r_status = N'申請已發送' where r_chaseno = '{0}' and r_status = N'上司承認中'", chaseno)
                    //        : tablename == "TB_FORM_R3" && status == "經管承認中" ? string.Format("update " + tablename + " set r_cmapproval = 'Yes', r_status = N'申請處理完成' where r_chaseno = '{0}' and r_status = N'經管承認中'", chaseno)
                    //    : string.Format("update TB_FORM set f_approval = 'Approve', f_approvaldate = '{0}', f_status = N'申請已發送' where f_chaseno = '{1}'", now, chaseno);

                    //string query = string.Format("update TB_FORM set f_approval = 'Approve', f_approvaldate = '{0}', f_status = N'{1}' where f_id = '{2}'", now, "IT 已接收", id);

                    //Debug.WriteLine("Query: " + query);
                    DataService.GetInstance().ExecuteNonQuery(query);

                    if (!type.StartsWith("R3"))
                    {
                        string from2 = "itadmin@dthk.kyocera.com";

                        string to2 = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(createdby, "kmhk.local"), "kmhk.local");

                        string subject2 = "IT Application Submitted - " + title;
                        string hostname2 = "Kdmail.km.local";
                        string body2 = "We have received your application and will process it as soon as possible.\n\nApplication no. : " + chaseno;

                        SmtpClient client2 = new SmtpClient(hostname2);
                        client2.DeliveryMethod = SmtpDeliveryMethod.Network;

                        MailMessage mail2 = new MailMessage();
                        mail2.From = new MailAddress(from2, "IT Admin", Encoding.UTF8);
                        mail2.To.Add(to2);
                        mail2.Subject = subject2;
                        mail2.Body = body2;

                        client2.Send(mail2);

                        string q1 = type == "權限及軟件安裝" ? string.Format("select f_content from TB_FORM_PERMISSION, TB_FORM where f_chaseno =  p_refno and p_chaseno = '{0}'", chaseno)
                            : type == "資產外借" ? string.Format("select f_content from TB_FORM_LOANING, TB_FORM where f_chaseno = l_refno and l_chaseno = '{0}'", chaseno)
                            : type == "工具開發/修改" ? string.Format("select f_content from TB_FORM_DEVELOP, TB_FORM where f_chaseno = d_refno and d_chaseno = '{0}'", chaseno)
                            : string.Format("select f_content from TB_FORM where f_chaseno = '{0}'", chaseno);

                        //RichTextBox rtb = new RichTextBox();
                        RtfPrintUtil rtb = new RtfPrintUtil();
                        using (IDataReader reader = DataService.GetInstance().ExecuteReader(q1))
                        {
                            while (reader.Read())
                            {
                                Byte[] content = new Byte[Convert.ToInt32((reader.GetBytes(0, 0, null, 0, Int32.MaxValue)))];
                                long bytesReceived = reader.GetBytes(0, 0, content, 0, content.Length);
                                ASCIIEncoding encoding = new ASCIIEncoding();
                                rtb.Rtf = encoding.GetString(content, 0, Convert.ToInt32(bytesReceived));
                            }
                        }

                        EformUtil.SendNotificationEmail(chaseno, type, createdby, to2, title, rtb.Rtf, 600, 400, rtb);
                    }
                    else
                    {
                        if (status == "上司承認中")
                        {
                            string mail = AdUtil.GetEmailByUsername(createdby, "kmhk.local");
                            EformUtil.SendR3NotificationEmail(chaseno, "R3申請", createdby, mail, title, EformUtil.GetR3Id(chaseno), EformUtil.GetR3Request(chaseno), EformUtil.GetR3Reason(chaseno));
                        }
                        else
                        {
                            string mail = AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local");
                            EformUtil.SendR3FinishedEmail(mail, GlobalService.User, chaseno, "R3申請", EformUtil.GetR3Id(chaseno), EformUtil.GetR3Request(chaseno), EformUtil.GetR3Reason(chaseno));
                        }
                    }
                }
            }

            string accContent = "Application Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
            string accBody = "<p><span style=\"font-family: Calibri;\">" + accContent + "</span></p>";

            if (emailList.Count > 0)
            {
                foreach (EmailSentData item in emailList)
                    EformUtil.SendApprovalEmail("", item.From, AdUtil.GetEmailByUsername(item.From, "kmhk.local"), AdUtil.GetEmailByUsername(item.To, "kmhk.local"), accBody, "Outstanding Slip");
            }

            if (approvedList.Count > 0)
            {
                foreach (ApprovedData item in approvedList)
                    EformUtil.SendOutstandingApprovedEmail("", item.From, AdUtil.GetEmailByUsername(item.From, "kmhk.local"), AdUtil.GetEmailByUsername(item.To, "kmhk.local"), "");
            }

            LoadData3();

            if (SaveEvent != null)
                SaveEvent(this, new EventArgs());
        }

        private void dgvForm_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if (e.Column.ValueType == typeof(byte[]))
            {
                DataGridViewColumn column = new VirtualDataGridViewColumn(e.Column);
                column.ValueType = typeof(string);
                column.Name = e.Column.Name;
                column.DisplayIndex = e.Column.DisplayIndex;
                column.CellTemplate = new DataGridViewTextBoxCell();
                column.DataPropertyName = e.Column.DataPropertyName;
                column.SortMode = DataGridViewColumnSortMode.Programmatic;

                e.Column.DataGridView.Columns.Add(column);
                e.Column.Visible = false;
            }
        }

        private void dgvForm_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Columns[e.ColumnIndex] is VirtualDataGridViewColumn)
            {
                VirtualDataGridViewColumn column = dgv.Columns[e.ColumnIndex] as VirtualDataGridViewColumn;
                DataRow row = (dgv.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                e.Value = row[column.OriginalColumn.Name];
            }

            if (e.Value is byte[])
            {
                e.Value = "0x" + BitConverter.ToString(e.Value as byte[]).Replace("-", "");
                e.FormattingApplied = true;
            }
        }

        private void dgvForm_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void dgvForm_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.RowIndex != -1)
               // dgvForm.Rows[e.RowIndex].Height = dgvForm.Columns.GetFirstColumn(DataGridViewElementStates.Displayed).Width;
        }

        private void dgvForm_DoubleClick(object sender, EventArgs e)
        {
            if (dgvForm.SelectedRows == null)
                return;

            string type = dgvForm.SelectedRows[0].Cells[2].Value.ToString();
            string chaseno = dgvForm.SelectedRows[0].Cells[1].Value.ToString();

            if (type.StartsWith("R3"))
            {
                FormR3Info form = new FormR3Info(chaseno);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData3();
                }
            }
            else if (type.StartsWith("Debit"))
            {
                DebitCreditNoteFormView2 form = new DebitCreditNoteFormView2(chaseno, "approval");
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData3();
            }
            else if (type.StartsWith("Outstanding"))
            {
                OutstandingViewForm form = new OutstandingViewForm(chaseno);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData3();
            }
            else
            {
                FormInfo form = new FormInfo(type, chaseno);
                if (form.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void dgvApprove_DoubleClick(object sender, EventArgs e)
        {
            if (dgvApprove.SelectedRows == null)
                return;

            string type = dgvApprove.SelectedRows[0].Cells[2].Value.ToString();
            string chaseno = dgvApprove.SelectedRows[0].Cells[1].Value.ToString();

            if (type.StartsWith("R3"))
            {
                FormR3Info form = new FormR3Info(chaseno);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData3();
                }
            }
            else if (type.StartsWith("Debit"))
            {
                DebitCreditNoteFormView2 form = new DebitCreditNoteFormView2(chaseno, "approval");
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData3();
            }
            else if (type.StartsWith("Outstanding"))
            {
                OutstandingViewForm form = new OutstandingViewForm(chaseno);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData3();
            }
            else
            {
                FormInfo form = new FormInfo(type, chaseno);
                if (form.ShowDialog() == DialogResult.OK)
                {

                }
            }
        }

        private void dgvApprove_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
           // Debug.WriteLine(e.Context);
        }

        private void dgvApprove_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource1.Filter = dgvApprove.FilterString;
        }

        private void dgvApprove_SortStringChanged(object sender, EventArgs e)
        {
            bindingSource1.Sort = dgvApprove.SortString;
        }
    }

    public class EmailSentData
    {
        public string From { get; set; }

        public string To { get; set; }
    }

    public class ApprovedData
    {
        public string From { get; set; }

        public string To { get; set; }
    }
}
