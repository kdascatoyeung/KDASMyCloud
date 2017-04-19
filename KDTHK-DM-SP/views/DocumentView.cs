using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.utils;
using KDTHK_DM_SP.services;
using System.Collections;
using KDTHK_DM_SP.lists;
using System.Diagnostics;
using System.IO;
using KDTHK_DM_SP.forms;
using Common;
using System.Runtime.InteropServices;
using System.Data.SqlServerCe;
using CustomUtil.utils.buffer;
using KDTHK_DM_SP.backup;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices;

namespace KDTHK_DM_SP.views
{
    public partial class DocumentView : UserControl
    {
        //public event EventHandler GetFileCountEvent;

        public event EventHandler GetNoticeEvent;

        string _mode = "";

        string _viewMode = "";

        string dialogCancel = "";

        public readonly Guid Downloads = new Guid("374DE290-123F-4565-9164-39C4925E467B");

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        static extern int SHGetKnownFolderPath([MarshalAs(UnmanagedType.LPStruct)]Guid rfid, uint dwFlags, IntPtr hToken, out string pszPath);

        public DocumentView()
        {
            InitializeComponent();

            TreeviewUtil.LoadPersonalFolder(tvFolder, GlobalService.User);

            BufferUtil.DoubleBuffered(dgvDoc, true);

            GlobalService.MemoryList = new List<string>();

            txtPath.Text = @"\Documents";

            this.LoadExternalStorage();

            Stopwatch sw = new Stopwatch();

            sw.Start();
            GlobalService.RootTable = RootUtil.RootDataTable();
            this.LoadData(GlobalService.RootTable, @"\Documents", "");
            sw.Stop();
            //Debug.WriteLine("Write to Datagrid: " + sw.Elapsed);

            splitContainer1.SplitterDistance = 180;
            Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
            tsbtnNewFolder.Enabled = _mode == "favorite" || _mode == "disc" ? false : true;
            tsbtnView.Enabled = _mode == "favorite" || _mode == "disc" ? false : true;
            tsbtnAttachment.Enabled = GlobalService.AttachmentList.Count > 0 ? true : false;
            btnPrevious.BackgroundImage = btnPrevious.Enabled ? Properties.Resources.arrow_180 : Properties.Resources.arrow_180_gray;
        }

