using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KDTHK_DM_SP.services
{
    public class CmsService
    {
        public static String CustomerCode { get; set; }
        public static String CustomerName { get; set; }
        public static String CustomerCurr { get; set; }
        public static String CustomerPayTerm { get; set; }

        public static String RateMonth { get; set; }
        public static String RateItem { get; set; }
        public static String Rate { get; set; }

        public static String InputInvNo { get; set; }
        public static String InputRingiNo { get; set; }

        public static String CurrencyType { get; set; }
        public static String CurrencyDesc { get; set; }

        public static List<Attachment> AttachmentList { get; set; }

        public static String TransactionReason { get; set; }
    }

    public class Attachment
    {
        public string Filename { get; set; }
        public string Filepath { get; set; }
    }
}
