using FinwaveClientFrontOffice.Models;
using FinwaveClientFrontOffice.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace FinwaveClientFrontOffice.Controllers
{
    public class PortfolioController : Controller
    {

        private readonly IPortfolioService _portfolioService;
        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }
        // GET: Portfolio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetPartialPosition()
        {
            return PartialView("~/Views/Portfolio/_PartialPosition.cshtml");
        }
        public ActionResult GetPartialAllocation()
        {
            return PartialView("~/Views/Portfolio/_PartialAllocation.cshtml");
        }
        public ActionResult GetPartialLedger()
        {
            return PartialView("~/Views/Portfolio/_PartialLedger.cshtml");
        }
        public ActionResult GetPartialHoldings()
        {
            return PartialView("~/Views/Portfolio/_PartialHoldings.cshtml");
        }
        /// <summary>
        /// Get Position Details
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetPositionDetails()
        {
            try
            {
                var lstMultipleDateOfPosition = new List<MultipleDateOfPosition>();
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

                CommonSearch oCommonsearch = new CommonSearch();
                var toDate = Request["ToDate"];
                if (!string.IsNullOrEmpty(toDate))
                {
                    DateTime date = DateTime.ParseExact(toDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    oCommonsearch.ToDate = date.ToString("dd/MM/yyyy");
                }
                var fromDate = Request["FromDate"];
                if (!string.IsNullOrEmpty(fromDate))
                {
                    DateTime date = DateTime.ParseExact(fromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    oCommonsearch.FromDate = date.ToString("dd/MM/yyyy");
                }
                oCommonsearch.ClientCode = "A0108";
                oCommonsearch.CompanyCode = "NSE_FNO";

                var responce = _portfolioService.GetClientPositionDetails(oCommonsearch);
                if (responce.IsSuccessStatusCode)
                {
                    var result = responce.Content.ReadAsStringAsync().Result;
                    JArray jarr = null;
                    try
                    {
                        jarr = JArray.Parse(result);
                        if (jarr.Count > 0)
                        {
                            JToken[] dataArray = jarr[0]["DATA"].ToArray();
                            for (int i = 0; i < dataArray.Count(); i++)
                            {
                                var oMultipleDateOfPosition = new MultipleDateOfPosition();
                                oMultipleDateOfPosition.CLIENT_ID = Convert.ToString(dataArray[i][0]);
                                oMultipleDateOfPosition.BUYRATE = Convert.ToString(dataArray[i][1]);
                                oMultipleDateOfPosition.BUYAMT = Convert.ToString(dataArray[i][2]);
                                oMultipleDateOfPosition.SALEQTY = Convert.ToString(dataArray[i][3]);
                                oMultipleDateOfPosition.SALERATE = Convert.ToString(dataArray[i][4]);
                                oMultipleDateOfPosition.SALEAMT = Convert.ToString(dataArray[i][5]);
                                oMultipleDateOfPosition.NETQTY = Convert.ToString(dataArray[i][6]);
                                oMultipleDateOfPosition.SHORTQTY = Convert.ToString(dataArray[i][7]);
                                oMultipleDateOfPosition.LONGQTY = Convert.ToString(dataArray[i][8]);
                                oMultipleDateOfPosition.NETRATE = Convert.ToString(dataArray[i][9]);
                                oMultipleDateOfPosition.NETAMT = Convert.ToString(dataArray[i][10]);
                                oMultipleDateOfPosition.SCRIP_SYMBOL = Convert.ToString(dataArray[i][11]);
                                oMultipleDateOfPosition.NET_PLAMT = Convert.ToString(dataArray[i][12]);
                                oMultipleDateOfPosition.FIFORATE = Convert.ToString(dataArray[i][13]);
                                oMultipleDateOfPosition.PL_AMT = Convert.ToString(dataArray[i][14]);
                                oMultipleDateOfPosition.CL_PRICE = Convert.ToString(dataArray[i][15]);
                                oMultipleDateOfPosition.CL_AMT = Convert.ToString(dataArray[i][16]);
                                oMultipleDateOfPosition.NOTIONAL = Convert.ToString(dataArray[i][17]);
                                oMultipleDateOfPosition.NOTIONAL1 = Convert.ToString(dataArray[i][18]);
                                oMultipleDateOfPosition.NOTIONAL_NET = Convert.ToString(dataArray[i][19]);
                                oMultipleDateOfPosition.NOTIONAL_NET1 = Convert.ToString(dataArray[i][20]);
                                oMultipleDateOfPosition.GROSSEXP = Convert.ToString(dataArray[i][21]);
                                oMultipleDateOfPosition.FULL_SCRIP_SYMBOL = Convert.ToString(dataArray[i][22]);
                                oMultipleDateOfPosition.BRANCH_CODE = Convert.ToString(dataArray[i][23]);
                                oMultipleDateOfPosition.BRANCH_NAME = Convert.ToString(dataArray[i][24]);
                                oMultipleDateOfPosition.BRANCH_CODE_MAIL = Convert.ToString(dataArray[i][25]);
                                oMultipleDateOfPosition.CLIENT_NAME = Convert.ToString(dataArray[i][26]);
                                oMultipleDateOfPosition.CLIENT_ID_MAIL = Convert.ToString(dataArray[i][27]);
                                oMultipleDateOfPosition.SR = Convert.ToString(dataArray[i][28]);
                                oMultipleDateOfPosition.FAMILY_GROUP = Convert.ToString(dataArray[i][29]);
                                oMultipleDateOfPosition.FAMILY_GROUP_MAIL = Convert.ToString(dataArray[i][30]);
                                oMultipleDateOfPosition.SCRIP_NAME = Convert.ToString(dataArray[i][31]);
                                oMultipleDateOfPosition.FROM_DATE = Convert.ToString(dataArray[i][32]);
                                oMultipleDateOfPosition.TO_DATE = Convert.ToString(dataArray[i][33]);
                                oMultipleDateOfPosition.FACTOR = Convert.ToString(dataArray[i][34]);
                                oMultipleDateOfPosition.MAIN_BRANCH_CODE = Convert.ToString(dataArray[i][35]);
                                oMultipleDateOfPosition.MAIN_BRANCH_NAME = Convert.ToString(dataArray[i][36]);
                                oMultipleDateOfPosition.MAIN_BRANCH_CODE_MAIL = Convert.ToString(dataArray[i][37]);
                                oMultipleDateOfPosition.INSTRUMENT_TYPE = Convert.ToString(dataArray[i][38]);
                                oMultipleDateOfPosition.CL_PRICE_ACT = Convert.ToString(dataArray[i][39]);
                                oMultipleDateOfPosition.EXPIRY_DATE = Convert.ToString(dataArray[i][40]);
                                oMultipleDateOfPosition.OPQTY = Convert.ToString(dataArray[i][41]);
                                oMultipleDateOfPosition.OPRATE = Convert.ToString(dataArray[i][42]);
                                oMultipleDateOfPosition.OPAMT = Convert.ToString(dataArray[i][43]);
                                oMultipleDateOfPosition.BUYQTY = Convert.ToString(dataArray[i][44]);
                                lstMultipleDateOfPosition.Add(oMultipleDateOfPosition);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lstMultipleDateOfPosition = new List<MultipleDateOfPosition>();
                    }
                }

                ////Getting the total count  to display on the grid pagination.    
                long TotalRecordsCount = lstMultipleDateOfPosition.Count();

                ////count of record after filter   
                long FilteredRecordCount = lstMultipleDateOfPosition.Count();

                lstMultipleDateOfPosition = lstMultipleDateOfPosition.Skip(skip).Take(pageSize).ToList();

                //// To avoid object reference error incase of  being null.    
                if (lstMultipleDateOfPosition == null)
                    lstMultipleDateOfPosition = new List<MultipleDateOfPosition>();

                return this.Json(new
                {
                    draw = Convert.ToInt32(draw),
                    recordsTotal = TotalRecordsCount,
                    recordsFiltered = FilteredRecordCount,
                    data = lstMultipleDateOfPosition
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get Position Details
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetLedgerDetails()
        {
            try
            {
                List<ClientLegerDetails> lstClientLegerDetails = new List<ClientLegerDetails>();
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;

                CommonSearch oCommonsearch = new CommonSearch();
                var fromDate = Request["FromDate"];
                var toDate = Request["ToDate"];
                var ClientCode = Request["ClientCode"];
                var Exchange = Request["Exchange"];
                var Marginaccount = Request["Marginaccount"];
                if (!string.IsNullOrEmpty(fromDate))
                {
                    DateTime date = DateTime.ParseExact(fromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    oCommonsearch.FromDate = date.ToString("dd/MM/yyyy");
                }
                if (!string.IsNullOrEmpty(toDate))
                {
                    DateTime date = DateTime.ParseExact(toDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    oCommonsearch.ToDate = date.ToString("dd/MM/yyyy");
                }
                if (!string.IsNullOrEmpty(ClientCode))
                {
                    oCommonsearch.ClientCode = ClientCode;
                }
                if (!string.IsNullOrEmpty(Exchange))
                {
                    oCommonsearch.CocdList = Exchange;
                }
                if (!string.IsNullOrEmpty(Marginaccount))
                {
                    oCommonsearch.ShowMargin = Marginaccount;
                }

                var responce = _portfolioService.GetClientLedgerDetails(oCommonsearch);
                if (responce.IsSuccessStatusCode)
                {
                    var result = responce.Content.ReadAsStringAsync().Result;
                    JArray jarr = null;
                    try
                    {
                        jarr = JArray.Parse(result);
                        if (jarr.Count > 0)
                        {
                            JToken[] dataArray = jarr[0]["DATA"].ToArray();
                            for (int i = 0; i < dataArray.Count(); i++)
                            {
                                var oClientLegerDetails = new ClientLegerDetails();
                                oClientLegerDetails.COCD = Convert.ToString(dataArray[i][0]);
                                oClientLegerDetails.DR_AMT = Convert.ToString(dataArray[i][1]);
                                oClientLegerDetails.CR_AMT = Convert.ToString(dataArray[i][2]);
                                oClientLegerDetails.VOUCHERDATE = Convert.ToString(dataArray[i][3]);
                                oClientLegerDetails.SETTLEMENT_NO = Convert.ToString(dataArray[i][4]);
                                oClientLegerDetails.CTRCODE = Convert.ToString(dataArray[i][5]);
                                oClientLegerDetails.CTRNAME = Convert.ToString(dataArray[i][6]);
                                oClientLegerDetails.TRANS_TYPE = Convert.ToString(dataArray[i][7]);
                                oClientLegerDetails.VOUCHERNO = Convert.ToString(dataArray[i][8]);
                                oClientLegerDetails.NARRATION = Convert.ToString(dataArray[i][9]);
                                oClientLegerDetails.BILLNO = Convert.ToString(dataArray[i][10]);
                                oClientLegerDetails.CONAME = Convert.ToString(dataArray[i][11]);
                                oClientLegerDetails.CHQNO = Convert.ToString(dataArray[i][12]);
                                oClientLegerDetails.EXPECTED_DATE = Convert.ToString(dataArray[i][13]);
                                oClientLegerDetails.TRADING_COCD = Convert.ToString(dataArray[i][14]);
                                oClientLegerDetails.PANNO = Convert.ToString(dataArray[i][15]);
                                oClientLegerDetails.EMAIL = Convert.ToString(dataArray[i][16]);
                                oClientLegerDetails.MANUALVNO = Convert.ToString(dataArray[i][17]);
                                oClientLegerDetails.BOOKTYPECODE = Convert.ToString(dataArray[i][18]);
                                if (!string.IsNullOrEmpty(Convert.ToString(dataArray[i][19])))
                                {
                                    oClientLegerDetails.BILL_DATE = Convert.ToDateTime(Convert.ToString(dataArray[i][19]));
                                }
                                oClientLegerDetails.MKT_TYPE = Convert.ToString(dataArray[i][20]);
                                oClientLegerDetails.GROUPCODE = Convert.ToString(dataArray[i][21]);
                                oClientLegerDetails.KINDOFACCOUNT = Convert.ToString(dataArray[i][22]);
                                oClientLegerDetails.BRSFLAG = Convert.ToString(dataArray[i][23]);
                                oClientLegerDetails.SETL_PAYINDATE = Convert.ToString(dataArray[i][24]);
                                oClientLegerDetails.LAST2SETL = Convert.ToString(dataArray[i][25]);
                                oClientLegerDetails.ACCOUNTCODE = Convert.ToString(dataArray[i][26]);
                                oClientLegerDetails.GATEWAYID = Convert.ToString(dataArray[i][27]);
                                oClientLegerDetails.PUNCH_TIME = Convert.ToString(dataArray[i][28]);
                                oClientLegerDetails.voctype = Convert.ToString(dataArray[i][29]);
                                oClientLegerDetails.CHQIMAGEPATH = Convert.ToString(dataArray[i][30]);
                                oClientLegerDetails.TRANS_TYPE1 = Convert.ToString(dataArray[i][31]);
                                oClientLegerDetails.ACCOUNTCODE = Convert.ToString(dataArray[i][32]);
                                oClientLegerDetails.ACCOUNTNAME = Convert.ToString(dataArray[i][33]);
                                oClientLegerDetails.TELNO = Convert.ToString(dataArray[i][34]);
                                oClientLegerDetails.FAX = Convert.ToString(dataArray[i][35]);
                                oClientLegerDetails.ADDR = Convert.ToString(dataArray[i][36]);
                                oClientLegerDetails.OPENINGBALANCE = Convert.ToString(dataArray[i][37]);
                                lstClientLegerDetails.Add(oClientLegerDetails);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lstClientLegerDetails = new List<ClientLegerDetails>();
                    }
                }

                ////Getting the total count  to display on the grid pagination.    
                long TotalRecordsCount = lstClientLegerDetails.Count();

                ////count of record after filter   
                long FilteredRecordCount = lstClientLegerDetails.Count();

                lstClientLegerDetails = lstClientLegerDetails.Skip(skip).Take(pageSize).ToList();

                //// To avoid object reference error incase of  being null.    
                if (lstClientLegerDetails == null)
                    lstClientLegerDetails = new List<ClientLegerDetails>();
                //// To avoid object reference error incase of  being null.    
                //if (lstMultipleDateOfPosition == null)



                return this.Json(new
                {
                    draw = Convert.ToInt32(draw),
                    recordsTotal = TotalRecordsCount,
                    recordsFiltered = FilteredRecordCount,
                    data = lstClientLegerDetails
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Get Position Details
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetHoldingDetails()
        {
            try
            {
                List<HoldingDetails> lstHoldingDetails = new List<HoldingDetails>();
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

                CommonSearch oCommonsearch = new CommonSearch();
                var toDate = Request["ToDate"];
                if (!string.IsNullOrEmpty(toDate))
                {
                    DateTime date = DateTime.ParseExact(toDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    oCommonsearch.ToDate = date.ToString("dd/MM/yyyy");
                }
                //oCommonsearch.ToDate = "15/04/2020";
                oCommonsearch.ClientCode = "A0108";

                var responce = _portfolioService.GetHoldingDetails(oCommonsearch);
                if (responce.IsSuccessStatusCode)
                {
                    var result = responce.Content.ReadAsStringAsync().Result;
                    JArray jarr = null;
                    try
                    {
                        jarr = JArray.Parse(result);
                        if (jarr.Count > 0)
                        {
                            JToken[] dataArray = jarr[0]["DATA"].ToArray();
                            for (int i = 0; i < dataArray.Count(); i++)
                            {
                                var oHoldingDetails = new HoldingDetails();
                                oHoldingDetails.CLIENTCODE = Convert.ToString(dataArray[i][0]);
                                oHoldingDetails.NET1 = Convert.ToString(dataArray[i][1]);
                                oHoldingDetails.AMOUNT = Convert.ToString(dataArray[i][2]);
                                oHoldingDetails.AMOUNT1 = Convert.ToString(dataArray[i][3]);
                                oHoldingDetails.PLEDGE_QTY = Convert.ToString(dataArray[i][4]);
                                oHoldingDetails.INSHORT = Convert.ToString(dataArray[i][5]);
                                oHoldingDetails.OUTSHORT = Convert.ToString(dataArray[i][6]);
                                oHoldingDetails.TOT_AMT = Convert.ToString(dataArray[i][7]);
                                oHoldingDetails.PERCENT_HOLD = Convert.ToString(dataArray[i][8]);
                                oHoldingDetails.ISIN = Convert.ToString(dataArray[i][9]);
                                oHoldingDetails.BRANCHCODE = Convert.ToString(dataArray[i][10]);
                                oHoldingDetails.FAMILYCODE = Convert.ToString(dataArray[i][11]);
                                oHoldingDetails.CLIENTNAME = Convert.ToString(dataArray[i][12]);
                                oHoldingDetails.BRANCHNAME = Convert.ToString(dataArray[i][13]);
                                oHoldingDetails.FAMILYNAME = Convert.ToString(dataArray[i][14]);
                                oHoldingDetails.BRANCHCODE_MAIL = Convert.ToString(dataArray[i][15]);
                                oHoldingDetails.CLIENTCODE_MAIL = Convert.ToString(dataArray[i][16]);
                                oHoldingDetails.LEDGERBAL = Convert.ToString(dataArray[i][17]);
                                oHoldingDetails.HOLDDATETIME = Convert.ToString(dataArray[i][18]);
                                oHoldingDetails.DP_ID = Convert.ToString(dataArray[i][19]);
                                oHoldingDetails.BRBENQTY = Convert.ToString(dataArray[i][20]);
                                oHoldingDetails.BO_ID = Convert.ToString(dataArray[i][21]);
                                oHoldingDetails.DEF_ACC = Convert.ToString(dataArray[i][22]);
                                oHoldingDetails.POA = Convert.ToString(dataArray[i][23]);
                                oHoldingDetails.PRICEDATE = Convert.ToString(dataArray[i][24]);
                                oHoldingDetails.MOBILE_NO = Convert.ToString(dataArray[i][25]);
                                oHoldingDetails.SCRIP_NAME = Convert.ToString(dataArray[i][26]);
                                oHoldingDetails.SCRIPTYPE = Convert.ToString(dataArray[i][27]);
                                oHoldingDetails.SCRIP_CODE = Convert.ToString(dataArray[i][28]);
                                oHoldingDetails.COLQTY = Convert.ToString(dataArray[i][29]);
                                oHoldingDetails.SCRIP_VALUE = Convert.ToString(dataArray[i][30]);
                                oHoldingDetails.SCRIP_SYMBOL = Convert.ToString(dataArray[i][31]);
                                oHoldingDetails.FreeQTY = Convert.ToString(dataArray[i][32]);
                                oHoldingDetails.HOLDINGDATETIME111 = Convert.ToString(dataArray[i][33]);
                                oHoldingDetails.BENQTY = Convert.ToString(dataArray[i][34]);
                                oHoldingDetails.SOHQTY = Convert.ToString(dataArray[i][35]);
                                oHoldingDetails.PLedgeQTY = Convert.ToString(dataArray[i][36]);
                                oHoldingDetails.LockinQty = Convert.ToString(dataArray[i][37]);
                                oHoldingDetails.NET = Convert.ToString(dataArray[i][38]);
                                lstHoldingDetails.Add(oHoldingDetails);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lstHoldingDetails = new List<HoldingDetails>();
                    }
                }

                ////Getting the total count  to display on the grid pagination.    
                long TotalRecordsCount = lstHoldingDetails.Count();

                ////count of record after filter   
                long FilteredRecordCount = lstHoldingDetails.Count();

                lstHoldingDetails = lstHoldingDetails.Skip(skip).Take(pageSize).ToList();

                //// To avoid object reference error incase of  being null.    
                if (lstHoldingDetails == null)
                    lstHoldingDetails = new List<HoldingDetails>();

                return this.Json(new
                {
                    draw = Convert.ToInt32(draw),
                    recordsTotal = TotalRecordsCount,
                    recordsFiltered = FilteredRecordCount,
                    data = lstHoldingDetails
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}