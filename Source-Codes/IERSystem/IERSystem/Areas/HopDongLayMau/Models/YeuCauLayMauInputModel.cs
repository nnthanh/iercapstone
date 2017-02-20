using IERSystem.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.HopDongLayMau.Models
{
    [Serializable]
    public class YeuCauLayMauInputModel
    {
        public String MaDon { get; set; }
        public String TenKhachHang { get; set; }
        public String TenDaiDien { get; set; }
        public String DiaChiLayMau { get; set; }
        public String DiaChiKhachHang { get; set; }
        public String MaSoThue { get; set; }
        public String SoDienThoai { get; set; }
        public String SoFax { get; set; }
        public DateTime NgayTaoHD { get; set; }
        public DateTime NgayDuKienTraMau { get; set; }
        public String PhuongPhapLayMau { get; set; }
        public String TenTieuChuanDoiChieu { get; set; }
        public double? PhiThiNghiemTamTinh { get; set; }
        public double? TienKhachHangTraTruoc { get; set; }
        //public Boolean DaGuiMau { get; set; }
        //public uint NamLayHD { get; set; }

        public List<MauPTInputModel> MauLayHienTruongs { get; set; }

        //TODO: nthoang Convert InputModel to Database Model
        public Request ToModel() 
        {
            var req = new Request();
            req.MaDon = this.MaDon;
            req.MaSoThue = this.MaSoThue;
            req.MauLayHienTruongs = this.MauLayHienTruongs.Select((elem) => {
                var mapped = new MauLayHienTruong();
                mapped.MoTaMau = elem.MoTaMau;
                mapped.Soluong = elem.Soluong;
                mapped.ViTriLayMau = elem.ViTriLayMau;
                //TODO: nthoang separate into New Table?
                mapped.MaChiTieuPhanTich = elem.ChiTieuPhanTich;
                mapped.MaMau = elem.MaMau;
                return mapped;
            }).ToArray();
            req.DiaChiKhachHang = this.DiaChiKhachHang;
            req.DiaChiLayMau = this.DiaChiLayMau;
            req.NgayDuKienTraMau = this.NgayDuKienTraMau;
            req.SoFax = this.SoFax;
            req.SoDienThoai = this.SoDienThoai;
            req.TenDaiDien = this.TenDaiDien;
            req.TenKhachHang = this.TenKhachHang;
            req.NgayTaoHD = this.NgayTaoHD;
            return req;
        }
    }
}