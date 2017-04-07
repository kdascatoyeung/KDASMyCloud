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
using CustomUtil.utils.authentication;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Data.SqlServerCe;
using System.Diagnostics;

namespace KDTHK_DM_SP.forms
{
    public partial class CopyForm : Form
    {
        public CopyForm(List<CopyFileList> list)
        {
            InitializeComponent();

            TreeviewUtil.LoadPersonalFolder(tvFolder, GlobalService.User);

            this.AddData(list);
        }

        private void AddData(List<CopyFileList> copyList)
        {
            foreach (CopyFileList item in copyList)
            {
                string fileName = item.FileName;
                string keyword = item.Keyword;
                string owner = item.Owner;
                string filePath = item.FilePath;
                string savedPath = item.SavedPath;

                if (owner == GlobalService.User)
                {
                    List<string> sharedList = DataUtil.GetLocalSharedList(GlobalService.RootTable, filePath);

                    string shared = sharedList.Count > 1 ? string.Join(";", sharedList.ToArray()) : sharedList.Count == 1 ? sharedList[0] : "-";

                    dgvCopySetup.Rows.Add(fileName, fileName + "_1", keyword, "---", filePath, "-", savedPath, shared);
                }
                else
                {
                    Debug.WriteLine("Owner: " + owner);
                    string tableName = "TB_" + AdUtil.GetUserIdByUsername(owner, "kmhk.local");

                    List<string> sharedList = DataUtil.GetSharedList(tableName, filePath);

                    if (sharedList.Contains(GlobalService.User))
                        sharedList.Remove(GlobalService.User);

                    sharedList.Add(owner);

                    string shared = sharedList.Count > 1 ? string.Join(";", sharedList.ToArray()) : sharedList.Count == 1 ? sharedList[0] : "-";

                    dgvCopySetup.Rows.Add(fileName, fileName + "_1", keyword, "---", filePath, "-", savedPath, shared);
                }
            }
        }

