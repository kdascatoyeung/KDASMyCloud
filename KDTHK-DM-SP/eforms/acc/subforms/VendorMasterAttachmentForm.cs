using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace KDTHK_DM_SP.eforms.acc.subforms
{
    public partial class VendorMasterAttachmentForm : Form
    {
        public VendorMasterAttachmentForm()
        {
            InitializeComponent();

            LoadData();
        }

        protected virtual bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;

            try
            {
                stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }

            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Multiselect = true;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] filenames = ofd.FileNames;

                List<string> errorList = new List<string>();

                foreach (string filename in filenames)
                {
                    FileInfo info = new FileInfo(filename);

                    if(IsFileLocked(info))
                        errorList.Add(info.Name);
                    else
                        AccService.attachmentList.Add(new AccAttachments { Filename = Path.GetFileNameWithoutExtension(filename), FilePath = filename });
                }

                LoadData();

                if (errorList.Count > 0)
                {
                    string message = "";

                    foreach (string error in errorList)
                        message = message + error + "\n";

                    MessageBox.Show("Error found. Please make sure below files availability.\n" + message);
                }

            }
        }

        private void LoadData()
        {
            dgvAttachment.Rows.Clear();

            foreach (AccAttachments item in AccService.attachmentList)
            {
                dgvAttachment.Rows.Add(item.Filename, item.FilePath, Properties.Resources.error_16);
            }
        }

        private void dgvAttachment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                AccService.attachmentList.RemoveAll(x => x.FilePath == dgvAttachment.CurrentRow.Cells[1].Value.ToString().Trim());
                dgvAttachment.Rows.Remove(dgvAttachment.CurrentRow);
            }
        }
    }
}
