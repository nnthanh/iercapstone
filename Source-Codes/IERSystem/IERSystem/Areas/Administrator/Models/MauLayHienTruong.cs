using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    public class MauLayHienTruong
    {
        public int Id { get; set; }
        //nthoang Encoded string value for Mau Phan Tich (model)
        public String MaMau { get; set; }
        public String MaMauKH { get; set; }
        public String ViTriLayMau { get; set; }
        public int SoLuong { get; set; }
        public String DonVi { get; set; }
        public String MoTaMau { get; set; }
        public DateTime NgayNhanMau { get; set; }
        public DateTime NgayTraMau { get; set; }
        public int MaHDPhanTich { get; set; }
        //TODO: nthoang DB Field needed to be worked on
        public String MaChiTieuPhanTich { get; set; }
        public int NamLayMau { get; set; }
        
        public virtual PhieuYeuCau PhieuYeuCau { get; set; }
        public virtual ChiTieuPhanTich ChiTieuPhanTich { get; set; }

    }
}