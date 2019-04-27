
namespace LUIS_pizzaorder.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class User_OrderContext : DbContext
    {
        public User_OrderContext()
            : base("name=pizzadbEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<user_order> user_order { get; set; }

    }
}
