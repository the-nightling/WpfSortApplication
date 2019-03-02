using System.Collections.ObjectModel;

namespace WpfSortApplication.SortAlgorithms
{
	/// <summary>
	/// Time Complexity:
	/// - Worse: O(n^2)
	/// - Average: Θ(n^2)
	/// - Best: Ω(n^2)
	/// Space Complexity: O(1)
	/// 
	/// Stable
	/// Worse than Insertion Sort but results in
	/// less memory writes
	/// 
	/// </summary>
	public class SelectionSort : SortAlgorithm
	{
		public SelectionSort(ObservableCollection<Item> items)
			: base(items)
		{ }

		public override void Reset()
		{
			this.currentIndex = 0;
		}

		public override void Sort()
		{
			for (int i = 0; i < Items.Count - 1; i++)
				SelectionSortStep(i);
		}

		public override void SortStep()
		{
			if (this.currentIndex >= Items.Count - 1)
				this.currentIndex = 0;

			SelectionSortStep(this.currentIndex);

			this.currentIndex++;
		}

		private void SelectionSortStep(int i)
		{
			int minIndex = FindMinIndex(i);

			if (minIndex != i)
			{
				Item tempItem = Items[i];
				Items[i] = Items[minIndex];
				Items[minIndex] = tempItem;
			}
		}

		int FindMinIndex(int arrayStartIndex)
		{
			int minIndex = arrayStartIndex;
			for (int i = arrayStartIndex + 1; i < Items.Count; i++)
			{
				if (Items[i].Value < Items[minIndex].Value)
					minIndex = i;
			}

			return minIndex;
		}
	}
}
