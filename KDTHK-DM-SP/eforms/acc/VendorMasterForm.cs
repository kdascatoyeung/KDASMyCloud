using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.eforms.acc.subforms;
using KDTHK_DM_SP.utils;
using KDTHK_DM_SP.services;
using CustomUtil.utils.authentication;

namespace KDTHK_DM_SP.eforms.acc
{
    public partial class VendorMasterForm : Form
    {
        public VendorMasterForm()
        {
            InitializeComponent();

            cbAppType.SelectedIndex = 0;

            cbVendorType.SelectedIndex = 0;

            cbCurrency.SelectedIndex = 0;

            cbFob.SelectedIndex = 0;

            AccService.attachmentList = new List<AccAttachments>();

            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            txtReason.Enabled = cbAppType.SelectedIndex == 0 ? false : true;

            cbVendorType.Enabled = cbAppType.SelectedIndex == 0 ? true : false;

            cbVendorType.Text = cbAppType.SelectedIndex == 0 ? cbVendorType.Items[0].ToString() : "-";
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void lklAttachment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VendorMasterAttachmentForm form = new VendorMasterAttachmentForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                lklAttachment.Text = "(" + AccService.attachmentList + ") attachments.";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string appType = cbAppType.SelectedItem.ToString().Trim();
            string reason = txtReason.Text.Trim();

            string vendorType = cbVendorType.SelectedItem.ToString().Trim();

            string vendorCode = txtVendorCode.Text.Trim();
            string vendorName = txtVendorName.Text.Trim();

            string addr1 = txtAddr1.Text.Trim();
            string addr2 = txtAddr2.Text.Trim();
            string addr3 = txtAddr3.Text.Trim();

            string person = txtPerson.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            string currency = cbCurrency.SelectedItem.ToString().Trim();
            string payterm = txtPayterm.Text.Trim();
            string fob = cbFob.SelectedItem.ToString().Trim();

            if (reason.Contains("'")) reason = reason.Replace("'", "''");

            if (vendorName.Contains("'")) vendorName = vendorName.Replace("'", "''");

            if (addr1.Contains("'")) addr1 = addr1.Replace("'", "''");

            if (addr2.Contains("'")) addr2 = addr2.Replace("'", "''");

            if (addr3.Contains("'")) addr3 = addr3.Replace("'", "''");

            string divHead = "Ho Kin Hang(何健恒,Ken)";//UserUtil.GetDiv(GlobalService.User);

            string cm1st = "Ho Kin Hang(何健恒,Ken)"; //"Ng Wai Kwan(吳蕙君,Wendy)";
            string cm2nd = "Ho Kin Hang(何健恒,Ken)"; //"Li Yuen Yan(李婉茵,Sharon)";
            string cm3rd = "Ho Kin Hang(何健恒,Ken)"; //"Leung Wai Yip(梁偉業,Philip)";
            string cm4th = "Ho Kin Hang(何健恒,Ken)"; //"Hara Masatoshi(原雅俊)";

            string attachment = "";


            string query = string.Format("insert into TB_ACC_VENDOR (v_type, v_reason, v_vendortype, v_code, v_name, v_addr1, v_addr2, v_addr3, v_person, v_phone, v_email" +
                ", v_currency, v_payterm, v_fob, v_attachment, v_created, v_createdby, v_div, v_cm1st, v_cm2nd, v_cm3rd, v_cm4th) values ('{0}', N'{1}', N'{2}', '{3}', N'{4}', N'{5}', N'{6}'" +
                ", N'{7}', N'{8}', '{9}', '{10}', '{11}', '{12}', '{13}', N'{14}', '{15}', N'{16}', N'{17}', N'{18}', N'{19}', N'{20}', N'{21}')", appType, reason, vendorType, vendorCode, vendorName,
                addr1, addr2, addr3, person, phone, email, currency, payterm, fob, "", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), GlobalService.User, divHead, cm1st, cm2nd, cm3rd, cm4th);

            DataServiceCM.GetInstance().ExecuteNonQuery(query);

            EformUtil.SendApprovalEmail("", GlobalService.User, AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local"), AdUtil.GetEmailByUsername(divHead, "kmhk.local"), "", "Vendor Master Application - " + appType);

            DialogResult = DialogResult.OK;
        }
    }
}
