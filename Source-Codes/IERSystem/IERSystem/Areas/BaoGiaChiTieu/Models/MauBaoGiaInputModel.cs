using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.BaoGiaChiTieu.Models
{
    public class MauBaoGiaInputModel
    {
        public string NhomChiTieu { get; set; }
        public string TenChiTieu { get; set; }
        public decimal DonGia { get; set; }
    }
}