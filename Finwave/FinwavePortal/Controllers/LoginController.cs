using FinwavePortal.Models;
using FinwavePortal.Services;
using System.Web.Mvc;

namespace FinwavePortal.Controllers
{
    public class LoginController : Controller
    {
        private LoginService objLoginService;

        public LoginController()
        {
            objLoginService = new LoginService();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="ouser"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index(Login ouser)
        {
            ouser.Password = PasswordSecurity.EncryptPassword(ouser.Password);
            Login oLogin = objLoginService.LoginUser(ouser);
            if (oLogin != null)
            {
                SessionVars.CurrentUser = oLogin;
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                return View();
            };

        }

        /// <summary>
        /// Clear
        /// </summary>
        /// <returns></returns>
        public ActionResult Clear()
        {
            Session.Clear();
            SessionVars.CurrentUser = null;
            return RedirectToAction("Index", "Login");
        }

    }
}