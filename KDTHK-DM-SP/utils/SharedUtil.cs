using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KDTHK_DM_SP.services;
using CustomUtil.utils.authentication;
using System.IO;
using System.Diagnostics;
using System.Data;

namespace KDTHK_DM_SP.utils
{
    public class SharedUtil
    {
        public static void UpdateEmptyShared()
        {
            string query = "update " + GlobalService.DbTable + " set r_shared = '-' where r_shared = ''";
            DataService.GetInstance().ExecuteNonQuery(query);
        }

        public static void UpdateShared()
        {
            string query = "update " + GlobalService.DbTable + " set r_shared = stuff(r_shared, 1, 1, '') where r_shared like ';%'";
            DataService.GetInstance().ExecuteNonQuery(query);
        }

        public static void AutoDeleteData()
        {
            List<string> pathList = new List<string>();
            string q1 = string.Format("select r_path from " + GlobalService.DbTable + " where r_deletedate <= getdate() and r_owner = N'{0}'", GlobalService.User);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(q1))
            {
                while (reader.Read())
                    pathList.Add(reader.GetString(0).Trim());
            }

            pathList = pathList.Distinct().ToList();

            foreach (string path in pathList)
            {
                List<string> sharedList = DataUtil.GetSharedList(GlobalService.DbTable, path);

                string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

                foreach (string shared in sharedList)
                {
                    if (shared == "-")
                        continue;

                    if (!UserUtil.IsCnMember(shared.Trim()) && !UserUtil.IsVnMember(shared.Trim()) && !UserUtil.IsJpMember(shared.Trim()))
                    {
                        try
                        {
                            string tableName = "TB_" + AdUtil.GetUserIdByUsername(shared.Trim(), "kmhk.local");
                            string sharedText = string.Format("delete from " + tableName + " where r_path = N'{0}'", sPath);
                            DataService.GetInstance().ExecuteNonQuery(sharedText);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Shared: " + shared);
                            Debug.WriteLine(ex.Message + ex.StackTrace);
                        }
                    }
                    else
                    {
                        string sharedText = string.Format("delete from TB_OUTSIDE_SHARE where o_path = N'{0}'", sPath);
                        DataService.GetInstance().ExecuteNonQuery(sharedText);
                    }
                }
            }

            string query = "delete from " + GlobalService.DbTable + " where r_deletedate <= getdate()";
            DataService.GetInstance().ExecuteNonQuery(query);

        }

        public static void SharedCN(List<string> cnlist, string filePath, string filename, string keyword)
        {
            foreach (string cnPerson in cnlist)
            {
                string staffno = UserUtil.GetCnUserStaffNo(cnPerson);

                string id = AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local");

                string directory = @"\\kdthk-dm1\project\KDTHK-DM\littlecloud\";
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                string nfilepath = filePath.Replace("''", "'");

                string newFileName = Path.GetFileName(nfilepath);
                string newFilePath = directory + newFileName;

                if (!File.Exists(newFilePath))
                    File.Copy(nfilepath, newFilePath, true);

                if (newFilePath.Contains("'"))
                    newFilePath = newFilePath.Replace("'", "''");

                string query = string.Format("if not exists (select * from S_OUT_SHARE where o_pathnew = N'{8}' and o_from = N'{4}' and o_toid = '{5}') " +
                    "insert into S_OUT_SHARE (o_path, o_filename, o_keyword, o_fromid, o_from, o_toid, o_to, o_date, o_pathnew) values (N'{0}', N'{1}', N'{2}', '{3}', N'{4}', '{5}', N'{6}', '{7}', N'{8}')",
                    filePath, filename, keyword, id, GlobalService.User, staffno, cnPerson, DateTime.Today.ToString("yyyy/MM/dd"), newFilePath);

                //Debug.WriteLine("Query: " + query);

                //DataService.GetInstance().ExecuteNonQuery(query);
                DataServiceMes.GetInstance().ExecuteNonQuery(query);

                UpdateFilePath(filePath, newFilePath);
            }
        }

