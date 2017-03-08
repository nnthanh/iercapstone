using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLyKetQuaPhanTich.Models;
using IERSystem.BusinessLogic.TableForms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.QuanLyKetQuaPhanTich.Controllers
{
    public class APIController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // POST: QuanLyKetQuaPhanTich/API/AddKetQuaPT
        [HttpPost]
        public JsonResult AddKetQuaPT(SoKQThuNghiemInputModel sokq_inp)
        {
            try
            {
                SoKQThuNghiemAPIImpl.AddKetQuaPT(sokq_inp, db, DateTime.Now);
                return Json(new UpsertDBResponse { IsOK = true, ErrMsg = "" });
            }
            catch (Exception e)
            {
                return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
            }
        }

        // POST: QuanLyKetQuaPhanTich/API/EditSoKQ
        [HttpPost]
        public JsonResult EditSoKQ(KetQuaEditedInputModel edit_inp)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    SoKQThuNghiemAPIImpl.EditSoKQ(edit_inp, db);
                    db.SaveChanges();
                    return Json(new UpsertDBResponse { IsOK = true, ErrMsg = "" });
                }
                return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
            }
            catch
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