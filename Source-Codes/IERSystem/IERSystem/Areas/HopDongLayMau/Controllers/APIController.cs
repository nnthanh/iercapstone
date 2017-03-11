using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.HopDongLayMau.Models;
using IERSystem.BusinessLogic.TableForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.HopDongLayMau.Controllers
{
    public class APIController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        private static readonly object _api_create_lock = new object();

        // POST: /HopDongLayMau/API/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(YeuCauLayMauInputModel input_request) {
            //if (ModelState.IsValid) {
                try {
                    lock (_api_create_lock) {
                        HopDongLayMauAPIImpl.CreateModel(input_request, db);
                        db.SaveChanges();
                    }
                    Console.WriteLine("OK");
                    return Json(new UpsertDBResponse { IsOK = true, ErrMsg = "" });
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
                }
            //} else {
            //    return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" }); 
            //}
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}