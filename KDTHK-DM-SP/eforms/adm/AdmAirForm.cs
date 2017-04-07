﻿using System;
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
    public partial class AdmAirForm : Form
    {
        public AdmAirForm()
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

            string shared = txtDeptShared.Text.Trim();

            string date = dtpDate.Value.ToString("yyyy/MM/dd");
            string from = txtFrom.Text.Trim();
            string to = txtTo.Text.Trim();
            string floor = txtFloor.Text.Trim();
            string reason = txtReason.Text.Trim();

            string sectHead = UserUtil.GetSectionHead(UserUtil.GetSect(GlobalService.User));
            string divHead = UserUtil.GetDivisionHead(UserUtil.GetDivision(GlobalService.User));

            string adm1st = "Sammy Chow Chi To (周志滔)";
            string adm2nd = "Sammy Chow Chi To (周志滔)";

            string query = string.Format("insert into TB_ADM_FORM_AIR (aa_createdby, aa_created, aa_department, aa_feedept, aa_date, aa_floor, aa_from, aa_to, aa_reason, aa_sect, aa_div, aa_adm1st, aa_adm2nd)" +
                " values (N'{0}', '{1}', N'{2}', N'{3}', '{4}', '{5}', '{6}', '{7}', N'{8}', N'{9}', N'{10}', N'{11}', N'{12}')", createdby, created, dept, shared, date, floor, from, to, reason, sectHead, divHead, adm1st, adm2nd);

            DataServiceCM.GetInstance().ExecuteNonQuery(query);

            string fromEmail = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), "kmhk.local");

            string toEmail = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(sectHead, "kmhk.local"), "kmhk.local");

            string text = "Application Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
            string body = "<p><span style=\"font-family: Calibri;\">" + text + "</span></p>";
            EformUtil.SendApprovalEmail("", GlobalService.User, fromEmail, toEmail, body, "Approval Required - 加冷氣申請");

            MessageBox.Show("Record has been saved.");

            DialogResult = DialogResult.OK;
        }
    }
}
