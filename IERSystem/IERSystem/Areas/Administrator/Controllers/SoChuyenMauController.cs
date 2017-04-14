using System;
using System.Collections.Generic;
//using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IERSystem.Areas.Administrator.Models;

namespace IERSystem.Areas.Administrator.Controllers
{
    public class SoChuyenMauController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: /Administrator/SoChuyenMau/
        public async Task<ActionResult> Index()
        {
            return View(await db.SoChuyenMaus.ToListAsync());
        }

        // GET: /Administrator/SoChuyenMau/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoChuyenMau sochuyenmau = await db.SoChuyenMaus.FindAsync(id);
            if (sochuyenmau == null)
            {
                return HttpNotFound();
            }
            return View(sochuyenmau);
        }

        // GET: /Administrator/SoChuyenMau/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Administrator/SoChuyenMau/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,MaKhachHang,MaMau,ChiTieuThuNghiem,NguoiGiaoMau,NguoiNhanMau,NgayGiaoMau,NgayTraKetQua,DienTien,GhiChu")] SoChuyenMau sochuyenmau)
        {
            if (ModelState.IsValid)
            {
                sochuyenmau.CreatedBy = db.Users.Find((int)Session["loggedID"]);
                db.SoChuyenMaus.Add(sochuyenmau);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sochuyenmau);
        }

        // GET: /Administrator/SoChuyenMau/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoChuyenMau sochuyenmau = await db.SoChuyenMaus.FindAsync(id);
            if (sochuyenmau == null)
            {
                return HttpNotFound();
            }
            return View(sochuyenmau);
        }

        // POST: /Administrator/SoChuyenMau/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,MaKhachHang,MaMau,ChiTieuThuNghiem,NguoiGiaoMau,NguoiNhanMau,NgayGiaoMau,NgayTraKetQua,DienTien,GhiChu")] SoChuyenMau sochuyenmau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sochuyenmau).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sochuyenmau);
        }

        // GET: /Administrator/SoChuyenMau/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoChuyenMau sochuyenmau = await db.SoChuyenMaus.FindAsync(id);
            if (sochuyenmau == null)
            {
                return HttpNotFound();
            }
            return View(sochuyenmau);
        }

        // POST: /Administrator/SoChuyenMau/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SoChuyenMau sochuyenmau = await db.SoChuyenMaus.FindAsync(id);
            db.SoChuyenMaus.Remove(sochuyenmau);
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
    }
}
