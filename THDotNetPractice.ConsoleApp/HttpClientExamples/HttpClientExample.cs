using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THDotNetPractice.ConsoleApp.Models;

namespace THDotNetPractice.ConsoleApp.HttpClientExamples
{
    public class HttpClientExample
    {
        public async Task Run()
        {
            //await Read();
            await ReadJsonPlaceholder();
        }

        public async Task Read()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7076/api/Blog");
            if(response.IsSuccessStatusCode) 
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);

                //JsonConvert.SerializeObject(); // C# Object to JSON
                //JsonConvert.DeserializeObject(); // JSON to C# Object

                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;

                foreach(var item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
        }

        public async Task ReadJsonPlaceholder()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);

                //JsonConvert.SerializeObject(); // C# Object to JSON
                //JsonConvert.DeserializeObject(); // JSON to C# Object

                List<JsonPlaceholderModel> lst = JsonConvert.DeserializeObject<List<JsonPlaceholderModel>>(jsonStr)!;

                foreach (var item in lst)
                {
                    Console.WriteLine(item.id);
                    Console.WriteLine(item.userId);
                    Console.WriteLine(item.title);
                    Console.WriteLine(item.body);
                }
            }
        }
    }
}
