using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using System.IO;
using System.Diagnostics;
using KDTHK_DM_SP.utils;
using CustomUtil.utils.authentication;

namespace KDTHK_DM_SP.eforms
{
    public partial class FormR3Info : Form
    {
        string _attachment = "";
        string _status = "";
        string _chaseno = "";
        string _applicant = "";
        string _title = "";

        public FormR3Info(string chaseno)
        {
            InitializeComponent();

            _chaseno = chaseno;

            LoadData(chaseno);

            if (_status == "經管承認中")
                lblCM.ForeColor = Color.Red;
        }

        private void LoadData(string chaseno)
        {
            string query = string.Format("select r_category, r_type, r_content, r_start, r_itattachment, r_status, r_applicant, r_title, r_itcomment from TB_FORM_R3 where r_chaseno = '{0}'", chaseno);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    txtType.Text = reader.GetString(0);
                    txtR3Type.Text = reader.GetString(1);
                    txtContent.Text = reader.GetString(8);
                    txtStart.Text = reader.GetString(3);
                    string attachment = reader.GetString(4);
                    if (attachment != "")
                    {
                        lklAttachment.Text = Path.GetFileName(attachment);
                        _attachment = attachment;
                    }
                    else
                        lklAttachment.Text = "No Attachment";

                    _status = reader.GetString(5);
                    _applicant = reader.GetString(6);
                    _title = reader.GetString(7);

                }
            }
        }

        private void lklAttachment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_attachment != "")
                Process.Start(_attachment);
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            if (!rbtnApprove.Checked && !rbtnReject.Checked)
                DialogResult = DialogResult.Cancel;
            else if (rbtnApprove.Checked)
            {
                string query = _status == "上司承認中" ? string.Format("update TB_FORM_R3 set r_approval = 'Yes', r_status = N'申請已發送' where r_chaseno = '{0}'", _chaseno)
                    : string.Format("update TB_FORM_R3 set r_cmapproval = 'Yes', r_cmappdate = '{0}', r_status = N'申請處理完成' where r_chaseno = '{1}'", now, _chaseno);

                DataService.GetInstance().ExecuteNonQuery(query);

                if (_status == "上司承認中")
                {
                    string mail = AdUtil.GetEmailByUsername(_applicant, "kmhk.local");
                    EformUtil.SendR3NotificationEmail(_chaseno, "R3申請", _applicant, mail, _title, EformUtil.GetR3Id(_chaseno), EformUtil.GetR3Request(_chaseno), EformUtil.GetR3Reason(_chaseno));
                }
                else
                {
                    EformUtil.SendNotificationEmail(_chaseno, "R3申請", GlobalService.User, AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local"), "經管承認完了", "", 0, 0, null);
                }
                DialogResult = DialogResult.OK;
            }
            else
            {
                string query = _status == "上司承認中" ? string.Format("update TB_FORM_R3 set r_approval = 'Reject', r_status = N'上司已拒絕' where r_chaseno = '{0}'", _chaseno)
                    : string.Format("update TB_FORM_R3 set r_cmapproval = 'Reject', r_status = N'經管已拒絕' where r_chaseno = '{0}'", _chaseno);

                DataService.GetInstance().ExecuteNonQuery(query);

                EformUtil.SendNotificationEmail(_chaseno, "R3申請", GlobalService.User, AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local"), "經管已拒絕", "", 0, 0, null);

                DialogResult = DialogResult.OK;
            }
        }
    }
}
