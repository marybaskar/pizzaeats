
namespace LUIS_pizzaorder.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class PizzaContext : DbContext
    {
        public PizzaContext()
            : base("name=pizzadbEntities")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<pizza> pizzas { get; set; }

    }
}
