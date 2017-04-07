using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;

namespace KDTHK_DM_SP.eforms
{
    public partial class FormInfo : Form
    {
        public FormInfo(string type, string chaseno)
        {
            InitializeComponent();

            this.Text = "Application Info - " + type;

            LoadData(type, chaseno);
        }

        private void LoadData(string type, string chaseno)
        {
            string query = type == "IT技術支援" ? string.Format("select f_applicant, f_content, f_start, f_end, f_approver, f_title from TB_FORM, TB_FORM_SUPPORT where f_chaseno = s_refno and s_chaseno = '{0}'", chaseno)
                : type == "資產外借" ? string.Format("select f_applicant, f_content, f_start, f_end, l_approver, f_title from TB_FORM, TB_FORM_LOANING where f_chaseno = l_refno and l_chaseno = '{0}'", chaseno)
                : type == "權限及軟件安裝" ? string.Format("select f_applicant, f_content, f_start, f_end, p_approver, f_title from TB_FORM, TB_FORM_PERMISSION where f_chaseno = p_refno and p_chaseno = '{0}'", chaseno)
                : type == "系統開發/修改" ? string.Format("select f_applicant, f_content, f_start, f_end, d_approver, f_title from TB_FORM, TB_FORM_DEVELOP where f_chaseno = d_refno and d_chasneo = '{0}'", chaseno)
                : type == "IT意見箱" ? string.Format("select f_applicant, f_content, f_start, f_end, f_approver, f_title from TB_FORM, TB_FORM_COMMENT where f_chaseno = c_refno and c_chaseno = '{0}'", chaseno)
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

                    txtStart.Text = reader.GetString(2);
                    txtEnd.Text = reader.GetString(3);
                    txtHead.Text = reader.GetString(4);
                    txtTitle.Text = reader.GetString(5);
                }
            }
        }

        private void rtbContent_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
