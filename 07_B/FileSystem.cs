using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _07_A;

namespace _07_B;

public class FileSystem : _07_A.FileSystem
{
	public FileSystem(string[] file) : base(file) { }

	public MyDirectory GetSmallestRemovableDirectory(int requiredSize)
	{
		var directories = GetAllDirectories();
		directories = directories.OrderBy(dir => dir.GetSize()).ToList();

		return directories.First(dir => dir.GetSize() >= requiredSize);
	}

	public List<MyDirectory> GetAllDirectories(MyDirectory? directory = null)
	{
		var directories = new List<MyDirectory>();
		directory ??= _filesystem;

		directories.Add(directory);

		foreach (var subDirectory in directory.Directories)
		{
			directories.AddRange(GetAllDirectories(subDirectory));
		}

		return directories;
	}
}
