using _05_A;

var output = "";
var filePath = @"..\..\..\input.txt";
var file = File.ReadAllLines(filePath);

//

var crates = new Crates(file);
crates.RearrangeCrates();
output = crates.GetTopCrates();

//

Console.WriteLine();
Console.WriteLine($"""Answer = "{output}" """);
Console.WriteLine("Press [Q] to exit...");
while (Console.ReadKey(true).Key != ConsoleKey.Q) { }
