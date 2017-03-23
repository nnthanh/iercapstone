using System.Web.Mvc;

namespace IERSystem.Areas.BaoGiaChiTieu
{
    public class BaoGiaChiTieuAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "BaoGiaChiTieu";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "BaoGiaChiTieu_default",
                "BaoGiaChiTieu/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}