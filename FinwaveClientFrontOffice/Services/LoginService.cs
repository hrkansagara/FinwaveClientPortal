using FinwaveClientFrontOffice.Common;
using FinwaveClientFrontOffice.Models;
using FinwaveClientFrontOffice.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace FinwaveClientFrontOffice.Services
{
    public class LoginService : ILoginService
    {
        private readonly LoginRepository _objLoginRepository;
        /// <summary>
        /// LoginService
        /// </summary>
        public LoginService(LoginRepository objLoginRepository)
        {
            _objLoginRepository = objLoginRepository;
        }

        /// <summary>
        /// LoginUser
        /// </summary>
        /// <param name="oLogin"></param>
        /// <returns></returns>
        public Login LoginUser(Login oLogin)
        {
            return _objLoginRepository.LoginUser(oLogin);
        }

        /// <summary>
        /// LoginUser
        /// </summary>
        /// <param name="oLogin"></param>
        /// <returns></returns>
        public Login UserDetailByUserName(Login oLogin)
        {
            return _objLoginRepository.UserDetailByUserName(oLogin);
        }

        /// <summary>
        /// Update Passward By Clientname
        /// </summary>
        /// <param name="oLogin"></param>
        /// <returns></returns>
        public SaveResponse UpdatePasswardByClientname(Login oLogin)
        {
            return _objLoginRepository.UpdatePasswardByClientname(oLogin);
        }

        /// <summary>
        /// Save User Details
        /// </summary>
        /// <param name="oAccountModel"></param>
        /// <returns></returns>
        public SaveResponse SaveUserDetails(AccountModel oAccountModel)
        {
            return _objLoginRepository.SaveUserDetails(oAccountModel);
        }

        /// <summary>
        /// Get Client Bank All Detail By Client Code
        /// </summary>
        /// <param name="ClientCode"></param>
        /// <returns></returns>
        public HttpResponseMessage GetClientBankAllDetailByClientCode(string ClientCode)
        {
            var response = new HttpResponseMessage();

            var builerUrl = Convert.ToString(ConfigurationManager.AppSettings["UrlTechexcelapi"] + "kycMaster/GetMaster");
            var builder = new UriBuilder(builerUrl);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["UrlUserName"] = Convert.ToString(ConfigurationManager.AppSettings["UrlUserName"]);
            query["UrlPassword"] = Convert.ToString(ConfigurationManager.AppSettings["UrlPassword"]);
            query["UrlDatabase"] = Convert.ToString(ConfigurationManager.AppSettings["UrlDatabase"]);
            query["UrlDataYear"] = Convert.ToString(ConfigurationManager.AppSettings["UrlDataYear"]);
            query["ClientCode"] = ClientCode;
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