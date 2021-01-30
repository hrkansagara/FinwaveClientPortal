using FinwaveClientFrontOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinwaveClientFrontOffice.Services
{
    public interface ILoginService
    {
        Login LoginUser(Login oLogin);

        Login GetUserByUserName(Login oLogin);
    }
}