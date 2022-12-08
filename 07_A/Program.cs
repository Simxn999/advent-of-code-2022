using _07_A;

var output = 0;
var filePath = @"..\..\..\input.txt";
var file = File.ReadAllLines(filePath);

//

var filesystem = new FileSystem(file);
output = filesystem.GetTotalSizeSmallerThanOrEqualToLimit(100000);

//

Console.WriteLine();
Console.WriteLine($"""Answer = "{output}" """);
Console.WriteLine("Press [Q] to exit...");
while (Console.ReadKey(true).Key != ConsoleKey.Q) { }