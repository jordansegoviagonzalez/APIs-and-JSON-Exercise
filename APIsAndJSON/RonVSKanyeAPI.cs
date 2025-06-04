using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class RonVSKanyeAPI
    
    {

        public static void Conversation()
        {
            var client = new HttpClient();
            
            Console.WriteLine("\"I approached Kanye West and Ron Swanson and couldn't help but overhearing nonsense they were saying...\"");

            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"Kaney says:\n{GetKanyeQuote(client)}\n");
                Thread.Sleep(2000);
                Console.WriteLine($"Ron says:\n{GetKanyeQuote(client)}\n");
                Thread.Sleep(2000);
                
                
                
            }
        }
        
        private static string GetRonQuote(HttpClient client)
         {
             var jText = client.GetStringAsync("https://ron-swanson-quotes.herokuapp.com/v2/quotes").Result;
     
             var quote = jText.Replace('[', ' ').Replace(']', ' ').Replace("", " ").Trim();
             
             //var ronArray = JArray.Parse(jText);
     
             //return ronArray[0].ToString();
             
             return quote; 
         }
        private static string GetKanyeQuote(HttpClient client)
        {
            var jText = client.GetStringAsync("https://api.kanye.rest").Result;
                
            var quote = JObject.Parse(jText)["quote"].ToString();
            
            return quote;
        }
        
    }
}
