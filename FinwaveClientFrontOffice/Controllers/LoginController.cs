using FinwaveClientFrontOffice.Models;
using FinwaveClientFrontOffice.Common;
using System.Web.Mvc;

namespace FinwaveClientFrontOffice.Controllers
{
    public class LoginController : Controller
    {
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
            Login oLogin = new Login();
            if (oLogin != null)
            {
                SessionHelper.CurrentUser = oLogin;
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
            SessionHelper.CurrentUser = null;
            return RedirectToAction("Index", "Login");
        }
    }
}