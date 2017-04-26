using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.HopDongLayMau.Models
{
    public class DetailsOutputModel
    {
        public Int64 Id { get; set; }
        public string MaDon { get; set; }
        public string TenKhachHang { get; set; }
        public string TenDaiDien { get; set; }
        public string DiaChiLayMau { get; set; }
        public string DiaChiKhachHang { get; set; }
        public string MaSoThue { get; set; }
        public string SoDienThoai { get; set; }
        public string SoFax { get; set; }
        public string NgayTaoHD { get; set; }
        public string NgayHenTraKQ { get; set; }
        public IEnumerable<MauDetailsOutputModel> MauPT { get; set; }
    }
}