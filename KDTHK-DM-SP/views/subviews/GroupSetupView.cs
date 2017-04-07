using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using KDTHK_DM_SP.lists;
using System.Diagnostics;
using System.Data.SqlServerCe;
using KDTHK_DM_SP.utils;
using KDTHK_DM_SP.forms;

namespace KDTHK_DM_SP.views.subviews
{
    public partial class GroupSetupView : UserControl
    {
        string _mode = "hk";

        List<UserList> _userList = new List<UserList>();

        List<UserGlobalList> _globalList = new List<UserGlobalList>();

        string _selectedGroup = "";

        public GroupSetupView()
        {
            InitializeComponent();

            Application.Idle += new EventHandler(Application_Idle);

            GlobalService.SelectedGlobalUserList = new List<UserGlobalList>();

            /*foreach (string item in GlobalService.SystemGroupList)
                if (item != "Custom")
                    ckblbGroup.Items.Add(item);*/

            this.LoadCustomGroup();

            LoadGroup(_mode);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            tsbtnRename.Enabled = dgvGroup.SelectedRows.Count > 0 ? true : false;
            tsbtnDelete.Enabled = dgvGroup.SelectedRows.Count > 0 ? true : false;
        }

        private void LoadCustomGroup()
        {
            List<string> groupList = new List<string>();

            dgvGroup.Rows.Clear();

            string query = string.Format("select distinct g_name from TB_CUSTOM_GROUP where g_owner = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    dgvGroup.Rows.Add(reader.GetString(0).Trim());
            }
            /*foreach (CustomGroupList group in GlobalService.CustomGroupList)
                if (!groupList.Contains(group.Group))
                    groupList.Add(group.Group);

            foreach (string group in groupList)
                dgvGroup.Rows.Add(group, group);*/
        }

        private void ToolStripButtonClicked(object sender, EventArgs e)
        {
            ToolStripButton button = (ToolStripButton)sender;
            string tag = button.Tag.ToString();

            tsbtnHk.Image = Properties.Resources.Hong_Kong_flat_gray;
            tsbtnJp.Image = Properties.Resources.Japan_gray;
            tsbtnCn.Image = Properties.Resources.China_flat_gray;
            tsbtnVn.Image = Properties.Resources.Vietnam_flat_gray;

            _mode = tag;

            LoadGroup(tag);

            if (tag == "hk") tsbtnHk.Image = Properties.Resources.Hong_Kong_flat;

            if (tag == "jp") tsbtnJp.Image = Properties.Resources.Japan;

            if (tag == "cn") tsbtnCn.Image = Properties.Resources.China_flat;

            if (tag == "vn") tsbtnVn.Image = Properties.Resources.Vietnam_flat;
        }

