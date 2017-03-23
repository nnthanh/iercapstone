using IERSystem.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IERSystem.Areas.QuanLyKetQuaPhanTich.Models;
using IERSystem.BusinessLogic.TableForms;
using IERSystem.BusinessLogic.Utils;

namespace IERSystem.Areas.QuanLyKetQuaPhanTich.Controllers
{
    public class SoKQThuNghiemController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: QuanLyKetQuaPhanTich/SoKQThuNghiem
        public async Task<ActionResult> Index()
        {
            return View(await db.SoKQThuNghiems.ToListAsync());
        }

        // GET: QuanLyKetQuaPhanTich/SoKQThuNghiem/Details/5
        public ActionResult Details(int id)
        {
            var sokq = db.SoKQThuNghiems.Find(id);
            if (sokq == null)
            {
                return HttpNotFound();
            }
            return View(new FormKQOutputModel() { 
                MaKhachHang = sokq.MauLayHienTruong.PhieuYeuCau.MaDon,
                MaMau = sokq.MauLayHienTruong.MaMau,
                NgayGuiMau = sokq.MauLayHienTruong.PhieuYeuCau.NgayLayMau.ToShortDateString(),
                NoiLayMau = sokq.MauLayHienTruong.PhieuYeuCau.DiaChiLayMau,
                ViTriLayMau = sokq.MauLayHienTruong.PhieuYeuCau.NoiLayMau,
                LoaiMau = LoaiMauConverter.ToLoaiMau(sokq.MaMau),
                DiaChi = sokq.MauLayHienTruong.PhieuYeuCau.DiaChiKhachHang,
                ChiTieuPhanTichKQs = sokq.KQThuNghiemMaus.Select((kqtn) =>
                {
                    return new ChiTieuPTDetailsModel()
                    {
                        DonVi = kqtn.DonVi,
                        GiaTri = kqtn.KetQua,
                        NguoiThucHien = "N/A",
                        PhuongPhap = kqtn.ChiTieuPhanTich.TenPhuongPhap,
                        TenChiTieu = kqtn.ChiTieuPhanTich.TenChiTieu
                    };
                })
            });
        }

        // GET: QuanLyKetQuaPhanTich/SoKQThuNghiem/Create
        public ActionResult Create()
        {
            return View(MauLayHienTruongAPIImpl.GetMauPTDaChuyen(db));
        }

        // POST: QuanLyKetQuaPhanTich/SoKQThuNghiem/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuanLyKetQuaPhanTich/SoKQThuNghiem/Edit/5
        public ActionResult Edit(long id = 0)
        {
            var sokq = db.SoKQThuNghiems.Find(id);
            if (sokq == null)
            {
                return HttpNotFound();
            }
            return View(sokq);
        }

        // GET: QuanLyKetQuaPhanTich/SoKQThuNghiem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: QuanLyKetQuaPhanTich/SoKQThuNghiem/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
