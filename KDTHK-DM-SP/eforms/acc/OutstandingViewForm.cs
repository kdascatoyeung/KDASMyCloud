using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using System.Data.SqlClient;
using KDTHK_DM_SP.utils;
using CustomUtil.utils.authentication;
using CustomUtil.utils.export;
using CustomUtil.utils.import;

namespace KDTHK_DM_SP.eforms.acc
{
    public partial class OutstandingViewForm : Form
    {
        string _status = "";
        string _invoice = "";

        public OutstandingViewForm(string invoice)
        {
            InitializeComponent();

            LoadData(invoice);

            if ((_status == "科責承認中" && AccUtil.GetDivisionApprover(invoice) == GlobalService.User) || (_status == "會計處理中" && AccUtil.GetAccStaff(invoice) == GlobalService.User) || (_status == "會計承認中" && AccUtil.GetAccApprover(invoice) == GlobalService.User))
            {
                btnApprove.Enabled = true;
                btnReject.Enabled = true;

                if (_status == "科責承認中")
                    gbOverall.Visible = false;
                else
                    gbOverall.Visible = true;
            }
            else
            {
                btnApprove.Enabled = false;
                btnReject.Enabled = false;
                gbOverall.Visible = false;
            }

            txtInputDate.BackColor = (_status == "會計處理中" || _status == "會計承認中") && Convert.ToDateTime(txtInputDate.Text).Month != DateTime.Today.Month ? Color.Yellow : Color.White;
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void LoadData(string invoice)
        {
            string query = string.Format("select o_id, o_invoice, o_vendor, o_vendorname, o_inputdate, o_paymentdate, o_currency, o_amount, o_status from TB_ACC_OUTSTANDING where o_invoice = '{0}'", invoice);

            int id = 0;

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    txtInvoice.Text = reader.GetString(1).Trim();
                    txtVendorCode.Text = reader.GetString(2).Trim();
                    txtVendorName.Text = reader.GetString(3).Trim();
                    txtInputDate.Text = reader.GetString(4).Trim();
                    txtPayDate.Text = reader.GetString(5).Trim();
                    txtCurrency.Text = reader.GetString(6).Trim();
                    txtAmount.Text = reader.GetString(7).Trim();
                    _status = reader.GetString(8).Trim();
                    _invoice = reader.GetString(1).Trim();

                }
            }

            string text = string.Format("select od_accountcode as acc, od_accountname as accname, od_costcentre as cc, od_costcentrename as ccname, od_amount as amount" +
                ", od_desc1 as desc1, od_desc2 as desc2, od_desc3 as desc3, od_desc4 as desc4, od_desc5 as desc5, od_display as descdisplay from TB_ACC_OUTSTANDING_DETAIL" +
                " where od_o_id = '{0}'", id);

            DataTable table = new DataTable();

            SqlDataAdapter sda = new SqlDataAdapter(text, DataServiceCM.GetInstance().Connection);
            sda.Fill(table);

            dgvOutstanding.DataSource = table;
            
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string text = _status == "科責承認中" ? string.Format("update TB_ACC_OUTSTANDING set o_divapproval = 'Yes', o_divapprovaldate = '{0}', o_status = N'會計處理中' where o_invoice = '{1}'", now, _invoice)
                : _status == "會計處理中" ? string.Format("update TB_ACC_OUTSTANDING set o_staffapproval = 'Yes', o_staffapprovaldate = '{0}', o_status = N'會計承認中' where o_invoice = '{1}'", now, _invoice)
                : string.Format("update TB_ACC_OUTSTANDING set o_accapproval = 'Yes', o_accapprovaldate = '{0}', o_status = N'申請處理完成' where o_invoice = '{1}'", now, _invoice);

            DataServiceCM.GetInstance().ExecuteNonQuery(text);

            string applicant = AccUtil.GetApplicant(_invoice);
            string div = AccUtil.GetDivisionApprover(_invoice);
            string staff = AccUtil.GetAccStaff(_invoice);
            string acc = AccUtil.GetAccApprover(_invoice);

            if (_status == "科責承認中")
                EformUtil.SendApprovalEmail(_invoice, applicant, AdUtil.GetEmailByUsername(applicant, "kmhk.local"), AdUtil.GetEmailByUsername(staff, "kmhk.local"), "", "Outstanding Slip - " + _invoice);

