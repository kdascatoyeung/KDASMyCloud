using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KDTHK_DM_SP.services;
using System.Diagnostics;
using System.Data.SqlClient;
using KDTHK_DM_SP.lists;

namespace KDTHK_DM_SP.utils
{
    public class RootUtil
    {
        public static DataTable RootDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("filename", typeof(string));
            table.Columns.Add("keyword", typeof(string));
            table.Columns.Add("modified", typeof(string));
            table.Columns.Add("access", typeof(string));
            table.Columns.Add("fileowner", typeof(string));
            table.Columns.Add("shared", typeof(string));
            table.Columns.Add("filepath", typeof(string));
            table.Columns.Add("vpath", typeof(string));
            table.Columns.Add("readcount", typeof(int));
            table.Columns.Add("favorite", typeof(string));
            table.Columns.Add("checked", typeof(string));
            table.Columns.Add("disc", typeof(string));
            table.Columns.Add("delete", typeof(string));

            /*string query = "select r_filename as filename, r_keyword as keyword, r_lastmodified as modified, r_lastaccess as access, r_owner as fileowner" +
                ", r_shared as shared, r_path as filepath, r_vpath as vpath, r_count as readcount, r_favorite as favorite, r_checked as checked, r_disc as disc from " + GlobalService.DbTable;

            using (SqlDataAdapter sda = new SqlDataAdapter(query, DataService.GetInstance().Connection))
            {
                sda.Fill(table);
            }*/

            //Debug.WriteLine(table.Rows.Count);

            Stopwatch sw = new Stopwatch();

            string query = "select r_filename, r_keyword, r_lastmodified, r_lastaccess, r_owner" +
                ", r_shared, r_path, r_vpath, r_count, r_favorite, r_checked, r_disc, r_deletedate from " + GlobalService.DbTable;

            sw.Start();

            table.BeginLoadData();

            //System.Windows.Forms.MessageBox.Show("Query: " + query);

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string fileName = reader.GetString(0);
                    string keyword = reader.GetString(1);
                    string lastModified = reader.GetString(2);
                    string lastAccess = reader.GetString(3);
                    string owner = reader.GetString(4);
                    string shared = reader.GetString(5);
                    string path = reader.GetString(6);
                    string vpath = reader.GetString(7);
                    int count = reader.GetInt32(8);
                    string favorite = reader.GetString(9).Trim();
                    string check = reader.GetString(10).Trim();
                    string disc = reader.GetString(11).Trim();
                    string autoDelete = reader.GetString(12).Trim();

                    if (autoDelete.Contains("2099"))
                        autoDelete = "-";
                    else
                    {
                        DateTime delete = Convert.ToDateTime(autoDelete);

                        autoDelete = (delete - DateTime.Today).TotalDays.ToString();
                    }

                    table.LoadDataRow(new object[] { fileName, keyword, lastModified, lastAccess, owner, shared, path, vpath, count, favorite, check, disc, autoDelete }, true);
                    //table.Rows.Add(fileName, keyword, lastModified, lastAccess, owner, shared, path, vpath, count, favorite, check, disc);
                }
            }

            table.EndLoadData();

            sw.Stop();

            Debug.WriteLine("Datatable: " + sw.Elapsed);
            return table;
        }

        public static string GetFileName(DataTable table, string filePath)
        {
            string sPath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

            //DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == filePath
                              select row).ToArray();

            string fileName = "";

            foreach (DataRow row in rows)
                fileName = row["filename"].ToString();

            return fileName;
        }

        public static string GetKeyword(DataTable table, string filePath)
        {
            string sPath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

            //DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == filePath
                              select row).ToArray();

            string keyword = "";

            foreach (DataRow row in rows)
                keyword = row["keyword"].ToString();

            return keyword;
        }

        public static string GetOwner(DataTable table, string filePath)
        {
            string sPath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

            //DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == filePath
                              select row).ToArray();

            string owner = "";

            foreach (DataRow row in rows)
                owner = row["fileowner"].ToString();

            return owner;
        }

        public static string GetSavedPath(DataTable table, string filePath)
        {
            string sPath = filePath.Contains("'") ? filePath.Replace("'", "''") : filePath;

            //DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == filePath
                              select row).ToArray();

            string savedPath = "";

            foreach (DataRow row in rows)
                savedPath = row["vpath"].ToString();

            return savedPath;
        }
    }
}
