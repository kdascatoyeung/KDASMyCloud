using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using KDTHK_DM_SP.services;

namespace KDTHK_DM_SP.utils
{
    public class QueryUtil
    {
        public static void InsertDataToLocalDb(string queryText)
        {
            string query = "insert into LTB_QUERY ([q_query]) values (@text)";

            using (SqlCeCommand ceCommand = new SqlCeCommand(query, LocalDataService.GetInstance().Connection))
            {
                System.Diagnostics.Debug.WriteLine(query);
                ceCommand.Parameters.AddWithValue("@text", queryText);
                ceCommand.ExecuteNonQuery();
            }
        }
    }
}
