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
    
    public partial class CongThucDoUong
    {
        public string MaDU { get; set; }
        public string MaNL { get; set; }
        public Nullable<double> SoLuong { get; set; }
    
        public virtual DoUong DoUong { get; set; }
        public virtual NguyenLieu NguyenLieu { get; set; }
    }
}
