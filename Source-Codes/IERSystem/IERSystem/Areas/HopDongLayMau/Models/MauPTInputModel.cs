using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.HopDongLayMau.Models
{
    [Serializable]
    public class MauPTInputModel
    {
        //nthoang Encoded string value for Mau Phan Tich (input model)
        public String MaMau { get; set; }
        public String MaMauKH { get; set; }
        public String KiHieuMau { get; set; }
        public String ViTriLayMau { get; set; }
        public int SoLuong { get; set; }
        public String DonVi { get; set; }
        public String MoTaMau { get; set; }
        
        //public DateTime NgayNhanMau { get; set; }
        //public DateTime NgayTraMau { get; set; }
        
        //public int MaHDPhanTich { get; set; }
        public String ChiTieuPhanTich { get; set; }
        //public uint NamLayMau { get; set; }
    }
}