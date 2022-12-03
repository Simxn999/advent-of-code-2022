var output = 0;

//

var file = @"..\..\..\input.txt";
var input = File.ReadAllText(file).Split("\n\n");
var chunks = new List<int>();

foreach (var chunk in input)
{
    var chunkList = chunk.Split("\n").ToList().ConvertAll(line =>
    {
        _ = int.TryParse(line, out var number);
        return number;
    });
    chunks.Add(chunkList.Sum());
}

chunks.Sort();
chunks.Reverse();
for (int i = 0; i < 3; i++)
{
    output += chunks[i];
}

//

Console.WriteLine();
Console.WriteLine($"""Answer = "{output}" """);
Console.WriteLine("Press [Q] to exit...");
while (Console.ReadKey(true).Key != ConsoleKey.Q) { }