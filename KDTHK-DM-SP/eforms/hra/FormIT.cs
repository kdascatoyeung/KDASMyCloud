using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomUtil.utils.authentication;
using KDTHK_DM_SP.services;
using KDTHK_DM_SP.utils;
using System.Data.SqlClient;
using System.Data.Linq;
using System.IO;
using System.Diagnostics;
using KDTHK_DM_SP.controls;

namespace KDTHK_DM_SP.eforms.hra
{
    public partial class FormIT : UserControl
    {
        public FormIT()
        {
            InitializeComponent();

            LoadData();

            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            
        }

        private void LoadData()
        {
            DataTable table = new DataTable();
            string[] headers = { "st", "type", "title", "startdate", "enddate", "created", "approver" };
            foreach (string header in headers)
                table.Columns.Add(header);
            table.Columns.Add("approval", typeof(Image));
            table.Columns.Add("refno", typeof(string));

            string query = string.Format("select f_status, f_type, f_start, f_end, f_created" +
                ", f_approver, f_approval, f_chaseno, f_title from TB_FORM where f_createdby = N'{0}' and (f_status = N'申請已發送' or f_status = N'I.T.處理中' or f_status = N'上司承認中')", GlobalService.User);

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string status = reader.GetString(0);
                    string type = reader.GetString(1);
                    string start = reader.GetString(2);
                    string end = reader.GetString(3);
                    string created = reader.GetString(4);
                    string approver = reader.GetString(5);
                    string approval = reader.GetString(6);
                    string chaseno = reader.GetString(7);
                    string title = reader.GetString(8);

                    Image app = approval == "Approve" ? Properties.Resources.tick : approval == "Reject" ? Properties.Resources.cross : Properties.Resources.minus_gray;

                    table.Rows.Add(status, type, title, start, end, created, approver, app, chaseno);

                }
            }

            LoadFormData(table);

            LoadR3Data(table);

