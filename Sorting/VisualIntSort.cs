namespace VisualSorting.Sorting
{
	public interface VisualIntSort
	{
		protected abstract int[] Array { get; set; }
		protected abstract ConsoleVisualizer Visualizer { get; set; }

		public void VisualSort(int[] array, ConsoleVisualizer visualizer)
		{
			this.Array = array;
			this.Visualizer = visualizer;
			visualizer.PrintArray();
			SortImplementation();
		}

		protected abstract void SortImplementation();		

		bool Compare(int index_1, int index_2, bool reverse = false)
		{
			Visualizer.VisualCompare(index_1, index_2);
			return reverse ? Array[index_1] < Array[index_2] : Array[index_1] > Array[index_2];
		}

		void Swap(int index_1, int index_2)
		{		
			if (Array[index_1] == Array[index_2]) return;

			Visualizer.VisualSwap(index_1, index_2);
			Array[index_1] = Array[index_1] + Array[index_2];
			Array[index_2] = Array[index_1] - Array[index_2];
			Array[index_1] = Array[index_1] - Array[index_2];
		}

	}
}
