using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using KDTHK_DM_SP.eforms.utils;

namespace KDTHK_DM_SP.eforms.hra
{
    public partial class FormPermission : Form
    {
        public FormPermission(string chaseno)
        {
            InitializeComponent();

            LoadApplicationData(chaseno);

            LoadData(chaseno);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void LoadApplicationData(string chaseno)
        {
            string refno = FormUtil.GetFormChaseNoByRefno("permission", chaseno);

            string query = string.Format("select f_applicant, f_content, f_start, f_end, p_approver from TB_FORM, TB_FORM_PERMISSION where f_chaseno = p_refno and f_chaseno = '{0}'", refno);

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    txtUser.Text = reader.GetString(0);
                    Byte[] content = new Byte[Convert.ToInt32((reader.GetBytes(1, 0, null, 0, Int32.MaxValue)))];
                    long bytesReceived = reader.GetBytes(1, 0, content, 0, content.Length);
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    rtbContent.Rtf = encoding.GetString(content, 0, Convert.ToInt32(bytesReceived));

                    ckbComment.Checked = true;
                    txtStart.Text = reader.GetString(2);
                    txtEnd.Text = reader.GetString(3);
                    txtHead.Text = reader.GetString(4);
                }
            }
        }

        private void LoadData(string chaseno)
        {
            string query = string.Format("select p_item, p_user, p_start, p_type, p_detail from TB_FORM_PERMISSION where p_chaseno = '{0}'", chaseno);

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string item = reader.GetString(0);
                    string user = reader.GetString(1);
                    string start = reader.GetString(2);
                    string type = reader.GetString(3);

                    dgvPermission.Rows.Add(item, user, start, type);

                    Byte[] content = new Byte[Convert.ToInt32((reader.GetBytes(4, 0, null, 0, Int32.MaxValue)))];
                    long bytesReceived = reader.GetBytes(4, 0, content, 0, content.Length);
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    rtbDetail.Rtf = encoding.GetString(content, 0, Convert.ToInt32(bytesReceived));
                }
            }
        }
    }
}
