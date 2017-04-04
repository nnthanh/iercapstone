using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IERSystem.Areas.Administrator.Models;

namespace IERSystem.Areas.QuanLySoNhanMau.Models
{
    public class MauPTAdderInputModel
    {
        public IEnumerable<long> MauPhanTichIDs { get; set; }
        public long CacSoNhanMauID { get; set; }

        public User CreateBy { get; set; }

        public int UserId { get; set; }
    }
}