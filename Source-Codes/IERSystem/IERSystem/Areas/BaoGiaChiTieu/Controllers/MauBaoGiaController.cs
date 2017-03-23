using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IERSystem.BusinessLogic;
using IERSystem.Areas.Administrator.Models;
using IERSystem.BusinessLogic.TableForms;

namespace IERSystem.Areas.BaoGiaChiTieu.Controllers
{
    public class MauBaoGiaController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: BaoGiaChiTieu/BaoGiaChiTieu/Upload
        public ActionResult Upload(FormCollection form_collection)
        {
            if (Request != null) {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                ChiTieuPhanTichAPIImpl.Create(file, db);
                db.SaveChanges();
            }
            return View("Upload");
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