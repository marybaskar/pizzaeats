using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pizzabot.Models
{
    public enum PizzaSizeOptions
    {
        small,
        medium,
        large,
    }

    public enum PizzaTopping
    {
      Pepperoni,
      Mushrooms,
      Onions,
      Sausage,
      Bacon,
      cheese,
      Olives,
      Peppers,
      Pineapples,
      Spinach,
       
    }

    [Serializable]
    public class OrderPizza
    {
        public PizzaSizeOptions? PizzaSize;
        public DateTime? OrderDate;
        public List<PizzaTopping> Topping;

        public static IForm<OrderPizza> BuildForm()
        {
            return new FormBuilder<OrderPizza>()
              .Message("welcome to pizzaeats bot!")
              .Build();
        }    
    }
}