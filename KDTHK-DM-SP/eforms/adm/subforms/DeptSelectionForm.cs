using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;

namespace KDTHK_DM_SP.eforms.adm.subforms
{
    public partial class DeptSelectionForm : Form
    {
        public DeptSelectionForm()
        {
            InitializeComponent();
        }

        private void lbDept_DoubleClick(object sender, EventArgs e)
        {
            GlobalService.SelectedDepartment = lbDept.SelectedItem.ToString().Trim();

            this.DialogResult = DialogResult.OK;
        }
    }
}
