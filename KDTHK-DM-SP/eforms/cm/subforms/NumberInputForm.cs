using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;

namespace KDTHK_DM_SP.eforms.cm.subforms
{
    public partial class NumberInputForm : Form
    {
        string _mode = "";

        public NumberInputForm(string input, string mode)
        {
            InitializeComponent();

            _mode = mode;

            this.Text = _mode == "inv" ? "Input INV No." : "Input Ringi No.";

            if (input != "")
            {
                string[] items = input.Split(';').ToArray();
                string output = "";
                foreach (string item in items)
                    output += item + "\r\n";

                txtInput.Text = output.Trim();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            List<string> list =new List<string>();
            if (txtInput.Lines.Length > 0)
                for (int i = 0; i < txtInput.Lines.Length; i++)
                    if (txtInput.Lines[i] != "")
                        list.Add(txtInput.Lines[i]);

            string output = string.Join(";", list);

            if (_mode == "inv") CmsService.InputInvNo = output.Trim();
            if (_mode == "ringi") CmsService.InputRingiNo = output.Trim();

            DialogResult = DialogResult.OK;
        }
    }
}
