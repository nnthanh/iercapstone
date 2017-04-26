using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERSystem.Areas.QuanLySoChuyenMau.Models
{
    public class SoChuyenMauOpenOutputModel
    {
        public long QuyenSo { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public IEnumerable<SoChuyenMauOpenRowOutputModel> NoiDung { get; set; }

        public string DomId { get; set; }
    }

    public class SoChuyenMauOpenRowOutputModel
    {
        public long Id { get; set; }
        public string MaKhachHang { get; set; }
        public string MaMau { get; set; }
        public string ChiTieuThuNghiem { get; set; }
        public string NguoiGiaoMau { get; set; }
        public string NguoiNhanMau { get; set; }
        public string NgayGiao { get; set; }
        public string NgayTraKQ { get; set; }
        public string DienTen { get; set; }
        public string GhiChu { get; set; }
    }
}
