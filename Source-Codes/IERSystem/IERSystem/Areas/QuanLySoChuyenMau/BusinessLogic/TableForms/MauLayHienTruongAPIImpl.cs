using IERSystem.Areas.Administrator.Models;
using IERSystem.Areas.QuanLySoChuyenMau.Models;
using IERSystem.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.BusinessLogic.TableForms
{
    public static partial class MauLayHienTruongAPIImpl
    {
        public static IEnumerable<MauPTToBeAddedOutputModel> GetCandidMauPTSoChuyenMau(
            MauPTToBeAddedInputModel inp_model, DateTime today, IERSystemModelContainer db)
        {
            if (today.Date.CompareTo(inp_model.TuNgay) > -1
                && today.Date.CompareTo(inp_model.DenNgay) < 1)
            {
                //nthoang if today is the date between SoChuyenMau FromDate and ToDate
                //Query all available MayLayHienTruongs
                var tinhtrang_nhanmau = TinhTrangMauConverter.ToByte(TinhTrangMau.DaNhan);   
                //nthoang: Potential performance bottleneck
                return (from sonhanmau in db.SoNhanMaus
                        where sonhanmau.MauLayHienTruong.TinhTrang == tinhtrang_nhanmau//[1]
                              && sonhanmau.MauLayHienTruong.SoChuyenMau == null //[2]
                              //nthoang: Additional checking bound for SoChuyenMau candids
                              //ngay nhan mau should be less than or equal to upper date bound of SoChuyenMau
                              && sonhanmau.NgayNhanMau.CompareTo(inp_model.DenNgay) < 1
                        select new { Mau = sonhanmau.MauLayHienTruong, SoNhanMau = sonhanmau }).ToList()
                               .Select((rowitem) => new MauPTToBeAddedOutputModel()
                               {
                                   Id = rowitem.Mau.Id,
                                   MaDon = rowitem.Mau.PhieuYeuCau.MaDon,
                                   MoTaMau = rowitem.Mau.MoTaMau,
                                   NgayNhanMau = rowitem.SoNhanMau.NgayNhanMau.ToShortDateString(),
                                   NgayTraMau = rowitem.Mau.PhieuYeuCau.NgayHenTraKQ.ToShortDateString(),
                                   MaMau = rowitem.Mau.MaMau,
                                   TenDiaChiKhachHang = 
                                       rowitem.Mau.PhieuYeuCau.TenKhachHang + " / " +
                                       rowitem.Mau.PhieuYeuCau.DiaChiKhachHang
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