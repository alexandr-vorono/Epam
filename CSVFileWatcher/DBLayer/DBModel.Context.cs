﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DBLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DBModelContainer : DbContext
    {
        public DBModelContainer()
            : base("name=DBModelContainer")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Manager> ManagerSet { get; set; }
        public DbSet<Order> OrderSet { get; set; }
        public DbSet<Client> ClientSet { get; set; }
        public DbSet<Goods> GoodsSet { get; set; }
        public DbSet<HistoeyFiles> HistoeyFilesSet { get; set; }
    }
}
