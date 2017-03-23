using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.QuanLyKetQuaPhanTich.Models
{
    public class KetQuaEditedInputModel
    {
        public long Id { get; set; }
        public IEnumerable<KetQuaEditedModel> KetQuas { get; set; }
    }

    public class KetQuaEditedModel
    {
        public string DonVi { get; set; }
        public string KetQua { get; set; }
    }
}