using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Semec.Areas.TenderQuoteManage.Controllers
{
    public class DashboardController : Controller
    {
        // GET: TenderQuoteManage/Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}