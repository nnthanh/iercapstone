using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.BaoGiaChiTieu.Controllers
{
    public class APIController : Controller
    {


        // GET: BaoGiaChiTieu/API/Details/loaimau
        public async Task<ActionResult> Details(string loaimau)
        {
            if (loaimau == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            
            
            return View();
        }
    }
}