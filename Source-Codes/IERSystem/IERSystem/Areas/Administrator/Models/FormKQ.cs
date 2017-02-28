using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    public class FormKQ
    {
        public int Id { get; set; }

        public String NoiLayMau { get; set; }
        public DateTime NgayGuiMau { get; set; }
        public String DiaChi { get; set; }
        public String LoaiMau { get; set; }
        public String ViTriLayMau { get; set; }

        public String MaMau { get; set; }

        public String MaDon { get; set; }
        
        public virtual ICollection<KetQuaPhanTichFormKQ> KetQuaPhanTichFormKQs { get; set; }

    }
}