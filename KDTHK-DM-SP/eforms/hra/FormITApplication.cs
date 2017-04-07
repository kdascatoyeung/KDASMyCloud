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
using System.Net.Mail;
using KDTHK_DM_SP.forms;
using System.IO;
using System.Data.SqlClient;
using System.Diagnostics;

namespace KDTHK_DM_SP.eforms.hra
{
    public partial class FormITApplication : Form
    {
        //string _category = "";
        //string _area = "";

        string _mode = "";
        string _type = "";
        string _chaseno = "";

        public FormITApplication(string mode, string type, string chaseno, string status)
        {
            InitializeComponent();

            txtUser.Text = GlobalService.User;

            string head = EformUtil.GetHead(GlobalService.User);
            txtHead.Text = head;

            //rtbContent.Select();

            txtTitle.Select();

            _mode = mode;

            _type = type;

            _chaseno = chaseno;

            this.Text = "IT Application";

            dtpEnd.Value = dtpStart.Value.AddDays(7);

            Application.Idle += new EventHandler(Application_Idle);

            if (mode == "view")
            {
                if (chaseno.StartsWith("IT-0"))
                    LoadOriginalData(type, chaseno);
                else
                    LoadData(type, chaseno);

                txtUser.KeyPress += new KeyPressEventHandler(Keypressed);
                rtbContent.KeyPress += new KeyPressEventHandler(Keypressed);
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
                ckbSupport.Enabled = false;
                ckbComment.Enabled = false;
                txtHead.KeyPress += new KeyPressEventHandler(Keypressed);
                btnApplicant.Visible = false;
                btnUsers.Visible = false;
                txtTitle.KeyPress += new KeyPressEventHandler(Keypressed);
            }

            if (mode == "new")
                ckbCancel.Visible = false;
            else if (status == "申請已發送" && (type == "IT技術支援" || type == "IT意見箱"))
                ckbCancel.Visible = true;
            else if (status == "上司承認中")
                ckbCancel.Visible = true;
            else
                ckbCancel.Visible = false;
        }

        private void Keypressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            //ckbCancel.Enabled = _mode == "new" ? false : true;
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            rtbContent.Select();
        }

