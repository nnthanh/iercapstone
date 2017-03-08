using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.QuanLyKetQuaPhanTich.Models
{
    public class SoKQThuNghiemInputModel
    {
        public long Id { get; set; }

        public string KiHieuMau { get; set; }
        public string NgayNhanMau { get; set; }
        public string NgayTraMau { get; set; }

    }

}