using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using THDotNetPractice.ConsoleApp.Models;

namespace THDotNetPractice.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        public void Read()
        {
            Console.WriteLine("Read");

            AppDbContext db = new AppDbContext();
            List<BlogModel> lst = db.Blogs.ToList();

            foreach (BlogModel item in lst)
            {
                Console.WriteLine(item.BlogId);
                Console.WriteLine(item.BlogTitle);
                Console.WriteLine(item.BlogAuthor);
                Console.WriteLine(item.BlogContent);
            }
        }

        public void Edit(int id)
        {
            Console.WriteLine("Edit");

            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id);

            if(item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void Create(string title, string author, string content)
        {
            Console.WriteLine("Create");
            BlogModel blog = new BlogModel()
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };

            AppDbContext db = new AppDbContext();
            db.Blogs.Add(blog);
            int result = db.SaveChanges();

            string message = result > 0 ? "Saved Successful." : "Saving Failed";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            Console.WriteLine("Update");
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if(item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;
            db.Blogs.Update(item);
            var result = db.SaveChanges();

            string message = result > 0 ? "Update Successful." : "Update Failed";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            Console.WriteLine("Delete");
            AppDbContext db = new AppDbContext();
            BlogModel item = db.Blogs.FirstOrDefault(item => item.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No data found.");
                return;
            }

            db.Blogs.Remove(item);
            var result = db.SaveChanges();

            string message = result > 0 ? "Delete Successful." : "Delete Failed";
            Console.WriteLine(message);
        }
    }
}
