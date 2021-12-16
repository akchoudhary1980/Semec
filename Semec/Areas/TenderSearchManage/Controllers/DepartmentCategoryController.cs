using Semec.Areas.TenderSearchManage.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace Semec.Areas.TenderSearchManage.Controllers
{
    public class DepartmentCategoryController : Controller
    {
        public MyContext db = new MyContext();
        public ActionResult Index()
        {
            ViewData["PageTitle"] = "Department Category List";
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
                var obj = (from t1 in dc.DepartmentCategoryModels// Item Model
                           select new
                           {
                               t1.DepartmentCategoryID,
                               t1.DepartmentCategoryName,
                           });
                // for Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    if (sortColumn.Equals("DepartmentCategoryID"))
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
                    obj = obj.Where(m => m.DepartmentCategoryName.Contains(searchValue));
                }


                // data transfer 
                recordsTotal = obj.Count();
                var data = obj.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Create()
        {
            ViewData["PageTitle"] = "New Department Category";
            return View();
        }
        [HttpPost]
        public ActionResult Create(DepartmentCategoryModel obj)
        {
            if (ModelState.IsValid)
            {

                bool isduplicate = db.DepartmentCategoryModels.Any(x => x.DepartmentCategoryName == obj.DepartmentCategoryName);
                // Check Duplicate              
                if (isduplicate == true)
                {
                    ModelState.AddModelError("DepartmentCategoryName", "Duplicate Record Found");
                    return View();
                }
                else
                {
                    int incid = db.DepartmentCategoryModels.DefaultIfEmpty().Max(r => r == null ? 0 : r.DepartmentCategoryID);
                    obj.DepartmentCategoryID = incid + 1;
                    db.DepartmentCategoryModels.Add(obj);
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
            ViewData["PageTitle"] = "Edit Department Category";
            var model = db.DepartmentCategoryModels.Where(x => x.DepartmentCategoryID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DepartmentCategoryModel obj)
        {
            MyContext db1 = new MyContext();
            if (ModelState.IsValid)
            {
                // Check Duplicate and prevet duplication at the time of edit
                var oldvalue = db1.DepartmentCategoryModels.Where(x => x.DepartmentCategoryID == obj.DepartmentCategoryID).SingleOrDefault();
                if (oldvalue.DepartmentCategoryName != obj.DepartmentCategoryName)
                {
                    bool duplicate = db1.DepartmentCategoryModels.Any(x => x.DepartmentCategoryName == obj.DepartmentCategoryName);
                    if (duplicate)
                    {
                        ModelState.AddModelError("DepartmentCategoryName", "Duplicate Record Found");
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
            ViewData["PageTitle"] = "Delete Department Category";
            var model = db.DepartmentCategoryModels.Where(x => x.DepartmentCategoryID == id).FirstOrDefault();
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
                    db.DepartmentCategoryModels.RemoveRange(db.DepartmentCategoryModels.Where(x => x.DepartmentCategoryID == id));
                    db.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["PageTitle"] = "Item Manager";
                    var model = db.DepartmentCategoryModels.Where(x => x.DepartmentCategoryID == id).FirstOrDefault();
                    ModelState.AddModelError("DepartmentCategoryName", "You can not delete this record becuase it used !");
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