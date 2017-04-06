using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    public class DashBoardOutputModel
    {
        public IEnumerable<MauLayHienTruong> DanhSachMau { get; set; }
        public int TongSoHD { get; set; }
        public int HopDongMoi { get; set; }
        public double TiLeHDMoi { get; set; }
        public int SoMauDaNhan { get; set; }
        public int SoMauMoiNhan { get; set; }
        public double TiLeMauMoi { get; set; }
        public int SoMauDaTN { get; set; }
        public int SoMauMoiTN { get; set; }
        public double TiLeTNMoi { get; set; }
        public List<int> MonthlyGraph { get; set; }
        public List<int> StatusGraph { get; set; }
    }
}