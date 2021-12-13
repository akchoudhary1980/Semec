using System.Web.Mvc;

namespace Semec.Areas.TenderSearchManage
{
    public class TenderSearchManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TenderSearchManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "TenderSearchManage_default",
                "TenderSearchManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}