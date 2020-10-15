using System;
using System.Collections.Generic;

namespace VisualSorting
{
	sealed class ArrayGenerator
	{
		private ArrayGenerator() { }

		private const int MAX_ARRAY_SIZE = 1000;

		private static int minNumber = 0;
		private static int maxNumber = 0;

		public static int[] GetArray(int elementWidth)
		{
			KeyValuePair<int, int> range = GetRangeByLength(elementWidth);

			ArrayGenerator.minNumber = range.Key;
			ArrayGenerator.maxNumber = range.Value;

			if (IsManuallyGenerationType())
			{
				return GetManuallyIntArray(RequestArraySize());
			}
			else
			{
				return RandomIntArray(RequestArraySize());
			}
		}

		private static int RequestArraySize()
		{
			Console.Write("Please enter array size: ");
			return Util.GetNextInt(2, MAX_ARRAY_SIZE);
		}

		private static bool IsManuallyGenerationType()
		{
			bool requested = false;
			ConsoleKey key = ConsoleKey.Escape;
			Console.WriteLine("Do you want to enter array values manually? Please press Y or N.");
			while (!requested)
			{
				Console.SetCursorPosition(0, 2);
				key = Console.ReadKey().Key;
				if (key.Equals(ConsoleKey.Y) || key.Equals(ConsoleKey.N))
				{
					requested = true;
				}

				Console.Write(" - Wrong key pressed. Please enter Y or N.", key.ToString(), requested);
			}
			Console.Clear();
			return key.Equals(ConsoleKey.Y);
		}

		private static int[] GetManuallyIntArray(int arraySize)
		{
			int[] array = new int[arraySize];
			for (int i = 0; i < arraySize; i++)
			{
				Console.Clear();
				Console.WriteLine("Enter {0}{1}int values. [{2}]",
					(arraySize - i),
					(i == 0 ? " " : " more "),
					string.Join(", ", array));
				array[i] = Util.GetNextInt(minNumber, maxNumber);
			}

			return array;
		}

		private static KeyValuePair<int, int> GetRangeByLength(int elementLength)
		{
			int max = int.Parse(new String('9', elementLength - 1));
			int min = -(max / 10);

			return KeyValuePair.Create(min, max);
		}

		private static int[] RandomIntArray(int arraySize)
		{
			int[] array = new int[arraySize];
			Random rand = new Random();

			for (int i = 0; i < arraySize; i++)
			{
				array[i] = rand.Next(minNumber, maxNumber);
			}

			return array;
		}

	}
}
