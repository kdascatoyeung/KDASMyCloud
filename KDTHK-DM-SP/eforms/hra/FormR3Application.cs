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
using System.IO;
using CustomUtil.utils.authentication;

namespace KDTHK_DM_SP.eforms.hra
{
    public partial class FormR3Application : Form
    {
        string _mode = "";
        string _chaseno = "";

        public FormR3Application(string mode, string chaseno, string status)
        {
            InitializeComponent();

            _mode = mode;
            _chaseno = chaseno;

            if (mode == "view")
            {
                cbType.Enabled = false;
                cbR3Type.Enabled = false;
                txtR3Id.KeyPress += new KeyPressEventHandler(KeyPressed);
                txtRequest.KeyPress += new KeyPressEventHandler(KeyPressed);
                txtReason.KeyPress += new KeyPressEventHandler(KeyPressed);
                dtpStart.Enabled = false;
                btnBrowse.Enabled = false;
                btnUsers.Enabled = false;

                LoadData();
            }
            else
            {
                cbType.SelectedIndex = 0;
                cbR3Type.SelectedIndex = 0;

                txtR3Id.PromptText = "可輸入多個R/3 用戶ID (請在ID後加上用戶姓名)\nR/3 用戶 ID 格式 : H+'xxxxxx'\n例: H123456 陳大文";

                txtHead.Text = EformUtil.GetHead(GlobalService.User);
            }

            if (mode == "new")
                ckbCancel.Visible = false;
            else if (status == "上司承認中")
                ckbCancel.Visible = true;
            else
                ckbCancel.Visible = false;
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void LoadData()
        {
            string query = string.Format("select r_category, r_type, r_r3id, r_request, r_reason, r_start, r_attachment, r_approver from TB_FORM_R3 where r_chaseno = '{0}'", _chaseno);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    cbType.Text = reader.GetString(0);
                    cbR3Type.Text = reader.GetString(1);
                    txtR3Id.Text = reader.GetString(2);
                    txtRequest.Text = reader.GetString(3);
                    txtReason.Text = reader.GetString(4);
                    dtpStart.Value = Convert.ToDateTime(reader.GetString(5));
                    txtAttachment.Text = reader.GetString(6);
                    txtHead.Text = reader.GetString(7);
                }
            }
        }

        private void BrowseFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtAttachment.Text = ofd.FileName;
            }
        }

        private void txtAttachment_DoubleClick(object sender, EventArgs e)
        {
            BrowseFile();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            BrowseFile();
        }

        private void SaveData()
        {
            string applicant = GlobalService.User;
            string category = cbType.SelectedItem.ToString().Trim();
            string type = cbR3Type.SelectedItem.ToString().Trim();
            string title = "R3申請 - " + category + type;
            string r3id = txtR3Id.Text.Trim();
            string request = txtRequest.Text.Trim();
            string reason = txtReason.Text.Trim();
            string start = dtpStart.Value.ToString("yyyy/MM/dd");
            string attachment = txtAttachment.Text.Trim() != "" ? txtAttachment.Text.Trim() : "";
            string approver = txtHead.Text.Trim();

            string cmApprover = GlobalService.User;//"Hara Masatoshi(原雅俊)";
            string itApprover = GlobalService.User;//"Chan Fai Lung(陳輝龍,Onyx)";

            string chaseno = GetLatestChaseno();

            string filePath = "";

            if (attachment != "")
            {
                string filename = Path.GetFileName(attachment);
                string directory = @"\\kdthk-dm1\project\kdthk-dm\Forms\R3 Application\" + GlobalService.User + @"\";

                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                File.Copy(attachment, directory + filename, true);

                filePath = directory + filename;
            }

            string query = string.Format("insert into TB_FORM_R3 (r_applicant, r_title, r_category, r_type, r_r3id, r_request, r_reason" +
                ", r_start, r_attachment, r_approver, r_cmapprover, r_itapprover, r_created, r_chaseno) values (N'{0}', N'{1}', N'{2}', '{3}', N'{4}', N'{5}', N'{6}', '{7}', N'{8}', N'{9}', N'{10}', N'{11}', '{12}', '{13}')",
                applicant, title, category, type, r3id, request, reason, start, filePath, approver, cmApprover, itApprover, DateTime.Today.ToString("yyyy/MM/dd"), chaseno);

            DataService.GetInstance().ExecuteNonQuery(query);

            string from = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), "kmhk.local");

            string to = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(approver, "kmhk.local"), "kmhk.local");

            string text = "IT Application Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
            string body = "<p><span style=\"font-family: Calibri;\">" + text + "</span></p>";
            EformUtil.SendApprovalEmail(chaseno, GlobalService.User, from, to, body, title);

            DialogResult = DialogResult.OK;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ckbCancel.Checked)
            {
                switch (MessageBox.Show("Are you sure to cancel the application?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:

                        string query = string.Format("delete from TB_FORM_R3 where r_chaseno = '{0}'", _chaseno);
                        DataService.GetInstance().ExecuteNonQuery(query);

                        MessageBox.Show("Record has been cancelled.");

                        DialogResult = DialogResult.OK;
                        break;

                    case DialogResult.No:
                        break;
                }
            }
            else
            {
                if (_mode == "new")
                    SaveData();
                else
                    DialogResult = DialogResult.OK;
            }
        }

        private string GetLatestChaseno()
        {
            string query = "select top 1 r_chaseno from TB_FORM_R3 order by r_chaseno desc";

            string result = "";

            string chaseno = "";
            try
            {
                result = DataService.GetInstance().ExecuteScalar(query).ToString();

                result = result.Substring(5);

                int number = Convert.ToInt32(result) + 1;

                chaseno = "IT-R-" + number.ToString("D7");
            }
            catch
            {
                chaseno = "IT-R-0000001";
            }


            return chaseno;
        }
    }
}
