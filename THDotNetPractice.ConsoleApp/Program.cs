// See https://aka.ms/new-console-template for more information
using THDotNetPractice.ConsoleApp.AdoDotNetExamples;
using THDotNetPractice.ConsoleApp.DapperExamples;

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
////adoDotNetExample.Read();
////adoDotNetExample.Edit(2);
////adoDotNetExample.Create("Test Title", "Test Author" , "Test Content");
////adoDotNetExample.Update(3, "Test Title 3", "Test Author 3" , "Test Content 3");
//adoDotNetExample.Delete(3);

DapperExample dapperExample = new DapperExample();
//dapperExample.Read();
//dapperExample.Edit(1);
//dapperExample.Create("Test Title 2", "Test Author 2", "Test Content 2");
//dapperExample.Update(5, "Test Title 3", "Test Author 3", "Test Content 3");
dapperExample.Delete(5);

Console.ReadKey();
