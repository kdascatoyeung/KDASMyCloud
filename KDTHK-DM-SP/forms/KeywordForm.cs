using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using System.Data.SqlServerCe;
using KDTHK_DM_SP.utils;
using System.IO;

namespace KDTHK_DM_SP.forms
{
    public partial class KeywordForm : Form
    {
        List<string> _pathList = new List<string>();

        public KeywordForm(List<string> pathList)
        {
            InitializeComponent();

            this.Text = pathList.Count == 1 ? "Keyword of " + Path.GetFileNameWithoutExtension(pathList[0]) : "Keyword of Multiple files";

            _pathList = pathList;
        }

        private void SaveData(DataTable table, List<string> pathList)
        {
            foreach (string path in pathList)
            {
                string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

                DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

                foreach (DataRow row in rows)
                {
                    row["keyword"] = txtKeyword.Text;

                    string text = string.Format("update " + GlobalService.DbTable + " set r_keyword = N'{0}' where r_path = N'{1}'", txtKeyword.Text, sPath);
                    DataService.GetInstance().ExecuteNonQuery(text);
                }
            }

            this.DialogResult = DialogResult.OK;
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SaveData(GlobalService.RootTable, _pathList);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveData(GlobalService.RootTable, _pathList);
        }
    }
}
