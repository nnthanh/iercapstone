using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    public class KQThuNghiemMau
    {
        public int Id { get; set; }
        public String ChiTieuThuNghiem { get; set; }
        public String DonVi { get; set; }
        public String KetQua { get; set; }
        public String NguoiThucHien { get; set; }

        public virtual SoKQThuNghiem SoKQThuNghiems { get; set; }
    }
}