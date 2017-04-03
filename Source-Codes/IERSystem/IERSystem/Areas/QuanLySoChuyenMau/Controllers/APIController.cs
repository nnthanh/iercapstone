﻿using IERSystem.Areas.Administrator.Models;
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
                    cacsonhanmau_inp.CreatedBy = db.Users.Find((int)Session["loggedId"]);
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