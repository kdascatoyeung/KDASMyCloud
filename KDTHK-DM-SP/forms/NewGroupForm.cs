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

namespace KDTHK_DM_SP.forms
{
    public partial class NewGroupForm : Form
    {
        public NewGroupForm()
        {
            InitializeComponent();
        }

        private void SaveData()
        {
            GlobalService.Group = txtGroup.Text;

            string storedGroup = GlobalService.Group.Contains("'") ? GlobalService.Group.Replace("'", "''") : GlobalService.Group;

            string text = string.Format("insert into TB_CUSTOM_GROUP (g_name, g_owner, g_member) values (N'{0}', N'{1}', N'{2}')", storedGroup, GlobalService.User, "-");
            DataService.GetInstance().ExecuteNonQuery(text);

            this.DialogResult = DialogResult.OK;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }

        private void txtGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SaveData();
        }
    }
}
