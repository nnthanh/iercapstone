using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoChuyenMau.Models;
using IERSystem.BusinessLogic.TableForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.QuanLySoChuyenMau.Controllers
{
    public class CacSoChuyenMauController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: QuanLySoChuyenMau/CacSoChuyenMau
        public async Task<ActionResult> Index()
        {
            return View(await CacSoChuyenMauAPIImpl.CreateView(db));
        }

        // POST: /QuanLyCacSoChuyenMau/CacSoChuyenMau/Create
        public ActionResult Create([Bind(Include = "Name,TuThang,DenThang")]SoChuyenMauInputModel cacsochuyenmau_inp)
        {
            if (ModelState.IsValid)
            {
                var today = DateTime.Now;
                cacsochuyenmau_inp.CreatedBy = db.Users.Find((int)Session["loggedID"]);
                cacsochuyenmau_inp.CreatedDate = DateTime.Now;
                cacsochuyenmau_inp.Nam = today.Year;
                cacsochuyenmau_inp.TuThang = today.Month;
                cacsochuyenmau_inp.DenThang = today.Month;
            }
            return View(cacsochuyenmau_inp);
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