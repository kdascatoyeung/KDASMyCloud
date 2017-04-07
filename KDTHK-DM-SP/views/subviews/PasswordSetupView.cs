using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using CustomUtil.utils.authentication;
using System.Net.Mail;
using System.Security.Cryptography;
using KDTHK_DM_SP.utils;
using System.Diagnostics;

namespace KDTHK_DM_SP.views.subviews
{
    public partial class PasswordSetupView : UserControl
    {
        SecurityUtil security = new SecurityUtil();

        public PasswordSetupView()
        {
            InitializeComponent();

            txtUser.Text = GlobalService.User;

            txtPassword.Select();
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void lklForgot_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //PasswordResetForm form = new PasswordResetForm();
            //form.ShowDialog();
            string staffId = AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local");

            string password = GetOriginalPassword(staffId.Replace("hk", ""));

            string fromEmail = "ken.ho@dthk.kyocera.com";
            string subject = "Your Password has been restored.";
            string content = "Your password has been restored. Please use the password below to access personal data (Salary Advice).\n\n" + password + "\n\nThis is system message. Please do not reply.";

            try
            {
                string hostname = "Kdmail.km.local";
                SmtpClient client = new SmtpClient(hostname);
                string toEmail = AdUtil.GetEmailByUserId(staffId, "kmhk.local");
                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                using (var message = new MailMessage(fromEmail, toEmail)
                {
                    Subject = subject,
                    Body = content
                })
                {
                    client.Send(message);
                }

                MessageBox.Show("Your password has been restored. Please check your Email.");
            }
            catch
            {
                MessageBox.Show("Your password cannot be reset. Please contact system administrator.");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string staffId = AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local").Replace("hk", "");

            if (!IsPasswordCorrect(staffId, txtPassword.Text))
            {
                MessageBox.Show("Your password is not valid.");
                return;
            }

            if (txtNewPassword.Text.Length < 5)
            {
                MessageBox.Show("Password must be at least 4 digits.");
                return;
            }

            string datetime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            //string originalPwd = GetOriginalPassword(staffId);

            //string insertText = string.Format("insert into TB_HR_PWD_LOG (pl_datetime, pl_staff, pl_old, pl_new) values ('{0}', N'{1}', '{2}', '{3}')", datetime, GlobalService.User, originalPwd, txtNewPassword.Text);
            //DataServiceHR.GetInstance().ExecuteNonQuery(insertText);

            string ePwd = security.Encrypt(txtNewPassword.Text);

            string updateText = string.Format("update TB_HR_PWD set p_password = '{0}' where p_staffid = '{1}'", ePwd, staffId);
            DataServiceHR.GetInstance().ExecuteNonQuery(updateText);

            MessageBox.Show("Record has been saved.");
        }

        private bool IsPasswordCorrect(string staffId, string password)
        {
            string query = string.Format("select p_password from TB_HR_PWD where p_staffid = '{0}'", staffId.Trim());
            string result = DataServiceHR.GetInstance().ExecuteScalar(query).ToString();

            string serverPwd = result == "-----" ? result : security.Decrypt(result.ToString().Trim());

            if (serverPwd != password)
                return false;

            return true;
        }

        private string GetOriginalPassword(string staffId)
        {
            string query = string.Format("select p_password from TB_HR_PWD where p_staffid = '{0}'", staffId);
            return security.Decrypt(DataServiceHR.GetInstance().ExecuteScalar(query).ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(security.Decrypt("C479204BCDDCBED9"));
        }
    }
}
