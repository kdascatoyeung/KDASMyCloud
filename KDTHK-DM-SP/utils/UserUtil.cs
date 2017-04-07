using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KDTHK_DM_SP.lists;
using KDTHK_DM_SP.services;
using System.Data;
using System.Diagnostics;

namespace KDTHK_DM_SP.utils
{
    public class UserUtil
    {
        public static string HrUserName1()
        {
            return "Ling Wai Man(凌慧敏,Velma)";
        }
        public static string ItUserName1()
        {
            return "Darli Yeung Sheung Yu (楊尚儒)";
        }
        public static string ItUserName2()
        {
            return "Donovan Chan Wing Shing (陳永成)";
        }
        public static string ItUserName3()
        {
            return "Cash Tsang Yuk Kam (曾旭鑫)";
        }
        public static string ItUserName4()
        {
            return "Nakata";
        }
        public static string ItMail1()
        {
            return "darli.yeung@das.kyocera.com";
        }
        public static string ItMail2()
        {
            return "donovan.chan@das.kyocera.com";
        }
        public static string ItMail3()
        {
            return "cash.tsang@das.kyocera.com";
        }
        public static string ItMail4()
        {
            return "kenichi.nakata@dc.kyocera.com";
        }
        public static string HrMail1()
        {
            return "sammy.chow@das.kyocera.com";
        }
        public static string HrMail2()
        {
            return "velma.ling@das.kyocera.com";
        }
        public static string HkHrMail3()
        {
            return "anna.liu@dthk.kyocera.com";
        }
        public static string HkRpsMail1()
        {
            return "ezra.chan@dthk.kyocera.com";
        }
        public static string HkItGroupCode()
        {
            return "23600";
        }
        public static bool IsSpecialUser(string shared)
        {
            if (shared == "Chow Chi To(周志滔,Sammy)" || shared == "Ling Wai Man(凌慧敏,Velma)" || shared == UserUtil.ItUserName2() || shared == "Ng Lau Yu, Lilith (吳柳如)" ||
                        shared == "Lee Miu Wah(李苗華)" || shared == UserUtil.ItUserName3() || shared == UserUtil.ItUserName1() || shared == UserUtil.ItUserName4())
            //if (shared == "Chow Chi To(周志滔,Sammy)" || shared == "Ling Wai Man(凌慧敏,Velma)" || shared == "Chan Fai Lung(陳輝龍,Onyx)" || shared == "Ng Lau Yu, Lilith (吳柳如)" ||
            //        shared == "Lee Miu Wah(李苗華)" || shared == "Lee Ming Fung(李銘峯)" || shared == "Ho Kin Hang(何健恒,Ken)" || shared == "Yeung Wai, Gabriel (楊偉)")
                return true;

            return false;
        }
        
        public static List<UserList> AllUserList()
        {
            List<UserList> list = new List<UserList>();

            string query = "select fd_staff, fd_dept, fd_name, d_name from TB_DIVISION_FOLDER, TB_DIVISION where fd_name = d_code and fd_isenabled = 1";

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                    list.Add(new UserList
                    {
                        User = GlobalService.Reader.GetString(0),
                        DepartmentCode = GlobalService.Reader.GetString(1),
                        DivisionCode = GlobalService.Reader.GetString(2),
                        Division = GlobalService.Reader.GetString(3)
                    });
            }
            return list;
        }

        public static string GetDivision(string name)
        {
            string query = string.Format("select d_name from TB_DIVISION, TB_DIVISION_FOLDER where d_code = fd_name and fd_staff = N'{0}'", name);
            Debug.WriteLine(query);
            return DataService.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static List<UserCnList> CnUserList()
        {
            List<UserCnList> list = new List<UserCnList>();

            string query = "select c_name, c_code, c_division from TB_USERS_CN";
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string name = reader.GetString(0).Trim();
                    string code = reader.GetString(1).Trim();
                    string section = reader.GetString(2).Trim();

                    list.Add(new UserCnList { Name = name, Code = code, Department = section });
                }
            }

