using Semec.Areas.InvoiceManage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semec.Controllers
{
    public class LoginController : Controller
    {
        public MyContext db = new MyContext();
        public ActionResult Challenge()
        {         
            Response.Cookies["CaptchaCode"].Value = TextLib.GetCaptcha(); 
            TextLib.DrawCaptch(Request.Cookies["CaptchaCode"].Value);           
            return View();
        }
        [HttpPost]
        public ActionResult Challenge(FormCollection form)
        {
            string mobile = form["Mobile"];
            string password = form["Password"];
            string captchacode = form["CaptchaCode"];           
            string capCode = Request.Cookies["CaptchaCode"].Value.ToString();
            ViewData["LoginError"] = null;

            if (capCode == captchacode)
            {
                var user = db.UserModels.Where(x => x.Mobile == mobile && x.Password == password).FirstOrDefault();
                if (user != null)
                {
                    Response.Cookies["UserID"].Value = user.UserID.ToString(); // Session of user
                    Response.Cookies["DisplayName"].Value  = user.DisplayName;
                    Response.Cookies["cLoginStatus"].Value = "Yes";
                    return RedirectToAction("Index", "Dashboard");
                    //return RedirectToAction("Index", "Dashboard", new { area = "" });                   
                }
                else
                {
                    ViewData["LoginError"] = "Invalid user name or password !";
                    return View();
                }
            }
            else
            {
                ViewData["LoginError"] = "Invalid Captcha Code !";
                return View();
            }
        }       
        public ActionResult Recovery()
        {
            Response.Cookies["CaptchaCode"].Value = TextLib.GetCaptcha();
            TextLib.DrawCaptch(Request.Cookies["CaptchaCode"].Value.ToString());
            return View();
        }
        [HttpPost]
        public ActionResult Recovery( FormCollection form)       {

          string mobile=  form["Mobile"].ToString();
          string otpcode = form["OtpCode"].ToString();
          string captchacode = form["CaptchaCode"].ToString();

            // 
            string OTPCode = Session["OTPCode"].ToString();
            string CaptchaCode = Session["CaptchaCode"].ToString();

            Session.Remove("OTPCode");
            Session.Remove("CaptchaCode");

            if (OTPCode == otpcode)
            {
                if (CaptchaCode == captchacode)
                {
                    Session["ClientID"] = DataLib.GetCellItems("Select UserID From UserModels Where UserName='" + mobile + "'");
                    RedirectToAction("ResetPassword", "Login");                    
                }
                else
                {
                   // TextLib.PopupMessage("Invalid Captcha Code");
                }
            }
            else
            {
               // TextLib.PopupMessage("Invalid OTP Code");
            }
            return View();
        }        
        [HttpPost]
        public ActionResult VarifyandSendOTPCode(string MobileNo, string Message)
        {
            // check mobile
            string result;
            string mob = DataLib.GetCellItems("Select Mobile from UserModels Where Mobile='" + MobileNo + "'");
            if (mob == MobileNo)
            {
                Session["OTPCode"] = TextLib.GeneratOTP();
                TextLib.SendSMS(MobileNo, Message + Session["OTPCode"].ToString(), "English");
                result = "OTP Code send to Mobile No :" + MobileNo;
            }
            else
            {
                result = "The Mobile No: " + MobileNo + " is not registered with us";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult RefereceCaptcha()
        {
            Response.Cookies["CaptchaCode"].Value = TextLib.GetCaptcha();
            TextLib.DrawCaptch(Request.Cookies["CaptchaCode"].Value);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Reset()
        {
           return View();
        }        
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }
    }
}