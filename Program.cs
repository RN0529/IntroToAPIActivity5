// See https://aka.ms/new-console-template for more information
using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using WebAPIClient;

namespace WebAPIClient
{
    class GhibliMovie
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("original_title_romanised")]
        public string OriginTitle { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }


    }

    public class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }
        private static async Task ProcessRepositories()
        {
            Console.WriteLine("Hello world!");

            try
            {
                Console.WriteLine("Trying API");
                var result = await client.GetAsync("https://ghibliapi.herokuapp.com/films/2baf70d1-42bb-4437-b551-e5fed5a87abe");
                var resultRead = await result.Content.ReadAsStringAsync();
                var fact = JsonConvert.DeserializeObject<GhibliMovie>(resultRead);
                Console.WriteLine("___");
                Console.WriteLine("Movie ID: " + fact.Id);
                Console.WriteLine("Movie Title: " + fact.Title);
                Console.WriteLine("Movie Original title: " + fact.OriginTitle);
                Console.WriteLine("Movie Description: \n" + fact.Description);
                Console.WriteLine("\n----");



            }
            catch (Exception)
            {
                Console.WriteLine("ERROR, something went wrong ");
            }

        }
    }
}