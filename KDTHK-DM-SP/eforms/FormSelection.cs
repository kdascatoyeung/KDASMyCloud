using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using KDTHK_DM_SP.eforms.cm;
using KDTHK_DM_SP.eforms.cm.subforms;
using KDTHK_DM_SP.eforms.acc;
using KDTHK_DM_SP.eforms.acc.subforms;
using KDTHK_DM_SP.eforms.adm;

namespace KDTHK_DM_SP.eforms
{
    public partial class FormSelection : Form
    {
        public FormSelection()
        {
            InitializeComponent();

            //if (GlobalService.User != "Ho Chui Lai(何翠麗,Joanne)" && GlobalService.User != "Lee Suk Ha(李淑霞,Zoe)" && GlobalService.User != "Leung Wai Yip(梁偉業,Philip)" && GlobalService.User != "Li Yuen Yan(李婉茵,Sharon)" && GlobalService.User != "Ng Wai Kwan(吳蕙君,Wendy)" && GlobalService.User != "Ogata Shuka (尾形秋香)" && GlobalService.User != "Ho Kin Hang(何健恒,Ken)")
                //btnOutstanding.Visible = false;

            //if (GlobalService.User != "Ho Kin Hang(何健恒,Ken)")
               // btnAdmin.Visible = false;
        }

        private void btnITService_Click(object sender, EventArgs e)
        {
            GlobalService.ApplicationForm = "itservice";

            DialogResult = DialogResult.OK;
        }

        private void btnR3_Click(object sender, EventArgs e)
        {
            GlobalService.ApplicationForm = "r3application";

            DialogResult = DialogResult.OK;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
        }

        private void customButton1_Click(object sender, EventArgs e)
        {
            DebitCreditNoteFormView form = new DebitCreditNoteFormView("debit");
            form.ShowDialog();
        }

        private void customButton2_Click(object sender, EventArgs e)
        {
            DebitCreditNoteFormView form = new DebitCreditNoteFormView("credit");
            form.ShowDialog();
        }

        private void customButton3_Click(object sender, EventArgs e)
        {
            DebitSelectionForm form = new DebitSelectionForm();
            form.ShowDialog();
        }

        private void customButton4_Click(object sender, EventArgs e)
        {
            DebitCreditNoteFormView form = new DebitCreditNoteFormView("DB-000001");
            form.ShowDialog();
        }

        private void btnOutstanding_Click(object sender, EventArgs e)
        {
            OutstandingSelectionForm form = new OutstandingSelectionForm();
            form.ShowDialog();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdmForm form = new AdmForm();
            form.ShowDialog();
        }
    }
}
