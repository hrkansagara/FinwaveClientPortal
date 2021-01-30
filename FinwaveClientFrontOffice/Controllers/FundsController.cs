using FinwaveClientFrontOffice.Authorization;
using System.Web.Mvc;

namespace FinwaveClientFrontOffice.Controllers
{
    [UserAuthorization]
    public class FundsController : Controller
    {
        // GET: Funds
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPartialDPStatement()
        {
            return PartialView("~/Views/Funds/_PartialDPStatement.cshtml");
        }
    }
}