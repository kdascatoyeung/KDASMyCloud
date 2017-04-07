using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.utils;
using KDTHK_DM_SP.services;
using CustomUtil.utils.authentication;

namespace KDTHK_DM_SP.eforms.adm
{
    public partial class AdmParkForm : Form
    {
        public AdmParkForm()
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

            string dept = txtDepartment.Text.Trim();

            string company = txtCompany.Text.Trim();
            string license = txtLicense.Text.Trim();

            string dt = dtpDate.Value.ToString("yyyy/MM/dd");

            string timeFrom = txtFrom.Text.Trim();
            string timeTo = txtTo.Text.Trim();

            string others = txtOthers.Text.Trim();

            if (string.IsNullOrEmpty(license))
            {
                MessageBox.Show("請先輸入車牌號");
                return;
            }

            string sectHead = UserUtil.GetSectionHead(UserUtil.GetSect(GlobalService.User));
            string divHead = UserUtil.GetDivisionHead(UserUtil.GetDivision(GlobalService.User));

            string adm1st = "Sammy Chow Chi To (周志滔)";
            string adm2nd = "Sammy Chow Chi To (周志滔)";

            string query = string.Format("insert into TB_ADM_FORM_PARK (ap_createdby, ap_created, ap_department, ap_company, ap_license, ap_date, ap_others, ap_sect, ap_div, ap_adm1st, ap_adm2nd, ap_from, ap_to)" +
                " values (N'{0}', '{1}', N'{2}', N'{3}', '{4}', '{5}', N'{6}', N'{7}', N'{8}', N'{9}', N'{10}', '{11}', '{12}')", createdby, created, dept, company, license, dt, others, sectHead, divHead, adm1st, adm2nd, timeFrom, timeTo);

            DataServiceCM.GetInstance().ExecuteNonQuery(query);

            string from = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), "kmhk.local");

            string to = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(sectHead, "kmhk.local"), "kmhk.local");

            string text = "Application Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
            string body = "<p><span style=\"font-family: Calibri;\">" + text + "</span></p>";
            EformUtil.SendApprovalEmail("", GlobalService.User, from, to, body, "Approval Required - 訪客車位申請");

            MessageBox.Show("Record has been saved.");

            DialogResult = DialogResult.OK;
        }
    }
}
