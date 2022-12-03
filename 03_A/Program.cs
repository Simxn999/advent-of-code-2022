var output = 0;
var filePath = @"..\..\..\input.txt";
var file = File.ReadAllLines(filePath);

//

foreach (var line in file)
{
    var sharedItems = new List<char>();
    var compartments = new List<string>
    {
        line[..(line.Length / 2)],
        line[(line.Length / 2)..],
    };


    foreach (var item in compartments.First())
    {
        if (sharedItems.Contains(item) || !compartments.Last().Contains(item))
            continue;

        sharedItems.Add(item);
    }

    foreach (var item in sharedItems)
    {
        if (item >= 'a')
        {
            output += item - 'a' + 1;
        }
        else
        {
            output += item - 'A' + 27;
        }
    }
}

//

Console.WriteLine();
Console.WriteLine($"""Answer = "{output}" """);
Console.WriteLine("Press [Q] to exit...");
while (Console.ReadKey(true).Key != ConsoleKey.Q) { }
