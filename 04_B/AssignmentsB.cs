namespace _04_B;

public class AssignmentsB
{
    public static List<List<List<int>>> GetOverlappingPairs(List<List<List<int>>> pairs)
    {
        return pairs.Where(pair =>
            pair.First().Any(pair.Last().Contains) ||
            pair.Last().Any(pair.First().Contains)
        ).ToList();
    }
}
