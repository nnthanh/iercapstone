using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.HopDongLayMau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.HopDongLayMau.Controllers
{
    public class APIController : Controller
    {
        private IERSystemDBContext db = new IERSystemDBContext();

        // GET: HopDongLayMau/API
        public ActionResult Index()
        {
            return View();
        }

        // POST: /HopDongLayMau/API/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<JsonResult> Create(YeuCauLayMauInputModel input_request) {
            bool isOk = false;
            string errMsg = "";
            if (ModelState.IsValid) {
                var encoded_inp_req = ItemEncoding.HopDongLayMauEncoding.MaHoa(input_request, db);
                db.PhieuYeuCaus.Add(encoded_inp_req.ToModel(db));
                try {
                    await db.SaveChangesAsync();
                    Console.WriteLine("OK");
                    isOk = true;
                } catch (System.Data.Entity.Infrastructure.DbUpdateException e) {
                    Console.WriteLine(e.Message);
                    isOk = false;
                }
            }

            return Json(new { isOk, errMsg });
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}