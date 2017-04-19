using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.HopDongLayMau.Models
{
    public class PhieuYeuCauEditOutputModel
    {
        public string TenKhachHang { get; set; }
        public string MaSoThue { get; set; }
        public string TenDaiDien { get; set; }
        public string SoDienThoai { get; set; }
        public string SoFax { get; set; }
        public string DiaChiLayMau { get; set; }
        public string DiaChiKhachHang { get; set; }
        public System.DateTime NgayLayMau { get; set; }
        public System.DateTime NgayHenTraKQ { get; set; }

        public virtual ICollection<MauLayHienTruongEditOutputModel> MauLayHienTruongs { get; set; }
    }

    public class MauLayHienTruongEditOutputModel
    {
        public string MaMau { get; set; }
        public string MaMauKH { get; set; }
        public string ViTriLayMau { get; set; }
        public int SoLuong { get; set; }
        public string MoTaMau { get; set; }
        public string ChiTieuPTs { get; set; }
    }
}