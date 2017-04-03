using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IERSystem.Areas.Administrator.Models;

namespace IERSystem.Areas.QuanLySoChuyenMau.Models
{
    public class CacSoChuyenMauOutputModel
    {
        public long Id { get; set; }
        public string TuNgay { get; set; }
        public string DenNgay { get; set; }
        public long QuyenSo { get; set; }
        public IEnumerable<SoChuyenMauOutputModel> NoiDung { get; set; }
        public User CreatedBy { get; set; }
    }
}
