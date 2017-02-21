using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    public class PhieuYeuCau
    {
        public int Id { get; set; }
        //nthoang Encoded string value for Phieu Yeu Cau (model)
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
        //TODO: nthoang DB Missing Field
        //public String PhuongPhapLayMau { get; set; }
        //TODO: nthoang DB Missing Field
        //public String TenTieuChuanDoiChieu { get; set; }
        //TODO: nthoang DB Missing Field
        //public double? PhiThiNghiemTamTinh { get; set; }
        //TODO: nthoang DB Missing Field
        //public double? TienKhachHangTraTruoc { get; set; }
        //TODO: nthoang DB Missing Field
        //public Boolean DaGuiMau { get; set; }
        public int NamLayHD { get; set; }

        public virtual ICollection<MauLayHienTruong> MauLayHienTruongs { get; set; }
    }
}