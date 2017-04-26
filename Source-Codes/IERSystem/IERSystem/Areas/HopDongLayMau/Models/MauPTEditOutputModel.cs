using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.HopDongLayMau.Models
{
    public class MauPTEditOutputModel
    {
        public long Id { get; set; }
        //nthoang The AA part in the AAZZZ/MM formatted encoded string
        public string KiHieuMau { get; set; }
        public string MaMauKH { get; set; }
        public string ViTriLayMau { get; set; }
        public int SoLuong { get; set; }
        public String DonVi { get; set; }
        public string MoTaMau { get; set; }
        public IEnumerable<ChiTieuPTEditedOutputModel> ChiTieuPhanTiches { get; set; }
    }

    public class ChiTieuPTEditedOutputModel
    {
        public long Id { get; set; }
        public string TenChiTieu { get; set; }
        public string NhomChiTieu { get; set; }
    }
}