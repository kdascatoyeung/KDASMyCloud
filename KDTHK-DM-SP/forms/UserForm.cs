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

namespace KDTHK_DM_SP.forms
{
    public partial class UserForm : Form
    {
        List<UserList> _userList = new List<UserList>();

        public UserForm()
        {
            InitializeComponent();

            this.LoadGroup();

            GlobalService.SelectedCnUser = new List<string>();
            GlobalService.SelectedCnUserList = new List<UserCnList>();
        }

        private void LoadGroup()
        {
            foreach (string item in GlobalService.SystemGroupList)
                if (item != "Custom")
                    ckblbGroup.Items.Add(item);

            foreach (CustomGroupList item in GlobalService.CustomGroupList)
                if (!ckblbGroup.Items.Contains(item.Group))
                    ckblbGroup.Items.Add(item.Group);
        }

        private void SearchData()
        {
            for (int i = dgvUser.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dgvUser.Rows[i];

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

            dgvUser.Rows.Clear();

            _userList = _userList.Distinct().ToList();

            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                List<UserList> userList = GlobalService.AllUserList.Where(name => name.User.Contains(txtSearch.Text.Substring(0, 1).ToUpper() + txtSearch.Text.Substring(1).ToLower()) ||
                    name.Division.Contains(txtSearch.Text.ToUpper())).ToList();

                foreach (UserList checkeditem in _userList)
                    dgvUser.Rows.Add("True", checkeditem.User, checkeditem.Division, "HK");

                foreach (UserList item in userList)
                {
                    if (!_userList.Contains(_userList.Find(name => name.User == item.User)))
                        if (item.User != GlobalService.User)
                            dgvUser.Rows.Add("False", item.User, item.Division, "HK");
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
                SearchData();   
            }
        }

        private void ckblbGroup_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            dgvUser.Rows.Clear();

            ckbCheckall.Checked = true;

            string selecteditem = ckblbGroup.Items[e.Index].ToString().Trim();

            List<UserList> userList = new List<UserList>();
            List<SystemGroupList> systemGroupList = new List<SystemGroupList>();
            List<CustomGroupList> customGroupList = new List<CustomGroupList>();

            if (e.NewValue == CheckState.Checked)
            {
                if (e.Index > 17)//Custom Group
                {
                    customGroupList = GlobalService.CustomGroupList.Where(x => x.Group == selecteditem.Trim()).ToList();

                    foreach (CustomGroupList item in customGroupList)
                        if (!_userList.Contains(_userList.Find(name => name.User.Trim() == item.Member.Trim())))
                            if (item.Member.Trim() != GlobalService.User)
                                _userList.Add(new UserList { User = item.Member, DepartmentCode = "", DivisionCode = "", Division = item.Division });
                }
                else if (e.Index > 14 && e.Index <= 17)//KDTHK 係責, 科責, 部責
                {
                    systemGroupList = GlobalService.ExtraSystemGroupList.Where(x => x.Group == selecteditem.Trim()).ToList();

                    foreach (SystemGroupList item in systemGroupList)
                        if (!_userList.Contains(_userList.Find(name => name.User == item.User)))
                            if (item.User != GlobalService.User)
                                _userList.Add(new UserList { User = item.User, DepartmentCode = "", DivisionCode = "", Division = item.Division });
                }
                else
                {
                    userList = GlobalService.AllUserList.Where(x => x.Division == selecteditem.Trim()).ToList();

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

                    if (index > 17)
                    {
                        customGroupList = GlobalService.CustomGroupList.Where(x => x.Group == reloadItem.Trim()).ToList();

                        foreach (CustomGroupList item in customGroupList)
                            if (!_userList.Contains(_userList.Find(name => name.User == item.Member)))
                                if (item.Member != GlobalService.User)
                                    _userList.Add(new UserList { User = item.Member, DepartmentCode = "", DivisionCode = "", Division = item.Division });
                    }
                    else if (index > 14 && index <= 17)
                    {
                        systemGroupList = GlobalService.ExtraSystemGroupList.Where(x => x.Group == reloadItem.Trim()).ToList();

                        foreach (SystemGroupList item in systemGroupList)
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

            if (GlobalService.SelectedCnUserList.Count > 0)
            {
                List<string> list = new List<string>();

                foreach (DataGridViewRow row in dgvUser.Rows)
                    list.Add(row.Cells[0].Value.ToString().Trim());

                foreach (UserCnList item in GlobalService.SelectedCnUserList)
                    if (!list.Contains(list.Find(x => x == item.Name)))
                        dgvUser.Rows.Add("True", item.Name, item.Department, "CN");
            }

            foreach (UserList item in _userList)
                dgvUser.Rows.Add("True", item.User, item.Division, "HK");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            List<string> cnlist = new List<string>();

            foreach (DataGridViewRow row in dgvUser.Rows)
            {
                string isChecked = row.Cells[0].FormattedValue.ToString();
                string user = row.Cells[1].Value.ToString();
                string loc = row.Cells[3].Value.ToString().Trim();

                if (isChecked == "True")
                {
                    if (loc == "HK")
                        list.Add(user);
                    else
                        cnlist.Add(user);
                }
            }

            GlobalService.SelectedCnUser = cnlist;
            GlobalService.SelectedUserList = list;

            this.DialogResult = DialogResult.OK;
        }

        private void ckbCheckall_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUser.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                cell.Value = ckbCheckall.Checked ? "True" : "False";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        private void btnCn_Click(object sender, EventArgs e)
        {
            /*UserCnForm form = new UserCnForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (GlobalService.SelectedCnUserList.Count > 0)
                {
                    List<string> list = new List<string>();

                    foreach (DataGridViewRow row in dgvUser.Rows)
                        list.Add(row.Cells[1].Value.ToString().Trim());

                    foreach (UserCnList item in GlobalService.SelectedCnUserList)
                        if (!list.Contains(list.Find(x => x == item.Name)))
                            dgvUser.Rows.Add("True", item.Name, item.Department, "CN");
                }
            }*/
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Clear records?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    _userList = new List<UserList>();
                    dgvUser.Rows.Clear();
                    GlobalService.SelectedCnUserList = new List<UserCnList>();

                    for (int i = 0; i < ckblbGroup.Items.Count; i++)
                        ckblbGroup.SetItemCheckState(i, CheckState.Unchecked);

                    break;

                case DialogResult.No:
                    break;
            }
        }

        private void btnJp_Click(object sender, EventArgs e)
        {
           
        }

        private void btnVn_Click(object sender, EventArgs e)
        {
            /*UserVnForm form = new UserVnForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (GlobalService.SelectedVnUserList.Count > 0)
                {
                    List<string> list = new List<string>();

                    foreach (DataGridViewRow row in dgvUser.Rows)
                        list.Add(row.Cells[1].Value.ToString().Trim());

                    foreach (UserVnList item in GlobalService.SelectedVnUserList)
                        if (!list.Contains(list.Find(x => x == item.Name)))
                            dgvUser.Rows.Add("True", item.Name, item.Department, "VN");
                }
            }*/
        }
    }
}
