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
    public class MauLayHienTruongController : Controller
    {
        private IERSystemDBContext db = new IERSystemDBContext();

        // GET: /Administrator/MauLayHienTruong/
        public async Task<ActionResult> Index()
        {
            return View(await db.MauLayHienTruong.ToListAsync());
        }

        // GET: /Administrator/MauLayHienTruong/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauLayHienTruong maulayhientruong = await db.MauLayHienTruong.FindAsync(id);
            if (maulayhientruong == null)
            {
                return HttpNotFound();
            }
            return View(maulayhientruong);
        }

        // GET: /Administrator/MauLayHienTruong/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Administrator/MauLayHienTruong/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(
          [Bind(Include="Id,MaMau,ViTriLayMau,DonVi,MoTaMau,NgayNhanMau,NgayTraMau,MaHDPhanTich,MaChiTieuPhanTich")]
          MauLayHienTruong maulayhientruong
          )
        {
            if (ModelState.IsValid)
            {
                db.MauLayHienTruong.Add(maulayhientruong);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(maulayhientruong);
        }

        // GET: /Administrator/MauLayHienTruong/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauLayHienTruong maulayhientruong = await db.MauLayHienTruong.FindAsync(id);
            if (maulayhientruong == null)
            {
                return HttpNotFound();
            }
            return View(maulayhientruong);
        }

        // POST: /Administrator/MauLayHienTruong/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,MaMau,ViTriLayMau,DonVi,MoTaMau,NgayNhanMau,NgayTraMau,MaHDPhanTich,MaChiTieuPhanTich")] MauLayHienTruong maulayhientruong)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maulayhientruong).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(maulayhientruong);
        }

        // GET: /Administrator/MauLayHienTruong/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MauLayHienTruong maulayhientruong = await db.MauLayHienTruong.FindAsync(id);
            if (maulayhientruong == null)
            {
                return HttpNotFound();
            }
            return View(maulayhientruong);
        }

        // POST: /Administrator/MauLayHienTruong/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            MauLayHienTruong maulayhientruong = await db.MauLayHienTruong.FindAsync(id);
            db.MauLayHienTruong.Remove(maulayhientruong);
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
