using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ConsoleApp.Client
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            client.BaseAddress = new Uri("https://weatherappapi.azurewebsites.net");

            var val = "application/json";
            var media = new MediaTypeWithQualityHeaderValue(val);

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(media);

            try
            {
                var weatherSummaries = new Class1();

                // read
                System.Console.WriteLine("Weather Summaries: ");
                List<Class1> weatherItems = GetWeatherItems();
                for (int i = 0; i < weatherItems.Count; i++)
                {
                    var oneSummary = weatherItems[i];
                    System.Console.WriteLine($"{i + 1}: {oneSummary.temperatureF} Degrees Farenheit, {oneSummary.summary}\n{oneSummary.date}\n");
                }
            }
            catch (System.Exception e)
            {
                
                System.Console.WriteLine(e.Message);
            }
        }

        private static List<Class1> GetWeatherItems()
        {
            var action = $"/weatherforecast";
            var request = client.GetAsync(action);
            var response = request.Result.Content.ReadAsAsync<List<Class1>>();

            return response.Result;
        }
    }
}
