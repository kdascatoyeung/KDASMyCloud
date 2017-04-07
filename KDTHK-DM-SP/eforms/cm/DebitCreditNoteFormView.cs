using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;

namespace KDTHK_DM_SP.eforms.cm
{
    public partial class DebitCreditNoteFormView : Form
    {
        string _noteno = "";
        string _status = "";

        public DebitCreditNoteFormView(string noteno)
        {
            InitializeComponent();

            _noteno = noteno;

            LoadData(noteno);

            SignalChanged();
        }

        private void LoadData(string noteNo)
        {
            string query = string.Format("select d_reqdate, d_reqoffice, d_reqcostcentre, d_custcode, d_custname, d_custcurr, d_payterm, d_duedate, d_custdiv" +
                ", d_divname, d_incharge, d_reason, d_invno, d_ringino, d_exmonth, d_exrate, d_dntotal1, d_dncurr, d_dntotal2, d_pdf, d_deduct, d_mention" +
                ", d_createdby, d_created, d_sect, d_sectapproval, d_sectdate, d_div, d_divapproval, d_divdate, d_dept, d_deptapproval, d_deptdate from TB_CM_DEBIT where d_docno = '{0}'", noteNo);

            using (IDataReader reader = DataServiceCM.GetInstance().ExecuteReader(query))
            {
                while (reader.Read())
                {
                    txtReqDate.Text = reader.GetString(0).Trim();
                    txtReqOffice.Text = reader.GetString(1).Trim();
                    txtReqCostcentre.Text = reader.GetString(2).Trim();

                    txtCustCode.Text = reader.GetString(3).Trim();
                    txtCustName.Text = reader.GetString(4).Trim();
                    txtCustCurr.Text = reader.GetString(5).Trim();
                    txtPayTerm.Text = reader.GetString(6).Trim();
                    txtDueDate.Text = reader.GetString(7).Trim();
                    txtCustDiv.Text = reader.GetString(8).Trim();
                    txtDivName.Text = reader.GetString(9).Trim();
                    txtIncharge.Text = reader.GetString(10).Trim();

                    txtReason.Text = reader.GetString(11).Trim();
                    txtInvNo.Text = reader.GetString(12).Trim();
                    txtRingiNo.Text = reader.GetString(13).Trim();

                    txtExMonth.Text = reader.GetString(14).Trim();
                    txtExRate.Text = reader.GetString(15).Trim();
                    txtDnTotal1.Text = reader.GetString(16).Trim();
                    txtDnCurr2.Text = reader.GetString(17).Trim();
                    txtDnTotal2.Text = reader.GetString(18).Trim();

                    string pdf = reader.GetString(19).Trim();
                    string deduct = reader.GetString(20).Trim();
                    txtMention.Text = reader.GetString(21).Trim();

                    string createdby = reader.GetString(22).Trim();
                    string created = reader.GetString(23).Trim();
                    lblRequester.Text = "Form was created by " + createdby + " at " + created;

                    string sect = reader.GetString(24).Trim();
                    string sectapp = reader.GetString(25).Trim();
                    string sectdate = reader.GetString(26).Trim();
                    lblSection.Text = "Form was approved by " + sect + " at " + sectdate;

                    string div = reader.GetString(27).Trim();
                    string divapp = reader.GetString(28).Trim();
                    string divdate = reader.GetString(29).Trim();
                    lblDivision.Text = "Form was approved by " + div + " at " + divdate;

                }
            }
        }

        private void SignalChanged()
        {
            string query = string.Format("select d_status from TB_CM_DEBIT where d_docno = '{0}'", _noteno);

            string status = DataServiceCM.GetInstance().ExecuteScalar(query).ToString().Trim();

            if (status == "係責承認中")
                pb2nd.BackgroundImage = Properties.Resources.circle_orange;

            if (status == "科責承認中")
            {
                pb2nd.BackgroundImage = Properties.Resources.circle;
                pb3rd.BackgroundImage = Properties.Resources.circle_orange;
            }

            if (status == "部責承認中")
            {
                pb2nd.BackgroundImage = Properties.Resources.circle;
                pb3rd.BackgroundImage = Properties.Resources.circle;
                pb4th.BackgroundImage = Properties.Resources.circle_orange;
            }

            if (status == "經管確認中")
            {
                pb2nd.BackgroundImage = Properties.Resources.circle;
                pb3rd.BackgroundImage = Properties.Resources.circle;
                pb4th.BackgroundImage = Properties.Resources.circle;
                pb5th.BackgroundImage = Properties.Resources.circle_orange;
            }

            if (status == "經管檢查中")
            {
                pb2nd.BackgroundImage = Properties.Resources.circle;
                pb3rd.BackgroundImage = Properties.Resources.circle;
                pb4th.BackgroundImage = Properties.Resources.circle;
                pb5th.BackgroundImage = Properties.Resources.circle;
                pb6th.BackgroundImage = Properties.Resources.circle_orange;
            }

            if (status == "經管承認中")
            {
                pb2nd.BackgroundImage = Properties.Resources.circle;
                pb3rd.BackgroundImage = Properties.Resources.circle;
                pb4th.BackgroundImage = Properties.Resources.circle;
                pb5th.BackgroundImage = Properties.Resources.circle;
                pb6th.BackgroundImage = Properties.Resources.circle;
                pb7th.BackgroundImage = Properties.Resources.circle_orange;
            }
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void MouseEnter(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string tag = button.Tag.ToString().Trim();

            if (tag == "approve")
            {

            }

            if (tag == "reject")
            {

            }
        }

        private void MouseLeave(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string tag = button.Tag.ToString().Trim();

            if (tag == "approve")
            {

            }

            if (tag == "reject")
            {

            }
        }

        private void customPanel34_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customPanel33_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customPanel32_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customPanel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customPanel59_Paint(object sender, PaintEventArgs e)
        {

        }

        private void customPanel58_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void DebitCreditNoteFormView_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
