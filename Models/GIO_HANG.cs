//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LEVINHHUY_K22CNT1_2210900106_PROJECT2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GIO_HANG
    {
        public int MaGioHang { get; set; }
        public int UserId { get; set; }
        public int MaSP { get; set; }
        public int SoLuong { get; set; }
        public Nullable<System.DateTime> NgayThem { get; set; }
    
        public virtual SAN_PHAM SAN_PHAM { get; set; }
        public virtual USER USER { get; set; }
    }
}
