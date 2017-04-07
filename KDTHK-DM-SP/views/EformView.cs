using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.eforms.hra;

namespace KDTHK_DM_SP.views
{
    public partial class EformView : UserControl
    {

        public EformView()
        {
            InitializeComponent();
        }

        private void LoadControl(UserControl control)
        {
            pnlMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(control);
        }

        private void ToolStripButtonClicked(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            string tag = button.Tag.ToString();

            foreach (ToolStripButton btn in toolStrip.Items)
                btn.ForeColor = Color.Black;

            button.ForeColor = Color.DodgerBlue;

        }
    }
}
