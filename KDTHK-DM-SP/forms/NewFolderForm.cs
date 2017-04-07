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

namespace KDTHK_DM_SP.forms
{
    public partial class NewFolderForm : Form
    {
        string _destinationPath = "";
        string _mode = "";

        public NewFolderForm(string destinationPath, string mode)
        {
            InitializeComponent();

            _destinationPath = destinationPath;

            _mode = mode;
        }

        private void SaveData()
        {
            string folder = txtFolder.Text;

            if (string.IsNullOrEmpty(folder))
            {
                MessageBox.Show("Please input folder name");
                return;
            }

            if (DataUtil.IsVpathExists(GlobalService.RootTable, _destinationPath + @"\" + folder))
            {
                MessageBox.Show("Folder already exists.");
                return;
            }

            if (_mode == "new")
                GlobalService.TemporaryFolderList.Add(_destinationPath + @"\" + folder);

            GlobalService.NewFolder = folder;
            this.DialogResult = DialogResult.OK;
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SaveData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.SaveData();
        }
    }
}
