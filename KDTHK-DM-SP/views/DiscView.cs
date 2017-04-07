using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using KDTHK_DM_SP.services;
using System.Diagnostics;
using System.IO;
using CustomUtil.utils.import;

namespace KDTHK_DM_SP.views
{
    public partial class DiscView : UserControl
    {
        DataTable DiscTable;

        public DiscView()
        {
            InitializeComponent();

            this.LoadDiscNo("all");

            //this.LoadPendingFile();

            DiscTable = new DataTable();
            DiscTable.Columns.Add("filename");

            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            tsbtnRequest.Enabled = dgvPending.Rows.Count > 0 ? true : false;
            tsbtnRemove.Enabled = dgvPending.SelectedRows.Count > 0 ? true : false;
        }

        #region Pending Files
        private void LoadPendingFile()
        {
            dgvPending.Rows.Clear();

            string query = "select d_path, d_name from LTB_DISC_PENDING";

            using (SqlCeDataReader reader = LocalDataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string path = reader.GetString(0);
                    string name = reader.GetString(1);

                    dgvPending.Rows.Add(name, path);
                }
            }
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            this.LoadPendingFile();
        }

        private void tsbtnRemove_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPending.SelectedRows)
            {
                string path = row.Cells[1].Value.ToString();

                string query = string.Format("delete from LTB_DISC_PENDING where d_path = N'{0}'", path);
                LocalDataService.GetInstance().ExecuteNonQuery(query);

                dgvPending.Rows.Remove(row);
            }
        }

        private void tsbtnRequest_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvPending.Rows)
            {
                string path = row.Cells[1].Value.ToString();

                string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                if(path.Contains("'"))
                    path = path.Replace("'", "''");

                string text = string.Format("insert into TB_DISC_REQUEST (d_datetime, d_requester, d_path) values ('{0}', N'{1}', N'{2}')", now, GlobalService.User, path);
                string query = "insert into LTB_QUERY ([q_query]) values (@text)";

                using (SqlCeCommand ceCommand = new SqlCeCommand(query, LocalDataService.GetInstance().Connection))
                {
                    ceCommand.Parameters.AddWithValue("@text", text);
                    ceCommand.ExecuteNonQuery();
                }
            }

            string delText = "delete from LTB_DISC_PENDING";
            LocalDataService.GetInstance().ExecuteNonQuery(delText);

            this.LoadPendingFile();
        }

        private void dgvPending_DoubleClick(object sender, EventArgs e)
        {
            if (dgvPending.SelectedRows == null)
                return;

            Process.Start(dgvPending.SelectedRows[0].Cells[1].Value.ToString());
        }
        #endregion

        private void LoadDiscNo(string filter)
        {
            dgvDisc.Rows.Clear();

            string folder = filter == "ipo" ? "Ipo"
                : filter == "log" ? "Logistic"
                : filter == "rps" ? "Rps"
                : filter == "hra" ? "Hra"
                : filter == "mcc" ? "Mcc"
                : filter == "cm" ? "Cm" : "";

            string[] files = folder == "" ? Directory.GetFiles(@"\\kdthk-dm1\project\IT System\DVD Record\", "*.*", SearchOption.AllDirectories)
                : Directory.GetFiles(@"\\kdthk-dm1\project\IT System\DVD Record\" + folder);

            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                dgvDisc.Rows.Add(fileName, file);
            }
        }

        private void MenuItemClicked(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            string tag = menuItem.Tag.ToString();
            string text = menuItem.Text;

            tsbtnView.Text = text;

            this.LoadDiscNo(tag);
        }

        private void dgvDisc_DoubleClick(object sender, EventArgs e)
        {
            dgvDiscView.Rows.Clear();

            pnlDisc.Enabled = true;

            string discNo = dgvDisc.SelectedRows[0].Cells[0].Value.ToString();
            string filePath = dgvDisc.SelectedRows[0].Cells[1].Value.ToString();

            lblDiscNo.Text = "Disc No. : " + discNo;

            DiscTable = ImportExcel2007.TranslateToTable(filePath);

            foreach (DataRow dr in DiscTable.Rows)
            {
                string fileName = dr.ItemArray[1].ToString();

                dgvDiscView.Rows.Add(fileName);
            }
        }

        private void SearchData(DataTable table, string source)
        {
            dgvDiscView.Rows.Clear();

            DataRow[] datarow = table.Select("filename like '%" + source + "%'");

            foreach (DataRow row in datarow)
                dgvDiscView.Rows.Add(row["filename"].ToString());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SearchData(DiscTable, txtSearch.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.SearchData(DiscTable, txtSearch.Text);
        }
    }
}
