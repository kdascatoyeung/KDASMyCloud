using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KDTHK_DM_SP.services;
using CustomUtil.utils.authentication;
using System.Net.Mail;
using System.Diagnostics;

namespace KDTHK_DM_SP.utils
{
    public class EmailUtil
    {
        public static void SendNotificationEmail(List<string> receiverList)
        {
            try
            {
                string fromEmail = AdUtil.GetEmailByUsername(GlobalService.User, "kmhk.local");

                string hostname = "Kdmail.km.local";

                string text = "Dear colleague,<br/><br/>You have received file from " + GlobalService.User + ". Please use the link below to read file.<br/><br/>" +
                    "<a href=\"\\\\172.16.13.231\\project\\KDTHK-DM\\littlesource\\LittleCloud.xlsm\">Installation Source (Excel 2007 or above)</a><br/><br/>" +
                    "<a href=\"\\\\172.16.13.231\\project\\KDTHK-DM\\littlesource\\LittleCloud.xls\">Installation Source (Excel 2003 only)</a><br/><br/>" +
                "If you have any questions, please follow the instruction below.<br/><a href=\"\\\\172.16.13.231\\project\\KDTHK-DM\\littlesource\\Enable Macro.pdf\">Installation Guide</a><br/><br/>Regards";

                string content = "<p><span style=\"font-family: Calibri;\">" + text + "</span></p>";

                string subject = "File Received";

                foreach (string user in receiverList)
                {
                    string domain = UserUtil.IsCnMember(user) ? "kmcn.local"
                        : UserUtil.IsVnMember(user) ? "kdtvn.local"
                        : UserUtil.IsJpMember(user) ? "km.local" : "kmhk.local";

                    string toEmail = AdUtil.GetEmailByUsername(user, domain);

                    if (user == GlobalService.User)
                        continue;

                    if (!IsEmailSent(toEmail))
                    {
                        SmtpClient client = new SmtpClient(hostname);
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;

                        MailMessage mail = new MailMessage(fromEmail, toEmail);
                        mail.IsBodyHtml = true;
                        mail.Subject = subject;
                        mail.Body = content;
                        client.Send(mail);

                        string query = string.Format("insert into TB_EMAIL_RECORD (e_datetime, e_name, e_from, e_receiver, e_to) values ('{0}', N'{1}', N'{2}', N'{3}', N'{4}')", DateTime.Now.ToString("yyyy/MM/dd HH:mm"),
                            GlobalService.User, fromEmail, user, toEmail);
                        DataService.GetInstance().ExecuteNonQuery(query);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message + ex.StackTrace);
            }
        }

        public static bool IsEmailSent(string to)
        {
            string query = string.Format("select * from TB_EMAIL_RECORD where e_to = '{0}'", to);
            using (GlobalService.Reader = DataService.GetInstance().ExecuteReader(query))
            {
                if (GlobalService.Reader.HasRows)
                    return true;
            }
            return false;
        }
    }
}
