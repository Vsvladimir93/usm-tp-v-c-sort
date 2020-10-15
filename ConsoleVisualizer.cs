using System;
using System.Collections.Generic;
using System.Threading;

namespace VisualSorting
{
	public sealed class ConsoleVisualizer
	{

		private readonly int WINDOW_WIDTH = 135;
		private readonly int LINE_HEIGHT = 3;

		private readonly ConsoleColor COMPARE_COLOR = ConsoleColor.Green;
		private readonly ConsoleColor SWAP_FORE_COLOR = ConsoleColor.DarkCyan;
		private readonly ConsoleColor SWAP_BACK_FIRST = ConsoleColor.Magenta;
		private readonly ConsoleColor SWAP_BACK_SECOND = ConsoleColor.Green;
		private readonly ConsoleColor DEFAULT_BACK_COLOR = ConsoleColor.Black;
		private readonly ConsoleColor DEFAULT_FORE_COLOR = ConsoleColor.White;

		private int[] array;
		private int lineCapacity;
		private int elementWidth;
		private int operationTime = 150;

		public ConsoleVisualizer(int[] array, int elementWidth, int operationTime)
		{
			this.array = array;
			this.elementWidth = elementWidth;
			this.operationTime = operationTime;
			lineCapacity = WINDOW_WIDTH / elementWidth;

			Console.SetWindowSize(WINDOW_WIDTH, 20);
		}
		public void PrintArray()
		{
			Console.Clear();
			KeyValuePair<int, int> position;

			for (int index = 0; index < array.Length; index++)
			{
				position = GetPosition(index);
				Console.SetCursorPosition(position.Key, position.Value);
				Console.Write("{0," + elementWidth + "} ", array[index]);
			}
		}

		public void VisualCompare(int index_1, int index_2)
		{
			if (index_1 == index_2) return;

			KeyValuePair<int, int> xy_1 = GetPosition(index_1);
			KeyValuePair<int, int> xy_2 = GetPosition(index_2);

			ClearAt(xy_1.Key, xy_1.Value);
			ClearAt(xy_2.Key, xy_2.Value);

			Console.ForegroundColor = COMPARE_COLOR;
			PrintAt(xy_1.Key, xy_1.Value - 1, array[index_1]);
			PrintAt(xy_2.Key, xy_2.Value + 1, array[index_2]);

			Thread.Sleep(operationTime);

			ClearAt(xy_1.Key, xy_1.Value - 1);
			ClearAt(xy_2.Key, xy_2.Value + 1);

			PrintAt(xy_1.Key, xy_1.Value + 1, array[index_1]);
			PrintAt(xy_2.Key, xy_2.Value - 1, array[index_2]);

			Thread.Sleep(operationTime);

			ClearAt(xy_1.Key, xy_1.Value + 1);
			ClearAt(xy_2.Key, xy_2.Value - 1);

			PrintAt(xy_1.Key, xy_1.Value - 1, array[index_1]);
			PrintAt(xy_2.Key, xy_2.Value + 1, array[index_2]);

			Thread.Sleep(operationTime);

			ClearAt(xy_1.Key, xy_1.Value - 1);
			ClearAt(xy_2.Key, xy_2.Value + 1);
			Console.ForegroundColor = DEFAULT_FORE_COLOR;

			PrintAt(xy_1.Key, xy_1.Value, array[index_1]);
			PrintAt(xy_2.Key, xy_2.Value, array[index_2]);

			Thread.Sleep(operationTime);

		}
		public void VisualSwap(int index_1, int index_2)
		{
			KeyValuePair<int, int> xy_1 = GetPosition(index_1);
			KeyValuePair<int, int> xy_2 = GetPosition(index_2);

			ClearAt(xy_1.Key, xy_1.Value);
			ClearAt(xy_2.Key, xy_2.Value);

			Console.ForegroundColor = SWAP_FORE_COLOR;
			Console.BackgroundColor = SWAP_BACK_FIRST;
			PrintAt(xy_1.Key, xy_1.Value + 1, array[index_1]);
			Console.BackgroundColor = SWAP_BACK_SECOND;
			PrintAt(xy_2.Key, xy_2.Value + 1, array[index_2]);

			Thread.Sleep(operationTime);

			Console.BackgroundColor = DEFAULT_BACK_COLOR;
			Console.ForegroundColor = DEFAULT_FORE_COLOR;
			PrintAt(xy_1.Key, xy_1.Value + 1, array[index_1]);
			PrintAt(xy_2.Key, xy_2.Value + 1, array[index_2]);

			Thread.Sleep(operationTime);

			Console.ForegroundColor = SWAP_FORE_COLOR;
			Console.BackgroundColor = SWAP_BACK_FIRST;
			PrintAt(xy_1.Key, xy_1.Value + 1, array[index_1]);
			Console.BackgroundColor = SWAP_BACK_SECOND;
			PrintAt(xy_2.Key, xy_2.Value + 1, array[index_2]);

			Thread.Sleep(operationTime);

			Console.BackgroundColor = DEFAULT_BACK_COLOR;
			Console.ForegroundColor = DEFAULT_FORE_COLOR;

			ClearAt(xy_1.Key, xy_1.Value + 1);
			ClearAt(xy_2.Key, xy_2.Value + 1);

			Console.ForegroundColor = SWAP_FORE_COLOR;
			Console.BackgroundColor = SWAP_BACK_FIRST;
			PrintAt(xy_2.Key, xy_2.Value, array[index_1]);
			Console.BackgroundColor = SWAP_BACK_SECOND;
			PrintAt(xy_1.Key, xy_1.Value, array[index_2]);

			Thread.Sleep(operationTime);

			Console.ForegroundColor = DEFAULT_FORE_COLOR;
			Console.BackgroundColor = SWAP_BACK_FIRST;
			PrintAt(xy_2.Key, xy_2.Value, array[index_1]);
			Console.BackgroundColor = SWAP_BACK_SECOND;
			PrintAt(xy_1.Key, xy_1.Value, array[index_2]);

			Thread.Sleep(operationTime);

			Console.ForegroundColor = DEFAULT_FORE_COLOR;
			Console.BackgroundColor = DEFAULT_BACK_COLOR;
			PrintAt(xy_2.Key, xy_2.Value, array[index_1]);
			PrintAt(xy_1.Key, xy_1.Value, array[index_2]);

			Thread.Sleep(operationTime);
		}

		private KeyValuePair<int, int> GetPosition(int index)
		{
			int x = (index % lineCapacity) * elementWidth;
			int y = (index / lineCapacity) * LINE_HEIGHT;

			return KeyValuePair.Create(x, y + 1);
		}

		private void ClearAt(int posX, int posY)
		{
			Console.SetCursorPosition(posX, posY);
			Console.Write(new string(' ', elementWidth));
		}

		private void PrintAt(int posX, int posY, int num)
		{
			Console.SetCursorPosition(posX, posY);
			Console.Write("{0," + elementWidth + "}", num);
		}

	}
}
