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

        // POST: QuanLyKetQuaPhanTich/API/EditSoKQ
        [HttpPost]
        public JsonResult GetNewContracts()
        {
            var expire_date = DateTime.Today.AddDays(-3);
            try
            {
                var result = (from mlth in db.MauLayHienTruongs
                              join skqtn in db.SoKQThuNghiems on mlth.SoKQThuNghiem.Id equals skqtn.Id
                              select new { MaMau = mlth.MaMau, SoKQThuNghiem = skqtn }).ToList()
                             .Select((rowitem) => new SoKQThuNghiemOutputModel()
                             {
                                 MaMau = rowitem.MaMau,
                                 //SoLuong = rowitem.SoKQThuNghiem.KQThuNghiemMaus.Count(),
                                 SoLuongKetQua = db.KQThuNghiemMaus.Where((kqtn) => kqtn.KetQua != "" && kqtn.SoKQThuNghiem.MauLayHienTruong.MaMau == rowitem.MaMau).Count()
                                 //rowitem.SoKQThuNghiem.KQThuNghiemMaus.Select((kqrow) => 
                                 //new KQOutputModel(){
                                 //    SoLuong = kqrow.KetQua.Count()
                                 //})
                             }).ToList();
                
                return Json(new GetDBResponse<IEnumerable<SoKQThuNghiemOutputModel>>() { IsOK = true, Data = result });
            }
            catch (InvalidOperationException e)
            {
                return Json(new GetDBResponse<SoKQThuNghiemOutputModel>() { IsOK = false, Data = null });
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