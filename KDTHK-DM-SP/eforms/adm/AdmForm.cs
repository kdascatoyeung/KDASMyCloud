using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KDTHK_DM_SP.eforms.adm
{
    public partial class AdmForm : Form
    {
        public AdmForm()
        {
            InitializeComponent();
        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            AdmRepairForm form = new AdmRepairForm();
            form.ShowDialog();
        }

        private void btnPurchase_Click(object sender, EventArgs e)
        {
            AdmPurchaseForm form = new AdmPurchaseForm();
            form.ShowDialog();
        }

        private void btnStamp_Click(object sender, EventArgs e)
        {
            AdmStampForm form = new AdmStampForm();
            form.ShowDialog();
        }

        private void btnPark_Click(object sender, EventArgs e)
        {
            AdmParkForm form = new AdmParkForm();
            form.ShowDialog();
        }

        private void btnLift_Click(object sender, EventArgs e)
        {
            AdmLiftForm form = new AdmLiftForm();
            form.ShowDialog();
        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            AdmKeyForm form = new AdmKeyForm();
            form.ShowDialog();
        }

        private void btnVisa_Click(object sender, EventArgs e)
        {
            AdmVisaForm form = new AdmVisaForm();
            form.ShowDialog();
        }

        private void btnAir_Click(object sender, EventArgs e)
        {
            AdmAirForm form = new AdmAirForm();
            form.ShowDialog();
        }

    }
}