        private void LoadGroup(string location)
        {
            try
            {
                ckblbGroup.Items.Clear();

                if (location == "hk")
                {
                    foreach (string item in GlobalService.SystemGroupList)
                        if (item != "Custom")
                            ckblbGroup.Items.Add(item);

                    foreach (CustomGroupList item in GlobalService.CustomGroupList)
                        if (!ckblbGroup.Items.Contains(item.Group))
                            ckblbGroup.Items.Add(item.Group);
                }
                else if (location == "jp")
                {
                    foreach (string item in GlobalService.JPGroupList)
                        ckblbGroup.Items.Add(item);
                }
                else if (location == "cn")
                {
                    foreach (string item in GlobalService.CNGroupList)
                        ckblbGroup.Items.Add(item);
                }
                else
                    foreach (string item in GlobalService.VNGroupList)
                        ckblbGroup.Items.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void ckblbGroup_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = dgvUsers.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dgvUsers.Rows[i];

                string isChecked = row.Cells[0].FormattedValue.ToString();
                string name = row.Cells[1].Value.ToString();
                string division = row.Cells[2].Value.ToString();
                string location = row.Cells[3].Value.ToString();

                if (isChecked == "True")
                    if (!_globalList.Contains(_globalList.Find(x => x.Name == name)))
                        _globalList.Add(new UserGlobalList { Name = name, Department = division, Location = location });
                    else
                        continue;
                else
                    _globalList.RemoveAll(x => x.Name == name);
            }

            dgvUsers.Rows.Clear();

            _globalList = _globalList.Distinct().ToList();

            ckbCheckall.Checked = true;

            string selectedItem = ckblbGroup.Items[e.Index].ToString().Trim();

            List<UserList> hklist = new List<UserList>();
            List<UserJpList> jplist = new List<UserJpList>();
            List<UserCnList> cnlist = new List<UserCnList>();
            List<UserVnList> vnlist = new List<UserVnList>();

            List<SystemGroupList> systemGroupList = new List<SystemGroupList>();
            List<CustomGroupList> customGroupList = new List<CustomGroupList>();

            if (e.NewValue == CheckState.Checked)
            {
                switch (_mode)
                {
                    case "hk":
                        if (e.Index > 16)
                        {
                            customGroupList = GlobalService.CustomGroupList.Where(x => x.Group == selectedItem.Trim()).ToList();

                            foreach (CustomGroupList item in customGroupList)
                                if (!_globalList.Contains(_globalList.Find(x => x.Name.Trim() == item.Member.Trim())))
                                    if (item.Member.Trim() != GlobalService.User)
                                        _globalList.Add(new UserGlobalList { Name = item.Member, Department = item.Division, Location = "HK" });
                        }
                        else if (e.Index > 13 && e.Index <= 16)
                        {
                            systemGroupList = GlobalService.ExtraSystemGroupList.Where(x => x.Group == selectedItem.Trim()).ToList();

                            foreach (SystemGroupList item in systemGroupList)
                                if (!_globalList.Contains(_globalList.Find(x => x.Name.Trim() == item.User.Trim())))
                                    if (item.User.Trim() != GlobalService.User)
                                        _globalList.Add(new UserGlobalList { Name = item.User.Trim(), Department = item.Division, Location = "HK" });
                        }
                        else
                        {
                            hklist = GlobalService.AllUserList.Where(x => x.Division == selectedItem.Trim()).ToList();

                            foreach (UserList item in hklist)
                                if (!_globalList.Contains(_globalList.Find(x => x.Name == item.User)))
                                    if (item.User.Trim() != GlobalService.User)
                                        _globalList.Add(new UserGlobalList { Name = item.User, Department = item.Division, Location = "HK" });
                        }
                        break;

                    case "jp":
                        jplist = GlobalService.JpUserList.Where(x => x.Department == selectedItem.Trim()).ToList();

                        foreach (UserJpList item in jplist)
                            if (!_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                _globalList.Add(new UserGlobalList { Name = item.Name, Department = item.Department, Location = "JP" });
                        break;

                    case "cn":
                        cnlist = GlobalService.CnUserList.Where(x => x.Department == selectedItem.Trim()).ToList();

                        foreach (UserCnList item in cnlist)
                            if (!_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                _globalList.Add(new UserGlobalList { Name = item.Name, Department = item.Department, Location = "CN" });
                        break;

                    case "vn":
                        vnlist = GlobalService.VnUserList.Where(x => x.Department == selectedItem.Trim()).ToList();

                        foreach (UserVnList item in vnlist)
                            if (!_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                _globalList.Add(new UserGlobalList { Name = item.Name, Department = item.Department, Location = "VN" });
                        break;
                }
            }
            else
            {
                string testItem = ckblbGroup.Items[e.Index].ToString().Trim();

                switch (_mode)
                {
                    case "hk":
                        if (e.Index > 16)
                        {
                            customGroupList = GlobalService.CustomGroupList.Where(x => x.Group == testItem.Trim()).ToList();

                            foreach (CustomGroupList item in customGroupList)
                                if (_globalList.Contains(_globalList.Find(x => x.Name == item.Member)))
                                    _globalList.RemoveAll(x => x.Name == item.Member.Trim());
                        }
                        else if (e.Index > 13 && e.Index <= 16)
                        {
                            systemGroupList = GlobalService.ExtraSystemGroupList.Where(x => x.Group == testItem.Trim()).ToList();

                            foreach (SystemGroupList item in systemGroupList)
                                if (_globalList.Contains(_globalList.Find(x => x.Name.Trim() == item.User.Trim())))
                                    _globalList.RemoveAll(x => x.Name.Trim() == item.User.Trim());
                        }
                        else
                        {
                            hklist = GlobalService.AllUserList.Where(x => x.Division == testItem.Trim()).ToList();

                            foreach (UserList item in hklist)
                            {
                                if (_globalList.Contains(_globalList.Find(x => x.Name == item.User)))
                                {
                                    //Debug.WriteLine("Contains: " + item.User);
                                    _globalList.RemoveAll(x => x.Name == item.User.Trim());

                                }
                            }
                        }

                        break;

                    case "jp":
                        jplist = GlobalService.JpUserList.Where(x => x.Department == testItem.Trim()).ToList();

                        foreach (UserJpList item in jplist)
                            if (_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                _globalList.RemoveAll(x => x.Name == item.Name.Trim());
                        break;

                    case "cn":
                        cnlist = GlobalService.CnUserList.Where(x => x.Department == testItem.Trim()).ToList();

                        foreach (UserCnList item in cnlist)
                            if (_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                _globalList.RemoveAll(x => x.Name == item.Name.Trim());
                        break;

                    case "vn":
                        vnlist = GlobalService.VnUserList.Where(x => x.Department == testItem.Trim()).ToList();

                        foreach (UserVnList item in vnlist)
                            if (_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                _globalList.RemoveAll(x => x.Name == item.Name.Trim());
                        break;
                }
            }


                /*foreach (int index in ckblbGroup.CheckedIndices)
                {
                    string reloadItem = ckblbGroup.Items[index].ToString().Trim();

                    Debug.WriteLine("Reload Item: " + reloadItem);
                    switch (_mode)
                    {
                        case "hk":
                            if (index > 17)
                            {
                                customGroupList = GlobalService.CustomGroupList.Where(x => x.Group == reloadItem.Trim()).ToList();

                                foreach (CustomGroupList item in customGroupList)
                                    if (_globalList.Contains(_globalList.Find(x => x.Name == item.Member)))
                                        _globalList.RemoveAll(x => x.Name == item.Member.Trim());
                            }
                            else if (index > 14 && index <= 17)
                            {
                                systemGroupList = GlobalService.ExtraSystemGroupList.Where(x => x.Group == reloadItem.Trim()).ToList();

                                foreach (SystemGroupList item in systemGroupList)
                                    if (_globalList.Contains(_globalList.Find(x => x.Name == item.User)))
                                        _globalList.RemoveAll(x => x.Name == item.User.Trim());
                            }
                            else
                            {
                                hklist = GlobalService.AllUserList.Where(x => x.Division == reloadItem.Trim()).ToList();

                                foreach (UserList item in hklist)
                                {
                                    if (!_globalList.Contains(_globalList.Find(x => x.Name == item.User)))
                                    {
                                        //Debug.WriteLine("Contains: " + item.User);
                                        _globalList.RemoveAll(x => x.Name == item.User.Trim());
                                        
                                    }
                                }
                            }

                            break;


                        case "jp":
                            jplist = GlobalService.JpUserList.Where(x => x.Department == reloadItem.Trim()).ToList();

                            foreach (UserJpList item in jplist)
                                if (_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                    _globalList.RemoveAll(x => x.Name == item.Name.Trim());
                            break;

                        case "cn":
                            cnlist = GlobalService.CnUserList.Where(x => x.Department == reloadItem.Trim()).ToList();

                            foreach (UserCnList item in cnlist)
                                if (_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                    _globalList.RemoveAll(x => x.Name == item.Name.Trim());
                            break;

                        case "vn":
                            vnlist = GlobalService.VnUserList.Where(x => x.Department == selectedItem.Trim()).ToList();

                            foreach (UserVnList item in vnlist)
                                if (_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                    _globalList.RemoveAll(x => x.Name == item.Name.Trim());
                            break;
                    }
                }
            }*/

            _globalList = _globalList.Distinct().ToList();

            foreach (UserGlobalList item in _globalList)
                dgvUsers.Rows.Add("True", item.Name, item.Department, item.Location);
            /*dgvUsers.Rows.Clear();

            string selectedItem = ckblbGroup.Items[e.Index].ToString();

            List<UserList> userList = new List<UserList>();

            List<SystemGroupList> groupList = new List<SystemGroupList>();

            if (e.NewValue == CheckState.Checked)
            {
                if (e.Index > 15)
                {
                    groupList = GlobalService.ExtraSystemGroupList.Where(x => x.Group == selectedItem.Trim()).ToList();

                    foreach (SystemGroupList item in groupList)
                        if (!_userList.Contains(_userList.Find(name => name.User == item.User)))
                            if (item.User != GlobalService.User)
                                _userList.Add(new UserList { User = item.User, DepartmentCode = "", DivisionCode = "", Division = item.Division });
                }
                else
                {
                    userList = GlobalService.AllUserList.Where(x => x.Division == selectedItem.Trim()).ToList();

                    foreach (UserList item in userList)
                        if (!_userList.Contains(_userList.Find(name => name.User == item.User)))
                            if (item.User != GlobalService.User)
                                _userList.Add(new UserList { User = item.User, DepartmentCode = item.DepartmentCode, DivisionCode = item.DivisionCode, Division = item.Division });
                }
            }
            else
            {
                _userList = new List<UserList>();

                foreach (int index in ckblbGroup.CheckedIndices)
                {
                    if (index == e.Index)
                        continue;

                    string reloadItem = ckblbGroup.Items[index].ToString();

                    if (index > 15)
                    {
                        groupList = GlobalService.ExtraSystemGroupList.Where(x => x.Group == reloadItem.Trim()).ToList();

                        foreach (SystemGroupList item in groupList)
                            if (!_userList.Contains(_userList.Find(name => name.User == item.User)))
                                if (item.User != GlobalService.User)
                                    _userList.Add(new UserList { User = item.User, DepartmentCode = "", DivisionCode = "", Division = item.Division });
                    }
                    else
                    {
                        userList = GlobalService.AllUserList.Where(x => x.Division == reloadItem.Trim()).ToList();

                        foreach (UserList item in userList)
                            if (!_userList.Contains(_userList.Find(name => name.User == item.User)))
                                if (item.User != GlobalService.User)
                                    _userList.Add(new UserList { User = item.User, DepartmentCode = item.DepartmentCode, DivisionCode = item.DivisionCode, Division = item.Division });
                    }
                }
            }

            _userList = _userList.Distinct().ToList();

            foreach (UserList item in _userList)
                dgvUsers.Rows.Add("True", item.User, item.Division);*/
        }

        private void dgvGroup_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dgvGroup.SelectedRows == null)
                    return;

                if (_selectedGroup == dgvGroup.SelectedRows[0].Cells[0].Value.ToString())
                    return;

                dgvUsers.Rows.Clear();

                _selectedGroup = dgvGroup.SelectedRows[0].Cells[0].Value.ToString();

                pnlGroup.Enabled = true;

                lblSelectedGroup.Text = "Group: " + _selectedGroup;

                _globalList = new List<UserGlobalList>();

                List<string> memberList = new List<string>();

                string query = string.Format("select g_member from TB_CUSTOM_GROUP where g_name = N'{0}' and g_member != '-' and g_owner = N'{1}'", _selectedGroup, GlobalService.User);
                using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
                {
                    while (reader.Read())
                        memberList.Add(reader.GetString(0).Trim());
                }

                foreach (string member in memberList)
                {
                    string division = "";
                    string loc = "";

                    if(UserUtil.IsCnMember(member.Trim()))
                    {
                        division = UserUtil.GetCnDepartment(member.Trim());
                        loc = "CN";
                    }
                    else if(UserUtil.IsJpMember(member.Trim()))
                    {
                        division = UserUtil.GetJpUserDepartment(member.Trim());
                        loc = "Jp";
                    }
                    else if (UserUtil.IsVnMember(member.Trim()))
                    {
                        division = UserUtil.GetVnDepartment(member.Trim());
                        loc = "Vn";
                    }
                    else
                    {
                        division = UserUtil.GetHKDivision(member.Trim());
                        loc = "Hk";
                    }

                    _globalList.Add(new UserGlobalList { Name = member, Department = division, Location = loc });
                }

                foreach (UserGlobalList item in _globalList)
                {
                    dgvUsers.Rows.Add("True", item.Name, item.Department, item.Location);
                }

                foreach (int i in ckblbGroup.CheckedIndices)
                    ckblbGroup.SetItemCheckState(i, CheckState.Unchecked);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> queryList = new List<string>();

            string delText = string.Format("delete from TB_CUSTOM_GROUP where g_name = N'{0}' and g_owner = N'{1}'", _selectedGroup, GlobalService.User);
            queryList.Add(delText);

            string ownerText = string.Format("insert into TB_CUSTOM_GROUP (g_name, g_owner, g_member) values (N'{0}', N'{1}', N'{2}')", _selectedGroup, GlobalService.User, "-");
            queryList.Add(ownerText);

            GlobalService.CustomGroupList.RemoveAll(x => x.Group == _selectedGroup);

            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                string isChecked = row.Cells[0].FormattedValue.ToString();
                string name = row.Cells[1].Value.ToString();
                string division = row.Cells[2].Value.ToString();

                if (isChecked == "True")
                {
                    string text = string.Format("insert into TB_CUSTOM_GROUP (g_name, g_owner, g_member) values (N'{0}', N'{1}', N'{2}')", _selectedGroup, GlobalService.User, name);
                    queryList.Add(text);

                    GlobalService.CustomGroupList.Add(new CustomGroupList { Group = _selectedGroup, Member = name, Division = division });
                }
            }

            foreach (string text in queryList)
                DataService.GetInstance().ExecuteNonQuery(text);

            MessageBox.Show("Record has been saved.");

            this.LoadCustomGroup();
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            //GlobalService.CustomGroupList = GroupUtil.CustomGroupList(GlobalService.User);

            this.LoadCustomGroup();
        }

        private void tsbtnNew_Click(object sender, EventArgs e)
        {
            NewGroupForm form = new NewGroupForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                dgvGroup.Rows.Add(GlobalService.Group, "");

            }
        }

        private void tsbtnRename_Click(object sender, EventArgs e)
        {

        }

        private void tsbtnDelete_Click(object sender, EventArgs e)
        {
            string selectedGroup = dgvGroup.SelectedRows[0].Cells[0].Value.ToString();

            dgvGroup.Rows.Remove(dgvGroup.SelectedRows[0]);

            //GlobalService.CustomGroupList.Remove(GlobalService.CustomGroupList.Find(x => x.Group == selectedGroup));

            string text = string.Format("delete from TB_CUSTOM_GROUP where g_name = N'{0}' and g_owner = N'{1}'", selectedGroup, GlobalService.User);
            //string query = "insert into LTB_QUERY ([q_query]) values (@text)";

            DataService.GetInstance().ExecuteNonQuery(text);
        }

        private void dgvGroup_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /*int rowIndex = dgvGroup.Rows.Count - 1;

            dgvGroup.ReadOnly = true;

            dgvGroup.Rows[rowIndex].Cells[1].Value = dgvGroup.Rows[rowIndex].Cells[0].Value;*/

            
        }

        private void ckbCheckall_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUsers.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                cell.Value = ckbCheckall.Checked ? "True" : "False";
            }
        }

