var output = 0;
var filePath = @"..\..\..\input.txt";
var file = File.ReadAllLines(filePath);

//

for (int i = 0; i < file.Length; i += 3)
{
    var group = new List<string>
    {
        file[i],
        file[i + 1],
        file[i + 2],
    };

    var item = group.First().First(rucksackItem => group.All(rucksack => rucksack.Contains(rucksackItem)));

    if (item >= 'a')
    {
        output += item - 'a' + 1;
    }
    else
    {
        output += item - 'A' + 27;
    }
}

//

Console.WriteLine();
Console.WriteLine($"""Answer = "{output}" """);
Console.WriteLine("Press [Q] to exit...");
while (Console.ReadKey(true).Key != ConsoleKey.Q) { }
