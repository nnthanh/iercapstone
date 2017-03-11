using System.Web.Mvc;

namespace IERSystem.Areas.QuanLyKetQuaPhanTich
{
    public class QuanLyKetQuaPhanTichAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QuanLyKetQuaPhanTich";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QuanLyKetQuaPhanTich_default",
                "QuanLyKetQuaPhanTich/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}