using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.lists;
using KDTHK_DM_SP.utils;
using KDTHK_DM_SP.services;
using System.Runtime.InteropServices;
using Common;
using System.IO;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Data.SqlServerCe;
using System.Diagnostics;

namespace KDTHK_DM_SP.forms
{
    public partial class DocumentForm : Form
    {
        string _defaultPath = "";

        public readonly Guid Downloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken, out string pszPath);

        List<string> sharedList = new List<string>();

        public DocumentForm(List<UploadFileList> uploadList, string defaultPath)
        {
            InitializeComponent();

            TreeviewUtil.LoadPersonalFolder(tvFolder, GlobalService.User);

            string division = GlobalService.Division;

            /*if (defaultPath.StartsWith(@"\Documents\" + division) || defaultPath.StartsWith(@"\Documents\Common") || defaultPath.StartsWith(@"\Documents\23600"))
                _defaultPath = defaultPath.Substring(10);
            else*/
                _defaultPath = defaultPath;

            this.AddData(uploadList, _defaultPath);

            //Debug.WriteLine(_defaultPath);

            cbAutoDelete.SelectedIndex = 0;

            dgvDocSetup.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvDocSetup.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void AddData(List<UploadFileList> uploadList, string defaultPath)
        {
            foreach (UploadFileList item in uploadList)
            {
                string fileName = item.FileName;
                string filePath = item.FilePath;
                string mode = item.Mode;
                string dragMode = item.DragMode;
                string favoriteMode = item.Favorite.Trim() == "True" ? "Yes" : "---";
                string folderName = item.FolderName;

                Debug.WriteLine(fileName);
                if (fileName.Contains("thumbs.db") || fileName.Contains("Thumbs.db"))
                    continue;

                string MyDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string MyPicturePath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
                string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string DownloadPath = "";
                SHGetKnownFolderPath(Downloads, 0, IntPtr.Zero, out DownloadPath);

                string departmentFolder = GlobalService.DepartmentFolder;

                string directory = filePath.StartsWith(@"M:\") ? filePath.Replace(@"M:\", @"\\kdthk-dm1\project\")
                    : filePath.StartsWith(@"L:\") ? filePath.Replace(@"L:\", departmentFolder + @"\")
                    : filePath.StartsWith(@"\\kdthk-dm1\Project\") ? filePath.Replace("Project", "project")
                    : filePath.StartsWith(@"\\kdthk-dm1\PROJECT\") ? filePath.Replace("PROJECT", "project")
                    : filePath.StartsWith(@"\\kdthk-dm1") ? filePath : @"\\kdthk-dm1\project\KDTHK-DM\" + AdUtil.getAccount() + @"\" + fileName;

                string tidyFilePath = filePath.StartsWith(@"\\kdthk-dm1\department\mcc\common") ? filePath.Replace(@"\\kdthk-dm1\department\mcc\common", @"\\kdthk-dm1\mcc$\Common")
                    : filePath.StartsWith(@"\\kdthk-dm1\Department\MCC\common") ? filePath.Replace(@"\\kdthk-dm1\Department\MCC\common", @"\\kdthk-dm1\mcc$\Common")
                    : filePath.StartsWith(@"\\kdthk-dm1\department\rps") ? filePath.Replace(@"\\kdthk-dm1\department\rps", @"\\kdthk-dm1\rps$")
                    : filePath.StartsWith(@"\\kdthk-dm1\department\ga") ? filePath.Replace(@"\\kdthk-dm1\department\ga", @"\\kdthk-dm1\ga$")
                    : filePath.StartsWith(@"\\kdthk-dm1\department\cm") ? filePath.Replace(@"\\kdthk-dm1\department\cm", @"\\kdthk-dm1\cm$")
                    : filePath.StartsWith(@"\\kdthk-dm1\department\ipo purchasing") ? filePath.Replace(@"\\kdthk-dm1\department\ipo purchasing", @"\\kdthk-dm1\ipo$")
                    : filePath.StartsWith(@"\\kdthk-dm1\department\logistics") ? filePath.Replace(@"\\kdthk-dm1\department\logistics", @"\\kdthk-dm1\logistics$")
                    : filePath;

                if (defaultPath.StartsWith(@"\Favorite"))
                    defaultPath = defaultPath.Replace(@"\Favorite", "");

                string structure = @"\Documents";

                if (tidyFilePath.StartsWith(MyDocumentPath))
                {
                    structure = tidyFilePath.Replace(MyDocumentPath, "");

                    if (dragMode == "folder")
                    {
                        structure = structure.Substring(0, structure.LastIndexOf("\\"));

                        //if (structure.Contains("\\"))
                           // structure = structure.Substring(structure.LastIndexOf("\\"));
                    }
                    else
                        structure = "";

                    structure = defaultPath + structure;
                }

                else if (tidyFilePath.StartsWith(MyPicturePath))
                {
                    structure = tidyFilePath.Replace(MyPicturePath, "");

                    if (dragMode == "folder")
                    {
                        structure = structure.Substring(0, structure.LastIndexOf("\\"));

                        //if (structure.Contains("\\"))
                           // structure = structure.Substring(structure.LastIndexOf("\\"));
                    }
                    else
                        structure = "";

                    structure = defaultPath + structure;
                }

                else if (tidyFilePath.StartsWith(DownloadPath))
                {
                    structure = tidyFilePath.Replace(DownloadPath, "");

                    if (dragMode == "folder")
                    {
                        structure = structure.Substring(0, structure.LastIndexOf("\\"));

                        //if (structure.Contains("\\"))
                           // structure = structure.Substring(structure.LastIndexOf("\\"));
                    }
                    else
                        structure = "";

                    structure = defaultPath + structure;
                }

                else if (tidyFilePath.StartsWith(DesktopPath))
                {
                    if (tidyFilePath.Contains("MyCloud Sync"))
                        structure = tidyFilePath.Replace(DesktopPath + @"\MyCloud Sync", "");
                    else
                        structure = tidyFilePath.Replace(DesktopPath, "");

                    if (dragMode == "folder")
                    {
                        structure = structure.Substring(0, structure.LastIndexOf("\\"));

                        

                        //structure = structure.Substring(structure.IndexOf(folderName));
                    }
                    else
                        structure = "";

                    structure = defaultPath + structure;
                }

                else if (tidyFilePath.StartsWith(@"M:\"))
                {
                    structure = tidyFilePath.Replace(@"M:\", "");

                    if (dragMode == "folder")
                    {
                        structure = structure.Substring(0, structure.LastIndexOf("\\"));

                        if (!structure.StartsWith("\\"))
                            structure = "\\" + structure;
                    }
                    else
                        structure = "";

                    structure = defaultPath + structure;
                }

                else if (tidyFilePath.StartsWith(@"\\kdthk-dm1\project\") || tidyFilePath.StartsWith(@"\\kdthk-dm1\Project\") || tidyFilePath.StartsWith(@"\\kdthk-dm1\PROJECT\"))
                {
                    tidyFilePath = tidyFilePath.StartsWith(@"\\kdthk-dm1\Project\") ? tidyFilePath.Replace("Project", "project")
                        : tidyFilePath.StartsWith(@"\\kdthk-dm1\PROJECT\") ? tidyFilePath.Replace("PROJECT", "project") : tidyFilePath;

                    structure = tidyFilePath.Replace(@"\\kdthk-dm1\project\", "");

                    if (dragMode == "folder")
                    {
                        structure = structure.Substring(0, structure.LastIndexOf("\\"));

                        if (!structure.StartsWith("\\"))
                            structure = "\\" + structure;
                    }
                    else
                        structure = "";

                    structure = defaultPath + structure;
                }

                else if (tidyFilePath.StartsWith(@"L:\"))
                {
                    structure = tidyFilePath.Replace(@"L:", "");

                    if (dragMode == "folder")
                    {
                        structure = structure.Substring(0, structure.LastIndexOf("\\"));

                        if (!structure.StartsWith("\\"))
                            structure = "\\" + structure;
                    }
                    else
                        structure = "";

                    structure = defaultPath + structure;
                }

                else if(tidyFilePath.StartsWith(@"C:\"))
                {
                    structure = tidyFilePath.Replace(@"C:", "");

                    if (dragMode == "folder")
                    {
                        structure = structure.Substring(0, structure.LastIndexOf("\\"));

                        //if (structure.Contains("\\"))
                           // structure = structure.Substring(structure.LastIndexOf("\\"));
                        if (!structure.StartsWith("\\"))
                            structure = "\\" + structure;
                    }
                    else
                        structure = "";

                    structure = defaultPath + structure;
                }

                else if (tidyFilePath.StartsWith(@"E:\"))
                {
                    structure = tidyFilePath.Replace(@"E:", "");

                    if (dragMode == "folder")
                    {
                        structure = structure.Substring(0, structure.LastIndexOf("\\"));

                        //if (structure.Contains("\\"))
                           // structure = structure.Substring(structure.LastIndexOf("\\"));
                        if (!structure.StartsWith("\\"))
                            structure = "\\" + structure;
                    }
                    else
                        structure = "";

                    structure = defaultPath + structure;
                }

                else if (tidyFilePath.StartsWith(departmentFolder))
                {
                    structure = tidyFilePath.Replace(departmentFolder, "");
                    structure = structure.Substring(1);

                    if (dragMode == "folder")
                    {
                        structure = structure.Substring(0, structure.LastIndexOf("\\"));

                        //if (structure.Contains("\\"))
                           // structure = structure.Substring(structure.LastIndexOf("\\"));

                        if (!structure.StartsWith("\\"))
                            structure = "\\" + structure;
                    }
                    else
                        structure = "";

                    structure = defaultPath + structure;
                }

                else
                {
                    structure = tidyFilePath.Replace(@"D:\", "");

                    if (dragMode == "folder")
                    {
                        if (structure.Contains(@"\"))
                        {
                            structure = structure.Substring(0, structure.LastIndexOf("\\"));

                            //if (structure.Contains("\\"))
                               // structure = structure.Substring(structure.LastIndexOf("\\"));
                            structure = defaultPath + structure;
                        }
                        else
                            structure = defaultPath;
                    }
                    else
                        structure = defaultPath;
                }

                if (structure.EndsWith(@"\"))
                    structure = structure.Substring(0, structure.Length - 1);

                if (structure.Contains(@"\\"))
                    structure.Replace(@"\\", @"\");

                if (fileName.Contains('.'))
                    fileName = fileName.Substring(0, fileName.LastIndexOf('.'));

                if (mode == "rename")
                {
                    int seq = 1;

                    string fileNameOnly = Path.GetFileNameWithoutExtension(directory);
                    string extensionOnly = Path.GetExtension(directory);
                    string pathOnly = Path.GetDirectoryName(directory);
                    string newPath = directory;

                    string tmpFile1 = "";
                    string tmpFile2 = "";

                    while (File.Exists(newPath))
                    {
                        int tmpCount = seq;
                        if (tmpFile1.Contains("(" + tmpCount + ")"))
                            tmpFile1 = tmpFile1.Substring(0, tmpFile1.LastIndexOf("(" + tmpCount + ")"));

                        tmpFile2 = string.Format("{0}({1})", tmpFile1, seq++);

                        newPath = Path.Combine(pathOnly, tmpFile2 + extensionOnly);
                    }

                    dgvDocSetup.Rows.Add(tmpFile2, "", favoriteMode, "---", filePath, newPath, structure, "Rename", "-");
                }

                else if (mode == "overwrite")
                    dgvDocSetup.Rows.Add(fileName, "", favoriteMode, "---", filePath, directory, structure, "Overwrite", "-");

                else
                    dgvDocSetup.Rows.Add(fileName, "", favoriteMode, "---", filePath, directory, structure, "Normal", "-");
            }

            List<int> indexList = new List<int>();

            foreach (DataGridViewRow row in dgvDocSetup.Rows)
            {
                string itemMode = row.Cells[6].Value.ToString();

                if (itemMode != "Rename")
                    indexList.Add(row.Index);
            }

            foreach (int idx in indexList)
                dgvDocSetup.Rows[idx].Cells[0].ReadOnly = true;
        }

        private void tsbtnSync_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnUploadFile_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnUploadFolder_Click(object sender, EventArgs e)
        {

        }

        private void markAllAsFavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvDocSetup.ClearSelection();

            foreach (DataGridViewRow row in dgvDocSetup.Rows)
                row.Cells[2].Value = "Yes";
        }

        private void removeAllFromFavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvDocSetup.ClearSelection();

            foreach (DataGridViewRow row in dgvDocSetup.Rows)
                row.Cells[2].Value = "---";
        }

        private void tsbtnUndo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDocSetup.Rows)
            {
                row.Cells[1].Value = "";
                row.Cells[2].Value = "---";
                row.Cells[3].Value = "---";
                row.Cells[6].Value = _defaultPath;
            }
        }

        private void tvFolder_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var hittest = tvFolder.HitTest(e.Location);

            if (hittest.Location != TreeViewHitTestLocations.PlusMinus)
            {
                string tvPath = @"\" + e.Node.FullPath;

                if (ckbApplyAll.Checked)
                {
                    foreach (DataGridViewRow row in dgvDocSetup.Rows)
                        row.Cells[6].Value = tvPath;
                }
                else
                {
                    dgvDocSetup.CurrentRow.Cells[6].Value = tvPath;
                }
            }
        }

        private void btnNewShare_Click(object sender, EventArgs e)
        {
            UserGlobalForm form = new UserGlobalForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                List<string> tmplist = new List<string>();

                foreach (DataGridViewRow row in dgvUser.Rows)
                    tmplist.Add(row.Cells[0].Value.ToString().Trim());

                foreach (UserGlobalList user in GlobalService.SelectedGlobalUserList)
                {
                    if (!tmplist.Contains(user.Name))
                    {
                        tmplist.Add(user.Name);
                        dgvUser.Rows.Add(user.Name, user.Location);
                    }
                }
            }
            /*UserForm form = new UserForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                List<string> tmplist = new List<string>();

                foreach (DataGridViewRow row in dgvUser.Rows)
                    tmplist.Add(row.Cells[0].Value.ToString().Trim());

                foreach (string user in GlobalService.SelectedUserList)
                {
                    if (!tmplist.Contains(user))
                    {
                        tmplist.Add(user);
                        dgvUser.Rows.Add(user, "HK");
                    }
                }

                foreach (string user in GlobalService.SelectedCnUser)
                {
                    if (!tmplist.Contains(user))
                    {
                        tmplist.Add(user);
                        dgvUser.Rows.Add(user, "CN");
                    }
                }
            }*/

            List<string> list = new List<string>();

            if (dgvUser.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvUser.Rows)
                {
                    string name = row.Cells[0].Value.ToString().Trim();
                    list.Add(name);
                }

                string shared = string.Join(";", list.ToArray());

                if (ckbApplyAll.Checked)
                {
                    foreach (DataGridViewRow row in dgvDocSetup.Rows)
                        row.Cells[8].Value = shared;
                }
                else
                {
                    dgvDocSetup.CurrentRow.Cells[8].Value = shared;
                }
            }

            /*if (lbShare.Items.Count > 0)
            {
                string shared = string.Join(";", lbShare.Items.OfType<object>());

                if (ckbApplyAll.Checked)
                {
                    foreach (DataGridViewRow row in dgvDocSetup.Rows)
                        row.Cells[8].Value = shared;
                }
                else
                {
                    dgvDocSetup.CurrentRow.Cells[8].Value = shared;
                }
            }*/
        }

        private void btnDeleteShare_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUser.SelectedRows)
                dgvUser.Rows.Remove(row);

            List<string> list = new List<string>();

            if (dgvUser.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvUser.Rows)
                {
                    string name = row.Cells[0].Value.ToString().Trim();
                    list.Add(name);
                }

                string shared = string.Join(";", list.ToArray());

                if (ckbApplyAll.Checked)
                {
                    foreach (DataGridViewRow row in dgvDocSetup.Rows)
                        row.Cells[8].Value = shared;
                }
                else
                {
                    dgvDocSetup.CurrentRow.Cells[8].Value = shared;
                }
            }
            else
            {
                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvDocSetup.Rows)
                        row.Cells[8].Value = "-";
                else
                    dgvDocSetup.CurrentRow.Cells[8].Value = "-";
            }

            /*for (int x = lbShare.SelectedIndices.Count - 1; x >= 0; x--)
            {
                int idx = lbShare.SelectedIndices[x];
                lbShare.Items.RemoveAt(idx);
            }

            if (lbShare.Items.Count > 0)
            {
                string shared = string.Join(";", lbShare.Items.OfType<object>());

                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvDocSetup.Rows)
                        row.Cells[8].Value = shared;
                else
                    dgvDocSetup.CurrentRow.Cells[8].Value = shared;
            }
            else
            {
                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvDocSetup.Rows)
                        row.Cells[8].Value = "-";
                else
                    dgvDocSetup.CurrentRow.Cells[8].Value = "-";
            }*/
        }

        private void CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rbtn = (RadioButton)sender;
            string tag = rbtn.Tag.ToString();

            dgvUser.Rows.Clear();
            //lbShare.Items.Clear();

            List<string> tmplist = new List<string>();

            if (tag == "custom")
            {
                if (sharedList.Count > 0)
                {
                    foreach (string shared in sharedList)
                    {
                        if (!tmplist.Contains(shared))
                        {
                            tmplist.Add(shared);
                            if (!UserUtil.IsCnMember(shared))
                                dgvUser.Rows.Add(shared, "HK");
                            else
                                dgvUser.Rows.Add(shared, "CN");
                        }
                    }
                }
                /*if (sharedList.Count > 0)
                    foreach (string shared in sharedList)
                        if (!lbShare.Items.Contains(shared.Trim()))
                            lbShare.Items.Add(shared.Trim());*/
            }

            if (tag == "division")
            {
                foreach (string member in GlobalService.DivisionMemberList)
                {
                    if (!tmplist.Contains(member))
                    {
                        tmplist.Add(member);
                        if (!UserUtil.IsCnMember(member))
                            dgvUser.Rows.Add(member, "HK");
                        else
                            dgvUser.Rows.Add(member, "CN");
                    }
                }
                 //   if (!lbShare.Items.Contains(member.Trim()))
                    //    lbShare.Items.Add(member.Trim());
            }

            if (tag == "department")
            {
                foreach (string member in GlobalService.DepartmentMemberList)
                {
                    if (!tmplist.Contains(member))
                    {
                        tmplist.Add(member);
                        if (!UserUtil.IsCnMember(member))
                            dgvUser.Rows.Add(member, "HK");
                        else
                            dgvUser.Rows.Add(member, "CN");
                    }
                }
                 //   if (!lbShare.Items.Contains(member.Trim()))
                    //    lbShare.Items.Add(member.Trim());
            }

            List<string> list = new List<string>();

            if (dgvUser.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgvUser.Rows)
                {
                    string name = row.Cells[0].Value.ToString().Trim();
                    list.Add(name);
                }

                string shared = string.Join(";", list.ToArray());

                if (ckbApplyAll.Checked)
                {
                    foreach (DataGridViewRow row in dgvDocSetup.Rows)
                        row.Cells[8].Value = shared;
                }
                else
                {
                    dgvDocSetup.CurrentRow.Cells[8].Value = shared;
                }
            }
            else
            {
                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvDocSetup.Rows)
                        row.Cells[8].Value = "-";
                else
                    dgvDocSetup.CurrentRow.Cells[8].Value = "-";
            }

            /*if (lbShare.Items.Count > 0)
            {
                string shared = string.Join(";", lbShare.Items.OfType<object>());

                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvDocSetup.Rows)
                        row.Cells[8].Value = shared;
                else
                    dgvDocSetup.CurrentRow.Cells[8].Value = shared;
            }
            else
            {
                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvDocSetup.Rows)
                        row.Cells[8].Value = "-";
                else
                    dgvDocSetup.CurrentRow.Cells[8].Value = "-";
            }*/
        }

        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            if (tvFolder.SelectedNode == null)
            {
                MessageBox.Show("Please select a folder first.");
                return;
            }

            NewFolderForm form = new NewFolderForm(@"\" + tvFolder.SelectedNode.FullPath, "document");
            if (form.ShowDialog() == DialogResult.OK)
            {
                string path = @"\" + tvFolder.SelectedNode.FullPath + @"\" + GlobalService.NewFolder;

                tvFolder.SelectedNode.Nodes.Add(GlobalService.NewFolder);

                TreeNode node = new TreeNode(path);
                tvFolder.SelectedNode = node;
                tvFolder.SelectedNode.Expand();
                tvFolder.SelectedNode.EnsureVisible();
                tvFolder.Focus();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("btnSave_Click");
            try
            {
                dgvDocSetup.EndEdit();

                List<string> queryList = new List<string>();

                foreach (DataGridViewRow row in dgvDocSetup.Rows)
                {
                    string fileName = row.Cells[0].Value.ToString();
                    string keyword = row.Cells[1].Value.ToString();
                    string favSelection = row.Cells[2].Value.ToString();
                    string selection = row.Cells[3].Value.ToString();
                    string directory = row.Cells[4].Value.ToString();
                    string targetDirectory = row.Cells[5].Value.ToString();
                    string vpath = row.Cells[6].Value.ToString();
                    string type = row.Cells[7].Value.ToString();
                    string shared = row.Cells[8].Value.ToString();
                    string sharedPerson = shared;

                    string favorite = favSelection == "---" ? "False" : "True";

                    string autoDelete = selection == "7 days" ? DateTime.Today.AddDays(7).ToString("yyyy/MM/dd")
                        : selection == "30 days" ? DateTime.Today.AddDays(30).ToString("yyyy/MM/dd")
                        : selection == "60 days" ? DateTime.Today.AddDays(60).ToString("yyyy/MM/dd")
                        : selection == "90 days" ? DateTime.Today.AddDays(90).ToString("yyyy/MM/dd") : "2099/12/31";

                    if (keyword == "")
                        keyword = fileName;

                    //if (!File.Exists(targetDirectory))
                    File.Copy(directory, targetDirectory, true);

                    string sPath = targetDirectory;

                    if (sPath.Contains("'"))
                        sPath = sPath.Replace("'", "''");

                    if (DataUtil.IsRecordExists(targetDirectory))
                    {
                        List<string> list = DataUtil.GetSharedList(GlobalService.DbTable, targetDirectory);

                        if (list.Count > 0)
                        {
                            foreach (string item in list)
                            {
                                string tbName = "TB_" + AdUtil.GetUserId();

                                string delText = string.Format("delete from " + tbName + " where r_path = N'{0}' and r_owner = N'{1}'", sPath, GlobalService.User);
                                DataService.GetInstance().ExecuteNonQuery(delText);
                            }
                        }

                        string delOwnerText = string.Format("delete from " + GlobalService.DbTable + " where r_path = N'{0}'", sPath);
                        DataService.GetInstance().ExecuteNonQuery(delOwnerText);
                    }

                    FileInfo info = new FileInfo(targetDirectory);
                    FileSecurity fs = info.GetAccessControl();
                    AuthorizationRuleCollection rules = fs.GetAccessRules(true, true, typeof(NTAccount));
                    string lastmodified = info.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss");
                    string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                    string extension = targetDirectory.Contains(".") ? targetDirectory.Substring(targetDirectory.LastIndexOf("."), targetDirectory.Length - targetDirectory.LastIndexOf(".")) : "file";

                    foreach (FileSystemAccessRule rule in rules)
                        fs.RemoveAccessRuleSpecific(rule);

                    fs.SetAccessRuleProtection(true, false);
                    fs.AddAccessRule(new FileSystemAccessRule(@"kmhk\itadmin", FileSystemRights.FullControl, AccessControlType.Allow));

                    if(GlobalService.User == "Chow Chi To(周志滔,Sammy)") fs.AddAccessRule(new FileSystemAccessRule(@"kmas\as1600048", FileSystemRights.FullControl, AccessControlType.Allow));
                    if(GlobalService.User == "Ling Wai Man(凌慧敏,Velma)") fs.AddAccessRule(new FileSystemAccessRule(@"kmas\as1600049", FileSystemRights.FullControl, AccessControlType.Allow));
                    if(GlobalService.User == "Ng Lau Yu, Lilith (吳柳如)") fs.AddAccessRule(new FileSystemAccessRule(@"kmas\as1600051", FileSystemRights.FullControl, AccessControlType.Allow));
                    if(GlobalService.User == "Lee Miu Wah(李苗華)") fs.AddAccessRule(new FileSystemAccessRule(@"kmas\as1600053", FileSystemRights.FullControl, AccessControlType.Allow));

                    fs.AddAccessRule(new FileSystemAccessRule(AdUtil.GetUserId(), FileSystemRights.FullControl, AccessControlType.Allow));

                    List<string> sharedList = new List<string>();

                    if (fileName.Contains("'"))
                        fileName = fileName.Replace("'", "''");

                    if (keyword.Contains("'"))
                        keyword = keyword.Replace("'", "''");

                    if (shared != "-")
                        sharedList = shared.Split(';').ToList();

                    //foreach (string item in sharedList)
                       // Debug.WriteLine("Item: " + item);

                    List<string> hklist = new List<string>();
                    List<string> cnlist = new List<string>();
                    List<string> vnlist = new List<string>();
                    List<string> jplist = new List<string>();

                    foreach (string item in sharedList)
                    {
                        if (UserUtil.IsCnMember(item.Trim()))
                            cnlist.Add(item.Trim());
                        else if (UserUtil.IsVnMember(item.Trim()))
                            vnlist.Add(item.Trim());
                        else if (UserUtil.IsJpMember(item.Trim()))
                            jplist.Add(item.Trim());
                        else
                            hklist.Add(item.Trim());
                    }

                    if (hklist.Count > 0)
                    {
                        foreach (string item in hklist)
                        {
                            string sharedId = AdUtil.GetUserIdByUsername(item.Trim());
                            string tableName = "TB_" + sharedId;

                            string sharedDivision = SystemUtil.GetDivision(item.Trim());
                            string sharedDepartment = SystemUtil.GetDepartment(item.Trim());

                            fs.AddAccessRule(new FileSystemAccessRule(sharedId, FileSystemRights.Modify, AccessControlType.Allow));

                            if (UserUtil.IsSpecialUser(item))
                            //if (item == "Chow Chi To(周志滔,Sammy)" || item == "Ling Wai Man(凌慧敏,Velma)" || item == "Chan Fai Lung(陳輝龍,Onyx)" || item == "Ng Lau Yu, Lilith (吳柳如)" ||
                            //    item == "Lee Miu Wah(李苗華)" || item == "Lee Ming Fung(李銘峯)" || item == "Ho Kin Hang(何健恒,Ken)" || item == "Yeung Wai, Gabriel (楊偉)")
                            {
                                string asText = string.Format("select as_userid from TB_USER_AS where as_user = N'{0}'", item.Trim());
                                string asId = DataService.GetInstance().ExecuteScalar(asText).ToString().Trim();

                                fs.AddAccessRule(new FileSystemAccessRule(asId, FileSystemRights.Modify, AccessControlType.Allow));
                            }

                            string sharedVpath = sharedDivision != GlobalService.Division && vpath.StartsWith(@"\" + GlobalService.Division) ? @"\Documents" + vpath
                                : sharedDepartment != GlobalService.Department && vpath.StartsWith(@"\Common") ? @"\Documents" + vpath : vpath;

                            if (sharedVpath.Contains("'"))
                                sharedVpath = sharedVpath.Replace("'", "''");

                            string sharedText = string.Format("insert into " + tableName + " (r_filename, r_extension, r_keyword, r_lastaccess, r_lastmodified, r_owner, r_shared, r_path, r_vpath, r_deletedate)" +
                                " values (N'{0}', '{1}', N'{2}', '{3}', '{4}', N'{5}', N'{6}', N'{7}', N'{8}', '{9}')", fileName, extension, keyword, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), lastmodified, GlobalService.User,
                                item.Trim(), sPath, sharedVpath, "2099/12/31");

                            queryList.Add(sharedText);
                        }
                    }

                    /*if (targetDirectory.StartsWith(@"\\kdthk-dm1\project\KDTHK-DM"))
                        File.SetAccessControl(targetDirectory, fs);
                    else
                    {
                        if (!targetDirectory.StartsWith(@"L:\") && !targetDirectory.StartsWith(@"M:\") && !targetDirectory.StartsWith(@"\\kdthk-dm1\project") && !targetDirectory.StartsWith(@"\\kdthk-dm1"))
                            File.SetAccessControl(targetDirectory, fs);
                    }*/
                    /* Commented out by Cato Yeung */

                    if (cnlist.Count > 0)
                    {
                        PermissionUtil.SetGlobalPermission(cnlist, targetDirectory, "kmcn.local");
                        SharedUtil.SharedCN(cnlist, sPath, fileName, keyword);
                    }

                    if (vnlist.Count > 0)
                    {
                        PermissionUtil.SetGlobalPermission(vnlist, targetDirectory, "kdtvn.local");
                        SharedUtil.SharedVN(vnlist, sPath, fileName, keyword);
                    }

                    if (jplist.Count > 0)
                    {
                        PermissionUtil.SetGlobalPermission(jplist, targetDirectory, "km.local");
                        SharedUtil.SharedJp(jplist, sPath, fileName, keyword);
                    }

                    try
                    {
                        List<string> receiverlist = cnlist.Concat(vnlist).Concat(jplist).ToList();
                        //receiverlist.Add(GlobalService.User);
                        if (receiverlist.Count > 0)
                            EmailUtil.SendNotificationEmail(receiverlist);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message + ex.StackTrace);
                    }
                    //SharedUtil.SharedGlobal(cnList, sPath, fileName, keyword);

                    /*sharedList = sharedList.Distinct().ToList();

                    if (sharedList.Count > 0)
                        sharedPerson = string.Join(";", sharedList.ToArray());*/

                    if (vpath.Contains("'"))
                        vpath = vpath.Replace("'", "''");

                    GlobalService.RootTable.Rows.Add(fileName, keyword, lastmodified, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), GlobalService.User, shared, targetDirectory, vpath, 0, favorite, "False");

                    string ownerText = string.Format("insert into " + GlobalService.DbTable + " (r_filename, r_extension, r_keyword, r_lastaccess, r_lastmodified, r_owner, r_shared, r_path, r_vpath, r_deletedate)" +
                                " values (N'{0}', '{1}', N'{2}', '{3}', '{4}', N'{5}', N'{6}', N'{7}', N'{8}', '{9}')", fileName, extension, keyword, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), lastmodified, GlobalService.User,
                                shared, sPath, vpath, autoDelete);

                    queryList.Add(ownerText);

                    if (directory.StartsWith(Environment.SpecialFolder.Desktop + @"\MyCloud Sync"))
                        File.Delete(directory);
                }
                queryList = queryList.Distinct().ToList();


                foreach (string text in queryList)
                {
                    DataService.GetInstance().ExecuteNonQuery(text);
                }
                //DataUtil.SyncDataToServer();
                GlobalService.RootTable = RootUtil.RootDataTable();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }


        private void dgvDocSetup_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void dgvDocSetup_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void dgvDocSetup_SelectionChanged(object sender, EventArgs e)
        {
            dgvUser.Rows.Clear();

            string shared = dgvDocSetup.CurrentRow.Cells[8].Value.ToString();

            if (shared == "-")
                dgvUser.Rows.Clear();
            else
            {
                List<string> userlist = shared.Split(';').ToList();

                foreach (string user in userlist)
                {
                    if (UserUtil.IsCnMember(user))
                        dgvUser.Rows.Add(user, "CN");
                    else if (UserUtil.IsVnMember(user))
                        dgvUser.Rows.Add(user, "VN");
                    else if (UserUtil.IsJpMember(user))
                        dgvUser.Rows.Add(user, "JP");
                    else
                        dgvUser.Rows.Add(user, "HK");
                }
            }

            /*lbShare.Items.Clear();

            if (shared == "-")
                lbShare.Items.Clear();
            else
            {
                string[] arrShared = shared.Split(';');

                foreach (string arr in arrShared)
                    if (!lbShare.Items.Contains(arr.Trim()))
                        lbShare.Items.Add(arr.Trim());
            }*/
        }

        private void btnKeyword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtKeyword.Text))
                return;

            foreach (DataGridViewRow row in dgvDocSetup.Rows)
                row.Cells[1].Value = txtKeyword.Text;

            txtKeyword.Text = "";
        }

        private void btnAutoDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDocSetup.Rows)
                row.Cells[3].Value = cbAutoDelete.SelectedItem.ToString();
        }

        private void txtKeyword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtKeyword.Text))
                    return;

                foreach (DataGridViewRow row in dgvDocSetup.Rows)
                    row.Cells[1].Value = txtKeyword.Text;

                txtKeyword.Text = "";
            }
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
