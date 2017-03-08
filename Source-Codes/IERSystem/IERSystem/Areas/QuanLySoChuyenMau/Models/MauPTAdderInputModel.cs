using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.QuanLySoChuyenMau.Models
{
    public class MauPTAdderInputModel
    {
        public IEnumerable<long> MauPhanTichIDs { get; set; }
        public long CacSoChuyenMauID { get; set; }
    }
}