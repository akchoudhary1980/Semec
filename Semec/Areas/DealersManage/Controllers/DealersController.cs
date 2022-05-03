using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Web.Mvc; 
using Semec.Areas.DealersManage.Model;

namespace Semec.Areas.DealersManage.Controllers
{
    public class DealersController : Controller
    {
        public MyContext db = new MyContext();
        public DataTable Trans; // Items Trans 
        public ActionResult Index()
        {
            ViewData["PageTitle"] = "Dealers List";
            return View();
        }
        [HttpPost]
        public ActionResult GetIndex()
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();
            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();

            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            using (MyContext dc = new MyContext())
            {
                //data
                var obj = (from t1 in dc.DealersModels // Item Model
                           select new
                           {
                               t1.DealersID,
                               t1.Logo,
                               t1.Company,
                               t1.Brand,
                               t1.CP1,
                               t1.MobileCP1,
                               t1.Website,
                               // un display items 
                               t1.EmailCP1,
                               t1.CP2,
                               t1.EmailCP2,
                               t1.MobileCP2,
                               t1.CP3,
                               t1.EmailCP3,
                               t1.MobileCP3,
                               t1.DealIn,
                               t1.City,
                               t1.State,
                               t1.Address
                           });
                // for Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    if(sortColumn.Equals("DealersID"))
                    {
                        obj = obj.OrderBy(sortColumn + " " + "desc");
                    }
                    else
                    {
                        obj = obj.OrderBy(sortColumn + " " + sortColumnDir);
                    }                    
                }
                // searching 
                if (!string.IsNullOrEmpty(searchValue))
                {
                    obj = obj.Where(m => m.Company.Contains(searchValue)
                                                     || m.Brand.Contains(searchValue)
                                                     || m.CP1.Contains(searchValue)
                                                     || m.MobileCP1.Contains(searchValue)
                                                     || m.Website.Contains(searchValue)
                                                     // un dispaly items   
                                                     || m.EmailCP1.Contains(searchValue)
                                                     || m.CP2.Contains(searchValue)
                                                     || m.EmailCP2.Contains(searchValue)
                                                     || m.MobileCP2.Contains(searchValue)
                                                     || m.CP3.Contains(searchValue)
                                                     || m.EmailCP3.Contains(searchValue)
                                                     || m.MobileCP3.Contains(searchValue)
                                                     || m.DealIn.Contains(searchValue)
                                                     || m.City.Contains(searchValue)
                                                     || m.State.Contains(searchValue)
                                                     || m.Address.Contains(searchValue)
                                                    

                                                     );

                }


                // data transfer 
                recordsTotal = obj.Count();
                var data = obj.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }
       
