using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.HopDongLayMau.Models
{
    public class MauDetailsOutputModel
    {
        public string MaMau { get; set; }
        public string MaMauKH { get; set; }
        public string ViTriLayMau { get; set; }
        public int SoLuong { get; set; }
        public string DonVi { get; set; }
        public string MoTaMau { get; set; }
        public string ChiTieuPhanTiches { get; set; }
    }
}