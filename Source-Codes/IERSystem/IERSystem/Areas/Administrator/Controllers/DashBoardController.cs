using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IERSystem.Areas.Administrator.Models;

namespace IERSystem.Areas.Administrator.Controllers
{
    public class DashBoardController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: /Administrator/DashBoard/
        public async Task<ActionResult> Index()
        {
            var users = db.Users.Include(u => u.RoleMaster);
            return View(await users.ToListAsync());
        }

        public async Task<ActionResult> Homepage()
        {
            var users = db.Users.Include(u => u.RoleMaster);
            return View(await users.ToListAsync());
        }
        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
