using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoNhanMau.Models;
using IERSystem.BusinessLogic.TableForms;
using IERSystem.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
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
                    cacsonhanmau_inp.CreatedBy = db.Users.Find((long)Session["loggedId"]);
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

        // GET: /QuanLyCacSoNhanMau/API/OpenSoNhanMau/1
        [HttpGet]
        public JsonResult OpenSoNhanMau(long? id)
        {
            try
            {
                if (id.HasValue)
                {
                    var result = SoNhanMauAPIImpl.FetchSoNhanMau(id.Value, db);
                    return Json(new GetDBResponse<SoNhanMauOpenOutputModel>()
                    {
                        IsOK = true,
                        Data = result
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new GetDBResponse<SoNhanMauOpenOutputModel>()
                    {
                        IsOK = false,
                        Data = null
                    }, JsonRequestBehavior.AllowGet);
                }

            }
            catch (InvalidOperationException e)
            {
                return Json(new GetDBResponse<SoNhanMauOpenOutputModel>()
                {
                    IsOK = false,
                    Data = null
                }, JsonRequestBehavior.AllowGet);
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
                    mauptadd_inp.CreateBy = db.Users.Find((long)Session["loggedId"]);
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
                var result = (from snm in db.SoNhanMaus
                             join csnm in db.CacSoNhanMaus on snm.CacSoNhanMauId equals csnm.Id
                             where snm.NgayNhanMau > expire_date && csnm.Id == sonhanmauopen_inp.Id
                             select snm.MauLayHienTruong.PhieuYeuCau.MaDon);                     

                return Json(new GetDBResponse<IEnumerable<string>>()
                {
                    IsOK = true,
                    Data = result
                });
                
            }
            else
            {
                return Json(new GetDBResponse<IEnumerable<NewItemsOutputModel>> { IsOK = false, Data = null });
            }
        }

        [HttpPost]
        public JsonResult RefreshBoxes(SoNhanMauOpenInputModel sonhanmauopen_inp)
        {
            if (ModelState.IsValid)
            {
                var result = new List<NewItemsOutputModel>(db.SoNhanMaus.Where(x => x.CacSoNhanMauId == sonhanmauopen_inp.Id)
                    .Select(y => new NewItemsOutputModel()
                    {
                        MaDon = y.MauLayHienTruong.PhieuYeuCau.MaDon,
                        KHKyTraTien = y.KHKiNhanTraTien,
                        KHKyTraKQ = y.KHKiNhanTraKQ
                    }));

                return Json(new GetDBResponse<IEnumerable<NewItemsOutputModel>>()
                {
                    IsOK = true,
                    Data = result
                });

            }
            else
            {
                return Json(new GetDBResponse<IEnumerable<NewItemsOutputModel>> { IsOK = false, Data = null });
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
                var tinhtrang_nhanmau = TinhTrangMauConverter.ToByte(TinhTrangMau.DaNhan);
                //Check if its still at TinhTrang [2], if its TinhTrang > [2], dont let them return it
                
                if (mau_tobereturned.TinhTrang == tinhtrang_nhanmau)
                {
                    try
                    {
                        mau_tobereturned.TinhTrang = TinhTrangMauConverter.ToByte(TinhTrangMau.KhoiTao);
                        db.MauLayHienTruongs.Attach(mau_tobereturned);
                        db.Entry(mau_tobereturned).Property(x => x.TinhTrang).IsModified = true;

                        var target_snm = (from snm in db.SoNhanMaus
                                          where snm.MauLayHienTruong.Id == mau_tobereturned.Id
                                          select snm).Single();

                        //await ReturnConfirmed(target_snm);

                        try
                        {
                            db.SoNhanMaus.Remove(target_snm);
                            await db.SaveChangesAsync();
                            return Json(new GetDBResponse<Int64>()
                            {
                                IsOK = true,
                                Data = target_snm.CacSoNhanMauId
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

        [HttpPost]
        public async Task<JsonResult> AddSignature(AddSignatureInputModel input_req)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String[] tokens;
                    long cacsonhanmau_id = 0;
                    string madon;
                    bool chk_kq, chk_tien;
                    for (int i = 0; i < input_req.Attribute.Length; ++i )
                    {
                        tokens = input_req.Attribute[i].Split(',');
                        madon = tokens[0];
                        chk_tien = Convert.ToBoolean(tokens[1]);
                        chk_kq = Convert.ToBoolean(tokens[2]);

                        var result = (from snm in db.SoNhanMaus
                                      where snm.MauLayHienTruong.PhieuYeuCau.MaDon == madon
                                      select snm).FirstOrDefault();       

                        result.KHKiNhanTraTien = chk_tien;
                        result.KHKiNhanTraKQ = chk_kq;

                        if (i == input_req.Attribute.Length-1)
                        {
                            cacsonhanmau_id = result.CacSoNhanMauId;
                        }
                        
                    }

                    await db.SaveChangesAsync();
                    Console.WriteLine("OK");
                    return Json(new GetDBResponse<Int64> { IsOK = true, Data = cacsonhanmau_id });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return Json(new GetDBResponse<Int64> { IsOK = false, Data = 0 });
                }
            }
            else
            {
                return Json(new GetDBResponse<Int64> { IsOK = false, Data = 0 });
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