            if (_status == "會計處理中")
                EformUtil.SendApprovalEmail(_invoice, applicant, AdUtil.GetEmailByUsername(applicant, "kmhk.local"), AdUtil.GetEmailByUsername(acc, "kmhk.local"), "", "Outstanding Slip - " + _invoice);

            if (_status == "會計承認中")
                EformUtil.SendFinishedEmail(_invoice, acc, AdUtil.GetEmailByUsername(acc, "kmhk.local"), AdUtil.GetEmailByUsername(applicant, "kmhk.local"), "Outstanding Slip Application Finished - " + _invoice, "You Outstanding Slip Application has been finished.");

            DialogResult = DialogResult.OK;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string text = _status == "科責承認中" ? string.Format("update TB_ACC_OUTSTANDING set o_divapproval = 'No', o_divapprovaldate = '{0}', o_status = N'科責已拒絕' where o_invoice = '{1}'", now, _invoice)
                : _status == "會計處理中" ? string.Format("update TB_ACC_OUTSTANDING set o_staffapproval = 'No', o_staffapprovaldate = '{0}', o_status = N'會計已拒絕' where o_invoice = '{1}'", now, _invoice)
                : string.Format("update TB_ACC_OUTSTANDING set o_accapproval = 'No', o_accapprovaldate = '{0}', o_status = N'會計已拒絕' where o_invoice = '{1}'", now, _invoice);

            DataServiceCM.GetInstance().ExecuteNonQuery(text);

            string applicant = AccUtil.GetApplicant(_invoice);

            EformUtil.SendRejectEmail(_invoice, GlobalService.User, AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local"), AdUtil.GetEmailByUsername(applicant, "kmhk.local"), "Outstanding Slip Rejected - " + _invoice, "Your Outstanding Slip has been rejected by " + GlobalService.User);

            DialogResult = DialogResult.OK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string text = _status == "會計處理中" ? string.Format("select o_invoice, o_vendor, o_vendorname, o_inputdate, o_paymentdate, o_currency, o_createdby, o_created" +
                ", od_accountcode, od_accountname, od_costcentre, od_costcentrename, od_amount, od_display from TB_ACC_OUTSTANDING, TB_ACC_OUTSTANDING_DETAIL" +
                " where o_id = od_o_id and o_status = N'會計處理中' and o_staff = N'{0}'", GlobalService.User)
                : string.Format("select o_invoice, o_vendor, o_vendorname, o_inputdate, o_paymentdate, o_currency, o_createdby, o_created, od_accountcode, od_accountname" +
                ", od_costcentre, od_costcentrename, od_amount, od_display from TB_ACC_OUTSTANDING, TB_ACC_OUTSTANDING_DETAIL where  o_id = od_o_id and o_status = N'會計承認中' and o_div = N'{0}'", GlobalService.User);

            DataTable table = new DataTable();

            string[] headers = { "Invoice", "Vendor", "VendorName", "AccountCode", "AccountName", "CostCentre", "CostCentreName", "InputDate", "PaymentDate", "Currency", "Amount", "Description", "CreatedBy", "Created", "Approval" };
            foreach (string header in headers)
                table.Columns.Add(header);

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(text))
            {
                while (reader.Read())
                {
                    string invoice = reader.GetString(0).Trim();
                    string vendor = reader.GetString(1).Trim();
                    string vendorname = reader.GetString(2).Trim();
                    string inputdate = reader.GetString(3).Trim();
                    string paydate = reader.GetString(4).Trim();
                    string currency = reader.GetString(5).Trim();
                    string createdby = reader.GetString(6).Trim();
                    string created = reader.GetString(7).Trim();
                    string acccode = reader.GetString(8).Trim();
                    string accname = reader.GetString(9).Trim();
                    string costcentre = reader.GetString(10).Trim();
                    string costcentrename = reader.GetString(11).Trim();
                    string amount = reader.GetString(12).Trim();
                    string display = reader.GetString(13).Trim();

                    table.Rows.Add(invoice, vendor, vendorname, acccode, accname, costcentre, costcentrename, inputdate, paydate, currency, amount, display, createdby, created, "-");
                }
            }

            ExportExcelUtil.ExportExcel(table);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                DataTable table = ImportExcel2007.TranslateToTable(ofd.FileName);

                List<int> invoiceIdList = new List<int>();

