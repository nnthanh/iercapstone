using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    public class FormKQ
    {
        public int Id { get; set; }
        public int So { get; set; }
        public String KyHieuMau { get; set; }
        public String NoiLayMau { get; set; }
        public String NgayGuiMau { get; set; }
        public String DiaChi { get; set; }
        public String LoaiMau { get; set; }
        public String ViTriLayMau { get; set; }
        public String STT { get; set; }
        public String ChiTieu { get; set; }
        public String DonVi { get; set; }
        public String GiaTri { get; set; }
        public String PhuongPhapPhanTich { get; set; }
    }
}