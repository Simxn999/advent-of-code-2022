namespace _08_A;

public class Trees
{
    protected string[] _file;
    protected Dictionary<(int x, int y), int>? _trees;
    protected Dictionary<(int x, int y), int>? _visibleTrees;
    protected int _xMax, _yMax;

    public Trees(string[] file)
	{
        _file = file;
        _xMax = file[0].Length;
        _yMax = file.Length;
	}

    public Dictionary<(int x, int y), int> GetTrees()
    {
        return _trees ?? ParseInput(_file);
    }

    public Dictionary<(int x, int y), int> GetVisibleTrees()
    {
        return _visibleTrees ?? CalculateVisibleTrees();
    }

    protected Dictionary<(int x, int y), int> ParseInput(string[] file)
    {
        var trees = new Dictionary<(int x, int y), int>();

        for (int y = 0; y < _yMax; y++)
        {
            var row = file[y].ToList().ConvertAll(tree => int.Parse(tree.ToString()));
            for (int x = 0; x < _xMax; x++)
            {
                trees.Add((x, y), row[x]);
            }
        }

        return trees;
    }

    protected Dictionary<(int x, int y), int> CalculateVisibleTrees()
    {
        var visibleTrees = new Dictionary<(int x, int y), int>();

        foreach (var tree in GetTrees())
        {
            var height = tree.Value;
            var x = tree.Key.x;
            var y = tree.Key.y;
            var row = GetRow(x, y);
            var column = GetColumn(x, y);

            if (x == 0 ||
                y == 0 ||
                x == _xMax ||
                y == _yMax ||
                !row.Any(neighbour => neighbour.Value >= height && neighbour.Key.x < x) ||
                !row.Any(neighbour => neighbour.Value >= height && neighbour.Key.x > x) ||
                !column.Any(neighbour => neighbour.Value >= height && neighbour.Key.y < y) ||
                !column.Any(neighbour => neighbour.Value >= height && neighbour.Key.y > y))
            {
                visibleTrees.Add((x, y), height);
            }
        }

        return visibleTrees;
    }

    protected Dictionary<(int x, int y), int> GetRow(int x, int y)
    {
        return GetTrees().Where(tree => tree.Key.y == y && tree.Key.x != x)
                         .ToDictionary(tree => tree.Key, tree => tree.Value);
    }

    protected Dictionary<(int x, int y), int> GetColumn(int x, int y)
    {
        return GetTrees().Where(tree => tree.Key.x == x && tree.Key.y != y)
                         .ToDictionary(tree => tree.Key, tree => tree.Value);
    }
}
