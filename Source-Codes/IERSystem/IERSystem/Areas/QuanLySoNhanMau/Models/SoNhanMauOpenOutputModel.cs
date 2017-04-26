using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.QuanLySoNhanMau.Models
{
    public class SoNhanMauOpenOutputModel
    {
        public long QuyenSo { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public IEnumerable<SoNhanMauOpenRowOutputModel> NoiDung { get; set; }

        public string DomId { get; set; }
    }

    public class SoNhanMauOpenRowOutputModel
    {
        public long Id { get; set; }
        public string MaPhieuYeuCau { get; set; }
        public string TenDiaChiKH { get; set; }
        public string MaMau { get; set; }
        public string ChiTieuThuNghiem { get; set; }
        public string NgayNhan { get; set; }
        public string NgayTraKQ { get; set; }
        public string MaMauKH { get; set; }
        public bool KHKyTraTien { get; set; }
        public bool KHKyTraKQ {get; set;}
        public string AddedBy { get; set; }
    }
}