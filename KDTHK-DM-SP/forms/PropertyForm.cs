using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KDTHK_DM_SP.forms
{
    public partial class PropertyForm : Form
    {
        public PropertyForm(string path)
        {
            InitializeComponent();

            txtDirectory.Text = path;
        }

        private void txtDirectory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtDirectory_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
                Clipboard.SetText(txtDirectory.Text);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtDirectory.Text);
        }


    }
}
