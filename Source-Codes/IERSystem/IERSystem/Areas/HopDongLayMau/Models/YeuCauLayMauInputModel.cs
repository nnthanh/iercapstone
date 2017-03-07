using IERSystem.Areas.Administrator.Models;
using IERSystem.BusinessLogic.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace IERSystem.Areas.HopDongLayMau.Models
{
    [Serializable]
    public class YeuCauLayMauInputModel
    {
        //nthoang Encoded string value for Yeu Cau Lay Mau (input model)
        public String MaDon { get; set; }
        public String TenKhachHang { get; set; }
        public String TenDaiDien { get; set; }
        public String DiaChiLayMau { get; set; }
        public String DiaChiKhachHang { get; set; }
        public String MaSoThue { get; set; }
        public String SoDienThoai { get; set; }
        public String SoFax { get; set; }
        public DateTime NgayLayMau { get; set; }
        public int NgayHenTraKQ { get; set; }
        public String PhuongPhapLayMau { get; set; }
        public String TenTieuChuanDoiChieu { get; set; }
        public double? PhiThiNghiemTamTinh { get; set; }
        public double? TienKhachHangTraTruoc { get; set; }
        //public Boolean DaGuiMau { get; set; }
        //public uint NamLayHD { get; set; }

        public IEnumerable<MauPTInputModel> MauLayHienTruongs { get; set; }
        
        /// <summary>
        /// Convert InputModel to Database Model
        /// </summary>
        /// <returns>The database model</returns>
        public PhieuYeuCau ToModel(DateTime today) 
        {
            var req = new PhieuYeuCau();
            //nthoang: here PhieuYeuCau should already been Encoded
            Debug.Assert(this.MaDon != null);
            req.MaDon = this.MaDon;
            req.TenDaiDien = this.TenDaiDien;
            req.TenKhachHang = this.TenKhachHang;
            req.DiaChiKhachHang = this.DiaChiKhachHang;
            req.DiaChiLayMau = this.DiaChiLayMau;
            req.MaSoThue = this.MaSoThue;
            req.SoFax = this.SoFax;
            req.SoDienThoai = this.SoDienThoai;
            req.NgayHenTraKQ = this.NgayLayMau.AddDays(this.NgayHenTraKQ);
            req.NoiLayMau = this.DiaChiLayMau;
            req.NgayLayMau = this.NgayLayMau;
            req.NgayTaoHD = today;
            req.MauLayHienTruongs = this.MauLayHienTruongs.Select((elem) => {
                var mapped = new MauLayHienTruong();
                mapped.MoTaMau = elem.MoTaMau;
                mapped.SoLuong = elem.SoLuong;
                mapped.DonVi = elem.DonVi;
                mapped.ViTriLayMau = elem.ViTriLayMau;
                mapped.MaMauKH = elem.MaMauKH;
                //nthoang: here MauLayHienTruong should already been Encoded
                Debug.Assert(elem.MaMau != null);
                mapped.MaMau = elem.MaMau;
                //nthoang: MauLayHienTruong.TinhTrang is KhoiTao
                mapped.TinhTrang = TinhTrangMauConverter.ToByte(TinhTrangMau.KhoiTao);
                return mapped;
            }).ToArray();
            return req;
        } 
    }
}