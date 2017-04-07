using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.xmls;
using System.IO;
using System.Xml.Serialization;
using KDTHK_DM_SP.services;
using System.Diagnostics;
using KDTHK_DM_SP.utils;

namespace KDTHK_DM_SP.views
{
    public partial class ApplicationView : UserControl
    {
        string _category = "";

        List<AppsInfo> _apps = new List<AppsInfo>();

        string userfilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "KDTHK");

        public ApplicationView()
        {
            InitializeComponent();

            LoadData("");
            //this.InitializeApps();

            //this.LoadApps();
        }

        private void LoadData(string category)
        {
            dgvAppList.Rows.Clear();

            string query = string.Format("select f_category, f_name, f_path, f_description from TB_APPLICATION where f_staff = N'{0}' and f_category like '%{1}%'", GlobalService.User, category);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string cat = reader.GetString(0).Trim();
                    string name = reader.GetString(1).Trim();
                    string path = reader.GetString(2).Trim();
                    string description = reader.GetString(3).Trim();

                    dgvAppList.Rows.Add(cat, name, description, path);
                }
            }
        }

        public FileInfo AppsFile
        {
            get { return new FileInfo(Path.Combine(userfilePath, "apps.xml")); }
        }

        private void InitializeApps()
        {
            dgvAppList.Rows.Clear();

            List<AppsInfo> lst = new List<AppsInfo>();

            foreach (AppsInfo app in GlobalService.AppsList)
                lst.Add(new AppsInfo(app.FileName, app.FilePath, app.Description, app.LastAccess, app.Category));

            XmlSerializer xmls = new XmlSerializer(lst.GetType());

            if (AppsFile.Exists)
                AppsFile.Delete();

            using (Stream s = AppsFile.OpenWrite())
            {
                xmls.Serialize(s, lst);
                s.Close();
            }
        }

        private void LoadApps()
        {
            if (AppsFile.Exists)
            {
                dgvAppList.Rows.Clear();

                List<AppsInfo> lst = new List<AppsInfo>();

                XmlSerializer xml = new XmlSerializer(lst.GetType());

                using (Stream s = AppsFile.OpenRead())
                    lst = xml.Deserialize(s) as List<AppsInfo>;

                foreach (AppsInfo info in lst)
                    _apps.Add(new AppsInfo { FileName = info.FileName, FilePath = info.FilePath, Description = info.Description, LastAccess = info.LastAccess, Category = info.Category });

                this.PlaceApps(_category);
            }
        }

        private void PlaceApps(string source)
        {
            dgvAppList.Rows.Clear();

            List<AppsInfo> appList = source != "" ? _apps.Where(x => x.Category == source).ToList() : _apps;

            foreach (AppsInfo app in appList)
            {
                string fileName = app.FileName;
                string filePath = app.FilePath;
                string description = app.Description;
                string lastAccess = app.LastAccess;
                string category = app.Category;

                dgvAppList.Rows.Add(category, fileName, description, filePath, lastAccess);

                dgvAppList.Sort(dgvAppList.Columns[4], ListSortDirection.Descending);
            }
        }

        private void LabelClicked(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            string tag = label.Tag.ToString();

            foreach (Control control in pnlMenu.Controls)
            {
                if (control is Label)
                {
                    Label lbl = (Label)control;
                    lbl.BackColor = SystemColors.ControlLightLight;
                    lbl.ForeColor = Color.DimGray;
                    lbl.Font = new Font("Calibri", lbl.Font.Size, FontStyle.Regular);
                }
            }

            label.BackColor = Color.WhiteSmoke;
            label.ForeColor = Color.DodgerBlue;
            label.Font = new Font("Calibri", label.Font.Size, FontStyle.Bold);

            _category = tag == "application" ? "Application"
                : tag == "tool" ? "Tools"
                : tag == "form" ? "Forms"
                : tag == "others" ? "Others" : "";

            //PlaceApps(_category);
            LoadData(_category);
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            /*_apps = new List<AppsInfo>();

            GlobalService.AppsList = SystemUtil.AppsList();

            this.InitializeApps();

            this.LoadApps();*/

            LoadData(_category);
        }

        private void dgvAppList_DoubleClick(object sender, EventArgs e)
        {
            if (dgvAppList.SelectedRows == null)
                return;

            string path = dgvAppList.SelectedRows[0].Cells[3].Value.ToString().Trim();

            if (!File.Exists(path))
                MessageBox.Show("System cannot find specified file. Please contact your administrator.");
            else
                Process.Start(path);

            if (path.Contains("'"))
                path = path.Replace("'", "''");

            string query = string.Format("update TB_APPLICATION set f_lastaccess = '{0}' where f_path = N'{1}' and f_staff = N'{2}'", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), path, GlobalService.User.Trim());
            DataService.GetInstance().ExecuteNonQuery(query);
        }

        private void tsbtnOpen_Click(object sender, EventArgs e)
        {

        }
    }
}