        public static void SharedVN(List<string> vnlist, string filePath, string filename, string keyword)
        {
            foreach (string vnPerson in vnlist)
            {
                string staffno = UserUtil.GetVnUserStaffNo(vnPerson);

                string id = AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local");

                string directory = @"\\kdthk-dm1\project\KDTHK-DM\littlecloud\";
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                string nfilepath = filePath.Replace("''", "'");

                string newFileName = Path.GetFileName(nfilepath);
                string newFilePath = directory + newFileName;

                if (!File.Exists(newFilePath))
                    File.Copy(nfilepath, newFilePath, true);

                if (newFilePath.Contains("'"))
                    newFilePath = newFilePath.Replace("'", "''");

                string query = string.Format("if not exists (select * from S_OUT_SHARE where o_path = N'{0}' and o_from = N'{4}' and o_toid = '{5}') " +
                    "insert into S_OUT_SHARE (o_path, o_filename, o_keyword, o_fromid, o_from, o_toid, o_to, o_date, o_pathnew) values (N'{0}', N'{1}', N'{2}', '{3}', N'{4}', '{5}', N'{6}', '{7}', N'{8}')",
                    filePath, filename, keyword, id, GlobalService.User, staffno, vnPerson, DateTime.Today.ToString("yyyy/MM/dd"), newFilePath);
                //DataService.GetInstance().ExecuteNonQuery(query);
                DataServiceMes.GetInstance().ExecuteNonQuery(query);

                UpdateFilePath(filePath, newFilePath);
            }
        }

        public static void SharedJp(List<string> jplist, string filePath, string filename, string keyword)
        {
            foreach (string jpPerson in jplist)
            {
                string staffno = UserUtil.GetJpUserStaffNo(jpPerson);

                string id = AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local");

                string directory = @"\\kdthk-dm1\project\KDTHK-DM\littlecloud\";
                if (!Directory.Exists(directory))
                    Directory.CreateDirectory(directory);

                string nfilepath = filePath.Replace("''", "'");

                string newFileName = Path.GetFileName(nfilepath);
                string newFilePath = directory + newFileName;
                if (!File.Exists(newFilePath))
                    File.Copy(nfilepath, newFilePath, true);

                if (newFilePath.Contains("'"))
                    newFilePath = newFilePath.Replace("'", "''");

                string query = string.Format("if not exists (select * from S_OUT_SHARE where o_path = N'{0}' and o_from = N'{4}' and o_toid = '{5}') " +
                    "insert into S_OUT_SHARE (o_path, o_filename, o_keyword, o_fromid, o_from, o_toid, o_to, o_date, o_pathnew) values (N'{0}', N'{1}', N'{2}', '{3}', N'{4}', '{5}', N'{6}', '{7}', N'{8}')",
                    filePath, filename, keyword, id, GlobalService.User, staffno, jpPerson, DateTime.Today.ToString("yyyy/MM/dd"), newFilePath);
                //DataService.GetInstance().ExecuteNonQuery(query);

                DataServiceMes.GetInstance().ExecuteNonQuery(query);

                UpdateFilePath(filePath, newFilePath);
            }
        }

        public static void UpdateFilePath(string oldPath, string newPath)
        {
            List<string> sharedList = new List<string>();

            string text = string.Format("select r_shared from " + GlobalService.DbTable + " where r_path = N'{0}' and r_owner = N'{1}'", oldPath, GlobalService.User);
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(text))
            {
                while (reader.Read())
                {
                    string shared = reader.GetString(0).Trim();
                    if (shared != "-" && shared != "")
                        sharedList = shared.Split(';').ToList();
                }
            }

            string query = string.Format("update " + GlobalService.DbTable + " set r_path = N'{1}' where r_path = N'{0}'", oldPath, newPath);
            DataService.GetInstance().ExecuteNonQuery(query);

            foreach (string shared in sharedList)
            {
                try
                {
                    string tableName = "TB_" + AdUtil.GetUserIdByUsername(shared.Trim(), "kmhk.local");

                    string sharedText = string.Format("update " + tableName + " set r_path = N'{1}' where r_path = N'{0}' and r_owner = N'{2}'", oldPath, newPath, GlobalService.User);
                    DataService.GetInstance().ExecuteNonQuery(sharedText);
                }
                catch
                {
                    continue;
                }
            }
            
        }
    }
}
