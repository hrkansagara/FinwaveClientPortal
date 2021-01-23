using FinwaveClientFrontOffice.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinwaveClientFrontOffice.Controllers
{
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