//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IERSystem.Areas.Administrator.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class FormKQ
    {
        public long Id { get; set; }
        public string NoiLayMau { get; set; }
        public string DiaChi { get; set; }
        public string ViTriLayMau { get; set; }
        public System.DateTime NgayGuiMau { get; set; }
        public string LoaiMau { get; set; }
        public string MaDon { get; set; }
        public string MaMau { get; set; }
    
        public virtual SoKQThuNghiem SoKQThuNghiem { get; set; }
    }
}
