using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using KDTHK_DM_SP.services;
using System.Diagnostics;
using KDTHK_DM_SP.eforms.hra;
using KDTHK_DM_SP.eforms.cm;
using KDTHK_DM_SP.eforms.acc;

namespace KDTHK_DM_SP.eforms
{
    public partial class FormHistory : UserControl
    {
        public FormHistory()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            DataTable table = new DataTable();
            string[] headers = { "st", "type", "title", "remarks", "startdate", "enddate", "created", "chaseno" };
            foreach (string header in headers)
                table.Columns.Add(header);

            string query = string.Format("select f_status, f_type, f_start, f_end, f_created, f_chaseno, f_title" +
                " from TB_FORM where f_createdby = N'{0}' and f_status = N'申請處理完成'", GlobalService.User);

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string status = reader.GetString(0);
                    string type = reader.GetString(1);
                    string start = reader.GetString(2);
                    string end = reader.GetString(3);
                    string created = reader.GetString(4);
                    string chaseno = reader.GetString(5);
                    string title = reader.GetString(6);

                    table.Rows.Add(status, type, title, start, end, created, chaseno);
                }
            }

            LoadFormData(table);

            LoadMCData(table);

            LoadACCData(table);

            bindingSource1.DataSource = table;

            dgvFormHistory.DataSource = bindingSource1;

            dgvFormHistory.Sort(dgvFormHistory.Columns[4], ListSortDirection.Ascending);
        }

        private void LoadFormData(DataTable table)
        {
            try
            {
                string[] queries = {string.Format("select s_status, s_type, f_start, f_end, f_created, s_chaseno, f_title from TB_FORM, TB_FORM_SUPPORT where s_chaseno = f_chaseno and f_createdby = N'{0}' and (s_status = N'申請處理完成' or s_status = N'上司已拒絕')", GlobalService.User)
                                   , string.Format("select p_status, p_category, f_start, f_end, f_created, p_chaseno, f_title from TB_FORM, TB_FORM_PERMISSION where p_refno = f_chaseno and f_createdby = N'{0}' and (p_status = N'申請處理完成'  or p_status = N'上司已拒絕')", GlobalService.User)
                                   , string.Format("select l_status, l_type, f_start, f_end, f_created, l_chaseno, f_title from TB_FORM, TB_FORM_LOANING where l_refno = f_chaseno and f_createdby = N'{0}' and (l_status = N'申請處理完成' or l_status = N'上司已拒絕')", GlobalService.User)
                                   , string.Format("select d_status, d_type, f_start, f_end, f_created, d_chaseno, f_title from TB_FORM, TB_FORM_DEVELOP where d_refno = f_chaseno and f_createdby = N'{0}' and (d_status = N'申請處理完成' or d_status = N'上司已拒絕')", GlobalService.User)
                                   , string.Format("select c_status, c_type, f_start, f_end, f_created, c_chaseno, f_title from TB_FORM, TB_FORM_COMMENT where c_refno = f_chaseno and f_createdby = N'{0}' and (c_status = N'申請處理完成'  or c_status = N'上司已拒絕')", GlobalService.User)
                                   , string.Format("select r_status, r_category, r_type, r_start, r_created, r_chaseno, r_title from TB_FORM_R3 where r_applicant = N'{0}' and (r_status = N'申請處理完成' or r_status = N'申請已拒絕')", GlobalService.User)};

                foreach (string query in queries)
                {
                    using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
                    {
                        while (reader.Read())
                        {
                            string status = reader.GetString(0);
                            string type = reader.GetString(1);
                            string start = reader.GetString(2);
                            string end = reader.GetString(3);
                            string created = reader.GetString(4);
                            string chaseno = reader.GetString(5);
                            string title = reader.GetString(6);

                            table.Rows.Add(status, type, title, "-", start, end, created, chaseno);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void LoadMCData(DataTable table)
        {
            string q1 = string.Format("select d_type, d_reason, d_created, d_docno, d_custcurr, d_dntotal1, d_dntotal2, d_custname, d_custcode  from TB_CM_DEBIT where d_createdby = N'{0}' and d_status = N'已發送'", GlobalService.User);

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
                    table.Rows.Add("已發送", type, title, name + " (" + code + ")", "", "", created, docno);
                }
            }
        }

        private void LoadACCData(DataTable table)
        {
            string q1 = string.Format("select o_status, o_invoice, o_created, o_currency, o_amount, o_vendorname, case o_status when N'科責承認中' then o_div when N'會計處理中' then o_staff else o_acc end from TB_ACC_OUTSTANDING" +
                " where o_createdby = N'{0}' and o_status = N'申請處理完成'", GlobalService.User);

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
                    table.Rows.Add(status, "Outstanding Slip", title, "", "", "", created, invoice);
                }
            }
        }

        private void dgvFormHistory_DoubleClick(object sender, EventArgs e)
        {
            if (dgvFormHistory.SelectedRows == null)
                return;

            string type = dgvFormHistory.SelectedRows[0].Cells[1].Value.ToString();
            string chaseno = dgvFormHistory.SelectedRows[0].Cells[7].Value.ToString();

            if (type == "IT技術支援")
            {
                FormSupport form = new FormSupport(chaseno);
                form.ShowDialog();
            }

            if (type == "IT意見箱")
            {
                FormComment form = new FormComment(chaseno);
                form.ShowDialog();
            }

            if (type == "權限關連及軟件安裝")
            {
                FormPermission form = new FormPermission(chaseno);
                form.ShowDialog();
            }

            if (type == "工具開發/修改")
            {

            }

            if (type == "資產外借")
            {

            }

            if (type == "R3申請")
            {
                FormR3 form = new FormR3(chaseno);
                form.ShowDialog();
            }

            if (type.ToLower().StartsWith("debit") || type.ToLower().StartsWith("credit"))
            {
                DebitNoteForm2 formDebit = new DebitNoteForm2(type.ToLower(), "view", chaseno);
                //DebitCreditNoteFormView2 formDebit = new DebitCreditNoteFormView2(chaseno, "view");
                if (formDebit.ShowDialog() == DialogResult.OK)
                    LoadData();
            }

            if (type.StartsWith("Outstanding"))
            {
                OutstandingViewForm formOutstanding = new OutstandingViewForm(chaseno);
                if (formOutstanding.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
        }

        private void dgvFormHistory_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (dgvFormHistory.Rows.Count > 0)
                {
                    if (((dgvFormHistory.Rows[0].Height * dgvFormHistory.Rows.Count) + dgvFormHistory.ColumnHeadersHeight) < e.Location.Y)
                        dgvFormHistory.ClearSelection();
                    else
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            var hti = dgvFormHistory.HitTest(e.X, e.Y);

                            if (dgvFormHistory.SelectedRows.Count == 1)
                            {
                                dgvFormHistory.ClearSelection();

                                if (((dgvFormHistory.Rows[0].Height * dgvFormHistory.Rows.Count) + dgvFormHistory.ColumnHeadersHeight) >= e.Location.Y)
                                    dgvFormHistory.Rows[hti.RowIndex].Selected = true;
                            }
                            else
                            {
                                if (((dgvFormHistory.Rows[0].Height * dgvFormHistory.Rows.Count) + dgvFormHistory.ColumnHeadersHeight) >= e.Location.Y)
                                    dgvFormHistory.Rows[hti.RowIndex].Selected = true;
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
            try
            {
                string type = dgvFormHistory.SelectedRows[0].Cells[1].Value.ToString().ToLower();

                if (!type.Contains("debit") && !type.Contains("credit"))
                    msDebit.Enabled = false;
                else
                    msDebit.Enabled = true;
            }
            catch { msDebit.Enabled = false; }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string refno = dgvFormHistory.SelectedRows[0].Cells[7].Value.ToString().Trim();

            string query = string.Format("select d_directory from TB_CM_DEBIT where d_docno = '{0}'", refno);
            string file = DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();

            Process.Start(file);
        }

        private void dgvFormHistory_FilterStringChanged(object sender, EventArgs e)
        {
            bindingSource1.Filter = dgvFormHistory.FilterString;
        }

        private void dgvFormHistory_SortStringChanged(object sender, EventArgs e)
        {
            bindingSource1.Sort = dgvFormHistory.SortString;
        }
    }
}
