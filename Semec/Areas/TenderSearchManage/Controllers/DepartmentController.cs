using Semec.Areas.TenderSearchManage.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace Semec.Areas.TenderSearchManage.Controllers
{
    public class DepartmentController : Controller
    {
        public MyContext db = new MyContext();
        public ActionResult Index()
        {
            ViewData["PageTitle"] = "Department List";
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
                var obj = (from t1 in dc.DepartmentModels// Item Model
                           select new
                           {
                               t1.DepartmentID,
                               t1.DepartmentName,
                           });
                // for Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    if (sortColumn.Equals("DepartmentID"))
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
                    obj = obj.Where(m => m.DepartmentName.Contains(searchValue));
                }


                // data transfer 
                recordsTotal = obj.Count();
                var data = obj.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Create()
        {
            ViewData["PageTitle"] = "New Department";
            return View();
        }
        [HttpPost]
        public ActionResult Create(DepartmentModel obj)
        {
            if (ModelState.IsValid)
            {

                bool isduplicate = db.DepartmentModels.Any(x => x.DepartmentName == obj.DepartmentName);
                // Check Duplicate              
                if (isduplicate == true)
                {
                    ModelState.AddModelError("DepartmentName", "Duplicate Record Found");
                    return View();
                }
                else
                {
                    int incid = db.DepartmentModels.DefaultIfEmpty().Max(r => r == null ? 0 : r.DepartmentID);
                    obj.DepartmentID = incid + 1;
                    db.DepartmentModels.Add(obj);
                    db.SaveChanges();
                    Session["Create"] = "Yes";
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
            ViewData["PageTitle"] = "Edit Department";
            var model = db.DepartmentModels.Where(x => x.DepartmentID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DepartmentModel obj)
        {
            MyContext db1 = new MyContext();
            if (ModelState.IsValid)
            {
                // Check Duplicate and prevet duplication at the time of edit
                var oldvalue = db1.DepartmentModels.Where(x => x.DepartmentID == obj.DepartmentID).SingleOrDefault();
                if (oldvalue.DepartmentName != obj.DepartmentName)
                {
                    bool duplicate = db1.DepartmentModels.Any(x => x.DepartmentName == obj.DepartmentName);
                    if (duplicate)
                    {
                        ModelState.AddModelError("DepartmentName", "Duplicate Record Found");
                        return View();
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
            ViewData["PageTitle"] = "Delete DepartmentName";           
            var model = db.DepartmentModels.Where(x => x.DepartmentID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id, string confirm)
        {

            // if area used
            string s = confirm;
            if (confirm == "Yes")
            {
                bool p = db.TenderSearchLinkModels.Any(x => x.DepartmentCategoryID == id);
                // to do is used in logic ?
                if (p == false)
                {
                    db.DepartmentModels.RemoveRange(db.DepartmentModels.Where(x => x.DepartmentID == id));
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["PageTitle"] = "Item Manager";
                    var model = db.DepartmentModels.Where(x => x.DepartmentID == id).FirstOrDefault();
                    ModelState.AddModelError("DepartmentName", "You can not delete this record becuase it used !");
                    return View(model);
                }
            }
            else
            {
                return View();
            }
        }
    }
}