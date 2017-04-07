using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KDTHK_DM_SP.backup
{
    public partial class ErrorBox : Form
    {
        public ErrorBox(string message)
        {
            InitializeComponent();

            richTextBox1.Text = message;
        }
    }
}
