using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using CustomUtil.utils.authentication;
using KDTHK_DM_SP.utils;

namespace KDTHK_DM_SP.eforms.adm
{
    public partial class AdmPurchaseForm : Form
    {
        public AdmPurchaseForm()
        {
            InitializeComponent();

            txtUser.Text = GlobalService.User;

            txtDepartment.Text = MasterUtil.Department();
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string createdby = txtUser.Text.Trim();
            string created = DateTime.Today.ToString("yyyy/MM/dd");

            string department = txtDepartment.Text.Trim();

            string remarks = txtRemarks.Text.Trim();

            string sectHead = UserUtil.GetSectionHead(UserUtil.GetSect(GlobalService.User));
            string divHead = UserUtil.GetDivisionHead(UserUtil.GetDivision(GlobalService.User));

            string adm1st = "Sammy Chow Chi To (周志滔)";
            string adm2nd = "Sammy Chow Chi To (周志滔)";

            if (remarks.Contains("'")) remarks = remarks.Replace("'", "''");

            string query = string.Format("insert into TB_ADM_FORM_PURCHASE (ap_created, ap_createdby, ap_department, ap_remarks, ap_sect, ap_div, ap_adm1st, ap_adm2nd)" +
                " values ('{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}')", created, createdby, department, remarks, sectHead, divHead, adm1st, adm2nd);

            DataServiceCM.GetInstance().ExecuteNonQuery(query);

            string text = "select top 1 ap_id from TB_ADM_FORM_PURCHASE order by ap_id desc";
            int id = (int)DataServiceCM.GetInstance().ExecuteScalar(text);

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow)
                    continue;

                string item = row.Cells[0].Value.ToString().Trim();
                string qty = row.Cells[1].Value.ToString().Trim();
                string amount = row.Cells[2].Value.ToString().Trim();

                if (item.Contains("'"))
                    item = item.Replace("'", "''");

                string detailText = string.Format("insert into TB_ADM_FORM_PURCHASE_DETAIL (apd_ap_id, apd_item, apd_qty, apd_amount)" +
                    " values ('{0}', N'{1}', '{2}', '{3}')", id, item, qty, amount);

                DataServiceCM.GetInstance().ExecuteNonQuery(detailText);
            }

            string from = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), "kmhk.local");

            string to = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(sectHead, "kmhk.local"), "kmhk.local");

            string emailText = "Application Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
            string body = "<p><span style=\"font-family: Calibri;\">" + emailText + "</span></p>";
            EformUtil.SendApprovalEmail("", GlobalService.User, from, to, body, "Approval Required - 月度購買依賴");

            MessageBox.Show("Record has been saved.");

            DialogResult = DialogResult.OK;
        }

        delegate void SetTotalCallback(string text);
        private void SetTotal(string text)
        {
            if (InvokeRequired)
            {
                SetTotalCallback callback = new SetTotalCallback(SetTotal);
                this.Invoke(callback, new object[] { text });
            }
            else
                lblTotal.Text = text;
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            double total = 0;

            foreach (DataGridViewRow row in dgvItems.Rows)
            {
                if (row.IsNewRow)
                    continue;

                try
                {
                    double value = Convert.ToDouble(row.Cells[1].Value) * Convert.ToDouble(row.Cells[2].Value);

                    total = total + value;
                }
                catch
                {
                    MessageBox.Show("Invalid amount");
                    continue;
                }
            }

            SetTotal("Total: " + total);
        }
    }
}
