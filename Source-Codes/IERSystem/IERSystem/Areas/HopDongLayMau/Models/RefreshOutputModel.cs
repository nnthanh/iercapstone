using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.HopDongLayMau.Models
{
    public class RefreshOutputModel
    {
        public string MaDon { get; set; }
        public string TenKhachHang { get; set; }
        public string TenDaiDien { get; set; }
        public string DiaChiLayMau { get; set; }
        public string DiaChiKH { get; set; }
        public string MaSoThue { get; set; }
        public string SDT { get; set; }
        public string SoFax { get; set; }
        public DateTime NgayTaoHD { get; set; }
        public string DuocTaoBoi { get; set; }
        //public string ChinhSuaLanCuoiBoi { get; set; }
        //public DateTime ChinhSuaLanCuoiLuc { get; set; }
        public DateTime NgayTraMau { get; set; }

    }
}