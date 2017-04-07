using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using KDTHK_DM_SP.lists;
using System.IO;
using System.Security.Principal;
using System.Security.AccessControl;
using CustomUtil.utils.authentication;
using KDTHK_DM_SP.utils;
using System.Diagnostics;

namespace KDTHK_DM_SP.forms
{
    public partial class MultiShareForm : Form
    {
        List<string> sharedList = new List<string>();

        List<SharedList> _list;

        List<string> deleteList = new List<string>();
        List<string> deleteCnList = new List<string>();
        List<string> deleteVnList = new List<string>();
        List<string> deleteJpList = new List<string>();

        public MultiShareForm(List<SharedList> list)
        {
            InitializeComponent();

            _list = list;

            this.LoadData(list);
        }

        private void LoadData(List<SharedList> list)
        {
            foreach (SharedList item in list)
            {
                string shared = item.Shared == "" ? "-" : item.Shared;
                dgvShareSetup.Rows.Add(item.Filename, item.Filepath, item.Vpath, shared, item.Keyword, item.LastModified, item.Disc, item.Shared);
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
                if (sharedList.Count > 0)
                {
                    foreach (string shared in sharedList)
                    {
                        if (!UserUtil.IsCnMember(shared))
                            dgvUser.Rows.Add(shared, "HK");
                        else
                            dgvUser.Rows.Add(shared, "CN");
                    }
                }
                        //lbShare.Items.Add(shared);
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
                    //lbShare.Items.Add(member);
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
                    //lbShare.Items.Add(member);
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
                    foreach (DataGridViewRow row in dgvShareSetup.Rows)
                        row.Cells[3].Value = shared;
                }
                else
                {
                    dgvShareSetup.CurrentRow.Cells[3].Value = shared;
                }
            }
            else
            {
                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvShareSetup.Rows)
                        row.Cells[3].Value = "-";
                else
                    dgvShareSetup.CurrentRow.Cells[3].Value = "-";
            }

