﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bombex.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bombex_dbEntities : DbContext
    {
        public bombex_dbEntities()
            : base("name=bombex_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Family> Families { get; set; }
        public virtual DbSet<Movement> Movements { get; set; }
        public virtual DbSet<Particular> Particulars { get; set; }
        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
    }
}
