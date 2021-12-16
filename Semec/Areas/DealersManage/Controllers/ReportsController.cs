using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Web.Mvc;

namespace Semec.Areas.DealersManage.Controllers
{
    public class ReportsController : Controller
    {
        public MyContext db = new MyContext();
        public ActionResult NoWebsite()
        {
            ViewData["PageTitle"] = "No Website List";
            return View();
        }
        [HttpPost]
        public ActionResult GetNoWebsite()
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
                var obj = (from t1 in dc.DealersModels.Where(x=>x.Website.Equals(null) || x.Website.Equals("")) // Dealer Model
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
                    if (sortColumn.Equals("DealersID"))
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
        public ActionResult NoBrand()
        {
            ViewData["PageTitle"] = "No Brand List";
            return View();
        }
        [HttpPost]
        public ActionResult GetNoBrand()
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
                var obj = (from t1 in dc.DealersModels.Where(x => x.Brand.Equals(null) || x.Brand.Equals("")) // Dealer Model
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
                    if (sortColumn.Equals("DealersID"))
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
        public ActionResult NoDealIn()
        {
            ViewData["PageTitle"] = "No DealIn List";
            return View();
        }
        [HttpPost]
        public ActionResult GetNoDealIn()
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
                var obj = (from t1 in dc.DealersModels.Where(x => x.DealIn.Equals(null) || x.DealIn.Equals("")) // Dealer Model
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
                    if (sortColumn.Equals("DealersID"))
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

        public ActionResult NoCatelog()
        {
            ViewData["PageTitle"] = "No Catelog List";
            return View();
        }
        [HttpPost]
        public ActionResult GetNoCatelog()
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
                var obj = (from t1 in dc.DealersModels.Where(x => x.Cataloge.Equals(null) || x.Cataloge.Equals("")) // Dealer Model
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
                    if (sortColumn.Equals("DealersID"))
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
        public ActionResult NoLogo()
        {
            ViewData["PageTitle"] = "No Catelog List";
            return View();
        }
        [HttpPost]
        public ActionResult GetNoLogo()
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
                var obj = (from t1 in dc.DealersModels.Where(x => x.Logo.Equals(null) || x.Cataloge.Equals("No.png")) // Dealer Model
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
                    if (sortColumn.Equals("DealersID"))
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
    }
}