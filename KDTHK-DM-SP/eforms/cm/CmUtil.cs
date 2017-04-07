using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KDTHK_DM_SP.services;
using System.Diagnostics;

namespace KDTHK_DM_SP.eforms.cm
{
    public class CmUtil
    {
        public static string GetLatestDebitNo()
        {
            string year = DateTime.Today.ToString("yy");
            string month = DateTime.Today.ToString("MM");

            string debitno = "KDTHK-DR" + year + month;

            string query = string.Format("select top 1 d_debitno from TB_CM_DEBIT where d_debitno like '{0}%' order by d_debitno desc", debitno);
            
            try
            {
                string no = DataServiceCM.GetInstance().ExecuteScalar(query).ToString();
                int seqno = Convert.ToInt32(no.Substring(12)) + 1;
                return no.Substring(0, 12) + seqno.ToString("D3");
            }
            catch
            {
                return "KDTHK-DR" + year + month + "001";
            }
        }

        public static string GetApplicant(string docno)
        {
            string query = string.Format("select d_createdby from TB_CM_DEBIT where d_docno = '{0}'", docno);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetStatus(string docno)
        {
            string query = string.Format("select d_status from TB_CM_DEBIT where d_docno = '{0}'", docno);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetSect(string docno)
        {
            string query = string.Format("select d_sect from TB_CM_DEBIT where d_docno = '{0}'", docno);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetDiv(string docno)
        {
            string query = string.Format("select d_div from TB_CM_DEBIT where d_docno = '{0}'", docno);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetDept(string docno)
        {
            string query = string.Format("select d_dept from TB_CM_DEBIT where d_docno = '{0}'", docno);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetMcStaff(string docno)
        {
            string query = string.Format("select d_mcstaff from TB_CM_DEBIT where d_docno = '{0}'", docno);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetMcReviewer(string docno)
        {
            string query = string.Format("select d_mcreviewer from TB_CM_DEBIT where d_docno = '{0}'", docno);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetMcApproval(string docno)
        {
            string query = string.Format("select d_mcfinal from TB_CM_DEBIT where d_docno = '{0}'", docno);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }
    }
}