        public ActionResult Create()
        {
            // DataTable 
            Trans = new DataTable();
            Trans.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("SerNo", typeof(int)),
                new DataColumn("ItemID", typeof(int)),
                new DataColumn("ItemName", typeof(string))
            });
            Session.Add("Trans", Trans);
            // End

            ViewData["PageTitle"] = "New Dealer";
            return View();
        }
        [HttpPost]
        public ActionResult Create(DealersModel obj)
        {
            if (ModelState.IsValid)
            {

                bool isduplicate = db.DealersModels.Any(x => x.Company == obj.Company);
                // Check Duplicate              
                if (isduplicate == true)
                {
                    ModelState.AddModelError("Company", "Duplicate Record Found");
                    return View();
                }
                else
                {
                    DataTable dt = Session["Trans"] as DataTable;
                    int DealersID=0;

                    int incid = db.DealersModels.DefaultIfEmpty().Max(r => r == null ? 0 : r.DealersID);
                    obj.DealersID = incid + 1;
                    DealersID = obj.DealersID;
                    obj.Logo = TextLib.UploadFilewithHTMLControl("FileLogo", "DealInLogo" + obj.DealersID.ToString());
                    obj.Cataloge = TextLib.UploadFilewithHTMLControl("FileCataloge", "DealInCataloge" + obj.DealersID.ToString());
                    obj.DealIn = GetDealInList(dt);
                    db.DealersModels.Add(obj);
                    db.SaveChanges();
                    // Insert Transaction                     
                    InsertSaleTrans(DealersID, dt);
                    Response.Cookies["Create"].Value = "Yes";
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return View();
            }
        }
        public void InsertSaleTrans(int id, DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    DealInModel obj = new DealInModel();
                    int incid = db.DealInModels.DefaultIfEmpty().Max(r => r == null ? 0 : r.DealInID);
                    obj.DealInID = incid + 1;

                    obj.DealersID = id; // dealer id 
                    obj.ItemID = Convert.ToInt32(dr["ItemID"].ToString());
                    obj.ItemName = dr["ItemName"].ToString();
                    db.DealInModels.Add(obj);
                    db.SaveChanges();
                }
            }
        }
        public ActionResult Edit(int id)
        {
            // DataTable 
            Trans = new DataTable();
            Trans.Columns.AddRange(new DataColumn[3]
            {
                new DataColumn("SerNo", typeof(int)),
                new DataColumn("ItemID", typeof(int)),
                new DataColumn("ItemName", typeof(string))
            });
            Session.Add("Trans", Trans);
            // End
            ViewData["PageTitle"] = "Update Dealer";
            var model = db.DealersModels.Where(x => x.DealersID == id).FirstOrDefault();           
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DealersModel obj)
        {
            MyContext db1 = new MyContext();
            if (ModelState.IsValid)
            {
                // Check Duplicate and prevet duplication at the time of edit
                var oldvalue = db1.DealersModels.Where(x => x.DealersID == obj.DealersID).SingleOrDefault();
                if (oldvalue.Company != obj.Company)
                {
                    bool duplicate = db1.DealersModels.Any(x => x.Company == obj.Company);
                    if (duplicate)
                    {
                        ModelState.AddModelError("Company", "Duplicate Record Found");
                        return View();
                    }
                    else
                    {

                        // Picture
                        if (TextLib.UploadFilewithHTMLControl("FileLogo", "DealInLogo" + obj.DealersID.ToString()) != "No.png")
                        {
                            obj.Logo = TextLib.UploadFilewithHTMLControl("FileLogo", "DealInLogo" + obj.DealersID.ToString());
                        }
                        else
                        {
                            obj.Logo = oldvalue.Logo;
                        }

                        // cataloge
                        if (TextLib.UploadFilewithHTMLControl("FileCataloge", "DealInCataloge" + obj.DealersID.ToString()) != "No.png")
                        {
                            obj.Cataloge = TextLib.UploadFilewithHTMLControl("FileCataloge", "DealInCataloge" + obj.DealersID.ToString());
                        }
                        else
                        {
                            obj.Cataloge = oldvalue.Cataloge;
                        }

                        DataTable dt = Session["Trans"] as DataTable;
                        obj.DealIn = GetDealInList(dt);

                        db.Entry(obj).State = EntityState.Modified;
                        db.SaveChanges();
                        
                        // remove from Deal in 
                        db.DealInModels.RemoveRange(db.DealInModels.Where(x => x.DealersID == obj.DealersID));

                        db.SaveChanges();
                        // Newly  Insert Transaction                     
                        
                        InsertSaleTrans(obj.DealersID, dt);

                        Response.Cookies["Edit"].Value = "Yes";
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {

                    // Picture
                    if (TextLib.UploadFilewithHTMLControl("FileLogo", "DealInLogo" + obj.DealersID.ToString()) != "No.png")
                    {
                        obj.Logo = TextLib.UploadFilewithHTMLControl("FileLogo", "DealInLogo" + obj.DealersID.ToString());
                    }
                    else
                    {
                        obj.Logo = oldvalue.Logo;
                    }

                    // cataloge
                    if (TextLib.UploadFilewithHTMLControl("FileCataloge", "DealInCataloge" + obj.DealersID.ToString()) != "No.png")
                    {
                        obj.Cataloge = TextLib.UploadFilewithHTMLControl("FileCataloge", "DealInCataloge" + obj.DealersID.ToString());
                    }
                    else
                    {
                        obj.Cataloge = oldvalue.Cataloge;
                    }

                    DataTable dt = Session["Trans"] as DataTable;
                    obj.DealIn = GetDealInList(dt);

                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();

                    // remove from Deal in 
                    db.DealInModels.RemoveRange(db.DealInModels.Where(x => x.DealersID == obj.DealersID));
                    db.SaveChanges();
                    // Newly  Insert Transaction
                    InsertSaleTrans(obj.DealersID, dt);

                    Response.Cookies["Edit"].Value = "Yes";
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            ViewData["PageTitle"] = "Delete Dealer";            
            var model = db.DealersModels.Where(x => x.DealersID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id, string confirm)
        {
            if (confirm == "Yes")
            {
                var dealer = db.DealersModels.Where(x => x.DealersID == id).SingleOrDefault();
                // Delete Logo 
                if(dealer.Logo!="No")
                {
                   TextLib.DeleteFile(dealer.Logo);
                }
                // Delete Cata
                if (dealer.Cataloge != "No")
                {
                    TextLib.DeleteFile(dealer.Cataloge);
                }

                // from Dealer 
                db.DealersModels.RemoveRange(db.DealersModels.Where(x => x.DealersID == id));
                db.SaveChanges();
                // from Deal in 
                db.DealInModels.RemoveRange(db.DealInModels.Where(x => x.DealersID == id));
                db.SaveChanges();

                return RedirectToAction(nameof(Index));               
            }
            else
            {
                return View();
            }
        }

        public ActionResult View(int id)
        {
            ViewData["PageTitle"] = "Dealers Details";
            var model = db.DealersModels.Where(x => x.DealersID == id).FirstOrDefault();

            string EmailTo = "";
            string Subject = "Tender Enqury for --.";
            var msg = new System.Net.Mail.MailMessage();
            msg.IsBodyHtml = true;

            msg.Body = "Dear Sir, %0aPlease find attached GEM Tender Enquiry for --- ."
                + "%0aKindly suggest us suitable product / model."
                + "%0aThanks";

            EmailTo = model.EmailCP1 + ";";

            if (model.EmailCP2 != null)
            {
                EmailTo = EmailTo + model.EmailCP2 + ";";
            }
            if (model.EmailCP3 != null)
            {
                EmailTo = EmailTo + model.EmailCP3 + ";";
            }
            if (model.EmailCP4 != null)
            {
                EmailTo = EmailTo + model.EmailCP4 + ";";
            }
            if (model.EmailCP5 != null)
            {
                EmailTo = EmailTo + model.EmailCP5 + ";";
            }


            ViewData["EmailTo"] = EmailTo;
            ViewData["Subject"] = Subject;
            ViewData["Body"] = msg.Body;
            return View(model);
        }
        // App
        // Get Item Auto Complete List
        public JsonResult ItemAutoComplete(string Prefix)
        {
            var list = db.ItemModels.Where(x => x.ItemName.Contains(Prefix))
                       .Select(x => new { x.ItemID, x.ItemName }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Add Trans Data       
        [ValidateAntiForgeryToken]
        public JsonResult InsertRow(string ID)
        {
            int id = Convert.ToInt32(ID);
            DataTable dt = Session["Trans"] as DataTable;            
            //Add to Datatable
            var item = db.ItemModels.Where(x => x.ItemID == id).SingleOrDefault();           
            dt.Rows.Add(TextLib.GetMaxDataTableColoumn(dt, "SerNo") + 1, id, item.ItemName);
            // for return data
            List<ItemTrans> list = new List<ItemTrans>();
            foreach (DataRow dr in dt.Rows)
            {   
                list.Add(new ItemTrans(
                    Convert.ToInt32(dr["SerNo"].ToString()),
                    Convert.ToInt32(dr["ItemID"].ToString()),
                    dr["ItemName"].ToString()
                    ));
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Add Trans Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult InsertItem(string ItemName)
        {
            string Message = "";
            bool isduplicate = db.ItemModels.Any(x => x.ItemName == ItemName);
            // Check Duplicate              
            if (isduplicate == true)
            {
               Message = "Duplicate Record Found";
            }
            else
            {
                ItemModel obj = new ItemModel();
                int incid = db.ItemModels.DefaultIfEmpty().Max(r => r == null ? 0 : r.ItemID);
                obj.ItemID = incid + 1;
                obj.ItemName = ItemName;
                db.ItemModels.Add(obj);
                db.SaveChanges();
                Message = obj.ItemID +"^"+ obj.ItemName;
            }
            return Json(Message, JsonRequestBehavior.AllowGet);
        }

        // Remove Trans Data
        public JsonResult DeleteRow(string iSer)
        {
            // Logic for Delete Operation            
            DataTable dt = Session["Trans"] as DataTable;
            // for Delete 
            for (int i = dt.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dt.Rows[i];
                if ((dr["SerNo"].ToString().Equals(iSer)))
                    dr.Delete();
            }
            dt.AcceptChanges();
            // End 
            // for return data
            List<ItemTrans> list = new List<ItemTrans>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(new ItemTrans(
                    Convert.ToInt32(dr["SerNo"].ToString()),
                    Convert.ToInt32(dr["ItemID"].ToString()),
                    dr["ItemName"].ToString()
                    ));
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        // Load Data When Edit 
        public JsonResult FetchRow(int iID)
        {
            List<ItemTrans> list = new List<ItemTrans>();
            // Get From Database 
            DataTable DealTrans = DataLib.GetQueryTable("Select * from DealInModels Where DealersID =" + iID);
            DataTable dt = Session["Trans"] as DataTable;
            if (dt != null)
            {
                dt.Clear();
                int i = 0;
                foreach (DataRow dr in DealTrans.Rows)
                {
                    dt.Rows.Add(i++, Convert.ToInt32(dr["ItemID"].ToString()), dr["ItemName"].ToString());
                }
                // for return data           
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(new ItemTrans(
                        Convert.ToInt32(dr["SerNo"].ToString()),
                        Convert.ToInt32(dr["ItemID"].ToString()),
                        dr["ItemName"].ToString()
                        ));
                }
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public string GetDealInList(DataTable dt)
        {
            string list = "";
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list = list + "," + dr["ItemName"].ToString();
                }
                list = list.Substring(1, list.Length-1);
            }
            return list;
        }
        // Download File 
        public ActionResult DownloadFile(string filename)
        {
            string fullName = Server.MapPath("~/UploadFiles/" + filename);
            byte[] fileBytes = GetFile(fullName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filename);
        }
        public byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }

        /// Get Designation List
        public static List<SelectListItem> GetDesginationList()
        {
            List<SelectListItem> ls = new List<SelectListItem>();
            MyContext db1 = new MyContext();
            var mylist = db1.DesginationModels.ToList();
            ls.Add(new SelectListItem() { Text = "Select", Value = "0" });
            foreach (var temp in mylist)
            {
                ls.Add(new SelectListItem() { Text = temp.DesginationName, Value = temp.DesginationID.ToString() });
            }
            db1.Dispose();
            return ls;
        }
    }
}