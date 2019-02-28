using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Pizzabot.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Pizzabot.Dialogs
{
    [LuisModel("a3923f26-486c-43f2-b3cd-f1122b90f238", "d318d9bc585e4e85a2abfd15d85a0860")]
    [Serializable]
    public class LUISDialog : LuisDialog<OrderPizza>  
    {
        [LuisIntent("")]
        public async Task None(IDialogContext context,LuisResult result)
        {
            await context.PostAsync("I'm Sorry I don't know what you mean.");
            context.Wait(MessageReceived);
                
        }
        [LuisIntent("Greeting")]
        public async Task Greeting(IDialogContext context, LuisResult result)
        {
           
            context.Call(new GreetingDialog(),Callback);

        }

        private async Task Callback(IDialogContext context, IAwaitable<object> result)
        {
            context.Wait(MessageReceived);
        }

        [LuisIntent("Order")]
        public async Task Order(IDialogContext context, LuisResult result)
        {
            var enrollmentForm = new FormDialog<Order>(new Order(), this.PizzaOrder, FormOptions.PromptInStart);
            context.Call<Order>(enrollmentForm, Callback);
//maryhjv,jv
        }


























    }

}