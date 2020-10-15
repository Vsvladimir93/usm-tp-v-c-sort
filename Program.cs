using System;
using System.Threading;
using VisualSorting.Sorting;

namespace VisualSorting
{
	class Program
	{
		static void Main(string[] args)
		{
			int elementWidth = 6;
			int operationTime = 100;
			int[] array = ArrayGenerator.GetArray(elementWidth);	

			ConsoleVisualizer visualizer = new ConsoleVisualizer(array, elementWidth, operationTime);

			VisualIntSort iSort = GetSortImplementation();

			AskForStart(array);

			iSort.VisualSort(array, visualizer);

			Thread.Sleep(60_000);
		}

		private static void AskForStart(int[] array)
		{
			Console.Clear();
			Console.WriteLine("Array: [{0}]", string.Join(", ", array));
			Console.WriteLine("Press Enter to start");
			Console.Read();
		}

		private static VisualIntSort GetSortImplementation()
		{
			Console.Clear();

			Console.WriteLine("Please select sort implementation: ");
			Console.WriteLine("1: Bubble sort algorithm.");
			Console.WriteLine("2: Quick sort algorithm.");

			int choice = Util.GetNextInt(1, 2);

			switch (choice)
			{
				case 2:
					return new QuickSort();
				default:
					return new BubbleSort();
			}
		}

	}
}
