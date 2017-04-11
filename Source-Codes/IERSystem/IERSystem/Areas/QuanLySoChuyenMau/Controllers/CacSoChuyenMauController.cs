using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoChuyenMau.Models;
using IERSystem.BusinessLogic.TableForms;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IERSystem.Areas.QuanLySoChuyenMau.Controllers
{
    public class CacSoChuyenMauController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: QuanLySoChuyenMau/CacSoChuyenMau
        public async Task<ActionResult> Index()
        {
            return View(await CacSoChuyenMauAPIImpl.CreateView(db));
        }

        // POST: /QuanLyCacSoChuyenMau/CacSoChuyenMau/Create
        public ActionResult Create([Bind(Include = "Name,TuThang,DenThang")]SoChuyenMauCreateInputModel cacsochuyenmau_inp)
        {
            if (ModelState.IsValid)
            {
                var today = DateTime.Now;
                cacsochuyenmau_inp.CreatedBy = db.Users.Find((int)Session["loggedID"]);
                cacsochuyenmau_inp.CreatedDate = DateTime.Now;
                cacsochuyenmau_inp.Nam = today.Year;
                cacsochuyenmau_inp.TuThang = today.Month;
                cacsochuyenmau_inp.DenThang = today.Month;
            }
            return View(cacsochuyenmau_inp);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,MaKhachHang,MaMau,ChiTieuThuNghiem,NguoiGiaoMau,NguoiNhanMau,NgayGiaoMau,NgayTraKetQua,DienTien,GhiChu")] SoChuyenMau sochuyenmau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sochuyenmau).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sochuyenmau);
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