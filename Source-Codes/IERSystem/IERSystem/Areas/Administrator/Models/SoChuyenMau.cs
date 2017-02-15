using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    public class SoChuyenMau
    {
        public int Id { get; set; }
        public String MaKhachHang { get; set; }
        public String MaMau { get; set; }
        public String ChiTieuThuNghiem { get; set; }
        public String NguoiGiaoMau { get; set; }
        public String NguoiNhanMau { get; set; }
        public DateTime NgayGiaoMau { get; set; }
        public DateTime NgayTraKetQua { get; set; }
        public String DienTien { get; set; }
        public String GhiChu { get; set; }

    }
}