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
}