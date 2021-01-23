using FinwavePortal.Models;
using FinwavePortal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinwavePortal.Services
{
    public class LoginService : ILoginService
    {
        private readonly LoginRepository _objLoginRepository;
        /// <summary>
        /// LoginService
        /// </summary>
        public LoginService()
        {
            _objLoginRepository = new LoginRepository();
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
    }
}