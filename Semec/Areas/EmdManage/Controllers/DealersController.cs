using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Collections.Generic;
using System.Web.Mvc;
using Semec.Areas.EmdManage.Model;

namespace Semec.Areas.EmdManage.Controllers
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
                               t1.Company,
                               t1.Brand
                           });
                // for Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    obj = obj.OrderBy(sortColumn + " " + sortColumnDir);
                }
                // searching 
                if (!string.IsNullOrEmpty(searchValue))
                {
                    obj = obj.Where(m => m.Company.Contains(searchValue)
                                                     || m.Brand.Contains(searchValue)
                                                     //|| m.CategoryName.Contains(searchValue)
                                                     //|| m.UnitName.Contains(searchValue)
                                                     //|| m.MRP.ToString().Contains(searchValue)
                                                     //|| m.MRP.ToString().Contains(searchValue)
                                                     //|| m.MRP.ToString().Contains(searchValue)
                                                     );

                }


                // data transfer 
                recordsTotal = obj.Count();
                var data = obj.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult View(int id)
        {
            ViewData["PageTitle"] = "Dealers Details";
            var model = db.DealersModels.Where(x => x.DealersID == id).FirstOrDefault();
            return View(model);            
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
                    Session["Create"] = "Yes";
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
            ViewData["PageTitle"] = "Edit Item";
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
                        if (TextLib.UploadFilewithHTMLControl("FileLogo", "DealInLogo" + obj.DealersID.ToString()) != "No")
                        {
                            obj.Logo = TextLib.UploadFilewithHTMLControl("FileLogo", "DealInLogo" + obj.DealersID.ToString());
                        }
                        else
                        {
                            obj.Logo = oldvalue.Logo;
                        }

                        // cataloge
                        if (TextLib.UploadFilewithHTMLControl("FileCataloge", "DealInCataloge" + obj.DealersID.ToString()) != "No")
                        {
                            obj.Cataloge = TextLib.UploadFilewithHTMLControl("FileCataloge", "DealInCataloge" + obj.DealersID.ToString());
                        }
                        else
                        {
                            obj.Cataloge = oldvalue.Cataloge;
                        }

                        db.Entry(obj).State = EntityState.Modified;
                        db.SaveChanges();
                        Session["Edit"] = "Yes";
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {

                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
                    Session["Edit"] = "Yes";
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
            ViewData["PageTitle"] = "Delete Item";
            ViewData["Error"] = "Do you want to delete this record !";
            var model = db.ItemModels.Where(x => x.ItemID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id, string confirm)
        {

            // if area used
            string s = confirm;
            if (confirm == "Yes")
            {
                bool p = db.DealInModels.Any(x => x.ItemID == id);
                // to do is used in Purchase / Quotation / Sales 
                if (p == false)
                {
                    db.ItemModels.RemoveRange(db.ItemModels.Where(x => x.ItemID == id));
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["PageTitle"] = "Item Manager";
                    var model = db.ItemModels.Where(x => x.ItemID == id).FirstOrDefault();
                    ViewData["Error"] = "You can not delete this record becuase it used !";
                    return View(model);
                }
            }
            else
            {
                return View();
            }
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
        public JsonResult InsertRow(int iID)
        {
            DataTable dt = Session["Trans"] as DataTable;            
            //Add to Datatable
            var item = db.ItemModels.Where(x => x.ItemID == iID).SingleOrDefault();           
            dt.Rows.Add(TextLib.GetMaxDataTableColoumn(dt, "SerNo") + 1,iID, item.ItemName);
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
    }
}