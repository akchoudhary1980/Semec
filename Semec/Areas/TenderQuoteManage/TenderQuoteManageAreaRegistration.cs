using System.Web.Mvc;

namespace Semec.Areas.TenderQuoteManage
{
    public class TenderQuoteManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TenderQuoteManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(                
                "TenderQuoteManage_default",
                "TenderQuoteManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "Semec.Areas.TenderQuoteManage.Controllers" }
            );
        }
    }
}