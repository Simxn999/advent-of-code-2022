using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_A;

public class Crates
{
	protected Dictionary<int, Stack<char>> _crates;
    protected List<(int count, int from, int to)> _input;

	public Crates(string[] file)
	{
        _crates = ParseCrates(file);
        _input = ParseInput(file);
    }

    Dictionary<int, Stack<char>> ParseCrates(string[] file)
    {
        if (_crates is not null) return _crates;

        var crates = new Dictionary<int, Stack<char>>
        {
            { 1, new() },
            { 2, new() },
            { 3, new() },
            { 4, new() },
            { 5, new() },
            { 6, new() },
            { 7, new() },
            { 8, new() },
            { 9, new() },
        };

        foreach (var item in crates.Keys)
        {
            var x = file[8].IndexOf(item.ToString());

            for (int y = 7; y >= 0; y--)
            {
                var crate = file[y][x];

                if (crate == ' ')
                    continue;

                crates[item].Push(crate);
            }
        }

        return crates;
    }

    List<(int count, int from, int to)> ParseInput(string[] file)
    {
        if (_input is not null)
            return _input;

        var input = new List<(int count, int from, int to)>();

        for (int y = 10; y < file.Length; y++)
        {
            var line = file[y].Split(' ');
            var count = int.Parse(line[1]);
            var from= int.Parse(line[3]);
            var to= int.Parse(line[5]);

            input.Add((count, from, to));
        }

        return input;
    }

    void Move(int from, int to)
    {
        var crate = _crates[from].Pop();

        _crates[to].Push(crate);
    }

    void Step(int count, int from, int to)
    {
        while (count > 0)
        {
            Move(from, to);

            count--;
        }
    }

    public Dictionary<int, Stack<char>> GetCrates() => _crates;

    public string GetTopCrates()
    {
        var stringBuilder = new StringBuilder();

        foreach (var stack in _crates.Values)
        {
            if (!stack.TryPeek(out var crate))
                continue;

            stringBuilder.Append(crate);
        }

        return stringBuilder.ToString();
    }

    public void RearrangeCrates()
    {
        foreach (var (count, from, to) in _input)
        {
            Step(count, from, to);
        }
    }
}
