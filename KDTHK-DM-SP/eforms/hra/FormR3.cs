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
using KDTHK_DM_SP.eforms.utils;
using System.IO;
using System.Diagnostics;

namespace KDTHK_DM_SP.eforms.hra
{
    public partial class FormR3 : Form
    {
        string _path = "";

        public FormR3(string chaseno)
        {
            InitializeComponent();

            LoadApplicationData(chaseno);

            LoadData(chaseno);
        }

        private void LoadApplicationData(string chaseno)
        {
            string refno = FormUtil.GetRefNo("r3", chaseno);

            string query = string.Format("select f_applicant, f_content, f_start, f_end, f_approver, f_title from TB_FORM where f_chaseno = '{0}'", refno);

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    txtUser.Text = reader.GetString(0);
                    Byte[] content = new Byte[Convert.ToInt32((reader.GetBytes(1, 0, null, 0, Int32.MaxValue)))];
                    long bytesReceived = reader.GetBytes(1, 0, content, 0, content.Length);
                    ASCIIEncoding encoding = new ASCIIEncoding();
                    rtbContent.Rtf = encoding.GetString(content, 0, Convert.ToInt32(bytesReceived));

                    dtpStart.Value = Convert.ToDateTime(reader.GetString(2));
                    dtpEnd.Value = Convert.ToDateTime(reader.GetString(3));
                    txtHead.Text = reader.GetString(4);
                    txtTitle.Text = reader.GetString(5);
                }
            }
        }

        private void LoadData(string chaseno)
        {
            string query = string.Format("select r_itcomment, r_itattachment from TB_FORM_R3 where r_chaseno = '{0}'", chaseno);

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    txtComment.Text = reader.GetString(0).Trim();

                    string path = reader.GetString(1).Trim();
                    _path = path;
                    lklAttachment.Text = Path.GetFileName(path);
                }
            }
        }

        private void lklAttachment_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(_path);
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
