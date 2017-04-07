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

namespace KDTHK_DM_SP.eforms.cm.subforms
{
    public partial class DescriptionSelectionForm : Form
    {
        public DescriptionSelectionForm(string source)
        {
            InitializeComponent();

            LoadCategory();

            SearchData("All", source);

            txtSearch.Text = source;
        }

        private void LoadCategory()
        {
            cbCategory.Items.Add("All");

            string query = "select distinct d_category from TB_CM_MASTER_DESCRIPTION";
            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    cbCategory.Items.Add(reader.GetString(0).Trim());
            }

            cbCategory.SelectedIndex = 0;
        }

        private void SearchData(string category, string source)
        {
            DataTable table = new DataTable();

            if (category == "All") category = "";

            string query = string.Format("select d_category as category, d_desc as reason from TB_CM_MASTER_DESCRIPTION where d_category like '%{0}%' and d_r3 like '%{1}%'", category, source);
            SqlDataAdapter sda = new SqlDataAdapter(query, DataServiceCM.GetInstance().Connection);
            sda.Fill(table);

            dgvDescrption.DataSource = table;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchData(cbCategory.SelectedItem.ToString(), txtSearch.Text);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            SearchData(cbCategory.SelectedItem.ToString(), txtSearch.Text);
        }

        private void dgvDescrption_DoubleClick(object sender, EventArgs e)
        {
            CmsService.TransactionReason = dgvDescrption.SelectedRows[0].Cells[1].Value.ToString().Trim();

            DialogResult = DialogResult.OK;
        }
    }
}
