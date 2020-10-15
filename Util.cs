using System;

namespace VisualSorting
{
	sealed class Util
	{
		public static int GetNextInt(int min, int max)
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

	}
}
