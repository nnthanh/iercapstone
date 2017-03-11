using System.Web.Mvc;

namespace IERSystem.Areas.QuanLySoChuyenMau
{
    public class QuanLySoChuyenMauAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QuanLySoChuyenMau";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QuanLySoChuyenMau_default",
                "QuanLySoChuyenMau/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}