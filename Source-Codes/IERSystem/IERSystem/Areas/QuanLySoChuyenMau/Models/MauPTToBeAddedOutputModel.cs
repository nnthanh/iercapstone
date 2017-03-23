using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.QuanLySoChuyenMau.Models
{
    public class MauPTToBeAddedOutputModel
    {
        public long Id { get; set; }
        public string MaDon {get; set;}
        public string TenDiaChiKhachHang { get; set; }
        public string MaMau { get; set; }
        public string NgayNhanMau { get; set; }
        public string NgayTraMau { get; set; }
        public string MoTaMau { get; set; }
    }
}