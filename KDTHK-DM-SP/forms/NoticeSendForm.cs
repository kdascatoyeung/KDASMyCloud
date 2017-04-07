using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CustomUtil.utils.authentication;
using KDTHK_DM_SP.services;
using System.Data.SqlServerCe;
using KDTHK_DM_SP.utils;

namespace KDTHK_DM_SP.forms
{
    public partial class NoticeSendForm : Form
    {
        List<string> _receiverList = new List<string>();

        string _filePath = "";
        string _fileName = "";

        public NoticeSendForm(List<string> receiverList, string filePath, string fileName)
        {
            InitializeComponent();

            _receiverList = receiverList;

            _filePath = filePath;

            _fileName = fileName;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;

            foreach (string receiver in _receiverList)
            {
                string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                if (_filePath.Contains("'"))
                    _filePath = _filePath.Replace("'", "''");

                if (_fileName.Contains("'"))
                    _fileName = _fileName.Replace("'", "''");

                string text = string.Format("insert into TB_NOTICE (n_requester, n_receiver, n_datetime, n_message, n_filename, n_filepath)" +
                    " values (N'{0}', N'{1}', '{2}', N'{3}', N'{4}', N'{5}')", GlobalService.User, receiver, now, message, _fileName, _filePath);
                string query = "insert into LTB_QUERY ([q_query]) values (@text)";

                using (SqlCeCommand ceCommand = new SqlCeCommand(query, LocalDataService.GetInstance().Connection))
                {
                    ceCommand.Parameters.AddWithValue("@text", text);
                    ceCommand.ExecuteNonQuery();
                }
            }

            //DataUtil.SyncDataToServer();
            this.DialogResult = DialogResult.OK;
        }
    }
}