            return list;
        }

        public static string GetCnUserStaffNo(string name)
        {
            string query = string.Format("select c_staffno from TB_USERS_CN where c_name = N'{0}'", name);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetCnDivision(string name)
        {
            string query = string.Format("select c_division from TB_USERS_CN where c_name = N'{0}'", name);
            return DataService.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static bool IsCnMember(string staff)
        {
            string query = string.Format("select * from TB_USERS_CN where c_name = N'{0}'", staff);
            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                if (GlobalService.Reader.HasRows)
                    return true;
            }
            return false;
        }

        public static List<UserVnList> VnUserList()
        {
            List<UserVnList> list = new List<UserVnList>();

            string query = "select v_staffno, v_name, v_department from TB_USERS_VN";
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string staffno = reader.GetString(0).Trim();
                    string name = reader.GetString(1).Trim();
                    string department = reader.GetString(2).Trim();

                    list.Add(new UserVnList { StaffNo = staffno, Name = name, Department = department });
                }
            }
            return list;
        }

        public static string GetVnUserStaffNo(string name)
        {
            string query = string.Format("select v_staffno from TB_USERS_VN where v_name = N'{0}'", name);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetVnDivision(string name)
        {
            string query = string.Format("select v_department from TB_USERS_VN where v_name = N'{0}'", name);
            return DataService.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static bool IsVnMember(string staff)
        {
            string query = string.Format("select * from TB_USERS_VN where v_name = N'{0}'", staff);
            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                if (GlobalService.Reader.HasRows)
                    return true;
            }
            return false;
        }

        public static List<UserJpList> JpUserList()
        {
            List<UserJpList> list = new List<UserJpList>();

            string query = "select j_staffno, j_name, j_department from TB_USERS_JP";
            using (IDataReader reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    string staffno = reader.GetString(0).Trim();
                    string name = reader.GetString(1).Trim();
                    string department = reader.GetString(2).Trim();

                    list.Add(new UserJpList { StaffNo = staffno, Name = name, Department = department });
                }
            }
            return list;
        }

        public static string GetJpUserStaffNo(string name)
        {
            string query = string.Format("select j_staffno from TB_USERS_JP where j_name = N'{0}'", name);
            Debug.WriteLine(query);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetJpDivision(string name)
        {
            string query = string.Format("select j_department from TB_USERS_JP where j_name = N'{0}'", name);
            return DataService.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static bool IsJpMember(string staff)
        {
            string query = string.Format("select * from TB_USERS_JP where j_name = N'{0}'", staff);
            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                if (GlobalService.Reader.HasRows)
                    return true;
            }
            return false;
        }

        public static string GetJpUserDepartment(string member)
        {
            string query = string.Format("select j_department from TB_USERS_JP where j_name = N'{0}'", member);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetVnDepartment(string member)
        {
            string query = string.Format("select v_department from TB_USERS_VN where v_name = N'{0}'", member);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetCnDepartment(string member)
        {
            string query = string.Format("select c_name from TB_USERS_CN where c_name = N'{0}'", member);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetHKDivision(string member)
        {
            string query = string.Format("select d_name from TB_DIVISION, TB_DIVISION_FOLDER where d_code = fd_name and fd_staff = N'{0}'", member);
            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetSect(string name)
        {
            string query = string.Format("select u_section from TB_USER where u_name = N'{0}'", name);
            return DataServiceMaster.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetDiv(string name)
        {
            string query = string.Format("select u_division from TB_USER where u_name = N'{0}'", name);
            return DataServiceMaster.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetDept(string name)
        {
            string query = string.Format("select u_department from TB_USER where u_name = N'{0}'", name);
            return DataServiceMaster.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetSectionHead(string section)
        {
            string query = string.Format("select d_incharge from TB_DEPARTMENT where d_section = N'{0}'", section);
            return DataServiceMaster.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetDivisionHead(string division)
        {
            string query = string.Format("select d_incharge from TB_DEPARTMENT where d_division = N'{0}' and d_section = '---'", division);
            return DataServiceMaster.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetDepartmentHead(string department)
        {
            string query = string.Format("select d_incharge from TB_DEPARTMENT where d_dept = N'{0}' and d_division = '---'", department);
            return DataServiceMaster.GetInstance().ExecuteScalar(query).ToString().Trim();
        }
    }
}
