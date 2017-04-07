using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KDTHK_DM_SP.services;
using System.Diagnostics;
using System.Data.SqlServerCe;
using System.IO;
using CustomUtil.utils.authentication;
using KDTHK_DM_SP.lists;

namespace KDTHK_DM_SP.utils
{
    public class DataUtil
    {
        public static void SyncDataToServer()
        {
            string query = "select q_query from LTB_QUERY";

            List<string> list = new List<string>();

            using (SqlCeDataReader reader = LocalDataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    list.Add(reader.GetString(0));
            }

            foreach (string text in list)
                DataService.GetInstance().ExecuteNonQuery(text);

            string delText = "delete from LTB_QUERY";
            //LocalDataService.GetInstance().ExecuteNonQuery(delText);
        }

        public static void AddReadCount(DataTable table, string path)
        {
            string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

            //DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == path
                              select row).ToArray();

            string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            foreach (DataRow row in rows)
            {
                row["readcount"] = (int)row["readcount"] + 1;
                row["access"] = now;

                string text = string.Format("update " + GlobalService.DbTable + " set r_count = '{0}', r_lastaccess = '{1}' where r_path = N'{2}'", row["readcount"], now, sPath);
                DataService.GetInstance().ExecuteNonQuery(text);
                //QueryUtil.InsertDataToLocalDb(text);
            }
        }

        public static void UpdateModifiedDate(string path)
        {
            FileInfo info = new FileInfo(path);
            string lastModified = info.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss");

            if (path.Contains("'"))
                path = path.Replace("'", "''");

            string query = string.Format("update " + GlobalService.DbTable + " set r_lastmodified = '{0}' where r_path = N'{1}'", lastModified, path);
            DataService.GetInstance().ExecuteNonQuery(query);
        }

        public static void DeleteData(DataTable table, string path)
        {
            string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

            //DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == path
                              select row).ToArray();

            List<string> queryList = new List<string>();

            foreach (DataRow row in rows)
            {
                string owner = row["fileowner"].ToString().Trim();

                if (owner == GlobalService.User)
                {
                    List<string> sharedList = GetSharedList(GlobalService.DbTable, sPath);

                    foreach (string shared in sharedList)
                    {
                        if (shared == "-")
                            continue;

                        if (!UserUtil.IsCnMember(shared.Trim()) && !UserUtil.IsVnMember(shared.Trim()) && !UserUtil.IsJpMember(shared.Trim()))
                        {
                            string tableName = "TB_" + AdUtil.GetUserIdByUsername(shared, "kmhk.local");
                            string sharedText = string.Format("delete from " + tableName + " where r_path = N'{0}'", sPath);
                            queryList.Add(sharedText);
                        }
                        else
                        {
                            string sharedText = string.Format("delete from TB_OUTSIDE_SHARE where o_path = N'{0}'", sPath);
                            queryList.Add(sharedText);
                        }
                    }

                    string ownerText = string.Format("delete from " + GlobalService.DbTable + " where r_path = N'{0}'", sPath);
                    queryList.Add(ownerText);

                    if (File.Exists(path))
                    {
                        if (GlobalService.User == UserUtil.HrUserName1())
                        //if (GlobalService.User == "Ling Wai Man(凌慧敏,Velma)")
                        {
                            string directory = @"\\kdthk-dm1\project\IT System\MyCloud Record\" + DateTime.Today.ToString("yyyyMMdd");
                            if (!Directory.Exists(directory))
                                Directory.CreateDirectory(directory);

                            string filename = Path.GetFileName(path);

                            File.Copy(path, directory + @"\" + filename);
                        }

                        File.Delete(path);
                    }

                    string delQuery = string.Format("delete from S_OUT_SHARE where o_path = N'{0}'", sPath);
                    DataServiceMes.GetInstance().ExecuteNonQuery(delQuery);
                }
                else
                {
                    string tableName = "TB_" + AdUtil.GetUserIdByUsername(owner, "kmhk.local");

                    List<string> sharedList = GetSharedList(tableName, sPath);
                    sharedList.Remove(GlobalService.User);

                    string shared = string.Join(";", sharedList.ToArray());

                    if (shared == "")
                        shared = "-";

                    string ownerText = string.Format("update " + tableName + " set r_shared = N'{0}' where r_path = N'{1}'", shared, sPath);
                    queryList.Add(ownerText);

                    string sharedText = string.Format("delete from " + GlobalService.DbTable + " where r_path = N'{0}'", sPath);
                    queryList.Add(sharedText);
                }

                if (row.RowState != DataRowState.Deleted)
                    row.Delete();
            }

            string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string query = string.Format("insert into TB_LOG (log_datetime, log_category, log_path, log_by) values ('{0}', '{1}', N'{2}', N'{3}')", now, "Delete", sPath, GlobalService.User);
            queryList.Add(query);

            foreach (string text in queryList)
                DataService.GetInstance().ExecuteNonQuery(text);
                //QueryUtil.InsertDataToLocalDb(text);
        }

