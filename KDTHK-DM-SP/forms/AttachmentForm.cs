using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.lists;
using System.Diagnostics;
using KDTHK_DM_SP.services;

namespace KDTHK_DM_SP.forms
{
    public partial class AttachmentForm : Form
    {
        public AttachmentForm(List<AttachmentList> list)
        {
            InitializeComponent();

            this.LoadAttachment(list);
        }

        private void LoadAttachment(List<AttachmentList> list)
        {
            foreach (AttachmentList item in list)
                dgvAttachment.Rows.Add("False", item.FileName, item.LastModified, item.FilePath);
        }

        private void btnSend_MouseEnter(object sender, EventArgs e)
        {
            btnSend.ForeColor = Color.DodgerBlue;
        }

        private void btnSend_MouseLeave(object sender, EventArgs e)
        {
            btnSend.ForeColor = Color.Black;
        }

        private void dgvAttachment_DoubleClick(object sender, EventArgs e)
        {
            string path = dgvAttachment.SelectedRows[0].Cells[3].Value.ToString();

            Process.Start(path);
        }

        private void ckbAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvAttachment.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                cell.Value = ckbAll.Checked ? "True" : "False";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();

            Microsoft.Office.Interop.Outlook.MailItem mailitem = (Microsoft.Office.Interop.Outlook.MailItem)app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

            foreach (DataGridViewRow row in dgvAttachment.Rows)
            {
                string isChecked = row.Cells[0].FormattedValue.ToString();
                string filePath = row.Cells[3].Value.ToString();

                if (isChecked == "True")
                {
                    mailitem.Attachments.Add(filePath);

                    GlobalService.AttachmentList.RemoveAll(x => x.FilePath == filePath);
                }
            }

            mailitem.Display(false);

            this.LoadAttachment(GlobalService.AttachmentList);

            if (GlobalService.AttachmentList.Count == 0)
                this.DialogResult = DialogResult.OK;
        }
    }
}
