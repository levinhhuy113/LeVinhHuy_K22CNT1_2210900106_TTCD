﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities1 : DbContext
    {
        public LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities1()
            : base("name=LEVINHHUY_K22CNT1_2210900106_PROJECT2Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CHI_TIET_DON_HANG> CHI_TIET_DON_HANG { get; set; }
        public virtual DbSet<DON_HANG> DON_HANG { get; set; }
        public virtual DbSet<KHACH_HANG> KHACH_HANG { get; set; }
        public virtual DbSet<QUAN_TRI> QUAN_TRI { get; set; }
        public virtual DbSet<SAN_PHAM> SAN_PHAM { get; set; }
    }
}
