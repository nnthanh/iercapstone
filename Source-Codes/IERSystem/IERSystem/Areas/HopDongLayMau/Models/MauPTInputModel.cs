using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.HopDongLayMau.Models
{
    [Serializable]
    public class MauPTInputModel
    {
        //nthoang Encoded string value for Mau Phan Tich (the AAZZZ/MM formatted string)
        public String MaMau { get; set; }
        public String MaMauKH { get; set; }
        //nthoang The AA part in the AAZZZ/MM formatted encoded string
        public String KiHieuMau { get; set; }
        public String ViTriLayMau { get; set; }
        public int SoLuong { get; set; }
        public String DonVi { get; set; }
        public String MoTaMau { get; set; }

        public IEnumerable<ChiTieuPTSelectedInputModel> ChiTieuPhanTiches { get; set; }
    }

    public class ChiTieuPTSelectedInputModel
    {
        public string TenChiTieu { get; set; }
        public string NhomChiTieu { get; set; }
    }

    public class ChiTieuPTSelectedOutputModel
    {
        public string TenChiTieu { get; set; }
        public string NhomChiTieu { get; set; }
    }
}