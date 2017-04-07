using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using KDTHK_DM_SP.utils;
using CustomUtil.utils.authentication;
using KDTHK_DM_SP.services;
using System.Data.SqlServerCe;
using System.Diagnostics;

namespace KDTHK_DM_SP.forms
{
    public partial class RenameForm : Form
    {
        string _mode = "";
        string _filePath = "";
        string _vpath = "";

        public RenameForm(string source, string filePath, string mode, string vpath)
        {
            InitializeComponent();

            txtSource.Text = source;

            txtTarget.Text = source;

            _mode = mode;

            _filePath = filePath;

            _vpath = vpath;

            this.Text = _mode == "file" ? "Rename Wizard - File" : "Rename Wizard - Folder";

            txtTarget.Select();
        }

        private void SaveDataFile(DataTable table, string path)
        {
            if (string.IsNullOrEmpty(txtTarget.Text))
            {
                MessageBox.Show("Please input file name.");
                return;
            }

            string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

            DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

            string newPath = path.Replace(txtSource.Text, txtTarget.Text);

            //bool confirmed = true;

            //Debug.WriteLine(newPath);

            /*if (File.Exists(newPath))
            {
                Debug.WriteLine("exists");
                switch (MessageBox.Show("Filename " + txtTarget.Text + " already exists. Do you want to overwrite it?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        File.Delete(newPath);
                        break;

                    case DialogResult.No:
                        confirmed = false;
                        break;
                }
            }*/

            //if (confirmed)
            //{
                File.Move(path, newPath);

                string fileName = txtTarget.Text;

                if (fileName.Contains("'"))
                    fileName = fileName.Replace("'", "''");

                string newPathSave = newPath.Contains("'") ? newPath.Replace("'", "''") : newPath;

                string tableName = "TB_" + AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local");

                List<string> sharedList = DataUtil.GetLocalSharedList(GlobalService.RootTable, path);

                List<string> queryList = new List<string>();

                foreach (DataRow row in table.Rows)
                {
                    row["filepath"] = newPath;
                    row["filename"] = txtTarget.Text;
                }

                if (sharedList.Count > 0)
                {
                    foreach (string shared in sharedList)
                    {
                        if (!UserUtil.IsCnMember(shared.Trim()) && !UserUtil.IsVnMember(shared.Trim()) && !UserUtil.IsJpMember(shared.Trim()))
                        {
                            string sharedTable = "TB_" + AdUtil.GetUserIdByUsername(shared.Trim(), "kmhk.local");

                            string sharedText = string.Format("update " + sharedTable + " set r_path = N'{0}', r_filename = N'{1}' where r_path = N'{2}'", newPathSave, fileName, sPath);
                            DataService.GetInstance().ExecuteNonQuery(sharedText);
                        }
                        else
                        {
                            string sharedText = string.Format("update TB_OUTSIDE_SHARE set o_path = N'{0}', o_filename = N'{1}' where o_path = N'{2}'", newPathSave, fileName, sPath);
                            DataService.GetInstance().ExecuteNonQuery(sharedText);
                        }
                    }
                }

                string ownerText = string.Format("update " + GlobalService.DbTable + " set r_path = N'{0}', r_filename = N'{1}' where r_path = N'{2}'", newPathSave, fileName, sPath);

                DataService.GetInstance().ExecuteNonQuery(ownerText);
            //}
        }

        private void SaveDataFolder(DataTable table, List<string> pathList)
        {
            if (string.IsNullOrEmpty(txtTarget.Text))
            {
                MessageBox.Show("Please input folder name.");
                return;
            }

            string newFolderName = txtTarget.Text;

            string newFolderNameSave = newFolderName.Contains("'") ? newFolderName.Replace("'", "''") : newFolderName;

            string newVpath = _vpath.Substring(0, _vpath.LastIndexOf("\\")) + @"\" + txtTarget.Text;

            string newVpathSave = newVpath.Contains("'") ? newVpath.Replace("'", "''") : newVpath;

            foreach (string path in pathList)
            {
                string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

                DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

                foreach (DataRow row in rows)
                {
                    row["vpath"] = newVpath;

                    string text = string.Format("update " + GlobalService.DbTable + " set r_vpath = replace(r_vpath, N'{0}', N'{1}') where r_path = N'{2}'", _vpath, newVpathSave, sPath);

                    DataService.GetInstance().ExecuteNonQuery(text);
                }
            }
        }

        private void txtSource_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtSource_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
                Clipboard.SetText(txtSource.Text);
        }

        private void txtTarget_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (_mode == "file")
                    this.SaveDataFile(GlobalService.RootTable, _filePath);
                else
                {
                    List<string> pathList = DataUtil.GetFolderPathList(GlobalService.RootTable, _vpath);
                    this.SaveDataFolder(GlobalService.RootTable, pathList);
                }

                DialogResult = DialogResult.OK;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (_mode == "file")
                    this.SaveDataFile(GlobalService.RootTable, _filePath);
                else
                {
                    List<string> pathList = DataUtil.GetFolderPathList(GlobalService.RootTable, _vpath);
                    this.SaveDataFolder(GlobalService.RootTable, pathList);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
            this.DialogResult = DialogResult.OK;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
