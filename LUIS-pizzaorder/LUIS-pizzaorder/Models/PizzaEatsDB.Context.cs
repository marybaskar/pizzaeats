﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LUIS_pizzaorder.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class pizzadbEntities : DbContext
    {
        public pizzadbEntities()
            : base("name=pizzadbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<credit_card> credit_card { get; set; }
        public virtual DbSet<pizza> pizzas { get; set; }
        public virtual DbSet<size> sizes { get; set; }
        public virtual DbSet<topping_cheese> topping_cheese { get; set; }
        public virtual DbSet<topping_meat> topping_meat { get; set; }
        public virtual DbSet<topping_veg> topping_veg { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<user_order> user_order { get; set; }
    }
}
