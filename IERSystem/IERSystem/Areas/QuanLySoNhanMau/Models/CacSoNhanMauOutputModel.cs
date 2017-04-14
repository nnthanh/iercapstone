using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IERSystem.Areas.Administrator.Models;

namespace IERSystem.Areas.QuanLySoNhanMau.Models
{

    public class CacSoNhanMauOutputModel
    {
        public long QuyenSo { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public User CreatedBy {get;set;}
    }
}