using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IERSystem.BusinessLogic;
using IERSystem.Areas.Administrator.Models;

namespace IERSystem.Areas.BaoGiaChiTieu.Controllers
{
    public class MauBaoGiaController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: BaoGiaChiTieu/MauBaoGia/Upload
        //nthoang: TODO: WIP
        public ActionResult Upload(FormCollection form_collection)
        {
            if (Request != null) {
                HttpPostedFileBase file = Request.Files["UploadedFile"];
                var data = BaoGiaChiTieuSheetParser.ParseUploadSheetData(file);
                Console.WriteLine(data);
                
            }
            return View("Index");
        }
    }
}