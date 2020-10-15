namespace VisualSorting.Sorting
{
	class QuickSort : VisualIntSort
	{
		private int[] array;
		private ConsoleVisualizer visualizer;
		
		int[] VisualIntSort.Array { get => array; set => array = value; }
		ConsoleVisualizer VisualIntSort.Visualizer { get => visualizer; set => visualizer = value; }

		void VisualIntSort.SortImplementation()
		{

			VisualIntSort iSort = this;
			QuickSortImpl(array, 0, array.Length - 1, iSort);
		}

		private void QuickSortImpl(int[] array, int start, int end, VisualIntSort iSort) 
		{
			int low = start;
			int high = end;
			int pivot = low;

			do
			{
				while (iSort.Compare(low, pivot, true)) low++;
				while (iSort.Compare(high, pivot)) high--;
				if (low <= high)
				{
					iSort.Swap(low, high);
					low++; high--;
				}
			} while (low <= high);

			if (start < high) QuickSortImpl(array, start, high, iSort);
			if (low < end) QuickSortImpl(array, low, end, iSort);
		}
	}
}
