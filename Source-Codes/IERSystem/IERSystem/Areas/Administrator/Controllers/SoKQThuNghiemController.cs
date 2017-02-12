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
    public class SoKQThuNghiemController : Controller
    {
        private IERSystemDBContext db = new IERSystemDBContext();

        // GET: /Administrator/SoKQThuNghiem/
        public async Task<ActionResult> Index()
        {
            return View(await db.SoKQThuNghiems.ToListAsync());
        }

        // GET: /Administrator/SoKQThuNghiem/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoKQThuNghiem sokqthunghiem = await db.SoKQThuNghiems.FindAsync(id);
            if (sokqthunghiem == null)
            {
                return HttpNotFound();
            }
            return View(sokqthunghiem);
        }

        // GET: /Administrator/SoKQThuNghiem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Administrator/SoKQThuNghiem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,KyHieuMau,NgayNhanMau,NgayTraMau,ChiTieuThuNghiem,DonVi,KetQua,NguoiThucHien")] SoKQThuNghiem sokqthunghiem)
        {
            if (ModelState.IsValid)
            {
                db.SoKQThuNghiems.Add(sokqthunghiem);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sokqthunghiem);
        }

        // GET: /Administrator/SoKQThuNghiem/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoKQThuNghiem sokqthunghiem = await db.SoKQThuNghiems.FindAsync(id);
            if (sokqthunghiem == null)
            {
                return HttpNotFound();
            }
            return View(sokqthunghiem);
        }

        // POST: /Administrator/SoKQThuNghiem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,KyHieuMau,NgayNhanMau,NgayTraMau,ChiTieuThuNghiem,DonVi,KetQua,NguoiThucHien")] SoKQThuNghiem sokqthunghiem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sokqthunghiem).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sokqthunghiem);
        }

        // GET: /Administrator/SoKQThuNghiem/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoKQThuNghiem sokqthunghiem = await db.SoKQThuNghiems.FindAsync(id);
            if (sokqthunghiem == null)
            {
                return HttpNotFound();
            }
            return View(sokqthunghiem);
        }

        // POST: /Administrator/SoKQThuNghiem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SoKQThuNghiem sokqthunghiem = await db.SoKQThuNghiems.FindAsync(id);
            db.SoKQThuNghiems.Remove(sokqthunghiem);
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
