using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.views;
using KDTHK_DM_SP.utils;
using KDTHK_DM_SP.services;
using KDTHK_DM_SP.lists;
using KDTHK_DM_SP.forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using KDTHK_DM_SP.eforms.hra;
using KDTHK_DM_SP.eforms;

namespace KDTHK_DM_SP
{
    public partial class Main : Form
    {
        //ApplicationView applicationView = new ApplicationView();
        ApplicationView applicationView = new ApplicationView();
        DiscView discView = new DiscView();
        DocumentView docView = new DocumentView();
        HomeView homeView = new HomeView();
        SettingView settingView = new SettingView();
        //EformView eformView = new EformView();
        //FormIT formView;
        Eform eform = new Eform();

        List<ReceivedList> receivedList = new List<ReceivedList>();

        int receivedCount = 0;
        int noticeCount = 0;
        int approvalCount = 0;

        /*[DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern bool GetDiskFreeSpaceEx(string directory, out ulong freeSpace, out ulong total, out ulong totalFree);*/

        bool isExtended = true;

        public Main()
        {
            InitializeComponent();

            try
            {
                GlobalService.RootTable = RootUtil.RootDataTable();

                receivedCount = MessageUtil.GetReceivedCount(GlobalService.RootTable);
                tsbtnReceived.Text = "Received" + " (" + receivedCount + ")";

                receivedList = MessageUtil.ReceivedList(GlobalService.RootTable);

                noticeCount = GlobalService.NoticeList.Count;
                tsbtnNotice.Text = "Notice" + " (" + noticeCount + ")";

                approvalCount = MessageUtil.GetApprovalCount();
                tsbtnApproval.Text = "Approval" + " (" + approvalCount + ")";

                if (SettingUtil.LoadSetting() == "True")
                {
                    pnlLeft.Width = 200;
                    btnExtend.BackgroundImage = Properties.Resources.left_button_basic_blue;
                    isExtended = true;
                }
                else
                {
                    pnlLeft.Width = 41;
                    btnExtend.BackgroundImage = Properties.Resources.right_button_basic_blue;
                    isExtended = false;
                }

                Application.Idle += new EventHandler(Application_Idle);

                docView = new DocumentView();
                //docView.GetFileCountEvent += new EventHandler(docView_GetFileCountEvent);
                docView.GetNoticeEvent += new EventHandler(docView_GetNoticeEvent);
                this.LoadControl(docView);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        void Application_Idle(object sender, EventArgs e)
        {
            tsbtnReceived.ForeColor = receivedCount > 0 ? Color.Red : Color.Black;
            tsbtnNotice.ForeColor = noticeCount > 0 ? Color.Red : Color.Black;
            tsbtnApproval.ForeColor = approvalCount > 0 ? Color.Red : Color.Black;
        }

        private void docView_GetNoticeEvent(object sender, EventArgs e)
        {
            GlobalService.NoticeList = MessageUtil.GetNoticeList();
            noticeCount = GlobalService.NoticeList.Count;
            tsbtnNotice.Text = "Notice" + " (" + noticeCount + ")";

            receivedCount = MessageUtil.GetReceivedCount(GlobalService.RootTable);
            tsbtnReceived.Text = "Received" + " (" + receivedCount + ")";

            receivedList = MessageUtil.ReceivedList(GlobalService.RootTable);
        }

        private void LoadControl(UserControl control)
        {
            pnlMain.Controls.Clear();
            control.Dock = DockStyle.Fill;
            pnlMain.Controls.Add(control);
        }

        private void LabelClicked(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            string tag = label.Tag.ToString();

            foreach (Control control in pnlMenu.Controls)
            {
                if (control is Label)
                {
                    Label lbl = (Label)control;
                    lbl.BackColor = SystemColors.ControlLightLight;
                    lbl.ForeColor = Color.DimGray;
                    lbl.Font = new Font("Calibri", lbl.Font.Size, FontStyle.Regular);
                }
            }

            label.BackColor = Color.AliceBlue;
            label.ForeColor = Color.DodgerBlue;
            label.Font = new Font("Calibri", label.Font.Size, FontStyle.Bold);

            UserControl uc = new UserControl();

            switch (tag)
            {
                case "home": uc = homeView;
                    break;

                case "document": uc = docView;
                    break;

                case "disc": uc = discView;
                    break;

                case "application":
                    if (!GlobalService.IsPasswordInput)
                    {
                        PasswordForm form = new PasswordForm();
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            uc = applicationView;
                        }
                        else
                            uc = null;
                    }
                    else
                        uc = applicationView;
                    break;

                case "form": uc = eform;
                    break;

                case "setting": uc = settingView;
                    break;
            }

            if (uc != null)
                this.LoadControl(uc);
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            if (isExtended)
            {
                pnlLeft.Width = 41;
                btnExtend.BackgroundImage = Properties.Resources.right_button_basic_blue;
                isExtended = false;
                //extendStatus = "collapse";
            }
            else
            {
                pnlLeft.Width = 200;
                btnExtend.BackgroundImage = Properties.Resources.left_button_basic_blue;
                isExtended = true;
                //extendStatus = "extend";
            }
        }

        private void tsbtnReceived_Click(object sender, EventArgs e)
        {
            ReceivedForm form = new ReceivedForm(receivedList);
            form.ShowDialog();

            receivedCount = MessageUtil.GetReceivedCount(GlobalService.RootTable);
            tsbtnReceived.Text = "Received" + " (" + receivedCount + ")";

            receivedList = MessageUtil.ReceivedList(GlobalService.RootTable);
        }

        private void tsbtnNotice_Click(object sender, EventArgs e)
        {
            NoticeForm form = new NoticeForm();
            form.ShowDialog();
            noticeCount = GlobalService.NoticeList.Count;
            tsbtnNotice.Text = "Notice" + " (" + noticeCount + ")";
        }

        private void tsbtnUserManual_Click(object sender, EventArgs e)
        {
            Process.Start(@"\\kdthk-dm1\project\IT System\MyCloud Manual.pdf");
        }

        private void tsbtnMySky_Click(object sender, EventArgs e)
        {
            Process.Start("http://km-square.km.local/kmhk-portal/General/IT/Lists/MySky/AllItems.aspx");
        }

        private void docView_GetFileCountEvent(object sender, EventArgs e)
        {
            tslblStatus.Visible = GlobalService.FileCount > 0 ? true : false;
            tslblStatus.Text = "File count: " + GlobalService.FileCount;
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                string extend = isExtended ? "True" : "False";

                SettingUtil.SaveSetting(extend);

                string query = string.Format("update TB_C_EXT set t_status = 'Offline' where t_staff = N'{0}'", GlobalService.User);
                DataServiceGeneral.GetInstance().ExecuteNonQuery(query);

                Process.GetCurrentProcess().Kill();
            }
            catch
            {
                Process.GetCurrentProcess().Kill();
            }
        }

