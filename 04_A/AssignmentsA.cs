namespace _04_A;

public class AssignmentsA
{
    public static List<List<List<int>>> GetPairs(string[] file)
    {
        var output = new List<List<List<int>>>();

        foreach (var line in file)
        {
            var pair = new List<List<int>>();

            foreach (var elf in line.Split(','))
            {
                var range = elf.Split('-').ToList().ConvertAll(int.Parse);
                var first = range.First() + 1;
                var last = range.Last() - 1;

                for (int i = first; i <= last; i++)
                {
                    range.Add(i);
                }

                pair.Add(range);
            }

            output.Add(pair);
        }

        return output;
    }

    public static List<List<List<int>>> GetFullyOverlappingPairs(List<List<List<int>>> pairs)
    {
        return pairs.Where(pair =>        
            pair.First().All(pair.Last().Contains) ||
            pair.Last().All(pair.First().Contains)
        ).ToList();
    }
}
