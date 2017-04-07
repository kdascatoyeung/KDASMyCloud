using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KDTHK_DM_SP.services;

namespace KDTHK_DM_SP.utils
{
    public class MasterUtil
    {
        public static string Division()
        {
            string query = string.Format("select u_division from TB_USER where u_name = N'{0}'", GlobalService.User);
            return DataServiceMaster.GetInstance().ExecuteScalar(query).ToString().Trim();
        }
        
        public static string Department()
        {
            string query = string.Format("select u_department from TB_USER where u_name = N'{0}'", GlobalService.User);
            return DataServiceMaster.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string CostCentre()
        {
            string query = string.Format("select top 1 d_costcentre from TB_DEPARTMENT, TB_USER where u_name = N'{0}' and u_division = d_division and u_section = d_section", GlobalService.User);

            try
            {
                return DataServiceMaster.GetInstance().ExecuteScalar(query).ToString().Trim();
            }
            catch
            {
                return "";
            }
        }

        public static bool IsAc5(string costcentre)
        {
            string query = string.Format("select count(*) from TB_DEPARTMENT where d_costcentre = '{0}' and d_ac5 = 'Yes'", costcentre);
            int result = (int)DataServiceMaster.GetInstance().ExecuteScalar(query);

            return result > 0 ? true : false;
        }

        public static bool IsAc6(string costcentre)
        {
            string query = string.Format("select count(*) from TB_DEPARTMENT where d_costcentre = '{0}' and d_ac6 = 'Yes'", costcentre);
            int result = (int)DataServiceMaster.GetInstance().ExecuteScalar(query);

            return result > 0 ? true : false;
        }
    }
}
