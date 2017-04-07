using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using System.Diagnostics;

namespace KDTHK_DM_SP.forms
{
    public partial class CustomGroupForm : Form
    {
        List<string> _list = new List<string>();

        public CustomGroupForm(List<string> list)
        {
            InitializeComponent();

            _list = list;
        }

        private void SaveData()
        {
            if (!string.IsNullOrEmpty(txtGroup.Text) && IsGroupExists(txtGroup.Text))
            {
                MessageBox.Show("Please input a valid group name.");
                return;
            }

            string ownertext = string.Format("insert into TB_CUSTOM_GROUP (g_name, g_owner, g_member) values (N'{0}', N'{1}', '-')", txtGroup.Text, GlobalService.User);
            DataService.GetInstance().ExecuteNonQuery(ownertext);

            foreach (string shared in _list)
            {
                string query = string.Format("insert into TB_CUSTOM_GROUP (g_name, g_owner, g_member) values (N'{0}', N'{1}', N'{2}')", txtGroup.Text, GlobalService.User, shared);
                DataService.GetInstance().ExecuteNonQuery(query);
            }

            MessageBox.Show("Group " + txtGroup.Text + " has been created.");
            this.DialogResult = DialogResult.OK;
        }

        private bool IsGroupExists(string groupname)
        {
            string query = string.Format("select * from TB_CUSTOM_GROUP where g_name = N'{0}' and g_owner = N'{1}'", groupname, GlobalService.User);
            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                if (GlobalService.Reader.HasRows)
                    return true;
            }

            return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void txtGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SaveData();
        }
    }
}
