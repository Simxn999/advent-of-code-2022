using _07_B;

var output = 0;
var filePath = @"..\..\..\input.txt";
var file = File.ReadAllLines(filePath);

//

var filesystem = new FileSystem(file);
var root = filesystem.GetFileSystem();
var totalSize = 70000000;
var updateSize = 30000000;
var rootSize = root.GetSize();
var unusedSize = totalSize - rootSize;
var requiredSizeLeft = updateSize - unusedSize;

output = filesystem.GetSmallestRemovableDirectory(requiredSizeLeft).GetSize();

//

Console.WriteLine();
Console.WriteLine($"""Answer = "{output}" """);
Console.WriteLine("Press [Q] to exit...");
while (Console.ReadKey(true).Key != ConsoleKey.Q) { }
