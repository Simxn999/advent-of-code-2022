using System.Text;

namespace _05_B;

public class Crates : _05_A.Crates
{
	public Crates(string[] file) : base(file) { }

    void Step(int count, int from, int to)
    {
        var crates = new List<char>();

        while (count > 0)
        {
            crates.Add(_crates[from].Pop());

            count--;
        }

        crates.Reverse();

        foreach (var crate in crates)
        {
            _crates[to].Push(crate);
        }
    }

    public new void RearrangeCrates()
    {
        foreach (var (count, from, to) in _input)
        {
            Step(count, from, to);
        }
    }
}
