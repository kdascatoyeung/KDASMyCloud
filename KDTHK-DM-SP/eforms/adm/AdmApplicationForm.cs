using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using KDTHK_DM_SP.utils;

namespace KDTHK_DM_SP.eforms.adm
{
    public partial class AdmApplicationForm : Form
    {
        public AdmApplicationForm()
        {
            InitializeComponent();

            txtApplicant.Text = GlobalService.User;
            txtDivision.Text = MasterUtil.Division();
            txtCostCentre.Text = MasterUtil.CostCentre();

            cbItems.SelectedIndex = 0;

            LoadStampInfo();
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void LoadStampInfo()
        {
            string[] items = { "HK$0.10", "HK$0.20", "HK$0.50", "HK$1.00", "HK$1.70", "HK$2.00", "HK$2.90", "HK$3.70", "HK$5.00", "HK$10.00" };

            foreach (string item in items)
                dgvStamp.Rows.Add(item, "0");
        }

        private void SaveData()
        {

        }

        private void AdmApplicationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
