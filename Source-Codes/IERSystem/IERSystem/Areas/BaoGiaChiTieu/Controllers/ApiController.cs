using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.BaoGiaChiTieu.Models;
using IERSystem.BusinessLogic.TableForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.BaoGiaChiTieu.Controllers
{
    public class APIController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // POST: BaoGiaChiTieu/API/FindChiTieu/
        [HttpPost]
        public ActionResult FindChiTieu(ChiTieuPTInputModel chitieupt_inp)
        {
            if (ModelState.IsValid)
            {
                var result =
                    ChiTieuPhanTichAPIImpl.GetChiTieusByNhomCT(chitieupt_inp, db);
                return Json(result);
            }
            else
            {
                return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
            }
        }

        // POST: BaoGiaChiTieu/API/GetNhomChiTieu/
        [HttpPost]
        public ActionResult GetNhomChiTieu()
        {
            if (ModelState.IsValid)
            {
                var result =
                    ChiTieuPhanTichAPIImpl.GetNhomCT(db);
                return Json(result);
            }
            else
            {
                return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
            }
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