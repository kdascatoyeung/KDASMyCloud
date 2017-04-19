using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using CustomUtil.utils.authentication;
using System.Data.SqlServerCe;
using KDTHK_DM_SP.utils;
using System.IO;
using System.Diagnostics;
using KDTHK_DM_SP.lists;
using System.Security.AccessControl;
using System.Security.Principal;

namespace KDTHK_DM_SP.forms
{
    public partial class SingleShareForm : Form
    {
        string _filePath = "";
        string _fileName = "";
        string _vpath = "";
        string _lastModified = "";
        string _keyword = "";

        List<string> deleteList = new List<string>();
        List<string> deleteCnList = new List<string>();
        List<string> deleteVnList = new List<string>();
        List<string> deleteJpList = new List<string>();

        List<string> sharedList = new List<string>();

        public SingleShareForm(string fileName, string filePath, string owner, string vpath, string lastModified, string keyword)
        {
            InitializeComponent();

            this.Text = "Shared Property - " + fileName;

            _filePath = filePath;

            _fileName = fileName;

            _vpath = vpath;

            _lastModified = lastModified;

            _keyword = keyword;

            tsbtnNew.Enabled = owner == GlobalService.User ? true : false;

            tsbtnDelete.Enabled = owner == GlobalService.User ? true : false;

            btnSave.Enabled = owner == GlobalService.User ? true : false;

            tsbtnGroup.Enabled = owner == GlobalService.User ? false : true;

            if (owner == GlobalService.User)
                this.LoadShared(filePath);
            else
                this.LoadSharedNotOwner(filePath, owner);

            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            //tsbtnNotice.Enabled = lbShare.SelectedItems.Count > 0 ? true : false;

            tsbtnNotice.Enabled = dgvUser.SelectedRows.Count > 0 ? true : false;
        }

        private void LoadShared(string filePath)
        {
            string sPath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

            DataRow[] rows = GlobalService.RootTable.Select(string.Format("filepath = '{0}'", sPath));

            List<string> sharedList = new List<string>();

            foreach (DataRow row in rows)
            {
                string shared = row["shared"].ToString();

                sharedList = shared.Split(';').ToList();
            }

            /*foreach (string shared in sharedList)
                if (shared != "-")
                    if (!lbShare.Items.Contains(shared))
                        lbShare.Items.Add(shared);*/

            List<string> tmplist = new List<string>();

            foreach (string shared in sharedList)
            {
                if (shared != "-")
                {
                    if (!tmplist.Contains(shared))
                    {
                        tmplist.Add(shared);
                        if (UserUtil.IsCnMember(shared))
                            dgvUser.Rows.Add(shared, "CN");
                        else if (UserUtil.IsVnMember(shared))
                            dgvUser.Rows.Add(shared, "VN");
                        else if (UserUtil.IsJpMember(shared))
                            dgvUser.Rows.Add(shared, "JP");
                        else
                            dgvUser.Rows.Add(shared, "HK");
                    }
                }
            }

            /*foreach (string cnShared in LoadCnSharedList(sPath))
            {
                if (!tmplist.Contains(cnShared))
                {
                    tmplist.Add(cnShared);
                    dgvUser.Rows.Add(cnShared, "CN");
                }
            }*/
        }

        private void LoadSharedNotOwner(string filePath, string owner)
        {
            string tableName = "TB_" + AdUtil.GetUserIdByUsername(owner, "kmhk.local");

            filePath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

            string query = string.Format("select r_shared from " + tableName + " where r_path = N'{0}'", filePath);

            List<string> tmplist = new List<string>();

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                {
                    string shared = GlobalService.Reader.GetString(0);

                    List<string> sharedlist = shared.Split(';').ToList();

                    foreach (string item in sharedlist)
                        if (item != GlobalService.User && !lbShare.Items.Contains(item) && item != "-")
                            lbShare.Items.Add(item);

                    foreach (string item in sharedlist)
                    {
                        if (item != "-" && item != GlobalService.User)
                        {
                            if (!tmplist.Contains(item))
                            {
                                tmplist.Add(item);
                                dgvUser.Rows.Add(item, "HK");
                            }
                        }
                    }
                }
            }

