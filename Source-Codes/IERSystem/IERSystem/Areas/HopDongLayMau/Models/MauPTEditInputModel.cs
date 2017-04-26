using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.HopDongLayMau.Models
{
    public class MauPTEditInputModel
    {
        public long Id { get; set; }
        public byte ModifiedState { get; set; }
        //nthoang Encoded string value for Mau Phan Tich (the AAZZZ/MM formatted string)
        public String MaMau { get; set; }
        public String MaMauKH { get; set; }
        //nthoang The AA part in the AAZZZ/MM formatted encoded string
        public String KiHieuMau { get; set; }
        public String ViTriLayMau { get; set; }
        public int SoLuong { get; set; }
        public String DonVi { get; set; }
        public String MoTaMau { get; set; }

        public IEnumerable<ChiTieuPTEditedInputModel> ChiTieuPhanTiches { get; set; }
    }

    public class ChiTieuPTEditedInputModel
    {
        public long Id { get; set; }
        //public string TenChiTieu { get; set; }
        //public string NhomChiTieu { get; set; }
    }
}