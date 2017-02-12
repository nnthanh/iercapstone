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
    public class FormKQController : Controller
    {
        private IERSystemDBContext db = new IERSystemDBContext();

        // GET: /Administrator/FormKQ/
        public async Task<ActionResult> Index()
        {
            return View(await db.FormKQs.ToListAsync());
        }

        // GET: /Administrator/FormKQ/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormKQ formkq = await db.FormKQs.FindAsync(id);
            if (formkq == null)
            {
                return HttpNotFound();
            }
            return View(formkq);
        }

        // GET: /Administrator/FormKQ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Administrator/FormKQ/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,So,KyHieuMau,NoiLayMau,NgayGuiMau,DiaChi,LoaiMau,ViTriLayMau,STT,ChiTieu,DonVi,GiaTri,PhuongPhapPhanTich")] FormKQ formkq)
        {
            if (ModelState.IsValid)
            {
                db.FormKQs.Add(formkq);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(formkq);
        }

        // GET: /Administrator/FormKQ/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormKQ formkq = await db.FormKQs.FindAsync(id);
            if (formkq == null)
            {
                return HttpNotFound();
            }
            return View(formkq);
        }

        // POST: /Administrator/FormKQ/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,So,KyHieuMau,NoiLayMau,NgayGuiMau,DiaChi,LoaiMau,ViTriLayMau,STT,ChiTieu,DonVi,GiaTri,PhuongPhapPhanTich")] FormKQ formkq)
        {
            if (ModelState.IsValid)
            {
                db.Entry(formkq).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(formkq);
        }

        // GET: /Administrator/FormKQ/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormKQ formkq = await db.FormKQs.FindAsync(id);
            if (formkq == null)
            {
                return HttpNotFound();
            }
            return View(formkq);
        }

        // POST: /Administrator/FormKQ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FormKQ formkq = await db.FormKQs.FindAsync(id);
            db.FormKQs.Remove(formkq);
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
