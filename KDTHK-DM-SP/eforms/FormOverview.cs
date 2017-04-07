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
using System.Diagnostics;
using KDTHK_DM_SP.eforms.hra;
using KDTHK_DM_SP.eforms.cm;
using KDTHK_DM_SP.eforms.acc;
using KDTHK_DM_SP.forms;
using CustomUtil.utils.authentication;
using KDTHK_DM_SP.utils;
using System.IO;

namespace KDTHK_DM_SP.eforms
{
    public partial class FormOverview : UserControl
    {
        public FormOverview()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            DataTable table = new DataTable();
            string[] headers = { "st", "type", "title", "remarks", "created", "approver", "refno" };
            foreach (string header in headers)
                table.Columns.Add(header);

            LoadITData(table);

            LoadMCData(table);

            LoadACCData(table);

            LoadAdmData(table);

            bsForm.DataSource = table;

            dgvForm.DataSource = bsForm;
        }

        private void LoadITData(DataTable table)
        {
            string q1 = string.Format("select f_status, f_type, f_title, f_created, f_approver, f_chaseno from TB_FORM" +
                " where f_createdby = N'{0}' and (f_status = N'申請已發送' or f_status = N'I.T.處理中' or f_status = N'上司承認中')", GlobalService.User);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(q1))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));
            }

            string[] queries = {string.Format("select s_status, s_type, f_created, f_approver, s_chaseno, f_title from TB_FORM, TB_FORM_SUPPORT where s_chaseno = f_chaseno and f_createdby = N'{0}' and (s_status = N'申請已發送' or s_status = N'I.T.處理中' or s_status = N'上司承認中')", GlobalService.User)
                                   , string.Format("select p_status, p_category, f_created, p_approver, p_chaseno, f_title from TB_FORM, TB_FORM_PERMISSION where p_refno = f_chaseno and f_createdby = N'{0}' and (p_status = N'申請已發送' or p_status = N'I.T.處理中' or p_status = N'上司承認中')", GlobalService.User)
                                   , string.Format("select l_status, l_type, f_created, l_approver, l_chaseno, f_title from TB_FORM, TB_FORM_LOANING where l_refno = f_chaseno and f_createdby = N'{0}' and (l_status = N'申請已發送' or l_status = N'I.T.處理中' or l_status = N'上司承認中')", GlobalService.User)
                                   , string.Format("select d_status, d_type, f_created, d_approver, d_chaseno, f_title from TB_FORM, TB_FORM_DEVELOP where d_refno = f_chaseno and f_createdby = N'{0}' and (d_status = N'申請已發送' or d_status = N'I.T.處理中' or d_status = N'上司承認中')", GlobalService.User)
                                   , string.Format("select c_status, c_type, f_created, f_approver, c_chaseno, f_title from TB_FORM, TB_FORM_COMMENT where c_refno = f_chaseno and f_createdby = N'{0}' and (c_status = N'申請已發送' or c_status = N'I.T.處理中' or c_status = N'上司承認中')", GlobalService.User)};

            foreach (string query in queries)
            {
                using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
                {
                    while (reader.Read())
                        table.Rows.Add(reader.GetString(0), reader.GetString(1), reader.GetString(5), "-", reader.GetString(2), reader.GetString(3), reader.GetString(4));
                }
            }

            string q2 = string.Format("select r_status, r_title, r_created, r_approver, r_chaseno from TB_FORM_R3 where r_applicant = N'{0}' and r_status != N'申請處理完成' and r_status != N'申請已拒絕'", GlobalService.User);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(q2))
            {
                while (reader.Read())
                    table.Rows.Add(reader.GetString(0), "R3申請", reader.GetString(1), "-", reader.GetString(2), reader.GetString(3), reader.GetString(4));
            }
        }

        private void LoadMCData(DataTable table)
        {
            string q1 = string.Format("select d_type, d_reason, d_created, d_docno, d_custcurr, d_dntotal1, d_dntotal2, d_custname, d_custcode  from TB_CM_DEBIT where d_createdby = N'{0}' and d_status != N'已發送'", GlobalService.User);

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q1))
            {
                while (reader.Read())
                {
                    string type = reader.GetString(0).Trim();
                    string reason = reader.GetString(1).Trim();
                    string created = reader.GetString(2).Trim();
                    string docno = reader.GetString(3).Trim();
                    string curr = reader.GetString(4).Trim();
                    string total1 = reader.GetString(5).Trim();
                    string total2 = reader.GetString(6).Trim();
                    string name = reader.GetString(7).Trim();
                    string code = reader.GetString(8).Trim();

                    string title = reason + " (" + curr + "";
                    string total = total1 != "" ? total1 : total2;

                    title = title + total + " )";
                    table.Rows.Add("已輸入", type, title, name + "(" + code + ")", created, "-", docno);
                }
            }
        }

        private void LoadACCData(DataTable table)
        {
            string q1 = string.Format("select o_status, o_invoice, o_created, o_currency, o_amount, o_vendorname, case o_status when N'科責承認中' then o_div when N'係責承認中' then o_sect when N'部責承認中' then o_dept when N'會計處理中' then o_staff else o_acc end from TB_ACC_OUTSTANDING" +
                " where o_createdby = N'{0}' and o_status != N'申請處理完成'", GlobalService.User);

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(q1))
            {
                while (reader.Read())
                {
                    string status = reader.GetString(0).Trim();
                    string invoice = reader.GetString(1).Trim();
                    string created = reader.GetString(2).Trim();
                    string currency = reader.GetString(3).Trim();
                    string amount = reader.GetString(4).Trim();
                    string vendorname = reader.GetString(5).Trim();
                    string approver = reader.GetString(6).Trim();

                    string title = vendorname + " (" + invoice + ") (" + currency + "" + amount + ")";
                    table.Rows.Add(status, "Outstanding Slip", title, "-", created, approver, invoice);
                }
            }
        }

        private void LoadAdmData(DataTable table)
        {
            try
            {
                string keyText = string.Format("select ak_status, ak_key, ak_remarks, ak_created, ak_id, case ak_status when N'係責承認中' then ak_sect when N'科責承認中' then ak_div when N'行政係責承認中' then ak_adm1st when N'行政科責承認中' then ak_adm2nd else '-' end from TB_ADM_FORM_KEY" +
                    " where ak_createdby = N'{0}' and ak_status != N'申請處理完成'", GlobalService.User);
                using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(keyText))
                {
                    while (reader.Read())
                        table.Rows.Add(reader.GetString(0).Trim(), "複製鎖匙申請", reader.GetString(1).Trim(), reader.GetString(2).Trim(), reader.GetString(3).Trim(), reader.GetString(5).Trim(), reader.GetInt32(4));
                }

                string liftText = string.Format("select al_status, al_date, al_vendor, al_reason, al_created, al_id, case al_status when N'係責承認中' then al_sect when N'科責承認中' then al_div when N'行政係責承認中' then al_adm1st when N'行政科責承認中' then al_adm2nd else '-' end from TB_ADM_FORM_LIFT" +
                    " where al_createdby = N'{0}' and al_status != N'申請處理完成'", GlobalService.User);
                using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(liftText))
                {
                    while (reader.Read())
                        table.Rows.Add(reader.GetString(0).Trim(), "使用載貨升降機", reader.GetString(1).Trim() + "  " + reader.GetString(2).Trim(), reader.GetString(3).Trim(), reader.GetString(4).Trim(), reader.GetString(6).Trim(), reader.GetInt32(5));
                }

                string parkText = string.Format("select ap_status, ap_company, ap_license, ap_date, ap_created, ap_id, case ap_status when N'係責承認中' then ap_sect when N'科責承認中' then ap_div when N'行政係責承認中' then ap_adm1st when N'行政科責承認中' then ap_adm2nd else '-' end from TB_ADM_FORM_PARK" +
                    " where ap_createdby = N'{0}' and ap_status != N'申請處理完成'", GlobalService.User);
                using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(parkText))
                {
                    while (reader.Read())
                        table.Rows.Add(reader.GetString(0).Trim(), "訪客車位申請", reader.GetString(1).Trim() + " " + reader.GetString(2).Trim(), reader.GetString(3).Trim(), reader.GetString(4).Trim(), reader.GetString(6).Trim(), reader.GetInt32(5));
                }

                string stampText = string.Format("select as_status, as_total, as_created, as_id, case as_status when N'係責承認中' then as_sect when N'科責承認中' then as_div when N'行政係責承認中' then as_adm1st when N'行政科責承認中' then as_adm2nd else '-' end from TB_ADM_FORM_STAMP" +
                    " where as_createdby = N'{0}' and as_status != N'申請處理完成'", GlobalService.User);
                using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(stampText))
                {
                    while (reader.Read())
                        table.Rows.Add(reader.GetString(0).Trim(), "購買郵票", "$" + reader.GetString(1).Trim(), "-", reader.GetString(2).Trim(), reader.GetString(4).Trim(), reader.GetInt32(3));
                }

                string visaText = string.Format("select av_status, av_reason, av_created, av_id, case av_status when N'係責承認中' then av_sect when N'科責承認中' then av_div when N'行政係責承認中' then av_adm1st when N'行政科責承認中' then av_adm2nd else '-' end from TB_ADM_FORM_VISA" +
                    " where av_createdby = N'{0}' and av_status != N'申請處理完成'", GlobalService.User);
                using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(visaText))
                {
                    while (reader.Read())
                        table.Rows.Add(reader.GetString(0).Trim(), "簽証申請", reader.GetString(1).Trim(), "-", reader.GetString(2).Trim(), reader.GetString(4).Trim(), reader.GetInt32(3));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void tsbtnNew_Click(object sender, EventArgs e)
        {
            FormSelection formSelection = new FormSelection();
            if (formSelection.ShowDialog() == DialogResult.OK)
            {
                if (GlobalService.ApplicationForm == "itservice")
                {
                    FormITApplication form = new FormITApplication("new", "", "", "");
                    if (form.ShowDialog() == DialogResult.OK)
                        LoadData();
                }
            }
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dgvForm_DoubleClick(object sender, EventArgs e)
        {
            if (dgvForm.SelectedRows == null)
                return;

            try
            {
                string status = dgvForm.SelectedRows[0].Cells[0].Value.ToString().Trim();
                string type = dgvForm.SelectedRows[0].Cells[1].Value.ToString().Trim();
                string chaseno = dgvForm.SelectedRows[0].Cells[6].Value.ToString().Trim();

                if (type.StartsWith("R3"))
                {
                    FormR3 formR3 = new FormR3(chaseno);
                    if (formR3.ShowDialog() == DialogResult.OK)
                        LoadData();
                }
                else if (type.ToLower().StartsWith("debit") || type.ToLower().StartsWith("credit"))
                {
                    DebitNoteForm2 formDebit = new DebitNoteForm2(type.ToLower(), "view", chaseno);
                    //DebitCreditNoteFormView2 formDebit = new DebitCreditNoteFormView2(chaseno, "view");
                    if (formDebit.ShowDialog() == DialogResult.OK)
                        LoadData();
                }
                else if (type.StartsWith("Outstanding"))
                {
                    OutstandingViewForm formOutstanding = new OutstandingViewForm(chaseno);
                    if (formOutstanding.ShowDialog() == DialogResult.OK)
                        LoadData();
                }
                else
                {
                    FormITApplication form = new FormITApplication("view", type, chaseno, status);
                    if (form.ShowDialog() == DialogResult.OK)
                        LoadData();
                }
            }
            catch { }
        }

        private void dgvForm_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (dgvForm.Rows.Count > 0)
                {
                    if (((dgvForm.Rows[0].Height * dgvForm.Rows.Count) + dgvForm.ColumnHeadersHeight) < e.Location.Y)
                        dgvForm.ClearSelection();
                    else
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            var hti = dgvForm.HitTest(e.X, e.Y);

                            if (dgvForm.SelectedRows.Count == 1)
                            {
                                dgvForm.ClearSelection();

                                if (((dgvForm.Rows[0].Height * dgvForm.Rows.Count) + dgvForm.ColumnHeadersHeight) >= e.Location.Y)
                                    dgvForm.Rows[hti.RowIndex].Selected = true;
                            }
                            else
                            {
                                if (((dgvForm.Rows[0].Height * dgvForm.Rows.Count) + dgvForm.ColumnHeadersHeight) >= e.Location.Y)
                                    dgvForm.Rows[hti.RowIndex].Selected = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void msDebit_Opening(object sender, CancelEventArgs e)
        {
            bool isValid = true;

            List<string> itemList = new List<string>();

            foreach (DataGridViewRow row in dgvForm.SelectedRows)
            {
                string type = row.Cells[1].Value.ToString().Trim().ToLower();

                if (!type.Contains("debit") && !type.Contains("credit") && !type.Contains("outstanding"))
                    isValid = false;

                itemList.Add(type);
            }

            msDebit.Enabled = !isValid || dgvForm.SelectedRows.Count == 0 ? false : true;

            bool containDB = false;
            bool containOS = false;

            if (itemList.Contains("debit") || itemList.Contains("credit")) containDB = true;
            if (itemList.Contains("outstanding slip")) containOS = true;

            if (containDB && containOS)
            {
                msDebit.Items[0].Enabled = false;
                msDebit.Items[1].Enabled = false;
                msDebit.Items[2].Enabled = false;
                msDebit.Items[3].Enabled = false;
                msDebit.Items[4].Enabled = false;
            }
            else if (containDB && !containOS)
            {
                msDebit.Items[0].Enabled = true;
                msDebit.Items[1].Enabled = false;
                msDebit.Items[2].Enabled = true;
                msDebit.Items[3].Enabled = false;
                msDebit.Items[4].Enabled = false;
            }
            else if (!containDB && containOS)
            {
                msDebit.Items[0].Enabled = false;
                msDebit.Items[1].Enabled = true;
                msDebit.Items[2].Enabled = true;
                msDebit.Items[3].Enabled = true;
                msDebit.Items[4].Enabled = true;
            }
            else
            {
                msDebit.Items[0].Enabled = true;
                msDebit.Items[1].Enabled = true;
                msDebit.Items[2].Enabled = true;
                msDebit.Items[3].Enabled = true;
                msDebit.Items[4].Enabled = true;
            }
        }

        private void sendToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvForm.SelectedRows)
            {
                string refno = row.Cells[6].Value.ToString().Trim();

                string query = string.Format("update TB_CM_DEBIT set d_status = N'已發送', d_mcstatus = N'處理中' where d_docno = '{0}'", refno);
                DataServiceCM.GetInstance().ExecuteNonQuery(query);
            }

            MessageBox.Show("Record has been sent");

            LoadData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Are you sure to delete selected items?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    foreach (DataGridViewRow row in dgvForm.SelectedRows)
                    {
                        string refno = row.Cells[6].Value.ToString().Trim();

                        string text = string.Format("select o_id from TB_ACC_OUTSTANDING where o_invoice = '{0}'", refno);
                        int id = (int)DataServiceCM.GetInstance().ExecuteScalar(text);

                        string delText = string.Format("delete from TB_ACC_OUTSTANDING where o_id = '{0}'", id);

                        string delText2 = string.Format("delete from TB_ACC_OUTSTANDING_DETAIL where od_o_id = '{0}'", id);

                        DataServiceCM.GetInstance().ExecuteNonQuery(delText);

                        DataServiceCM.GetInstance().ExecuteNonQuery(delText2);
                    }

                    MessageBox.Show("Record has been deleted");

                    LoadData();
                    break;

                case DialogResult.No:
                    break;
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvForm.SelectedRows)
            {
                string refno = row.Cells[6].Value.ToString().Trim();

                string query = string.Format("select d_directory from TB_CM_DEBIT where d_docno = '{0}'", refno);
                string file = DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();

                Process.Start(file);
            }

            LoadData();
        }

        private void dgvForm_SortStringChanged(object sender, EventArgs e)
        {
            bsForm.Sort = dgvForm.SortString;
        }

        private void dgvForm_FilterStringChanged(object sender, EventArgs e)
        {
            bsForm.Filter = dgvForm.FilterString;
        }

        private void changeApproverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserHeadForm form = new UserHeadForm("user");
            if (form.ShowDialog() == DialogResult.OK)
            {
                switch (MessageBox.Show("Are you sure to change the approver to " + GlobalService.SelectedUserHead + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        foreach (DataGridViewRow row in dgvForm.SelectedRows)
                        {
                            string status = row.Cells[0].Value.ToString().Trim();
                            string refno = row.Cells[6].Value.ToString().Trim();

                            string query = status == "係責承認中" ? string.Format("update TB_ACC_OUTSTANDING set o_sect = N'{0}' where o_invoice = '{1}'", GlobalService.SelectedUserHead, refno)
                                : status == "科責承認中" ? string.Format("update TB_ACC_OUTSTANDING set o_div = N'{0}' where o_invoice = '{1}'", GlobalService.SelectedUserHead, refno)
                                : status == "部責承認中" ? string.Format("update TB_ACC_OUTSTANDING set o_dept = N'{0}' where o_invoice = '{1}'", GlobalService.SelectedUserHead, refno) : "";

                            if (query != "")
                            {
                                DataServiceCM.GetInstance().ExecuteNonQuery(query);

                                string from = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), "kmhk.local");

                                string to = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.SelectedUserHead, "kmhk.local"), "kmhk.local");

                                string text = "Outstanding Slip Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
                                string body = "<p><span style=\"font-family: Calibri;\">" + text + "</span></p>";
                                EformUtil.SendApprovalEmail(refno, GlobalService.User, from, to, body, "Outstanding Slip");
                            }
                        }

                        MessageBox.Show("Record has been saved.");

                        LoadData();
                        break;

                    case DialogResult.No:
                        break;
                }
            }
        }

        private void outstandingSlipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            foreach (DataGridViewRow row in dgvForm.SelectedRows)
            {
                string refno = row.Cells[6].Value.ToString().Trim();

                string filename = @"C:\temp\outstanding\" + refno + ".pdf";

                if (File.Exists(filename))
                    File.Delete(filename);

                Directory.CreateDirectory(@"C:\temp\outstanding");

                List<OutstandingDetailData> dataList = new List<OutstandingDetailData>();

                string text = string.Format("select od_accountcode, od_accountname, od_costcentre, od_costcentrename, od_amount, od_desc1, od_desc2, od_desc3, od_desc4, od_desc5" +
                    " from TB_ACC_OUTSTANDING, TB_ACC_OUTSTANDING_DETAIL where od_o_id = o_id and o_invoice = '{0}'", refno);

                using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(text))
                {
                    while (reader.Read())
                    {
                        string accountcode = reader.GetString(0).Trim();
                        string accountname = reader.GetString(1).Trim();
                        string costcentre = reader.GetString(2).Trim();
                        string costcentrename = reader.GetString(3).Trim();
                        string amount = reader.GetString(4).Trim();
                        string remarks1 = reader.GetString(5).Trim();
                        string remarks2 = reader.GetString(6).Trim();
                        string remarks3 = reader.GetString(7).Trim();
                        string remarks4 = reader.GetString(8).Trim();
                        string remarks5 = reader.GetString(9).Trim();

                        dataList.Add(new OutstandingDetailData { AccountCode = accountcode + " " + accountname, CostCentre = costcentre + " " + costcentrename, Amount = amount, Remarks1 = remarks1, Remarks2 = remarks2, Remarks3 = remarks3, Remarks4 = remarks4, Remarks5 = remarks5 });
                    }
                }

                string query = string.Format("select o_vendor, o_vendorname, o_inputdate, o_paymentdate, o_currency, o_amount, o_createdby, o_created, o_sect" +
                   ", o_sectapprovaldate, o_div, o_divapprovaldate, o_dept, o_deptapprovaldate from TB_ACC_OUTSTANDING where o_invoice = '{0}'", refno);

                using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
                {
                    while (reader.Read())
                    {
                        string vendor = reader.GetString(0).Trim();
                        string vendorname = reader.GetString(1).Trim();
                        string indate = reader.GetString(2).Trim();
                        string paydate = reader.GetString(3).Trim();
                        string curr = reader.GetString(4).Trim();
                        string total = reader.GetString(5).Trim();
                        string createdby = reader.GetString(6).Trim();
                        string created = reader.GetString(7).Trim();
                        string sect = reader.GetString(8).Trim();
                        string sectappdate = reader.GetString(9).Trim();
                        string div = reader.GetString(10).Trim();
                        string divappdate = reader.GetString(11).Trim();
                        string dept = reader.GetString(12).Trim();
                        string deptappdate = reader.GetString(13).Trim();

                        PdfUtil.ExportOutstandingForm(filename, vendor, vendorname, refno, indate, paydate, curr, total, createdby, created, sect, sectappdate, div, divappdate, dept, deptappdate, dataList);

                        list.Add(filename);
                    }
                }

                string directoryText = string.Format("update TB_ACC_OUTSTANDING set o_directory = N'{0}', o_status = N'會計處理中' where o_invoice = '{1}'", filename, refno);
                DataServiceCM.GetInstance().ExecuteNonQuery(directoryText);
            }

            LoadData();

            string[] files = list.ToArray();

            string destination = @"C:\temp\" + DateTime.Now.ToString("yyyyMMddHHmm") + "_outstanding.pdf";

            PdfUtil.CombinePdfs(files, destination);

            Process.Start(destination);

            
        }
    }
}
