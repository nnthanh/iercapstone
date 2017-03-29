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
using System.Data.Objects.SqlClient;

namespace IERSystem.Areas.Administrator.Controllers
{
    public class DashBoardController : Controller
    {
        private IERSystemModelContainer db = new IERSystemModelContainer();

        // GET: /Administrator/DashBoard/
        public async Task<ActionResult> Index()
        {
            var danhsachmau = db.MauLayHienTruongs.Include(u=>u.PhieuYeuCau);
            //Dem tong so hop dong
            var TongSoHD = db.PhieuYeuCaus.Count();
            ViewBag.TongSoHD = TongSoHD;
            //Dem so hop dong vua tao trong vong 3 ngay
            var HDMoi = (from r in db.PhieuYeuCaus 
                         where (SqlFunctions.DateDiff("day", DateTime.Now, r.NgayTaoHD) < 3) 
                         select r).Count();
            ViewBag.HDMoi = HDMoi;
            //Dem so mau da duoc nhan
            var SoMauDaNhan = (from m in db.MauLayHienTruongs where(m.TinhTrang==1)select m).Count();
            ViewBag.SoMauDaNHan = SoMauDaNhan;
            //Dem so mau da nhan trong vong 1 tuan
            var SoMauMoiNhan = (from m in db.MauLayHienTruongs
                                join so in db.SoNhanMaus on m.Id equals so.MauLayHienTruong.Id
                                where (m.TinhTrang == 1 && (SqlFunctions.DateDiff("day", DateTime.Now, m.SoNhanMau.NgayNhanMau) < 7)) 
                                select m).Count();
            ViewBag.SoMauMoiNhan = SoMauMoiNhan;
            //Dem so mau da duoc thi nghiem
            var SoMauDaDuocTN = (from m in db.MauLayHienTruongs where(m.TinhTrang==3)select m).Count();
            ViewBag.SoMauDaDuocTN = SoMauDaDuocTN;
            //Dem so mau da duoc thi nghiem trong vong 1 tuan
            var SoMauMoiTN = (from m in db.MauLayHienTruongs
                              join so in db.SoKQThuNghiems on m.Id equals so.MauLayHienTruong.Id
                              where (m.TinhTrang == 3 && (DateTime.Now - (DateTime)m.SoKQThuNghiem.NgayNhanMau).TotalDays < 7)
                              select m).Count();
            ViewBag.SoMauMoiTN = SoMauMoiTN;
            return View(await danhsachmau.ToListAsync());
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
