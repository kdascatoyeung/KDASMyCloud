using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.lists;
using KDTHK_DM_SP.services;
using System.Diagnostics;
using System.Data.SqlServerCe;
using KDTHK_DM_SP.utils;

namespace KDTHK_DM_SP.forms
{
    public partial class NoticeForm : Form
    {
        public NoticeForm()
        {
            InitializeComponent();

            this.LoadData();

            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            tsbtnClear.Enabled = dgvNotice.Rows.Count > 0 ? true : false;
        }

        private void LoadData()
        {
            dgvNotice.Rows.Clear();

            foreach (NoticeList notice in GlobalService.NoticeList)
                dgvNotice.Rows.Add(notice.Requester, notice.Datetime, notice.Filename, notice.Message, notice.Filepath, "Receive");
        }

        private void dgvNotice_DoubleClick(object sender, EventArgs e)
        {
            string path = dgvNotice.SelectedRows[0].Cells[4].Value.ToString();

            Process.Start(path);
        }

        private void tsbtnClear_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvNotice.Rows)
            {
                string filePath = row.Cells[4].Value.ToString();

                GlobalService.NoticeList.Remove(GlobalService.NoticeList.Find(x => x.Filepath == filePath));

                if (filePath.Contains("'"))
                    filePath = filePath.Replace("'", "''");

                string text = string.Format("delete from TB_NOTICE where n_receiver = N'{0}' and n_filepath = N'{1}'", GlobalService.User, filePath);
                DataService.GetInstance().ExecuteNonQuery(text);
                //QueryUtil.InsertDataToLocalDb(text);
            }

            //DataUtil.SyncDataToServer();

            dgvNotice.Rows.Clear();
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            GlobalService.NoticeList = MessageUtil.GetNoticeList();

            this.LoadData();
        }

        private void dgvNotice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                string filePath = dgvNotice.CurrentRow.Cells[4].Value.ToString();

                GlobalService.NoticeList.Remove(GlobalService.NoticeList.Find(x => x.Filepath == filePath));

                string text = string.Format("delete from TB_NOTICE where n_receiver = N'{0}' and n_filepath = N'{1}'", GlobalService.User, filePath);
                DataService.GetInstance().ExecuteNonQuery(text);
                //QueryUtil.InsertDataToLocalDb(text);

                dgvNotice.Rows.Remove(dgvNotice.CurrentRow);

                //DataUtil.SyncDataToServer();
            }
        }
    }
}
