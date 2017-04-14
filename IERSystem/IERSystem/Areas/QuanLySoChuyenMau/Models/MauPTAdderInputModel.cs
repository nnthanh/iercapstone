using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IERSystem.Areas.Administrator.Models;

namespace IERSystem.Areas.QuanLySoChuyenMau.Models
{
    public class MauPTAdderInputModel
    {
        public IEnumerable<long> MauPhanTichIDs { get; set; }
        public long CacSoChuyenMauID { get; set; }
        public User CreatedBy { get; set; }
        public int UserId { get; set; }
        
    }
}