                foreach (DataRow row in table.Rows)
                {
                    string invoice = row.ItemArray[0].ToString().Trim();
                    string vendor = row.ItemArray[1].ToString().Trim();
                    string acccode = row.ItemArray[3].ToString().Trim();
                    string costcentre = row.ItemArray[4].ToString().Trim();
                    string amount = row.ItemArray[10].ToString().Trim();
                    string approval = row.ItemArray[11].ToString().Trim();

                    if (approval == "Yes")
                    {
                        int id = GetInvoiceId(invoice);
                        string status = GetInvoiceStatus(invoice);

                        string query = status == "會計處理中" ? string.Format("update TB_ACC_OUTSTANDING_DETAIL set od_staffapproval = 'Yes' where od_o_id = '{0}' and od_accountcode = '{1}'" +
                            " and od_costcentre = '{2}' and od_amount = '{3}'", id, acccode, costcentre, amount) : string.Format("update TB_ACC_OUTSTANDING_DETAIL set od_divapproval = 'Yes'" +
                            " where od_o_id = '{0}' and od_accountcode = '{1}' and od_costcentre = '{2}' and od_amount = '{3}'", id, acccode, costcentre, amount);
                        DataServiceCM.GetInstance().ExecuteNonQuery(query);

                        invoiceIdList.Add(id);
                    }
                }

                invoiceIdList = invoiceIdList.Distinct().ToList();

                string now = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

                foreach (int item in invoiceIdList)
                {
                    string status = GetInvoiceStatusById(item);
                    string invoice = GetInvoiceById(item);

                    string applicant = AccUtil.GetApplicant(invoice);
                    string div = AccUtil.GetDivisionApprover(invoice);
                    string staff = AccUtil.GetAccStaff(invoice);
                    string acc = AccUtil.GetAccApprover(invoice);

                    if (status == "會計處理中")
                    {
                        if (IsAllItemApprovedByStaff(item))
                        {
                            string query = string.Format("update TB_ACC_OUTSTANDING set o_status = N'會計承認中', o_staffapproval = 'Yes', o_staffapprovaldate = '{0}' where o_id = '{1}'", now, item);
                            DataServiceCM.GetInstance().ExecuteNonQuery(query);

                            EformUtil.SendApprovalEmail(_invoice, applicant, AdUtil.GetEmailByUsername(applicant, "kmhk.local"), AdUtil.GetEmailByUsername(acc, "kmhk.local"), "", "Outstanding Slip - " + invoice);
                        }
                    }

                    if (status == "會計承認中")
                    {
                        if (IsAllItemApprovedByAcc(item))
                        {
                            string query = string.Format("update TB_ACC_OUTSTANDING set o_status = N'申請處理完成', o_accapproval = 'Yes', o_accapprovaldate = '{0}' where o_id = '{1}'", now, item);
                            DataServiceCM.GetInstance().ExecuteNonQuery(query);

                            EformUtil.SendFinishedEmail(_invoice, acc, AdUtil.GetEmailByUsername(acc, "kmhk.local"), AdUtil.GetEmailByUsername(applicant, "kmhk.local"), "Outstanding Slip Application Finished - " + invoice, "You Outstanding Slip Application has been finished.");
                        }
                    }
                }

                MessageBox.Show("Record has been uploaded.");
            }
        }

        private Int32 GetInvoiceId(string invoice)
        {
            string query = string.Format("select o_id from TB_ACC_OUTSTANDING where o_invoice = '{0}'", invoice);
            return (int)DataServiceCM.GetInstance().ExecuteScalar(query);
        }

        private String GetInvoiceById(int id)
        {
            string query = string.Format("select o_invoice from TB_ACC_OUTSTANDING where o_id = '{0}'", id);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        private String GetInvoiceStatus(string invoice)
        {
            string query = string.Format("select o_status from TB_ACC_OUTSTANDING where o_invoice = '{0}'", invoice);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        private String GetInvoiceStatusById(int id)
        {
            string query = string.Format("select o_status from TB_ACC_OUTSTANDING where o_id = '{0}'", id);
            return DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        private Boolean IsAllItemApprovedByStaff(int id)
        {
            string query = string.Format("select * from TB_ACC_OUTSTANDING_DETAIL where od_o_id = '{0}' and od_staffapproval = 'No'", id);
            using (SqlDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                if (reader.HasRows)
                    return false;
            }
            return true;
        }

        private Boolean IsAllItemApprovedByAcc(int id)
        {
            string query = string.Format("select * from TB_ACC_OUTSTANDING_DETAIL where od_o_id = '{0}' and od_divapproval = 'No'", id);
            using (SqlDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                if (reader.HasRows)
                    return false;
            }
            return true;
        }
    }
}
