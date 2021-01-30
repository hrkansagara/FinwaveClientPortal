using FinwaveClientFrontOffice.Authorization;
using System.Web.Mvc;

namespace FinwaveClientFrontOffice.Controllers
{
    [UserAuthorization]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }
    }
}