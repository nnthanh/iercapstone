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
    public class CacSoChuyenMauController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: /Administrator/CacSoChuyenMau/
        public async Task<ActionResult> Index()
        {
            return View(await db.CacSoChuyenMaus.ToListAsync());
        }

        // GET: /Administrator/CacSoChuyenMau/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CacSoChuyenMau cacsochuyenmau = await db.CacSoChuyenMaus.FindAsync(id);
            if (cacsochuyenmau == null)
            {
                return HttpNotFound();
            }
            return View(cacsochuyenmau);
        }

        // GET: /Administrator/CacSoChuyenMau/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Administrator/CacSoChuyenMau/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Year")] CacSoChuyenMau cacsochuyenmau)
        {
            if (ModelState.IsValid)
            {
                cacsochuyenmau.CreatedBy = db.Users.Find((int)Session["loggedID"]);
                cacsochuyenmau.CreatedDate = DateTime.Now;
                db.CacSoChuyenMaus.Add(cacsochuyenmau);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cacsochuyenmau);
        }

        // GET: /Administrator/CacSoChuyenMau/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CacSoChuyenMau cacsochuyenmau = await db.CacSoChuyenMaus.FindAsync(id);
            if (cacsochuyenmau == null)
            {
                return HttpNotFound();
            }
            return View(cacsochuyenmau);
        }

        // POST: /Administrator/CacSoChuyenMau/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Year")] CacSoChuyenMau cacsochuyenmau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cacsochuyenmau).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cacsochuyenmau);
        }

        // GET: /Administrator/CacSoChuyenMau/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CacSoChuyenMau cacsochuyenmau = await db.CacSoChuyenMaus.FindAsync(id);
            if (cacsochuyenmau == null)
            {
                return HttpNotFound();
            }
            return View(cacsochuyenmau);
        }

        // POST: /Administrator/CacSoChuyenMau/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CacSoChuyenMau cacsochuyenmau = await db.CacSoChuyenMaus.FindAsync(id);
            db.CacSoChuyenMaus.Remove(cacsochuyenmau);
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
