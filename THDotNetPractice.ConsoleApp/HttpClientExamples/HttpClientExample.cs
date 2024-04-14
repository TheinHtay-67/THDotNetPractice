using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
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
            //await Edit(1);
            //await Edit(100);
            //await Create("test title", "test author", "test content");
            //await Update(20,"test title 2", "test author 3", "test content 4");
            await Delete(20);
        }

        public async Task Read()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7076/api/Blog");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
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
                Console.Write(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task Edit(int id)
        {
            string url = $"https://localhost:7076/api/Blog/{id}";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;

                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            else
            {
                Console.Write(await response.Content.ReadAsStringAsync());
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
            string jsonBlog = JsonConvert.SerializeObject(blog);

            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);

            string url = "https://localhost:7076/api/Blog";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                BlogModel item = JsonConvert.DeserializeObject<BlogModel>(jsonStr)!;
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
            else
            {
                Console.Write(await response.Content.ReadAsStringAsync());
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
            string jsonBlog = JsonConvert.SerializeObject(blog);

            HttpContent httpContent = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);

            string url = $"https://localhost:7076/api/Blog/{id}";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync(url, httpContent);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.Write(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.Write(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task Delete(int id) 
        {
            string url = $"https://localhost:7076/api/Blog/{id}";
            HttpClient client = new HttpClient();
            var response = await client.DeleteAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                Console.Write(await response.Content.ReadAsStringAsync());
            }
            else
            {
                Console.Write(await response.Content.ReadAsStringAsync());
            }
        }

    }
}
