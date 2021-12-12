using System.Web.Mvc;

namespace Semec.Areas.TenderLinkManage
{
    public class TenderLinkManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TenderLinkManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TenderLinkManage_default",
                "TenderLinkManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}