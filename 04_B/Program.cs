using _04_A;
using _04_B;

var output = 0;
var filePath = @"..\..\..\input.txt";
var file = File.ReadAllLines(filePath);

//

var pairs = AssignmentsA.GetPairs(file);

output = AssignmentsB.GetOverlappingPairs(pairs).Count;

//

Console.WriteLine();
Console.WriteLine($"""Answer = "{output}" """);
Console.WriteLine("Press [Q] to exit...");
while (Console.ReadKey(true).Key != ConsoleKey.Q) { }