        private void LoadOriginalData(string type, string chaseno)
        {
            string query = string.Format("select f_applicant, f_content, f_start, f_end, f_approver, f_title from TB_FORM where f_chaseno = '{0}'", chaseno);

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    txtUser.Text = reader.GetString(0);
                    Byte[] content = new Byte[Convert.ToInt32((reader.GetBytes(1, 0, null, 0, Int32.MaxValue)))];
                    long bytesReceived = reader.GetBytes(1, 0, content, 0, content.Length);
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    rtbContent.Rtf = encoding.GetString(content, 0, Convert.ToInt32(bytesReceived));

                    if (type == "IT技術支援")
                        ckbSupport.Checked = true;
                    if (type == "IT意見箱")
                        ckbComment.Checked = true;

                    dtpStart.Value = Convert.ToDateTime(reader.GetString(2));
                    dtpEnd.Value = Convert.ToDateTime(reader.GetString(3));
                    txtHead.Text = reader.GetString(4);
                    txtTitle.Text = reader.GetString(5);
                }
            }
        }

        private void LoadData(string type, string chaseno)
        {
            string query = type == "IT技術支援" ? string.Format("select f_applicant, f_content, f_start, f_end, f_approver, f_title from TB_FORM, TB_FORM_SUPPORT where f_chaseno = s_refno and s_chaseno = '{0}'", chaseno)
                : type == "資產外借" ? string.Format("select f_applicant, f_content, f_start, f_end, l_approver, f_title from TB_FORM, TB_FORM_LOANING where f_chaseno = l_refno and l_chaseno = '{0}'", chaseno)
                : type == "權限關連及軟件安裝" ? string.Format("select f_applicant, f_content, f_start, f_end, p_approver, f_title from TB_FORM, TB_FORM_PERMISSION where f_chaseno = p_refno and p_chaseno = '{0}'", chaseno)
                : type == "系統開發/修改" ? string.Format("select f_applicant, f_content, f_start, f_end, d_approver, f_title from TB_FORM, TB_FORM_DEVELOP where f_chaseno = d_refno and d_chasneo = '{0}'", chaseno)
                : type == "IT意見箱" ? string.Format("select f_applicant, f_content, f_start, f_end, f_approver, f_title from TB_FORM, TB_FORM_COMMENT where f_chaseno = c_refno and c_chaseno = '{0}'", chaseno)
                : type == "R3申請"? string.Format("select f_applicant, f_content, f_start, f_end, f_approver, f_title from TB_FORM, TB_FORM_R3 where f_chaseno = r_refno and r_chaseno = '{0}'", chaseno)
                : string.Format("select f_applicant, f_content, f_start, f_end, f_approver, f_title from TB_FORM where f_chaseno = '{0}'", chaseno);

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    txtUser.Text = reader.GetString(0);
                    Byte[] content = new Byte[Convert.ToInt32((reader.GetBytes(1, 0, null, 0, Int32.MaxValue)))];
                    long bytesReceived = reader.GetBytes(1, 0, content, 0, content.Length);
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    rtbContent.Rtf = encoding.GetString(content, 0, Convert.ToInt32(bytesReceived));

                    if (type == "IT技術支援")
                        ckbSupport.Checked = true;
                    if (type == "IT意見箱")
                        ckbComment.Checked = true;

                    dtpStart.Value = Convert.ToDateTime(reader.GetString(2));
                    dtpEnd.Value = Convert.ToDateTime(reader.GetString(3));
                    txtHead.Text = reader.GetString(4);
                    txtTitle.Text = reader.GetString(5);
                }
            }
        }

        private void SaveData()
        {
            if (string.IsNullOrEmpty(txtTitle.Text))
            {
                MessageBox.Show("請輸入申請項目主題");
                return;
            }

            rtbContent.SaveFile("temp.rtf");
            FileStream stream = new FileStream("temp.rtf", FileMode.Open, FileAccess.Read);
            int size = Convert.ToInt32(stream.Length);
            Byte[] rtf = new Byte[size];
            stream.Read(rtf, 0, size);

            string user = txtUser.Text.Trim();

            string category = ckbSupport.Checked ? "IT技術支援" : ckbComment.Checked ? "IT意見箱" : "IT綜合申請";

            string start = dtpStart.Value.ToString("yyyy/MM/dd");

            string end = dtpEnd.Value.ToString("yyyy/MM/dd");

            string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string head = txtHead.Text.Trim();

            string chaseno = GetLatestChaseno();

            string title = txtTitle.Text.Trim();

            if (title.Contains("'")) title = title.Replace("'", "''");

            if (category != "IT技術支援" && category != "IT意見箱")
            {
                string query = string.Format("insert into TB_FORM (f_chaseno, f_type, f_content, f_start, f_end, f_created, f_createdby, f_status, f_applicant, f_approver, f_title)" +
                    " values ('{0}', N'{1}', @Content, '{2}', '{3}', '{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}')", chaseno, category, start, end, now, GlobalService.User, "上司承認中", user, head, title);

                SqlCommand cmd = new SqlCommand(query, DataService.GetInstance().Connection);

                SqlParameter param = new SqlParameter("@Content", SqlDbType.Image, rtf.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, rtf);
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                //Send Email
                string from = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), "kmhk.local");

                string to = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(head, "kmhk.local"), "kmhk.local");

                string text = "IT Application Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
                string body = "<p><span style=\"font-family: Calibri;\">" + text + "</span></p>";
                EformUtil.SendApprovalEmail(chaseno, GlobalService.User, from, to, body, txtTitle.Text.Trim());

            }
            else
            {
                string query = string.Format("insert into TB_FORM (f_chaseno, f_type, f_content, f_start, f_end, f_createdby, f_created, f_status, f_applicant, f_approver, f_title)" +
                    " values ('{0}', N'{1}', @Content, '{2}', '{3}', N'{4}', N'{5}', N'{6}', N'{7}', N'{8}', N'{9}')", chaseno, category, start, end, GlobalService.User, now, "申請已發送", user, "---", title);

                SqlCommand cmd = new SqlCommand(query, DataService.GetInstance().Connection);

                SqlParameter param = new SqlParameter("@Content", SqlDbType.Image, rtf.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, rtf);
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                string email = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), "kmhk.local");

                EformUtil.SendReceivedEmail(chaseno, email, txtTitle.Text.Trim());

                EformUtil.SendNotificationEmail(chaseno, category, GlobalService.User, email, txtTitle.Text.Trim(), rtbContent.Rtf, rtbContent.Width, rtbContent.Height, rtbContent);
            }

            DialogResult = DialogResult.OK;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ckbCancel.Checked)
            {
                string tablename = _type == "IT技術支援" ? "TB_FORM_SUPPORT" : _type == "資產外借" ? "TB_FORM_LOANING" : _type == "權限關連及軟件安裝" ? "TB_FORM_PERMISSION" : _type == "系統開發/修改" ? "TB_FORM_DEVELOP" : _type == "IT意見箱" ? "TB_FORM_COMMENT" : _type == "R3申請" ? "TB_FORM_R3" : "TB_FORM";

                List<string> querylist = new List<string>();

                string query = "";

                if (_chaseno.StartsWith("IT-0"))
                {
                    querylist.Add(string.Format("delete from TB_FORM_SUPPORT where s_refno = '{0}'", _chaseno));
                    querylist.Add(string.Format("delete from TB_FORM_LOANING where l_refno = '{0}'", _chaseno));
                    querylist.Add(string.Format("delete from TB_FORM_PERMISSION where p_refno = '{0}'", _chaseno));
                    querylist.Add(string.Format("delete from TB_FORM_DEVELOP where d_refno = '{0}'", _chaseno));
                    querylist.Add(string.Format("delete from TB_FORM_COMMENT where c_refno = '{0}'", _chaseno));
                    querylist.Add(string.Format("delete from TB_FORM where f_chaseno = '{0}'", _chaseno));
                    querylist.Add(string.Format("delete from TB_FORM_R3 where r_chaseno = '{0}'", _chaseno));
                }
                else
                {
                    query = _type == "IT技術支援" ? string.Format("delete from TB_FORM_SUPPORT where s_chaseno = '{0}'", _chaseno)
                        : _type == "資產外借" ? string.Format("delete from TB_FORM_LOANING where l_chaseno = '{0}'", _chaseno)
                        : _type == "權限關連及軟件安裝" ? string.Format("delete from TB_FORM_PERMISSION where p_chaseno = '{0}'", _chaseno)
                        : _type == "系統開發/修改" ? string.Format("delete from TB_FORM_DEVELOP where d_chaseno = '{0}'", _chaseno)
                        : _type == "IT意見箱" ? string.Format("delete from TB_FORM_COMMENT where c_chaseno = '{0}'", _chaseno)
                        : _type == "R3申請" ? string.Format("delete from TB_FORM_R3 where r_chaseno = '{0}'", _chaseno)
                        : string.Format("delete from TB_FORM where f_chaseno = '{0}'", _chaseno);

                    querylist.Add(query);
                }

                switch (MessageBox.Show("Are you sure to cancel the application?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:

                        foreach (string q in querylist)
                            DataService.GetInstance().ExecuteNonQuery(q);

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
            /*if (rtbContent.Text == null)
            {
                MessageBox.Show("Please input application CONTENT.");
                return;
            }

            string content = rtbContent.Text;

            string start = dtpStart.Value.ToString("yyyy/MM/dd");

            string end = dtpEnd.Value.ToString("yyyy/MM/dd");

            string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string head = txtHead.Text.Trim();

            string chaseno = GetLatestChaseno();

            string query = "";

            if (_category != "技術支援" && _category != "意見箱")
            {
                //query = string.Format("insert into TB_FORM (f_type, f_level, f_content, f_start, f_end, f_created, f_createdby, f_approver, f_emergency, f_chaseno, f_handleby)" +
                //" values (N'{0}', N'{1}', N'{2}', '{3}', '{4}', '{5}', N'{6}', N'{7}', '{8}', '{9}', N'{10}')", _category, _area, content, start, end, now, GlobalService.User, head, emergency, chaseno, incharge);

                DataService.GetInstance().ExecuteNonQuery(query);

                string from = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), "kmhk.local");

                string to = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(head, "kmhk.local"), "kmhk.local");

                string text = "IT Application Approval required. Please click <a href=\"\\\\kdthk-dm1\\project\\it system\\MyCloud Beta\\KDTHK-DM-SP.application\">HERE</a> to approval process.";
                string body = "<p><span style=\"font-family: Calibri;\">" + text + "</span></p>";
                EformUtil.SendApprovalEmail(chaseno, from, to, body);
            }
            else
            {
                //query = string.Format("insert into TB_FORM (f_type, f_level, f_content, f_start, f_end, f_created, f_createdby, f_approver, f_emergency, f_chaseno, f_status, f_handleby)" +
                //" values (N'{0}', N'{1}', N'{2}', '{3}', '{4}', '{5}', N'{6}', N'{7}', '{8}', '{9}', N'{10}', N'{11}')", _category, _area, content, start, end, now, GlobalService.User, "---", emergency, chaseno, "IT 已接收", incharge);

                DataService.GetInstance().ExecuteNonQuery(query);

                string email = AdUtil.GetEmailByUserId(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), "kmhk.local");

                EformUtil.SendReceivedEmail(chaseno, email);
            }

            DialogResult = DialogResult.OK;*/
        }

        private string GetLatestChaseno()
        {
            string query = "select top 1 f_chaseno from TB_FORM order by f_chaseno desc";

            string result = "";

            string chaseno = "";
            try
            {
                result = DataService.GetInstance().ExecuteScalar(query).ToString();

                result = result.Substring(3);

                int number = Convert.ToInt32(result) + 1;

                chaseno = "IT-" + number.ToString("D7");
            }
            catch
            {
                chaseno = "IT-0000001";
            }


            return chaseno;
        }

        private void txtHead_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            LoadUserHead();
        }

        private void txtHead_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            LoadUserHead();
        }

        private void LoadUserHead()
        {
            UserHeadForm form = new UserHeadForm("head");

            if (form.ShowDialog() == DialogResult.OK)
                txtHead.Text = GlobalService.SelectedUserHead;
        }

        private void LoadUser()
        {
            UserHeadForm form = new UserHeadForm("user");
            if (form.ShowDialog() == DialogResult.OK)
                txtUser.Text = GlobalService.SelectedUserHead;
        }

        private void ckbSupport_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSupport.Checked)
                ckbComment.Checked = false;
        }

        private void ckbComment_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbComment.Checked)
                ckbSupport.Checked = false;
        }

        private void btnApplicant_Click(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void txtUser_DoubleClick(object sender, EventArgs e)
        {
            LoadUser();
        }
    }
}
