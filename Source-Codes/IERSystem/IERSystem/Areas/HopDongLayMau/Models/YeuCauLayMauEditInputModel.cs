using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.HopDongLayMau.Models
{
    public class YeuCauLayMauEditInputModel
    {
        public long Id { get; set; }

        public string TenKhachHang { get; set; }
        public string MaSoThue { get; set; }
        public string TenDaiDien { get; set; }
        public string SoDienThoai { get; set; }
        public string SoFax { get; set; }
        public string DiaChiLayMau { get; set; }
        public string DiaChiKhachHang { get; set; }
        public System.DateTime NgayLayMau { get; set; }
        public System.DateTime NgayHenTraKQ { get; set; }

        public virtual IEnumerable<MauPTEditInputModel> MauLayHienTruongs { get; set; }
    }

}