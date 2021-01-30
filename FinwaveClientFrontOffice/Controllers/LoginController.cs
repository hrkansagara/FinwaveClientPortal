using FinwaveClientFrontOffice.Models;
using FinwaveClientFrontOffice.Common;
using System.Web.Mvc;
using FinwaveClientFrontOffice.Services;
using Newtonsoft.Json.Linq;
using System.Linq;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace FinwaveClientFrontOffice.Controllers
{
    public class LoginController : Controller
    {
        private LoginService objLoginService;
        public LoginController(LoginService _objLoginService)
        {
            objLoginService = _objLoginService;
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
        public ActionResult Index(Login oLogin)
        {
            oLogin.Password = PasswordSecurity.EncryptPassword(oLogin.Password);
            var loginResp = CheckUser(oLogin);

            if (loginResp.oLogin != null)
            {
                SessionHelper.CurrentUser = loginResp.oLogin;
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                TempData["Notification"] = JsonConvert.SerializeObject(loginResp);
                return View();
            }
        }

        public LoginResponse CheckUser(Login oLogin)
        {
            LoginResponse loginResp = new LoginResponse();
            loginResp.oLogin = objLoginService.LoginUser(oLogin);

            if (loginResp.oLogin == null)
            {
                return new LoginResponse() { Success = false, ResponseString = "Invalid UserName or Password." };
            }
            return loginResp;
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

        /// <summary>
        /// Forgot Passward
        /// </summary>
        /// <param name="ouser"></param>
        /// <returns></returns>
        public ActionResult ForgotPassward()
        {
            return View("~/Views/Login/ForgetPassword.cshtml");
        }

        /// <summary>
        /// UserRegistar
        /// </summary>
        /// <param name="ouser"></param>
        /// <returns></returns>
        public ActionResult UserRegistar()
        {
            return PartialView("~/Views/Login/UserRegistar.cshtml");
        }




        [HttpPost]
        public JsonResult UserDetailByClientCode(User oUser)
        {
            SessionHelper.CurrentOtpUser = null;
            List<AccountModel> lstAccount = new List<AccountModel>();
            SaveResponse saveResponse = new SaveResponse();
            var responce = objLoginService.GetClientBankAllDetailByClientCode(oUser.ClientCode);
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
                        var acct = new AccountModel();
                        acct.COMPANY_CODE = Convert.ToString(dataArray[i][0]);
                        acct.MICR_CODE = Convert.ToString(dataArray[i][1]);
                        acct.BANK_ACNO = Convert.ToString(dataArray[i][2]);
                        acct.BANK_NAME = Convert.ToString(dataArray[i][3]);
                        acct.CLIENT_DP_CODE = Convert.ToString(dataArray[i][4]);
                        acct.DP_ID = Convert.ToString(dataArray[i][5]);
                        acct.DP_NAME = Convert.ToString(dataArray[i][6]);
                        acct.REMESHIRE_GROUP = Convert.ToString(dataArray[i][7]);
                        acct.REMESHIRE_NAME = Convert.ToString(dataArray[i][8]);
                        acct.CLIENT_ID = Convert.ToString(dataArray[i][9]);
                        acct.CLIENT_NAME = Convert.ToString(dataArray[i][10]);
                        acct.CL_RESI_ADD1 = Convert.ToString(dataArray[i][11]);
                        acct.CL_RESI_ADD2 = Convert.ToString(dataArray[i][12]);
                        acct.CL_RESI_ADD3 = Convert.ToString(dataArray[i][13]);
                        acct.MOBILE_NO = Convert.ToString(dataArray[i][14]);
                        acct.CLIENT_ID_MAIL = Convert.ToString(dataArray[i][15]);
                        acct.PAN_NO = Convert.ToString(dataArray[i][16]);
                        lstAccount.Add(acct);
                    }
                }
            }
            catch
            {
                lstAccount = new List<AccountModel>();
            }

            if (lstAccount != null && lstAccount.Any())
            {
                AccountModel oAccountModel = new AccountModel();
                oAccountModel = lstAccount.Where(X => X.COMPANY_CODE == "BSE_CASH").ToList().FirstOrDefault();
                if (oAccountModel != null)
                {
                    ///6 digit otp generator for mobile.
                    Random generator = new Random();
                    oAccountModel.MobileOtp = generator.Next(0, 1000000).ToString("D6");
                    SessionHelper.CurrentOtpUser = oAccountModel;
                    //Send otp on mobile 
                    //var sms = new SendSMS();
                    //sms.mobile = "7984452408";// oAccountModel.MOBILE_NO;
                    //sms.message = oAccountModel.MobileOtp;
                    //sms.apicall();
                    // end
                    saveResponse.Success = true;
                    saveResponse.Data = oAccountModel.MobileOtp;
                    saveResponse.ResponseString = "Otp sent on your registered mobile number.";
                }
                else
                {
                    saveResponse.Success = false;
                    saveResponse.ResponseString = "This Clientcode not exist.Please enter again.";
                }
            }
            else
            {
                saveResponse.Success = false;
                saveResponse.ResponseString = "This Clientcode not exist.Please enter again.";
            }
            return Json(saveResponse);
        }


        /// <summary>
        /// Index
        /// </summary>
        /// <param name="ouser"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveDetails(User oUser)
        {
            var userResponse = SaveUserDetails(oUser);
            if (userResponse.Success)
            {
                AccountModel accountModel = SessionHelper.CurrentOtpUser;
                Login oLogin = new Login();
                oLogin.UserFullName = accountModel.CLIENT_NAME;
                oLogin.UserName = accountModel.CLIENT_ID;
                oLogin.EmailId = accountModel.EmailId;
                oLogin.Mobile = accountModel.Mobile;
                SessionHelper.CurrentUser = oLogin;
                TempData["Notification"] = JsonConvert.SerializeObject(userResponse);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                TempData["Notification"] = JsonConvert.SerializeObject(userResponse);
                return View();
            }
        }

        public UserResponse SaveUserDetails(User oUser)
        {
            UserResponse userResponse = new UserResponse();
            if (oUser.Password.ToLower() == oUser.ConformPassword.ToLower())
            {
                if (!string.IsNullOrEmpty(oUser.MobileOtp))
                {
                    if (oUser.MobileOtp == SessionHelper.CurrentOtpUser.MobileOtp)
                    {
                        oUser.Password = PasswordSecurity.EncryptPassword(oUser.Password);
                        SessionHelper.CurrentOtpUser.Password = oUser.Password;
                        SaveResponse oSaveResponse = new SaveResponse();
                        oSaveResponse = objLoginService.SaveUserDetails(SessionHelper.CurrentOtpUser);
                        userResponse.ResponseString = oSaveResponse.ResponseString;
                        userResponse.Success = oSaveResponse.Success;
                    }
                    else
                    {
                        userResponse.Success = false;
                        userResponse.ResponseString = "Otp not matched.";
                    }
                }
                else
                {
                    userResponse.Success = false;
                    userResponse.ResponseString = "Please enter Otp number.";
                }
            }
            else
            {
                userResponse.Success = false;
                userResponse.ResponseString = "passward not matched.";
            }
            return userResponse;
        }

        [HttpPost]
        public JsonResult ResendOtp()
        {
            SaveResponse oSaveResponse = new SaveResponse();
            //Add Logic - resend otp
            oSaveResponse.Success = true;
            oSaveResponse.ResponseString = "Otp send successfully.";
            return Json(oSaveResponse);
        }

        [HttpPost]
        public JsonResult ResetPassward(User oUser)
        {
            SaveResponse oSaveResponse = new SaveResponse();
            Login oLogin = new Login();
            oLogin.UserName = oUser.ClientCode;
            oLogin = objLoginService.UserDetailByUserName(oLogin);
            if (oLogin != null)
            {
                if (oUser.ReceiveType == "Email")
                {
                    //Add Logic for mail
                }
                else
                {
                    //Add Logic -mobile for sent passward
                }
                Random generator = new Random();
                oLogin.Password = generator.Next(0, 1000000).ToString("D6");
                oLogin.Password = PasswordSecurity.EncryptPassword(oLogin.Password);
                oSaveResponse = objLoginService.UpdatePasswardByClientname(oLogin);
            }
            else
            {
                oSaveResponse.Success = false;
                oSaveResponse.ResponseString = "UserName not exist.";
            }
            return Json(oSaveResponse);
        }
    }
}