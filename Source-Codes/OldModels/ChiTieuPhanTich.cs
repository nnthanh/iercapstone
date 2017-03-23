using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace IERSystem.Areas.Administrator.Models
{
    public class ChiTieuPhanTich
    {
        public int Id { get; set; }
        public String TenChiTieu { get; set; }
        public decimal ChiPhi { get; set; }
        public String NhomChiTieu { get; set; }
    }
}