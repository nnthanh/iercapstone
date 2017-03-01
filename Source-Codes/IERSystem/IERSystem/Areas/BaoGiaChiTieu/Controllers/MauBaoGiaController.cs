using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static IERSystem.BusinessLogic.BaoGiaChiTieuSheetParser;

namespace IERSystem.Areas.BaoGiaChiTieu.Controllers
{
    public class MauBaoGiaController : Controller
    {
        // GET: BaoGiaChiTieu/MauBaoGia/Upload
        public ActionResult Upload(FormCollection form_collection)
        {
            if (Request != null) {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                var data = ParseUploadSheetData(file);
                Console.WriteLine(data);
            }
            return View("Index");
        }
    }
}