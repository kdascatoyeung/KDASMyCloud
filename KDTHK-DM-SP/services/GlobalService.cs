using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using KDTHK_DM_SP.lists;
using KDTHK_DM_SP.xmls;

namespace KDTHK_DM_SP.services
{
    public class GlobalService
    {
        public static String UserAppDataFolder { get; set; }

        public static Dictionary<int, DictionaryUtil> RootDictionary { get; set; }

        public static DataTable RootTable { get; set; }

        public static List<DocumentList> DocumentList { get; set; }

        public static List<DiscList> DiscList { get; set; }

        public static String UserId { get; set; }

        public static String User { get; set; }

        public static String SelectedDepartment { get; set; }

        public static SqlDataReader Reader { get; set; }

        public static SqlDataAdapter Adapter { get; set; }

        public static String DbTable { get; set; }

        public static String SelectedVpath { get; set; }

        public static List<String> MemoryList { get; set; }

        public static String DepartmentFolder { get; set; }

        public static List<String> DivisionMemberList { get; set; }

        public static List<String> DepartmentMemberList { get; set; }

        public static String Division { get; set; }

        public static String Department { get; set; }

        public static List<String> SystemGroupList { get; set; }

        public static List<CustomGroupList> CustomGroupList { get; set; }

        public static List<UserList> AllUserList { get; set; }

        public static List<AttachmentList> AttachmentList { get; set; }

        public static List<SystemGroupList> ExtraSystemGroupList { get; set; }

        public static List<NoticeList> NoticeList { get; set; }

        public static List<String> SelectedUserList { get; set; }

        public static Boolean IsPasswordInput { get; set; }

        public static Int32 FileCount { get; set; }

        public static String NewFolder { get; set; }

        public static String Group { get; set; }

        public static Int32 SelectedIndex { get; set; }

        public static List<AppsInfo> AppsList { get; set; }

        public static List<String> TemporaryFolderList { get; set; }

        public static List<ContactList> ContactList { get; set; }

        public static String SelectedUserHead { get; set; }

        public static List<UserCnList> CnUserList { get; set; }

        public static List<String> CNGroupList { get; set; }

        public static List<UserCnList> SelectedCnUserList { get; set; }

        public static List<String> SelectedCnUser { get; set; }

        public static List<UserVnList> VnUserList { get; set; }

        public static List<String> VNGroupList { get; set; }

        public static List<UserVnList> SelectedVnUserList { get; set; }

        public static List<UserJpList> JpUserList { get; set; }

        public static List<String> JPGroupList { get; set; }

        public static List<UserJpList> SelectedJpUserList { get; set; }

        public static List<UserGlobalList> SelectedGlobalUserList { get; set; }

        public static String ApplicationForm { get; set; }

        public static String StartupPath { get; set; }

    }
}
