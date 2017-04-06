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
            DashBoardOutputModel dashboardOutput = new DashBoardOutputModel();
            var danhsachmau = db.MauLayHienTruongs.Include(u=>u.PhieuYeuCau);
            //Dem tong so hop dong
            var TongSoHD = db.PhieuYeuCaus.Count();
            dashboardOutput.DanhSachMau = danhsachmau;
            dashboardOutput.TongSoHD = TongSoHD;
            //ViewBag.TongSoHD = TongSoHD;
            //Dem so hop dong vua tao trong vong 3 ngay
            var HDMoi = (from r in db.PhieuYeuCaus
                         where (DbFunctions.DiffDays(DateTime.Now, r.NgayTaoHD) < 3) 
                         select r).Count();
            //ViewBag.HDMoi = HDMoi;
            dashboardOutput.HopDongMoi = HDMoi;
            double TiLeHDMoi = 0;
            double TiLeMauMoi = 0;
            double TiLeTNMoi = 0;
            if (TongSoHD != 0)
            {
                TiLeHDMoi = HDMoi / TongSoHD*100;
            }
            dashboardOutput.TiLeHDMoi = Math.Round(TiLeHDMoi,2);
            //Dem so mau da duoc nhan
            var SoMauDaNhan = (from m in db.MauLayHienTruongs where(m.TinhTrang==1)select m).Count();
            //ViewBag.SoMauDaNhan = SoMauDaNhan;
            dashboardOutput.SoMauDaNhan = SoMauDaNhan;
            //Dem so mau da nhan trong vong 1 tuan
            var SoMauMoiNhan = (from m in db.MauLayHienTruongs
                                join so in db.SoNhanMaus on m.Id equals so.MauLayHienTruong.Id
                                where (m.TinhTrang == 1 && (DbFunctions.DiffDays( DateTime.Now, m.SoNhanMau.NgayNhanMau) < 7)) 
                                select m).Count();
            //ViewBag.SoMauMoiNhan = SoMauMoiNhan;
            dashboardOutput.SoMauMoiNhan = SoMauMoiNhan;
            if(SoMauDaNhan!=0)
            {
                TiLeMauMoi = SoMauMoiNhan/SoMauDaNhan*100;
            }
            dashboardOutput.TiLeMauMoi = Math.Round(TiLeMauMoi,2);
            //Dem so mau da duoc thi nghiem
            var SoMauDaDuocTN = (from m in db.MauLayHienTruongs where(m.TinhTrang==3)select m).Count();
            //ViewBag.SoMauDaDuocTN = SoMauDaDuocTN;
            dashboardOutput.SoMauDaTN = SoMauDaDuocTN;
            //Dem so mau da duoc thi nghiem trong vong 1 tuan
            var SoMauMoiTN = (from m in db.MauLayHienTruongs
                              join so in db.SoKQThuNghiems on m.Id equals so.MauLayHienTruong.Id
                              where (m.TinhTrang == 3 && (DbFunctions.DiffDays( DateTime.Now, m.SoNhanMau.NgayNhanMau) < 7))
                              select m).Count();
            //ViewBag.SoMauMoiTN = SoMauMoiTN;
            dashboardOutput.SoMauMoiTN = SoMauMoiTN;
            if (SoMauDaDuocTN != 0)
            {
                TiLeTNMoi = SoMauMoiTN / SoMauDaDuocTN * 100;
            }
            dashboardOutput.TiLeTNMoi = Math.Round(TiLeTNMoi, 2);

            //Tinh du lieu cho month chart
            for (int i = 1; i <= 12; i++) 
            { 
                int Count = (from a in danhsachmau where a.PhieuYeuCau.NgayTaoHD.Month == i select a).Count();
                dashboardOutput.MonthlyGraph.Add(Count);
            }
            //Tinh du lieu cho status chart
            for (int i = 0; i < 5;i++)
            {
                int Count = (from a in danhsachmau where a.TinhTrang == i select a).Count();
                dashboardOutput.StatusGraph.Add(Count);
            }
            return View(dashboardOutput);
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
