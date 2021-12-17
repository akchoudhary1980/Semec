﻿using Semec.Areas.TenderSearchManage.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace Semec.Areas.TenderSearchManage.Controllers
{
    public class TenderSearchLinkController : Controller
    {
        public MyContext db = new MyContext();
        public ActionResult Index()
        {
            ViewData["PageTitle"] = "Tender Search Link List";
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
                var obj = (from t1 in dc.TenderSearchLinkModels// Item Model
                           // join here 

                           select new
                           {
                               t1.TenderSearchLinkID,
                               t1.State,
                               t1.City,
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
                    obj = obj.Where(m => m.City.Contains(searchValue));
                }


                // data transfer 
                recordsTotal = obj.Count();
                var data = obj.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Create()
        {
            ViewData["PageTitle"] = "New Tender Search Link";
            return View();
        }
        [HttpPost]
        public ActionResult Create(TenderSearchLinkModel obj)
        {
            if (ModelState.IsValid)
            {
                bool isduplicate = db.TenderSearchLinkModels.Any(x => x.TenderSearchLink == obj.TenderSearchLink);
                // Check Duplicate              
                if (isduplicate == true)
                {
                    ModelState.AddModelError("TenderSearchLink", "Duplicate Record Found");
                    return View();
                }
                else
                {
                    int incid = db.TenderSearchLinkModels.DefaultIfEmpty().Max(r => r == null ? 0 : r.TenderSearchLinkID);
                    obj.TenderSearchLinkID = incid + 1;

                    obj.Logo = TextLib.UploadFilewithHTMLControl("FileLogo", "TenderSearchLogo" + obj.TenderSearchLinkID.ToString());

                    db.TenderSearchLinkModels.Add(obj);
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
            ViewData["PageTitle"] = "Edit Tender Search Link";
            var model = db.TenderSearchLinkModels.Where(x => x.TenderSearchLinkID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(TenderSearchLinkModel obj)
        {
            MyContext db1 = new MyContext();
            if (ModelState.IsValid)
            {
                // Check Duplicate and prevet duplication at the time of edit
                var oldvalue = db1.TenderSearchLinkModels.Where(x => x.TenderSearchLinkID == obj.TenderSearchLinkID).SingleOrDefault();
                if (oldvalue.TenderSearchLink != obj.TenderSearchLink)
                {
                    bool duplicate = db1.TenderSearchLinkModels.Any(x => x.TenderSearchLink == obj.TenderSearchLink);
                    if (duplicate)
                    {
                        ModelState.AddModelError("TenderSearchLink", "Duplicate Record Found");
                        return View();
                    }
                    else
                    {
                        // Picture
                        if (TextLib.UploadFilewithHTMLControl("FileLogo", "TenderSearchLogo" + obj.TenderSearchLinkID.ToString()) != "No.png")
                        {
                            obj.Logo = TextLib.UploadFilewithHTMLControl("FileLogo", "DealInLogo" + obj.TenderSearchLinkID.ToString());
                        }
                        else
                        {
                            obj.Logo = oldvalue.Logo;
                        }

                        db.Entry(obj).State = EntityState.Modified;
                        db.SaveChanges();
                        Response.Cookies["Edit"].Value = "Yes";
                        return RedirectToAction(nameof(Index));
                    }
                }
                else
                {
                    // Picture
                    if (TextLib.UploadFilewithHTMLControl("FileLogo", "TenderSearchLogo" + obj.TenderSearchLinkID.ToString()) != "No.png")
                    {
                        obj.Logo = TextLib.UploadFilewithHTMLControl("FileLogo", "DealInLogo" + obj.TenderSearchLinkID.ToString());
                    }
                    else
                    {
                        obj.Logo = oldvalue.Logo;
                    }

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
            ViewData["PageTitle"] = "Delete Tender Search Link";
            var model = db.TenderSearchLinkModels.Where(x => x.TenderSearchLinkID == id).FirstOrDefault();
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
                    ViewData["PageTitle"] = "Tender Search Link";
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

        // Get Department Auto Complete List
        public JsonResult DepartmentAutoComplete(string Prefix)
        {
            var list = db.DepartmentModels.Where(x => x.DepartmentName.Contains(Prefix))
                       .Select(x => new { x.DepartmentID, x.DepartmentName }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        // Get Department Category Auto Complete List
        public JsonResult DepartmentCategoryAutoComplete(string Prefix)
        {
            var list = db.DepartmentCategoryModels.Where(x => x.DepartmentCategoryName.Contains(Prefix))
                       .Select(x => new { x.DepartmentCategoryID, x.DepartmentCategoryName }).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        // Add Department Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult InsertDepartment(string DepartmentName)
        {
            string Message = "";
            bool isduplicate = db.DepartmentModels.Any(x => x.DepartmentName == DepartmentName);
            // Check Duplicate              
            if (isduplicate == true)
            {
                Message = "Duplicate Record Found";
            }
            else
            {
                DepartmentModel obj = new DepartmentModel();
                int incid = db.DepartmentModels.DefaultIfEmpty().Max(r => r == null ? 0 : r.DepartmentID);
                obj.DepartmentID = incid + 1;
                obj.DepartmentName = DepartmentName;
                db.DepartmentModels.Add(obj);
                db.SaveChanges();
                Message = obj.DepartmentID + "^" + obj.DepartmentName;
            }
            return Json(Message, JsonRequestBehavior.AllowGet);
        }
        // Add Department Category Data
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult InsertDepartmentCategory(string DepartmentCategoryName)
        {
            string Message = "";
            bool isduplicate = db.DepartmentCategoryModels.Any(x => x.DepartmentCategoryName == DepartmentCategoryName);
            // Check Duplicate              
            if (isduplicate == true)
            {
                Message = "Duplicate Record Found";
            }
            else
            {
                DepartmentCategoryModel obj = new DepartmentCategoryModel();
                int incid = db.DepartmentCategoryModels.DefaultIfEmpty().Max(r => r == null ? 0 : r.DepartmentCategoryID);
                obj.DepartmentCategoryID = incid + 1;
                obj.DepartmentCategoryName = DepartmentCategoryName;
                db.DepartmentCategoryModels.Add(obj);
                db.SaveChanges();
                Message = obj.DepartmentCategoryID + "^" + obj.DepartmentCategoryName;
            }
            return Json(Message, JsonRequestBehavior.AllowGet);
        }
    }
}