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
    public partial class CurrencySearchForm : Form
    {
        public CurrencySearchForm(string currType)
        {
            InitializeComponent();

            LoadData("");
        }

        private void LoadData(string source)
        {
            DataTable table = new DataTable();

            string query = string.Format("select cu_month as mon, cu_type as item, cu_description as description, cu_currency as rate from TB_CM_MASTER_CURRENCY where cu_month like '%{0}%'", source);

            SqlDataAdapter sda = new SqlDataAdapter(query, DataServiceCM.GetInstance().Connection);
            sda.Fill(table);

            dgvCurrency.DataSource = table;
        }

        private void dgvCurrency_DoubleClick(object sender, EventArgs e)
        {
            CmsService.RateMonth = dgvCurrency.SelectedRows[0].Cells[0].Value.ToString().Trim();
            CmsService.RateItem = dgvCurrency.SelectedRows[0].Cells[1].Value.ToString().Trim();
            CmsService.Rate = dgvCurrency.SelectedRows[0].Cells[3].Value.ToString().Trim();

            DialogResult = DialogResult.OK;
        }
    }
}
