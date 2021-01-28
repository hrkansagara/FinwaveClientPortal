using FinwaveClientFrontOffice.Models;
using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;

namespace FinwaveClientFrontOffice.Common
{
    public static class SessionHelper
    {
        public static Login CurrentUser
        {
            get
            {
                try
                {
                    if (HttpContext.Current.Session["CurrentUser"] == null)
                    {
                        return null;
                    }
                    return (Login)HttpContext.Current.Session["CurrentUser"];
                }
                catch
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["CurrentUser"] = value; HttpContext.Current.Session.Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeout"]); }

        }

        public static AccountModel CurrentOtpUser
        {
            get
            {
                try
                {
                    if (HttpContext.Current.Session["CurrentOTPUser"] == null)
                    {
                        return null;
                    }
                    return (AccountModel)HttpContext.Current.Session["CurrentOTPUser"];
                }
                catch
                {
                    return null;
                }
            }
            set { HttpContext.Current.Session["CurrentOTPUser"] = value; HttpContext.Current.Session.Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["SessionTimeout"]); }

        }
    }
    public class Response
    {
        public bool Success { get; set; }
        public string ResponseString { get; set; }

        public Response()
        {
            Success = true;
            ResponseString = string.Empty;
        }

        public Response(bool Success, string ResponseString)
        {
            this.Success = Success;
            this.ResponseString = ResponseString;
        }
    }

    public class SaveResponse
    {
        public bool Success { get; set; }
        public string ResponseString { get; set; }
        public string Cid { get; set; }
        public string OtherMessage { get; set; }
        public object Data { get; set; }

        public SaveResponse()
        {
            Success = false;
        }

        public SaveResponse(bool successOrFailure, string responseMessage, string identifier)
        {
            Cid = identifier;
            Success = successOrFailure;
            ResponseString = responseMessage;
        }
        public SaveResponse(bool successOrFailure, string responseMessage, string identifier, dynamic data)
        {
            Cid = identifier;
            Success = successOrFailure;
            ResponseString = responseMessage;
            this.Data = data;
        }
    }

    public class SMTPEmail
    {
        public static async Task<bool> SendEmail(Tuple<string, string, string> mailObj)
        {
            string SMTPUserName = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["SMTPUserName"]].ToString();
            string SMTPFrom = ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["SMTPFrom"]].ToString();
            try
            {
                MailMessage mail = new MailMessage(SMTPFrom, mailObj.Item1);
                mail.IsBodyHtml = true;
                mail.Subject = mailObj.Item2;
                mail.Body = mailObj.Item3;

                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["SMTPHost"]].ToString());
                client.Port = Convert.ToInt32(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["SMTPPort"]].ToString());
                client.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["EnableSsl"]].ToString());
                client.UseDefaultCredentials = false; // Important : This line Of code must be executed before setting the NetworkCredentials Object, otherwise the setting will be reset (a bug in .NET)
                NetworkCredential cred = new NetworkCredential(SMTPUserName, ConfigurationManager.AppSettings[ConfigurationManager.AppSettings["SMTPPassword"]].ToString());
                client.Credentials = cred;
                await client.SendMailAsync(mail).ConfigureAwait(false);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

