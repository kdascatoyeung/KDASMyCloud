using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KDTHK_DM_SP.services;

namespace KDTHK_DM_SP.utils
{
    public class McUtil
    {
        public static string GetNextDocNo()
        {
            string query = "select top 1 d_id from TB_CM_DEBIT order by d_id desc";

            try
            {
                int result = (int)DataServiceCM.GetInstance().ExecuteScalar(query);
                result += 1;

                return "DB-" + result.ToString("D5");
            }
            catch
            {
                return "DB-000001";
            }
        }

        public static int GetId()
        {
            string query = "select top 1 d_id from TB_CM_DEBIT order by d_id desc";

            try
            {
                int result = (int)DataServiceCM.GetInstance().ExecuteScalar(query);
                return result;
            }
            catch
            {
                return 1;
            }
        }
    }
}
