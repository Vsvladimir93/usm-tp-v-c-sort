namespace VisualSorting.Sorting
{
	class BubbleSort : VisualIntSort
	{
		private int[] array;
		private ConsoleVisualizer visual;

		int[] VisualIntSort.Array { get => array; set => array = value; }
		ConsoleVisualizer VisualIntSort.Visualizer { get => visual; set => visual = value; }

		void VisualIntSort.SortImplementation()
		{
			for (int outerIndex = 0; outerIndex < array.Length; outerIndex++)
			{
				for (int index = 1; index < (array.Length - outerIndex); index++)
				{
					VisualIntSort iSort = this;
					if (iSort.Compare(index - 1, index)) 
					{
						iSort.Swap(index - 1, index);
					}
				}
			}
		}
	}
}
