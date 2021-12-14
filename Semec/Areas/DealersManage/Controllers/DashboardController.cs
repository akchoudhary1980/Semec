﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semec.Areas.DealersManage.Controllers
{
    public class DashboardController : Controller
    {
        public MyContext db = new MyContext();
        public ActionResult Index()
        {
            int item = db.ItemModels.Count();
            int dealer = db.DealersModels.Count();
            ViewData["ItemCount"] = item;
            ViewData["DealerCount"] = dealer;
            string Disp = "";
            ViewData["DisplayName"] = "";

            if (Request.Cookies["DisplayName"] != null)
            {
                Disp = Request.Cookies["DisplayName"].Value.ToString();
            }
            ViewData["DisplayName"] = Disp;

            return View();
        }
    }
}