        private void LoadData(DataTable sourceTable, string sourcePath, string mode)
        {
            try
            {
                DataRow[] dataRow = (from row in sourceTable.AsEnumerable()
                                     where mode == "" ? row.RowState != DataRowState.Deleted && row.Field<string>("vpath").StartsWith(sourcePath)
                                     : mode == "owned" ? row.RowState != DataRowState.Deleted && row.Field<string>("vpath").StartsWith(sourcePath) && row.Field<string>("fileowner") == GlobalService.User
                                     : row.RowState != DataRowState.Deleted && row.Field<string>("vpath").StartsWith(sourcePath) && row.Field<string>("shared") == GlobalService.User
                                     select row).ToArray();

                List<string> folderList = new List<string>();
                List<string> fileList = new List<string>();

                DataTable outputTable = new DataTable();
                outputTable.Columns.Add("img", typeof(Image));
                string[] headers = { "filename", "keyword", "modified", "shared", "owner", "read", "type", "path", "vpath", "delete" };
                foreach (string header in headers)
                    outputTable.Columns.Add(header);
                outputTable.Columns.Add("fav", typeof(Image));
                outputTable.Columns.Add("disc", typeof(Image));

                Debug.WriteLine("==================================");
                foreach (DataRow row in dataRow)
                {
                    string fileName = row.ItemArray[0].ToString().Trim();
                    string keyword = row.ItemArray[1].ToString().Trim();
                    string modified = row.ItemArray[2].ToString();
                    string access = row.ItemArray[3].ToString();
                    string owner = row.ItemArray[4].ToString().Trim();
                    string shared = row.ItemArray[5].ToString().Trim();
                    string path = row.ItemArray[6].ToString().Trim();
                    string vpath = row.ItemArray[7].ToString().Trim();
                    string count = row.ItemArray[8].ToString();
                    string favorite = row.ItemArray[9].ToString().Trim();
                    string disc = row.ItemArray[11].ToString().Trim();
                    string delete = row.ItemArray[12].ToString().Trim();

                    int sharedCount = 0;

                    if (shared != "-")
                    {
                        if (shared.Contains(";"))
                        {
                            string[] slist = shared.Split(';');
                            sharedCount = slist.Length;
                        }
                        else
                            sharedCount = 1;
                    }

                    Image icon = null;
                    string i_filename = "";
                    string i_keyword = "";
                    string i_modified = "";
                    //string i_access = "";
                    string i_owner = "";
                    string i_shared = "";
                    string i_path = "";
                    string i_vpath = "";
                    string i_count = "";
                    //string i_favorite = "";
                    //string i_disc = "";
                    string i_type = "";
                    string i_delete = "";

                    Image fav = null;
                    Image dis = null;

                    if (sourcePath != vpath)
                    {
                        string tmpPath = vpath.Replace(sourcePath, "").Substring(1);

                        //Debug.WriteLine("Source Path: " + sourcePath + "   Vpath: " + vpath);
                        //Debug.WriteLine("Tmp Path2: " + tmpPath);
                        if (tmpPath.Contains(@"\"))
                        {
                            tmpPath = tmpPath.Substring(0, tmpPath.IndexOf(@"\"));

                            //Debug.WriteLine("Tmp Path1: " + tmpPath);
                            if (!folderList.Contains(tmpPath))
                            {
                                folderList.Add(tmpPath);

                                i_type = "folder";
                                icon = Properties.Resources.folder_open;
                                i_filename = tmpPath;
                                i_vpath = sourcePath + @"\" + tmpPath;
                                i_delete = "";
                                dis = DataUtil.IsAllFileDisc(GlobalService.RootTable, i_vpath) ? Properties.Resources.status_away : Properties.Resources.status;
                                fav = DataUtil.IsAllFileFavorite2(GlobalService.RootTable, i_vpath) ? Properties.Resources.star_16 : Properties.Resources.star_gray_16;
                            }
                            else
                                continue;
                        }

                        else if (folderList.Contains(tmpPath))
                            continue;

                        else
                        {
                            folderList.Add(tmpPath);

                            i_type = "folder";
                            icon = Properties.Resources.folder_open;
                            i_filename = tmpPath;
                            i_vpath = sourcePath + @"\" + tmpPath;
                            i_delete = "";
                            dis = DataUtil.IsAllFileDisc(GlobalService.RootTable, i_vpath) ? Properties.Resources.status_away : Properties.Resources.status;
                            fav = DataUtil.IsAllFileFavorite2(GlobalService.RootTable, i_vpath) ? Properties.Resources.star_16 : Properties.Resources.star_gray_16;
                        }
                    }
                    else
                    {
                        if (fileList.Contains(path))
                            continue;

                        fileList.Add(path);

                        Image imgFavorite = favorite == "True" ? Properties.Resources.star_16 : Properties.Resources.star_gray_16;

                        Image discStatus = disc == "False" ? Properties.Resources.status
                        : disc == "Pending" ? Properties.Resources.status_away : Properties.Resources.status_busy;

                        Image img;
                        string imgPath = path.ToLower();

                        if (imgPath.EndsWith(".xls") || imgPath.EndsWith(".xlsx") || imgPath.EndsWith(".xlsm") || imgPath.EndsWith(".csv"))
                            img = Properties.Resources.excel_16;
                        else if (imgPath.EndsWith(".doc") || imgPath.EndsWith(".docx"))
                            img = Properties.Resources.word_16;
                        else if (imgPath.EndsWith(".ppt") || imgPath.EndsWith(".pptx"))
                            img = Properties.Resources.powerpoint_16;
                        else if (imgPath.EndsWith(".png") || imgPath.EndsWith(".jpg") || imgPath.EndsWith(".gif") || imgPath.EndsWith(".tiff") || imgPath.EndsWith(".jpeg") || imgPath.EndsWith(".bmp") || imgPath.EndsWith(".tif"))
                            img = Properties.Resources.picture;
                        else if (imgPath.EndsWith(".pdf"))
                            img = Properties.Resources.pdf_16;
                        else if (imgPath.EndsWith(".txt"))
                            img = Properties.Resources.text;
                        else if (imgPath.EndsWith(".zip"))
                            img = Properties.Resources.zip_16;
                        else
                            img = Properties.Resources.windows_16;

                        i_type = "file";
                        icon = img;
                        i_count = count;
                        i_filename = fileName;
                        i_keyword = keyword;
                        i_modified = modified;
                        i_shared = sharedCount.ToString();
                        i_owner = owner;
                        i_path = path;
                        i_vpath = vpath;
                        i_delete = delete;

                        fav = imgFavorite;
                        dis = discStatus;
                    }

                    if (i_vpath.EndsWith(@"\"))
                        continue;
                    outputTable.Rows.Add(icon, i_filename, i_keyword, i_modified, i_shared, i_owner, i_count, i_type, i_path, i_vpath, i_delete, fav, dis);
                }

                /*foreach (string folder in GlobalService.TemporaryFolderList)
                {
                    Debug.WriteLine(txtPath.Text + "     " + folder);
                    if (!txtPath.Text.Contains(folder))
                        outputTable.Rows.Add(Properties.Resources.folder_open, folder.Substring(folder.LastIndexOf("\\") + 1), "", "", "", "", "", "newfolder", "", folder, "", Properties.Resources.star_gray_16, Properties.Resources.status);
                }*/

                outputTable.DefaultView.Sort = "type, filename asc";
                outputTable = outputTable.DefaultView.ToTable();

                dgvDoc.DataSource = outputTable;

                dgvDoc.Sort(dgvDoc.Columns[7], ListSortDirection.Descending);

                try
                {
                    dgvDoc.ClearSelection();

                    dgvDoc.Rows[GlobalService.SelectedIndex].Selected = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message + ex.StackTrace);
                }
                //this.CheckDisc();
            }
            catch (Exception ex)
            {
                ErrorBox box = new ErrorBox(ex.Message + ex.StackTrace);
                box.ShowDialog();
            }
        }

        private void LoadDocument(List<DocumentList> list)
        {
            dgvDoc.Rows.Clear();

            foreach (DocumentList item in list)
                dgvDoc.Rows.Add(item.Icon, item.Name, item.Keyword, item.Modified, item.Shared, item.Owner, item.Read, item.Type, item.Path, item.Vpath, item.Favorite, item.Status);

            List<KeyValuePair<DataGridViewColumn, bool>> sortedList = new List<KeyValuePair<DataGridViewColumn, bool>>();
            sortedList.Add(new KeyValuePair<DataGridViewColumn, bool>(dgvDoc.Columns[7], false));
            sortedList.Add(new KeyValuePair<DataGridViewColumn, bool>(dgvDoc.Columns[1], true));

            GridRowComparer comparer = new GridRowComparer(sortedList);
            dgvDoc.Sort(comparer);
        }

        private void LoadFavorite(DataTable sourceTable, string sourcePath, string mode)
        {
            _mode = "favorite";

            DataRow[] dataRow = (from row in sourceTable.AsEnumerable()
                                 where row.RowState != DataRowState.Deleted && row.Field<string>("favorite") == "True"
                                 select row).ToArray();

            List<string> folderList = new List<string>();
            List<string> fileList = new List<string>();

            DataTable outputTable = new DataTable();
            outputTable.Columns.Add("img", typeof(Image));
            string[] headers = { "filename", "keyword", "modified", "shared", "owner", "read", "type", "path", "vpath", "delete" };
            foreach (string header in headers)
                outputTable.Columns.Add(header);
            outputTable.Columns.Add("fav", typeof(Image));
            outputTable.Columns.Add("disc", typeof(Image));

            foreach (DataRow row in dataRow)
            {
                string fileName = row.ItemArray[0].ToString().Trim();
                string keyword = row.ItemArray[1].ToString().Trim();
                string modified = row.ItemArray[2].ToString();
                string access = row.ItemArray[3].ToString();
                string owner = row.ItemArray[4].ToString().Trim();
                string shared = row.ItemArray[5].ToString().Trim();
                string path = row.ItemArray[6].ToString().Trim();
                string vpath = row.ItemArray[7].ToString().Trim();
                string count = row.ItemArray[8].ToString();
                string favorite = row.ItemArray[9].ToString().Trim();
                string disc = row.ItemArray[11].ToString().Trim();
                string delete = row.ItemArray[12].ToString().Trim();

                Image discStatus = disc == "False" ? Properties.Resources.status
                    : disc == "Pending" ? Properties.Resources.status_away : Properties.Resources.status_busy;

                int sharedCount = 0;

                if (shared != "-")
                {
                    if (shared.Contains(";"))
                    {
                        string[] slist = shared.Split(';');
                        sharedCount = slist.Length;
                    }
                    else
                        sharedCount = 1;
                }

                Image icon = null;
                string i_filename = "";
                string i_keyword = "";
                string i_modified = "";
                //string i_access = "";
                string i_owner = "";
                string i_shared = "";
                string i_path = "";
                string i_vpath = "";
                string i_count = "";
                //string i_favorite = "";
                //string i_disc = "";
                string i_type = "";
                string i_delete = "";

                Image fav = null;
                Image dis = null;

                Image imgFavorite = favorite == "True" ? Properties.Resources.star_16 : Properties.Resources.star_gray_16;

                if (vpath.StartsWith(@"\" + UserUtil.HkItGroupCode()) || vpath.StartsWith(@"\" + GlobalService.Division) || vpath.StartsWith(@"\Common"))
                //if (vpath.StartsWith(@"\23600") || vpath.StartsWith(@"\" + GlobalService.Division) || vpath.StartsWith(@"\Common"))
                {
                    //sourcePath = vpath.StartsWith(@"\23600\")? sourcePath
                    //    :vpath.StartsWith(@"\23600") ? @"\Documents\23600"
                    sourcePath = vpath.StartsWith(@"\" + UserUtil.HkItGroupCode() + "\\") ? sourcePath
                        : vpath.StartsWith(@"\" + UserUtil.HkItGroupCode()) ? @"\Documents\" + UserUtil.HkItGroupCode()
                        : vpath.StartsWith(@"\" + GlobalService.Division + @"\") ? sourcePath
                        : vpath.StartsWith(@"\" + GlobalService.Division) ? @"\Documents\" + GlobalService.Division 
                        : vpath.StartsWith(@"\Common\")? sourcePath
                        : vpath.StartsWith(@"\Common") ? @"\Common" : sourcePath;

                    vpath = @"\Documents" + vpath;

                    if (sourcePath != vpath)
                    {
                        Debug.WriteLine("Source Path: " + sourcePath);
                        Debug.WriteLine("Vpath: " + vpath);

                        string tmpPath = vpath.Replace(sourcePath, "").Substring(1);

                        if (tmpPath.Contains(@"\"))
                        {
                            tmpPath = tmpPath.Substring(0, tmpPath.IndexOf(@"\"));

                            if (tmpPath == "Documents")
                                continue;

                            if (!folderList.Contains(tmpPath))
                            {
                                folderList.Add(tmpPath);

                                i_type = "folder";
                                icon = Properties.Resources.folder_open;
                                i_filename = tmpPath;
                                i_vpath = sourcePath + @"\" + tmpPath;
                                i_delete = "";
                                dis = DataUtil.IsAllFileDisc(GlobalService.RootTable, i_vpath) ? Properties.Resources.status_away : Properties.Resources.status;
                                fav = DataUtil.IsAllFileFavorite2(GlobalService.RootTable, i_vpath) ? Properties.Resources.star_16 : Properties.Resources.star_gray_16;

                                //dgvDoc.Rows.Add(Properties.Resources.folder_open, tmpPath, "", "", "", "", "", "folder", "", sourcePath + @"\" + tmpPath, imgFavorite, discStatus);
                            }
                            else
                                continue;
                        }

                        else if (folderList.Contains(tmpPath))
                            continue;

                        else
                        {
                            folderList.Add(tmpPath);

                            i_type = "folder";
                            icon = Properties.Resources.folder_open;
                            i_filename = tmpPath;
                            i_vpath = sourcePath + @"\" + tmpPath;
                            i_delete = "";
                            dis = DataUtil.IsAllFileDisc(GlobalService.RootTable, i_vpath) ? Properties.Resources.status_away : Properties.Resources.status;
                            fav = DataUtil.IsAllFileFavorite2(GlobalService.RootTable, i_vpath) ? Properties.Resources.star_16 : Properties.Resources.star_gray_16;

                            //dgvDoc.Rows.Add(Properties.Resources.folder_open, tmpPath, "", "", "", "", "", "folder", "", sourcePath + @"\" + tmpPath, imgFavorite, discStatus);
                        }
                    }
                    else
                    {
                        if (txtPath.Text == vpath)
                        {
                            if (fileList.Contains(path))
                                continue;

                            fileList.Add(path);

                            Image img;
                            string imgPath = path.ToLower();

                            if (imgPath.EndsWith(".xls") || imgPath.EndsWith(".xlsx") || imgPath.EndsWith(".xlsm") || imgPath.EndsWith(".csv"))
                                img = Properties.Resources.excel_16;
                            else if (imgPath.EndsWith(".doc") || imgPath.EndsWith(".docx"))
                                img = Properties.Resources.word_16;
                            else if (imgPath.EndsWith(".ppt") || imgPath.EndsWith(".pptx"))
                                img = Properties.Resources.powerpoint_16;
                            else if (imgPath.EndsWith(".png") || imgPath.EndsWith(".jpg") || imgPath.EndsWith(".gif") || imgPath.EndsWith(".tiff") || imgPath.EndsWith(".jpeg") || imgPath.EndsWith(".bmp") || imgPath.EndsWith(".tif"))
                                img = Properties.Resources.picture;
                            else if (imgPath.EndsWith(".pdf"))
                                img = Properties.Resources.pdf_16;
                            else if (imgPath.EndsWith(".txt"))
                                img = Properties.Resources.text;
                            else if (imgPath.EndsWith(".zip"))
                                img = Properties.Resources.zip_16;
                            else
                                img = Properties.Resources.windows_16;

                            i_type = "file";
                            icon = img;
                            i_count = count;
                            i_filename = fileName;
                            i_keyword = keyword;
                            i_modified = modified;
                            i_shared = sharedCount.ToString();
                            i_owner = owner;
                            i_path = path;
                            i_vpath = vpath;
                            i_delete = delete;

                            fav = imgFavorite;
                            dis = discStatus;

                            //dgvDoc.Rows.Add(img, fileName, keyword, modified, sharedCount.ToString(), owner, count, "file", path, vpath, imgFavorite, discStatus);
                        }
                    }
                }
                else
                {
                    if (sourcePath != vpath)
                    {
                        string tmpPath = vpath.Replace(sourcePath, "").Substring(1);

                        if (tmpPath.Contains(@"\"))
                        {
                            tmpPath = tmpPath.Substring(0, tmpPath.IndexOf(@"\"));

                            if (!folderList.Contains(tmpPath))
                            {
                                folderList.Add(tmpPath);

                                if (tmpPath == "Documents")
                                    continue;

                                i_type = "folder";
                                icon = Properties.Resources.folder_open;
                                i_filename = tmpPath;
                                i_vpath = sourcePath + @"\" + tmpPath;
                                i_delete = "";
                                dis = DataUtil.IsAllFileDisc(GlobalService.RootTable, i_vpath) ? Properties.Resources.status_away : Properties.Resources.status;
                                fav = DataUtil.IsAllFileFavorite2(GlobalService.RootTable, i_vpath) ? Properties.Resources.star_16 : Properties.Resources.star_gray_16;

                                //dgvDoc.Rows.Add(Properties.Resources.folder_open, tmpPath, "", "", "", "", "", "folder", "", sourcePath + @"\" + tmpPath, imgFavorite, discStatus);
                            }
                            else
                                continue;
                        }

                        else if (folderList.Contains(tmpPath))
                            continue;

                        else
                        {
                            folderList.Add(tmpPath);

                            if (tmpPath == "Documents")
                                continue;

                            i_type = "folder";
                            icon = Properties.Resources.folder_open;
                            i_filename = tmpPath;
                            i_vpath = sourcePath + @"\" + tmpPath;
                            i_delete = "";
                            dis = DataUtil.IsAllFileDisc(GlobalService.RootTable, i_vpath) ? Properties.Resources.status_away : Properties.Resources.status;
                            fav = DataUtil.IsAllFileFavorite2(GlobalService.RootTable, i_vpath) ? Properties.Resources.star_16 : Properties.Resources.star_gray_16;

                            //dgvDoc.Rows.Add(Properties.Resources.folder_open, tmpPath, "", "", "", "", "", "folder", "", sourcePath + @"\" + tmpPath, imgFavorite, discStatus);
                        }
                    }
                    else
                    {
                        if (fileList.Contains(path))
                            continue;

                        fileList.Add(path);

                        Image img;
                        string imgPath = path.ToLower();

                        if (imgPath.EndsWith(".xls") || imgPath.EndsWith(".xlsx") || imgPath.EndsWith(".xlsm") || imgPath.EndsWith(".csv"))
                            img = Properties.Resources.excel_16;
                        else if (imgPath.EndsWith(".doc") || imgPath.EndsWith(".docx"))
                            img = Properties.Resources.word_16;
                        else if (imgPath.EndsWith(".ppt") || imgPath.EndsWith(".pptx"))
                            img = Properties.Resources.powerpoint_16;
                        else if (imgPath.EndsWith(".png") || imgPath.EndsWith(".jpg") || imgPath.EndsWith(".gif") || imgPath.EndsWith(".tiff") || imgPath.EndsWith(".jpeg") || imgPath.EndsWith(".bmp") || imgPath.EndsWith(".tif"))
                            img = Properties.Resources.picture;
                        else if (imgPath.EndsWith(".pdf"))
                            img = Properties.Resources.pdf_16;
                        else if (imgPath.EndsWith(".txt"))
                            img = Properties.Resources.text;
                        else if (imgPath.EndsWith(".zip"))
                            img = Properties.Resources.zip_16;
                        else
                            img = Properties.Resources.windows_16;

                        i_type = "file";
                        icon = img;
                        i_count = count;
                        i_filename = fileName;
                        i_keyword = keyword;
                        i_modified = modified;
                        i_shared = sharedCount.ToString();
                        i_owner = owner;
                        i_path = path;
                        i_vpath = vpath;
                        i_delete = delete;

                        fav = imgFavorite;
                        dis = discStatus;

                        //dgvDoc.Rows.Add(img, fileName, keyword, modified, sharedCount.ToString(), owner, count, "file", path, vpath, imgFavorite, discStatus);
                    }
                }
                outputTable.Rows.Add(icon, i_filename, i_keyword, i_modified, i_shared, i_owner, i_count, i_type, i_path, i_vpath, i_delete, fav, dis);
            }

            outputTable.DefaultView.Sort = "type, filename asc";
            outputTable = outputTable.DefaultView.ToTable();

            dgvDoc.DataSource = outputTable;

            dgvDoc.Sort(dgvDoc.Columns[7], ListSortDirection.Descending);

            //this.CheckFavorite();

            dgvDoc.ClearSelection();
        }

        private void LoadDisc(DataTable sourceTable, string sourcePath)
        {
            DataRow[] dataRow = (from row in sourceTable.AsEnumerable()
                                 where row.RowState != DataRowState.Deleted && (row.Field<string>("disc") == "Pending" || row.Field<string>("disc") == "True")
                                 select row).ToArray();

            List<string> folderList = new List<string>();
            List<string> fileList = new List<string>();

            DataTable outputTable = new DataTable();
            outputTable.Columns.Add("img", typeof(Image));
            string[] headers = { "filename", "keyword", "modified", "shared", "owner", "read", "type", "path", "vpath", "delete" };
            foreach (string header in headers)
                outputTable.Columns.Add(header);
            outputTable.Columns.Add("fav", typeof(Image));
            outputTable.Columns.Add("disc", typeof(Image));

            foreach (DataRow row in dataRow)
            {
                string fileName = row.ItemArray[0].ToString().Trim();
                string keyword = row.ItemArray[1].ToString().Trim();
                string modified = row.ItemArray[2].ToString();
                string access = row.ItemArray[3].ToString();
                string owner = row.ItemArray[4].ToString().Trim();
                string shared = row.ItemArray[5].ToString().Trim();
                string path = row.ItemArray[6].ToString().Trim();
                string vpath = row.ItemArray[7].ToString().Trim();
                string count = row.ItemArray[8].ToString();
                string favorite = row.ItemArray[9].ToString().Trim();
                string disc = row.ItemArray[11].ToString().Trim();
                string delete = row.ItemArray[12].ToString().Trim();

                Image discStatus = disc == "False" ? Properties.Resources.status
                    : disc == "Pending" ? Properties.Resources.status_away : Properties.Resources.status_busy;

                //if (vpath == @"\Disc\Documents")
                // continue;

                int sharedCount = 0;

                if (shared != "-")
                {
                    if (shared.Contains(";"))
                    {
                        string[] slist = shared.Split(';');
                        sharedCount = slist.Length;
                    }
                    else
                        sharedCount = 1;
                }

                Image icon = null;
                string i_filename = "";
                string i_keyword = "";
                string i_modified = "";
                //string i_access = "";
                string i_owner = "";
                string i_shared = "";
                string i_path = "";
                string i_vpath = "";
                string i_count = "";
                //string i_favorite = "";
                //string i_disc = "";
                string i_type = "";
                string i_delete = "";

                Image fav = null;
                Image dis = null;

                Image imgFavorite = favorite == "True" ? Properties.Resources.star_16 : Properties.Resources.star_gray_16;

                if (vpath.StartsWith(@"\" + UserUtil.HkItGroupCode()) || vpath.StartsWith(@"\" + GlobalService.Division) || vpath.StartsWith(@"\Common"))
                //if (vpath.StartsWith(@"\23600") || vpath.StartsWith(@"\" + GlobalService.Division) || vpath.StartsWith(@"\Common"))
                {
                    //sourcePath = vpath.StartsWith(@"\23600\") ? sourcePath
                    //    : vpath.StartsWith(@"\23600") ? @"\Documents\23600"
                    sourcePath = vpath.StartsWith(@"\"  + UserUtil.HkItGroupCode() +"\\") ? sourcePath
                        : vpath.StartsWith(@"\" + UserUtil.HkItGroupCode()) ? @"\Documents\" + UserUtil.HkItGroupCode()
                        : vpath.StartsWith(@"\" + GlobalService.Division + @"\") ? sourcePath
                        : vpath.StartsWith(@"\" + GlobalService.Division) ? @"\Documents\" + GlobalService.Division
                        : vpath.StartsWith(@"\Common\") ? sourcePath
                        : vpath.StartsWith(@"\Common") ? @"\Common" : sourcePath;

                    vpath = @"\Documents" + vpath;

                    if (sourcePath != vpath)
                    {
                        string tmpPath = vpath.Replace(sourcePath, "").Substring(1);

                        if (tmpPath.Contains(@"\"))
                        {
                            tmpPath = tmpPath.Substring(0, tmpPath.IndexOf(@"\"));

                            if (!folderList.Contains(tmpPath))
                            {
                                folderList.Add(tmpPath);

                                i_type = "folder";
                                icon = Properties.Resources.folder_open;
                                i_filename = tmpPath;
                                i_vpath = sourcePath + @"\" + tmpPath;
                                i_delete = "";
                                dis = Properties.Resources.status_away;
                                fav = DataUtil.IsAllFileFavorite2(GlobalService.RootTable, i_vpath) ? Properties.Resources.star_16 : Properties.Resources.star_gray_16;

                                //dgvDoc.Rows.Add(Properties.Resources.folder_open, tmpPath, "", "", "", "", "", "folder", "", sourcePath + @"\" + tmpPath, imgFavorite, discStatus);
                            }
                            else
                                continue;
                        }

                        else if (folderList.Contains(tmpPath))
                            continue;

                        else
                        {
                            folderList.Add(tmpPath);

                            i_type = "folder";
                            icon = Properties.Resources.folder_open;
                            i_filename = tmpPath;
                            i_vpath = sourcePath + @"\" + tmpPath;
                            i_delete = "";
                            dis = Properties.Resources.status_away;
                            fav = DataUtil.IsAllFileFavorite2(GlobalService.RootTable, i_vpath) ? Properties.Resources.star_16 : Properties.Resources.star_gray_16;

                            //dgvDoc.Rows.Add(Properties.Resources.folder_open, tmpPath, "", "", "", "", "", "folder", "", sourcePath + @"\" + tmpPath, imgFavorite, discStatus);
                        }
                    }
                    else
                    {
                        if (txtPath.Text == vpath)
                        {
                            if (fileList.Contains(path))
                                continue;

                            fileList.Add(path);

                            Image img;
                            string imgPath = path.ToLower();

                            if (imgPath.EndsWith(".xls") || imgPath.EndsWith(".xlsx") || imgPath.EndsWith(".xlsm") || imgPath.EndsWith(".csv"))
                                img = Properties.Resources.excel_16;
                            else if (imgPath.EndsWith(".doc") || imgPath.EndsWith(".docx"))
                                img = Properties.Resources.word_16;
                            else if (imgPath.EndsWith(".ppt") || imgPath.EndsWith(".pptx"))
                                img = Properties.Resources.powerpoint_16;
                            else if (imgPath.EndsWith(".png") || imgPath.EndsWith(".jpg") || imgPath.EndsWith(".gif") || imgPath.EndsWith(".tiff") || imgPath.EndsWith(".jpeg") || imgPath.EndsWith(".bmp") || imgPath.EndsWith(".tif"))
                                img = Properties.Resources.picture;
                            else if (imgPath.EndsWith(".pdf"))
                                img = Properties.Resources.pdf_16;
                            else if (imgPath.EndsWith(".txt"))
                                img = Properties.Resources.text;
                            else if (imgPath.EndsWith(".zip"))
                                img = Properties.Resources.zip_16;
                            else
                                img = Properties.Resources.windows_16;

                            i_type = "file";
                            icon = img;
                            i_count = count;
                            i_filename = fileName;
                            i_keyword = keyword;
                            i_modified = modified;
                            i_shared = sharedCount.ToString();
                            i_owner = owner;
                            i_path = path;
                            i_vpath = vpath;
                            i_delete = delete;

                            fav = imgFavorite;
                            dis = discStatus;

                            //dgvDoc.Rows.Add(img, fileName, keyword, modified, sharedCount.ToString(), owner, count, "file", path, vpath, imgFavorite, discStatus);
                        }
                    }
                }
                else
                {
                    if (sourcePath != vpath)
                    {
                        string tmpPath = vpath.Replace(sourcePath, "").Substring(1);

                        if (tmpPath.Contains(@"\"))
                        {
                            tmpPath = tmpPath.Substring(0, tmpPath.IndexOf(@"\"));

                            //if (tmpPath == "Disc")
                            // continue;
                            if (!folderList.Contains(tmpPath))
                            {
                                folderList.Add(tmpPath);

                                if (tmpPath == "Documents")
                                    continue;

                                i_type = "folder";
                                icon = Properties.Resources.folder_open;
                                i_filename = tmpPath;
                                i_vpath = sourcePath + @"\" + tmpPath;
                                i_delete = "";
                                dis = Properties.Resources.status_away;
                                fav = DataUtil.IsAllFileFavorite2(GlobalService.RootTable, i_vpath) ? Properties.Resources.star_16 : Properties.Resources.star_gray_16;

                                //dgvDoc.Rows.Add(Properties.Resources.folder_open, tmpPath, "", "", "", "", "", "folder", "", sourcePath + @"\" + tmpPath, imgFavorite, discStatus);
                            }
                            else
                                continue;
                        }

                        else if (folderList.Contains(tmpPath))
                            continue;

                        else
                        {
                            folderList.Add(tmpPath);

                            if (tmpPath == "Documents")
                                continue;

                            i_type = "folder";
                            icon = Properties.Resources.folder_open;
                            i_filename = tmpPath;
                            i_vpath = sourcePath + @"\" + tmpPath;
                            i_delete = "";
                            dis = Properties.Resources.status_away;
                            fav = DataUtil.IsAllFileFavorite2(GlobalService.RootTable, i_vpath) ? Properties.Resources.star_16 : Properties.Resources.star_gray_16;

                            //dgvDoc.Rows.Add(Properties.Resources.folder_open, tmpPath, "", "", "", "", "", "folder", "", sourcePath + @"\" + tmpPath, imgFavorite, discStatus);
                        }
                    }
                    else
                    {
                        if (fileList.Contains(path))
                            continue;

                        fileList.Add(path);

                        Image img;
                        string imgPath = path.ToLower();

                        if (imgPath.EndsWith(".xls") || imgPath.EndsWith(".xlsx") || imgPath.EndsWith(".xlsm") || imgPath.EndsWith(".csv"))
                            img = Properties.Resources.excel_16;
                        else if (imgPath.EndsWith(".doc") || imgPath.EndsWith(".docx"))
                            img = Properties.Resources.word_16;
                        else if (imgPath.EndsWith(".ppt") || imgPath.EndsWith(".pptx"))
                            img = Properties.Resources.powerpoint_16;
                        else if (imgPath.EndsWith(".png") || imgPath.EndsWith(".jpg") || imgPath.EndsWith(".gif") || imgPath.EndsWith(".tiff") || imgPath.EndsWith(".jpeg") || imgPath.EndsWith(".bmp") || imgPath.EndsWith(".tif"))
                            img = Properties.Resources.picture;
                        else if (imgPath.EndsWith(".pdf"))
                            img = Properties.Resources.pdf_16;
                        else if (imgPath.EndsWith(".txt"))
                            img = Properties.Resources.text;
                        else if (imgPath.EndsWith(".zip"))
                            img = Properties.Resources.zip_16;
                        else
                            img = Properties.Resources.windows_16;

                        i_type = "file";
                        icon = img;
                        i_count = count;
                        i_filename = fileName;
                        i_keyword = keyword;
                        i_modified = modified;
                        i_shared = sharedCount.ToString();
                        i_owner = owner;
                        i_path = path;
                        i_vpath = vpath;
                        i_delete = delete;

                        fav = imgFavorite;
                        dis = discStatus;

                        //dgvDoc.Rows.Add(img, fileName, keyword, modified, sharedCount.ToString(), owner, count, "file", path, vpath, imgFavorite, discStatus);
                    }
                }

                outputTable.Rows.Add(icon, i_filename, i_keyword, i_modified, i_shared, i_owner, i_count, i_type, i_path, i_vpath, i_delete, fav, dis);
            }

            outputTable.DefaultView.Sort = "type, filename asc";
            outputTable = outputTable.DefaultView.ToTable();

            dgvDoc.DataSource = outputTable;

            dgvDoc.Sort(dgvDoc.Columns[7], ListSortDirection.Descending);

            dgvDoc.ClearSelection();
        }

        private void CheckFavorite()
        {
            foreach (DataGridViewRow row in dgvDoc.Rows)
            {
                string type = row.Cells[7].Value.ToString();
                string vpath = row.Cells[9].Value.ToString();

                if (type == "folder")
                {
                    if (!DataUtil.IsAllFileFavorite2(GlobalService.RootTable, vpath))
                    {
                        DataGridViewImageCell cell = (DataGridViewImageCell)row.Cells[11];
                        cell.Value = (Image)Properties.Resources.star_gray_16;
                    }
                }
            }
        }

        private void CheckDisc()
        {
            foreach (DataGridViewRow row in dgvDoc.Rows)
            {
                string vpath = row.Cells[9].Value.ToString();

                if (!DataUtil.IsAllFileDisc(vpath))
                {
                    DataGridViewCell cell = (DataGridViewImageCell)row.Cells[12];
                    cell.Value = (Image)Properties.Resources.status_away;
                }
                else
                {
                    DataGridViewCell cell = (DataGridViewImageCell)row.Cells[12];
                    cell.Value = (Image)Properties.Resources.status;
                }
            }
        }

        private void LoadExternalStorage()
        {
            string query = string.Format("select share_folder, share_path from TB_SHARED_FOLDER where share_staffid = N'{0}'", GlobalService.User);
            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                {
                    string folder = GlobalService.Reader.GetString(0);
                    string path = GlobalService.Reader.GetString(1);

                    dgvExternalStorage.Rows.Add(Properties.Resources.cloud_20, folder, path);
                }
            }
        }

        private void tvFolder_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                tvFolder.SelectedNode = e.Node;

                txtSearch.Clear();

                var hittest = tvFolder.HitTest(e.Location);

                if (hittest.Location != TreeViewHitTestLocations.PlusMinus)
                {
                    string tmpPath = txtPath.Text.Trim();

                    txtPath.Text = @"\" + e.Node.FullPath;
                    btnPrevious.Enabled = false;
                    GlobalService.SelectedVpath = txtPath.Text;

                    if (GlobalService.MemoryList.Count > 0)
                    {
                        var item = GlobalService.MemoryList[GlobalService.MemoryList.Count - 1];

                        if (item != tmpPath)
                        {
                            GlobalService.MemoryList.Add(tmpPath);
                            btnPrevious.Enabled = true;
                        }
                    }
                    else
                    {
                        GlobalService.MemoryList.Add(tmpPath);
                        btnPrevious.Enabled = true;
                    }
                }

                _mode = "";
                this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);

            }
        }

        private void dgvDoc_DoubleClick(object sender, EventArgs e)
        {
            if (dgvDoc.SelectedRows.Count > 0)
            {
                string name = dgvDoc.SelectedRows[0].Cells[1].Value.ToString();
                string path = dgvDoc.SelectedRows[0].Cells[8].Value.ToString();
                string type = dgvDoc.SelectedRows[0].Cells[7].Value.ToString();
                string vpath = dgvDoc.SelectedRows[0].Cells[9].Value.ToString();

                //Debug.WriteLine("Selected vpath : " + vpath);

                if (txtPath.Text == @"\Documents")
                {
                    List<DocumentList> docList = new List<DocumentList>();
                    foreach (DataGridViewRow row in dgvDoc.Rows)
                    {
                        Image img = (Image)row.Cells[0].Value;
                        string dFilename = row.Cells[1].Value.ToString();
                        string dKeyword = row.Cells[2].Value.ToString();
                        string dModified = row.Cells[3].Value.ToString();
                        string dShared = row.Cells[4].Value.ToString();
                        string dOwner = row.Cells[5].Value.ToString();
                        string dRead = row.Cells[6].Value.ToString();
                        string dType = row.Cells[7].Value.ToString();
                        string dPath = row.Cells[8].Value.ToString();
                        string dVpath = row.Cells[9].Value.ToString();
                        Image dFavorite = (Image)row.Cells[11].Value;
                        Image dStatus = (Image)row.Cells[12].Value;

                        docList.Add(new DocumentList { Icon = img, Name = dFilename, Keyword = dKeyword, Modified = dModified, Shared = dShared, Owner = dOwner, Read = dRead, Type = dType, Path = dPath, Vpath = dVpath, Favorite = dFavorite, Status = dStatus });
                    }
                    GlobalService.DocumentList = docList;
                }

                if (type == "notice")
                {
                    Process.Start(path);
                }
                else if (type == "folder" || type == "newfolder")
                {
                    btnPrevious.Enabled = true;

                    if (GlobalService.MemoryList.Count > 0)
                    {
                        var item = GlobalService.MemoryList[GlobalService.MemoryList.Count - 1];

                        if (item != txtPath.Text)
                            GlobalService.MemoryList.Add(txtPath.Text);
                    }
                    else
                        GlobalService.MemoryList.Add(txtPath.Text);

                    txtPath.Text = txtPath.Text + @"\" + name;

                    if (_mode == "favorite")
                    {
                        txtPath.Text = vpath;
                        this.LoadFavorite(GlobalService.RootTable, vpath, "doubleclicked");
                    }
                    else if (_mode == "disc")
                        this.LoadDisc(GlobalService.RootTable, vpath);
                    else
                        this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
                }
                else
                {
                    if (DiscUtil.IsDisc(GlobalService.RootTable, path))
                    {
                        string discNo = DiscUtil.GetDiscNo(GlobalService.DiscList, path);
                        switch (MessageBox.Show("This file is already stored in disc : " + discNo +". Do you want to contact system administrator to retrieve this file?\n\nPress Yes to send notice to system administrator.\nPress No to cancel.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        {
                            case DialogResult.Yes:
                                string fromEmail = AdUtil.GetEmailByUserId(AdUtil.GetUserId());
                                //string toEmail = "gabriel.yeung@dthk.kyocera.com";
                                //string[] ccEmail = {  "mingfung.lee@dthk.kyocera.com", "ken.ho@dthk.kyocera.com", "onyx.chan@dthk.kyocera.com" };
                                string toEmail = UserUtil.ItMail1();
                                string[] ccEmail = { UserUtil.ItMail3(), UserUtil.ItMail2() };
                                string subject = discNo + "_DVD Request from " + GlobalService.User;
                                string content = "DVD request from " + GlobalService.User + "\nFilename: " + name + "\nDisc No.: " + discNo;

                                string hostname = "Kdmail.km.local";
                                SmtpClient client = new SmtpClient(hostname);
                                client.DeliveryMethod = SmtpDeliveryMethod.Network;

                                MailMessage message = new MailMessage(fromEmail, toEmail);
                                message.Subject = subject;
                                message.Body = content;
                                foreach (string cc in ccEmail)
                                    message.CC.Add(cc);

                                try
                                {
                                    client.Send(message);
                                }
                                catch
                                {
                                    
                                }
                                break;

                            case DialogResult.No:
                                break;
                        }
                    }
                    else
                    {
                        if (File.Exists(path))
                        {
                            Process.Start(path);
                            DataUtil.AddReadCount(GlobalService.RootTable, path);

                            if (txtSearch.Text != "")
                            {
                                this.SearchData(GlobalService.RootTable, txtSearch.Text);
                            }
                            else
                            {
                                if (_mode == "favorite")
                                    this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
                                else if (_mode == "disc")
                                    this.LoadDisc(GlobalService.RootTable, txtPath.Text);
                                else
                                    this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
                            }
                        }
                        else
                            MessageBox.Show("System cannot find specifed file. File may be relocated or removed.");
                    }
                }
            }
        }

        private void dgvDoc_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (dgvDoc.Rows.Count > 0)
                {
                    if (((dgvDoc.Rows[0].Height * dgvDoc.Rows.Count) + dgvDoc.ColumnHeadersHeight) < e.Location.Y)
                        dgvDoc.ClearSelection();
                    else
                    {
                        if (e.Button == MouseButtons.Right)
                        {
                            var hti = dgvDoc.HitTest(e.X, e.Y);

                            if (dgvDoc.SelectedRows.Count == 1)
                            {
                                dgvDoc.ClearSelection();

                                if (((dgvDoc.Rows[0].Height * dgvDoc.Rows.Count) + dgvDoc.ColumnHeadersHeight) >= e.Location.Y)
                                    dgvDoc.Rows[hti.RowIndex].Selected = true;
                            }
                            else
                            {
                                if (((dgvDoc.Rows[0].Height * dgvDoc.Rows.Count) + dgvDoc.ColumnHeadersHeight) >= e.Location.Y)
                                    dgvDoc.Rows[hti.RowIndex].Selected = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            string vpath = txtPath.Text;

            if (vpath.Substring(1).Contains("\\"))
                vpath = vpath.Substring(0, vpath.LastIndexOf("\\"));

            txtPath.Text = vpath;

            if (!txtPath.Text.Substring(1).Contains("\\"))
                btnPrevious.Enabled = false;

            if (_mode == "favorite")
                this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "previous");
            else if (_mode == "disc")
                this.LoadDisc(GlobalService.RootTable, txtPath.Text);
            else
                this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            //tvFolder.Nodes.Clear();

            string apath = txtPath.Text.StartsWith(@"\Documents\Common") ? txtPath.Text.Replace(@"\Documents\Common", @"\Common")
                : txtPath.Text.StartsWith(@"\Documents\" + GlobalService.Division) ? txtPath.Text.Replace(@"\Documents\" + GlobalService.Division, @"\" + GlobalService.Division) : txtPath.Text;

            List<string> list = DataUtil.GetFolderPathList(GlobalService.RootTable, apath);
            foreach (string path in list)
                DataUtil.UpdateModifiedDate(path);

            //DataUtil.SyncDataToServer();

            GlobalService.RootTable = RootUtil.RootDataTable();

            TreeviewUtil.LoadPersonalFolder(tvFolder, GlobalService.User);

            string query = string.Format("update " + GlobalService.DbTable + " set r_vpath = replace(r_vpath, '{0}', '{1}')", @"\Documents\Common", @"\Common");
            DataService.GetInstance().ExecuteNonQuery(query);

            GlobalService.DiscList = DiscUtil.PopulateDiscList();

            if (_mode == "favorite")
                this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
            else if (_mode == "disc")
                this.LoadDisc(GlobalService.RootTable, txtPath.Text);
            else
                this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);

            if (GetNoticeEvent != null)
                GetNoticeEvent(this, new EventArgs());
        }

        private void dgvExternalStorage_DoubleClick(object sender, EventArgs e)
        {
            string path = dgvExternalStorage.SelectedRows[0].Cells[2].Value.ToString().Trim();

            Process.Start(path);
        }

        private void dgvDoc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                switch(MessageBox.Show("Are you sure to delete selected item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        foreach (DataGridViewRow row in dgvDoc.SelectedRows)
                        {
                            string type = row.Cells[7].Value.ToString();
                            string name = row.Cells[1].Value.ToString();

                            if (type == "folder")
                            {
                                string vpath = txtPath.Text + @"\" + name;
                                //DataRow[] dataRow = GlobalService.RootTable.Select(string.Format("vpath like '{0}%'", vpath));

                                DataRow[] dataRow = (from dr in GlobalService.RootTable.AsEnumerable()
                                                     where dr.RowState != DataRowState.Deleted && dr.Field<string>("vpath").StartsWith(vpath)
                                                     select dr).ToArray();

                                foreach (DataRow r in dataRow)
                                {
                                    string path = r["filepath"].ToString();
                                    DataUtil.DeleteData(GlobalService.RootTable, path);
                                }
                            }
                            else
                            {
                                string path = row.Cells[8].Value.ToString();
                                DataUtil.DeleteData(GlobalService.RootTable, path);
                            }
                        }

                        this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);

                        break;
                    case DialogResult.No:
                        break;
                }
            }
        }

        private void tsbtnSync_Click(object sender, EventArgs e)
        {
            string staffId = AdUtil.GetUserIdByUsername(GlobalService.User);

            string syncPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\MyCloud Sync";

            if (!Directory.Exists(syncPath))
                Directory.CreateDirectory(syncPath);

            string[] filepaths = Directory.GetFiles(syncPath, "*.*", SearchOption.AllDirectories);

            List<UploadFileList> uploadList = new List<UploadFileList>();

            string favoriteMode = txtPath.Text.StartsWith(@"\Favorite") ? "True" : "False";

            bool isSelected = false;
            string selectedMode = "";

            if (filepaths.Length > 0)
            {
                switch (MessageBox.Show("Sync files found. Do you want to setup now?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    case DialogResult.Yes:
                        foreach (string file in filepaths)
                        {
                            FileInfo info = new FileInfo(file);
                            string fileName = info.Name;
                            string filePath = info.FullName;

                            string directory = @"\\kdthk-dm1\project\KDTHK-DM\" + AdUtil.getAccount("kmhk.local") + @"\" + fileName;

                            if (File.Exists(directory))
                            {
                                if (!isSelected)
                                {
                                    switch (MessageBox.Show("Duplicate file found.\nPress Yes to overwirte.\nPress No to rename.\nPress Cancel to quit.", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                                    {
                                        case DialogResult.Yes:
                                            isSelected = true;
                                            selectedMode = "overwrite";
                                            uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "overwrite", DragMode = "file", Favorite = favoriteMode, FolderName = "" });
                                            break;

                                        case DialogResult.No:
                                            isSelected = true;
                                            selectedMode = "rename";
                                            uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "rename", DragMode = "file", Favorite = favoriteMode, FolderName = "" });
                                            break;

                                        case DialogResult.Cancel:
                                            break;
                                    }
                                }
                                else
                                {
                                    switch (selectedMode)
                                    {
                                        case "overwrite":
                                            uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "overwrite", DragMode = "file", Favorite = favoriteMode, FolderName = "" });
                                            break;

                                        case "rename":
                                            uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "rename", DragMode = "file", Favorite = favoriteMode, FolderName = "" });
                                            break;
                                    }
                                }
                            }
                            else
                                uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "", DragMode = "file", Favorite = favoriteMode, FolderName = "" });
                        }
                        break;

                    case DialogResult.No:
                        break;
                }
            }
            else
                MessageBox.Show("No files contain in MyCloud Sync folder.");

            if (uploadList.Count > 0)
            {
                DocumentForm docForm = new DocumentForm(uploadList, txtPath.Text);
                if (docForm.ShowDialog() == DialogResult.OK)
                {
                    if (_mode == "favorite")
                        this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
                    else if (_mode == "disc")
                        this.LoadDisc(GlobalService.RootTable, txtPath.Text);
                    else
                        this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);

                    foreach (string filePath in filepaths)
                        File.Delete(filePath);

                    DirectoryInfo dinfo = new DirectoryInfo(syncPath);

                    foreach (DirectoryInfo dir in dinfo.GetDirectories())
                        dir.Delete(true);
                }
            }
        }

        private void tsbtnNewFolder_Click(object sender, EventArgs e)
        {
            NewFolderForm form = new NewFolderForm(txtPath.Text, "new");
            if (form.ShowDialog() == DialogResult.OK)
            {
                DataTable table = (DataTable)dgvDoc.DataSource;
                table.Rows.Add(Properties.Resources.folder_open, GlobalService.NewFolder, "", "", "", "", "", "newfolder", "", txtPath.Text + @"\" + GlobalService.NewFolder, "", Properties.Resources.star_gray_16, Properties.Resources.status);
                dgvDoc.DataSource = table;
            }
        }

        private void UploadFile()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Multiselect = true;

                DialogResult result = ofd.ShowDialog();

                if (result == DialogResult.Cancel)
                {
                    if (dialogCancel != "")
                        result = DialogResult.OK;
                }

                if (result == DialogResult.OK)
                {
                    dialogCancel = "";

                    string[] files = ofd.FileNames;

                    List<UploadFileList> uploadList = new List<UploadFileList>();

                    bool isSelected = false;
                    string selectedMode = "";

                    foreach (string file in files)
                    {
                        FileInfo info = new FileInfo(file);
                        string fileName = info.Name;
                        string filePath = info.FullName;

                        Debug.WriteLine("filename: " + fileName);

                        string directory = filePath.StartsWith(@"M:\") ? filePath.Replace(@"M:\", @"\\kdthk-dm1\project\")
                            : filePath.StartsWith(@"L:\") ? filePath : @"\\kdthk-dm1\project\KDTHK-DM\" + AdUtil.getAccount() + @"\" + fileName;

                        string favoriteMode = _mode == "favorite" ? "True" : "False";

                        if (File.Exists(directory) && directory.Contains(@"\\kdthk-dm1\project\KDTHK-DM"))
                        {
                            if (!isSelected)
                            {
                                switch (MessageBox.Show("Duplicate file found.\nPress Yes to overwirte.\nPress No to rename.\nPress Cancel to quit.", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                                {
                                    case DialogResult.Yes:
                                        isSelected = true;
                                        selectedMode = "overwrite";
                                        uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "overwrite", DragMode = "file", Favorite = favoriteMode, FolderName = "" });
                                        break;

                                    case DialogResult.No:
                                        isSelected = true;
                                        selectedMode = "rename";
                                        uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "rename", DragMode = "file", Favorite = favoriteMode, FolderName = "" });
                                        break;

                                    case DialogResult.Cancel:
                                        break;
                                }
                            }
                            else
                            {
                                switch (selectedMode)
                                {
                                    case "overwrite":
                                        uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "overwrite", DragMode = "file", Favorite = favoriteMode, FolderName = "" });
                                        break;

                                    case "rename":
                                        uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "rename", DragMode = "file", Favorite = favoriteMode, FolderName = "" });
                                        break;
                                }
                            }
                        }
                        else
                            uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "", DragMode = "file", Favorite = favoriteMode, FolderName = "" });
                    }

                    Debug.WriteLine("upload count: " + uploadList.Count);
                    if (uploadList.Count > 0)
                    {
                        DocumentForm docForm = new DocumentForm(uploadList, txtPath.Text);
                        if (docForm.ShowDialog() == DialogResult.OK)
                        {
                            if (_mode == "favorite")
                                this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
                            else if (_mode == "disc")
                                this.LoadDisc(GlobalService.RootTable, txtPath.Text);
                            else
                                this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
                        }
                    }
                }
            }
        }

        private void tsbtnUploadFile_Click(object sender, EventArgs e)
        {
            UploadFile();
        }

        private void UploadFolder()
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string folder = fbd.SelectedPath;

                    string folderName = folder.Substring(folder.LastIndexOf("\\"));

                    string[] files = Directory.GetFileSystemEntries(folder, "*", SearchOption.AllDirectories);

                    List<UploadFileList> uploadList = new List<UploadFileList>();

                    bool isSelected = false;
                    string selectedMode = "";

                    foreach (string file in files)
                    {
                        FileAttributes attributes = File.GetAttributes(file);
                        bool isSubFolder = (attributes & FileAttributes.Directory) == FileAttributes.Directory;

                        if (isSubFolder)
                            continue;

                        FileInfo info = new FileInfo(file);
                        string fileName = info.Name;
                        string filePath = info.FullName;

                        string directory = filePath.StartsWith(@"M:\") ? filePath.Replace(@"M:\", @"\\kdthk-dm1\project\")
                            : filePath.StartsWith(@"L:\") ? filePath : @"\\kdthk-dm1\project\KDTHK-DM\" + AdUtil.getAccount("kmhk.local") + @"\" + fileName;

                        string favoriteMode = _mode == "favorite" ? "True" : "False";

                        if (File.Exists(directory) && directory.Contains(@"\\kdthk-dm1\project\KDTHK-DM"))
                        {
                            if (!isSelected)
                            {
                                switch (MessageBox.Show("Duplicate file found.\nPress Yes to overwirte.\nPress No to rename.\nPress Cancel to quit.", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                                {
                                    case DialogResult.Yes:
                                        isSelected = true;
                                        selectedMode = "overwrite";
                                        uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "overwrite", DragMode = "folder", Favorite = favoriteMode, FolderName = folderName });
                                        break;

                                    case DialogResult.No:
                                        isSelected = true;
                                        selectedMode = "rename";
                                        uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "rename", DragMode = "folder", Favorite = favoriteMode, FolderName = folderName });
                                        break;

                                    case DialogResult.Cancel:
                                        break;
                                }
                            }
                            else
                            {
                                switch (selectedMode)
                                {
                                    case "overwrite":
                                        uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "overwrite", DragMode = "folder", Favorite = favoriteMode, FolderName = folderName });
                                        break;

                                    case "rename":
                                        uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "rename", DragMode = "folder", Favorite = favoriteMode, FolderName = folderName });
                                        break;
                                }
                            }
                        }
                        else
                            uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "", DragMode = "folder", Favorite = favoriteMode, FolderName = folderName });
                    }

                    if (uploadList.Count > 0)
                    {
                        DocumentForm docForm = new DocumentForm(uploadList, txtPath.Text);
                        if (docForm.ShowDialog() == DialogResult.OK)
                        {
                            if (_mode == "favorite")
                                this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
                            else if (_mode == "disc")
                                this.LoadDisc(GlobalService.RootTable, txtPath.Text);
                            else
                                this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No file can be found.");
                    }
                }
                else
                {
                    dialogCancel = "cancel";
                }
            }
        }

        private void tsbtnUploadFolder_Click(object sender, EventArgs e)
        {
            UploadFolder();   
        }

        private void tsbtnAttachment_Click(object sender, EventArgs e)
        {
            AttachmentForm form = new AttachmentForm(GlobalService.AttachmentList);
            form.ShowDialog();
        }

        private void dgvDoc_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            dgvDoc.CurrentCell.ReadOnly = true;
        }

        private void dgvDoc_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                List<KeyValuePair<DataGridViewColumn, bool>> sortedList = new List<KeyValuePair<DataGridViewColumn, bool>>();
                sortedList.Add(new KeyValuePair<DataGridViewColumn, bool>(dgvDoc.Columns[7], false));
                sortedList.Add(new KeyValuePair<DataGridViewColumn, bool>(dgvDoc.Columns[e.ColumnIndex], true));

                GridRowComparer comparer = new GridRowComparer(sortedList);
                dgvDoc.Sort(comparer);

                foreach (DataGridViewColumn column in dgvDoc.Columns)
                {
                    if (column.Index != e.ColumnIndex)
                    {
                        column.HeaderCell.Style.BackColor = SystemColors.ControlLightLight;
                        column.HeaderCell.Style.ForeColor = Color.Black;
                        column.HeaderCell.Style.Font = new Font("Calibri", 9.5F, FontStyle.Regular);
                    }
                    else
                    {
                        dgvDoc.Columns[e.ColumnIndex].HeaderCell.Style.ForeColor = Color.SteelBlue;
                        dgvDoc.Columns[e.ColumnIndex].HeaderCell.Style.Font = new Font("Calibri", 9.5F, FontStyle.Bold);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        private void msDocument_Opening(object sender, CancelEventArgs e)
        {
            var cms = (ContextMenuStrip)sender;
            var mousePos = Control.MousePosition;

            if (cms != null)
            {
                var pos = cms.PointToClient(mousePos);
                if (cms.ClientRectangle.Contains(pos))
                {
                    var relpos = dgvDoc.PointToClient(mousePos);
                    var hti = dgvDoc.HitTest(relpos.X, relpos.Y);
                    if (hti.RowIndex == -1)
                    {
                        //e.Cancel = true;
                        foreach (var item in msDocument.Items.OfType<ToolStripMenuItem>())
                            item.Enabled = false;

                        msDocument.Items[3].Enabled = true;
                    }
                    else
                    {
                        bool containFolder = false;
                        bool containNewFolder = false;

                        bool containNotice = false;

                        foreach (DataGridViewRow row in dgvDoc.SelectedRows)
                        {
                            string type = row.Cells[7].Value.ToString();
                            if (type == "notice")
                                containNotice = true;
                            if (type == "folder")
                                containFolder = true;
                            if (type == "newfolder")
                                containNewFolder = true;
                        }

                        if (containNotice)
                        {
                            msDocument.Enabled = false;
                        }
                        else
                        {
                            msDocument.Enabled = true;

                            if (containNewFolder)
                            {
                                foreach (var item in msDocument.Items.OfType<ToolStripMenuItem>())
                                    item.Enabled = false;

                                msDocument.Items[21].Enabled = true;
                            }
                            else
                            {
                                foreach (var item in msDocument.Items.OfType<ToolStripMenuItem>())
                                    item.Enabled = true;

                                string type = dgvDoc.SelectedRows[0].Cells[7].Value.ToString().Trim();

                                msDocument.Items[0].Enabled = containFolder && dgvDoc.SelectedRows.Count > 1 ? false : true;
                                msDocument.Items[1].Enabled = containFolder ? false : true;
                                //msDocument.Items[3].Enabled = dgvDoc.SelectedRows.Count > 1 || containFolder ? false : true;
                                msDocument.Items[6].Enabled = dgvDoc.SelectedRows.Count > 1 ? false : true;
                                msDocument.Items[8].Enabled = (dgvDoc.SelectedRows.Count > 1 || GlobalService.User != dgvDoc.SelectedRows[0].Cells[5].Value.ToString().Trim()) && type != "folder" ? false : true;
                                msDocument.Items[12].Enabled = containFolder ? false : true;
                                msDocument.Items[14].Enabled = containFolder || containNewFolder || dgvDoc.SelectedRows.Count > 1 ? false : true;
                                msDocument.Items[15].Enabled = containFolder || containNewFolder ? false : true;
                            }
                        }
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void dgvDoc_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            e.Effect = DragDropEffects.None;

            List<UploadFileList> uploadList = new List<UploadFileList>();

            bool isSelected = false;
            string selectedMode = "";

            foreach (string file in files)
            {
                if (file.Contains("thumbs.db") || file.Contains("Thumbs.db"))
                    continue;

                FileAttributes attribute = File.GetAttributes(file);
                bool isFolder = (attribute & FileAttributes.Directory) == FileAttributes.Directory;

                if (isFolder)
                {
                    string folder = file.Substring(file.LastIndexOf("\\") + 1);

                    string[] fs = Directory.GetFileSystemEntries(file, "*", SearchOption.AllDirectories);

                    foreach (string f in fs)
                    {
                        FileAttributes subatt = File.GetAttributes(f);
                        bool isSubFolder = (subatt & FileAttributes.Directory) == FileAttributes.Directory;

                        if (isSubFolder)
                            continue;

                        FileInfo info = new FileInfo(f);
                        string fileName = info.Name;
                        string filePath = info.FullName;

                        if (folder == "")
                            folder = Path.GetDirectoryName(f);

                        string directory = filePath.StartsWith(@"M:\") ? filePath.Replace(@"M:\", @"\\kdthk-dm1\project\")
                            : filePath.StartsWith(@"L:\") ? filePath : @"\\kdthk-dm1\project\KDTHK-DM\" + AdUtil.getAccount("kmhk.local") + @"\" + fileName;

                        string favoriteMode = txtPath.Text.StartsWith(@"\Favorite") ? "True" : "False";

                        if (File.Exists(directory) && directory.Contains(@"\\kdthk-dm1\project\KDTHK-DM"))
                        {
                            if (!isSelected)
                            {
                                switch (MessageBox.Show("Duplicate file found.\nPress Yes to overwirte.\nPress No to rename.\nPress Cancel to quit.", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                                {
                                    case DialogResult.Yes:
                                        isSelected = true;
                                        selectedMode = "overwrite";
                                        uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "overwrite", DragMode = "folder", Favorite = favoriteMode });
                                        break;

                                    case DialogResult.No:
                                        isSelected = true;
                                        selectedMode = "rename";
                                        uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "rename", DragMode = "folder", Favorite = favoriteMode });
                                        break;

                                    case DialogResult.Cancel:
                                        break;
                                }
                            }
                            else
                            {
                                switch (selectedMode)
                                {
                                    case "overwrite":
                                        uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "overwrite", DragMode = "folder", Favorite = favoriteMode });
                                        break;

                                    case "rename":
                                        uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "rename", DragMode = "folder", Favorite = favoriteMode });
                                        break;
                                }
                            }
                        }
                        else
                            uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "", DragMode = "folder", Favorite = favoriteMode });
                    }
                }
                else
                {
                    FileInfo info = new FileInfo(file);
                    string fileName = info.Name;
                    string filePath = info.FullName;

                    string currentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToUpper();

                    string accountName = "";

                    if (currentUser.StartsWith("KMHK"))
                    {
                        accountName = AdUtil.getAccount("kmhk.local");
                    }
                    else if (currentUser.StartsWith("KMAS"))
                    {
                        accountName = AdUtil.getAccount("kmas.local");
                    }
                    else
                    {
                        throw new Exception("User does not belongs to KMHK or KMAS");
                    }
                    
                    /*string directory = filePath.StartsWith(@"M:\") ? filePath.Replace(@"M:\", @"\\kdthk-dm1\project\")
                        : filePath.StartsWith(@"L:\") ? filePath : @"\\kdthk-dm1\project\KDTHK-DM\" + AdUtil.getAccount("kmhk.local") + @"\" + fileName;*/
                    string directory = filePath.StartsWith(@"M:\") ? filePath.Replace(@"M:\", @"\\kdthk-dm1\project\")
                        : filePath.StartsWith(@"L:\") ? filePath : @"\\kdthk-dm1\project\KDTHK-DM\" + accountName + @"\" + fileName;

                    string favoriteMode = _mode == "favorite" ? "True" : "False";

                    if (File.Exists(directory) && directory.Contains(@"\\kdthk-dm1\project\KDTHK-DM"))
                    {
                        if (!isSelected)
                        {
                            switch (MessageBox.Show("Duplicate file found.\nPress Yes to overwirte.\nPress No to rename.\nPress Cancel to quit.", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation))
                            {
                                case DialogResult.Yes:
                                    isSelected = true;
                                    selectedMode = "overwrite";
                                    uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "overwrite", DragMode = "file", Favorite = favoriteMode });
                                    break;

                                case DialogResult.No:
                                    isSelected = true;
                                    selectedMode = "rename";
                                    uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "rename", DragMode = "file", Favorite = favoriteMode });
                                    break;

                                case DialogResult.Cancel:
                                    break;
                            }
                        }
                        else
                        {
                            switch (selectedMode)
                            {
                                case "overwrite":
                                    uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "overwrite", DragMode = "file", Favorite = favoriteMode });
                                    break;

                                case "rename":
                                    uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "rename", DragMode = "file", Favorite = favoriteMode });
                                    break;
                            }
                        }
                    }
                    else
                        uploadList.Add(new UploadFileList { FileName = fileName, FilePath = filePath, Mode = "", DragMode = "file", Favorite = favoriteMode });
                    
                    }
            }

            if (uploadList.Count > 0)
            {
                DocumentForm docForm = new DocumentForm(uploadList, txtPath.Text);
                if (docForm.ShowDialog() == DialogResult.OK)
                {
                    if (_mode == "favorite")
                        this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
                    else if (_mode == "disc")
                        this.LoadDisc(GlobalService.RootTable, txtPath.Text);
                    else
                        this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
                }
            }
        }

        private void dgvDoc_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        #region ToolStripClick
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = dgvDoc.SelectedRows[0].Cells[1].Value.ToString();
            string type = dgvDoc.SelectedRows[0].Cells[7].Value.ToString();
            string filePath = dgvDoc.SelectedRows[0].Cells[8].Value.ToString();

            if (type == "folder")
            {
                btnPrevious.Enabled = true;

                if (GlobalService.MemoryList.Count > 0)
                {
                    var item = GlobalService.MemoryList[GlobalService.MemoryList.Count - 1];

                    if (item != txtPath.Text)
                        GlobalService.MemoryList.Add(txtPath.Text);
                }
                else
                    GlobalService.MemoryList.Add(txtPath.Text);

                txtPath.Text = txtPath.Text + @"\" + name;
            }
            else
            {
                foreach (DataGridViewRow row in dgvDoc.SelectedRows)
                {
                    string fPath = row.Cells[8].Value.ToString();

                    if (File.Exists(fPath))
                    {
                        Process.Start(fPath);
                        DataUtil.AddReadCount(GlobalService.RootTable, fPath);
                    }
                    else
                        MessageBox.Show("System cannot find specifed file. File may be relocated or removed.");
                }

                this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
            }
        }

