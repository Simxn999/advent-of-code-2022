namespace _08_B;

public class Trees : _08_A.Trees
{
    public Trees(string[] file) : base(file) { }

    public int GetHighestScenicScore()
    {
        var trees = new List<int>();

        foreach (var tree in GetTrees())
        {
            trees.Add(GetScenicScore(tree.Key.x, tree.Key.y));
        }

        return trees.Max();
    }

    protected int GetScenicScore(int x, int y)
    {
        var scores = new Dictionary<string, int>()
        {
            { "left", 0 },
            { "right", 0 },
            { "top", 0 },
            { "bottom", 0 },
        };
        var tree = GetTrees()[(x, y)];

        var left = GetRow(x, y).Where(neighbour => neighbour.Key.x < x).Reverse().ToDictionary(tree => tree.Key, tree => tree.Value);
        var right = GetRow(x, y).Where(neighbour => neighbour.Key.x > x).ToDictionary(tree => tree.Key, tree => tree.Value);
        var top = GetColumn(x, y).Where(neighbour => neighbour.Key.y < y).Reverse().ToDictionary(tree => tree.Key, tree => tree.Value);
        var bottom = GetColumn(x, y).Where(neighbour => neighbour.Key.y > y).ToDictionary(tree => tree.Key, tree => tree.Value);

        foreach (var direction in scores.Keys)
        {
            Dictionary<(int x, int y), int> neighbours = direction switch
            {
                "left" => left,
                "right" => right,
                "top" => top,
                "bottom" => bottom,
                _ => throw new Exception("Que????"),
            };

            foreach (var neighbour in neighbours)
            {
                scores[direction]++;

                if (neighbour.Value >= tree)
                {
                    break;
                }
            }
        }

        var score = scores["left"] * scores["right"] * scores["top"] * scores["bottom"];

        return score;
    }
}
