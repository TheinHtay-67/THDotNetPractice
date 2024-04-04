// See https://aka.ms/new-console-template for more information
using THDotNetPractice.ConsoleApp.AdoDotNetExamples;

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit(2);
//adoDotNetExample.Create("Test Title", "Test Author" , "Test Content");
//adoDotNetExample.Update(3, "Test Title 3", "Test Author 3" , "Test Content 3");
adoDotNetExample.Delete(3);

Console.ReadKey();
