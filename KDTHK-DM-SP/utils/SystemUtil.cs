using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;
using System.IO;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using System.Runtime.InteropServices;
using KDTHK_DM_SP.xmls;

namespace KDTHK_DM_SP.utils
{
    public class SystemUtil
    {
        public static bool IsNetworkAvailable()
        {
            return NetworkInterface.GetIsNetworkAvailable();
        }

        public static bool IsFileInUse(FileInfo info)
        {
            FileStream stream = null;

            try
            {
                stream = info.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                MessageBox.Show("The file is unavailable because it is still being processed.");
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        public static string GetDivision(string person)
        {
            string query = string.Format("select fd_name from TB_DIVISION_FOLDER where fd_staff = N'{0}'", person);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetDepartment(string person)
        {
            string query = string.Format("select fd_dept from TB_DIVISION_FOLDER where fd_staff = N'{0}'", person);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static List<string> DivisionMember(string person)
        {
            List<string> list = new List<string>();

            string query = string.Format("select fd_staff from TB_DIVISION_FOLDER where fd_name = (select fd_name from TB_DIVISION_FOLDER" +
                " where fd_staff = N'{0}') and fd_staff != N'{0}'", person);

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                    list.Add(GlobalService.Reader.GetString(0));
            }

            list = list.Distinct().ToList();

            return list;
        }

        public static List<string> DepartmentMember(string person)
        {
            List<string> list = new List<string>();

            string query = string.Format("select fd_staff from TB_DIVISION_FOLDER where fd_dept = (select fd_dept from TB_DIVISION_FOLDER" +
               " where fd_staff = N'{0}') and fd_staff != N'{0}'", person);

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                    list.Add(GlobalService.Reader.GetString(0));
            }

            list = list.Distinct().ToList();

            return list;
        }

        public static List<AppsInfo> AppsList()
        {
            List<AppsInfo> list = new List<AppsInfo>();

            string query = string.Format("select f_category, f_name, f_path, f_description, f_lastAccess from TB_APPLICATION where f_staff = N'{0}'", GlobalService.User);

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                {
                    string category = GlobalService.Reader.GetString(0);
                    string fileName = GlobalService.Reader.GetString(1);
                    string filePath = GlobalService.Reader.GetString(2);
                    string desc = GlobalService.Reader.GetString(3);
                    string lastAccess = GlobalService.Reader.GetString(4);

                    list.Add(new AppsInfo { Category = category, FileName = fileName, FilePath = filePath, LastAccess = lastAccess, Description = desc });
                }
            }

            return list;
        }
    }
}
