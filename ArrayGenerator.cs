using System;
using System.Globalization;

namespace VisualSorting
{
	sealed class ArrayGenerator
	{
		private ArrayGenerator() { }

		private const int MIN_NUMBER = -9_999;
		private const int MAX_NUMBER = 99_999;
		private const int MAX_ARRAY_SIZE = 1000;

		public static int[] GetArray()
		{
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
			return GetNextInt(2, MAX_ARRAY_SIZE);
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
				/* Restrict max number length to 5 */
				array[i] = GetNextInt(MIN_NUMBER, MAX_NUMBER);
			}

			return array;
		}

		private static int GetNextInt(int min, int max)
		{
			try
			{
				int number = int.Parse(Console.ReadLine());
				if (number < min || number > max)
				{
					Console.WriteLine(" - Please enter number between range {0} and {1}", min, max);
					return GetNextInt(min, max);
				}
				else
				{
					return number;
				}
			}
			catch (Exception e)
			{
				if (e is FormatException)
				{
					Console.WriteLine(" - Is not a number!");
				}
				else if (e is OverflowException)
				{
					Console.WriteLine(" - Please enter value in range between {0} and {1}", int.MinValue, int.MaxValue);
				}
				else
				{
					Console.WriteLine(" - Oops!");
				}

				return GetNextInt(min, max);
			}
		}

		private static int[] RandomIntArray(int arraySize)
		{
			int[] array = new int[arraySize];
			Random rand = new Random();

			for (int i = 0; i < arraySize; i++)
			{
				array[i] = rand.Next(MIN_NUMBER, MAX_NUMBER);
			}

			return array;
		}

	}
}
