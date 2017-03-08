using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.QuanLySoNhanMau.Models
{
    public class SoNhanMauOutputModel
    {
        public long Id { get; set; }
        public string MaPhieuYeuCau { get; set; }
        public string TenDiaChiKH { get; set; }
        public string MaMau { get; set; }
        public string ChiTieuThuNghiem { get; set; }
        public string NgayNhan { get; set; }
        public string NgayTraKQ { get; set; }
        public string MaMauKH { get; set; }
    }

}