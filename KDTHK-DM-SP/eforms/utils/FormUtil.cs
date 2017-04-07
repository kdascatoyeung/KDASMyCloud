using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KDTHK_DM_SP.services;
using System.Diagnostics;

namespace KDTHK_DM_SP.eforms.utils
{
    public class FormUtil
    {
        public static string GetRefNo(string type, string chaseno)
        {
            string query = type == "permission" ? string.Format("select p_refno from TB_FORM_PERMISSION where p_chaseno = '{0}'", chaseno)
                : type == "loaning" ? string.Format("select l_refno from TB_FORM_LOANING where l_chaseno = '{0}'", chaseno)
                : type == "develop" ? string.Format("select d_refno from TB_FORM_DEVELOP where d_chaseno = '{0}'", chaseno)
                : type == "comment" ? string.Format("select c_refno from TB_FORM_COMMENT where c_chaseno = '{0}'", chaseno)
                : type == "r3" ? string.Format("select r_refno from TB_FORM_R3 where r_chaseno = '{0}'", chaseno) : "";

            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetChaseNoByRefNo(string type, string refno)
        {
            string query = type == "permission" ? string.Format("select p_chaseno from TB_FORM_PERMISSION where p_refno = '{0}'", refno)
                : type == "loaning" ? string.Format("select l_chaseno from TB_FORM_LOANING where l_refno = '{0}'", refno)
                : type == "develop" ? string.Format("select d_chaseno from TB_FORM_DEVELOP where d_refno = '{0}'", refno)
                : type == "comment" ? string.Format("select c_chaseno from TB_FORM_COMMENT where c_refno = '{0}'", refno)
                : string.Format("select s_chaseno from TB_FORM_SUPPORT where s_refno = '{0}'", refno);

            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetFormChaseNoByRefno(string type, string refno)
        {
            string query = type == "permission" ? string.Format("select p_refno from TB_FORM_PERMISSION where p_chaseno = '{0}'", refno)
                : type == "loaning" ? string.Format("select l_refno from TB_FORM_LOANING where l_chaseno = '{0}'", refno)
                : type == "develop" ? string.Format("select d_refno from TB_FORM_DEVELOP where d_chaseno = '{0}'", refno)
                : type == "comment" ? string.Format("select c_refno from TB_FORM_COMMENT where c_chaseno = '{0}'", refno)
                : string.Format("select s_refno from TB_FORM_SUPPORT where s_chaseno = '{0}'", refno);

            return DataService.GetInstance().ExecuteScalar(query).ToString();
        }
    }
}
