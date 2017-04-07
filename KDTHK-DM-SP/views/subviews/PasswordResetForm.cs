using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using CustomUtil.utils.authentication;

namespace KDTHK_DM_SP.views.subviews
{
    public partial class PasswordResetForm : Form
    {
        public PasswordResetForm()
        {
            InitializeComponent();
        }

        private void SaveData()
        {
            string staffId = AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local").Replace("hk", "");

            string datetime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string originalPwd = GetOriginalPassword(staffId);

            string insertText = string.Format("insert into TB_HR_PWD_LOG (pl_datetime, pl_staff, pl_old, pl_new) values ('{0}', N'{1}', '{2}', '{3}')", datetime, GlobalService.User, originalPwd, txtPassword.Text);
            DataServiceHR.GetInstance().ExecuteNonQuery(insertText);

            string updateText = string.Format("update TB_HR_PWD set p_password = '{0}' where p_staffid = '{1}'", txtPassword.Text, staffId);
            DataServiceHR.GetInstance().ExecuteNonQuery(updateText);

            DialogResult = DialogResult.OK;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SaveData();
        }

        private string GetOriginalPassword(string staffId)
        {
            string query = string.Format("select p_password from TB_HR_PWD where p_staffid = '{0}'", staffId);
            return DataServiceHR.GetInstance().ExecuteScalar(query).ToString();
        }
    }
}
