using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KDTHK_DM_SP.services;
using System.IO;
using CustomUtil.utils.authentication;
using KDTHK_DM_SP.utils;
using System.Diagnostics;
using CustomUtil.utils.import;

namespace KDTHK_DM_SP.forms
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();

            string domain = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;

            //GlobalService.User = domain == "kmhk.local" ? AdUtil.getUsername("kmhk.local") : "";

            string currentUser = System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToUpper();

            //string currentUser = Environment.UserDomainName.ToUpper();

            if (currentUser.StartsWith("KMHK"))
            {
                GlobalService.User = AdUtil.getUsername("kmhk.local");
                GlobalService.DbTable = "TB_" + AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local");
            }
            else if (currentUser.StartsWith("KMAS"))
            {
                //GlobalService.User = AdUtil.getUsername("kmas.local");
                //GlobalService.DbTable = "TB_" + AdUtil.GetUserIdByUsername(GlobalService.User, "kmas.local");
                string tb = currentUser == @"KMAS\AS1600048" ? "hk070022"
                    : currentUser == @"KMAS\AS1600049" ? "hk110017"
                    //: currentUser == @"KMAS\AS1600050" ? "hk040015"
                    : currentUser == @"KMAS\AS1600051" ? "hk160002"
                    : currentUser == @"KMAS\AS1600053" ? "hk950330"
                    : currentUser == @"KMAS\AS1600054" ? "hk110023"
                    //: currentUser == @"KMAS\AS1600055" ? "hk120027"
                    //: currentUser == @"KMAS\AS1600056" ? "hk140005" : "";
                    : currentUser == @"KMAS\AS1600056" ? "hk140005"
                    : currentUser == @"KMAS\AS1700059" ? "hkit001"
                    : currentUser == @"KMAS\AS1700060" ? "hkit002"
                    : currentUser == @"KMAS\AS1700061" ? "hkit003"
                    : currentUser == @"KMAS\AS060701057" ? "hkit004"
                    : currentUser == @"KMAS\AS1700063" ? "hkit004" : "";

                GlobalService.DbTable = "TB_" + tb;

                string name = currentUser == @"KMAS\AS1600048" ? "Chow Chi To(周志滔,Sammy)"
                    : currentUser == @"KMAS\AS1600049" ? "Ling Wai Man(凌慧敏,Velma)"
                    //: currentUser == @"KMAS\AS1600050" ? "Chan Fai Lung(陳輝龍,Onyx)"
                    : currentUser == @"KMAS\AS1600051" ? "Ng Lau Yu, Lilith (吳柳如)"
                    : currentUser == @"KMAS\AS1600053" ? "Lee Miu Wah(李苗華)"
                    : currentUser == @"KMAS\AS1600054" ? "Lee Ming Fung(李銘峯)"
                    //: currentUser == @"KMAS\AS1600055" ? "Ho Kin Hang(何健恒,Ken)"
                    : currentUser == @"KMAS\AS1600056" ? "Yeung Wai, Gabriel (楊偉)"
                    : currentUser == @"KMAS\AS1700059" ? "Darli Yeung Sheung Yu (楊尚儒)"
                    : currentUser == @"KMAS\AS1700060" ? "Donovan Chan Wing Shing (陳永成)"
                    : currentUser == @"KMAS\AS1700061" ? "Cash Tsang Yuk Kam (曾旭鑫)"
                    : currentUser == @"KMAS\AS1700063" ? "Cato Yeung Pui Kwan (楊沛昆)"
                    : currentUser == @"KMAS\AS060701057" ? "Nakata" : "";

                GlobalService.User = name;
            }
            else
            {
                throw new Exception("User does not belongs to KMHK or KMAS");
            }

            //GlobalService.User = "Hara Masatoshi(原雅俊)";
            //GlobalService.User = "Anna Liu Yin Na (廖燕娜)";
            //GlobalService.DbTable = "TB_hk170001";

            if (!worker.IsBusy)
                worker.RunWorkerAsync();
        }

        delegate void SetProgressBarCallback(int value);
        private void SetProgressBar(int value)
        {
            if (InvokeRequired)
            {
                SetProgressBarCallback callback = new SetProgressBarCallback(SetProgressBar);
                this.Invoke(callback, new object[] { value });
            }
            else
                pbLoading.Value = value;
        }

        delegate void SetLabelCallback(string text);
        private void SetLabel(string text)
        {
            if (InvokeRequired)
            {
                SetLabelCallback callback = new SetLabelCallback(SetLabel);
                this.Invoke(callback, new object[] { text });
            }
            else
                lblMsg.Text = text;
        }
        
        private void LoadUserAppData()
        {
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string userfilePath = Path.Combine(localAppData, "KDTHK");

            if (!Directory.Exists(userfilePath))
                Directory.CreateDirectory(userfilePath);

            string sourceFilePath = Path.Combine(Application.StartupPath, "LocalDb.sdf");
            string destFilePath = Path.Combine(userfilePath, "LocalDb.sdf");

            if (!File.Exists(destFilePath))
                File.Copy(sourceFilePath, destFilePath);

            GlobalService.UserAppDataFolder = destFilePath;
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                SetProgressBar(60);

                SetLabel("Initializing components");

                //this.LoadUserAppData();

                SetProgressBar(100);

                SetLabel("Getting user information");

                //GlobalService.User = "Hara Masatoshi(原雅俊)";
                //GlobalService.DbTable = "TB_hk950097";

                /*if (domain == "kmhk.local")
                    GlobalService.DbTable = "TB_" + AdUtil.GetUserIdByUsername(GlobalService.User, "kmhk.local");
                else
                {
                    string id = AdUtil.GetUserIdByUsername(GlobalService.User, domain);

                    string tb = id == "as1600048" ? "hk070022"
                        : id == "as1600049" ? "hk110017"
                        : id == "as1600050" ? "hk040015"
                        : id == "as1600051" ? "hk160002"
                        : id == "as1600053" ? "hk950330"
                        : id == "as1600054" ? "hk110023"
                        : id == "as1600055" ? "hk120027"
                        : id == "as1600056" ? "hk140005" : "";

                    GlobalService.DbTable = "TB_" + tb;

                    string name = id == "as1600048" ? "Chow Chi To(周志滔,Sammy)"
                        : id == "as1600049" ? "Ling Wai Man(凌慧敏,Velma)"
                        : id == "as1600050" ? "Chan Fai Lung(陳輝龍,Onyx)"
                        : id == "as1600051" ? "Ng Lau Yu, Lilith (吳柳如)"
                        : id == "as1600053" ? "Lee Miu Wah(李苗華)"
                        : id == "as1600054" ? "Lee Ming Fung(李銘峯)"
                        : id == "as1600055" ? "Ho Kin Hang(何健恒,Ken)"
                        : id == "as1600056" ? "Yeung Wai, Gabriel (楊偉)" : "";

                    GlobalService.User = name;
                }*/

                //List<string> list = new List<string>();
                //list.Add(GlobalService.User);
                //EmailUtil.SendNotificationEmail(list);

                GlobalService.User = GlobalService.User.Trim();

                try
                {
                    SetLabel("Synchronizing data");

                    SharedUtil.AutoDeleteData();

                    Stopwatch sw = new Stopwatch();

                    sw.Start();
                    GlobalService.DepartmentFolder = SetupUtil.GetDepartmentFolder(GlobalService.User);
                    sw.Stop();
                    Debug.WriteLine("Get Department Folder: " + sw.Elapsed);

                    sw.Reset();
                    sw.Start();
                    GlobalService.DivisionMemberList = SystemUtil.DivisionMember(GlobalService.User);
                    sw.Stop();
                    Debug.WriteLine("Get Division Memeber: " + sw.Elapsed);

                    sw.Reset();
                    sw.Start();
                    GlobalService.DepartmentMemberList = SystemUtil.DepartmentMember(GlobalService.User);
                    sw.Stop();
                    Debug.WriteLine("Get Department Member: " + sw.Elapsed);

                    sw.Reset();
                    sw.Start();
                    GlobalService.SystemGroupList = GroupUtil.SystemGroupList();
                    GlobalService.CNGroupList = GroupUtil.CnGroupList();
                    GlobalService.VNGroupList = GroupUtil.VnGroupList();
                    GlobalService.JPGroupList = GroupUtil.JpGroupList();
                    sw.Stop();
                    Debug.WriteLine("Get System Group: " + sw.Elapsed);

                    sw.Reset();
                    sw.Start();
                    GlobalService.CustomGroupList = GroupUtil.CustomGroupList2(GlobalService.User);
                    sw.Stop();
                    Debug.WriteLine("Get Custom Group: " + sw.Elapsed);

                    sw.Reset();
                    sw.Start();
                    GlobalService.AllUserList = UserUtil.AllUserList();
                    GlobalService.CnUserList = UserUtil.CnUserList();
                    GlobalService.VnUserList = UserUtil.VnUserList();
                    GlobalService.JpUserList = UserUtil.JpUserList();
                    sw.Stop();
                    Debug.WriteLine("Get All User: " + sw.Elapsed);

                    sw.Reset();
                    sw.Start();
                    GlobalService.AttachmentList = new List<lists.AttachmentList>();
                    sw.Stop();
                    Debug.WriteLine("Initialize attachment list: " + sw.Elapsed);

                    sw.Reset();
                    sw.Start();
                    GlobalService.ExtraSystemGroupList = GroupUtil.ExtraSystemGroupList();
                    sw.Stop();
                    Debug.WriteLine("Get Extra System Group: " + sw.Elapsed);

                    sw.Reset();
                    sw.Start();
                    GlobalService.NoticeList = MessageUtil.GetNoticeList();
                    sw.Stop();
                    Debug.WriteLine("Get Notice list: " + sw.Elapsed);

                    GlobalService.IsPasswordInput = false;

                    sw.Reset();
                    sw.Start();
                    GlobalService.DiscList = DiscUtil.PopulateDiscList();
                    sw.Stop();
                    Debug.WriteLine("Populate Disc List: " + sw.Elapsed);

                    sw.Reset();
                    sw.Start();
                    GlobalService.Division = SystemUtil.GetDivision(GlobalService.User);
                    sw.Stop();
                    Debug.WriteLine("Get Division: " + sw.Elapsed);

                    sw.Reset();
                    sw.Start();
                    GlobalService.AppsList = SystemUtil.AppsList();
                    sw.Stop();
                    Debug.WriteLine("Get Application list: " + sw.Elapsed);

                    sw.Reset();
                    sw.Start();
                    GlobalService.DocumentList = new List<lists.DocumentList>();
                    sw.Stop();
                    Debug.WriteLine("Initialize Document List: " + sw.Elapsed);

                    sw.Reset();
                    sw.Start();
                    GlobalService.ContactList = ContactUtil.ContactList();
                    sw.Stop();
                    Debug.WriteLine("Load Contact List: " + sw.Elapsed);

                    GetSystemVersion();

                    UpdateCommon();

                    SharedUtil.UpdateEmptyShared();

                    SharedUtil.UpdateShared();

                    Login();

                    //DataUtil.SyncDataToServer();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message + ex.StackTrace);
                }
            }
            catch (ArgumentException ex)
            {
                File.WriteAllText(@"D:\Error.txt", ex.Message + ex.StackTrace);
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Login()
        {
            string query = string.Format("update TB_C_EXT set t_lastlogin = '{0}', t_status = 'Online' where t_staff = N'{1}'", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"), GlobalService.User);
            DataServiceGeneral.GetInstance().ExecuteNonQuery(query);
        }

        private void GetSystemVersion()
        {
            string version = "3.0";
            string datetime = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            string query = string.Format("if not exists (select * from TB_VERSION where v_name = N'{0}')" +
                " insert into TB_VERSION (v_name, v_version, v_lastlogin) values (N'{0}', '{1}', '{2}') else" +
                " update TB_VERSION set v_version = '{1}', v_lastlogin = '{2}' where v_name = N'{0}'", GlobalService.User, version, datetime);

            DataService.GetInstance().ExecuteNonQuery(query);
        }

        private void UpdateCommon()
        {
            string query = string.Format("update " + GlobalService.DbTable + " set r_vpath = replace(r_vpath, '{0}', '{1}')", @"\Documents\Common", @"\Common");
            DataService.GetInstance().ExecuteNonQuery(query);
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                SetProgressBar(100);

                Main main = new Main();
                main.Show();

                this.Hide();
            }
            catch (ArgumentException ex)
            {
                File.WriteAllText(@"D:\Error.txt", ex.Message + ex.StackTrace);
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
