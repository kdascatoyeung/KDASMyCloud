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
    public partial class AdmVisaForm : Form
    {
        public AdmVisaForm()
        {
            InitializeComponent();

            txtUser.Text = GlobalService.User;

            txtDepartment.Text = MasterUtil.Department();

            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            txtOthers.Enabled = ckbOthers.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string createdby = txtUser.Text.Trim();
            string created = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string department = txtDepartment.Text.Trim();

            string china = ckbChina.Checked ? "Yes" : "No";
            string taiwan = ckbTaiwan.Checked ? "Yes" : "No";
            string india = ckbIndia.Checked ? "Yes" : "No";
            string czech = ckbCzech.Checked ? "Yes" : "No";
            string usa = ckbUsa.Checked ? "Yes" : "No";
            string vietnam1 = ckbVietnam1.Checked ? "Yes" : "No";
            string vietnam2 = ckbVietnam2.Checked ? "Yes" : "No";
            string others = txtOthers.Text.Trim();

            string date = dtpDate.Value.ToString("yyyy/MM/dd");
            string reason = txtReason.Text.Trim();

            string sectHead = UserUtil.GetSectionHead(UserUtil.GetSect(GlobalService.User));
            string divHead = UserUtil.GetDivisionHead(UserUtil.GetDivision(GlobalService.User));

            string adm1st = "Sammy Chow Chi To (周志滔)";
            string adm2nd = "Sammy Chow Chi To (周志滔)";

            string query = string.Format("insert into TB_ADM_FORM_VISA (av_createdby, av_created, av_department, av_china, av_taiwan, av_india, av_czech" +
                ", av_usa, av_vietnam1, av_vietnam2, av_others, av_indate, av_reason, av_sect, av_div, av_adm1st, av_adm2nd) values (N'{0}', '{1}', N'{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', N'{10}', '{11}', N'{12}', N'{13}', N'{14}', N'{15}', N'{16}')",
                createdby, created, department, china, taiwan, india, czech, usa, vietnam1, vietnam2, others, date, reason, sectHead, divHead, adm1st, adm2nd);

            DataServiceCM.GetInstance().ExecuteNonQuery(query);

            string from = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), "kmhk.local");

            string to = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(sectHead, "kmhk.local"), "kmhk.local");

            string text = "Application Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
            string body = "<p><span style=\"font-family: Calibri;\">" + text + "</span></p>";
            EformUtil.SendApprovalEmail("", GlobalService.User, from, to, body, "Approval Required - 簽証申請");

            MessageBox.Show("Record has been saved.");

            DialogResult = DialogResult.OK;
        }
    }
}
