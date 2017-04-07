using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoChuyenMau.Models;
using IERSystem.BusinessLogic.TableForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.QuanLySoChuyenMau.Controllers
{
    public class APIController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // POST: /QuanLyCacSoChuyenMau/API/Create
        [HttpPost]
        public JsonResult Create(SoChuyenMauCreateInputModel cacsonhanmau_inp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CacSoChuyenMauAPIImpl.CreateModel(cacsonhanmau_inp, db);
                    db.SaveChanges();
                    Console.WriteLine("OK");
                    return Json(new UpsertDBResponse { IsOK = true, ErrMsg = "" });
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                {
                    Console.WriteLine(e.Message);
                    return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
                }
            }
            else
            {
                return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
            }
        }

        // POST: /QuanLyCacSoChuyenMau/API/GetMauPTCandids
        [HttpPost]
        public JsonResult GetMauPTCandids(MauPTToBeAddedInputModel maupttobeadded_inp)
        {
            if (ModelState.IsValid)
            {
                var result =
                    MauLayHienTruongAPIImpl.GetCandidMauPTSoChuyenMau(maupttobeadded_inp, DateTime.Now, db);
                return Json(new GetDBResponse<IEnumerable<MauPTToBeAddedOutputModel>>()
                {
                    IsOK = true,
                    Data = result
                });
            }
            else
            {
                return Json(new GetDBResponse<IEnumerable<MauPTToBeAddedOutputModel>> { IsOK = false, Data = null });
            }
        }

        // POST: /QuanLyCacSoChuyenMau/API/OpenSoChuyenMau
        [HttpPost]
        public JsonResult OpenSoChuyenMau(SoChuyenMauOpenInputModel sochuyenmauopen_inp)
        {
            try
            {
                var result = SoChuyenMauAPIImpl.FetchSoChuyenMau(sochuyenmauopen_inp.Id, db);
                return Json(new GetDBResponse<SoChuyenMauOpenOutputModel>()
                {
                    IsOK = true,
                    Data = result
                });
            }
            catch (InvalidOperationException e)
            {
                return Json(new GetDBResponse<SoChuyenMauOpenOutputModel>()
                {
                    IsOK = false,
                    Data = null
                });
            }
        }

        // POST: /QuanLyCacSoChuyenMau/API/ReceiveMauPTs
        [HttpPost]
        public JsonResult ReceiveMauPTs(MauPTAdderInputModel mauptadd_inp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    SoChuyenMauAPIImpl.AddMauPT(mauptadd_inp, db);
                    db.SaveChanges();
                    Console.WriteLine("OK");
                    return Json(new UpsertDBResponse { IsOK = true, ErrMsg = "" });
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateException e)
                {
                    Console.WriteLine(e.Message);
                    return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
                }
            }
            else
            {
                return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
            }
        }

        [HttpPost]
        public JsonResult GetNumberOfNewItems(MauPTToBeAddedInputModel maupttobeadded_inp)
        {
            if (ModelState.IsValid)
            {
                int result =
                    (MauLayHienTruongAPIImpl.GetCandidMauPTSoChuyenMau(maupttobeadded_inp, DateTime.Now, db)).Count();
                return Json(new GetDBResponse<int>()
                {
                    IsOK = true,
                    Data = result
                });
            }
            else
            {
                return Json(new GetDBResponse<IEnumerable<MauPTToBeAddedOutputModel>> { IsOK = false, Data = null });
            }
        }

        [HttpPost]
        public JsonResult GetNewItems(MauPTToBeAddedInputModel maupttobeadded_inp)
        {
            if (ModelState.IsValid)
            {
                var result =
                    MauLayHienTruongAPIImpl.GetCandidMauPTSoChuyenMau(maupttobeadded_inp, DateTime.Now, db);
                return Json(new GetDBResponse<IEnumerable<MauPTToBeAddedOutputModel>>()
                {
                    IsOK = true,
                    Data = result
                });
            }
            else
            {
                return Json(new GetDBResponse<IEnumerable<MauPTToBeAddedOutputModel>> { IsOK = false, Data = null });
            }
        }

        [HttpPost]
        public JsonResult GetNewItemsForOneBook(SoChuyenMauOpenInputModel sochuyenmauopen_inp)
        {
            var expire_date = DateTime.Today.AddDays(-3);
            if (ModelState.IsValid)
            {
                //var target_sonhanmau = db.CacSoNhanMaus.Single((snm) => snm.Id == id);
                var result = from scm in db.SoChuyenMaus
                             join cscm in db.CacSoChuyenMaus on scm.CacSoChuyenMauId equals cscm.Id
                             where scm.NgayGiaoMau > expire_date && cscm.Id == sochuyenmauopen_inp.Id
                             select scm.MauLayHienTruong.MaMau;

                return Json(new GetDBResponse<IEnumerable<string>>()
                {
                    IsOK = true,
                    Data = result
                });
            }
            else
            {
                return Json(new GetDBResponse<IEnumerable<MauPTToBeAddedOutputModel>> { IsOK = false, Data = null });
            }
        }

        [HttpPost]
        public JsonResult GetNumberOfNewItemsForOneBook(SoChuyenMauOpenInputModel sochuyenmauopen_inp)
        {
            var expire_date = DateTime.Today.AddDays(-3);
            if (ModelState.IsValid)
            {
                //var target_sonhanmau = db.CacSoNhanMaus.Single((snm) => snm.Id == id);
                int result = (from scm in db.SoChuyenMaus
                              join cscm in db.CacSoChuyenMaus on scm.CacSoChuyenMauId equals cscm.Id
                              where scm.NgayGiaoMau > expire_date && cscm.Id == sochuyenmauopen_inp.Id
                              select scm.MauLayHienTruong.MaMau).Count();

                return Json(new GetDBResponse<int>()
                {
                    IsOK = true,
                    Data = result
                });
            }
            else
            {
                return Json(new GetDBResponse<IEnumerable<MauPTToBeAddedOutputModel>> { IsOK = false, Data = null });
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