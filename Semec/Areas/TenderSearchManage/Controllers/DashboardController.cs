using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semec.Areas.TenderSearchManage.Controllers
{
    public class DashboardController : Controller
    {
        // GET: TenderSearchManage/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}