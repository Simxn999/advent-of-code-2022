using _04_A;

var output = 0;
var filePath = @"..\..\..\input.txt";
var file = File.ReadAllLines(filePath);

//

var pairs = AssignmentsA.GetPairs(file);

output = AssignmentsA.GetFullyOverlappingPairs(pairs).Count;

//

Console.WriteLine();
Console.WriteLine($"""Answer = "{output}" """);
Console.WriteLine("Press [Q] to exit...");
while (Console.ReadKey(true).Key != ConsoleKey.Q) { }
