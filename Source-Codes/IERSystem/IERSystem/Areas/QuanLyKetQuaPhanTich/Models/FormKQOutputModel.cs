using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.QuanLyKetQuaPhanTich.Models
{
    public class FormKQOutputModel
    {
        public string MaKhachHang { get; set; }
        public string MaMau { get; set; }
        public string NoiLayMau { get; set; }
        public string NgayGuiMau { get; set; }
        public string DiaChi { get; set; }
        public string LoaiMau { get; set; }
        public string ViTriLayMau { get; set; }

        public IEnumerable<ChiTieuPTDetailsModel> ChiTieuPhanTichKQs { get; set; }
    }

}