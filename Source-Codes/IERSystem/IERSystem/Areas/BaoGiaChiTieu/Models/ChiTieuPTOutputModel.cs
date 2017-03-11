using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.BaoGiaChiTieu.Models
{
    public class ChiTieuPTOutputModel
    {
        public long Id { get; set; }

        public string TenNhomChiTieu { get; set; }
        public string TenPhuongPhap { get; set; }
        public string TenChiTieu { get; set; }
    }
}