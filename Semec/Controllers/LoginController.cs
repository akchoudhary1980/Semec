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
            Session["CaptchaCode"] = TextLib.GetCaptcha();
            TextLib.DrawCaptch(Session["CaptchaCode"].ToString());
            Session["LoginError"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult Challenge(FormCollection form)
        {
            string mobile = form["Mobile"];
            string password = form["Password"];
            string captchacode = form["CaptchaCode"];
            string capCode = Session["CaptchaCode"].ToString();
           

            if (capCode == captchacode)
            {
                var user = db.UserModels.Where(x => x.Mobile == mobile && x.Password == password).FirstOrDefault();
                if (user != null)
                {
                    Session["UserID"] = user.UserID; // Session of user
                    Session["CustomerName"] = user.DisplayName;
                    Session["cLoginStatus"] = "Yes";
                    return RedirectToAction("Index", "Dashboard", new { area = "DealersManage" });                   
                }
                else
                {
                    Session["LoginError"] = "Invalid user name or password !";
                    return View();
                }
            }
            else
            {
                Session["LoginError"] = "Invalid Captcha Code !";
                return View();
            }
        }

        public ActionResult LoginTest()
        {
            Session["CaptchaCode"] = TextLib.GetCaptcha();
            TextLib.DrawCaptch(Session["CaptchaCode"].ToString());
            return View();
        }
        public ActionResult PasswordRecovery()
        {
            Session["CaptchaCode"] = TextLib.GetCaptcha();
            TextLib.DrawCaptch(Session["CaptchaCode"].ToString());
            return View();
        }
        [HttpPost]
        public ActionResult PasswordRecovery( FormCollection form)       {

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
        public ActionResult ResetPassword()
        {
           return View();
        }
        [HttpPost]
        public ActionResult RefereceCaptcha()
        {
            Session["CaptchaCode"] = TextLib.GetCaptcha();
            TextLib.DrawCaptch(Session["CaptchaCode"].ToString());
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            // if database setting for login with password             
            return RedirectToAction("LoginPassword", "Login");             
        }
        public ActionResult LoginOTP()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginOTP(FormCollection form)
        {
            string mobile = form["Mobile"];           
            string captchacode = form["CaptchaCode"];
            string capCode = Session["CaptchaCode"].ToString();
            string otp = form["OtpCode"];
            string otpCode = Session["OtpCode"].ToString();

            if (capCode == captchacode)
            {
                if (otp == otpCode)
                {  
                    // 
                    var user = db.UserModels.Where(x => x.UserName == mobile && x.AccountStatus.Equals("Active")).FirstOrDefault();
                    try
                    {
                        Session["DisplayName"] = user.DisplayName;
                        Session["LoginStatus"] = "Yes";
                        Session["CompanyID"] = user.UserID;
                        // check the condition 
                        if (user.UserType == "Admin")
                        {
                            Session["UserID"] = user.UserID;
                            return RedirectToAction("Client", "Dashboard");
                        }
                        else
                        {
                            Session["UserID"] = user.UserID;
                            if (user.Password == "Temp")
                            {
                                return RedirectToAction("Recovery", "Login");
                            }
                            else
                            {
                                return RedirectToAction("Client", "Dashboard");
                            }
                        }
                    }
                    catch
                    {
                        ModelState.AddModelError("Mobile", "Invalid user name or password");
                        return View();
                    }
                    // 
                }
                else
                {
                    // Call Java Script  
                    string message = "Invalid Otp Code !";
                    ViewBag.SweetMessage = string.Format("ShowMessage('{0}');", message);
                    return View();
                }                
            }
            else
            {
                // Call Java Script  
                string message = "Invalid Captcha Code !";
                ViewBag.SweetMessage = string.Format("ShowMessage('{0}');", message);
                return View();
            }
        }
        // Login From Delivery
        [HttpPost]
        public ActionResult LoginDelivery(FormCollection form)
        {
            string mobile = form["Mobile"];
            string password = form["Password"];
            string captchacode = form["CaptchaCode"];
            string capCode = Session["CaptchaCode"].ToString();

            if (capCode == captchacode)
            {
                var user = db.CustomerModels.Where(x => x.Mobile == mobile && x.Address == password).FirstOrDefault();
                try
                {
                    Session["CustomerID"] = user.CustomerID;
                    Session["CustomerName"] = user.CustomerName;
                    Session["cLoginStatus"] = "Yes";
                    // check the condition
                    return RedirectToAction("DeliveryDetails", "Home");                   
                }
                catch
                {
                    // Call Java Script  
                    //string message = "Invalid user name or password !";
                    //ViewBag.SweetMessage = string.Format("ShowMessage('{0}');", message);
                    //return View();

                    Session["LoginError"] = "Invalid user name or password !";
                    return RedirectToAction("DeliveryDetails", "Home");
                }
            }
            else
            {
             
                Session["LoginError"] = "Invalid Captcha Code !";              
                return RedirectToAction("DeliveryDetails", "Home");
               
            }
        }

        // Customer Login 
        

        /// Customer Sign In
        /// 
        public ActionResult SignInCheckout()
        {
            Session["Checkout"] = "Yes";
            return RedirectToAction("SignIn", "Login");
        }

        public ActionResult LoginCheckout()
        {
            Session["LoginCheckout"] = "Yes";
            return RedirectToAction("Index", "Login");
        }

        public ActionResult SignIn()
        {
            Session["CaptchaCode"] = TextLib.GetCaptcha();
            TextLib.DrawCaptch(Session["CaptchaCode"].ToString());
            return View();
        }
        [HttpPost]
        public ActionResult SignIn(FormCollection form)
        {
            CustomerModel c = new CustomerModel
            {
                CustomerName = form["CustomerName"],
                Mobile = form["Mobile"],
                Email = form["Email"],
                Address = form["Password"]
            };


            string captchacode = form["CaptchaCode"];
            string capCode = Session["CaptchaCode"].ToString();
            var dup = db.CustomerModels.Any(x => x.Mobile.Equals(c.Mobile));
            if(dup==false)
            {
                if (capCode == captchacode)
                {

                    int incid = db.CustomerModels.DefaultIfEmpty().Max(r => r == null ? 0 : r.CustomerID);
                    c.CustomerID = incid + 1;
                    db.CustomerModels.Add(c);
                    db.SaveChanges();
                    //
                    // Delivery 
                    if (Session["Checkout"] != null)
                    {
                        Session.Remove("Checkout");
                        // login session
                        Session["CustomerID"] = c.CustomerID;
                        Session["CustomerName"] = c.CustomerName;
                        Session["cLoginStatus"] = "Yes";
                        return RedirectToAction("DeliveryDetails", "Home");  // Delivery Address Page   

                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Customer");  // Dashboard  
                    }

                }
                else
                {                    
                    ViewBag.SweetMessage = "Invalid Captcha Code !";
                    return View();
                }
            }
            else
            {
                ViewBag.SweetMessage = "This mobile aleady register with us !";
                return View();
            }
                         
        }
    }
}