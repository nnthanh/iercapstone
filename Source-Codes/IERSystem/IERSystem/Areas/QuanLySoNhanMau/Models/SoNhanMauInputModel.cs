using IERSystem.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace IERSystem.Areas.QuanLySoNhanMau.Models
{
    public class SoNhanMauInputModel
    {
        public int Nam { get; set; }
        public int TuThang { get; set; }
        public int DenThang { get; set; }

        public CacSoNhanMau ToModel()
        {
            return new CacSoNhanMau()
            {
                TuNgay = new DateTime(this.Nam, this.TuThang, 1),
                DenNgay = new DateTime(this.Nam, this.DenThang, DateTime.DaysInMonth(this.Nam, this.DenThang))
            };
        }
    }
}