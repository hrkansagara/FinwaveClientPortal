using FinwaveClientFrontOffice.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web;

namespace FinwaveClientFrontOffice.Services
{
    public class PortfolioService : IPortfolioService
    {
        public HttpResponseMessage GetHoldingDetails(CommonSearch oCommonSearch)
        {
            var response = new HttpResponseMessage();

            var builerUrl = Convert.ToString(ConfigurationManager.AppSettings["UrlTechexcelapi"] + "Holding/Holding1");
            var builder = new UriBuilder(builerUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["UrlUserName"] = Convert.ToString(ConfigurationManager.AppSettings["UrlUserName"]);
            query["UrlPassword"] = Convert.ToString(ConfigurationManager.AppSettings["UrlPassword"]);
            query["UrlDatabase"] = Convert.ToString(ConfigurationManager.AppSettings["UrlDatabase"]);
            query["UrlDataYear"] = Convert.ToString(ConfigurationManager.AppSettings["UrlDataYear"]);
            query["Client_code"] = oCommonSearch.ClientCode;
            query["To_date"] = oCommonSearch.ToDate;
            builder.Query = query.ToString();

            string url = builder.ToString();

            using (var client = new HttpClient())
            {
                response = client.GetAsync(url).Result;
            }
            return response;
        }

        public HttpResponseMessage GetClientLedgerDetails(CommonSearch oCommonSearch)
        {
            var response = new HttpResponseMessage();

            var builerUrl = Convert.ToString(ConfigurationManager.AppSettings["UrlTechexcelapi"] + "Ledger/Ledger1");
            var builder = new UriBuilder(builerUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["UrlUserName"] = Convert.ToString(ConfigurationManager.AppSettings["UrlUserName"]);
            query["UrlPassword"] = Convert.ToString(ConfigurationManager.AppSettings["UrlPassword"]);
            query["UrlDatabase"] = Convert.ToString(ConfigurationManager.AppSettings["UrlDatabase"]);
            query["UrlDataYear"] = Convert.ToString(ConfigurationManager.AppSettings["UrlDataYear"]);
            query["FromDate"] = oCommonSearch.FromDate;
            query["ToDate"] = oCommonSearch.ToDate;
            query["Client_code"] = oCommonSearch.ClientCode;
            query["COCDLIST"] = oCommonSearch.CocdList;
            query["ShowMargin"] = oCommonSearch.ShowMargin;
            builder.Query = query.ToString();

            string url = builder.ToString();

            using (var client = new HttpClient())
            {
                response = client.GetAsync(url).Result;
            }
            return response;
        }

        public HttpResponseMessage GetClientPositionDetails(CommonSearch oCommonSearch)
        {
            var response = new HttpResponseMessage();

            var builerUrl = Convert.ToString(ConfigurationManager.AppSettings["UrlTechexcelapi"] + "Reports2/R44");
            var builder = new UriBuilder(builerUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["UrlUserName"] = Convert.ToString(ConfigurationManager.AppSettings["UrlUserName"]);
            query["UrlPassword"] = Convert.ToString(ConfigurationManager.AppSettings["UrlPassword"]);
            query["UrlDatabase"] = Convert.ToString(ConfigurationManager.AppSettings["UrlDatabase"]);
            query["UrlDataYear"] = Convert.ToString(ConfigurationManager.AppSettings["UrlDataYear"]);
            query["COMPANY_CODE"] = oCommonSearch.CompanyCode;
            query["FROM_DATE"] = oCommonSearch.FromDate;
            query["TO_DATE"] = oCommonSearch.ToDate;
            query["client_code"] = oCommonSearch.ClientCode;
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