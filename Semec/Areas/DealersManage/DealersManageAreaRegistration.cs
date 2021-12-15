using System.Web.Mvc;

namespace Semec.Areas.DealersManage
{
    public class DealersManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "DealersManage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                //"DealersManage_default",
                //"DealersManage/{controller}/{action}/{id}",
                //new { action = "Index", id = UrlParameter.Optional }
                "DealersManage_default",
                "DealersManage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "Semec.Areas.DealersManage.Controllers" }

            );
        }
    }
}