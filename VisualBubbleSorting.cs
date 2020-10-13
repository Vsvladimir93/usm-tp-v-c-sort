using System;
using System.Threading;

namespace VisualSorting
{
	sealed class VisualBubbleSorting
	{
		private static int TOP_Y = 1;
		private static int MID_Y = 2;
		private static int BOT_Y = 3;
		private static int ITER_TIME = 500;
		private static int SWAP_TIME = 150;

		private VisualBubbleSorting()
		{ }
		 
		public static void Sort(int[] array)
		{
			Console.Clear();

			int[] initialArrayState = new int[array.Length];
			Array.Copy(array, initialArrayState, array.Length);

			StartVisualSorting(array);

			Console.SetCursorPosition(0, 4);
			Console.WriteLine("{0} <- Initial array state.", string.Join(" ", initialArrayState));

		}

		public static int IterationTime
		{
			get { return ITER_TIME; }
			set { ITER_TIME = value < 0 || value > 2000 ? 500 : value; }
		}

		private static void StartVisualSorting(int[] array)
		{
			int cursorX = 0;

			printArray(array);
			for (int outerIndex = 0; outerIndex < array.Length; outerIndex++)
			{
				for (int index = 1; index < (array.Length - outerIndex); index++)
				{

					if (VisualCompare(index - 1, index, array, cursorX))
					{
						VisualSwap(index - 1, index, array, cursorX);
					}
					cursorX += array[index - 1].ToString().Length + 1;
				}
				cursorX = 0;
			}

		}

		private static void printArray(int[] array)
		{
			Console.Clear();
			Console.SetCursorPosition(0, MID_Y);
			Console.WriteLine(string.Join(" ", array));
		}

		private static bool VisualCompare(int index_1, int index_2, int[] array, int cursorX)
		{
			int firstValue = array[index_1];
			int secondValue = array[index_2];

			int secondValX = cursorX + firstValue.ToString().Length + 1;

			int numbersLength = firstValue.ToString().Length + secondValue.ToString().Length + 1;

			ShowCompare(cursorX, secondValX, numbersLength, firstValue, secondValue);
			return firstValue > secondValue;
		}

		private static void ShowCompare(int firstValX, int secondValX, int numbersLength, int firstValue, int secondValue)
		{
			ClearAt(firstValX, MID_Y, numbersLength);
			Console.ForegroundColor = ConsoleColor.DarkGreen;

			int firstY = TOP_Y;
			int secondY = BOT_Y;

			bool toggle = true;

			for (int counter = 0; counter < 3; counter++)
			{
				PrintAt(firstValX, firstY, firstValue);
				PrintAt(secondValX, secondY, secondValue);

				Thread.Sleep(ITER_TIME);

				ClearAt(firstValX, firstY, firstValue.ToString().Length);
				ClearAt(secondValX, secondY, secondValue.ToString().Length);

				if (toggle)
				{
					firstY = BOT_Y;
					secondY = TOP_Y;
				}
				else
				{
					firstY = TOP_Y;
					secondY = BOT_Y;
				}
				toggle = !toggle;
			}

			if (firstValue > secondValue)
			{
				PrintAt(firstValX, MID_Y, firstValue);
				PrintAt(secondValX, MID_Y, secondValue);
				Console.ForegroundColor = ConsoleColor.White;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.White;
				PrintAt(firstValX, MID_Y, firstValue);
				PrintAt(secondValX, MID_Y, secondValue);
			}
			
		}

		private static void VisualSwap(int index_1, int index_2, int[] array, int cursorX)
		{
			int firstValue = array[index_1];
			int secondValue = array[index_2];

			int secondValX = cursorX + firstValue.ToString().Length + 1;

			int numbersLength = firstValue.ToString().Length + secondValue.ToString().Length + 1;

			ShowSwap(cursorX, secondValX, numbersLength, firstValue, secondValue);
			array[index_1] = array[index_1] + array[index_2];
			array[index_2] = array[index_1] - array[index_2];
			array[index_1] = array[index_1] - array[index_2];
		}

		private static void ShowSwap(int firstValX, int secondValX, int numbersLength, int firstValue, int secondValue)
		{
			int firstValLength = firstValue.ToString().Length;
			int secondValLength = secondValue.ToString().Length;

			int firstMidX = firstValX + (firstValLength / 2);
			int secondMidX = firstValX + (secondValLength / 2);

			int secondValLengthDiff = secondValLength - firstValLength;

			Console.ForegroundColor = ConsoleColor.DarkBlue;

			ClearAt(firstValX, MID_Y, numbersLength);

			PrintAt(firstMidX, TOP_Y, firstValue);
			PrintAt(secondMidX, BOT_Y, secondValue);
			
			Thread.Sleep(SWAP_TIME);

			ClearAt(firstMidX, TOP_Y, firstValLength);
			ClearAt(secondMidX, BOT_Y, secondValLength);

			Console.ForegroundColor = ConsoleColor.White;

			PrintAt(firstValX, MID_Y, secondValue);
			PrintAt(secondValX + secondValLengthDiff, MID_Y, firstValue);

			Thread.Sleep(ITER_TIME);
		}

		private static void ClearAt(int posX, int posY, int length)
		{
			Console.SetCursorPosition(posX, posY);
			Console.Write(new string(' ', length));
		}

		private static void PrintAt(int posX, int posY, int num)
		{
			Console.SetCursorPosition(posX, posY);
			Console.Write(num);
		}

	}
}
