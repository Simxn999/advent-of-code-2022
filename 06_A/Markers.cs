namespace _06_A;

public class Markers
{
    readonly string _input;

	public Markers(string[] file)
	{
		_input = ParseInput(file);
	}

    static string ParseInput(string[] file) => file[0];

	public int GetProcessedCharactersCount(int distinct)
	{
        var lastFourCharacters = new Queue<char>();

        for (int i = 0; i < _input.Length; i++)
        {
            var character = _input[i];

            if (lastFourCharacters.Count >= distinct)
                lastFourCharacters.Dequeue();

            lastFourCharacters.Enqueue(character);

            if (lastFourCharacters.Distinct().Count() == distinct)
            {
                return i + 1;
            }
        }

        return 0;
    }
}
