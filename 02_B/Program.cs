var output = 0;

//

var inputFilePath = @"..\..\..\input.txt";
var file = File.ReadAllLines(inputFilePath);
var rockPaperScissor = new Dictionary<char, RockPaperScissor>
{
    { 'X', RockPaperScissor.Loss },
    { 'Y', RockPaperScissor.Draw },
    { 'Z', RockPaperScissor.Win },
    { 'A', RockPaperScissor.Rock },
    { 'B', RockPaperScissor.Paper },
    { 'C', RockPaperScissor.Scissor },
};

foreach (var line in file)
{
    var enemyMove = rockPaperScissor[line.First()];
    var outcome = rockPaperScissor[line.Last()];

    switch (outcome)
    {
        case RockPaperScissor.Loss:
            output += enemyMove switch
            {
                RockPaperScissor.Rock => 3,
                RockPaperScissor.Paper => 1,
                RockPaperScissor.Scissor => 2,
                _ => 0
            };
            break;

        case RockPaperScissor.Draw:
            output += 3;
            output += enemyMove switch
            {
                RockPaperScissor.Rock => 1,
                RockPaperScissor.Paper => 2,
                RockPaperScissor.Scissor => 3,
                _ => 0
            };
            break;

        case RockPaperScissor.Win:
            output += 6;
            output += enemyMove switch
            {
                RockPaperScissor.Rock => 2,
                RockPaperScissor.Paper => 3,
                RockPaperScissor.Scissor => 1,
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
    Scissor,
    Win,
    Draw,
    Loss
}