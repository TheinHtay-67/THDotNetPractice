// See https://aka.ms/new-console-template for more information
using THDotNetPractice.ConsoleApp.AdoDotNetExamples;
using THDotNetPractice.ConsoleApp.DapperExamples;
using THDotNetPractice.ConsoleApp.EFCoreExamples;

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
////adoDotNetExample.Read();
////adoDotNetExample.Edit(2);
////adoDotNetExample.Create("Test Title", "Test Author" , "Test Content");
////adoDotNetExample.Update(3, "Test Title 3", "Test Author 3" , "Test Content 3");
//adoDotNetExample.Delete(3);

//DapperExample dapperExample = new DapperExample();
////dapperExample.Read();
////dapperExample.Edit(1);
////dapperExample.Create("Test Title 2", "Test Author 2", "Test Content 2");
////dapperExample.Update(5, "Test Title 3", "Test Author 3", "Test Content 3");
//dapperExample.Delete(5);

EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Edit(1);
//eFCoreExample.Create("Test Title 4", "Test Author 4", "Test Content 4");
//eFCoreExample.Update(7, "Test Title 3", "Test Author 3", "Test Content 3");
eFCoreExample.Delete(6);


Console.ReadKey();
