﻿using IERSystem.Areas.Administrator.Models;
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
        public DateTime NgayTaoHD { get; set; }
        public DateTime NgayDuKienTraMau { get; set; }
        public String PhuongPhapLayMau { get; set; }
        public String TenTieuChuanDoiChieu { get; set; }
        public double? PhiThiNghiemTamTinh { get; set; }
        public double? TienKhachHangTraTruoc { get; set; }
        //public Boolean DaGuiMau { get; set; }
        //public uint NamLayHD { get; set; }

        public List<MauPTInputModel> MauLayHienTruongs { get; set; }
        
        /// <summary>
        /// Convert InputModel to Database Model
        /// </summary>
        /// <returns>The database model</returns>
        public PhieuYeuCau ToModel() 
        {
            var req = new PhieuYeuCau();
            req.MaDon = this.MaDon;
            req.TenDaiDien = this.TenDaiDien;
            req.TenKhachHang = this.TenKhachHang;
            req.DiaChiKhachHang = this.DiaChiKhachHang;
            req.DiaChiLayMau = this.DiaChiLayMau;
            req.MaSoThue = this.MaSoThue;
            req.SoFax = this.SoFax;
            req.SoDienThoai = this.SoDienThoai;
            req.NgayTaoHD = this.NgayTaoHD;
            req.NgayDuKienTraMau = this.NgayDuKienTraMau;
            //nthoang: PhieuYeuCau.NamLayHD set here
            req.NamLayHD = this.NgayTaoHD.Year;
            req.MauLayHienTruongs = this.MauLayHienTruongs.Select((elem) => {
                var mapped = new MauLayHienTruong();
                mapped.MoTaMau = elem.MoTaMau;
                mapped.SoLuong = elem.SoLuong;
                mapped.DonVi = elem.DonVi;
                mapped.ViTriLayMau = elem.ViTriLayMau;
                //nthoang: MauLayHienTruong.NamLayMau set here
                mapped.NamLayMau = req.NamLayHD;
                //nthoang: MauLayHienTruong.NgayDuKienTraMau and MauLayHienTruong.NgayNhanMau set here
                mapped.NgayNhanMau = req.NgayTaoHD;
                mapped.NgayTraMau = req.NgayDuKienTraMau;
                mapped.MaMauKH = elem.MaMauKH;
                //nthoang: here MauLayHienTruong should be Encoded
                Debug.Assert(elem.MaMau != null);
                mapped.MaMau = elem.MaMau;
                return mapped;
            }).ToArray();
            return req;
        } 
    }
}