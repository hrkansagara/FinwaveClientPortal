using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinwaveClientFrontOffice.Controllers
{
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