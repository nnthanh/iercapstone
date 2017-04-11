using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Controllers
{
    public class HomeController : Controller
    {
        //GET: Home/TrangChu
        public ActionResult TrangChu()
        {
            return View();
        }
    }
}