
namespace LUIS_pizzaorder.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class UserContext : DbContext
    {
        public UserContext()
            : base("name=pizzadbEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<user> users { get; set; }
    
    }
}
