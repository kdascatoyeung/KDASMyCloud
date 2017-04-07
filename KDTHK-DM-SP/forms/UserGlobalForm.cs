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
using System.Diagnostics;
using KDTHK_DM_SP.utils;

namespace KDTHK_DM_SP.forms
{
    public partial class UserGlobalForm : Form
    {
        string _mode = "hk";

        List<UserList> _userlist = new List<UserList>();

        List<UserGlobalList> _globalList = new List<UserGlobalList>();

        public UserGlobalForm()
        {
            InitializeComponent();

            GlobalService.SelectedGlobalUserList = new List<UserGlobalList>();

            LoadGroup(_mode);
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

        private void SearchData()
        {
            for (int i = dgvUser.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dgvUser.Rows[i];

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

            dgvUser.Rows.Clear();

            _globalList = _globalList.Distinct().ToList();

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                foreach (UserGlobalList checkedItem in _globalList)
                    dgvUser.Rows.Add("True", checkedItem.Name, checkedItem.Department, checkedItem.Location);

                switch (_mode)
                {
                    case "hk":
                        List<UserList> userList = GlobalService.AllUserList.Where(name => name.User.Contains(txtSearch.Text.Substring(0, 1).ToUpper() + txtSearch.Text.Substring(1).ToLower()) || name.Division.Contains(txtSearch.Text.ToUpper())).ToList();

                        foreach (UserList item in userList)
                        {
                            if (!_globalList.Contains(_globalList.Find(x => x.Name == item.User)))
                                if (item.User != GlobalService.User)
                                    dgvUser.Rows.Add("False", item.User, item.Division, "HK");
                        }
                        break;

                    case "jp":
                        List<UserJpList> jplist = GlobalService.JpUserList.Where(name => name.Name.Contains(txtSearch.Text.Substring(0, 1).ToUpper() + txtSearch.Text.Substring(1).ToLower()) || name.Department.Contains(txtSearch.Text.ToUpper())).ToList();

                        foreach (UserJpList item in jplist)
                        {
                            if (!_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                dgvUser.Rows.Add("False", item.Name, item.Department, "JP");
                        }
                        break;

                    case "cn":
                        List<UserCnList> cnlist = GlobalService.CnUserList.Where(name => name.Name.Contains(txtSearch.Text.Substring(0, 1).ToLower() + txtSearch.Text.Substring(1).ToLower()) || name.Department.Contains(txtSearch.Text.ToUpper())).ToList();

                        Debug.WriteLine(txtSearch.Text.Substring(0, 1).ToUpper() + txtSearch.Text.Substring(1));
                        foreach (UserCnList item in cnlist)
                        {
                            if (!_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                dgvUser.Rows.Add("False", item.Name, item.Department, "CN");
                        }
                        break;


                    case "vn":
                        List<UserVnList> vnlist = GlobalService.VnUserList.Where(name => name.Name.Contains(txtSearch.Text.Substring(0, 1).ToUpper() + txtSearch.Text.Substring(1).ToLower()) || name.Department.Contains(txtSearch.Text.ToUpper())).ToList();

                        foreach (UserVnList item in vnlist)
                        {
                            if (!_globalList.Contains(_globalList.Find(x => x.Name == item.Name)))
                                dgvUser.Rows.Add("False", item.Name, item.Department, "VN");
                        }
                        break;
                }
            }
            else
                MessageBox.Show("Please input name to search.");
        }

        private void ckblbGroup_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = dgvUser.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dgvUser.Rows[i];

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

            dgvUser.Rows.Clear();

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
                                    {
                                        string loc = UserUtil.IsJpMember(item.Member.Trim()) ? "JP"
                                            : UserUtil.IsCnMember(item.Member.Trim()) ? "CN"
                                            : UserUtil.IsVnMember(item.Member.Trim()) ? "VN" : "HK";

                                        _globalList.Add(new UserGlobalList { Name = item.Member, Department = item.Division, Location = loc });
                                    }
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

                            if(selectedItem=="經營管理科")
                                _globalList.Add(new UserGlobalList { Name = "Lai King Ho(黎景豪,Ken)", Department = "經營管理科", Location = "HK" });

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
                //_globalList = new List<UserGlobalList>();

                //foreach (int index in ckblbGroup.CheckedIndices)
                //{
                    //if (index == e.Index)
                       // continue;

                    string reloadItem = ckblbGroup.Items[e.Index].ToString().Trim();

                    switch (_mode)
                    {
                        case "hk":
                            if (e.Index > 16)
                            {
                                customGroupList = GlobalService.CustomGroupList.Where(x => x.Group == reloadItem.Trim()).ToList();

                                foreach (CustomGroupList item in customGroupList)
                                    if (_globalList.Contains(_globalList.Find(x => x.Name == item.Member.Trim())))
                                        _globalList.RemoveAll(x => x.Name == item.Member.Trim());
                            }
                            else if (e.Index > 13 && e.Index <= 16)
                            {
                                systemGroupList = GlobalService.ExtraSystemGroupList.Where(x => x.Group == reloadItem.Trim()).ToList();

                                foreach (SystemGroupList item in systemGroupList)
                                    if (_globalList.Contains(_globalList.Find(x => x.Name.Trim() == item.User.Trim())))
                                        _globalList.RemoveAll(x => x.Name.Trim() == item.User.Trim());
                            }
                            else
                            {
                                hklist = GlobalService.AllUserList.Where(x => x.Division == reloadItem.Trim()).ToList();

                                foreach (UserList item in hklist)
                                {
                                    if (_globalList.Contains(_globalList.Find(x => x.Name == item.User)))
                                        _globalList.RemoveAll(x => x.Name == item.User.Trim());
                                }

                                if (selectedItem == "經營管理科")
                                    _globalList.RemoveAll(x => x.Name == "Lai King Ho(黎景豪,Ken)" && x.Department == "經營管理科");
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
            //}

            _globalList = _globalList.Distinct().ToList();

            foreach (UserGlobalList item in _globalList)
                dgvUser.Rows.Add("True", item.Name, item.Department, item.Location);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUser.Rows)
            {
                string isChecked = row.Cells[0].FormattedValue.ToString();
                string name = row.Cells[1].Value.ToString().Trim();
                string department = row.Cells[2].Value.ToString().Trim();
                string location = row.Cells[3].Value.ToString().Trim();

                if (isChecked == "True")
                    GlobalService.SelectedGlobalUserList.Add(new UserGlobalList { Name = name, Department = department, Location = location });
            }

            Debug.WriteLine(GlobalService.SelectedGlobalUserList.Count);
            DialogResult = DialogResult.OK;
        }

        private void ckbCheckall_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUser.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                cell.Value = ckbCheckall.Checked ? "True" : "False";
            }
        }
    }
}
