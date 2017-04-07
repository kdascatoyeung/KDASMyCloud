using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KDTHK_DM_SP.eforms.acc.subforms
{
    public partial class OutstandingErrorBox : Form
    {
        public OutstandingErrorBox(List<OutstandingError> list)
        {
            InitializeComponent();

            foreach (OutstandingError error in list)
            {
                dgvError.Rows.Add(error.index, error.Message);
            }
        }

        private void btnInput_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }
    }
}
