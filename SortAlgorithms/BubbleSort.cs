using System.Collections.ObjectModel;

namespace WpfSortApplication.SortAlgorithms
{
	/// <summary>
	/// Time Complexity:
	/// - Worst: O(n^2)
	/// - Average: Θ(n^2)
	/// - Best: Ω(n)
	/// Space Complexity: O(1)
	/// 
	/// Stable
	/// Poor performance
	/// 
	/// </summary>
	public class BubbleSort : SortAlgorithm
	{
		public BubbleSort(ObservableCollection<Item> items)
			: base(items)
		{ }

		public override void Reset()
		{
			this.currentIndex = Items.Count;
		}

		public override void Sort()
		{
			int i = Items.Count;
			while (i > 1)
			{
				i = BubbleSortStep(i);
			}
		}

		public override void SortStep()
		{
			if (this.currentIndex <= 1)
				this.currentIndex = Items.Count;

			this.currentIndex = BubbleSortStep(this.currentIndex);
		}

		private int BubbleSortStep(int currentEndIndex)
		{
			int endIndex = 0;
			for (int j = 0; j < currentEndIndex - 1; j++)
			{
				if (Items[j].Value > Items[j + 1].Value)
				{
					Swap(j, j + 1);

					endIndex = j + 1;
				}
			}

			return endIndex;
		}
	}
}
