using Semec.Areas.EmdManage.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace Semec.Areas.EmdManage.Controllers
{
    public class DealersController : Controller
    {
        public MyContext db = new MyContext();
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
        public ActionResult Create()
        {
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
                    int incid = db.DealersModels.DefaultIfEmpty().Max(r => r == null ? 0 : r.DealersID);
                    obj.DealersID = incid + 1;
                    db.DealersModels.Add(obj);
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
            ViewData["PageTitle"] = "Edit Item";
            var model = db.DealersModels.Where(x => x.DealersID == id).FirstOrDefault();
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(ItemModel obj)
        {
            MyContext db1 = new MyContext();
            if (ModelState.IsValid)
            {
                // Check Duplicate and prevet duplication at the time of edit
                var oldvalue = db1.ItemModels.Where(x => x.ItemID == obj.ItemID).SingleOrDefault();
                if (oldvalue.ItemName != obj.ItemName)
                {
                    bool duplicate = db1.ItemModels.Any(x => x.ItemName == obj.ItemName);
                    if (duplicate)
                    {
                        ModelState.AddModelError("ItemName", "Duplicate Record Found");
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
    }
}