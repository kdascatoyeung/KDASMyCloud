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
    public partial class AdmStampForm : Form
    {
        public AdmStampForm()
        {
            InitializeComponent();

            string[] items = { "$0.10", "$0.20", "$0.50", "$1.00", "$1.70", "$2.00", "$2.90", "$3.70", "$5.00", "$10.00" };

            foreach (string item in items)
                dgvItems.Rows.Add(item, "0", "0");

            txtUser.Text = GlobalService.User;

            txtDepartment.Text = MasterUtil.Department();
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void dgvItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string cell = dgvItems.CurrentRow.Cells[0].Value.ToString().Substring(1);
                double type = Convert.ToDouble(cell);

                int qty = Convert.ToInt32(dgvItems.CurrentRow.Cells[1].Value);

                dgvItems.CurrentRow.Cells[2].Value = type * qty;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgvItems.EndEdit();

            string createdby = txtUser.Text.Trim();
            string created = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            string department = txtDepartment.Text.Trim();

            string s1qty = dgvItems.Rows[0].Cells[1].Value.ToString();
            double s1amt = Convert.ToDouble(dgvItems.Rows[0].Cells[2].Value);

            string s2qty = dgvItems.Rows[1].Cells[1].Value.ToString();
            double s2amt = Convert.ToDouble(dgvItems.Rows[1].Cells[2].Value);

            string s3qty = dgvItems.Rows[2].Cells[1].Value.ToString();
            double s3amt = Convert.ToDouble(dgvItems.Rows[2].Cells[2].Value);

            string s4qty = dgvItems.Rows[3].Cells[1].Value.ToString();
            double s4amt = Convert.ToDouble(dgvItems.Rows[3].Cells[2].Value);

            string s5qty = dgvItems.Rows[4].Cells[1].Value.ToString();
            double s5amt = Convert.ToDouble(dgvItems.Rows[4].Cells[2].Value);

            string s6qty = dgvItems.Rows[5].Cells[1].Value.ToString();
            double s6amt = Convert.ToDouble(dgvItems.Rows[5].Cells[2].Value);

            string s7qty = dgvItems.Rows[6].Cells[1].Value.ToString();
            double s7amt = Convert.ToDouble(dgvItems.Rows[6].Cells[2].Value);

            string s8qty = dgvItems.Rows[7].Cells[1].Value.ToString();
            double s8amt = Convert.ToDouble(dgvItems.Rows[7].Cells[2].Value);

            string s9qty = dgvItems.Rows[8].Cells[1].Value.ToString();
            double s9amt = Convert.ToDouble(dgvItems.Rows[8].Cells[2].Value);

            string s10qty = dgvItems.Rows[9].Cells[1].Value.ToString();
            double s10amt = Convert.ToDouble(dgvItems.Rows[9].Cells[2].Value);

            double total = s1amt + s2amt + s3amt + s4amt + s5amt + s6amt + s7amt + s8amt + s9amt + s10amt;
            string sectHead = UserUtil.GetSectionHead(UserUtil.GetSect(GlobalService.User));
            string divHead = UserUtil.GetDivisionHead(UserUtil.GetDivision(GlobalService.User));

            string adm1st = "Sammy Chow Chi To (周志滔)";
            string adm2nd = "Sammy Chow Chi To (周志滔)";

            string query = string.Format("insert into TB_ADM_FORM_STAMP (as_createdby, as_created, as_department, as_total, as_s1qty, as_s1amt, as_s2qty, as_s2amt" +
                ", as_s3qty, as_s3amt, as_s4qty, as_s4amt, as_s5qty, as_s5amt, as_s6qty, as_s6amt, as_s7qty, as_s7amt, as_s8qty, as_s8amt, as_s9qty, as_s9amt, as_s10qty, as_s10amt" +
                ", as_sect, as_div, as_adm1st, as_adm2nd) values (N'{0}', '{1}', N'{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}', '{12}', '{13}', '{14}', '{15}', '{16}', '{17}', '{18}', '{19}', '{20}', '{21}', '{22}', '{23}', N'{24}', N'{25}', N'{26}', N'{27}')",
                createdby, created, department, total, s1qty, s1amt, s2qty, s2amt, s3qty, s3amt, s4qty, s4amt, s5qty, s5amt, s6qty, s6amt, s7qty, s7amt, s8qty, s8amt, s9qty, s9amt, s10qty, s10amt, sectHead, divHead, adm1st, adm2nd);

            DataServiceCM.GetInstance().ExecuteNonQuery(query);

            string from = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), "kmhk.local");

            string to = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(sectHead, "kmhk.local"), "kmhk.local");

            string text = "Application Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
            string body = "<p><span style=\"font-family: Calibri;\">" + text + "</span></p>";
            EformUtil.SendApprovalEmail("", GlobalService.User, from, to, body, "Approval Required - 購買郵票依賴");

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
                    double value = Convert.ToDouble(row.Cells[2].Value);

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
