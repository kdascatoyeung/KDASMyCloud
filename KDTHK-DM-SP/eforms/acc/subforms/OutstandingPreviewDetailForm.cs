using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;

namespace KDTHK_DM_SP.eforms.acc.subforms
{
    public partial class OutstandingPreviewDetailForm : Form
    {
        public OutstandingPreviewDetailForm(string invoice, string code, string name, string currency, string total, List<Outstanding> list)
        {
            InitializeComponent();

            DataTable table = new DataTable();

            string[] headers = { "code", "name", "ac", "acname", "cc", "ccname", "amt", "rm1", "rm2", "rm3", "rm4", "rm5" };

            foreach (string header in headers)
                table.Columns.Add(header);

            this.Text = "Invoice: " + invoice + "   Total: " + currency + " " + total;

            var dataList = from x in list
                           where x.Invoice == invoice && x.VendorCode == code
                           select new { x.AccountCode, x.CostCentre, x.Amount, x.Desc1, x.Desc2, x.Desc3, x.Desc4, x.Desc5 };

            foreach (var item in dataList)
            {
                string acText = string.Format("select a_name from TB_CM_MASTER_ACCOUNTCODE where a_code = '{0}'", item.AccountCode);
                string acName = DataServiceCM.GetInstance().ExecuteScalar(acText).ToString();

                string ccText = string.Format("select c_name from TB_CM_MASTER_COSTCENTRE where c_code = '{0}'", item.CostCentre);
                string ccName = DataServiceCM.GetInstance().ExecuteScalar(ccText).ToString();

                table.Rows.Add(code, name, item.AccountCode, acName, item.CostCentre, ccName, item.Amount, item.Desc1, item.Desc2, item.Desc3, item.Desc4, item.Desc5);
            }

            dgvPreview.DataSource = table;

        }
    }
}