        private void SearchData2()
        {
            for (int i = dgvUsers.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dgvUsers.Rows[i];

                string isChecked = row.Cells[0].FormattedValue.ToString();
                string name = row.Cells[1].Value.ToString();
                string division = row.Cells[2].Value.ToString();
                string location = row.Cells[3].Value.ToString();

                if (isChecked == "True")
                    if (!_globalList.Contains(_globalList.Find(x => x.Name == name)))
                        _globalList.Add(new UserGlobalList { Name = name, Department = division, Location = location });
                    else
                        continue;
                else
                    _globalList.RemoveAll(x => x.Name == name);
            }

            dgvUsers.Rows.Clear();

            _globalList = _globalList.Distinct().ToList();

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                foreach (UserGlobalList checkedItem in _globalList)
                    dgvUsers.Rows.Add("True", checkedItem.Name, checkedItem.Department, checkedItem.Location);

                switch (_mode)
                {
                    case "hk":
                        List<UserList> userList = GlobalService.AllUserList.Where(name => name.User.Contains(txtSearch.Text.Substring(0, 1).ToUpper() + txtSearch.Text.Substring(1).ToLower()) || name.Division.Contains(txtSearch.Text.ToUpper())).ToList();

                        foreach (UserList item in userList)
                        {
                            if (!_globalList.Contains(_globalList.Find(x => x.Name == item.User)))
                                if (item.User != GlobalService.User)
                                    dgvUsers.Rows.Add("False", item.User, item.Division, "HK");
                        }
                        break;

                    case "jp":
                        List<UserJpList> jplist = GlobalService.JpUserList.Where(name => name.Name.Contains(txtSearch.Text.Substring(0, 1).ToUpper() + txtSearch.Text.Substring(1).ToLower()) || name.Department.Contains(txtSearch.Text.ToUpper())).ToList();

                        foreach (UserJpList item in jplist)
                        {
                            if (!_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                dgvUsers.Rows.Add("False", item.Name, item.Department, "JP");
                        }
                        break;

                    case "cn":
                        List<UserCnList> cnlist = GlobalService.CnUserList.Where(name => name.Name.Contains(txtSearch.Text.Substring(0, 1).ToLower() + txtSearch.Text.Substring(1).ToLower()) || name.Department.Contains(txtSearch.Text.ToUpper())).ToList();

                        Debug.WriteLine(txtSearch.Text.Substring(0, 1).ToUpper() + txtSearch.Text.Substring(1));
                        foreach (UserCnList item in cnlist)
                        {
                            if (!_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                dgvUsers.Rows.Add("False", item.Name, item.Department, "CN");
                        }
                        break;


                    case "vn":
                        List<UserVnList> vnlist = GlobalService.VnUserList.Where(name => name.Name.Contains(txtSearch.Text.Substring(0, 1).ToUpper() + txtSearch.Text.Substring(1).ToLower()) || name.Department.Contains(txtSearch.Text.ToUpper())).ToList();

                        foreach (UserVnList item in vnlist)
                        {
                            if (!_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                dgvUsers.Rows.Add("False", item.Name, item.Department, "VN");
                        }
                        break;
                }
            }
            else
                MessageBox.Show("Please input name to search.");
        }

        private void SearchData()
        {
            //dgvUsers.Rows.Clear();

            for (int i = dgvUsers.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dgvUsers.Rows[i];

                string isChecked = row.Cells[0].FormattedValue.ToString();
                string name = row.Cells[1].Value.ToString();
                string division = row.Cells[2].Value.ToString();

                if (isChecked == "True")
                    if (!_userList.Contains(_userList.Find(n => n.User == name)))
                        _userList.Add(new UserList { User = name, Division = division });
                    else
                        continue;
                else
                    _userList.RemoveAll(x => x.User == name);
            }

            dgvUsers.Rows.Clear();

            _userList = _userList.Distinct().ToList();

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                List<UserList> userList = GlobalService.AllUserList.Where(name => name.User.Contains(txtSearch.Text.Substring(0, 1).ToUpper() + txtSearch.Text.Substring(1)) ||
                    name.Division.Contains(txtSearch.Text.ToUpper())).ToList();

                foreach (UserList checkeditem in _userList)
                    dgvUsers.Rows.Add("True", checkeditem.User, checkeditem.Division);

                foreach (UserList item in userList)
                {
                    if (!_userList.Contains(_userList.Find(name => name.User == item.User)))
                        if (item.User != GlobalService.User)
                            dgvUsers.Rows.Add("False", item.User, item.Division);
                }
            }
            else
            {
                MessageBox.Show("Please input name to search.");
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchData2();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchData2();
        }
    }
}
