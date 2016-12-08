using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.Administrator.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Administrator/Account/
        // 
        // GET: /Account/Login 
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        
	}
}