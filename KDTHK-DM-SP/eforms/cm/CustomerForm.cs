using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using System.Data.SqlClient;

namespace KDTHK_DM_SP.eforms.cm
{
    public partial class CustomerForm : Form
    {
        public CustomerForm(string custName)
        {
            InitializeComponent();
        }

        private void LoadData(string custName)
        {
            DataTable table = new DataTable();

            string query = string.Format("select cust_code as code, cust_name as name, cust_curr as curr, cust_payterm as payterm from TB_CM_MASTER_CUSTOMER where cust_name like N'%{0}%'", custName);

            SqlDataAdapter sda = new SqlDataAdapter(query, DataService.GetInstance().Connection);
            sda.Fill(table);

            dgvCustomer.DataSource = table;
        }

        private void dgvCustomer_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