           /*if (lbShare.Items.Count > 0)
            {
                string shared = string.Join(";", lbShare.Items.OfType<object>());

                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvShareSetup.Rows)
                        row.Cells[3].Value = shared;
                else
                    dgvShareSetup.CurrentRow.Cells[3].Value = shared;
            }
            else
            {
                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvShareSetup.Rows)
                        row.Cells[3].Value = "-";
                else
                    dgvShareSetup.CurrentRow.Cells[3].Value = "-";
            }*/
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
                    foreach (DataGridViewRow row in dgvShareSetup.Rows)
                        row.Cells[3].Value = shared;
                }
                else
                {
                    dgvShareSetup.CurrentRow.Cells[3].Value = shared;
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
                    foreach (DataGridViewRow row in dgvShareSetup.Rows)
                        row.Cells[3].Value = shared;
                }
                else
                {
                    dgvShareSetup.CurrentRow.Cells[3].Value = shared;
                }
            }*/

            /*if (lbShare.Items.Count > 0)
            {
                string shared = string.Join(";", lbShare.Items.OfType<object>());

                if (ckbApplyAll.Checked)
                {
                    foreach (DataGridViewRow row in dgvShareSetup.Rows)
                        row.Cells[3].Value = shared;
                }
                else
                {
                    dgvShareSetup.CurrentRow.Cells[3].Value = shared;
                }
            }*/
        }

        private void btnDeleteShare_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUser.SelectedRows)
            {
                dgvUser.Rows.Remove(row);
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
                    foreach (DataGridViewRow row in dgvShareSetup.Rows)
                        row.Cells[3].Value = shared;
                }
                else
                {
                    dgvShareSetup.CurrentRow.Cells[3].Value = shared;
                }
            }
            else
            {
                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvShareSetup.Rows)
                        row.Cells[3].Value = "-";
                else
                    dgvShareSetup.CurrentRow.Cells[3].Value = "-";
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
                    foreach (DataGridViewRow row in dgvShareSetup.Rows)
                        row.Cells[3].Value = shared;
                else
                    dgvShareSetup.CurrentRow.Cells[3].Value = shared;
            }
            else
            {
                if (ckbApplyAll.Checked)
                    foreach (DataGridViewRow row in dgvShareSetup.Rows)
                        row.Cells[3].Value = "-";
                else
                    dgvShareSetup.CurrentRow.Cells[3].Value = "-";
            }*/
        }

        private void dgvShareSetup_SelectionChanged(object sender, EventArgs e)
        {
            dgvUser.Rows.Clear();
            //lbShare.Items.Clear();

            string shared = dgvShareSetup.CurrentRow.Cells[3].Value.ToString();

            if (shared == "-")
                dgvUser.Rows.Clear();
            //lbShare.Items.Clear();
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
                //string[] arrShared = shared.Split(';');

                //foreach (string arr in arrShared)
                   // lbShare.Items.Add(arr.Trim());
            }
        }

        private void tsbtnUndo_Click(object sender, EventArgs e)
        {
            dgvShareSetup.Rows.Clear();

            this.LoadData(_list);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> queryList = new List<string>();

            foreach (DataGridViewRow row in dgvShareSetup.Rows)
            {
                string name = row.Cells[0].Value.ToString();
                string path = row.Cells[1].Value.ToString();
                string folder = row.Cells[2].Value.ToString();
                string shared = row.Cells[3].Value.ToString();
                string keyword = row.Cells[4].Value.ToString();
                string modified = row.Cells[5].Value.ToString();
                string disc = row.Cells[6].Value.ToString();
                string oShared = row.Cells[7].Value.ToString();

                string extension = Path.GetExtension(path);
                string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                if (keyword == "")
                    keyword = name;

                //if (shared == oShared)
                   // continue;

                FileInfo info = new FileInfo(path);
                FileSecurity fs = info.GetAccessControl();
                AuthorizationRuleCollection rules = fs.GetAccessRules(true, true, typeof(NTAccount));

                foreach (FileSystemAccessRule rule in rules)
                    fs.RemoveAccessRuleSpecific(rule);

                fs.SetAccessRuleProtection(true, false);
                fs.AddAccessRule(new FileSystemAccessRule(@"kmhk\itadmin", FileSystemRights.FullControl, AccessControlType.Allow));
                fs.AddAccessRule(new FileSystemAccessRule(AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local"), FileSystemRights.FullControl, AccessControlType.Allow));

                string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

                if (DataUtil.IsRecordExists(path))
                {
                    List<string> list = DataUtil.GetSharedList(GlobalService.DbTable, path);

                    if (list.Count > 0)
                    {
                        foreach (string item in list)
                        {
                            if (!UserUtil.IsCnMember(item.Trim()) && !UserUtil.IsVnMember(item.Trim()) && !UserUtil.IsJpMember(item.Trim()))
                            {
                                string tbName = "TB_" + AdUtil.GetUserIdByUsername(item.Trim(), "kmhk.local");

                                string delText = string.Format("delete from " + tbName + " where r_path = N'{0}' and r_owner = N'{1}'", sPath, GlobalService.User);
                                DataService.GetInstance().ExecuteNonQuery(delText);
                            }
                            else
                            {
                                string delText = string.Format("delete from S_OUT_SHARE where o_path = N'{0}' and o_to = N'{1}'", sPath, item.Trim());
                                DataServiceMes.GetInstance().ExecuteNonQuery(delText);
                            }
                        }
                    }
                }

                List<string> sharedList = shared.Split(';').ToList();

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

                if (name.Contains("'"))
                    name = name.Replace("'", "''");

                if (keyword.Contains("'"))
                    keyword = keyword.Replace("'", "''");

                if (shared != "-")
                {
                    foreach (string item in hklist)
                    {
                        string sharedId = AdUtil.GetUserIdByUsername(item.Trim(), "kmhk.local");
                        string tableName = "TB_" + sharedId;

                        string sharedDivision = SystemUtil.GetDivision(item.Trim());
                        string sharedDepartment = SystemUtil.GetDepartment(item.Trim());

                        fs.AddAccessRule(new FileSystemAccessRule(sharedId, FileSystemRights.Modify, AccessControlType.Allow));


                        if (UserUtil.IsSpecialUser(item))
                        //if (item == "Chow Chi To(周志滔,Sammy)" || item == "Ling Wai Man(凌慧敏,Velma)" || item == "Chan Fai Lung(陳輝龍,Onyx)" || item == "Ng Lau Yu, Lilith (吳柳如)" ||
                        //        item == "Lee Miu Wah(李苗華)" || item == "Lee Ming Fung(李銘峯)" || item == "Ho Kin Hang(何健恒,Ken)" || item == "Yeung Wai, Gabriel (楊偉)")
                        {
                            string asText = string.Format("select as_userid from TB_USER_AS where as_user = N'{0}'", item.Trim());
                            string asId = DataService.GetInstance().ExecuteScalar(asText).ToString().Trim();

                            fs.AddAccessRule(new FileSystemAccessRule(asId, FileSystemRights.Modify, AccessControlType.Allow));
                        }

                        string sharedVpath = sharedDivision != GlobalService.Division && folder.StartsWith(@"\" + GlobalService.Division) ? @"\Documents" + folder
                            : sharedDepartment != GlobalService.Department && folder.StartsWith(@"\Common") ? @"\Documents" + folder : folder;

                        if (sharedVpath.Contains("'"))
                            sharedVpath.Replace("'", "''");

                        string sharedText = string.Format("insert into " + tableName + " (r_filename, r_extension, r_keyword, r_lastaccess, r_lastmodified, r_owner, r_shared, r_path, r_vpath, r_deletedate)" +
                            " values (N'{0}', '{1}', N'{2}', '{3}', '{4}', N'{5}', N'{6}', N'{7}', N'{8}', '{9}')", name, extension, keyword, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), modified, GlobalService.User,
                            item.Trim(), sPath, sharedVpath, "2099/12/31");

                        queryList.Add(sharedText);

                        try
                        {
                            File.SetAccessControl(path, fs);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine(ex.Message + ex.StackTrace);
                            continue;
                        }
                    }

                    if (cnlist.Count > 0)
                    {
                        PermissionUtil.SetGlobalPermission(cnlist, path, "kmcn.local");
                        SharedUtil.SharedCN(cnlist, sPath, name, keyword);
                    }

                    if (vnlist.Count > 0)
                    {
                        PermissionUtil.SetGlobalPermission(vnlist, path, "kdtvn.local");
                        SharedUtil.SharedVN(vnlist, sPath, name, keyword);
                    }

                    if (jplist.Count > 0)
                    {
                        PermissionUtil.SetGlobalPermission(jplist, path, "km.local");
                        SharedUtil.SharedJp(jplist, sPath, name, keyword);
                    }
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

                if (shared == "")
                    shared = "-";

                string ownerText = string.Format("update " + GlobalService.DbTable + " set r_shared = N'{0}' where r_path = N'{1}'", shared, sPath);
                queryList.Add(ownerText);

                
            }

            foreach (string text in queryList)
                DataService.GetInstance().ExecuteNonQuery(text);

            GlobalService.RootTable = RootUtil.RootDataTable();
            this.DialogResult = DialogResult.OK;
        }
    }
}
