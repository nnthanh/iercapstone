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
    
    public partial class RoleMatrix
    {
        public int Id { get; set; }
        public short HopDong { get; set; }
        public short SoNhan { get; set; }
        public short SoChuyen { get; set; }
        public short SoKQ { get; set; }
        public short FormKQ { get; set; }
        public int RoleMasterId { get; set; }
    
        public virtual RoleMaster RoleMaster { get; set; }
    }
}