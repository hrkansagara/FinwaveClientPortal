using FinwaveClientFrontOffice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinwaveClientFrontOffice.Repositories
{
    public interface ILoginRepository
    {
        Login LoginUser(Login oLogin);
        Login UserDetailByUserName(Login oLogin);

        Login GetUserByUserName(Login oLogin);
    }
}