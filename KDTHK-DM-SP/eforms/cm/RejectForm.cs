using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;

namespace KDTHK_DM_SP.eforms.cm
{
    public partial class RejectForm : Form
    {
        string _docno = "";

        public RejectForm(string docno)
        {
            InitializeComponent();

            _docno = docno;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string query = string.Format("update TB_CM_DEBIT set d_reject = N'{0}' where d_docno = '{1}'", txtReason.Text.Trim(), _docno);
            DataServiceCM.GetInstance().ExecuteNonQuery(query);

            DialogResult = DialogResult.OK;
        }
    }
}
