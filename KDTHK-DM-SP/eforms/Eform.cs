using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.eforms.hra;
using System.Diagnostics;

namespace KDTHK_DM_SP.eforms
{
    public partial class Eform : UserControl
    {
        FormIT formIt = new FormIT();
        FormHistory formHistory = new FormHistory();

        FormOverview formOverview = new FormOverview();

        public Eform()
        {
            InitializeComponent();

            LoadControl(formOverview);
        }

        private void LoadControl(UserControl control)
        {
            pnlMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(control);
        }

        private void ToolStripButtonClicked(object sender, EventArgs e)
        {
            ToolStripButton tsbtn = (ToolStripButton)sender;
            string tag = tsbtn.Tag.ToString();

            if (tag == "application")
            {
                //formIt = new FormIT();
                //LoadControl(formIt);

                formOverview = new FormOverview();
                LoadControl(formOverview);
            }

            if (tag == "history")
            {
                formHistory = new FormHistory();
                LoadControl(formHistory);
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Process.Start(@"\\kdthk-dm1\kdthkshare$\資訊及規則(eg.總經理早會講話,業務基準書)\電腦\Manual\Mycloud-Eform.lnk");
        }
    }
}
