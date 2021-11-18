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
    public class StateController : Controller
    {
        public MyContext db = new MyContext();       
        public ActionResult Index()
        {             
            ViewData["PageTitle"] = "State List"; 
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
            if (sortColumn == "StateID")
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
                var citylist = (from t1 in db.StateModels // state                                                                    
                                join t2 in db.CountryModels // country 
                                on t1.CountryID equals t2.CountryID
                                select new
                                {
                                    t1.StateID,
                                    t1.StateName,
                                    t1.StateType,
                                    t2.CountryName,
                                });


                // 
                // for Sorting
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    citylist = citylist.OrderBy(sortColumn + " " + sortColumnDir);
                }
                // for Searching                 
                if (!string.IsNullOrEmpty(searchValue))
                {
                    citylist = citylist.Where(m => m.StateName.Contains(searchValue)
                                                        || m.StateType.Contains(searchValue)
                                                        || m.CountryName.Contains(searchValue)
                                                        );
                }

                // data transfer 
                recordsTotal = citylist.Count();
                var data = citylist.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);               
            }
        }
        public ActionResult Create()
        {
            ViewData["PageTitle"] = "New State";
            return View();
        }        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StateModel obj)
        {
            if (ModelState.IsValid)
            {
                bool duplicate = db.StateModels.Any(x => x.StateName == obj.StateName);
                if (duplicate)
                {
                    ModelState.AddModelError("StateName", "Duplicate Record Found");
                    return View();
                }
                else
                {                   
                    int incid = db.StateModels.DefaultIfEmpty().Max(r => r == null ? 0 : r.StateID);
                    obj.StateID = incid + 1;
                    
                    db.StateModels.Add(obj);
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
            ViewData["PageTitle"] = "Edit State";
            var model = db.StateModels.Where(x => x.StateID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(StateModel obj)
        {
            if (ModelState.IsValid)
            {
                // Check Duplicate and prevet duplication at the time of edit 
                //dbContext db1 = new dbContext();
                var oldvalue = db.StateModels.Where(x => x.StateID == obj.StateID).SingleOrDefault();
                if (oldvalue.StateName != obj.StateName)
                {
                    bool duplicate = db.StateModels.Any(x => x.StateName == obj.StateName);
                    if (duplicate)
                    {
                        ModelState.AddModelError("StateName", "Duplicate Record Found");
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
            ViewData["PageTitle"] = "Delete State";
            var model = db.StateModels.Where(x => x.StateID == id).FirstOrDefault();           
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id,string confirm)
        {   
            string s = confirm;
            if (confirm=="Yes")
            {                
                db.StateModels.RemoveRange(db.StateModels.Where(x => x.StateID == id));
                db.SaveChanges();
                return RedirectToAction(nameof(Index));               
            }
            else
            {
                return View();
            }           
        }

        //public static List<SelectListItem> GetCountryList()
        //{            
        //    List<SelectListItem> ls = new List<SelectListItem>();
        //    var mylist = db.CountryModels.ToList();
        //    ls.Add(new SelectListItem() { Text = "Select", Value = "" });
        //    foreach (var temp in mylist)
        //    {
        //        ls.Add(new SelectListItem() { Text = temp.CountryName, Value = temp.CountryID.ToString() });
        //    }            
        //    return ls;
        //}

        public static List<SelectListItem> GetStateTypeList()
        {
            List<SelectListItem> ls = new List<SelectListItem>
            {
                new SelectListItem() { Text = "Select", Value = "" },
                new SelectListItem() { Text = "State", Value = "S" },
                new SelectListItem() { Text = "Union Teritery", Value = "T" }
            };
            return ls;
        }

       
    }
}