using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KDTHK_DM_SP.services;
using System.Net.Mail;
using System.Net.Mime;
using Itenso.Rtf;
using Itenso.Rtf.Support;
using Itenso.Rtf.Converter.Html;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace KDTHK_DM_SP.utils
{
    public class EformUtil
    {
        public static string GetHead(string staff)
        {
            string query = string.Format("select s_head from TB_C_STAFF where s_name = N'{0}'", staff.Trim());
            return DataServiceHR.GetInstance().ExecuteScalar(query).ToString();
        }

        public static string GetInCharge(string category)
        {
            string query = string.Format("select fm_name from TB_FORM_MASTER where fm_category = N'{0}'", category.Trim());

            return DataService.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetR3Status(string chaseno)
        {
            string query = string.Format("select r_status from TB_FORM_R3 where r_chaseno = '{0}'", chaseno);
            return DataService.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetR3Id(string chaseno)
        {
            string query = string.Format("select r_r3id from TB_FORM_R3 where r_chaseno = '{0}'", chaseno);
            return DataService.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetR3Request(string chaseno)
        {
            string query = string.Format("select r_request from TB_FORM_R3 where r_chaseno = '{0}'", chaseno);
            return DataService.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static string GetR3Reason(string chaseno)
        {
            string query = string.Format("select r_reason from TB_FORM_R3 where r_chaseno = '{0}'", chaseno);
            return DataService.GetInstance().ExecuteScalar(query).ToString().Trim();
        }

        public static void SendNotificationEmail(string chaseno,string category, string sender, string from, string title, string body, int width, int height, RtfPrintUtil rtb)
        {
            string hostname = "Kdmail.km.local";

            string to = UserUtil.ItMail1();
            //string to = "gabriel.yeung@dthk.kyocera.com";
            //string to = "ken.ho@dthk.kyocera.com";

            string subject = "Application received - " + title;

            SmtpClient client = new SmtpClient(hostname);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            string body2 = "Application no. : " + chaseno + "<br />Category: " + category + "<br />Content: <br />";

            string html = "";

            if (body != "")
            {
                Image tmpImg = new Bitmap(width, height + 20);
                Graphics g = Graphics.FromImage(tmpImg);

                rtb.PrintImage(0, g);

                if (!Directory.Exists(@"C:\temp\images"))
                    Directory.CreateDirectory(@"C:\temp\images");

                tmpImg.Save(@"C:\temp\images\temp.png", System.Drawing.Imaging.ImageFormat.Png);

                g.Dispose();

                var img = new LinkedResource(@"C:\temp\images\temp.png");
                img.ContentId = Guid.NewGuid().ToString();

                html = body2 + string.Format(@"<p></p><img src =""cid:{0}""/>", img.ContentId);

                var view = AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html);
                view.LinkedResources.Add(img);
               // view.ContentType = new ContentType("text/html");

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, sender, Encoding.UTF8);
                mail.To.Add(to);
                //mail.CC.Add(UserUtil.ItMail1());
                mail.CC.Add(UserUtil.ItMail2());
                mail.CC.Add(UserUtil.ItMail3());
                mail.CC.Add(UserUtil.HkRpsMail1());
                mail.CC.Add(UserUtil.HkHrMail3());
                //mail.CC.Add("onyx.chan@dthk.kyocera.com");
                //mail.CC.Add("mingfung.lee@dthk.kyocera.com");
                //mail.CC.Add("ken.ho@dthk.kyocera.com");
                //mail.CC.Add("ezra.chan@dthk.kyocera.com");
                //mail.CC.Add("ava.yiu@dthk.kyocera.com");
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = html;
                mail.AlternateViews.Add(view);
                client.Send(mail);
            }
            else
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, sender, Encoding.UTF8);
                mail.To.Add(UserUtil.ItMail4());
                mail.CC.Add(UserUtil.ItMail2());
                mail.CC.Add(UserUtil.ItMail3());
                //mail.To.Add("ken.ho@dthk.kyocera.com");
                //mail.CC.Add("onyx.chan@dthk.kyocera.com");
                //mail.CC.Add("mingfung.lee@dthk.kyocera.com");
                //mail.CC.Add("ken.ho@dthk.kyocera.com");
                mail.Subject = subject;
                mail.IsBodyHtml = true;
                mail.Body = body2;
                client.Send(mail);
            }
            
        }

        public static void SendR3NotificationEmail(string chaseno, string category, string sender, string from, string title, string r3Id, string request, string reason)
        {
            string hostname = "Kdmail.km.local";

            //string to = "ken.ho@dthk.kyocera.com";//"onyx.chan@dthk.kyocera.com";
            string to = UserUtil.ItMail2();//"onyx.chan@dthk.kyocera.com";

            string subject = "Application received - " + title;

            SmtpClient client = new SmtpClient(hostname);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            string body2 = "Application no. : " + chaseno + "<br />Category: " + category + "<br />Content: <br />";

            string html = "R3 ID : "+ r3Id + "<br /><br />申請依賴 : " + request + "<br /><br />理由 : " + reason;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from, sender, Encoding.UTF8);
            mail.To.Add(to);
            //mail.CC.Add("caleb.fuh@dthk.kyocera.com");
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body2 + html;

            client.Send(mail);
        }

        public static void SendR3FinishedEmail(string from, string sender, string chaseno, string category, string r3Id, string request, string reason)
        {
            string hostname = "Kdmail.km.local";

            string to = UserUtil.ItMail2();
            //string to = "onyx.chan@dthk.kyocera.com";

            string subject = "R3申請 - 經管已承認";

            SmtpClient client = new SmtpClient(hostname);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            string body2 = "Application no. : " + chaseno + "<br />Category: " + category + "<br />Content: <br />";

            string html = "R3 ID : " + r3Id + "<br /><br />申請依賴 : " + request + "<br /><br />理由 : " + reason;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from, sender, Encoding.UTF8);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body2 + html;

            client.Send(mail);

        }

        public static void SendReceivedEmail(string chaseno, string to, string title)
        {
            string hostname = "Kdmail.km.local";

            string from = "itadmin@dthk.kyocera.com";

            string subject = "Application submitted - " + title;

            string body = "We have received your application and will process it as soon as possible.\n\nApplication no. : " + chaseno;

            SmtpClient client = new SmtpClient(hostname);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from, "IT Admin", Encoding.UTF8);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;

            client.Send(mail);
        }

        public static void SendOutstandingApprovedEmail(string chaseno, string sender, string from, string to, string title)
        {
            string hostname = "Kdmail.km.local";

            string subject = "Outstanding Slip has been approved - " + title;

            string body = "Your oustanding slip has been approved and ready for printing.\n\nApplication no. : " + chaseno;

            SmtpClient client = new SmtpClient(hostname);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from, sender, Encoding.UTF8);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;

            client.Send(mail);
        }

        public static void SendApprovalEmail(string chaseno, string sender, string from, string to, string content, string title)
        {
            string hostname = "Kdmail.km.local";

            string subject = "Approval Required - " + title;

            SmtpClient client = new SmtpClient(hostname);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            var img = new LinkedResource("images/imgemail.png");
            img.ContentId = Guid.NewGuid().ToString();

            content = content + string.Format(@"<p></p><img src =""cid:{0}""/>", img.ContentId);

            var view = AlternateView.CreateAlternateViewFromString(content, null, MediaTypeNames.Text.Html);
            view.LinkedResources.Add(img);

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from, sender, Encoding.UTF8);
            mail.To.Add(to);
            mail.Subject = subject;
            //mail.Body = content;
            mail.AlternateViews.Add(view);
            mail.IsBodyHtml = true;
            client.Send(mail);
        }

        public static void SendDebitNotificationEmail(string chaseno, string sender, string from, string to, string content)
        {
            string hostname = "Kdmail.km.local";

            string subject = "Application received - " + chaseno;

            SmtpClient client = new SmtpClient(hostname);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from, sender, Encoding.UTF8);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = content;
            mail.IsBodyHtml = true;
            client.Send(mail);
        }

        public static void SendRejectEmail(string chaseno, string sender, string from, string to, string subject, string content)
        {
            string hostname = "Kdmail.km.local";

            SmtpClient client = new SmtpClient(hostname);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from, sender, Encoding.UTF8);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = content;
            client.Send(mail);
        }

        public static void SendFinishedEmail(string chaseno, string sender, string from, string to, string subject, string content)
        {
            string hostname = "Kdmail.km.local";

            SmtpClient client = new SmtpClient(hostname);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from, sender, Encoding.UTF8);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = content;
            client.Send(mail);
        }
    }
}
