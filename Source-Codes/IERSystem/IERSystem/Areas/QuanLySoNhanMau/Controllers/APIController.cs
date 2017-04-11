using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoNhanMau.Models;
using IERSystem.BusinessLogic.TableForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.QuanLySoNhanMau.Controllers
{
    public class APIController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // POST: /QuanLyCacSoNhanMau/API/Create
        [HttpPost]
        public JsonResult Create(SoNhanMauCreateInputModel cacsonhanmau_inp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    cacsonhanmau_inp.CreatedBy = db.Users.Find((int)Session["loggedId"]);
                    CacSoNhanMauAPIImpl.CreateModel(cacsonhanmau_inp, db);
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

        // POST: /QuanLyCacSoNhanMau/API/OpenSoNhanMau
        [HttpPost]
        public JsonResult OpenSoNhanMau(SoNhanMauOpenInputModel sonhanmauopen_inp)
        {
            try
            {
                var result = SoNhanMauAPIImpl.FetchSoNhanMau(sonhanmauopen_inp.Id, db);
                return Json(new GetDBResponse<SoNhanMauOpenOutputModel>() {
                    IsOK = true,
                    Data = result
                });
            }
            catch (InvalidOperationException e)
            {
                return Json(new GetDBResponse<SoNhanMauOpenOutputModel>()
                {
                    IsOK = false,
                    Data = null
                });
            }
        }

        //TODO: nthoang: SoNhanMau Delete not supported yet
        // POST: /QuanLyCacSoNhanMau/API/Delete
        //[HttpPost]
        //public JsonResult Delete(SoNhanMauInputModel cacsonhanmau_inp)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            CacSoNhanMauAPIImpl.CreateModel(cacsonhanmau_inp, db);
        //            db.SaveChanges();
        //            Console.WriteLine("OK");
        //            return Json(new UpsertDBResponse { IsOK = true, ErrMsg = "" });
        //        }
        //        catch (System.Data.Entity.Infrastructure.DbUpdateException e)
        //        {
        //            Console.WriteLine(e.Message);
        //            return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
        //        }
        //    }
        //    else
        //    {
        //        return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
        //    }
        //}

        // POST: /QuanLyCacSoNhanMau/API/GetMauPTCandids
        [HttpPost]
        public JsonResult GetMauPTCandids(MauPTToBeAddedInputModel maupttobeadded_inp)
        {
            if (ModelState.IsValid)
            {
                var result = 
                    MauLayHienTruongAPIImpl.GetCandidMauPTSoNhanMau(maupttobeadded_inp, DateTime.Now, db);
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

        // POST: /QuanLyCacSoNhanMau/API/ReceiveMauPTs
        [HttpPost]
        public JsonResult ReceiveMauPTs(MauPTAdderInputModel mauptadd_inp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    mauptadd_inp.CreateBy = db.Users.Find((int)Session["loggedId"]);
                    SoNhanMauAPIImpl.AddMauPT(mauptadd_inp, db);
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
                    (MauLayHienTruongAPIImpl.GetCandidMauPTSoNhanMau(maupttobeadded_inp, DateTime.Now, db)).Count();
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
                    MauLayHienTruongAPIImpl.GetCandidMauPTSoNhanMau(maupttobeadded_inp, DateTime.Now, db);
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
        public JsonResult GetNewItemsForOneBook(SoNhanMauOpenInputModel sonhanmauopen_inp)
        {
            var expire_date = DateTime.Today.AddDays(-3);
            if (ModelState.IsValid)
            {
                //var target_sonhanmau = db.CacSoNhanMaus.Single((snm) => snm.Id == id);
                var result = from snm in db.SoNhanMaus
                             join csnm in db.CacSoNhanMaus on snm.CacSoNhanMauId equals csnm.Id
                             where snm.NgayNhanMau > expire_date && csnm.Id == sonhanmauopen_inp.Id
                             select snm.MauLayHienTruong.PhieuYeuCau.MaDon;                     

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
        public JsonResult GetNumberOfNewItemsForOneBook(SoNhanMauOpenInputModel sonhanmauopen_inp)
        {
            var expire_date = DateTime.Today.AddDays(-3);
            if (ModelState.IsValid)
            {
                //var target_sonhanmau = db.CacSoNhanMaus.Single((snm) => snm.Id == id);
                int result = (from snm in db.SoNhanMaus
                             join csnm in db.CacSoNhanMaus on snm.CacSoNhanMauId equals csnm.Id
                             where snm.NgayNhanMau > expire_date && csnm.Id == sonhanmauopen_inp.Id
                             select snm.MauLayHienTruong.PhieuYeuCau.MaDon).Count();

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