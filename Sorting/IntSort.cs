namespace VisualSorting.Sorting
{
	public class IntSort
	{
		private int[] array;
		private bool isAscending;

		public void StartSort(int[] array, bool isAscending)
		{
			this.array = array;
			this.isAscending = isAscending;
			Sort();
		}

		protected void Sort()
		{
			for (int outerIndex = 0; outerIndex < array.Length; outerIndex++)
			{
				for (int index = 1; index < (array.Length - outerIndex); index++)
				{
					Iteration(index - 1, index);
				}
			}
		}

		protected void Iteration(int index_1, int index_2)
		{
			Visualizer.VisualCompare(index_1, index_2, array);
			if (Compare(index_1, index_2))
			{
				Visualizer.VisualSwap(index_1, index_2, array);
				Swap(index_1, index_2);
			}
		}

		private bool Compare(int index_1, int index_2)
		{
			return isAscending ? array[index_1] > array[index_2] : array[index_1] < array[index_2];
		}

		private void Swap(int index_1, int index_2)
		{
			array[index_1] = array[index_1] + array[index_2];
			array[index_2] = array[index_1] - array[index_2];
			array[index_1] = array[index_1] - array[index_2];
		}

	}
}
