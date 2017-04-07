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

namespace KDTHK_DM_SP.eforms.cm.subforms
{
    public partial class CustomerSearchForm : Form
    {
        public CustomerSearchForm(string customerName)
        {
            InitializeComponent();

            LoadData(customerName);

            txtSearch.Text = customerName;
        }

        private void LoadData(string source)
        {
            DataTable table = new DataTable();

            string query = string.Format("select cust_code as code, cust_name as name, cust_curr as curr, cust_payterm as payterm, cust_currtype as currtype, cust_currdesc as currdesc" +
                " from TB_CM_MASTER_CUSTOMER where cust_name like N'%{0}%' or cust_shortname like '%{0}%' order by cust_vc, cust_type, cust_name", source);

            SqlDataAdapter sda = new SqlDataAdapter(query, DataServiceCM.GetInstance().Connection);
            sda.Fill(table);

            dgvCustomer.DataSource = table;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                LoadData(txtSearch.Text.Trim());
        }

        private void dgvCustomer_DoubleClick(object sender, EventArgs e)
        {
            CmsService.CustomerCode = dgvCustomer.SelectedRows[0].Cells[0].Value.ToString().Trim();
            CmsService.CustomerName = dgvCustomer.SelectedRows[0].Cells[1].Value.ToString().Trim();
            CmsService.CustomerCurr = dgvCustomer.SelectedRows[0].Cells[2].Value.ToString().Trim();
            CmsService.CustomerPayTerm = dgvCustomer.SelectedRows[0].Cells[3].Value.ToString().Trim();
            CmsService.CurrencyType = dgvCustomer.SelectedRows[0].Cells[4].Value.ToString().Trim();
            CmsService.CurrencyDesc = dgvCustomer.SelectedRows[0].Cells[5].Value.ToString().Trim();

            DialogResult = DialogResult.OK;
        }
    }
}
