using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    internal class OpenWeatherMapAPI
    {
        public static void GetTempFromZipCode()
        {
            var appsettingsText = File.ReadAllText("appsettings.json");
            
            var  apiKey = JObject.Parse(appsettingsText)["ApiKey"].ToString();
            
            Console.WriteLine("Let's get the temp from your city! Please enter your zip voce:");
            
            var zip = Console.ReadLine();

            var url = $"https://api.openweathermap.org/data/2.5/weather?zip={zip}&appid={apiKey}&units=imperial";
            
            var client = new HttpClient();
            
            var weatherResponde = client.GetStringAsync(url).Result;
            
            var temp = JObject.Parse(weatherResponde)["main"]["temp"].ToString();
            
            //display the results to the user
            Console.WriteLine($"The temperature in your city is {temp}.");

        }
    }
}