            dgvForm.DataSource = table;
        }

        private void LoadFormData(DataTable table)
        {
            try
            {
                string[] queries = {string.Format("select s_status, s_type, f_start, f_end, f_created, f_approver, f_approval, s_chaseno, f_title from TB_FORM, TB_FORM_SUPPORT where s_chaseno = f_chaseno and f_createdby = N'{0}' and (s_status = N'申請已發送' or s_status = N'I.T.處理中' or s_status = N'上司承認中')", GlobalService.User)
                                   , string.Format("select p_status, p_category, f_start, f_end, f_created, p_approver, p_approval, p_chaseno, f_title from TB_FORM, TB_FORM_PERMISSION where p_refno = f_chaseno and f_createdby = N'{0}' and (p_status = N'申請已發送' or p_status = N'I.T.處理中' or p_status = N'上司承認中')", GlobalService.User)
                                   , string.Format("select l_status, l_type, f_start, f_end, f_created, l_approver, l_approval, l_chaseno, f_title from TB_FORM, TB_FORM_LOANING where l_refno = f_chaseno and f_createdby = N'{0}' and (l_status = N'申請已發送' or l_status = N'I.T.處理中' or l_status = N'上司承認中')", GlobalService.User)
                                   , string.Format("select d_status, d_type, f_start, f_end, f_created, d_approver, d_approval, d_chaseno, f_title from TB_FORM, TB_FORM_DEVELOP where d_refno = f_chaseno and f_createdby = N'{0}' and (d_status = N'申請已發送' or d_status = N'I.T.處理中' or d_status = N'上司承認中')", GlobalService.User)
                                   , string.Format("select c_status, c_type, f_start, f_end, f_created, f_approver, f_approval, c_chaseno, f_title from TB_FORM, TB_FORM_COMMENT where c_refno = f_chaseno and f_createdby = N'{0}' and (c_status = N'申請已發送' or c_status = N'I.T.處理中' or c_status = N'上司承認中')", GlobalService.User)};

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
                            string approver = reader.GetString(5);
                            string approval = reader.GetString(6);
                            string chaseno = reader.GetString(7);
                            string title = reader.GetString(8);

                            Image app = approval == "Approve" ? Properties.Resources.tick : approval == "Reject" ? Properties.Resources.cross : (approval == "---" || approval == "No") && approver != "---" ? Properties.Resources.exclamation_diamond : Properties.Resources.minus_gray;

                            table.Rows.Add(status, type, title, start, end, created, approver, app, chaseno);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void LoadR3Data(DataTable table)
        {
            string query = string.Format("select r_status, r_title, r_start, r_created, r_approver, r_approval, r_chaseno from TB_FORM_R3 where r_applicant = N'{0}' and r_status != N'申請處理完成' and r_status != N'申請已拒絕'", GlobalService.User);

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string status = reader.GetString(0).Trim();
                    string title = reader.GetString(1).Trim();
                    string start = reader.GetString(2).Trim();
                    string created = reader.GetString(3).Trim();
                    string approver = reader.GetString(4).Trim();
                    string approval = reader.GetString(5).Trim();
                    string chaseno = reader.GetString(6).Trim();

                    Image app = approval == "Yes" ? Properties.Resources.tick : approval == "Reject" ? Properties.Resources.cross : Properties.Resources.exclamation_diamond;

                    table.Rows.Add(status, "R3申請", title, start, "---", created, approver, app, chaseno);
                }
            }
        }

        private void tsbtnNew_Click(object sender, EventArgs e)
        {
            FormSelection form = new FormSelection();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (GlobalService.ApplicationForm == "itservice")
                {
                    FormITApplication app = new FormITApplication("new", "", "", "");
                    if (app.ShowDialog() == DialogResult.OK)
                        LoadData();
                }

                if (GlobalService.ApplicationForm == "r3application")
                {
                    FormR3Application app = new FormR3Application("new", "", "");
                    if (app.ShowDialog() == DialogResult.OK)
                        LoadData();
                }
            }

            //FormITApplication form = new FormITApplication("new");
            //if (form.ShowDialog() == DialogResult.OK)
               // LoadData();

        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private Image VarBinaryToImage(Binary binary)
        {
            var arrBinary = binary.ToArray();
            Image img = null;

            using (MemoryStream ms = new MemoryStream(arrBinary))
            {
                ms.Write(arrBinary, 0, arrBinary.Length);
                img = Image.FromStream(ms);
            }

            return img;
        }

        private Image ByteToImage(byte[] array)
        {
            byte[] data = null;
            Image img = null;
            Bitmap bmp = null;

            data = (byte[])array.Clone();

            try
            {
                MemoryStream ms = new MemoryStream(array);
                ms.Position = 0;
                img = Image.FromStream(ms);
                bmp = new Bitmap(img);
            }
            catch
            {
                throw;
            }

            return bmp;
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

                DataRow dataRow = (dgv.Rows[e.RowIndex].DataBoundItem as DataRowView).Row;
                e.Value = dataRow[column.OriginalColumn.Name];
            }

            if (e.Value is byte[])
            {
                e.Value = "0x" + BitConverter.ToString(e.Value as byte[]).Replace("-", "");
                e.FormattingApplied = true;
            }
        }

        private void dgvForm_DoubleClick(object sender, EventArgs e)
        {
            if (dgvForm.SelectedRows == null)
                return;

            string status = dgvForm.SelectedRows[0].Cells[0].Value.ToString().Trim();
            string type = dgvForm.SelectedRows[0].Cells[1].Value.ToString().Trim();
            string chaseno = dgvForm.SelectedRows[0].Cells[8].Value.ToString().Trim();

            if (type.StartsWith("R3"))
            {
                //FormR3Application form = new FormR3Application("view", chaseno, status);
                FormR3 form = new FormR3(chaseno);
                if (form.ShowDialog() == DialogResult.OK)
                    LoadData();
            }
            else
            {
                FormITApplication form = new FormITApplication("view", type, chaseno, status);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
    }
}
