using FinwavePortal.Authorization;
using FinwavePortal.Models;
using FinwavePortal.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FinwavePortal.Controllers
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

        public ActionResult HDFCTransactionListView()
        {
            return View("HDFCTransactionList");
        }

        /// <summary>
        /// Get Intraday Transection List
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetIntradayTransectionList()
        {
            try
            {
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                //Paging Size (10,20,50,100)    
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;

                // Filter them

                SearchParamModel searchParamModel = new SearchParamModel();
                var fromDate = Request["FromDate"];
                var toDate = Request["ToDate"];
                if(!string.IsNullOrEmpty(fromDate))
                {
                    searchParamModel.FromDate = fromDate;
                }
                if (!string.IsNullOrEmpty(toDate))
                {
                    searchParamModel.ToDate =toDate;
                }

                //Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    searchParamModel.SortExp = sortColumn + " " + sortColumnDir;
                }
                else
                {
                    searchParamModel.SortExp = "RecordId DESC";
                }
                searchParamModel.PageSize = 25;
                searchParamModel.PageIndex = 1;
                List<IntradayTransactionModel> intradayTransactionData = _dashboardService.GetTransactionList(searchParamModel);

                //Getting the total count  to display on the grid pagination.    
                long TotalRecordsCount = intradayTransactionData.Count();

                //count of record after filter   
                long FilteredRecordCount = intradayTransactionData.Count();

                var lstIntradayTransactionData = intradayTransactionData.Skip(skip).Take(pageSize).ToList();


                // To avoid object reference error incase of lstIntradayTransactionData being null.    
                if (lstIntradayTransactionData == null)
                    lstIntradayTransactionData = new List<IntradayTransactionModel>();


                return this.Json(new
                {
                    draw = Convert.ToInt32(draw),
                    recordsTotal = TotalRecordsCount,
                    recordsFiltered = FilteredRecordCount,
                    data = lstIntradayTransactionData
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}