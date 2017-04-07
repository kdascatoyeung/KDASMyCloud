using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using System.DirectoryServices.AccountManagement;
using System.Diagnostics;
using CustomUtil.utils.authentication;

namespace KDTHK_DM_SP.forms
{
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();

            txtUser.Text = GlobalService.User;

            txtPassword.Select();
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void Login(string userName, string password)
        {
            bool valid = false;

            try
            {
                if (password == "")
                    valid = false;
                else
                {
                    using (PrincipalContext context = new PrincipalContext(ContextType.Domain))
                    {
                        valid = context.ValidateCredentials(userName, password);
                    }
                }

                if (valid)
                {
                    GlobalService.IsPasswordInput = true;
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Invalid password.");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid password.");
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void Login2(string userName, string password)
        {
            bool valid = false;

            PrincipalContext domain = null;

            try
            {
                if (password == "")
                    valid = false;
                else
                {
                    domain = new PrincipalContext(ContextType.Domain, "172.16.13.242", userName, password);
                    valid = domain.ValidateCredentials(userName, password);
                    //valid = true;
                }
            }
            catch
            {
                valid = false;
            }

            if (valid)
            {
                GlobalService.IsPasswordInput = true;
                this.DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Invalid password.");
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Login(@"kmhk.local\" + AdUtil.GetUserIdByUsername(txtUser.Text.Trim(), "kmhk.local"), txtPassword.Text.Trim());
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Login(@"kmhk.local\" + AdUtil.GetUserIdByUsername(txtUser.Text.Trim(), "kmhk.local"), txtPassword.Text.Trim());
        }

        private Boolean IsAuthenticated(string username, string password)
        {
            PrincipalContext domain;

            try
            {
                domain = new PrincipalContext(ContextType.Domain, "172.16.13.242", username.Trim(), password.Trim());
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
                return false;
            }

            return false;
        }
    }
}
