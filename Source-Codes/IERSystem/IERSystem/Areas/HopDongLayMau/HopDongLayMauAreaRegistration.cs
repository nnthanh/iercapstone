using System.Web.Mvc;

namespace IERSystem.Areas.HopDongLayMau
{
    public class HopDongLayMauAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HopDongLayMau";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HopDongLayMau_default",
                "HopDongLayMau/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}