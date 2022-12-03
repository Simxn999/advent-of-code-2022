var output = 0;
var filePath = @"..\..\..\input.txt";
var file = File.ReadAllLines(filePath);

//



//

Console.WriteLine();
Console.WriteLine($"""Answer = "{output}" """);
Console.WriteLine("Press [Q] to exit...");
while (Console.ReadKey(true).Key != ConsoleKey.Q) { }
