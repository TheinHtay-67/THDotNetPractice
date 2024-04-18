using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using THDotNetPractice.ConsoleApp.Models;

namespace THDotNetPractice.ConsoleApp.RestClientExamples
{
    public class RestClientExample
    {
        private readonly string _apiUrl = "https://localhost:7076/api/Blog";
        public async Task Run()
        {
            //await Read();
            //await Edit(1);
            //await Edit(100);
            //await Create("test title", "test author", "test content");
            //await Update(20,"test title 2", "test author 3", "test content 4");
            await Delete(2);
        }

        public async Task Read()
        {
            RestRequest request = new RestRequest(_apiUrl, Method.Get);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                List<BlogModel> lst = JsonConvert.DeserializeObject<List<BlogModel>>(jsonStr)!;

                foreach (var item in lst)
                {
                    Console.WriteLine(item.BlogId);
                    Console.WriteLine(item.BlogTitle);
                    Console.WriteLine(item.BlogAuthor);
                    Console.WriteLine(item.BlogContent);
                }
            }
            else
            {
                Console.Write(response.Content!);
            }
        }

        public async Task Edit(int id)
        {
            string url = $"{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Get);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;

                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            else
            {
                Console.Write(response.Content!);
            }
        }

        public async Task Create(string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            RestRequest request = new RestRequest(_apiUrl, Method.Post);
            request.AddJsonBody(blog);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Console.Write(response.Content!);
            }
            else
            {
                Console.Write(response.Content!);
            }
        }

        public async Task Update(int id, string title, string author, string content)
        {
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            string url = $"{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Put);
            request.AddJsonBody(blog);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Console.Write(response.Content!);
            }
            else
            {
                Console.Write(response.Content!);
            }
        }

        public async Task Delete(int id)
        {
            string url = $"{_apiUrl}/{id}";
            RestRequest request = new RestRequest(url, Method.Delete);
            RestClient client = new RestClient();
            RestResponse response = await client.ExecuteAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Console.Write(response.Content!);
            }
            else
            {
                Console.Write(response.Content!);
            }
        }
    }
}
