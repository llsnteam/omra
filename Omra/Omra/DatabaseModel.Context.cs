﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Omra
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DatabaseElements : DbContext
    {
        public DatabaseElements()
            : base("name=DatabaseElements")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bizonyitekok> Bizonyitekok { get; set; }
        public virtual DbSet<Bunesetek> Bunesetek { get; set; }
        public virtual DbSet<Dolgozok> Dolgozok { get; set; }
        public virtual DbSet<Gyanusitottak> Gyanusitottak { get; set; }
        public virtual DbSet<Uzenetek> Uzenetek { get; set; }
        public virtual DbSet<FelvettBizonyitekok> FelvettBizonyitekok { get; set; }
        public virtual DbSet<FelvettDolgozok> FelvettDolgozok { get; set; }
        public virtual DbSet<FelvettGyanusitottak> FelvettGyanusitottak { get; set; }
    }
}