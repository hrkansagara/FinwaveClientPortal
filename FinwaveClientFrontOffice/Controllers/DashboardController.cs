using FinwaveClientFrontOffice.Authorization;
using FinwaveClientFrontOffice.Services;
using System.Web.Mvc;

namespace FinwaveClientFrontOffice.Controllers
{
    [UserAuthorization]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}