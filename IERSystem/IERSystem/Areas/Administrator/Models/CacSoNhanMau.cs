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
    
    public partial class CacSoNhanMau
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CacSoNhanMau()
        {
            this.SoNhanMaus = new HashSet<SoNhanMau>();
        }
    
        public long Id { get; set; }
        public System.DateTime TuNgay { get; set; }
        public System.DateTime DenNgay { get; set; }
        public long UserId { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoNhanMau> SoNhanMaus { get; set; }
        public virtual User CreatedBy { get; set; }
    }
}
