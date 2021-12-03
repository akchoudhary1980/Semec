using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace Semec.Controllers
{
    //[CheckLoginStatus]
    public class ShareController : Controller
    {
        // GET: Share
        private readonly MyContext db = new MyContext();
        public ActionResult Index()
        {
            return View();
        }

        // Get Country List
        public JsonResult CountryAutoComplete(string Prefix)
        {
            var countrylist = db.CountryModels.Where(x => x.CountryName.Contains(Prefix))
                       .Select(x => new { x.CountryID, x.CountryName }).ToList();
            return Json(countrylist, JsonRequestBehavior.AllowGet);
        }
        // Get State List 
        public JsonResult StateAutoComplete(string Prefix)
        {
            var statelist = db.StateModels.Where(x => x.StateName.StartsWith(Prefix))
                       .Select(x => new { x.StateID, x.StateName }).ToList();
            return Json(statelist, JsonRequestBehavior.AllowGet);
        }
        // Get City List
        public JsonResult CityAutoComplete(string Prefix)
        {
            var citylist = db.CityModels.Where(x => x.CityName.StartsWith(Prefix))
                       .Select(x => new { x.CityID, x.CityName }).ToList();
            return Json(citylist, JsonRequestBehavior.AllowGet);
        }



        /// Get Designation List
        public static List<SelectListItem> GetDesignationList()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            MyContext db = new MyContext();
            var mylist = db.DesginationModels.ToList();
            ls.Add(new SelectListItem() { Text = "Select", Value = "" });
            foreach (var temp in mylist)
            {
                ls.Add(new SelectListItem() { Text = temp.DesginationName, Value = temp.DesginationID.ToString() });
            }            
            return ls;
        }
        
        
        public static List<SelectListItem> GetRentPeriodList()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            ls.Add(new SelectListItem() { Text = "Select", Value = "" });
            ls.Add(new SelectListItem() { Text = "3 Months", Value = "3 Months" });
            ls.Add(new SelectListItem() { Text = "6 Months", Value = "6 Months" });
            ls.Add(new SelectListItem() { Text = "11 Months", Value = "11 Months" });
            ls.Add(new SelectListItem() { Text = "23 Months", Value = "23 Months" });
            ls.Add(new SelectListItem() { Text = "35 Months", Value = "35 Months" });
            ls.Add(new SelectListItem() { Text = "Un Decide", Value = "Un Decide" });
            return ls;
        }
        /// Get Designation List
        public static List<SelectListItem> GetCompanyList()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            MyContext db1 = new MyContext();
            var mylist = db1.CompanyModels.ToList();
            ls.Add(new SelectListItem() { Text = "Select", Value = "" });
            foreach (var temp in mylist)
            {
                ls.Add(new SelectListItem() { Text = temp.CompanyName, Value = temp.CompanyID.ToString() });
            }
            db1.Dispose();
            return ls;
        }       

        // Get Customer Mobile List
        public JsonResult CustomerMobileAutoComplete(string Prefix)
        {
            var mobilelist = db.CustomerModels.Where(x => x.Mobile.Contains(Prefix))
                       .Select(x => new { x.CustomerID, x.Mobile }).ToList();
            return Json(mobilelist, JsonRequestBehavior.AllowGet);
        }
        // Get Customer Email List
        public JsonResult CustomerEmailAutoComplete(string Prefix)
        {
            var mobilelist = db.CustomerModels.Where(x => x.Email.Contains(Prefix))
                       .Select(x => new { x.CustomerID, x.Email }).ToList();
            return Json(mobilelist, JsonRequestBehavior.AllowGet);
        }

        // Get Customer Name List
        public JsonResult VenderNameAutoComplete(string Prefix)
        {
            var mobilelist = db.VenderModels.Where(x => x.VenderName.Contains(Prefix))
                       .Select(x => new { x.VenderID, x.VenderName }).ToList();
            return Json(mobilelist, JsonRequestBehavior.AllowGet);
        }

        // Get Customer Name List
        public JsonResult CustomerNameAutoComplete(string Prefix)
        {
            var mobilelist = db.CustomerModels.Where(x => x.CustomerName.Contains(Prefix))
                       .Select(x => new { x.CustomerID, x.CustomerName }).ToList();
            return Json(mobilelist, JsonRequestBehavior.AllowGet);
        }
        
        

        // Get Cudtomer List
        
        // Get Customer Info by Mobile
        //[HttpPost]
        //public ActionResult GetCustomerInfoByMobile(string Mobile)
        //{
        //    string message;
        //    try
        //    {
        //        var cus = db.CustomerModels.Where(x => x.Mobile == Mobile).SingleOrDefault();
        //        string OrderNo = DataLib.GetCellItems("Select OrderNo from OrderModels Where CustomerID =" + cus.CustomerID);
        //        message = "Order No :" + OrderNo + " | Name :" + cus.CustomerName + " | Mobile:" + cus.Mobile + " | City:" + cus.City;
        //        message = cus.CustomerID + "^" + DataLib.GetCellItems("Select OrderID from OrderModels Where CustomerID =" + cus.CustomerID) + "^" + message;                
        //    }
        //    catch
        //    {
        //        message = "No Record Found !";
        //    }
        //      return Json(message, JsonRequestBehavior.AllowGet);
        //}
        // Get Customer Info by Mobile
        //[HttpPost]
        //public ActionResult GetCustomerInfoByOrderNo(string OrderNo)
        //{
        //    string message;
        //    try
        //    {
        //        int cusid = Convert.ToInt32(DataLib.GetCellItems("Select CustomerID from OrderModels Where OrderNo =" + OrderNo));
        //        var cus = db.CustomerModels.Where(x => x.CustomerID == cusid).SingleOrDefault();                
        //        message = "Order No :" + OrderNo + " | Name :" + cus.CustomerName + " | Mobile:" + cus.Mobile + " | City:" + cus.City;
        //        message = cus.CustomerID + "^" + DataLib.GetCellItems("Select OrderID from OrderModels Where CustomerID =" + cus.CustomerID) + "^" + message;
        //    }
        //    catch
        //    {
        //        message = "No Record Found !";
        //    }
        //    return Json(message, JsonRequestBehavior.AllowGet);
        //}


        // Get Product Auto Complete List
        public JsonResult ProductAutoComplete(string Prefix)
        {
            var productlist = db.ProductModels.Where(x => x.ProductName.Contains(Prefix))
                       .Select(x => new { x.ProductID, x.ProductName }).ToList();
            return Json(productlist, JsonRequestBehavior.AllowGet);
        }

        // Get Service Auto Complete List
        public JsonResult ServiceAutoComplete(string Prefix)
        {
            var productlist = db.ServiceModels.Where(x => x.ServiceName.Contains(Prefix))
                       .Select(x => new { x.ServiceID, x.ServiceName }).ToList();
            return Json(productlist, JsonRequestBehavior.AllowGet);
        }

        // Customer Details Auto Fill 
        public JsonResult CustomerDetailFill(int CustomerID)
        {
            string result;
            var v = db.CustomerModels.Where(x => x.CustomerID == CustomerID).SingleOrDefault();
            result = v.CustomerID + "^"
                     + v.CustomerName + "^"
                     + v.Address + "^"
                     + v.State + "^"
                     + v.City + "^"
                     + v.Mobile + "^"
                     + v.Whatsup + "^"
                     + v.Email + "^"
                     + v.ProfessionID + "^"
                     + v.GSTNo + "^";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // Get Profession List 
        public static List<SelectListItem> GetProfessionList()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            MyContext db = new MyContext();
            var mylist = db.ProfessionModels.ToList();
            ls.Add(new SelectListItem() { Text = "Select", Value = "" });
            foreach (var temp in mylist)
            {
                ls.Add(new SelectListItem() { Text = temp.ProfessionName, Value = temp.ProfessionID.ToString() });
            }           
            return ls;
        }

        //// Product and Service Details Auto Fill 
        //public JsonResult AutoFillData(string iID, string iType)
        //{
        //    string result;
        //    if (iType == "P")
        //    {
        //        string unitID = DataLib.GetCellItems("Select UnitID From ProductModels Where ProductID =" + iID);
        //        string unitName = DataLib.GetCellItems("Select UnitName From UnitModels Where UnitID =" + unitID); // 
        //        string gstslabID = DataLib.GetCellItems("Select GSTSlabID From ProductModels Where ProductID = " + iID);
        //        string gstslab = DataLib.GetCellItems("Select PercentValue From GSTSlabModels Where GSTSlabID = " + gstslabID); // 
        //        string rate = DataLib.GetCellItems("Select Rate From ProductModels Where ProductID =" + iID);
        //        result = unitName + "^" + gstslab + "^" + rate;
        //    }
        //    else
        //    {
        //        string unitID = DataLib.GetCellItems("Select UnitID From ServiceModels Where ServiceID =" + iID);
        //        string unitName = DataLib.GetCellItems("Select UnitName From UnitModels Where UnitID =" + unitID); // 
        //        string gstslabID = DataLib.GetCellItems("Select GSTSlabID From ServiceModels Where ServiceID = " + iID);
        //        string gstslab = DataLib.GetCellItems("Select PercentValue From GSTSlabModels Where GSTSlabID = " + gstslabID); // 
        //        string rate = DataLib.GetCellItems("Select ServiceCharge From ServiceModels Where ServiceID =" + iID);
        //        result = unitName + "^" + gstslab + "^" + rate;
        //    }
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}