        private void dgvCopySetup_SelectionChanged(object sender, EventArgs e)
        {
            dgvUser.Rows.Clear();

            string shared = dgvCopySetup.CurrentRow.Cells[7].Value.ToString();

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

            string shared = dgvCopySetup.CurrentRow.Cells[7].Value.ToString();

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

        private void tvFolder_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var hittest = tvFolder.HitTest(e.Location);

            if (hittest.Location != TreeViewHitTestLocations.PlusMinus)
            {
                string tvPath = @"\" + e.Node.FullPath;

                if (ckbApplyAll.Checked)
                {
                    foreach (DataGridViewRow row in dgvCopySetup.Rows)
                        row.Cells[6].Value = tvPath;
                }
                else
                {
                    dgvCopySetup.CurrentRow.Cells[6].Value = tvPath;
                }
            }
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
                string cShared = dgvCopySetup.CurrentRow.Cells[7].Value.ToString();

                if (cShared == "-")
                    dgvUser.Rows.Clear();
                else if (cShared.Contains(";"))
                {
                    List<string> lst = cShared.Split(';').ToList();

                    foreach (string item in lst)
                    {
                        if (!UserUtil.IsCnMember(item))
                            dgvUser.Rows.Add(item, "HK");
                        else
                            dgvUser.Rows.Add(item, "CN");
                    }
                }
                else
                {
                    if (!UserUtil.IsCnMember(cShared))
                        dgvUser.Rows.Add(cShared, "HK");
                    else
                        dgvUser.Rows.Add(cShared, "CN");
                }

                /*if (cShared == "-")
                    lbShare.Items.Clear();

                else if (cShared.Contains(";"))
                {
                    string[] arrShared = cShared.Split(';');

                    foreach (string arr in arrShared)
                        if (!lbShare.Items.Contains(arr.Trim()))
                            lbShare.Items.Add(arr.Trim());
                }

                else
                {
                    lbShare.Items.Add(cShared);
                }*/
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
                    //if (!lbShare.Items.Contains(member.Trim()))
                       // lbShare.Items.Add(member.Trim());
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
                    //if (!lbShare.Items.Contains(member.Trim()))
                       // lbShare.Items.Add(member.Trim());
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
                    foreach (DataGridViewRow row in dgvCopySetup.Rows)
                        row.Cells[7].Value = shared;
                }
                else
                {
                    dgvCopySetup.CurrentRow.Cells[7].Value = shared;
                }
            }
            else
            {
                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvCopySetup.Rows)
                        row.Cells[7].Value = "-";
                else
                    dgvCopySetup.CurrentRow.Cells[7].Value = "-";
            }

            /*if (lbShare.Items.Count > 0)
            {
                string shared = string.Join(";", lbShare.Items.OfType<object>());

                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvCopySetup.Rows)
                        row.Cells[7].Value = shared;
                else
                    dgvCopySetup.CurrentRow.Cells[7].Value = shared;
            }
            else
            {
                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvCopySetup.Rows)
                        row.Cells[7].Value = "-";
                else
                    dgvCopySetup.CurrentRow.Cells[7].Value = "-";
            }*/
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string directory = @"\\kdthk-dm1\project\KDTHK-DM\" + AdUtil.getAccount("kmhk.local");

            List<string> queryList = new List<string>();

            foreach (DataGridViewRow row in dgvCopySetup.Rows)
            {
                string fileName = row.Cells[1].Value.ToString();
                string keyword = row.Cells[2].Value.ToString();
                string favSelection = row.Cells[3].Value.ToString();
                string filePath = row.Cells[4].Value.ToString();
                string folder = row.Cells[6].Value.ToString();
                string shared = row.Cells[7].Value.ToString();
                string extension = Path.GetExtension(filePath);
                string favorite = favSelection == "---" ? "False" : "True";

                //if (!Directory.Exists(directory + folder))
                // Directory.CreateDirectory(directory + folder);

                string destination = Path.Combine(directory, fileName + extension);

                File.Copy(filePath, destination, true);
                
                FileInfo info = new FileInfo(destination);
                FileSecurity fs = info.GetAccessControl();
                AuthorizationRuleCollection rules = fs.GetAccessRules(true, true, typeof(NTAccount));
                string lastmodified = info.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss");
                string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                fs.SetAccessRuleProtection(true, false);
                fs.AddAccessRule(new FileSystemAccessRule(@"kmhk\itadmin", FileSystemRights.FullControl, AccessControlType.Allow));
                fs.AddAccessRule(new FileSystemAccessRule(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), FileSystemRights.FullControl, AccessControlType.Allow));

                string storedDest = destination;

                if (storedDest.Contains("'"))
                    storedDest = storedDest.Replace("'", "''");

                if (fileName.Contains("'"))
                    fileName = fileName.Replace("'", "''");

                if (keyword.Contains("'"))
                    keyword = keyword.Replace("'", "''");

                if (shared != "-")
                {
                    List<string> fileSharedList = shared.Split(';').ToList();

                    List<string> hklist = new List<string>();
                    List<string> cnlist = new List<string>();
                    List<string> vnlist = new List<string>();
                    List<string> jplist = new List<string>();

                    foreach (string item in fileSharedList)
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

                    foreach (string fileShared in hklist)
                    {
                        string sharedId = AdUtil.GetUserIdByUsername(fileShared.Trim(), "kmhk.local");
                        string tableName = "TB_" + sharedId;

                        fs.AddAccessRule(new FileSystemAccessRule(sharedId, FileSystemRights.Modify, AccessControlType.Allow));

                        if (UserUtil.IsSpecialUser(fileShared))
                        //if (fileShared == "Chow Chi To(周志滔,Sammy)" || fileShared == "Ling Wai Man(凌慧敏,Velma)" || fileShared == "Chan Fai Lung(陳輝龍,Onyx)" || fileShared == "Ng Lau Yu, Lilith (吳柳如)" ||
                        //        fileShared == "Lee Miu Wah(李苗華)" || fileShared == "Lee Ming Fung(李銘峯)" || fileShared == "Ho Kin Hang(何健恒,Ken)" || fileShared == "Yeung Wai, Gabriel (楊偉)")
                        {
                            string asText = string.Format("select as_userid from TB_USER_AS where as_user = N'{0}'", fileShared.Trim());
                            string asId = DataService.GetInstance().ExecuteScalar(asText).ToString().Trim();

                            fs.AddAccessRule(new FileSystemAccessRule(asId, FileSystemRights.Modify, AccessControlType.Allow));
                        }

                        string sharedDivision = SystemUtil.GetDivision(fileShared.Trim());
                        string sharedDepartment = SystemUtil.GetDepartment(fileShared.Trim());

                        string sharedVpath = sharedDivision != GlobalService.Division && folder.StartsWith(@"\" + GlobalService.Division) ? @"\Documents" + folder
                            : sharedDepartment != GlobalService.Department && folder.StartsWith(@"\Common") ? @"\Documents" + folder : folder;

                        if (sharedVpath.Contains("'"))
                            sharedVpath = sharedVpath.Replace("'", "''");

                        string sharedText = string.Format("insert into " + tableName + " (r_filename, r_extension, r_keyword, r_lastaccess, r_lastmodified, r_owner, r_shared, r_path, r_vpath, r_deletedate)" +
                            " values (N'{0}', '{1}', N'{2}', '{3}', '{4}', N'{5}', N'{6}', N'{7}', N'{8}', '{9}')", fileName, extension, keyword, now, lastmodified, GlobalService.User,
                            fileShared.Trim(), storedDest, sharedVpath, "2099/12/31");

                        queryList.Add(sharedText);
                    }

                    try
                    {
                        File.SetAccessControl(destination, fs);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message + ex.StackTrace);
                        continue;
                    }

                    if (cnlist.Count > 0)
                    {
                        PermissionUtil.SetGlobalPermission(cnlist, destination, "kmcn.local");
                        SharedUtil.SharedCN(cnlist, storedDest, fileName, keyword);
                    }

                    if (vnlist.Count > 0)
                    {
                        PermissionUtil.SetGlobalPermission(vnlist, destination, "kdtvn.local");
                        SharedUtil.SharedVN(vnlist, storedDest, fileName, keyword);
                    }

                    if (jplist.Count > 0)
                    {
                        PermissionUtil.SetGlobalPermission(jplist, destination, "km.local");
                        SharedUtil.SharedJp(jplist, storedDest, fileName, keyword);
                    }

                    try
                    {
                        List<string> receiverlist = cnlist.Concat(vnlist).Concat(jplist).ToList();
                        if (receiverlist.Count > 0)
                            EmailUtil.SendNotificationEmail(receiverlist);
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message + ex.StackTrace);
                    }
                }

                GlobalService.RootTable.Rows.Add(fileName, keyword, lastmodified, now, GlobalService.User, shared, destination, folder, 0, favorite, "True", "False");

                if (folder.Contains("'"))
                    folder = folder.Replace("'", "''");

                if (shared == "")
                    shared = "-";

                string ownerText = string.Format("insert into " + GlobalService.DbTable + " (r_filename, r_extension, r_keyword, r_lastaccess, r_lastmodified, r_owner, r_shared, r_path, r_vpath, r_deletedate)" +
                            " values (N'{0}', '{1}', N'{2}', '{3}', '{4}', N'{5}', N'{6}', N'{7}', N'{8}', '{9}')", fileName, extension, keyword, now, lastmodified, GlobalService.User,
                            shared, storedDest, folder, "2099/12/31");

                queryList.Add(ownerText);
            }

            foreach (string text in queryList)
            {
                DataService.GetInstance().ExecuteNonQuery(text);
            }

            //DataUtil.SyncDataToServer();
            GlobalService.RootTable = RootUtil.RootDataTable();
            this.DialogResult = DialogResult.OK;
        }

        private void btnNewFolder_Click(object sender, EventArgs e)
        {
            if (tvFolder.SelectedNode == null)
            {
                MessageBox.Show("Please select a folder first.");
                return;
            }

            NewFolderForm form = new NewFolderForm(@"\" + tvFolder.SelectedNode.FullPath, "copy");
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
                    foreach (DataGridViewRow row in dgvCopySetup.Rows)
                        row.Cells[7].Value = shared;
                }
                else
                {
                    dgvCopySetup.CurrentRow.Cells[7].Value = shared;
                }
            }

            /*if (lbShare.Items.Count > 0)
            {
                string shared = string.Join(";", lbShare.Items.OfType<object>());

                if (ckbApplyAll.Checked)
                {
                    foreach (DataGridViewRow row in dgvCopySetup.Rows)
                        row.Cells[7].Value = shared;
                }
                else
                {
                    dgvCopySetup.CurrentRow.Cells[7].Value = shared;
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
                    foreach (DataGridViewRow row in dgvCopySetup.Rows)
                        row.Cells[7].Value = shared;
                }
                else
                {
                    dgvCopySetup.CurrentRow.Cells[7].Value = shared;
                }
            }
            else
            {
                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvCopySetup.Rows)
                        row.Cells[7].Value = "-";
                else
                    dgvCopySetup.CurrentRow.Cells[7].Value = "-";
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
                    foreach (DataGridViewRow row in dgvCopySetup.Rows)
                        row.Cells[7].Value = shared;
                else
                    dgvCopySetup.CurrentRow.Cells[7].Value = shared;
            }
            else
            {
                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvCopySetup.Rows)
                        row.Cells[7].Value = "-";
                else
                    dgvCopySetup.CurrentRow.Cells[7].Value = "-";
            }*/
        }

        private void markAllAsFavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvCopySetup.ClearSelection();

            foreach (DataGridViewRow row in dgvCopySetup.Rows)
                row.Cells[2].Value = "Yes";
        }

        private void removeAllFromFavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgvCopySetup.ClearSelection();

            foreach (DataGridViewRow row in dgvCopySetup.Rows)
                row.Cells[2].Value = "---";
        }
    }
}
