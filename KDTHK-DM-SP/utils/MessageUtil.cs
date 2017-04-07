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
    public class MessageUtil
    {
        public static int GetReceivedCount(DataTable table)
        {
            DataRow[] rows = table.Select("checked = 'False' and fileowner <> '" + GlobalService.User + "'");

            return rows.Length;
        }

        public static List<ReceivedList> ReceivedList(DataTable table)
        {
            List<ReceivedList> list = new List<lists.ReceivedList>();

            DataRow[] rows = table.Select("checked = 'False' and fileowner <> '" + GlobalService.User + "'");

            foreach (DataRow row in rows)
            {
                string fileName = row["filename"].ToString();
                string received = row["access"].ToString();
                string owner = row["fileowner"].ToString();
                string filePath = row["filepath"].ToString();
                string vpath = row["vpath"].ToString();

                list.Add(new ReceivedList { FileName = fileName, Owner = owner, Received = received, FilePath = filePath, Vpath = vpath });
            }

            return list;
        }

        public static List<NoticeList> GetNoticeList()
        {
            List<NoticeList> list = new List<NoticeList>();

            string query = string.Format("select n_requester, n_receiver, n_datetime, n_message, n_filename, n_filepath from TB_NOTICE where n_receiver = N'{0}'", GlobalService.User);

            Debug.WriteLine("Notice Query: " + query);

            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                while (GlobalService.Reader.Read())
                {
                    string requester = GlobalService.Reader.GetString(0);
                    string receiver = GlobalService.Reader.GetString(1);
                    string datetime = GlobalService.Reader.GetString(2);
                    string message = GlobalService.Reader.GetString(3);
                    string filename = GlobalService.Reader.GetString(4);
                    string filepath = GlobalService.Reader.GetString(5);

                    list.Add(new NoticeList { Requester = requester, Receiver = receiver, Datetime = datetime, Message = message, Filename = filename, Filepath = filepath });
                }
            }
            return list;
        }

        public static int GetApprovalCount()
        {
            string q1 = string.Format("select count(*) from TB_FORM_PERMISSION where p_approver = N'{0}' and p_status = N'{1}'", GlobalService.User, "上司承認中");
            int permission = (int)DataService.GetInstance().ExecuteScalar(q1);

            string q2 = string.Format("select count(*) from TB_FORM_LOANING where l_approver = N'{0}' and l_status = N'{1}'", GlobalService.User, "上司承認中");
            int loaning = (int)DataService.GetInstance().ExecuteScalar(q2);

            string q3 = string.Format("select count(*) from TB_FORM_DEVELOP where d_approver = N'{0}' and d_status = N'{1}'", GlobalService.User, "上司承認中");
            int develop = (int)DataService.GetInstance().ExecuteScalar(q3);

            string query = string.Format("select count(*) from TB_FORM where f_approver = N'{0}' and f_status = N'{1}'", GlobalService.User, "上司承認中");
            int form= (int)DataService.GetInstance().ExecuteScalar(query);

            string q4 = string.Format("select count(*) from TB_FORM_R3 where (r_approver = N'{0}' and r_status = N'{1}') or (r_cmapprover = N'{0}' and r_status = N'{2}')", GlobalService.User, "上司承認中", "經管承認中");
            int r3 = (int)DataService.GetInstance().ExecuteScalar(q4);

            string q5 = string.Format("select count(*) from TB_CM_DEBIT where (d_sect = N'{0}' and d_status = N'係責承認中') or (d_div = N'{0}' and d_status = N'科責承認中')" +
                " or (d_dept = N'{0}' and d_status = N'部責承認中') or (d_mcreviewer = N'{0}' and d_status = N'經管檢查中') or (d_mcfinal = N'{0}' and d_status = N'經管承認中')", GlobalService.User);
            int debit = (int)DataServiceCM.GetInstance().ExecuteScalar(q5);

            string q6 = string.Format("select count(*) from TB_CM_DEBIT_CANCEL where (c_applicant = N'{0}' or c_sect = N'{0}' or c_div = N'{0}' or c_dept = N'{0}' or c_targetsect = N'{0}' or c_targetdept = N'{0}')", GlobalService.User);
            int cancel = (int)DataServiceCM.GetInstance().ExecuteScalar(q6);

            string q7 = string.Format("select count(*) from TB_ACC_OUTSTANDING where (o_sect = N'{0}' and o_status = N'係責承認中') or (o_div = N'{0}' and o_status = N'科責承認中') or (o_dept = N'{0}' and o_status = N'部責承認中') or (o_staff = N'{0}' and o_status = N'會計處理中')" +
                " or (o_acc = N'{0}' and o_status = N'會計承認中')", GlobalService.User);
            int outstanding = (int)DataServiceCM.GetInstance().ExecuteScalar(q7);

            return permission + loaning + develop + form + r3 + debit + cancel + outstanding;
        }
    }
}
