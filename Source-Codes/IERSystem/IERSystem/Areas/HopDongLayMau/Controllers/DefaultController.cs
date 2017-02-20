using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.HopDongLayMau.Controllers
{
    public class DefaultController : Controller
    {
        // GET: HopDongLayMau/Default
        public ActionResult Index()
        {
            return View("Hello world");
        }
    }
}