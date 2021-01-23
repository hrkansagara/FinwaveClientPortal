using FinwaveClientFrontOffice.Models;
using System;
using System.Configuration;
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
    }
}