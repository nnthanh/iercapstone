using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoNhanMau.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using IERSystem.BusinessLogic.Utils;

namespace IERSystem.BusinessLogic.TableForms
{
    public static partial class MauLayHienTruongAPIImpl
    {
        public static IEnumerable<MauPTToBeAddedOutputModel> GetCandidMauPTSoNhanMau(
            MauPTToBeAddedInputModel inp_model, DateTime today, IERSystemModelContainer db)
        {
            if (today.Date.CompareTo(inp_model.TuNgay) > -1
                && today.Date.CompareTo(inp_model.DenNgay) < 1)
            {
                //nthoang if today is the date between SoNhanMau FromDate and ToDate
                //Query all available MayLayHienTruongs
                var tinhtrang_khoitao = TinhTrangMauConverter.ToByte(TinhTrangMau.KhoiTao);
                return (from mauht in db.MauLayHienTruongs
                        join phieuyc in db.PhieuYeuCaus on mauht.PhieuYeuCauId equals phieuyc.Id
                        where mauht.TinhTrang == tinhtrang_khoitao//[1]
                              && mauht.SoNhanMau == null //[2]
                        //&& phieuyc.NgayTaoHD.CompareTo(inp_model.TuNgay) > -1
                        //&& phieuyc.NgayTaoHD.CompareTo(inp_model.DenNgay) < 1
                        select new { Mau = mauht, Phieu = phieuyc }).ToList()
                               .Select((rowitem) => new MauPTToBeAddedOutputModel()
                        {
                            Id = rowitem.Mau.Id,
                            MaDon = rowitem.Phieu.MaDon,
                            //DiaChiKH = rowitem.Phieu.DiaChiKhachHang,
                            MoTaMau = rowitem.Mau.MoTaMau,
                            NgayTaoHD = rowitem.Phieu.NgayTaoHD.ToShortDateString(),
                            NgayTraMau = rowitem.Phieu.NgayHenTraKQ.ToShortDateString(),
                            //TenDaiDien = rowitem.Phieu.TenDaiDien,
                            MaMau = rowitem.Mau.MaMau,
                            TenKhachHang = rowitem.Phieu.TenKhachHang
                        }).ToList();
            }
            else
            {
                //nthoang if today is not the date between SoNhanMau FromDate and ToDate
                //nthoang return empty list
                return new List<MauPTToBeAddedOutputModel>();
            }

        }
    }
}