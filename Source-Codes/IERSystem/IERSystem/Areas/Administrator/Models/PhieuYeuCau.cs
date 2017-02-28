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
    
    public partial class PhieuYeuCau
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhieuYeuCau()
        {
            this.MauLayHienTruongs = new HashSet<MauLayHienTruong>();
        }
    
        public long Id { get; set; }
        public string DiaChiKhachHang { get; set; }
        public string DiaChiLayMau { get; set; }
        public decimal KhachHangTraTruoc { get; set; }
        public string MaDon { get; set; }
        public string MaSoThue { get; set; }
        public System.DateTime NgayTaoHD { get; set; }
        public string NoiLayMau { get; set; }
        public decimal PhiThiNghiemTamTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string SoFax { get; set; }
        public string TenDaiDien { get; set; }
        public string TenKhachHang { get; set; }
        public System.DateTime NgayLayMau { get; set; }
        public System.DateTime NgayHenTraKQ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MauLayHienTruong> MauLayHienTruongs { get; set; }
        public virtual SoNhanMau SoNhanMau { get; set; }
    }
}
