//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsTestBunifu
{
    using System;
    using System.Collections.Generic;
    
    public partial class DoUong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DoUong()
        {
            this.ChiTietHDBs = new HashSet<ChiTietHDB>();
            this.CongThucDoUongs = new HashSet<CongThucDoUong>();
        }
    
        public string MaDU { get; set; }
        public string TenDU { get; set; }
        public decimal DonGia { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHDB> ChiTietHDBs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CongThucDoUong> CongThucDoUongs { get; set; }
    }
}
