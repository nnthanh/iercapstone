using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoChuyenMau.Models;
using IERSystem.BusinessLogic.TableForms;
using IERSystem.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
                    cacsonhanmau_inp.CreatedBy = db.Users.Find((long)Session["loggedId"]);
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
                    mauptadd_inp.CreatedBy = db.Users.Find((long)Session["loggedId"]);
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


        [HttpPost]
        public async Task<JsonResult> Return(ReturnItemInputModel return_item)
        {
            if (ModelState.IsValid)
            {
                //Get Mau to be returned
                var mau_tobereturned = (from mauht in db.MauLayHienTruongs
                                        where mauht.MaMau == return_item.MaMau
                                        select mauht).Single();

                var target = db.CacSoNhanMaus.First((model) => model.Id == mau_tobereturned.SoNhanMau.CacSoNhanMauId);
                var tinhtrang_chuyenmau = TinhTrangMauConverter.ToByte(TinhTrangMau.DaChuyen);
                //Check if its still at TinhTrang [3], if its TinhTrang > [3], dont let them return it

                if (mau_tobereturned.TinhTrang == tinhtrang_chuyenmau)
                {
                    try
                    {
                        mau_tobereturned.TinhTrang = TinhTrangMauConverter.ToByte(TinhTrangMau.DaNhan);
                        db.MauLayHienTruongs.Attach(mau_tobereturned);
                        db.Entry(mau_tobereturned).Property(x => x.TinhTrang).IsModified = true;

                        var target_scm = (from scm in db.SoChuyenMaus
                                          where scm.MauLayHienTruong.Id == mau_tobereturned.Id
                                          select scm).Single();

                        //await ReturnConfirmed(target_snm);
                        var target_skqtn = (from skqtn in db.SoKQThuNghiems
                                            where skqtn.MauLayHienTruong.Id == mau_tobereturned.Id
                                            select skqtn).Single();
                        try
                        {
                            db.KQThuNghiemMaus.RemoveRange(db.KQThuNghiemMaus.Where(kq => kq.SoKQThuNghiemId == target_skqtn.Id));
                            //db.KQThuNghiemMaus.Where(kq => kq.SoKQThuNghiemId == target_skqtn.Id).ToList().ForEach(db.KQThuNghiemMaus.DeleteObject());
                            db.SoKQThuNghiems.Remove(target_skqtn);
                            db.SoChuyenMaus.Remove(target_scm);
                            await db.SaveChangesAsync();

                            return Json(new GetDBResponse<Int64>()
                            {
                                IsOK = true,
                                Data = target_scm.CacSoChuyenMauId
                            });
                            //return Json(new UpsertDBResponse { IsOK = true, ErrMsg = "" });
                        }
                        catch
                        {
                            return Json(new GetDBResponse<Int64> { IsOK = false, Data = 0 });
                        }

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return Json(new GetDBResponse<Int64> { IsOK = false, Data = 0 });
                    }
                }
            }
            return Json(new GetDBResponse<Int64> { IsOK = false, Data = 0 });
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