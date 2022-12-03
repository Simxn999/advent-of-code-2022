var output = 0;

//

var inputFilePath = @"..\..\..\input.txt";
var file = File.ReadAllLines(inputFilePath);
var hands = new Dictionary<char, RockPaperScissor>
{
    { 'X', RockPaperScissor.Rock },
    { 'A', RockPaperScissor.Rock },
    { 'Y', RockPaperScissor.Paper },
    { 'B', RockPaperScissor.Paper },
    { 'C', RockPaperScissor.Scissor },
    { 'Z', RockPaperScissor.Scissor },
};

foreach (var line in file)
{
    var enemyMove = hands[line.First()];
    var myMove = hands[line.Last()];

    switch (myMove)
    {
        case RockPaperScissor.Rock:
            output += 1;
            output += enemyMove switch
            {
                RockPaperScissor.Rock => 3,
                RockPaperScissor.Scissor => 6,
                _ => 0
            };
            break;

        case RockPaperScissor.Paper:
            output += 2;
            output += enemyMove switch
            {
                RockPaperScissor.Paper => 3,
                RockPaperScissor.Rock => 6,
                _ => 0
            };
            break;

        case RockPaperScissor.Scissor:
            output += 3;
            output += enemyMove switch
            {
                RockPaperScissor.Scissor => 3,
                RockPaperScissor.Paper => 6,
                _ => 0
            };
            break;

        default:
            break;
    }
}

//

Console.WriteLine();
Console.WriteLine($"""Answer = "{output}" """);
Console.WriteLine("Press [Q] to exit...");
while (Console.ReadKey(true).Key != ConsoleKey.Q) { }

enum RockPaperScissor
{
    Rock,
    Paper,
    Scissor
}