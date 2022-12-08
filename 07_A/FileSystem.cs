namespace _07_A;

public class FileSystem
{
    protected List<List<string>> _input;
    protected MyDirectory _filesystem;
    protected MyDirectory _currentDirectory;
    protected Stack<MyDirectory> _path;

    public FileSystem(string[] file)
    {
        _input = ParseInput(file);
        _filesystem = new MyDirectory("/");
        _currentDirectory = _filesystem;
        _path = new();
        _path.Push(_filesystem);

        ExecuteInput();
    }

    public MyDirectory GetFileSystem() => _filesystem;

    public List<List<string>> ParseInput(string[] file)
    {
        var input = new List<List<string>>();

        foreach (var line in file)
        {
            input.Add(line.Split(' ').ToList());
        }

        return input;
    }

    public void ExecuteInput()
    {
        foreach (var command in _input)
        {
            ExecuteCommand(command);
        }
    }

    public void ExecuteCommand(List<string> command)
    {
        switch (command)
        {
            case ["$", "cd", var directory]:
                ChangeDirectory(directory);
                break;

            case ["$", _]:
                break;

            case ["dir", var name]:
                AddDirectory(name);
                break;

            case [var size, var name]:
                AddFile(name, int.Parse(size));
                break;

            default:
                throw new Exception($"[{string.Join(' ', command)}] was not recognized!");
        }
    }

    public void ChangeDirectory(string argument)
    {
        MyDirectory? directory = null;

        switch (argument)
        {
            case "..":
                if (_path.Count <= 1)
                    break;

                _path.Pop();
                directory = _path.Peek();

                _currentDirectory = directory;
                break;

            case "/":
                _path.Clear();
                _path.Push(_filesystem);
                _currentDirectory = _filesystem;
                break;

            default:
                directory = _currentDirectory.Directories.FirstOrDefault(dir => dir.Name == argument) ?? AddDirectory(argument);

                _currentDirectory = directory;
                _path.Push(directory);
                break;
        }
    }

    public MyDirectory AddDirectory(string name)
    {
        if (_currentDirectory.Directories.Any(dir => dir.Name == name))
            return _currentDirectory.Directories.First(dir => dir.Name == name);

        var directory = new MyDirectory(name);
        _currentDirectory.Directories.Add(directory);

        return directory;
    }

    public MyFile AddFile(string name, int size)
    {
        if (_currentDirectory.Files.Any(file => file.Name == name))
            return _currentDirectory.Files.First(file => file.Name == name);

        var file = new MyFile(name, size);
        _currentDirectory.Files.Add(file);

        return file;
    }

    public int GetTotalSizeSmallerThanOrEqualToLimit(int limit, MyDirectory? directory = null)
    {
        var size = 0;
        directory ??= _filesystem;

        if (directory.IsBelowOrEqualToLimit(limit))
            size += directory.GetSize();

        foreach (var subDirectory in directory.Directories)
        {
            size += GetTotalSizeSmallerThanOrEqualToLimit(limit, subDirectory);
        }

        return size;
    }
}
