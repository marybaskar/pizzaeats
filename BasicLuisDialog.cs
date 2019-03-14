using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;

//LUIS BOT NAME: pizzaAutom 
//Note: you need to go to your Azure app setting and go to LuisAppID and replace that with the LuisAppID found in pizzaAutom in Applicattion Info 

namespace Microsoft.Bot.Sample.LuisBot
{
    //Info on the template I used--> http://aka.ms/azurebots-csharp-luis
    [Serializable]
    public class BasicLuisDialog : LuisDialog<object>
    {
        // CONSTANTS        
        // Entity in the LUIS app
        public const string Entity_number = "builtin.number";
        public const string Entity_size = "size";
        public const string Entity_topping = "topping";

        // Intents in the LUIS app 
        public const string Intent_Greeting = "Greeting";
        public const string Intent_pizzaOrder = "pizzaOrder";
        public const string Intent_None = "None";

        // the connection to LUIS-- DOES NOT NEED TO BE CHANGED
        public BasicLuisDialog() : base(new LuisService(new LuisModelAttribute(
            ConfigurationManager.AppSettings["LuisAppId"], 
            ConfigurationManager.AppSettings["LuisAPIKey"], 
            domain: ConfigurationManager.AppSettings["LuisAPIHostName"])))
        {
        }
        
        //for greeting    
        [LuisIntent(Intent_Greeting)]
        public async Task GreetingIntent(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        } 
        //for pizzaOrder
         [LuisIntent(Intent_pizzaOrder)]
        public async Task pizzaOrderIntent(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        } 
        // the None
        [LuisIntent("None")]
        public async Task NoneIntent(IDialogContext context, LuisResult result)
        {
            await this.ShowLuisResult(context, result);
        }

// To change intents and stuff, go to https://luis.ai and create a new intent: then train and publish to see changes.      

// Below are the entities found in the result--- basically to see if the correct entities are being mapped with the intent! 
// This should eventually be changed to redirect to an pizza order form or something of that sort
        public string BotEntityRecognition(LuisResult result)
        {
            StringBuilder entityResults = new StringBuilder();

            if(result.Entities.Count>0)
        {
            foreach (EntityRecommendation item in result.Entities)
        {
            // Query: I want a large mushroom pizza
            // item.Type = "topping"
            // item.Entity = "mushroom"
            entityResults.Append(item.Type + "=" + item.Entity + ",");
        }
        // removes last comma
            entityResults.Remove(entityResults.Length - 1, 1);
        }

            return entityResults.ToString();
        }
//_____________________________________________________________________________________
//The bot's reply to your very important needs    
        private async Task ShowLuisResult(IDialogContext context, LuisResult result) 
        {
        // get recognized entities
        string entities = this.BotEntityRecognition(result);
    
        // round number
        string roundedScore =  result.Intents[0].Score != null ? (Math.Round(result.Intents[0].Score.Value, 2).ToString()) : "0";
    
        await context.PostAsync($"**Query**: {result.Query}, **Intent**: {result.Intents[0].Intent}, **Score**: {roundedScore}. **Entities**: {entities}");
        await context.PostAsync($"**You want this to happen, based on your query**: {result.Intents[0].Intent}, **Which maps to these entities**: {entities}");
        context.Wait(MessageReceived);
        }
    }
}