using System.Web.Mvc;

namespace Semec.Areas.InvoiceManage
{
    public class InvoiceManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "InvoiceManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "InvoiceManage_default",
                "InvoiceManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}