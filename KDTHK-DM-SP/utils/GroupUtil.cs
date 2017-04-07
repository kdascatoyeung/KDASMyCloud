using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KDTHK_DM_SP.services;
using KDTHK_DM_SP.lists;
using System.Data;
using System.Diagnostics;

namespace KDTHK_DM_SP.utils
{
    public class GroupUtil
    {
        public static List<string> SystemGroupList()
        {
            List<string> list = new List<string>();

            string[] divisions = {"Custom", "物流管理科", "倉庫管理1科", "倉庫管理2科", "開發採購1科", "開發採購2科", "開發採購3科", "採購管理科",
                                     "經營管理科", "會計科", "RPS 管理科", "行政科", "人力資源科", "事業推進科", "Master 管理科"};

            foreach (string division in divisions)
                list.Add(division);

            string query = "select sg_group from TB_SYSTEM_GROUP order by sg_seq";
            
            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                    list.Add(GlobalService.Reader.GetString(0));
            }

            list = list.Distinct().ToList();

            return list;
        }

        public static List<CustomGroupList> CustomGroupList2(string person)
        {
            List<CustomGroupList> list = new List<CustomGroupList>();

            string query = string.Format("select g_name, g_member from TB_CUSTOM_GROUP where g_owner = N'{0}' and g_member != '-'", person);

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                    list.Add(new CustomGroupList { Group = GlobalService.Reader.GetString(0), Member = GlobalService.Reader.GetString(1), Division = "" });
            }

            List<CustomGroupList> tmpList = list;

            foreach (CustomGroupList item in list)
            {
                var obj = tmpList.FirstOrDefault(x => x.Member == item.Member);
                if (obj != null)
                    obj.Division = UserUtil.IsCnMember(item.Member.Trim()) ? UserUtil.GetCnDivision(item.Member.Trim())
                        : UserUtil.IsJpMember(item.Member.Trim()) ? UserUtil.GetJpDivision(item.Member.Trim())
                        : UserUtil.IsVnMember(item.Member.Trim()) ? UserUtil.GetVnDivision(item.Member.Trim()) : UserUtil.GetDivision(item.Member.Trim());
            }

            return list;
        }

        public static List<CustomGroupList> CustomGroupList(string person)
        {
            List<CustomGroupList> list = new List<CustomGroupList>();

            string query = string.Format("select g_name, g_member, d_name from TB_CUSTOM_GROUP, TB_DIVISION_FOLDER, TB_DIVISION"+
                " where g_member = fd_staff and fd_name = d_code and g_owner = N'{0}' and g_member != '-'", person);

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                    list.Add(new CustomGroupList { Group = GlobalService.Reader.GetString(0), Member = GlobalService.Reader.GetString(1), Division = GlobalService.Reader.GetString(2) });
            }

            return list;
        }

        public static List<SystemGroupList> ExtraSystemGroupList()
        {
            List<SystemGroupList> list = new List<SystemGroupList>();

            string query = "select sg_group, sg_staff, d_name from TB_SYSTEM_GROUP, TB_DIVISION, TB_DIVISION_FOLDER where sg_staff = fd_staff and fd_name = d_code";

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                    list.Add(new SystemGroupList { Group = GlobalService.Reader.GetString(0), User = GlobalService.Reader.GetString(1), Division = GlobalService.Reader.GetString(2) });

            }

            return list;
        }

        public static List<string> CnGroupList()
        {
            List<string> list = new List<string>();

            string q1 = string.Format("select distinct c_division from TB_USERS_CN where c_division = N'{0}'", "总经理/副总经理/总经理付");
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(q1))
            {
                while (reader.Read())
                    list.Add(reader.GetString(0).Trim());
            }

            string query = string.Format("select distinct c_division from TB_USERS_CN where c_division != N'{0}' order by c_division", "总经理/副总经理/总经理付");

            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    list.Add(reader.GetString(0).Trim());
            }

            return list;
        }

        public static List<string> VnGroupList()
        {
            List<string> list = new List<string>();

            string q1 = "select distinct v_department from TB_USERS_VN where v_department = 'KDTVN'";
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(q1))
            {
                while (reader.Read())
                    list.Add(reader.GetString(0).Trim());
            }

            string query = "select distinct v_department from TB_USERS_VN where v_department != 'KDTVN' order by v_department";
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    list.Add(reader.GetString(0).Trim());
            }

            return list;
        }

        public static List<string> JpGroupList()
        {
            List<string> list = new List<string>();

            string q1 = string.Format("select distinct j_department from TB_USERS_JP where j_department = N'{0}'", "京セラドキュメントソリューションズ株式会社");
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(q1))
            {
                while (reader.Read())
                    list.Add(reader.GetString(0).Trim());
            }

            string q2 = string.Format("select distinct j_department from TB_USERS_JP where j_department = N'{0}'", "京セラドキュメントソリューションズジャパン株式会社");
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(q2))
            {
                while (reader.Read())
                    list.Add(reader.GetString(0).Trim());
            }

            string query = string.Format("select distinct j_department from TB_USERS_JP where j_department != '{0}' and j_department != '{1}' order by j_department", "京セラドキュメントソリューションズ株式会社", "京セラドキュメントソリューションズジャパン株式会社");
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                    list.Add(reader.GetString(0).Trim());
            }
            return list;
        }
    }
}
