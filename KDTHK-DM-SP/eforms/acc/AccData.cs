using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KDTHK_DM_SP.eforms.acc
{
    public class AccData
    {
        public static string VendorCode { get; set; }

        public static string VendorName { get; set; }

        public static string PayTerm { get; set; }

        public static string Currency { get; set; }
    }

    public class AccAttachments
    {
        public string Filename { get; set; }

        public string FilePath { get; set; }
    }

    public class OutstandingDetailData
    {
        public string AccountCode { get; set; }

        public string CostCentre { get; set; }

        public string Amount { get; set; }

        public string Remarks1 { get; set; }

        public string Remarks2 { get; set; }

        public string Remarks3 { get; set; }

        public string Remarks4 { get; set; }

        public string Remarks5 { get; set; }
    }
}
