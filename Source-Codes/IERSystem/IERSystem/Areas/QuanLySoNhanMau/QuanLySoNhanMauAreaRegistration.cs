using System.Web.Mvc;

namespace IERSystem.Areas.QuanLySoNhanMau
{
    public class QuanLySoNhanMauAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "QuanLySoNhanMau";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "QuanLySoNhanMau_default",
                "QuanLySoNhanMau/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}