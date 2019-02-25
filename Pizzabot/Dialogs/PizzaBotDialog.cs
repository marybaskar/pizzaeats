using Microsoft.Bot.Builder.Dialogs;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using Microsoft.Bot.Builder.FormFlow;
using Pizzabot.Models;
using System.Threading.Tasks;

namespace Pizzabot.Dialogs
{
    public class PizzaBotDialog
    {
        public static readonly IDialog<string> dialog = Chain.PostToChain()
            .Select(msg => msg.Text)
            .Switch(
            new RegexCase<IDialog<string>>(new Regex("^Hi", RegexOptions.IgnoreCase), (context, text) =>
             {
                 return Chain.ContinueWith(new GreetingDialog(), AfterGreetingContinuation);

             }),
        new DefaultCase<string, IDialog<string>>((ContextBoundObject, text) =>
            {
                return Chain.ContinueWith(FormDialog.FromForm(OrderPizza.BuildForm, FormOptions.PromptInStart), AfterGreetingContinuation);
            }))
            .Unwrap()
            .PostToUser();

        private async static Task<IDialog<string>> AfterGreetingContinuation(IBotContext context, IAwaitable<object> item)
        {
            var token = await item;
            var name = "User";
            context.UserData.TryGetValue<string>("Name", out name);
            return Chain.Return($"Thank you for using pizzaeats bot: {name}");
        }
    }
}