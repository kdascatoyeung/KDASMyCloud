using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.views.subviews;

namespace KDTHK_DM_SP.views
{
    public partial class SettingView : UserControl
    {
        GroupSetupView groupView = new GroupSetupView();
        PasswordSetupView passwordView = new PasswordSetupView();

        public SettingView()
        {
            InitializeComponent();

            this.LoadControl(groupView);
        }

        private void LoadControl(UserControl control)
        {
            pnlMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(control);
        }

        private void tsbtnGroup_Click(object sender, EventArgs e)
        {
            this.LoadControl(groupView);
        }

        private void tsbtnPassword_Click(object sender, EventArgs e)
        {
            this.LoadControl(passwordView);
        }
    }
}
