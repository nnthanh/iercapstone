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
    
    public partial class SoNhanMau
    {
        public long Id { get; set; }
        public bool KHKiNhanTraKQ { get; set; }
        public bool KHKiNhanTraTien { get; set; }
        public System.DateTime NgayNhan { get; set; }
        public System.DateTime NgayTraKQ { get; set; }
        public long CacSoNhanMauId { get; set; }
    
        public virtual CacSoNhanMau CacSoNhanMau { get; set; }
        public virtual MauLayHienTruong MauLayHienTruong { get; set; }
    }
}