            foreach (string gShared in LoadGlobalSharedList(filePath))
            {
                if (!tmplist.Contains(gShared))
                {
                    tmplist.Add(gShared);
                    if (UserUtil.IsCnMember(gShared))
                        dgvUser.Rows.Add(gShared, "CN");
                    else if (UserUtil.IsVnMember(gShared))
                        dgvUser.Rows.Add(gShared, "VN");
                    else
                        dgvUser.Rows.Add(gShared, "JP");
                }
            }

            dgvUser.Rows.Add(owner, "HK");
            //lbShare.Items.Add(owner);
        }

        private List<string> LoadGlobalSharedList(string filepath)
        {
            //if(filepath.Contains("'"))
               // filepath = filepath.Replace("'", "''");

            List<string> list = new List<string>();

            string query = string.Format("select o_to from TB_OUTSIDE_SHARE where o_path = N'{0}' and o_from = N'{1}'", filepath, GlobalService.User);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    list.Add(reader.GetString(0).Trim());
            }

            return list.Distinct().ToList();
        }

        private void tsbtnNew_Click(object sender, EventArgs e)
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

                foreach(DataGridViewRow row in dgvUser.Rows)
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
        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            /*for (int i = lbShare.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int index = lbShare.SelectedIndices[i];
                deleteList.Add(lbShare.Items[index].ToString().Trim());
                lbShare.Items.RemoveAt(index);
            }*/

            foreach (DataGridViewRow row in dgvUser.SelectedRows)
            {
                string loc = row.Cells[1].Value.ToString().Trim();

                if (loc == "HK")
                    deleteList.Add(row.Cells[0].Value.ToString().Trim());
                else if (loc == "CN")
                    deleteCnList.Add(row.Cells[0].Value.ToString().Trim());
                else if (loc == "VN")
                    deleteVnList.Add(row.Cells[0].Value.ToString().Trim());
                else
                    deleteJpList.Add(row.Cells[0].Value.ToString().Trim());

                dgvUser.Rows.Remove(row);
            }

           /* for (int i = dgvUser.SelectedRows.Count - 1; i >= 0; i--)
            {
                string loc = dgvUser.SelectedRows[i].Cells[1].Value.ToString().Trim();
                if (loc == "HK")
                    deleteList.Add(dgvUser.SelectedRows[i].Cells[0].Value.ToString().Trim());
                else
                    deleteCnList.Add(dgvUser.SelectedRows[i].Cells[0].Value.ToString().Trim());

                dgvUser.Rows.RemoveAt(i);
            }*/
        }

        private void tsbtnNotice_Click(object sender, EventArgs e)
        {
            List<string> receiverList = new List<string>();// lbShare.Items.Cast<string>().ToList();

            foreach (DataGridViewRow row in dgvUser.Rows)
                receiverList.Add(row.Cells[0].Value.ToString().Trim());

            NoticeSendForm form = new NoticeSendForm(receiverList, _filePath, _fileName);
            form.ShowDialog();
        }

        private void SaveData()
        {
            SharedUtil.UpdateEmptyShared();
            SharedUtil.UpdateShared();

            string sPath = _filePath.Contains("'") ? _filePath.Replace("'", "''") : _filePath;

            DataRow[] rows = GlobalService.RootTable.Select(string.Format("filepath = '{0}'", sPath));

            List<string> hklist = new List<string>();
            List<string> cnlist = new List<string>();
            List<string> vnlist = new List<string>();
            List<string> jplist = new List<string>();

            foreach (DataGridViewRow row in dgvUser.Rows)
            {
                string loc = row.Cells[1].Value.ToString().Trim();
                if (loc == "HK")
                    hklist.Add(row.Cells[0].Value.ToString().Trim());
                else if (loc == "CN")
                    cnlist.Add(row.Cells[0].Value.ToString().Trim());
                else if (loc == "VN")
                    vnlist.Add(row.Cells[0].Value.ToString().Trim());
                else
                    jplist.Add(row.Cells[0].Value.ToString().Trim());
            }

            //FileInfo info = new FileInfo(_filePath);
            //FileSecurity fs = info.GetAccessControl();
            //AuthorizationRuleCollection rules = fs.GetAccessRules(true, true, typeof(NTAccount));

            if (deleteList.Count > 0)
                PermissionUtil.RemovePermission(deleteList, _filePath);

            if (deleteCnList.Count > 0)
                PermissionUtil.RemoveGlobalPermission(deleteCnList, _filePath, "kmcn.local");

            if (deleteVnList.Count > 0)
                PermissionUtil.RemoveGlobalPermission(deleteVnList, _filePath, "kdtvn.local");

            if (deleteJpList.Count > 0)
                PermissionUtil.RemoveGlobalPermission(deleteJpList, _filePath, "km.local");

            if (hklist.Count > 0)
                PermissionUtil.SetPermission(hklist, _filePath);

            if (cnlist.Count > 0)
                PermissionUtil.SetGlobalPermission(cnlist, _filePath, "kmcn.local");

            if (vnlist.Count > 0)
                PermissionUtil.SetGlobalPermission(vnlist, _filePath, "kdtvn.local");

            if (jplist.Count > 0)
                PermissionUtil.SetGlobalPermission(jplist, _filePath, "km.local");

            List<string> totalList = hklist.Concat(cnlist).Concat(vnlist).Concat(jplist).ToList();

            string shared = totalList.Count == 0 ? "-" : string.Join(";", totalList.ToArray());

            foreach (DataRow row in rows)
            {
                if (shared == "")
                    shared = "-";

                row["shared"] = shared;

                string text = string.Format("update " + GlobalService.DbTable + " set r_shared = N'{0}' where r_path = N'{1}'", shared, sPath);
                DataService.GetInstance().ExecuteNonQuery(text);
            }

            string disc = DiscUtil.IsDisc(GlobalService.RootTable, _filePath) ? "True" : "False";

            string extension = Path.GetExtension(_filePath);

            if (_fileName.Contains("'"))
                _fileName = _fileName.Replace("'", "''");

            if (_keyword.Contains("'"))
                _keyword = _keyword.Replace("'", "''");

            foreach (string sharedPerson in hklist)
            {
                string tableName = "TB_" + AdUtil.GetUserIdByUsername(sharedPerson.Trim(), "kmhk.local");

                string sharedDivision = SystemUtil.GetDivision(sharedPerson.Trim());
                string sharedDepartment = SystemUtil.GetDepartment(sharedPerson.Trim());

                string sharedVpath = sharedDivision != GlobalService.Division && _vpath.StartsWith(@"\" + GlobalService.Division) ? @"\Documents" + _vpath
                            : sharedDepartment != GlobalService.DepartmentFolder && _vpath.StartsWith(@"\Common") ? @"\Documents" + _vpath : _vpath;

                string sharedText = string.Format("if not exists (select * from " + tableName + " where r_path = N'{7}') insert into " + tableName + " (r_filename, r_extension, r_keyword, r_lastaccess, r_lastmodified, r_owner, r_shared, r_path, r_vpath, r_deletedate, r_disc)" +
                            " values (N'{0}', '{1}', N'{2}', '{3}', '{4}', N'{5}', N'{6}', N'{7}', N'{8}', '{9}', '{10}')", _fileName, extension, _keyword, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), _lastModified, GlobalService.User,
                            sharedPerson.Trim(), sPath, sharedVpath, "2099/12/31", disc);

                DataService.GetInstance().ExecuteNonQuery(sharedText);
            }

            SharedUtil.SharedCN(cnlist, sPath, _fileName, _keyword);
            SharedUtil.SharedVN(vnlist, sPath, _fileName, _keyword);
            SharedUtil.SharedJp(jplist, sPath, _fileName, _keyword);

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

            DialogResult = DialogResult.OK;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
            /*SharedUtil.UpdateEmptyShared();
            SharedUtil.UpdateShared();

            string sPath = _filePath.Contains("'") ? _filePath.Replace("'", "''") : _filePath;

            DataRow[] rows = GlobalService.RootTable.Select(string.Format("filepath = '{0}'", sPath));

            //string shared = lbShare.Items.Count == 0 ? "-" : string.Join(";", lbShare.Items.Cast<string>());

            List<string> hklist = new List<string>();
            List<string> cnlist = new List<string>();

            foreach (DataGridViewRow row in dgvUser.Rows)
            {
                string loc = row.Cells[1].Value.ToString().Trim();
                if (loc == "HK")
                    hklist.Add(row.Cells[0].Value.ToString().Trim());
                else
                    cnlist.Add(row.Cells[0].Value.ToString().Trim());
            }

            string shared = hklist.Count == 0 ? "-" : string.Join(";", hklist.ToArray());

            if (deleteList.Count > 0)
                PermissionUtil.RemovePermission(deleteList, _filePath);

            //sharedList = lbShare.Items.Cast<string>().ToList();

            if (hklist.Count > 0)
                PermissionUtil.SetPermission(hklist, _filePath);

            List<string> queryList = new List<string>();

            foreach (DataRow row in rows)
            {
                if (shared == "")
                    shared = "-";

                row["shared"] = shared;

                string text = string.Format("update " + GlobalService.DbTable + " set r_shared = N'{0}' where r_path = N'{1}'", shared, sPath);

                DataService.GetInstance().ExecuteNonQuery(text);
            }

            string disc = DiscUtil.IsDisc(GlobalService.RootTable, _filePath) ? "True" : "False";

            string extension = Path.GetExtension(_filePath);

            if (_fileName.Contains("'"))
                _fileName = _fileName.Replace("'", "''");

            if (_keyword.Contains("'"))
                _keyword = _keyword.Replace("'", "''");

            foreach (string sharedPerson in hklist)
            {
                string tableName = "TB_" + AdUtil.GetUserIdByUsername(sharedPerson.Trim(), "kmhk.local");

                string sharedDivision = SystemUtil.GetDivision(sharedPerson.Trim());
                string sharedDepartment = SystemUtil.GetDepartment(sharedPerson.Trim());

                //Debug.WriteLine("Shared Division: " + sharedDivision + "   My Division: " + GlobalService.Division);
                //Debug.WriteLine("Shared Department: " + sharedDepartment + "  My Department: " + GlobalService.Department);

                string sharedVpath = sharedDivision != GlobalService.Division && _vpath.StartsWith(@"\" + GlobalService.Division) ? @"\Documents" + _vpath
                            : sharedDepartment != GlobalService.DepartmentFolder && _vpath.StartsWith(@"\Common") ? @"\Documents" + _vpath : _vpath;

                string sharedText = string.Format("if not exists (select * from " + tableName + " where r_path = N'{7}') insert into " + tableName + " (r_filename, r_extension, r_keyword, r_lastaccess, r_lastmodified, r_owner, r_shared, r_path, r_vpath, r_deletedate, r_disc)" +
                            " values (N'{0}', '{1}', N'{2}', '{3}', '{4}', N'{5}', N'{6}', N'{7}', N'{8}', '{9}', '{10}')", _fileName, extension, _keyword, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), _lastModified, GlobalService.User,
                            sharedPerson.Trim(), sPath, sharedVpath, "2099/12/31", disc);

                DataService.GetInstance().ExecuteNonQuery(sharedText);
            }

            foreach (string cnPerson in cnlist)
            {
                //string query = string.Format
            }

            //DataUtil.SyncDataToServer();

            this.DialogResult = DialogResult.OK;*/
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void tsbtnGroup_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();

            foreach (DataGridViewRow row in dgvUser.Rows)
                list.Add(row.Cells[0].Value.ToString().Trim());

            list = list.Distinct().ToList();

            CustomGroupForm form = new CustomGroupForm(list);
            if (form.ShowDialog() == DialogResult.OK)
                DialogResult = DialogResult.OK;

        }
    }
}
