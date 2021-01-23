using System;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace FinwaveClientFrontOffice.Services
{
    public class AccountService : IAccountService
    {
        public HttpResponseMessage GetClientDetailByClientCode(string ClientCode)
        {
            var response = new HttpResponseMessage();

            var builerUrl = Convert.ToString(ConfigurationManager.AppSettings["UrlTechexcelapi"] + "ClientList/ClientList");
            var builder = new UriBuilder(builerUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["UrlUserName"] = Convert.ToString(ConfigurationManager.AppSettings["UrlUserName"]);
            query["UrlPassword"] = Convert.ToString(ConfigurationManager.AppSettings["UrlPassword"]);
            query["UrlDatabase"] = Convert.ToString(ConfigurationManager.AppSettings["UrlDatabase"]);
            query["UrlDataYear"] = Convert.ToString(ConfigurationManager.AppSettings["UrlDataYear"]);
            query["CLIENT_ID"] = ClientCode;
            query["FROM_DATE"] = "";
            query["TO_DATE"] = "";
            builder.Query = query.ToString();

            string url = builder.ToString();

            using (var client = new HttpClient())
            {
                response = client.GetAsync(url).Result;
            }

            return response;
        }

        public HttpResponseMessage GetClientBankDetailByClientCode(string ClientCode)
        {
            var response = new HttpResponseMessage();

            var builerUrl = Convert.ToString(ConfigurationManager.AppSettings["UrlTechexcelapi"] + "ClientBankDetailMultiple/ClientBankDetailMultiple1");
            var builder = new UriBuilder(builerUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["UrlUserName"] = Convert.ToString(ConfigurationManager.AppSettings["UrlUserName"]);
            query["UrlPassword"] = Convert.ToString(ConfigurationManager.AppSettings["UrlPassword"]);
            query["UrlDatabase"] = Convert.ToString(ConfigurationManager.AppSettings["UrlDatabase"]);
            query["UrlDataYear"] = Convert.ToString(ConfigurationManager.AppSettings["UrlDataYear"]);
            query["Client_id"] = ClientCode;
            builder.Query = query.ToString();

            string url = builder.ToString();

            using (var client = new HttpClient())
            {
                response = client.GetAsync(url).Result;
            }
            return response;
        }

        public HttpResponseMessage GetClientBankDetailMultipleAccounts(string ClientCode)
        {
            var response = new HttpResponseMessage();

            var builerUrl = Convert.ToString(ConfigurationManager.AppSettings["UrlTechexcelapi"] +"ClientBankDetailMultiple/ClientBankDetailMultiple1");
            var builder = new UriBuilder(builerUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["UrlUserName"] = Convert.ToString(ConfigurationManager.AppSettings["UrlUserName"]);
            query["UrlPassword"] = Convert.ToString(ConfigurationManager.AppSettings["UrlPassword"]);
            query["UrlDatabase"] = Convert.ToString(ConfigurationManager.AppSettings["UrlDatabase"]);
            query["UrlDataYear"] = Convert.ToString(ConfigurationManager.AppSettings["UrlDataYear"]);
            query["Client_id"] = ClientCode;
            builder.Query = query.ToString();

            string url = builder.ToString();

            using (var client = new HttpClient())
            {
                response = client.GetAsync(url).Result;
            }
            return response;
        }
    }
}