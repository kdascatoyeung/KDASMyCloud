using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using System.Diagnostics;
using KDTHK_DM_SP.utils;
using CustomUtil.utils.authentication;

namespace KDTHK_DM_SP.eforms.acc.subforms
{
    public partial class OutstandingPreviewForm : Form
    {
        List<Outstanding> dataList = null;

        public OutstandingPreviewForm(DataTable table, List<Outstanding> list)
        {
            InitializeComponent();

            dgvPreview.DataSource = table;

            dataList = list;
        }

        private void dgvPreview_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                string invoice = dgvPreview.CurrentRow.Cells[2].Value.ToString().Trim();
                string code = dgvPreview.CurrentRow.Cells[0].Value.ToString().Trim();
                string name = dgvPreview.CurrentRow.Cells[1].Value.ToString().Trim();

                string currency = AccUtil.GetVendorCurrency(code);

                string total = dgvPreview.CurrentRow.Cells[3].Value.ToString().Trim();

                OutstandingPreviewDetailForm form = new OutstandingPreviewDetailForm(invoice, code, name, currency, total, dataList);
                form.ShowDialog();
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string sectHead = UserUtil.GetSectionHead(UserUtil.GetSect(GlobalService.User));
            string divHead = UserUtil.GetDivisionHead(UserUtil.GetDivision(GlobalService.User));

            string dept = UserUtil.GetDept(GlobalService.User);
            string deptHead = dept.Contains("RPS") ? UserUtil.GetDepartmentHead(dept) : "";

            string cm1st = "Lee Suk Ha(李淑霞,Zoe)";
            string cm2nd = "Li Yuen Yan(李婉茵,Sharon)";

            foreach (DataGridViewRow row in dgvPreview.Rows)
            {
                string invoice = row.Cells[2].Value.ToString().Trim();
                string code = row.Cells[0].Value.ToString().Trim();
                string name = row.Cells[1].Value.ToString().Trim();

                string currency = AccUtil.GetVendorCurrency(code);

                string payterm = AccUtil.GetVendorPayTerm(code);

                string paydate = AccUtil.PayDate(Convert.ToDateTime(DateTime.Today.ToString("yyyy/MM/dd")), payterm);

                string total = row.Cells[3].Value.ToString().Trim();

                string invoiceText = string.Format("insert into TB_ACC_MASTER_INVOICE (i_invoice, i_vendor) values ('{0}', '{1}')", invoice, code);
                DataServiceCM.GetInstance().ExecuteNonQuery(invoiceText);

                string query = string.Format("insert into TB_ACC_OUTSTANDING (o_invoice, o_vendor, o_vendorname, o_inputdate, o_paymentdate, o_currency, o_amount, o_createdby" +
                    ", o_created, o_div, o_staff, o_acc, o_sect, o_dept) values ('{0}', '{1}', N'{2}', '{3}', '{4}', '{5}', '{6}', N'{7}', '{8}', N'{9}', N'{10}', N'{11}', N'{12}', N'{13}')", invoice, code, name, DateTime.Today.ToString("yyyy/MM/dd"), paydate, currency, total,
                    GlobalService.User, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), divHead, cm1st, cm2nd, sectHead, deptHead);

                DataServiceCM.GetInstance().ExecuteNonQuery(query);

                //KDTHK_DM_SP.utils.EformUtil.SendApprovalEmail(invoice, GlobalService.User, AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local"), AdUtil.GetEmailByUsername(sectHead, "kmhk.local"), "", "Outstanding Slip");
            }

            foreach (Outstanding item in dataList)
            {
                int id = AccUtil.GetOutstandingIdByInvoice(item.Invoice);

                string acName = AccUtil.GetAccountName(item.AccountCode);
                string ccName = AccUtil.GetCostCentreName(item.CostCentre);

                string desc = (item.Desc1 + item.Desc2 + item.Desc3 + item.Desc4 + item.Desc5);
                desc = desc.Substring(0, Math.Min(desc.Length, 50));

                string text = string.Format("insert into TB_ACC_OUTSTANDING_DETAIL (od_o_id, od_accountcode, od_accountname, od_costcentre, od_costcentrename, od_amount" +
                            ", od_desc1, od_desc2, od_desc3, od_desc4, od_desc5, od_display) values ('{0}', '{1}', N'{2}', '{3}', N'{4}', '{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', N'{11}')", id, item.AccountCode,
                            acName, item.CostCentre, ccName, item.Amount, item.Desc1, item.Desc2, item.Desc3, item.Desc4, item.Desc5, desc);
                DataServiceCM.GetInstance().ExecuteNonQuery(text);
            }

            string content = "Application Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
            string body = "<p><span style=\"font-family: Calibri;\">" + content + "</span></p>";

            bool isSent = false;

            if (!isSent)
            {
                isSent = true;
                KDTHK_DM_SP.utils.EformUtil.SendApprovalEmail("", GlobalService.User, AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local"), AdUtil.GetEmailByUsername(sectHead, "kmhk.local"), body, "Outstanding Slip");
            }

            MessageBox.Show("Record has been saved.");

            DialogResult = DialogResult.OK;
        }

        private string DoFormat(string text)
        {
            var s = string.Format("{0:0.00}", Convert.ToDouble(text));

            s = StringUtil.Calculation(s, 50);

            return s;
        }

    }
}
