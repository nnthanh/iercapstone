using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    public class SoNhanMau
    {
        public int Id { get; set; }
        public String PhieuYeuCau { get; set; }
        public String TenDiaChiKhachHang { get; set; }
        public String MaSo { get; set; }
        public String ChiTieuThuNghiem { get; set; }
        public DateTime NgayNhan { get; set; }
        public DateTime NgayTraKetQua { get; set; }
        public String KHKyNhan { get; set; }
        public String KyHieuMau { get; set; }
    }
}