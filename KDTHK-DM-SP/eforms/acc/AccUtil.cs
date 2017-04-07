using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using KDTHK_DM_SP.services;
using System.Diagnostics;
using System.Globalization;

namespace KDTHK_DM_SP.eforms.acc
{
    public class AccUtil
    {
        public static bool LessThen3DecimalPlaces(decimal dec)
        {
            decimal value = dec * 1000;
            return value == Math.Floor(value);
        }

        public static float ExcelDecimal(string value)
        {
            string csp = CultureInfo.CurrentCulture.NumberFormat.CurrencyDecimalSeparator;
            string v = value.Replace(".", csp);
            v = v.Replace(",", csp);
            return float.Parse(value);
        }

        public static bool IsInvoiceExists(string invoice, string vendor)
        {
            string query = string.Format("select * from TB_ACC_MASTER_INVOICE where i_invoice = '{0}' and i_vendor = '{1}'", invoice, vendor);

            using (SqlDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                if (reader.HasRows)
                    return true;
                else
                    return false;
            }
        }

        public static bool IsVendorExists(string vendor)
        {
            string query = string.Format("select * from TB_ACC_MASTER_VENDOR where v_code = '{0}'", vendor);

            using (SqlDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                if (reader.HasRows)
                    return true;
                else
                    return false;
            }
        }

        public static string GetVendorName(string vendor)
        {
            string query = string.Format("select v_name from TB_ACC_MASTER_VENDOR where v_code = '{0}'", vendor);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetVendorCurrency(string vendor)
        {
            string query = string.Format("select v_currency from TB_ACC_MASTER_VENDOR where v_code = '{0}'", vendor);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetVendorPayTerm(string vendor)
        {
            string query = string.Format("select v_payterm from TB_ACC_MASTER_VENDOR where v_code = '{0}'", vendor);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static bool IsAccountCodeExists(string accountcode)
        {
            string query = string.Format("select * from TB_CM_MASTER_ACCOUNTCODE where a_code = '{0}'", accountcode);

            using (SqlDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                if (reader.HasRows)
                    return true;
                else
                    return false;
            }
        }

        public static string GetAccountName(string accountcode)
        {
            string query = string.Format("select a_name from TB_CM_MASTER_ACCOUNTCODE where a_code = '{0}'", accountcode);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static bool IsCostCentreExists(string costcentre)
        {
            string query = string.Format("select * from TB_CM_MASTER_COSTCENTRE where c_code = '{0}'", costcentre);

            using (SqlDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                if (reader.HasRows)
                    return true;
                else
                    return false;
            }
        }

        public static string GetCostCentreName(string costcentre)
        {
            string query = string.Format("select c_name from TB_CM_MASTER_COSTCENTRE where c_code = '{0}'", costcentre);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetApplicant(string invoice)
        {
            string query = string.Format("select o_createdby from TB_ACC_OUTSTANDING where o_invoice = '{0}'", invoice);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetSectionApprover(string invoice)
        {
            string query = string.Format("select o_sect from TB_ACC_OUTSTANDING where o_invoice = '{0}'", invoice);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetDivisionApprover(string invoice)
        {
            string query = string.Format("select o_div from TB_ACC_OUTSTANDING where o_invoice = '{0}'", invoice);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetDepartmentApprover(string invoice)
        {
            string query = string.Format("select o_dept from TB_ACC_OUTSTANDING where o_invoice = '{0}'", invoice);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetAccStaff(string invoice)
        {
            string query = string.Format("select o_staff from TB_ACC_OUTSTANDING where o_invoice = '{0}'", invoice);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetAccApprover(string invoice)
        {
            string query = string.Format("select o_acc from TB_ACC_OUTSTANDING where o_invoice = '{0}'", invoice);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string PayDate(DateTime today, string payterm)
        {
            DateTime paydate = payterm == "HK01" ? new DateTime(today.Year, today.Month, 1).AddMonths(2).AddDays(-1)
                        : payterm == "HK02" ? new DateTime(today.Year, today.Month, 1).AddMonths(3).AddDays(-1)
                        : payterm == "HK05" ? today.AddDays(300)
                        : payterm == "HK08" ? today.AddDays(7)
                        : today.AddDays(30);

            if (payterm == "HK08" || payterm == "HK09")
            {
                switch (paydate.DayOfWeek)
                {
                    case DayOfWeek.Saturday: paydate = paydate.AddDays(6); break;
                    case DayOfWeek.Sunday: paydate = paydate.AddDays(5); break;
                    case DayOfWeek.Monday: paydate = paydate.AddDays(4); break;
                    case DayOfWeek.Tuesday: paydate = paydate.AddDays(3); break;
                    case DayOfWeek.Wednesday: paydate = paydate.AddDays(2); break;
                    case DayOfWeek.Thursday: paydate = paydate.AddDays(1); break;
                }
            }

            return paydate.ToString("yyyy/MM/dd");
        }

        public static Int32 GetOutstandingIdByInvoice(string invoice)
        {
            string query = string.Format("select o_id from TB_ACC_OUTSTANDING where o_invoice = '{0}'", invoice);
            return (int)DataServiceCM.GetInstance().ExecuteScalar(query);
        }
    }
}