        private void openWithExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filePath = dgvDoc.SelectedRows[0].Cells[8].Value.ToString();

            if (File.Exists(filePath))
            {
                Process.Start("EXCEL.EXE", "\"" + filePath + "\"");
                DataUtil.AddReadCount(GlobalService.RootTable, filePath);
                this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
            }
            else
                MessageBox.Show("System cannot find specifed file. File may be relocated or removed.");
        }

        private void shareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<SharedList> sharedDataList = new List<SharedList>();

            if (dgvDoc.SelectedRows.Count == 1)
            {
                string fileName = dgvDoc.SelectedRows[0].Cells[1].Value.ToString();
                string keyword = dgvDoc.SelectedRows[0].Cells[2].Value.ToString();
                string modified = dgvDoc.SelectedRows[0].Cells[3].Value.ToString();
                string owner = dgvDoc.SelectedRows[0].Cells[5].Value.ToString();
                string type = dgvDoc.SelectedRows[0].Cells[7].Value.ToString();
                string filePath = dgvDoc.SelectedRows[0].Cells[8].Value.ToString();
                string vpath = dgvDoc.SelectedRows[0].Cells[9].Value.ToString();

                if (type == "folder")
                {
                    string sVpath = vpath.Contains("'") ? vpath.Replace("'", "''") : vpath;

                    DataRow[] rows = (from row in GlobalService.RootTable.AsEnumerable()
                                      where row.RowState != DataRowState.Deleted && row.Field<string>("vpath").StartsWith(vpath) && row.Field<string>("fileowner") == GlobalService.User
                                      select row).ToArray();

                    foreach (DataRow row in rows)
                        sharedDataList.Add(new SharedList
                        {
                            Filename = row["filename"].ToString(),
                            Keyword = row["keyword"].ToString(),
                            Filepath = row["filepath"].ToString(),
                            Vpath = row["vpath"].ToString(),
                            Shared = row["shared"].ToString(),
                            LastModified = row["modified"].ToString(),
                            Disc = row["disc"].ToString()
                        });
                }
                else
                {
                    SingleShareForm singleForm = new SingleShareForm(fileName, filePath, owner, vpath, modified, keyword);

                    if (singleForm.ShowDialog() == DialogResult.OK)
                    {
                        if (_mode == "favorite")
                            this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
                        else if (_mode == "disc")
                            this.LoadDisc(GlobalService.RootTable, txtPath.Text);
                        else
                            this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvDoc.SelectedRows)
                {
                    string type = row.Cells[7].Value.ToString();
                    string vpath = row.Cells[9].Value.ToString();

                    if (type == "folder")
                    {
                        string sVpath = vpath.Contains("'") ? vpath.Replace("'", "''") : vpath;

                        DataRow[] rows = (from dr in GlobalService.RootTable.AsEnumerable()
                                          where dr.RowState != DataRowState.Deleted && dr.Field<string>("vpath").StartsWith(vpath) && dr.Field<string>("fileowner") == GlobalService.User
                                          select dr).ToArray();

                        foreach (DataRow dr in rows)
                            sharedDataList.Add(new SharedList
                            {
                                Filename = dr["filename"].ToString(),
                                Keyword = dr["keyword"].ToString(),
                                Filepath = dr["filepath"].ToString(),
                                Vpath = dr["vpath"].ToString(),
                                Shared = dr["shared"].ToString(),
                                LastModified = dr["modified"].ToString(),
                                Disc = dr["disc"].ToString()
                            });
                    }
                    else
                    {
                        string fileName = row.Cells[1].Value.ToString();
                        string keyword = row.Cells[2].Value.ToString();
                        string modified = row.Cells[3].Value.ToString();
                        string owner = row.Cells[5].Value.ToString();
                        string filePath = row.Cells[8].Value.ToString();

                        string shared = string.Join(";", DataUtil.GetSharedList(GlobalService.DbTable, filePath));
                        sharedDataList.Add(new SharedList { Filename = fileName, Keyword = keyword, Filepath = filePath, Vpath = vpath, LastModified = modified, Shared = shared, Disc = DiscUtil.GetDiscStatus(GlobalService.RootTable, filePath) });
                    }
                }
            }

            if (sharedDataList.Count > 0)
            {
                MultiShareForm form = new MultiShareForm(sharedDataList);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (_mode == "favorite")
                        this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
                    else if (_mode == "disc")
                        this.LoadDisc(GlobalService.RootTable, txtPath.Text);
                    else
                        this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
                }
            }
        }

        private void keywordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> pathList = new List<string>();

            foreach (DataGridViewRow row in dgvDoc.SelectedRows)
            {
                string name = row.Cells[1].Value.ToString();
                string type = row.Cells[7].Value.ToString();

                if (type == "folder")
                {
                    foreach (string path in DataUtil.GetFolderPathList(GlobalService.RootTable, txtPath.Text + @"\" + name))
                        pathList.Add(path);
                }
                else
                {
                    string path = row.Cells[8].Value.ToString();
                    pathList.Add(path);
                }
            }

            GlobalService.SelectedIndex = dgvDoc.SelectedRows[0].Index;

            KeywordForm form = new KeywordForm(pathList);
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (_mode == "favorite")
                    this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
                else if (_mode == "disc")
                    this.LoadDisc(GlobalService.RootTable, txtPath.Text);
                else
                    this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string name = dgvDoc.SelectedRows[0].Cells[1].Value.ToString();
            string type = dgvDoc.SelectedRows[0].Cells[7].Value.ToString();
            string path = dgvDoc.SelectedRows[0].Cells[8].Value.ToString();
            string vpath = dgvDoc.SelectedRows[0].Cells[9].Value.ToString();

            GlobalService.SelectedIndex = dgvDoc.SelectedRows[0].Index;

            RenameForm form = new RenameForm(name, path, type == "folder" ? "folder" : "file", vpath);
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (_mode == "favorite")
                    this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
                else if (_mode == "disc")
                    this.LoadDisc(GlobalService.RootTable, txtPath.Text);
                else
                {
                    GlobalService.RootTable = RootUtil.RootDataTable();

                    this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
                }
            }
        }

        private void markToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDoc.SelectedRows)
            {
                string name = row.Cells[1].Value.ToString();
                string type = row.Cells[7].Value.ToString();
                if (type == "file")
                {
                    string filePath = row.Cells[8].Value.ToString();
                    DataUtil.MarkAsFavorite(GlobalService.RootTable, filePath);
                }
                else
                {
                    //Debug.WriteLine(txtPath.Text + @"\" + name);
                    List<string> pathList = DataUtil.GetFolderPathList(GlobalService.RootTable, txtPath.Text + @"\" + name);
                    foreach(string path in pathList)
                        DataUtil.MarkAsFavorite(GlobalService.RootTable, path);
                    //foreach (string path in DataUtil.GetFolderPathList(GlobalService.RootTable, txtPath.Text + @"\" + name))
                       // DataUtil.MarkAsFavorite(GlobalService.RootTable, path);
                }
            }

            GlobalService.SelectedIndex = dgvDoc.SelectedRows[0].Index;

            if (_mode == "favorite")
                this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
            else if (_mode == "disc")
                this.LoadDisc(GlobalService.RootTable, txtPath.Text);
            else
                this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDoc.SelectedRows)
            {
                string name = row.Cells[1].Value.ToString();
                string type = row.Cells[7].Value.ToString();
                string vpath = row.Cells[9].Value.ToString();

                if (type == "file")
                {
                    string filePath = row.Cells[8].Value.ToString();
                    DataUtil.RemoveFromFavorite(GlobalService.RootTable, filePath);
                }
                else
                {
                    string folderPath = "";

                    string division = GlobalService.Division;

                    if (_mode == "favorite")
                        if (vpath.StartsWith(@"\Documents\" + division) || vpath.StartsWith(@"\Documents\Common") || vpath.StartsWith(@"\Documents\23600"))
                            folderPath = vpath.Substring(10);
                        else
                            folderPath = txtPath.Text + @"\" + name;
                    else
                        folderPath = txtPath.Text + @"\" + name;

                    List<string> pathList = DataUtil.GetFolderPathList(GlobalService.RootTable, folderPath);
                    foreach (string path in pathList)
                        DataUtil.RemoveFromFavorite(GlobalService.RootTable, path);
                }
            }

            GlobalService.SelectedIndex = dgvDoc.SelectedRows[0].Index;

            if (_mode == "favorite")
                this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
            else if (_mode == "disc")
                this.LoadDisc(GlobalService.RootTable, txtPath.Text);
            else
                this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<CopyFileList> copyList = new List<CopyFileList>();

            foreach (DataGridViewRow row in dgvDoc.SelectedRows)
            {
                string name = row.Cells[1].Value.ToString();
                string type = row.Cells[7].Value.ToString();

                if (type == "folder")
                {
                    foreach (string path in DataUtil.GetFolderPathList(GlobalService.RootTable, txtPath.Text + @"\" + name))
                    {
                        string fileName = RootUtil.GetFileName(GlobalService.RootTable, path);
                        string keyword = RootUtil.GetKeyword(GlobalService.RootTable, path);
                        string owner = RootUtil.GetOwner(GlobalService.RootTable, path);
                        string vpath = RootUtil.GetSavedPath(GlobalService.RootTable, path);

                        copyList.Add(new CopyFileList { FileName = fileName, Keyword = keyword, Owner = owner, FilePath = path, SavedPath = vpath });
                    }
                }
                else
                {
                    string keyword = row.Cells[2].Value.ToString();
                    string owner = row.Cells[5].Value.ToString();
                    string filePath = row.Cells[8].Value.ToString();
                    string fileVpath = row.Cells[9].Value.ToString();

                    copyList.Add(new CopyFileList { FileName = name, Keyword = keyword, Owner = owner, FilePath = filePath, SavedPath = fileVpath });
                }
            }

            if (copyList.Count > 0)
            {
                CopyForm form = new CopyForm(copyList);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (_mode == "favorite")
                        this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
                    else if (_mode == "disc")
                        this.LoadDisc(GlobalService.RootTable, txtPath.Text);
                    else
                        this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
                }
            }
        }

        private void outlookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

            foreach (DataGridViewRow row in dgvDoc.SelectedRows)
            {
                string rowType = row.Cells[7].Value.ToString();
                if (rowType != "file")
                    continue;
                string rowPath = row.Cells[8].Value.ToString();
                mailItem.Attachments.Add(rowPath);
            }

            if (mailItem.Attachments.Count > 0)
                mailItem.Display(false);
        }

        private void attachmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDoc.SelectedRows)
            {
                string rowName = row.Cells[1].Value.ToString();
                string rowType = row.Cells[7].Value.ToString();
                if (rowType != "file")
                    continue;
                string rowModified = row.Cells[3].Value.ToString();
                string rowPath = row.Cells[8].Value.ToString();

                GlobalService.AttachmentList.RemoveAll(x => x.FilePath == rowPath);
                GlobalService.AttachmentList.Add(new AttachmentList { FileName = rowName, LastModified = rowModified, FilePath = rowPath });
            }
        }

        private void customLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dgvDoc.SelectedRows)
                {
                    string type = row.Cells[7].Value.ToString();
                    
                    if (type == "folder")
                    {
                        string name = row.Cells[1].Value.ToString();
                        string vpath = row.Cells[9].Value.ToString();

                        DataRow[] rows = (from dr in GlobalService.RootTable.AsEnumerable()
                                          where dr.RowState != DataRowState.Deleted && dr.Field<string>("vpath").StartsWith(vpath)
                                          select dr).ToArray();

                        foreach (DataRow dr in rows)
                        {
                            string filePath = dr["filepath"].ToString();
                            string fileVpath = dr["vpath"].ToString();

                            string folder = fileVpath.StartsWith(@"\Documents\") ? fileVpath.Substring(10)
                           : fileVpath.StartsWith(@"\Common\") ? fileVpath.Substring(8) : fileVpath.Substring(7);

                            string targetDest = fbd.SelectedPath + @"\" + folder.Substring(folder.IndexOf(name));

                            if (!Directory.Exists(targetDest))
                                Directory.CreateDirectory(targetDest);

                            FileInfo info = new FileInfo(filePath);
                            File.Copy(filePath, targetDest + @"\" + info.Name, true);
                        }
                    }
                    else
                    {
                        string path = row.Cells[8].Value.ToString();

                        FileInfo info = new FileInfo(path);
                        File.Copy(path, fbd.SelectedPath + @"\" + info.Name, true);
                    }
                }

                dgvDoc.ClearSelection();

                Process.Start(fbd.SelectedPath);
            }
        }

        private void personalStorageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string destination;
            SHGetKnownFolderPath(Downloads, 0, IntPtr.Zero, out destination);

            foreach (DataGridViewRow row in dgvDoc.SelectedRows)
            {
                string type = row.Cells[7].Value.ToString();

                if (type == "folder")
                {
                    string name = row.Cells[1].Value.ToString();
                    string vpath = row.Cells[9].Value.ToString();

                    DataRow[] rows = (from dr in GlobalService.RootTable.AsEnumerable()
                                      where dr.RowState != DataRowState.Deleted && dr.Field<string>("vpath").StartsWith(vpath)
                                      select dr).ToArray();

                    foreach (DataRow dr in rows)
                    {
                        string filePath = dr["filepath"].ToString();
                        string fileVpath = dr["vpath"].ToString();

                        string folder = fileVpath.StartsWith(@"\Documents\") ? fileVpath.Substring(10)
                       : fileVpath.StartsWith(@"\Common\") ? fileVpath.Substring(8) : fileVpath.Substring(7);

                        string targetDest = destination + @"\MyCloud\" + folder.Substring(folder.IndexOf(name));

                        if (!Directory.Exists(targetDest))
                            Directory.CreateDirectory(targetDest);

                        FileInfo info = new FileInfo(filePath);
                        File.Copy(filePath, targetDest + @"\" + info.Name, true);
                    }
                }
                else
                {
                    string path = row.Cells[8].Value.ToString();

                    FileInfo info = new FileInfo(path);
                    File.Copy(path, destination + @"\MyCloud\" + info.Name, true);
                }
            }

            dgvDoc.ClearSelection();

            Process.Start(destination + @"\MyCloud");
        }

        private void personalStorageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Are you sure to store data to Personal Storage?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:

                    string storage = @"\\kdthk-dm1\bc_" + AdUtil.getAccount("kmhk.local") + "$";

                    List<string> queryList = new List<string>();

                    foreach (DataGridViewRow row in dgvDoc.SelectedRows)
                    {
                        string type = row.Cells[7].Value.ToString();
         
                        if (type == "folder")
                        {
                            string vpath = row.Cells[9].Value.ToString();

                            List<string> pathList = DataUtil.GetFolderPathList(GlobalService.RootTable, vpath);

                            foreach (string path in pathList)
                            {
                                string filename = Path.GetFileName(path);
                                string folder = vpath.Replace(@"\Documents", "");

                                if (!Directory.Exists(storage + folder))
                                    Directory.CreateDirectory(storage + folder);

                                File.Copy(path, Path.Combine(storage + folder, filename), true);
                            }
                        }
                        else
                        {
                            string filename = row.Cells[1].Value.ToString();
                            string path = row.Cells[8].Value.ToString();
                            string folder = row.Cells[9].Value.ToString().Replace(@"\Documents", "");
                            string extension = Path.GetExtension(path);

                            //string storedPath = path.Contains("'") ? path.Replace("'", "''") : path;
                            File.Copy(path, Path.Combine(storage + @"\" + folder, filename + extension), true);
                        }
                    }

                    break;

                case DialogResult.No:
                    break;
            }
        }

        private void localDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<RelocateList> list = new List<RelocateList>();

            foreach (DataGridViewRow row in dgvDoc.SelectedRows)
            {
                string name = row.Cells[1].Value.ToString();
                string keyword = row.Cells[2].Value.ToString();
                string modified = row.Cells[3].Value.ToString();
                string owner = row.Cells[5].Value.ToString();
                string type = row.Cells[7].Value.ToString();
                string path = row.Cells[8].Value.ToString();
                string vpath = row.Cells[9].Value.ToString();

                if (type == "folder")
                {
                    List<string> fileList = DataUtil.GetFolderPathList(GlobalService.RootTable, vpath);
                    foreach (string file in fileList)
                    {
                        string fullVpath = DataUtil.GetVpath(file);
                        list.Add(new RelocateList { FilePath = file, SelectedType = type, Folder = name, Owner = owner, Keyword = DataUtil.GetData(GlobalService.RootTable, file, "keyword"), LastModified = DataUtil.GetData(GlobalService.RootTable, file, "modified"), Disc = DiscUtil.GetDiscStatus(GlobalService.RootTable, file), Vpath = fullVpath });
                    }
                }
                else
                {
                    string disc = DiscUtil.GetDiscStatus(GlobalService.RootTable, path);
                    list.Add(new RelocateList { FilePath = path, SelectedType = type, Folder = name, Owner = owner, Keyword = keyword, LastModified = modified, Disc = disc, Vpath = "" });
                }
            }

            RelocationForm form = new RelocationForm(list);
            if (form.ShowDialog() == DialogResult.OK)
            {
                GlobalService.RootTable = RootUtil.RootDataTable();
                this.LoadData(GlobalService.RootTable, GlobalService.SelectedVpath, _viewMode);
                txtPath.Text = GlobalService.SelectedVpath;

                tvFolder.Nodes.Clear();

                TreeviewUtil.LoadPersonalFolder(tvFolder, GlobalService.User);
            }
        }

        private void propertyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = dgvDoc.SelectedRows[0].Cells[8].Value.ToString();

            PropertyForm form = new PropertyForm(path);

            if (form.ShowDialog() == DialogResult.OK)
            {
                if (_mode == "favorite")
                    this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
                else if (_mode == "disc")
                    this.LoadDisc(GlobalService.RootTable, txtPath.Text);
                else
                    this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
            }
        }

        private void discToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (MessageBox.Show("Are you sure to delete selected item?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    foreach (DataGridViewRow row in dgvDoc.SelectedRows)
                    {
                        string type = row.Cells[7].Value.ToString();
                        string vpath = row.Cells[9].Value.ToString();
                        if (type == "file")
                        {
                            string filePath = row.Cells[8].Value.ToString();
                            DataUtil.DeleteData(GlobalService.RootTable, filePath);
                        }
                        else if (type == "folder")
                        {
                            List<string> pathList = DataUtil.GetFolderPathList(GlobalService.RootTable, vpath);
                            if (pathList.Count > 0)
                                foreach (string path in pathList)
                                    DataUtil.DeleteData(GlobalService.RootTable, path);
                        }
                        else
                            dgvDoc.Rows.Remove(row);
                    }

                    //dgvDoc.ReadOnly = true;

                    //DataUtil.SyncDataToServer();

                    dgvDoc.ClearSelection();

                    this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
                    break;

                case DialogResult.No:
                    break;
            }

        }

        #endregion

        private void dgvDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {

            }
        }

        private void txtPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.C)
                Clipboard.SetText(txtPath.Text);

            if (e.Control && e.KeyCode == Keys.V)
                txtPath.Text = Clipboard.GetText();

            if (e.KeyCode == Keys.Enter)
            {
                if (_mode == "favorite")
                    this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
                else if (_mode == "disc")
                    this.LoadDisc(GlobalService.RootTable, txtPath.Text);
                else
                    this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
            }
        }

        private void txtPath_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void SearchData(DataTable table, string source)
        {
            if (source == "")
            {
                MessageBox.Show("Please input filename or keyword.");
                return;
            }

            //dgvDoc.Rows.Clear();

            //DataRow[] dataRow = table.Select(string.Format("filename like '%{0}%' or keyword like '%{0}%'", source));

            DataRow[] dataRow = (from dr in GlobalService.RootTable.AsEnumerable()
                                 where dr.RowState != DataRowState.Deleted && (dr.Field<string>("filename").ToLower().Contains(source.ToLower()) || dr.Field<string>("keyword").ToLower().Contains(source.ToLower()) || dr.Field<string>("fileowner").ToLower().Contains(source.ToLower()))
                                 select dr).ToArray();

            List<string> folderList = new List<string>();
            List<string> fileList = new List<string>();

            DataTable outputTable = new DataTable();
            outputTable.Columns.Add("img", typeof(Image));
            string[] headers = { "filename", "keyword", "modified", "shared", "owner", "read", "type", "path", "vpath", "delete" };
            foreach (string header in headers)
                outputTable.Columns.Add(header);
            outputTable.Columns.Add("fav", typeof(Image));
            outputTable.Columns.Add("disc", typeof(Image));

            foreach (DataRow row in dataRow)
            {
                string fileName = row.ItemArray[0].ToString().Trim();
                string keyword = row.ItemArray[1].ToString().Trim();
                string modified = row.ItemArray[2].ToString();
                string access = row.ItemArray[3].ToString();
                string owner = row.ItemArray[4].ToString().Trim();
                string shared = row.ItemArray[5].ToString().Trim();
                string path = row.ItemArray[6].ToString().Trim();
                string vpath = row.ItemArray[7].ToString().Trim();
                string count = row.ItemArray[8].ToString();
                string favorite = row.ItemArray[9].ToString().Trim();
                string disc = row.ItemArray[11].ToString().Trim();
                string delete = row.ItemArray[12].ToString().Trim();

                int sharedCount = 0;

                if (shared != "-")
                {
                    if (shared.Contains(";"))
                    {
                        string[] slist = shared.Split(';');
                        sharedCount = slist.Length;
                    }
                    else
                        sharedCount = 1;
                }

                if (fileList.Contains(path))
                    continue;

                fileList.Add(path);

                Image imgFavorite = favorite == "True" ? Properties.Resources.star_16 : Properties.Resources.star_gray_16;

                Image discStatus = disc == "False" ? Properties.Resources.status
                : disc == "Pending" ? Properties.Resources.status_away : Properties.Resources.status_busy;

                Image img;
                string imgPath = path.ToLower();

                if (imgPath.EndsWith(".xls") || imgPath.EndsWith(".xlsx") || imgPath.EndsWith(".xlsm") || imgPath.EndsWith(".csv"))
                    img = Properties.Resources.excel_16;
                else if (imgPath.EndsWith(".doc") || imgPath.EndsWith(".docx"))
                    img = Properties.Resources.word_16;
                else if (imgPath.EndsWith(".ppt") || imgPath.EndsWith(".pptx"))
                    img = Properties.Resources.powerpoint_16;
                else if (imgPath.EndsWith(".png") || imgPath.EndsWith(".jpg") || imgPath.EndsWith(".gif") || imgPath.EndsWith(".tiff") || imgPath.EndsWith(".jpeg") || imgPath.EndsWith(".bmp") || imgPath.EndsWith(".tif"))
                    img = Properties.Resources.picture;
                else if (imgPath.EndsWith(".pdf"))
                    img = Properties.Resources.pdf_16;
                else if (imgPath.EndsWith(".txt"))
                    img = Properties.Resources.text;
                else if (imgPath.EndsWith(".zip"))
                    img = Properties.Resources.zip_16;
                else
                    img = Properties.Resources.windows_16;

                //dgvDoc.Rows.Add(img, fileName, keyword, modified, sharedCount, owner, count, "file", path, vpath, imgFavorite, Properties.Resources.status);
                outputTable.Rows.Add(img, fileName, keyword, modified, sharedCount.ToString(), owner, count, "file", path, vpath, delete, imgFavorite, discStatus);
            }

            try
            {
                DirectoryInfo info = new DirectoryInfo(@"\\kdthk-dm1\moss$\HR\社內招聘");
                List<string> pathlist = new List<string>();// Directory.GetFiles(@"\\kdthk-dm1\moss$", "*.*", SearchOption.AllDirectories).ToList();
                SearchFiles(info, pathlist);

                foreach (string item in pathlist)
                {
                    if (item.Contains(txtSearch.Text))
                    {
                        Image imgNotice = Properties.Resources.information;
                        string path = Path.GetFileNameWithoutExtension(item);
                        outputTable.Rows.Add(imgNotice, path, "---", "---", "---", "---", "---", "notice", item, txtPath.Text, "---", Properties.Resources.star_gray_16, Properties.Resources.status);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }

            outputTable.DefaultView.Sort = "type, filename asc";
            outputTable = outputTable.DefaultView.ToTable();

            dgvDoc.DataSource = outputTable;
        }

        private void SearchFiles(DirectoryInfo info, List<string> fileList)
        {
            try
            {
                foreach (DirectoryInfo di in info.GetDirectories())
                    SearchFiles(di, fileList);
            }
            catch { }

            try
            {
                foreach (FileInfo fi in info.GetFiles())
                    fileList.Add(fi.FullName);
            }
            catch { }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                this.SearchData(GlobalService.RootTable, txtSearch.Text);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.SearchData(GlobalService.RootTable, txtSearch.Text);
        }

        private void dgvDoc_SelectionChanged(object sender, EventArgs e)
        {
        }

        private void tsbtnFavorite_Click(object sender, EventArgs e)
        {
            _mode = "favorite";

            this.LoadFavorite(GlobalService.RootTable, @"\Documents", "init");
        }

        private void tsbtnDisc_Click(object sender, EventArgs e)
        {
            _mode = "disc";

            this.LoadDisc(GlobalService.RootTable, @"\Documents");
        }

        private void tsbtnViewOwned_Click(object sender, EventArgs e)
        {
            _viewMode = "owned";

            tsbtnView.Text = "Owned";
            tsbtnView.Image = Properties.Resources.user_red;

            this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
        }

        private void tsbtnViewReceived_Click(object sender, EventArgs e)
        {
            _viewMode = "received";

            tsbtnView.Text = "Received";
            tsbtnView.Image = Properties.Resources.users;

            this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
        }

        private void tsbtnViewDefault_Click(object sender, EventArgs e)
        {
            _mode = "";

            _viewMode = "";

            tsbtnView.Text = "View";
            tsbtnView.Image = Properties.Resources.television;

            this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
        }

        private void tsbtnHome_Click(object sender, EventArgs e)
        {
            _mode = "";

            txtPath.Text = @"\Documents";

            this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
        }

        private void locateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string vpath = dgvDoc.SelectedRows[0].Cells[9].Value.ToString();

            txtSearch.Clear();

            txtPath.Text = vpath;

            this.LoadData(GlobalService.RootTable, vpath, _viewMode);
        }

        private void addressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = dgvDoc.SelectedRows[0].Cells[8].Value.ToString();

            Clipboard.SetText(path);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> pathlist = new List<string>();
            OutsideShareForm form = new OutsideShareForm(pathlist);
            form.ShowDialog();
        }

        private void requestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<PendingList> pendingList = new List<PendingList>();

            foreach (DataGridViewRow row in dgvDoc.SelectedRows)
            {
                string type = row.Cells[7].Value.ToString();

                if (type == "folder")
                {
                    string vpath = row.Cells[9].Value.ToString();

                    string sVpath = vpath.Contains("'") ? vpath.Replace("'", "''") : vpath;

                    DataRow[] rows = (from dr in GlobalService.RootTable.AsEnumerable()
                                      where dr.RowState != DataRowState.Deleted && dr.Field<string>("vpath").StartsWith(vpath)
                                      select dr).ToArray();

                    foreach (DataRow dr in rows)
                    {
                        dr["disc"] = "Pending";

                        string path = dr["filepath"].ToString();
                        if (path.Contains("'"))
                            path = path.Replace("'", "''");

                        List<string> sharedList = new List<string>();

                        sharedList = DataUtil.GetSharedList(GlobalService.DbTable, path);

                        foreach (string shared in sharedList)
                        {
                            try
                            {
                                Debug.WriteLine(shared.Trim());
                                string tableName = "TB_" + AdUtil.GetUserIdByUsername(shared.Trim());

                                string sharedText = string.Format("update " + tableName + " set r_disc = 'Pending' where r_path = '{0}'", path);
                                //QueryUtil.InsertDataToLocalDb(sharedText);
                                DataService.GetInstance().ExecuteNonQuery(sharedText);
                            }
                            catch(Exception ex)
                            {
                                Debug.WriteLine(ex.Message + ex.StackTrace);
                                continue;
                            }
                        }

                        string text = string.Format("update " + GlobalService.DbTable + " set r_disc = 'Pending' where r_path = '{0}'", path);
                        //QueryUtil.InsertDataToLocalDb(text);
                        DataService.GetInstance().ExecuteNonQuery(text);

                        pendingList.Add(new PendingList { FilePath = dr["filepath"].ToString(), FileName = dr["filename"].ToString() });
                    }
                }
                else
                {
                    string fileName = row.Cells[1].Value.ToString();
                    string filePath = row.Cells[8].Value.ToString();

                    string sPath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

                    DataRow[] rows = (from dr in GlobalService.RootTable.AsEnumerable()
                                      where dr.RowState != DataRowState.Deleted && dr.Field<string>("filepath") == filePath
                                      select dr).ToArray();

                    foreach (DataRow dr in rows)
                    {
                        dr["disc"] = "Pending";

                        string path = dr["filepath"].ToString();
                        if (path.Contains("'"))
                            path = path.Replace("'", "''");

                        List<string> sharedList = new List<string>();

                        sharedList = DataUtil.GetSharedList(GlobalService.DbTable, path);

                        foreach (string shared in sharedList)
                        {
                            try
                            {
                                Debug.WriteLine(shared.Trim());
                                string tableName = "TB_" + AdUtil.GetUserIdByUsername(shared.Trim());

                                string sharedText = string.Format("update " + tableName + " set r_disc = 'Pending' where r_path = '{0}'", path);
                                //QueryUtil.InsertDataToLocalDb(sharedText);
                                DataService.GetInstance().ExecuteNonQuery(sharedText);
                            }
                            catch(Exception ex)
                            {
                                Debug.WriteLine(ex.Message + ex.StackTrace);
                                continue;
                            }
                        }

                        string text = string.Format("update " + GlobalService.DbTable + " set r_disc = 'Pending' where r_path = '{0}'", path);
                        //QueryUtil.InsertDataToLocalDb(text);
                        DataService.GetInstance().ExecuteNonQuery(text);
                    }

                    pendingList.Add(new PendingList { FilePath = filePath, FileName = fileName });
                }
            }

            foreach (PendingList item in pendingList)
            {
                string query = string.Format("insert into TB_DISC_REQUEST (d_datetime, d_requester, d_filename, d_path) values ('{0}', N'{1}', N'{2}', N'{3}')", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), GlobalService.User, item.FileName, item.FilePath);
                DataService.GetInstance().ExecuteNonQuery(query);
            }

            GlobalService.SelectedIndex = dgvDoc.SelectedRows[0].Index;

            if (_mode == "favorite")
                this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
            else if (_mode == "disc")
                this.LoadDisc(GlobalService.RootTable, txtPath.Text);
            else
                this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
        }

        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDoc.SelectedRows)
            {
                string type = row.Cells[7].Value.ToString();

                if (type == "folder")
                {
                    string vpath = row.Cells[9].Value.ToString();

                    string sVpath = vpath.Contains("'") ? vpath.Replace("'", "''") : vpath;

                    DataRow[] rows = (from dr in GlobalService.RootTable.AsEnumerable()
                                      where dr.RowState != DataRowState.Deleted && dr.Field<string>("vpath").StartsWith(vpath)
                                      select dr).ToArray();

                    foreach (DataRow dr in rows)
                    {
                        dr["disc"] = "False";

                        string path = dr["filepath"].ToString();
                        if (path.Contains("'"))
                            path = path.Replace("'", "''");

                        List<string> sharedList = new List<string>();

                        sharedList = DataUtil.GetSharedList(GlobalService.DbTable, path);

                        foreach (string shared in sharedList)
                        {
                            string tableName = "TB_" + AdUtil.GetUserIdByUsername(shared.Trim());

                            string sharedText = string.Format("update " + tableName + " set r_disc = 'False' where r_path = '{0}'", path);
                            DataService.GetInstance().ExecuteNonQuery(sharedText);
                            //QueryUtil.InsertDataToLocalDb(sharedText);
                        }

                        string text = string.Format("update " + GlobalService.DbTable + " set r_disc = 'False' where r_path = '{0}'", path);
                        DataService.GetInstance().ExecuteNonQuery(text);
                        //QueryUtil.InsertDataToLocalDb(text);
                    }
                }
                else
                {
                    string fileName = row.Cells[1].Value.ToString();
                    string filePath = row.Cells[8].Value.ToString();

                    string sPath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

                    DataRow[] rows = (from dr in GlobalService.RootTable.AsEnumerable()
                                      where dr.RowState != DataRowState.Deleted && dr.Field<string>("filepath") == filePath
                                      select dr).ToArray();

                    foreach (DataRow dr in rows)
                    {
                        dr["disc"] = "False";

                        string path = dr["filepath"].ToString();
                        if (path.Contains("'"))
                            path = path.Replace("'", "''");

                        List<string> sharedList = new List<string>();

                        sharedList = DataUtil.GetSharedList(GlobalService.DbTable, path);

                        foreach (string shared in sharedList)
                        {
                            string tableName = "TB_" + AdUtil.GetUserIdByUsername(shared.Trim());

                            string sharedText = string.Format("update " + tableName + " set r_disc = 'False' where r_path = N'{0}'", path);
                            DataService.GetInstance().ExecuteNonQuery(sharedText);
                            //QueryUtil.InsertDataToLocalDb(sharedText);
                        }

                        string text = string.Format("update " + GlobalService.DbTable + " set r_disc = 'False' where r_path = N'{0}'", path);
                        DataService.GetInstance().ExecuteNonQuery(text);
                        //QueryUtil.InsertDataToLocalDb(text);
                    }
                }
            }

            if (_mode == "favorite")
                this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
            else if (_mode == "disc")
                this.LoadDisc(GlobalService.RootTable, txtPath.Text);
            else
                this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
        }

        private void AutoDelete_Clicked(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            string tag = item.Tag.ToString();

            List<string> pathList = new List<string>();

            foreach (DataGridViewRow row in dgvDoc.SelectedRows)
            {
                string type = row.Cells[7].Value.ToString();

                if (type == "newfolder")
                    continue;
                else if (type == "file")
                {
                    string path = row.Cells[8].Value.ToString();
                    pathList.Add(path);
                }
                else
                {
                    string vpath = row.Cells[9].Value.ToString();
                    List<string> tmpList = DataUtil.GetFolderPathList(GlobalService.RootTable, vpath);
                    foreach (string path in tmpList)
                        pathList.Add(path);
                }
            }

            foreach (string path in pathList)
            {   
                string autoDelete = tag == "none" ? "2099/12/31"
                : tag == "7days" ? DateTime.Today.AddDays(7).ToString("yyyy/MM/dd")
                : tag == "30days" ? DateTime.Today.AddDays(30).ToString("yyyy/MM/dd")
                : tag == "60days" ? DateTime.Today.AddDays(60).ToString("yyyy/MM/dd")
                : DateTime.Today.AddDays(90).ToString("yyyy/MM/dd");

                DataRow[] rows = (from dr in GlobalService.RootTable.AsEnumerable()
                                      where dr.RowState != DataRowState.Deleted && dr.Field<string>("filepath") == path
                                      select dr).ToArray();

                foreach (DataRow dr in rows)
                    if (!autoDelete.Contains("2099"))
                        dr["delete"] = (Convert.ToDateTime(autoDelete) - DateTime.Today).TotalDays.ToString();
                    else
                        dr["delete"] = "-";

                string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

                string text = string.Format("update " + GlobalService.DbTable + " set r_deletedate = '{0}' where r_path = N'{1}'", autoDelete, sPath);
                DataService.GetInstance().ExecuteNonQuery(text);
                //QueryUtil.InsertDataToLocalDb(text);
            }

            GlobalService.SelectedIndex = dgvDoc.SelectedRows[0].Index;

            if (_mode == "favorite")
                this.LoadFavorite(GlobalService.RootTable, txtPath.Text, "");
            else if (_mode == "disc")
                this.LoadDisc(GlobalService.RootTable, txtPath.Text);
            else
                this.LoadData(GlobalService.RootTable, txtPath.Text, _viewMode);
        }

        private void filesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadFile();
        }

        private void folderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UploadFolder();
        }

        private void btnShareLink_Click(object sender, EventArgs e)
        {
            string path = @"\\\\kdthk-dm1\project\KDTHK-DM\temp\" + AdUtil.GetUserIdByUsername(GlobalService.User);

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //File.Create(path);

            using (StreamWriter sw = new StreamWriter(path + @"\sharelink.bat"))
            {
                //sw.WriteLine("\"C:\\Users\\hk120027\\Documents\\visual studio 2010\\Projects\\MyCloudLinkGenerator\\MyCloudLinkGenerator\\bin\\Debug\\MyCloudLinkGenerator.exe\" " + txtPath.Text + "");
                sw.WriteLine("\"\\\\kdthk-dm1\\project\\IT System\\test program\\test\\MyCloudLinkGenerator.exe\" " + txtPath.Text + "");
                //sw.WriteLine("\"C:\\Users\\hk120027\\AppData\\Roaming\\Microsoft\\Windows\\Start Menu\\Programs\\Microsoft\\LinkGenerator.appref-ms\" " + txtPath.Text + "");
            }

            Microsoft.Office.Interop.Outlook.Application app = new Microsoft.Office.Interop.Outlook.Application();
            Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem);

            //string text = "<a href=\"\\\\kdthk-dm1\\project\\IT System\\MyCloud Beta\\KDTHK-DM-SP.application\" link>MyCloud Link</a>";
            string text = "<a href=\"" + path + @"\sharelink.bat" + "\">MyCloud Link</a>";
            string content = "<p><span style=\"font-family: Calibri;\">" + text + "</span></p>";

            mailItem.HTMLBody = content;
            mailItem.Display(false);
        }
    }
}
