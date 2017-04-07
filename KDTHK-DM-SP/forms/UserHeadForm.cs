using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using System.Data.SqlClient;
using KDTHK_DM_SP.lists;

namespace KDTHK_DM_SP.forms
{
    public partial class UserHeadForm : Form
    {
        string _mode = "";

        public UserHeadForm(string mode)
        {
            InitializeComponent();

            _mode = mode;
        }

        private void SearchData(string source)
        {
            DataTable table = new DataTable();
            table.Columns.Add("name");

            if (_mode == "head")
            {
                string query = string.Format("select distinct sg_staff as name from TB_SYSTEM_GROUP where sg_staff like N'%{0}%'", source);
                SqlDataAdapter adpater = new SqlDataAdapter(query, DataService.GetInstance().Connection);
                adpater.Fill(table);

            }
            else
            {
                List<UserList> userList = GlobalService.AllUserList.Where(name => name.User.Contains(txtSearch.Text.Substring(0, 1).ToUpper() + txtSearch.Text.Substring(1)) ||
                    name.Division.Contains(txtSearch.Text.ToUpper())).ToList();

                foreach (UserList item in userList)
                    table.Rows.Add(item.User);
            }

            dgvUser.DataSource = table;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchData(txtSearch.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchData(txtSearch.Text);
        }

        private void dgvUser_DoubleClick(object sender, EventArgs e)
        {
            if (dgvUser.Rows.Count > 0)
            {
                string head = dgvUser.SelectedRows[0].Cells[0].Value.ToString().Trim();
                GlobalService.SelectedUserHead = head;

                DialogResult = DialogResult.OK;
            }
        }
    }
}
