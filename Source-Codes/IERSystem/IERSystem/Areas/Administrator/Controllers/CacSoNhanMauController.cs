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
    public class CacSoNhanMauController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: /Administrator/CacSoNhanMau/
        public async Task<ActionResult> Index()
        {
            return View(await db.CacSoNhanMaus.ToListAsync());
        }

        // GET: /Administrator/CacSoNhanMau/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CacSoNhanMau cacsonhanmau = await db.CacSoNhanMaus.FindAsync(id);
            if (cacsonhanmau == null)
            {
                return HttpNotFound();
            }
            return View(cacsonhanmau);
        }

        // GET: /Administrator/CacSoNhanMau/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Administrator/CacSoNhanMau/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include="Id,Year,From,To")] CacSoNhanMau cacsonhanmau)
        {
            if (ModelState.IsValid)
            {
                db.CacSoNhanMaus.Add(cacsonhanmau);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cacsonhanmau);
        }

        // GET: /Administrator/CacSoNhanMau/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CacSoNhanMau cacsonhanmau = await db.CacSoNhanMaus.FindAsync(id);
            if (cacsonhanmau == null)
            {
                return HttpNotFound();
            }
            return View(cacsonhanmau);
        }

        // POST: /Administrator/CacSoNhanMau/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include="Id,Year,From,To")] CacSoNhanMau cacsonhanmau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cacsonhanmau).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cacsonhanmau);
        }

        // GET: /Administrator/CacSoNhanMau/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CacSoNhanMau cacsonhanmau = await db.CacSoNhanMaus.FindAsync(id);
            if (cacsonhanmau == null)
            {
                return HttpNotFound();
            }
            return View(cacsonhanmau);
        }

        // POST: /Administrator/CacSoNhanMau/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CacSoNhanMau cacsonhanmau = await db.CacSoNhanMaus.FindAsync(id);
            db.CacSoNhanMaus.Remove(cacsonhanmau);
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
