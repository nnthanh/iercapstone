using IERSystem.Areas.Administrator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace IERSystem.Areas.QuanLySoNhanMau.Models
{
    public class SoNhanMauCreateInputModel
    {
        public int Nam { get; set; }
        public int TuThang { get; set; }
        public int DenThang { get; set; }
    }
}