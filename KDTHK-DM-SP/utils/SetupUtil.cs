using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KDTHK_DM_SP.services;
using System.Diagnostics;

namespace KDTHK_DM_SP.utils
{
    public class SetupUtil
    {
        public static string GetDepartmentFolder(string person)
        {
            Debug.WriteLine(person);
            string query = string.Format("select fd_dept_folder from TB_DIVISION_FOLDER where fd_staff = N'{0}'", person);
            Debug.WriteLine("Query: " + query);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }
    }
}
