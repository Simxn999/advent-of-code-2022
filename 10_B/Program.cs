var output = 0;
var filePath = @"..\..\..\input.txt";
var file = File.ReadAllLines(filePath);

//

var _x = 1;
var cycles = new List<string>();

foreach (var line in file)
{
    var input = line.Split(' ');

    switch (input)
    {
        case ["addx", string x]:
            for (int i = 0; i < 2; i++)
            {
                cycles.Add(IsInSprite(cycles.Count) ? "##" : "  ");

                if (i == 1)
                    _x += int.Parse(x);
            }
            break;

        case ["noop"]:
            cycles.Add(IsInSprite(cycles.Count) ? "##" : "  ");
            break;

        default:
            throw new Exception("que?");
    }
}

for (int i = 1; i <= cycles.Count; i++)
{
    Console.Write(cycles[i - 1]);

    if (i % 40 == 0)
        Console.WriteLine();
}

//

Console.WriteLine();
Console.WriteLine("Press [Q] to exit...");
while (Console.ReadKey(true).Key != ConsoleKey.Q) { }

bool IsInSprite(int pixel)
{
    pixel -= pixel / 40 * 40;
    return pixel >= _x - 1 && pixel <= _x + 1;
}