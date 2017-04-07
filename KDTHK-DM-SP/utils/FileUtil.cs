using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace KDTHK_DM_SP.utils
{
    public class FileUtil
    {
        public static int GetFileCount(DataTable table, string vpath)
        {
            string sVpath = vpath.Contains("'") ? vpath.Replace("'", "''") : vpath;

            DataRow[] rows = table.Select(string.Format("vpath like '{0}%'", sVpath));

            return rows.Length;
        }
    }
}
