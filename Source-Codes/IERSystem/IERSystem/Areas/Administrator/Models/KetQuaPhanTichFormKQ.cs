using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    public class KetQuaPhanTichFormKQ
    {
        public int Id { get; set; }
       
        public string ChiTieu { get; set; }

        public string DonVi { get; set; }

        public int GiaTri { get; set; }

        public string PhuongPhapPhanTich { get; set; }
    }
}