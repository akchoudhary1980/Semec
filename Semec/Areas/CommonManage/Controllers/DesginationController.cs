using Semec.Areas.CommonManage.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.Mvc;


namespace Semec.Areas.CommonManage.Controllers
{
    public class DesginationController : Controller
    {
        public MyContext db = new MyContext();       
        public ActionResult Index()
        {             
            ViewData["PageTitle"] = "Desgination List"; 
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
            //var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();
            var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            //for Sort Direction 
            var sortColumnDir = "";
            if (sortColumn == "DesginationID")
            {
                sortColumnDir = "desc";
            }
            else
            {
                sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();// Request.Form.GetValues["order[0][dir]"].FirstOrDefault();
            }
            // for Data
            using (MyContext dc = new MyContext())
            {
                var list = (from t1 in db.DesginationModels // state 
                                select new
                                {
                                    t1.DesginationID,
                                    t1.DesginationName,
                                    t1.Remark,
                                });


                // 
                // for Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    list = list.OrderBy(sortColumn + " " + sortColumnDir);
                }
                // for Searching                 
                if (!string.IsNullOrEmpty(searchValue))
                {
                    list = list.Where(m => m.DesginationName.Contains(searchValue)  
                    || m.Remark.Contains(searchValue)
                    );
                }

                // data transfer 
                recordsTotal = list.Count();
                var data = list.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);               
            }
        }
        public ActionResult Create()
        {
            ViewData["PageTitle"] = "New Desgination";
            return View();
        }        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DesginationModel obj)
        {
            if (ModelState.IsValid)
            {
                bool duplicate = db.DesginationModels.Any(x => x.DesginationName == obj.DesginationName);
                if (duplicate)
                {
                    ModelState.AddModelError("DesginationName", "Duplicate Record Found");
                    return View();
                }
                else
                {                   
                    int incid = db.DesginationModels.DefaultIfEmpty().Max(r => r == null ? 0 : r.DesginationID);
                    obj.DesginationID = incid + 1;
                    
                    db.DesginationModels.Add(obj);
                    db.SaveChanges();
                    Response.Cookies["Create"].Value = "Yes";                   
                    return RedirectToAction(nameof(Index));                   
                }
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            ViewData["PageTitle"] = "Update Desgination";
            var model = db.DesginationModels.Where(x => x.DesginationID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DesginationModel obj)
        {
            if (ModelState.IsValid)
            {   
                var oldvalue = db.DesginationModels.Where(x => x.DesginationID == obj.DesginationID).SingleOrDefault();
                if (oldvalue.DesginationName != obj.DesginationName)
                {
                    bool duplicate = db.DesginationModels.Any(x => x.DesginationName == obj.DesginationName);
                    if (duplicate)
                    {
                        ModelState.AddModelError("DesginationName", "Duplicate Record Found");
                        return View();
                    }
                    else
                    {                        
                        db.Entry(obj).State = EntityState.Modified;
                        db.SaveChanges();
                        Response.Cookies["Edit"].Value = "Yes";                        
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    
                    db.Entry(obj).State = EntityState.Modified;
                    db.SaveChanges();
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
            ViewData["PageTitle"] = "Delete Desgination";
            var model = db.DesginationModels.Where(x => x.DesginationID == id).FirstOrDefault();           
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id,string confirm)
        {   
            string s = confirm;
            if (confirm=="Yes")
            {                
                db.DesginationModels.RemoveRange(db.DesginationModels.Where(x => x.DesginationID == id));
                db.SaveChanges();
                return RedirectToAction(nameof(Index));               
            }
            else
            {
                return View();
            }           
        }
    }
}