using FinwavePortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinwavePortal.Repositories
{
    public interface ILoginRepository
    {
        Login LoginUser(Login oLogin);
    }
}