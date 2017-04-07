using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KDTHK_DM_SP.eforms.cm.subforms
{
    public partial class DebitSelectionForm : Form
    {
        public DebitSelectionForm()
        {
            InitializeComponent();
        }

        private void btnDebit_Click(object sender, EventArgs e)
        {
            //DebitCreditNoteForm3 form = new DebitCreditNoteForm3("debit");
            DebitNoteForm2 form = new DebitNoteForm2("debit", "new", "");
            if (form.ShowDialog() == DialogResult.OK)
                DialogResult = DialogResult.OK;
        }

        private void btnCredit_Click(object sender, EventArgs e)
        {
            //DebitCreditNoteForm3 form = new DebitCreditNoteForm3("credit");
            DebitNoteForm2 form = new DebitNoteForm2("credit", "new", "");
            if (form.ShowDialog() == DialogResult.OK)
                DialogResult = DialogResult.OK;
        }
    }
}
