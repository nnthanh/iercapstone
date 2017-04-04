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
        public JsonResult GetCustomer()
        {
            ///if (ModelState.IsValid)
            //{
                var result =
                    db.KhachHangs.Select((kh) => kh.TenKhachHang + "/" + kh.DiaChiKhachHang);
                return Json(new GetDBResponse<IEnumerable<string>>() { IsOK = true, Data = result });
            //}
            //else
            //{
            //    return Json(new UpsertDBResponse { IsOK = false, ErrMsg = "" });
            //}
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
        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}