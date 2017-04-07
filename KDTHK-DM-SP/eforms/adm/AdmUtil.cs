using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomUtil.utils.authentication;

namespace KDTHK_DM_SP.eforms.adm
{
    public class AdmUtil
    {
        public static string GetEmail(string user)
        {
            try
            {
                return AdUtil.GetEmailByUsername(user, "kmhk.local");
            }
            catch
            {
                return AdUtil.GetEmailByUsername(user, "kmas.local");
            }
        }
    }
}
