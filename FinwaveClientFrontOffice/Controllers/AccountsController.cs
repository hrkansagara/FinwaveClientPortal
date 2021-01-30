using FinwaveClientFrontOffice.Authorization;
using FinwaveClientFrontOffice.Models;
using FinwaveClientFrontOffice.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FinwaveClientFrontOffice.Controllers
{
    [UserAuthorization]
    public class AccountsController : Controller
    {

        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        // GET: Dashboard
        // GET: Accounts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetPartialAccountDetails()
        {
            List<AccountModel> lstAccount = new List<AccountModel>();
            var account = new Account();
            string ClientCode = "I0225";
            var responce = _accountService.GetClientDetailByClientCode(ClientCode);
            if(responce.IsSuccessStatusCode)
            {
               var result = responce.Content.ReadAsStringAsync().Result;
                JArray jarr = JArray.Parse(result);
                if (jarr.Count > 0)
                {
                    JToken[] dataArray = jarr[0]["DATA"].ToArray();
                    for (int i = 0; i < dataArray.Count(); i++)
                    {
                        var acct = new AccountModel();
                        acct.COMPANY_CODE = Convert.ToString(dataArray[i][0]);
                        acct.CL_RESI_ADD1 = Convert.ToString(dataArray[i][9]);
                        acct.CL_RESI_ADD2 = Convert.ToString(dataArray[i][10]);
                        acct.CL_RESI_ADD3 = Convert.ToString(dataArray[i][11]);
                        acct.SEX = Convert.ToString(dataArray[i][34]);
                        acct.CITY = Convert.ToString(dataArray[i][112]);
                        acct.PIN_CODE = Convert.ToString(dataArray[i][123]);
                        acct.CLIENT_ID_MAIL = Convert.ToString(dataArray[i][178]);
                        acct.PAN_NO = Convert.ToString(dataArray[i][189]);
                        acct.MOBILE_NO = Convert.ToString(dataArray[i][200]);
                        acct.CLIENT_ID = Convert.ToString(dataArray[i][573]);
                        acct.CLIENT_NAME = Convert.ToString(dataArray[i][584]);
                        acct.BANK_ACNO = Convert.ToString(dataArray[i][590]);
                        acct.CLIENT_BANK_NAME = Convert.ToString(dataArray[i][591]);
                        acct.MICR_CODE = Convert.ToString(dataArray[i][596]);
                        acct.CLIENT_DP_CODE = Convert.ToString(dataArray[i][598]);
                        acct.DP_ID = Convert.ToString(dataArray[i][600]);
                        acct.DP_NAME = Convert.ToString(dataArray[i][601]);
                        acct.BIRTH_DATE = Convert.ToString(dataArray[i][245]);
                        acct.NOMINEE_NAME = Convert.ToString(dataArray[i][246]);
                        acct.DEPOSITORY = Convert.ToString(dataArray[i][603]);
                        lstAccount.Add(acct);
                    }

                    var nseAccount = lstAccount.Where(x => x.COMPANY_CODE.ToLower().Trim() == "nse_cash").FirstOrDefault();

                    account.COMPANY_CODE = nseAccount.COMPANY_CODE;
                    account.CL_RESI_ADD1 = nseAccount.CL_RESI_ADD1;
                    account.CL_RESI_ADD2 = nseAccount.CL_RESI_ADD2;
                    account.CL_RESI_ADD3 = nseAccount.CL_RESI_ADD3;
                    account.ADDRESS = (nseAccount.CL_RESI_ADD1.TrimEnd(',').Trim() + ", " + nseAccount.CL_RESI_ADD2.TrimEnd(',').Trim() + ", " + nseAccount.CL_RESI_ADD3.TrimEnd(',').Trim()).Replace(",,", ",");
                    account.SEX = nseAccount.SEX;
                    account.CITY = nseAccount.CITY;
                    account.PIN_CODE = nseAccount.PIN_CODE;
                    account.CLIENT_ID_MAIL = nseAccount.CLIENT_ID_MAIL;
                    account.PAN_NO = nseAccount.PAN_NO;
                    account.MOBILE_NO = nseAccount.MOBILE_NO;
                    account.CLIENT_ID = nseAccount.CLIENT_ID;
                    account.CLIENT_NAME = nseAccount.CLIENT_NAME;
                    account.BANK_ACNO = nseAccount.BANK_ACNO;
                    account.CLIENT_BANK_NAME = nseAccount.CLIENT_BANK_NAME;
                    account.MICR_CODE = nseAccount.MICR_CODE;
                    account.CLIENT_DP_CODE = nseAccount.CLIENT_DP_CODE;
                    account.DP_ID = nseAccount.DP_ID;
                    account.DP_NAME = nseAccount.DP_NAME;
                    account.BIRTH_DATE = nseAccount.BIRTH_DATE;
                    account.NOMINEE_NAME = nseAccount.NOMINEE_NAME;
                    account.DEPOSITORY = nseAccount.DEPOSITORY;

                    var bankAccountDetailsRepsponce = _accountService.GetClientBankDetailByClientCode(ClientCode);
                    if (bankAccountDetailsRepsponce.IsSuccessStatusCode)
                    {
                        List<BankAccountDetails> lstBankDetails = new List<BankAccountDetails>();
                        var bankAccountDetails = bankAccountDetailsRepsponce.Content.ReadAsStringAsync().Result;
                        JArray jarrbankAccountDetails = JArray.Parse(bankAccountDetails);
                        if (jarr.Count > 0)
                        {
                            JToken[] datajarrbankAccountDetails = jarrbankAccountDetails[0]["DATA"].ToArray();
                            for (int i = 0; i < datajarrbankAccountDetails.Count(); i++)
                            {
                                var objBankAccountDetails = new BankAccountDetails();
                                objBankAccountDetails.ACCOUNT_CODE = Convert.ToString(datajarrbankAccountDetails[i][0]);
                                objBankAccountDetails.BANK_FAX_NO = Convert.ToString(datajarrbankAccountDetails[i][1]);
                                objBankAccountDetails.EFT_FLAG = Convert.ToString(datajarrbankAccountDetails[i][2]);
                                objBankAccountDetails.PROOF_REC = Convert.ToString(datajarrbankAccountDetails[i][3]);
                                objBankAccountDetails.IFSC_CODE = Convert.ToString(datajarrbankAccountDetails[i][4]);
                                objBankAccountDetails.CITY = Convert.ToString(datajarrbankAccountDetails[i][5]);
                                objBankAccountDetails.STATE = Convert.ToString(datajarrbankAccountDetails[i][6]);
                                objBankAccountDetails.COUNTRY = Convert.ToString(datajarrbankAccountDetails[i][7]);
                                objBankAccountDetails.CHQPRINTNAME = Convert.ToString(datajarrbankAccountDetails[i][8]);
                                objBankAccountDetails.NACHFLAG = Convert.ToString(datajarrbankAccountDetails[i][9]);
                                objBankAccountDetails.NACHUMRNO = Convert.ToString(datajarrbankAccountDetails[i][0]);
                                objBankAccountDetails.CLIENT_NAME = Convert.ToString(datajarrbankAccountDetails[i][11]);
                                objBankAccountDetails.BANK_ACNO = Convert.ToString(datajarrbankAccountDetails[i][12]);
                                objBankAccountDetails.BANKACTIVE = Convert.ToString(datajarrbankAccountDetails[i][13]);
                                objBankAccountDetails.FT_ATOM_CODE = Convert.ToString(datajarrbankAccountDetails[i][14]);
                                objBankAccountDetails.BANKMODIFYDATE = Convert.ToString(datajarrbankAccountDetails[i][15]);
                                objBankAccountDetails.BANK_NAME = Convert.ToString(datajarrbankAccountDetails[i][16]);
                                objBankAccountDetails.BANK_ADDRESS = Convert.ToString(datajarrbankAccountDetails[i][17]);
                                objBankAccountDetails.DEFAULT_AC = Convert.ToString(datajarrbankAccountDetails[i][18]);
                                objBankAccountDetails.MICR_CODE = Convert.ToString(datajarrbankAccountDetails[i][19]);
                                objBankAccountDetails.MOBILE_NO = Convert.ToString(datajarrbankAccountDetails[i][20]);
                                objBankAccountDetails.IFSC_CODE_ACT = Convert.ToString(datajarrbankAccountDetails[i][21]);
                                objBankAccountDetails.BANK_ACCTYPE = Convert.ToString(datajarrbankAccountDetails[i][22]);
                                objBankAccountDetails.ACC_OPEN_DATE = Convert.ToString(datajarrbankAccountDetails[i][23]);
                                objBankAccountDetails.BANK_TEL_NO = Convert.ToString(datajarrbankAccountDetails[i][24]);
                                lstBankDetails.Add(objBankAccountDetails);
                            }
                            account.objBankAccountDetails = lstBankDetails.Where(x => x.DEFAULT_AC.ToLower().Trim() == "yes").FirstOrDefault();
                            account.lstBankAccountDetails = lstBankDetails.Where(x => x.DEFAULT_AC.ToLower().Trim() != "yes").ToList();
                        }
                    }
                        
                }
            }
            return PartialView("~/Views/Accounts/_PartialAccountDetail.cshtml", account);
        }
    }
}