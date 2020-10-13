using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VisualSorting.Sorting;

namespace VisualSorting
{
	class Program
	{
		static void Main(string[] args)
		{
			CheckForArgs(args);
			Console.SetWindowSize(135, 20);
			Console.WriteLine();
			int[] array = ArrayGenerator.GetArray();
			AskForStart(array);

			VisualBubbleSorting.Sort(array);
		}

		private static void AskForStart(int[] array)
		{
			Console.Clear();
			Console.WriteLine("Array: [{0}]", string.Join(", ", array));
			Console.WriteLine("Press Enter to start");
			Console.Read();
		}

		private static void CheckForArgs(string[] args)
		{
			foreach (string arg in args)
			{
				if (arg.Contains("-it"))
				{
					try
					{
						int iterTime = int.Parse(arg.Split("=")[1].Trim());
						VisualBubbleSorting.IterationTime = iterTime;
					}
					catch (Exception e)
					{
						Console.WriteLine("Wrong argument value." + arg);
					}
				}
			}

		}

	}
}
