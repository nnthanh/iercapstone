using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.QuanLySoNhanMau.Models
{
    public class MauPTToBeAddedOutputModel
    {
        public long Id { get; set; }
        public string MaDon {get; set;}
        public string MaMau { get; set; }
        public string TenKhachHang { get; set; }
        public string MoTaMau { get; set; }
        public string NgayTaoHD {get; set;}
        public string NgayTraMau {get; set;}
    }
}