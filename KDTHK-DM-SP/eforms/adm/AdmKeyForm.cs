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
using CustomUtil.utils.authentication;

namespace KDTHK_DM_SP.eforms.adm
{
    public partial class AdmKeyForm : Form
    {
        public AdmKeyForm()
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
            string created = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string department = txtDepartment.Text.Trim();

            string key = txtKey.Text.Trim();
            string remarks = txtRemarks.Text.Trim();

            string sectHead = UserUtil.GetSectionHead(UserUtil.GetSect(GlobalService.User));
            string divHead = UserUtil.GetDivisionHead(UserUtil.GetDivision(GlobalService.User));

            string adm1st = "Sammy Chow Chi To (周志滔)";
            string adm2nd = "Sammy Chow Chi To (周志滔)";

            string query = string.Format("insert into TB_ADM_FORM_KEY (ak_createdby, ak_created, ak_department, ak_key, ak_remarks, ak_sect, ak_div, ak_adm1st, ak_adm2nd)" +
                " values (N'{0}', '{1}', N'{2}', N'{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}')", createdby, created, department, key, remarks, sectHead, divHead, adm1st, adm2nd);

            DataServiceCM.GetInstance().ExecuteNonQuery(query);

            string from = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), "kmhk.local");

            string to = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(sectHead, "kmhk.local"), "kmhk.local");

            string text = "Application Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
            string body = "<p><span style=\"font-family: Calibri;\">" + text + "</span></p>";
            EformUtil.SendApprovalEmail("", GlobalService.User, from, to, body, "Approval Required - 複製鎖匙依賴");

            MessageBox.Show("Record has been saved.");

            DialogResult = DialogResult.OK;
        }
    }
}
