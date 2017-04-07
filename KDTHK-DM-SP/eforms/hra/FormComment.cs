using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.eforms.utils;
using KDTHK_DM_SP.services;

namespace KDTHK_DM_SP.eforms.hra
{
    public partial class FormComment : Form
    {
        public FormComment(string chaseno)
        {
            InitializeComponent();

            LoadApplicationData(chaseno);
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
            string refno = chaseno.StartsWith("IT-C") ? FormUtil.GetChaseNoByRefNo("comment", chaseno) : chaseno;

            string query = string.Format("select f_applicant, f_content, f_start, f_end from TB_FORM where f_chaseno = '{0}'", chaseno);

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
                }
            }
        }

        private void LoadData(string chaseno)
        {
            string query = chaseno.StartsWith("IT-C") ? string.Format("select s_answer from TB_FORM_SUPPORT where s_chaseno = '{0}'", chaseno)
                : string.Format("select s_answer from TB_FORM, TB_FORM_SUPPORT where s_refno = f_chaseno and s_refno = '{0}'", chaseno);

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    txtSolution.Text = reader.GetString(0);
            }
        }
    }
}
