using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace FinwaveClientFrontOffice.Common
{
    public class SendEmail
    {
        public static String _curErrorMessage = "";
        public enum EmailTemplateType
        {
            Password = 1,
            WelcomeMail = 2,
            OTP = 3,
            eSignLink = 4,
            VideoKYCLink = 5
        }

        public SendEmail()
        {

        }

        public static bool SentEmail(String recepientEmail, String bccEmail, string subject, string body, String AttachmentPath)
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;

                //Create the SmtpClient object  (assumes using localhost)
                System.Net.Mail.SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["SMTPAdd"]);
                //smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FromEmail"], ConfigurationManager.AppSettings["FromPass"]);

                //Create the MailMessage object 
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                //Assign from address 
                msg.From = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["FromEmail"]);
                //Assign to address
                msg.To.Add(new System.Net.Mail.MailAddress(recepientEmail));
                //if (pCc.Trim() != "")
                //{
                //    String[] Emails = pCc.Split(',');
                //    for (int i = 0; i < Emails.Length; i++)
                //    {
                //        msg.CC.Add(new System.Net.Mail.MailAddress(Emails[i]));
                //    }
                //    //msg.CC.Add(new System.Net.Mail.MailAddress(pCc));
                //    //msg.Bcc.Add(new System.Net.Mail.MailAddress(pCc));
                //}

                if (bccEmail.Trim() != "")
                {
                    String[] BEmails = bccEmail.Split(',');
                    for (int i = 0; i < BEmails.Length; i++)
                    {
                        msg.Bcc.Add(new System.Net.Mail.MailAddress(BEmails[i]));
                    }
                }

                //assign subject, and body
                msg.Subject = subject;
                msg.Body = body;
                //msg.IsBodyHtml = Convert.ToBoolean(pFormat);
                msg.IsBodyHtml = true;
                if (AttachmentPath.Trim() != "")
                {
                    msg.Attachments.Add(new System.Net.Mail.Attachment(AttachmentPath));
                }
                //Send the message with SmtpClient
                smtp.EnableSsl = true;
                smtp.Port = 587;
                //if (Utils.IsHttps()) smtp.Port = 465;
                //smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                //smtp.Timeout = 20000;
                //smtp.Timeout = 100;
                smtp.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool SentEmaiEKCYl(String recepientEmail, String bccEmail, string subject, string body, String AttachmentPath)
        {
            try
            {
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)768 | (SecurityProtocolType)3072;

                //Create the SmtpClient object  (assumes using localhost)
                System.Net.Mail.SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["SMTPAdd"]);
                //smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EkYCFromEmail"], ConfigurationManager.AppSettings["EkYCFromPass"]);

                //Create the MailMessage object 
                System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
                //Assign from address 
                msg.From = new System.Net.Mail.MailAddress(ConfigurationManager.AppSettings["EkYCFromEmail"]);
                //Assign to address
                msg.To.Add(new System.Net.Mail.MailAddress(recepientEmail));
                //if (pCc.Trim() != "")
                //{
                //    String[] Emails = pCc.Split(',');
                //    for (int i = 0; i < Emails.Length; i++)
                //    {
                //        msg.CC.Add(new System.Net.Mail.MailAddress(Emails[i]));
                //    }
                //    //msg.CC.Add(new System.Net.Mail.MailAddress(pCc));
                //    //msg.Bcc.Add(new System.Net.Mail.MailAddress(pCc));
                //}

                if (bccEmail.Trim() != "")
                {
                    String[] BEmails = bccEmail.Split(',');
                    for (int i = 0; i < BEmails.Length; i++)
                    {
                        msg.Bcc.Add(new System.Net.Mail.MailAddress(BEmails[i]));
                    }
                }

                //assign subject, and body
                msg.Subject = subject;
                msg.Body = body;
                //msg.IsBodyHtml = Convert.ToBoolean(pFormat);
                msg.IsBodyHtml = true;
                if (AttachmentPath.Trim() != "")
                {
                    msg.Attachments.Add(new System.Net.Mail.Attachment(AttachmentPath));
                }
                //Send the message with SmtpClient
                smtp.EnableSsl = true;

                smtp.Port = 587;
                //if (Utils.IsHttps()) smtp.Port = 465;
                //smtp.Timeout = 100;
                smtp.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string GetEmailBody(EmailTemplateType curEmailTemplateType)
        {
            String EmailPath = String.Empty;

            if (curEmailTemplateType == EmailTemplateType.Password)
            {
                EmailPath = System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/Passwordsent.html");
            }
            else if (curEmailTemplateType == EmailTemplateType.OTP)
            {
                EmailPath = System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/OTP.html");
            }
            else if (curEmailTemplateType == EmailTemplateType.eSignLink)
            {
                EmailPath = System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/eKYCLink.html");
            }
            else if (curEmailTemplateType == EmailTemplateType.VideoKYCLink)
            {
                EmailPath = System.Web.HttpContext.Current.Server.MapPath("~/EmailTemplates/VideoKYCLink.html");
            }

            string body = string.Empty;
            using (StreamReader reader = new StreamReader(EmailPath))
            {
                body = reader.ReadToEnd();
            }
            return body;
        }

    }
}