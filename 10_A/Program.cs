var output = 0;
var filePath = @"..\..\..\input.txt";
var file = File.ReadAllLines(filePath);

//

var cycles = new List<int>{ 1 };

foreach (var line in file)
{
    var input = line.Split(' ');

	switch (input)
	{
		case ["addx", string x]:
			for (int i = 0; i < 2; i++)
			{
				cycles.Add(i == 1 ? cycles.Last() + int.Parse(x) : cycles.Last());
			}
			break;

		case ["noop"]:
			cycles.Add(cycles.Last());
			break;

		default:
			throw new Exception("que?");
	}
}

for (int i = 20; i <= 220; i += 40)
{
	output += i * cycles[i - 1];
}

//

Console.WriteLine();
Console.WriteLine($"""Answer = "{output}" """);
Console.WriteLine("Press [Q] to exit...");
while (Console.ReadKey(true).Key != ConsoleKey.Q) { }
