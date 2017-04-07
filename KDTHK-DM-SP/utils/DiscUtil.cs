using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using KDTHK_DM_SP.lists;
using KDTHK_DM_SP.services;
using System.Diagnostics;

namespace KDTHK_DM_SP.utils
{
    public class DiscUtil
    {
        public static List<DiscList> PopulateDiscList()
        {
            List<DiscList> list = new List<DiscList>();

            string query = "select d_disc, d_path from TB_DISC_REQUEST where d_finished = 'True'";

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                {
                    string disc = GlobalService.Reader.GetString(0);
                    string path = GlobalService.Reader.GetString(1);

                    list.Add(new DiscList { DiscNo = disc, FilePath = path });
                }
            }

            return list;
        }

        public static bool IsDisc(DataTable table, string path)
        {
            bool isDisc = false;

            string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

            //DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == path
                              select row).ToArray();

            foreach (DataRow row in rows)
            {
                string value = row["disc"].ToString().Trim();
                if (value == "True")
                    isDisc = true;
            }

            return isDisc;
        }

        public static string GetDiscNo(List<DiscList> list, string path)
        {
            List<DiscList> filterList = list.Where(x => x.FilePath == path).ToList();

            return filterList[0].DiscNo;
        }

        public static string GetDiscStatus(DataTable table, string path)
        {
            string sPath = path.Contains("'") ? path.Replace("'", "''") : path;

            //DataRow[] rows = table.Select(string.Format("filepath = '{0}'", sPath));

            DataRow[] rows = (from row in table.AsEnumerable()
                              where row.RowState != DataRowState.Deleted && row.Field<string>("filepath") == path
                              select row).ToArray();

            string status = "";

            foreach (DataRow row in rows)
                status = row["disc"].ToString();

            return status;
        }
    }
}
