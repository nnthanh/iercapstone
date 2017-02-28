using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IERSystem.Areas.Administrator.Models
{
    public class CacSoNhanMau
    {
        public int Id { get; set; }
        public int Year { get; set; }

        //TODO: nthoang cannot assign From To DateTime given our current TableForms.CacSoChuyenMauAPIImpl.Create function
        //public DateTime From { get; set; }
        //public DateTime To { get; set; }

        public virtual ICollection<SoNhanMau> SoNhanMaus { get; set; }
    }
}