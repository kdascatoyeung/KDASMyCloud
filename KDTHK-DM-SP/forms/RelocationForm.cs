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
using KDTHK_DM_SP.lists;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using CustomUtil.utils.authentication;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace KDTHK_DM_SP.forms
{
    public partial class RelocationForm : Form
    {
        string _defaultPath = @"\Documents";

        List<RelocateList> _relocateList = new List<RelocateList>();

        public RelocationForm(List<RelocateList> relocateList)
        {
            InitializeComponent();

            TreeviewUtil.LoadPersonalFolder(tvFolder, GlobalService.User);

            _relocateList = relocateList;

        }

        private void tvFolder_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var hittest = tvFolder.HitTest(e.Location);

            if (hittest.Location != TreeViewHitTestLocations.PlusMinus)
                _defaultPath = @"\" + e.Node.FullPath;
        }

        private void SaveData(List<RelocateList> relocateList)
        {
            foreach (RelocateList item in relocateList)
            {
                string filePath = item.FilePath;
                string owner = item.Owner;
                string folder = item.Folder;
                string type = item.SelectedType; //Folder or File
                string keyword = item.Keyword;
                string modified = item.LastModified;
                string disc = item.Disc;
                string vpath = item.Vpath;

                string sPath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

                string sVpath = "";

                if (type == "folder")
                {
                    int index = item.Vpath.LastIndexOf(item.Folder);

                    string tmp = item.Folder.Contains(@"\") ? item.Vpath.Substring(index) : item.Folder;
                    string storedVpath = _defaultPath + @"\" + tmp;
                    if (storedVpath.Contains("'"))
                        storedVpath = storedVpath.Replace("'", "''");

                    sVpath = storedVpath;

                    string query = string.Format("update " + GlobalService.DbTable + " set r_vpath = N'{0}' where r_path = N'{1}'", storedVpath, sPath);
                    DataService.GetInstance().ExecuteNonQuery(query);
                }
                else
                {
                    string storedVpath = _defaultPath;
                    if (storedVpath.Contains("'"))
                        storedVpath = storedVpath.Replace("'", "''");

                    sVpath = storedVpath;

                    string query = string.Format("update " + GlobalService.DbTable + " set r_vpath = N'{0}' where r_path = N'{1}'", storedVpath, sPath);
                    DataService.GetInstance().ExecuteNonQuery(query);
                }

                if (owner == GlobalService.User)
                {
                    List<string> memberList = new List<string>();

                    if (!sVpath.StartsWith(@"\Documents"))
                    {
                        if (sVpath.StartsWith(@"\Common"))
                        {
                            foreach (string member in GlobalService.DepartmentMemberList)
                                if (member != GlobalService.User)
                                    memberList.Add(member.Trim());
                        }
                        else
                        {
                            foreach (string member in GlobalService.DivisionMemberList)
                                if (member != GlobalService.User)
                                    memberList.Add(member.Trim());
                        }
                    }

                    DataRow[] rows = (from row in GlobalService.RootTable.AsEnumerable()
                                      where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == filePath
                                      select row).ToArray();

                    foreach (DataRow row in rows)
                    {
                        string member = string.Join(";", memberList.OfType<string>());
                        string text = string.Format("update " + GlobalService.DbTable + " set r_shared = N'{0}' where r_path = N'{1}'", member, sPath);
                        DataService.GetInstance().ExecuteNonQuery(text);

                        FileInfo info = new FileInfo(filePath);
                        FileSecurity fs = info.GetAccessControl();
                        AuthorizationRuleCollection rules = fs.GetAccessRules(true, true, typeof(NTAccount));

                        fs.SetAccessRuleProtection(true, false);

                        string fileName = Path.GetFileNameWithoutExtension(filePath);
                        string extension = Path.GetExtension(filePath);

                        foreach (string mem in memberList)
                        {
                            string tableName = "TB_" + AdUtil.GetUserIdByUsername(mem.Trim(), "kmhk.local");

                            fs.AddAccessRule(new FileSystemAccessRule(AdUtil.GetUserIdByUsername(mem.Trim(), "kmhk.local"), FileSystemRights.Modify, AccessControlType.Allow));

                            if (UserUtil.IsSpecialUser(mem))
                            //if (mem == "Chow Chi To(周志滔,Sammy)" || mem == "Ling Wai Man(凌慧敏,Velma)" || mem == "Chan Fai Lung(陳輝龍,Onyx)" || mem == "Ng Lau Yu, Lilith (吳柳如)" ||
                            //    mem == "Lee Miu Wah(李苗華)" || mem == "Lee Ming Fung(李銘峯)" || mem == "Ho Kin Hang(何健恒,Ken)" || mem == "Yeung Wai, Gabriel (楊偉)")
                            {
                                string asText = string.Format("select as_userid from TB_USER_AS where as_user = N'{0}'", mem.Trim());
                                string asId = DataService.GetInstance().ExecuteScalar(asText).ToString().Trim();

                                fs.AddAccessRule(new FileSystemAccessRule(asId, FileSystemRights.Modify, AccessControlType.Allow));
                            }

                            string sharedText = string.Format("if not exists (select * from " + tableName + " where r_path = N'{7}') insert into " + tableName + " (r_filename" +
                                ", r_extension, r_keyword, r_lastaccess, r_lastmodified, r_owner, r_shared, r_path, r_vpath, r_deletedate, r_disc) values " +
                                "(N'{0}', '{1}', N'{2}', '{3}', '{4}', N'{5}', N'{6}', N'{7}', N'{8}', '{9}', '{10}')", fileName, extension, keyword, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), modified, GlobalService.User,
                                mem.Trim(), sPath, sVpath, "2099/12/31", disc);
                            DataService.GetInstance().ExecuteNonQuery(sharedText);
                        }

                        File.SetAccessControl(filePath, fs);
                    }
                }
            }

            GlobalService.SelectedVpath = _defaultPath;

            this.DialogResult = DialogResult.OK;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData(_relocateList);
            /*List<string> memberList = new List<string>();

            if (!_defaultPath.StartsWith(@"\Documents"))
            {
                if (_defaultPath.StartsWith(@"\Common"))
                {
                    foreach (string member in GlobalService.DepartmentMemberList)
                        if (member != GlobalService.User)
                            memberList.Add(member.Trim());
                }
                else
                {
                    foreach (string member in GlobalService.DivisionMemberList)
                        if (member != GlobalService.User)
                            memberList.Add(member.Trim());
                }
            }
            else
            {
                DataUtil.RelocateData(GlobalService.RootTable, _relocateList, _defaultPath);
            }

            List<string> queryList = new List<string>();

            foreach (RelocateList item in _relocateList)
            {
                string filePath = item.FilePath;
                string owner = item.Owner;
                string folder = item.Folder;
                string type = item.SelectedType; //Folder or File
                string keyword = item.Keyword;
                string modified = item.LastModified;
                string disc = item.Disc;

                string sPath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

                string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                //DataRow[] rows = GlobalService.RootTable.Select(string.Format("filepath = '{0}'", sPath));
                DataRow[] rows = (from row in GlobalService.RootTable.AsEnumerable()
                                  where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == filePath
                                  select row).ToArray();

                foreach (DataRow row in rows)
                {
                    row["vpath"] = type == "file" ? _defaultPath : _defaultPath + @"\" + folder;

                    string vpath = row["vpath"].ToString();
                    string sVpath = vpath.Contains("'") ? vpath.Replace("'", "''") : vpath;

                    if (owner == GlobalService.User)
                    {
                        string member = string.Join(";", memberList.OfType<string>());

                        string text = string.Format("update " + GlobalService.DbTable + " set r_vpath = N'{0}', r_shared = N'{1}' where r_path = N'{2}'", row["vpath"].ToString(), member, sPath);
                        queryList.Add(text);

                        FileInfo info = new FileInfo(filePath);
                        FileSecurity fs = info.GetAccessControl();
                        AuthorizationRuleCollection rules = fs.GetAccessRules(true, true, typeof(NTAccount));

                        fs.SetAccessRuleProtection(true, false);

                        string fileName = Path.GetFileNameWithoutExtension(filePath);
                        string extension  = Path.GetExtension(filePath);

                        foreach (string mem in memberList)
                        {
                            string tableName = "TB_" + AdUtil.GetUserIdByUsername(mem.Trim(), "kmhk.local");

                            fs.AddAccessRule(new FileSystemAccessRule(AdUtil.GetUserIdByUsername(mem.Trim(), "kmhk.local"), FileSystemRights.Modify, AccessControlType.Allow));

                            string sharedText = string.Format("if not exists (select * from " + tableName + " where r_path = N'{7}') insert into " + tableName + " (r_filename" +
                                ", r_extension, r_keyword, r_lastaccess, r_lastmodified, r_owner, r_shared, r_path, r_vpath, r_deletedate, r_disc) values " +
                                "(N'{0}', '{1}', N'{2}', '{3}', '{4}', N'{5}', N'{6}', N'{7}', N'{8}', '{9}', '{10}')", fileName, extension, keyword, now, modified, GlobalService.User,
                                mem.Trim(), sPath, sVpath, "2099/12/31", disc);
                            queryList.Add(sharedText);
                        }

                        File.SetAccessControl(filePath, fs);
                    }
                    else
                    {
                        string text = string.Format("update " + GlobalService.DbTable + " set r_vpath = N'{0}' where r_path = N'{1}'", row["vpath"].ToString(), sPath);
                        queryList.Add(text);
                    }
                }
            }

            foreach (string query in queryList)
                DataService.GetInstance().ExecuteNonQuery(query);

            GlobalService.SelectedVpath = _defaultPath;

            this.DialogResult = DialogResult.OK;*/
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tsbtnNewFolder_Click(object sender, EventArgs e)
        {
            if (tvFolder.SelectedNode == null)
            {
                MessageBox.Show("Please select a folder first.");
                return;
            }

            NewFolderForm form = new NewFolderForm(@"\" + tvFolder.SelectedNode.FullPath, "relocate");
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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveData(_relocateList);   
        }
    }
}
