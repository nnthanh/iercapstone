using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IERSystem.Areas.Administrator.Models;

namespace IERSystem.Areas.Administrator.Controllers
{
    public class QuanLyKhachHangController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: /Administrator/QuanLyKhachHang/
        public async Task<ActionResult> Index()
        {
            return View(await db.KhachHangs.ToListAsync());
        }

        // GET: /Administrator/QuanLyKhachHang/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachhang = await db.KhachHangs.FindAsync(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // GET: /Administrator/QuanLyKhachHang/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Administrator/QuanLyKhachHang/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,TenKhachHang,DiaChiKhachHang,TenDaiDien,SoDienThoai,SoFax")] KhachHang khachhang)
        {
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachhang);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(khachhang);
        }

        // GET: /Administrator/QuanLyKhachHang/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachhang = await db.KhachHangs.FindAsync(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // POST: /Administrator/QuanLyKhachHang/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,TenKhachHang,DiaChiKhachHang,TenDaiDien,SoDienThoai,SoFax")] KhachHang khachhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachhang).State = (System.Data.Entity.EntityState)System.Data.EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(khachhang);
        }

        // GET: /Administrator/QuanLyKhachHang/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachhang = await db.KhachHangs.FindAsync(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // POST: /Administrator/QuanLyKhachHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            KhachHang khachhang = await db.KhachHangs.FindAsync(id);
            db.KhachHangs.Remove(khachhang);
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
