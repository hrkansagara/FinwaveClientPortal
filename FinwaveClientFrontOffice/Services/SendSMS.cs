using System.IO;
using System.Net;

namespace FinwaveClientFrontOffice.Services
{
    public class SendSMS
    {
        #region Variable
        string _mobile = string.Empty;
        string _message = string.Empty;
        string _username = "airan"; //"safalcapital1";
        string _password = "airanfin";//"safal123";
        string _domain = "sms.infisms.co.in";//"bulk-sms.in";
        string _sender = "AIRAFN"; //"EKARNF";
        #endregion

        #region Property
        public string mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        public string message
        {
            get { return _message; }
            set { _message = value; }
        }
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string domian
        {
            get { return _domain; }
            set { _domain = value; }
        }
        public string sender
        {
            get { return _sender; }
            set { _sender = value; }
        }
        #endregion

        #region Methods
        public string apicall()
        {
            //priority :Route id for the selected route(4 - OTP , 8 - Promo , 11 - Transational , 12 - Scrub , 18 - Intrl
            //"http://bulk-sms.in/pushsms.php?username=safalcapital1&password=safal123&sender=EKARNF&to=7405415306&message=HI&priority=4"
            //string url = "http://" + domian + "/pushsms.php?username=" + username + "&password=" + password + "&sender=" + sender + "&to=" + mobile + "&message=" + message + "&priority=4";
            string url = "http://" + domian + "/API/SendSMS.aspx?UserID=" + username + "&UserPassword=" + password + "&SenderId=" + sender + "&PhoneNumber=" + mobile + "&Text=" + message + "&AccountType=2&MessageType=0";
            HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                StreamReader sr = new StreamReader(httpres.GetResponseStream());

                string results = sr.ReadToEnd();
                sr.Close();
                return results;
            }
            catch
            {
                return "0";
            }
        }
        #endregion
    }
}