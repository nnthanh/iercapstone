using IERSystem.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IERSystem.Areas.QuanLySoChuyenMau.Models
{
    public class SoChuyenMauInputModel
    {
        public int Nam { get; set; }
        public int TuThang { get; set; }
        public int DenThang { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
