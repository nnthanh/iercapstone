using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.QuanLySoNhanMau.Models
{

    public class CacSoNhanMauOutputModel
    {
        public long Id { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public long QuyenSo { get; set; }
        public IEnumerable<SoNhanMauOutputModel> NoiDung { get; set; }
    }
}