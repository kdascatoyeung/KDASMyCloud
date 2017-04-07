using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.lists;
using KDTHK_DM_SP.utils;
using KDTHK_DM_SP.services;
using CustomUtil.utils.authentication;
using System.Diagnostics;

namespace KDTHK_DM_SP.forms
{
    public partial class ReceivedForm : Form
    {
        public ReceivedForm(List<ReceivedList> receivedList)
        {
            InitializeComponent();

            this.LoadReceivedData(receivedList);
        }

        private void LoadReceivedData(List<ReceivedList> receivedList)
        {
            dgvReceived.Rows.Clear();

            foreach (ReceivedList receivedItem in receivedList)
            {
                string fileName = receivedItem.FileName;
                string owner = receivedItem.Owner;
                string received = receivedItem.Received;
                string filePath = receivedItem.FilePath;
                string vpath = receivedItem.Vpath;

                string imgPath = filePath.ToLower();

                Image img;

                if (imgPath.EndsWith(".xls") || imgPath.EndsWith(".xlsx") || imgPath.EndsWith(".xlsm") || imgPath.EndsWith(".csv"))
                    img = Properties.Resources.excel_16;
                else if (imgPath.EndsWith(".doc") || imgPath.EndsWith(".docx"))
                    img = Properties.Resources.word_16;
                else if (imgPath.EndsWith(".ppt") || imgPath.EndsWith(".pptx"))
                    img = Properties.Resources.powerpoint_16;
                else if (imgPath.EndsWith(".png") || imgPath.EndsWith(".jpg") || imgPath.EndsWith(".gif") || imgPath.EndsWith(".tiff") || imgPath.EndsWith(".jpeg") || imgPath.EndsWith(".bmp") || imgPath.EndsWith(".tif"))
                    img = Properties.Resources.picture;
                else if (imgPath.EndsWith(".pdf"))
                    img = Properties.Resources.pdf_16;
                else if (imgPath.EndsWith(".txt"))
                    img = Properties.Resources.text;
                else if (imgPath.EndsWith(".zip"))
                    img = Properties.Resources.zip_16;
                else
                    img = Properties.Resources.windows_16;

                dgvReceived.Rows.Add("False", img, fileName, "---", owner, received, filePath, vpath, Properties.Resources.cross);
            }
        }

        private void markAllAsFavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvReceived.Rows)
                row.Cells[3].Value = "Yes";
        }

        private void removeAllFromFavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvReceived.Rows)
                row.Cells[3].Value = "---";
        }

        private void ckbAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvReceived.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                cell.Value = ckbAll.Checked ? "True" : "False";
            }
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvReceived.SelectedRows)
            {
                string favorite = row.Cells[3].Value.ToString();
                string path = row.Cells[6].Value.ToString();
                DataUtil.ReceiveData(GlobalService.RootTable, path, favorite);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void btnReceiveAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvReceived.Rows)
            {
                string favorite = row.Cells[3].Value.ToString();
                string path = row.Cells[6].Value.ToString();

                DataUtil.ReceiveData(GlobalService.RootTable, path, favorite);
            }

            this.DialogResult = DialogResult.OK;
        }

        private void dgvReceived_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                List<string> queryList = new List<string>();

                string filePath = dgvReceived.CurrentRow.Cells[6].Value.ToString();

                string sPath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

                //DataRow[] rows = GlobalService.RootTable.Select(string.Format("filepath = '{0}'", sPath));

                DataRow[] rows = (from row in GlobalService.RootTable.AsEnumerable()
                                     where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == filePath
                                     select row).ToArray();

                foreach (DataRow row in rows)
                {
                    string owner = row["fileowner"].ToString();

                    string tableName = "TB_" + AdUtil.GetUserIdByUsername(owner, "kmhk.local");

                    List<string> sharedList = DataUtil.GetSharedList(tableName, filePath);
                    sharedList.Remove(GlobalService.User);

                    string shared = string.Join(";", sharedList.ToArray());

                    string ownerText = string.Format("update " + tableName + " set r_shared = N'{0}' where r_path = N'{1}'", shared, sPath);
                    queryList.Add(ownerText);

                    string sharedText = string.Format("delete from " + GlobalService.DbTable + " where r_path = N'{0}'", sPath);
                    queryList.Add(sharedText);

                    row.Delete();
                }

                foreach (string text in queryList)
                    DataService.GetInstance().ExecuteNonQuery(text);
                    //QueryUtil.InsertDataToLocalDb(text);

                //DataUtil.SyncDataToServer();

                this.LoadReceivedData(MessageUtil.ReceivedList(GlobalService.RootTable));
            }
        }

        private void dgvReceived_DoubleClick(object sender, EventArgs e)
        {
            if (dgvReceived.SelectedRows == null)
                return;

            string path = dgvReceived.CurrentRow.Cells[6].Value.ToString();

            Process.Start(path);

            dgvReceived.CurrentRow.Cells[0].Value = "True";
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> queryList = new List<string>();

            foreach (DataGridViewRow r in dgvReceived.SelectedRows)
            {
                string filePath = r.Cells[6].Value.ToString().Trim();

                string sPath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

                DataRow[] rows = (from row in GlobalService.RootTable.AsEnumerable()
                                  where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == filePath
                                  select row).ToArray();

                foreach (DataRow row in rows)
                {
                    string owner = row["fileowner"].ToString();

                    string tableName = "TB_" + AdUtil.GetUserIdByUsername(owner, "kmhk.local");

                    List<string> sharedList = DataUtil.GetSharedList(tableName, filePath);
                    sharedList.Remove(GlobalService.User);

                    string shared = string.Join(";", sharedList.ToArray());

                    string ownerText = string.Format("update " + tableName + " set r_shared = N'{0}' where r_path = N'{1}'", shared, sPath);
                    queryList.Add(ownerText);

                    string sharedText = string.Format("delete from " + GlobalService.DbTable + " where r_path = N'{0}'", sPath);
                    queryList.Add(sharedText);

                    row.Delete();
                }
            }
            foreach (string text in queryList)
                DataService.GetInstance().ExecuteNonQuery(text);
                //QueryUtil.InsertDataToLocalDb(text);

            //DataUtil.SyncDataToServer();

            this.LoadReceivedData(MessageUtil.ReceivedList(GlobalService.RootTable));
        }
    }
}
