using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MvcAffablebean.Models
{
    public class SampleData : DropCreateDatabaseIfModelChanges<AffablebeanEntities>
    {
        protected override void Seed(AffablebeanEntities context)
        {
            var categories = new List<Category>
            {
                new Category { Name = "Dairy" },
                new Category { Name = "Meats" },
                new Category { Name = "Bakery" },
                new Category { Name = "Fruits&veg" }
               
            };

           new List<Product>
            {
                new Product{  Category= categories.Single(g => g.Name == "Dairy"), Price = 8.99M, Productname = "Cheese", ProductUrl = "/Content/Images/Products/Cheese.png" },
                new Product {  Category = categories.Single(g => g.Name == "Dairy"), Price = 8.99M, Productname =  "milk", ProductUrl = "/Content/Images/Products/Milk.png" },
                new Product{  Category = categories.Single(g => g.Name == "Dairy"), Price = 8.99M, Productname = "butter", ProductUrl = "/Content/Images/Products/Butter.png" },
                new Product{ Category = categories.Single(g => g.Name == "Dairy"), Price = 8.99M, Productname= "free range eggs", ProductUrl = "/Content/Images/Products/Free range Eggs.png" },
                new Product{ Category = categories.Single(g => g.Name == "Meats"), Price = 8.99M, Productname = "chicken leg", ProductUrl = "/Content/Images/Products/Chicken leg.png" },
                new Product{ Category = categories.Single(g => g.Name == "Meats"), Price = 8.99M, Productname =  "organic meat patties", ProductUrl = "/Content/Images/Products/Organic Meat Patties.png" },
                new Product{ Category = categories.Single(g => g.Name == "Meats"), Price = 8.99M, Productname =  "parma ham", ProductUrl = "/Content/Images/Products/Parma ham.png" },
                new Product{ Category = categories.Single(g => g.Name == "Meats"), Price = 8.99M, Productname =  "sausages", ProductUrl = "/Content/Images/Products/Sausages.png" },
                new Product{ Category = categories.Single(g => g.Name == "Bakery"), Price = 8.99M, Productname =  "choclate cookies", ProductUrl = "/Content/Images/Products/Chocolate cookies.png" },
                new Product{ Category = categories.Single(g => g.Name == "Bakery"), Price = 8.99M, Productname =  "pumpkin seed bun", ProductUrl = "/Content/Images/Products/Pumpkin seed bun.png" },
                new Product{ Category = categories.Single(g => g.Name == "Bakery"), Price = 8.99M, Productname =  "sesame seed bagel", ProductUrl = "/Content/Images/Products/Sesame seed bagel.png" },
                new Product{ Category = categories.Single(g => g.Name == "Bakery"), Price = 8.99M, Productname =  "sunflower seed loaf", ProductUrl = "/Content/Images/Products/Sunflower seed loaf.png" },
                new Product{ Category = categories.Single(g => g.Name == "Fruits&veg"), Price = 8.99M, Productname =  "broccoli", ProductUrl = "/Content/Images/Product/Broccoli.png" },
                new Product{ Category = categories.Single(g => g.Name == "Fruits&veg"), Price = 8.99M, Productname =  "corn on the cob", ProductUrl = "/Content/Images/Products/Corn on the cob.png" },
                new Product{ Category = categories.Single(g => g.Name == "Fruits&veg"), Price = 8.99M, Productname =  "red currants", ProductUrl = "/Content/Images/Products/Red currants.png" },
                new Product{ Category = categories.Single(g => g.Name == "Fruits&veg"), Price = 8.99M, Productname =  "seedless watermelon", ProductUrl = "/Content/Images/Products/Seedless watermelon.png" }


            }.ForEach(a => context.Products.Add(a));
        }
    }
}