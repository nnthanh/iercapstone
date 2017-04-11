using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IERSystem.Areas.Administrator.Models;
using System.IO;
using Newtonsoft.Json;
using IERSystem.Areas.HopDongLayMau.Models;
using System.Data.Entity;

namespace IERSystem.Areas.HopDongLayMau.Controllers
{
  
    public class YeuCauLayMauController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: /HopDongLayMau/YeuCauLayMau/
        public async Task<ActionResult> Index()
        {
            return View(await db.PhieuYeuCaus.ToListAsync());
        }

        // GET: /HopDongLayMau/YeuCauLayMau/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuYeuCau request = await db.PhieuYeuCaus.FindAsync(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: /HopDongLayMau/YeuCauLayMau/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /HopDongLayMau/YeuCauLayMau/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
            //[Bind(
            //   Include="MaDon,TenKhachHang,TenDaiDien,DiaChiLayMau,MaSoThue,SoDienThoai,SoFax,NgayTaoHD,NgayDuKienTraMau, MauLayHienTruong"
            //)] 
            YeuCauLayMauInputModel inputRequest)
        {
            inputRequest.CreatedBy = db.Users.Find((int)Session["loggedID"]);
            return View(inputRequest);
        }


        // GET: /HopDongLayMau/YeuCauLayMau/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuYeuCau request = await db.PhieuYeuCaus.FindAsync(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: /HopDongLayMau/YeuCauLayMau/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,MaDon,TenKhachHang,TenDaiDien,DiaChiLayMau,DiaChiKhachHang,MaSoThue,SoDienThoai,SoFax,NgayTaoHD,NgayDuKienTraMau,PhuongPhapLayMau,TenTieuChuanDoiChieu,PhiThiNghiemTamTinh,TienKhachHangTraTruoc,DaGuiMau")] PhieuYeuCau request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = System.Data.Entity.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(request);
        }

        // GET: /HopDongLayMau/YeuCauLayMau/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuYeuCau request = await db.PhieuYeuCaus.FindAsync(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: /HopDongLayMau/YeuCauLayMau/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PhieuYeuCau request = await db.PhieuYeuCaus.FindAsync(id);
            db.PhieuYeuCaus.Remove(request);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public async Task<ActionResult> ExportToExcel(int? RequestID)
        {
            if (RequestID == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhieuYeuCau request = await db.PhieuYeuCaus.FindAsync(RequestID);
            ViewBag.RequestID = RequestID;
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }
        public ActionResult GeneratePDF(int? RequestID)
        {
            return new Rotativa.ActionAsPdf("ExportToExcel", new { RequestID = RequestID });
        }


        [ChildActionOnly]
        public ActionResult DanhSachMau(int? RequestID)
        {

            var query = from pro in db.MauLayHienTruongs
                        where pro.PhieuYeuCau.Id == RequestID
                        select pro ;
            return PartialView("_danhsachmau", query.ToList());
        }
    }
}
