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
    
    public partial class SoKQThuNghiem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SoKQThuNghiem()
        {
            this.KQThuNghiemMaus = new HashSet<KQThuNghiemMau>();
        }
    
        public long Id { get; set; }
        public string MaMau { get; set; }
        public System.DateTime NgayNhanMau { get; set; }
        public System.DateTime NgayTraMau { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KQThuNghiemMau> KQThuNghiemMaus { get; set; }
        public virtual MauLayHienTruong MauLayHienTruong { get; set; }
        public virtual FormKQ FormKQ { get; set; }
    }
}
