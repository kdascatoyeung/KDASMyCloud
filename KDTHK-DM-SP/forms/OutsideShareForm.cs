using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using KDTHK_DM_SP.utils;
using KDTHK_DM_SP.lists;
using KDTHK_DM_SP.services;
using CustomUtil.utils.buffer;

namespace KDTHK_DM_SP.forms
{
    public partial class OutsideShareForm : Form
    {
        List<string> _pathList;

        public OutsideShareForm(List<string> pathList)
        {
            InitializeComponent();

            BufferUtil.DoubleBuffered(dgvUser, true);

            _pathList = pathList;

            InitializeComboBox();

            dgvUser.Rows.Clear();

            foreach (ContactList item in GlobalService.ContactList)
                dgvUser.Rows.Add("False", item.Staff, item.Company, item.Email);
        }

        private void InitializeComboBox()
        {
            cbCompany.Items.Add("All");

            foreach (ContactList clist in GlobalService.ContactList)
                if (!cbCompany.Items.Contains(clist.Company))
                    cbCompany.Items.Add(clist.Company);

            cbCompany.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContactUtil.DisplayGlobalAddressList();
        }

        private void SearchData(string staff, string company)
        {
            dgvUser.Rows.Clear();

            List<ContactList> list = company == "All" ? GlobalService.ContactList.Where(x => x.Staff.Contains(txtName.Text)).ToList() : GlobalService.ContactList.Where(x => x.Staff.Contains(txtName.Text) && x.Company == cbCompany.SelectedItem.ToString()).ToList();

            foreach (ContactList item in list)
                dgvUser.Rows.Add("False", item.Staff, item.Company, item.Email);
        }

        private void cbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SearchData(txtName.Text, cbCompany.SelectedItem.ToString());
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SearchData(txtName.Text, cbCompany.SelectedItem.ToString());
        }

        private void ckbCheckall_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUser.Rows)
            {
                DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)row.Cells[0];
                cell.Value = ckbCheckall.Checked ? "True" : "False";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvUser.Rows)
            {
                string check = row.Cells[0].FormattedValue.ToString();

                if (check == "True")
                {
                    string staff = row.Cells[1].Value.ToString();

                    foreach (string path in _pathList)
                    {
                        string query = string.Format("insert into TB_OUT_SHARED (os_path, os_from, os_shared) values (N'{0}', N'{1}', N'{2}')", path, GlobalService.User, staff);
                        DataService.GetInstance().ExecuteNonQuery(query);
                    }
                }
            }
        }
    }
}
