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
        //TODO: nthoang DB Field needed to be worked on
        public String NguoiGiaoMau { get; set; }
        //TODO: nthoang DB Field needed to be worked on
        public String NguoiNhanMau { get; set; }
        public DateTime NgayGiaoMau { get; set; }
        public DateTime NgayTraKetQua { get; set; }
        //TODO: nthoang DB Field needed to be worked on
        public String DienTien { get; set; }
        //TODO: nthoang DB Field needed to be worked on
        public String GhiChu { get; set; }

        public virtual CacSoChuyenMau CacSoChuyenMau { get; set; }
    }
}