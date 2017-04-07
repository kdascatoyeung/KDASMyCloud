using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using KDTHK_DM_SP.services;
using System.Diagnostics;

namespace KDTHK_DM_SP.eforms.acc.subforms
{
    public partial class VendorSearchForm : Form
    {
        string _type = "";

        public VendorSearchForm(string source, string type)
        {
            InitializeComponent();

            _type = type;

            LoadData(source, type);
        }

        private void LoadData(string source, string type)
        {
            DataTable table = new DataTable();

            string query = type == "code" ? string.Format("select v_code as vendor, v_name as vendorname, v_payterm as payterm, v_currency as curr from TB_ACC_MASTER_VENDOR where v_code like '%{0}%'", source)
                : string.Format("select v_code as vendor, v_name as vendorname, v_payterm as payterm, v_currency as curr from TB_ACC_MASTER_VENDOR where v_name like N'%{0}%'", source);

            SqlDataAdapter sda = new SqlDataAdapter(query, DataServiceCM.GetInstance().Connection);
            sda.Fill(table);

            dgvVendor.DataSource = table;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData(txtSearch.Text, _type);
        }

        private void dgvVendor_DoubleClick(object sender, EventArgs e)
        {
            AccData.VendorCode = dgvVendor.SelectedRows[0].Cells[0].Value.ToString().Trim();
            AccData.VendorName = dgvVendor.SelectedRows[0].Cells[1].Value.ToString().Trim();
            AccData.PayTerm = dgvVendor.SelectedRows[0].Cells[2].Value.ToString().Trim();
            AccData.Currency = dgvVendor.SelectedRows[0].Cells[3].Value.ToString().Trim();

            DialogResult = DialogResult.OK;
        }
    }
}