        private void tsbtnApproval_Click(object sender, EventArgs e)
        {
            eforms.ApprovalView view = new eforms.ApprovalView();
            view.RefreshEvent += new EventHandler(view_RefreshEvent);
            view.SaveEvent += new EventHandler(view_SaveEvent);
            this.LoadControl(view);
        }

        private void view_RefreshEvent(object sender, EventArgs e)
        {
            approvalCount = MessageUtil.GetApprovalCount();
            tsbtnApproval.Text = "Approval" + " (" + approvalCount + ")";
        }

        private void view_SaveEvent(object sender, EventArgs e)
        {
            approvalCount = MessageUtil.GetApprovalCount();
            tsbtnApproval.Text = "Approval" + " (" + approvalCount + ")";
        }

        private void tsbtnRefresh_Click(object sender, EventArgs e)
        {
            receivedCount = MessageUtil.GetReceivedCount(GlobalService.RootTable);
            tsbtnReceived.Text = "Received" + " (" + receivedCount + ")";

            receivedList = MessageUtil.ReceivedList(GlobalService.RootTable);

            noticeCount = GlobalService.NoticeList.Count;
            tsbtnNotice.Text = "Notice" + " (" + noticeCount + ")";

            approvalCount = MessageUtil.GetApprovalCount();
            tsbtnApproval.Text = "Approval" + " (" + approvalCount + ")";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
