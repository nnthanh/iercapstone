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
    
    public partial class ChiTieuPhanTich
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChiTieuPhanTich()
        {
            this.MauLayHienTruongs = new HashSet<MauLayHienTruong>();
            this.SoChuyenMaus = new HashSet<SoChuyenMau>();
        }
    
        public long Id { get; set; }
        public string TenChiTieu { get; set; }
        public decimal ChiPhi { get; set; }
        public string TenPhuongPhap { get; set; }
        public long NhomChiTieuId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MauLayHienTruong> MauLayHienTruongs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoChuyenMau> SoChuyenMaus { get; set; }
        public virtual NhomChiTieu NhomChiTieu { get; set; }
        public virtual KQThuNghiemMau KQThuNghiemMau { get; set; }
    }
}
