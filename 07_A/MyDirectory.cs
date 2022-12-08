namespace _07_A;

public class MyDirectory
{
    public string Name;
    public List<MyDirectory> Directories;
    public List<MyFile> Files;

    public MyDirectory(string name)
    {
        Name = name;
        Directories = new();
        Files = new();
    }

    public int GetSize()
    {
        var size = Files.Sum(file => file.Size);

        foreach (var directory in Directories)
        {
            size += directory.GetSize();
        }

        return size;
    }

    public bool IsBelowOrEqualToLimit(int limit) => GetSize() <= limit;
}
