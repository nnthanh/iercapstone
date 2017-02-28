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
    public class SoNhanMauController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: /Administrator/SoNhanMau/
        public async Task<ActionResult> Index()
        {
            return View(await db.SoNhanMaus.ToListAsync());
        }

        // GET: /Administrator/SoNhanMau/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoNhanMau sonhanmau = await db.SoNhanMaus.FindAsync(id);
            if (sonhanmau == null)
            {
                return HttpNotFound();
            }
            return View(sonhanmau);
        }

        // GET: /Administrator/SoNhanMau/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Administrator/SoNhanMau/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,PhieuYeuCau,TenDiaChiKhachHang,MaSo,ChiTieuThuNghiem,NgayNhan,NgayTraKetQua,KyHieuMau,KHKyNhanTraTien,KHKyNhanTraKQ")] SoNhanMau sonhanmau)
        {
            if (ModelState.IsValid)
            {
                db.SoNhanMaus.Add(sonhanmau);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sonhanmau);
        }

        // GET: /Administrator/SoNhanMau/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoNhanMau sonhanmau = await db.SoNhanMaus.FindAsync(id);
            if (sonhanmau == null)
            {
                return HttpNotFound();
            }
            return View(sonhanmau);
        }

        // POST: /Administrator/SoNhanMau/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,PhieuYeuCau,TenDiaChiKhachHang,MaSo,ChiTieuThuNghiem,NgayNhan,NgayTraKetQua,KyHieuMau,KHKyNhanTraTien,KHKyNhanTraKQ")] SoNhanMau sonhanmau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sonhanmau).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sonhanmau);
        }

        // GET: /Administrator/SoNhanMau/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoNhanMau sonhanmau = await db.SoNhanMaus.FindAsync(id);
            if (sonhanmau == null)
            {
                return HttpNotFound();
            }
            return View(sonhanmau);
        }

        // POST: /Administrator/SoNhanMau/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SoNhanMau sonhanmau = await db.SoNhanMaus.FindAsync(id);
            db.SoNhanMaus.Remove(sonhanmau);
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
