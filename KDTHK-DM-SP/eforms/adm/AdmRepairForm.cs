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
using KDTHK_DM_SP.forms;
using KDTHK_DM_SP.eforms.adm.subforms;
using CustomUtil.utils.authentication;

namespace KDTHK_DM_SP.eforms.adm
{
    public partial class AdmRepairForm : Form
    {
        public AdmRepairForm()
        {
            InitializeComponent();

            txtUser.Text = GlobalService.User;

            txtDepartment.Text = MasterUtil.Department();
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnDeptShared1_Click(object sender, EventArgs e)
        {
            DeptSelectionForm form = new DeptSelectionForm();

            if (form.ShowDialog() == DialogResult.OK)
                txtDeptShared1.Text = GlobalService.SelectedDepartment;
        }

        private void btnDeptShared2_Click(object sender, EventArgs e)
        {
            DeptSelectionForm form = new DeptSelectionForm();

            if (form.ShowDialog() == DialogResult.OK)
                txtDeptShared2.Text = GlobalService.SelectedDepartment;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sectHead = UserUtil.GetSectionHead(UserUtil.GetSect(GlobalService.User));
            string divHead = UserUtil.GetDivisionHead(UserUtil.GetDivision(GlobalService.User));
            //string deptHead = "Ho Kin Hang(何健恒,Ken)";// UserUtil.GetDepartmentHead(UserUtil.GetDept(GlobalService.User));

            string adm1st = "Sammy Chow Chi To (周志滔)";
            string adm2nd = "Sammy Chow Chi To (周志滔)";
            //string adm3rd = "Ho Kin Hang(何健恒,Ken)";//"Sammy Chow Chi To (周志滔)";

            string createdby = txtUser.Text.Trim();
            string created = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string department = txtDepartment.Text.Trim();

            string fee = txtFee.Text.Trim();

            string deptShared1 = txtDeptShared1.Text.Trim();
            string deptShared2 = txtDeptShared2.Text.Trim();

            string content = rtbContent.Text.Trim();

            string query = string.Format("insert into TB_ADM_FORM_REPAIR (ar_created, ar_createdby, ar_department, ar_fee, ar_deptshared1, ar_deptshared2" +
                ", ar_content, ar_sect, ar_div, ar_adm1st, ar_adm2nd) values ('{0}', N'{1}', N'{2}', '{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}')", created, createdby, department, fee,
                deptShared1, deptShared2, content, sectHead, divHead, adm1st, adm2nd);

            DataServiceCM.GetInstance().ExecuteNonQuery(query);

            string from = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), "kmhk.local");

            string to = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(sectHead, "kmhk.local"), "kmhk.local");

            string text = "Application Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
            string body = "<p><span style=\"font-family: Calibri;\">" + text + "</span></p>";
            EformUtil.SendApprovalEmail("", GlobalService.User, from, to, body, "Approval Required - 業務/修理依賴");

            MessageBox.Show("Record has been saved.");

            DialogResult = DialogResult.OK;
        }
    }
}
