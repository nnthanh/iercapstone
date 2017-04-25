using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.HopDongLayMau.Models;
using IERSystem.BusinessLogic.TableForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.HopDongLayMau.Controllers
{
    public class APIController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        private static readonly object _api_create_lock = new object();

        // POST: /HopDongLayMau/API/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(YeuCauLayMauInputModel input_request) {
            //if (ModelState.IsValid) {
                try {
                    lock (_api_create_lock) {
                        input_request.CreatedBy = db.Users.Find((long)Session["loggedID"]);
                        HopDongLayMauAPIImpl.CreateModel(input_request, db);
                        db.SaveChanges();
                    }
                    Console.WriteLine("OK");
                    return Json(new UpsertDBResponse { IsOK = true, ErrMsg = "" });
                } catch (Exception e) {
                    Console.WriteLine(e.Message);
                    return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
                }
            //} else {
            //    return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" }); 
            //}
        }
        [HttpPost]
        public JsonResult GetCustomer()
        {
                var result =
                    db.KhachHangs.Select((kh) => kh.TenKhachHang + "/" + kh.DiaChiKhachHang);
                return Json(new GetDBResponse<IEnumerable<string>>() { IsOK = true, Data = result });
        }
        
        [HttpPost]
        public JsonResult GetCustomerInfo(GetCustomerInfoInputModel customer_inpmodel)
        {
            try {
                var result = db.KhachHangs.Where((kh) => kh.TenKhachHang.Equals(customer_inpmodel.CustomerName)
                    && kh.DiaChiKhachHang.Equals(customer_inpmodel.CustomerAddress)).Single();
                return Json(new GetDBResponse<KhachHang>() { IsOK = true, Data = result });
            } catch (InvalidOperationException e) {
                //Throw if name is not unique (Should not be expected)
                Debug.Assert(false);
                return Json(new GetDBResponse<KhachHang>() { IsOK = false, Data = null });
            }
        }

        [HttpPost]
        public JsonResult GetNumberOfNewContracts()
        {
            var expire_date = DateTime.Today.AddDays(-3);
            try
            {
                int count = (from pyc in db.PhieuYeuCaus
                             where pyc.NgayTaoHD > expire_date
                             select pyc).Count();
                return Json(new GetDBResponse<int>() { IsOK = true, Data = count });
            }
            catch (InvalidOperationException e)
            {
                Debug.Assert(false);
                return Json(new GetDBResponse<KhachHang>() { IsOK = false, Data = null });
            }    
        }

        [HttpPost]
        public JsonResult GetNewContracts()
        {
            var expire_date = DateTime.Today.AddDays(-3);
            try
            {
                var result = from pyc in db.PhieuYeuCaus
                             where pyc.NgayTaoHD > expire_date
                             select pyc.MaDon;
                return Json(new GetDBResponse<IEnumerable<string>>() { IsOK = true, Data = result });
            }
            catch (InvalidOperationException e)
            {
                Debug.Assert(false);
                return Json(new GetDBResponse<KhachHang>() { IsOK = false, Data = null });
            }

            
        }

        [HttpPost]
        public JsonResult RefreshTable()
        {     
            try 
            {
                try 
                {

                    var temp = (from p in db.PhieuYeuCaus
                                select p).ToList();

                    DateTime[] date_create = new DateTime[temp.Count()];
                    DateTime[] date_return = new DateTime[temp.Count()];

                    for(int i=0; i<temp.Count(); ++i)
                    {
                        date_create[i] = temp[i].NgayTaoHD;
                        date_return[i] = temp[i].NgayHenTraKQ;
                    }

                    var result = new List<RefreshOutputModel>(db.PhieuYeuCaus.Select(pyc =>
                    new RefreshOutputModel()
                    {
                        Id = pyc.Id,
                        MaDon = pyc.MaDon,
                        TenKhachHang = pyc.TenKhachHang,
                        TenDaiDien = pyc.TenDaiDien,
                        DiaChiLayMau = pyc.DiaChiLayMau,
                        DiaChiKH = pyc.DiaChiKhachHang,
                        MaSoThue = pyc.MaSoThue,
                        SDT = pyc.SoDienThoai,
                        SoFax = pyc.SoFax,
                        //NgayTaoHD = pyc.NgayTaoHD,
                        //NgayTraMau = pyc.NgayHenTraKQ,
                        DuocTaoBoi = pyc.CreatedBy.Fullname
                        //ChinhSuaLanCuoiBoi =pyc.,
                        //ChinhSuaLanCuoiLuc =pyc.ChinhSuaLanCuoiLuc                       
                    }
                    ));

                    for (int j = 0; j < result.Count(); ++j )
                    {
                        result[j].NgayTaoHD = date_create[j].ToShortDateString();
                        result[j].NgayTraMau = date_return[j].ToShortDateString();
                    }

                    return Json(new GetDBResponse<IEnumerable<RefreshOutputModel>>()
                    {
                        IsOK = true,
                        Data = result
                    });
                }
                catch (InvalidOperationException e)
                {
                    throw e;
                }

                
            }
            catch (InvalidOperationException e)
            {
                return Json(new GetDBResponse<IEnumerable<RefreshOutputModel>>()
                {
                    IsOK = false,
                    Data = null
                });
            }
                


        }
        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}