        public static void MarkAsFavorite(DataTable table, string path)
        {
            string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

            //DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == path
                              select row).ToArray();

            List<string> queryList = new List<string>();

            foreach (DataRow row in rows)
            {
                row["favorite"] = "True";

                string text = string.Format("update " + GlobalService.DbTable + " set r_favorite = '{0}' where r_path = N'{1}'", "True", sPath);
                DataService.GetInstance().ExecuteNonQuery(text);
                //QueryUtil.InsertDataToLocalDb(text);
            }
        }

        public static void RemoveFromFavorite(DataTable table, string path)
        {
            string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

            //DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == path
                              select row).ToArray();

            foreach (DataRow row in rows)
            {
                row["favorite"] = "False";

                string text = string.Format("update " + GlobalService.DbTable + " set r_favorite = '{0}' where r_path = N'{1}'", "False", sPath);
                DataService.GetInstance().ExecuteNonQuery(text);
                //QueryUtil.InsertDataToLocalDb(text);
            }
        }

        public static void ReceiveData(DataTable table, string path, string favorite)
        {
            string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

            //DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == path
                              select row).ToArray();

            List<string> queryList = new List<string>();

            foreach (DataRow row in rows)
            {
                row["checked"] = "True";

                string text = "";

                if (favorite == "Yes")
                    text = string.Format("update " + GlobalService.DbTable + " set r_checked = 'True', r_favorite = 'True' where r_path = N'{0}'", sPath);
                else
                    text = string.Format("update " + GlobalService.DbTable + " set r_checked = 'True' where r_path = N'{0}'", sPath);

                DataService.GetInstance().ExecuteNonQuery(text);
                //QueryUtil.InsertDataToLocalDb(text);
            }

            //DataUtil.SyncDataToServer();
        }

        public static void RelocateData(DataTable table, List<RelocateList> list, string targetVpath)
        {
            List<string> queryList = new List<string>();

            foreach (RelocateList relocateItem in list)
            {
                string sPath = relocateItem.FilePath.Contains("'") ? relocateItem.FilePath.Replace("'", "''") : relocateItem.FilePath;

                //DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

                DataRow[] rows = (from row in table.AsEnumerable()
                                  where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == relocateItem.FilePath
                                  select row).ToArray();

                foreach (DataRow row in rows)
                {
                    row["vpath"] = relocateItem.SelectedType == "file" ? targetVpath : targetVpath + @"\" + relocateItem.Folder;

                    string text = string.Format("update " + GlobalService.DbTable + " set r_vpath = N'{0}' where r_path = N'{1}'", row["vpath"].ToString(), sPath);
                    queryList.Add(text);
                }
            }

            foreach (string text in queryList)
                DataService.GetInstance().ExecuteNonQuery(text);
        }

        public static List<string> GetFolderPathList(DataTable table, string vpath)
        {
            List<string> list = new List<string>();

            //DataRow[] rows = table.Select(string.Format("vpath like '{0}%'", vpath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("vpath").StartsWith(vpath)
                              select row).ToArray();

            foreach (DataRow row in rows)
                list.Add(row["filepath"].ToString());

            //Debug.WriteLine("list count: " + list.Count);
            return list;
        }

        public static List<string> GetLocalSharedList(DataTable table, string path)
        {
            List<string> list = new List<string>();

            string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

            //DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == path
                              select row).ToArray();

            foreach (DataRow row in rows)
            {
                string shared = row["shared"].ToString();
                if (shared != "-")
                    list = shared.Split(';').ToList();
            }

            return list;
        }

        public static List<string> GetSharedList(string tableName, string path)
        {
            List<string> list = new List<string>();

            string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

            string query = string.Format("select r_shared from " + tableName + " where r_path = N'{0}' and r_shared != '-'", sPath);

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                    list = GlobalService.Reader.GetString(0).Split(';').ToList();
            }

            return list.Distinct().ToList();
        }

        public static bool IsAllFileDisc(DataTable table, string vpath)
        {
            bool isDisc = true;

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("vpath").StartsWith(vpath)
                              select row).ToArray();

            foreach (DataRow row in rows)
            {
                string disc = row["disc"].ToString().Trim();
                if (disc == "False")
                    isDisc = false;
            }

            return isDisc;
        }

        public static bool IsAllFileFavorite2(DataTable table, string vpath)
        {
            bool isFavorite = true;

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("vpath").StartsWith(vpath)
                              select row).ToArray();

            foreach (DataRow row in rows)
            {
                string favorite = row["favorite"].ToString().Trim();
                if ( favorite == "False")
                    isFavorite = false;
            }
            return isFavorite;
        }

        public static bool IsAllFileFavorite(string vpath)
        {
            bool isFavorite = true;

            string query = string.Format("select r_favorite from " + GlobalService.DbTable + " where r_vpath like N'{0}%'", vpath);

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                {
                    string favorite = GlobalService.Reader.GetString(0);
                    if (favorite == "False")
                        isFavorite = false;
                }
            }

            return isFavorite;
        }

        public static bool IsAllFileDisc(string vpath)
        {
            bool isDisc = true;

            string query = string.Format("select r_disc from " + GlobalService.DbTable + " where r_vpath like N'{0}%'", vpath);

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                {
                    string disc = GlobalService.Reader.GetString(0);
                    if (disc != "True")
                        isDisc = false;
                }
            }

            return isDisc;
        }

        public static bool IsVpathExists(DataTable table, string vpath)
        {
            string sVpath = vpath.Contains("'") ? vpath.Replace("'", "''") : vpath;

            //DataRow[] rows = table.Select(string.Format("vpath = '{0}'", sVpath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("vpath") == vpath
                              select row).ToArray();

            if (rows.Length > 0)
                return true;

            return false;
        }

        public static string GetData(DataTable table, string path, string option)
        {
            string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

            //DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == path
                              select row).ToArray();

            string result = option == "keyword" ? rows[0]["keyword"].ToString()
                : option == "modified" ? rows[0]["modified"].ToString() : "";

            return result;
        }

        public static string GetLastAccess(DataTable table, string path)
        {
            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == path
                              select row).ToArray();

            return rows[0]["access"].ToString();
        }

        public static bool IsRecordExists(string path)
        {
            bool isexist = false;

            if (path.Contains("'"))
                path = path.Replace("'", "''");

            string query = string.Format("select * from " + GlobalService.DbTable + " where r_path = N'{0}'", path);

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                if (GlobalService.Reader.HasRows)
                    isexist = true;
                else
                    isexist = false;
            }
            return isexist;
        }

        public static string GetVpath(string filepath)
        {
            string query = string.Format("select top 1 r_vpath from " + GlobalService.DbTable + " where r_path = N'{0}'", filepath);
            return DataService.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static bool ContainSubpath(string vpath)
        {
            string query = string.Format("select count(*) from " + GlobalService.DbTable + " where r_vpath like N'{0}%'", vpath);
            int result = (int)DataService.GetInstance().ExecuteScalar(query);
            return result > 0 ? true : false;
        }
    }
}
