using IERSystem.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.BaoGiaChiTieu.Models
{
    public class ChiTieuPhanTichInputModel
    {
        public string TenChiTieu { get; set; }
        public string PhuongPhap { get; set; }
        public decimal DonGia { get; set; }
    }

    public class MauBaoGiaInputModel
    {
        public string NhomChiTieu { get; set; }
        public List<ChiTieuPhanTichInputModel> ChiTieus { get; set; }
    }
}