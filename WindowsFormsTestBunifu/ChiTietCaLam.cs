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
    
    public partial class ChiTietCaLam
    {
        public string MaNV { get; set; }
        public string MaCa { get; set; }
        public System.DateTime NgayLamViec { get; set; }
        public virtual CaLam CaLam { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}
