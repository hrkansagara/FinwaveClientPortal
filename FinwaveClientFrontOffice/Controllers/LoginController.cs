using FinwaveClientFrontOffice.Models;
using FinwaveClientFrontOffice.Common;
using System.Web.Mvc;
using FinwaveClientFrontOffice.Services;
using Newtonsoft.Json.Linq;
using System.Linq;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Text;

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

        /// <summary>
        /// User verify and send otp
        /// </summary>
        /// <param name="oUser"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UserDetailByClientCode(User oUser)
        {
            SessionHelper.CurrentOtpUser = null;
            List<AccountModel> lstAccount = new List<AccountModel>();

            SaveResponse saveResponse = new SaveResponse();
            var login = new Login()
            {
                UserName = oUser.ClientCode
            };
            var oLogin = objLoginService.GetUserByUserName(login);
            if (oLogin != null)
            {
                return Json(new SaveResponse() { Success = false, ResponseString = "User already exist." });
            }
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
                    var sms = new SendSMS();
                    sms.mobile = oAccountModel.MOBILE_NO;
                    sms.message = "Below is the OTP for finwave workspace regestration. \n" + oAccountModel.MobileOtp;
                    sms.apicall();
                    //end
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
                SessionHelper.CurrentOtpUser = null;
                TempData["Notification"] = JsonConvert.SerializeObject(userResponse);
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                oUser.ClientCode = SessionHelper.CurrentOtpUser.CLIENT_ID;
                TempData["Notification"] = JsonConvert.SerializeObject(userResponse);
                return PartialView("~/Views/Login/UserRegistar.cshtml", oUser);
            }
        }

        /// <summary>
        /// Save User
        /// </summary>
        /// <param name="oUser"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Resend OTP
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ResendOtp()
        {
            SaveResponse oSaveResponse = new SaveResponse();
            //Add Logic - resend otp
            Random generator = new Random();
            SessionHelper.CurrentOtpUser.MobileOtp = generator.Next(0, 1000000).ToString("D6");
            //Send otp on mobile
            var sms = new SendSMS();
            sms.mobile =  SessionHelper.CurrentOtpUser.MOBILE_NO;
            sms.message = "Below is the OTP for finwave workspace regestration. \n" + SessionHelper.CurrentOtpUser.MobileOtp;
            sms.apicall();
            //end
            oSaveResponse.Success = true;
            oSaveResponse.ResponseString = "Otp sent successfully.";
            return Json(oSaveResponse);
        }

        /// <summary>
        /// Reset Password
        /// </summary>
        /// <param name="oUser"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult ResetPassward(User oUser)
        {
            SaveResponse oSaveResponse = new SaveResponse();
            Login oLogin = new Login();
            oLogin.UserName = oUser.ClientCode;
            oLogin = objLoginService.UserDetailByUserName(oLogin);
            var isSuccess = false;
            if (oLogin != null)
            {
                Random generator = new Random();
                oLogin.Password = CreatePassword(3, "abcdefghijklmnopqrstuvwxyz") + CreatePassword(3, "ABCDEFGHIJKLMNOPQRSTUVWXYZ") + generator.Next(0, 1000000).ToString("D3");
                if (oUser.ReceiveType == "Email")
                {
                    //Add Logic for mail
                    string s = string.Empty;
                    StringBuilder str = new StringBuilder();
                    StreamReader sr = new StreamReader(Server.MapPath("~/EmailTemplate/ResetPasswordTemplate.html"));
                    s = sr.ReadToEnd();
                    str = new StringBuilder(s);
                    str.Replace("##UserName##", oLogin.UserFullName);
                    str.Replace("##Password##", oLogin.Password);
                    sr.Close();
                    isSuccess = SendEmail.SentEmail(oLogin.EmailId, "", "Reset Password", str.ToString(), "");
                }
                else
                {
                    //Send otp on mobile
                    var sms = new SendSMS();
                    sms.mobile =  SessionHelper.CurrentOtpUser.MOBILE_NO;
                    sms.message = "Below is the Password for finwave workspace. \n" + oLogin.Password;
                    sms.apicall();
                    //end
                }

                if (isSuccess)
                {
                    oLogin.Password = PasswordSecurity.EncryptPassword(oLogin.Password);
                    oSaveResponse = objLoginService.UpdatePasswardByClientname(oLogin);
                }
                else
                {
                    oSaveResponse.Success = false;
                    oSaveResponse.ResponseString = "Something went wrong please try again after sometimes.";
                }
            }
            else
            {
                oSaveResponse.Success = false;
                oSaveResponse.ResponseString = "UserName not exist.";
            }
            return Json(oSaveResponse);
        }

        /// <summary>
        /// generate password
        /// </summary>
        /// <param name="length"></param>
        /// <param name="fromCharacters"></param>
        /// <returns></returns>
        public string CreatePassword(int length, string fromCharacters)
        {
            string valid = fromCharacters;// "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }
    }
}