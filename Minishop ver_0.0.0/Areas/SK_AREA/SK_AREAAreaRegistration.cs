using System.Web.Mvc;

namespace Minishop_ver_0._0._0.Areas.SK_AREA
{
    public class SK_AREAAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "SK_AREA";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "SK_AREA_default",
                "SK_AREA/{controller}/{action}/{id}",
                new {action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}