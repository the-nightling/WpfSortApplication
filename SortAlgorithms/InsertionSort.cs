using System.Collections.ObjectModel;

namespace WpfSortApplication.SortAlgorithms
{
	/// <summary>
	/// Time Complexity:
	/// - Worse: O(n^2)
	/// - Average: Θ(n^2)
	/// - Best: Ω(n)
	/// Space Complexity: O(1)
	/// 
	/// Stable
	/// 
	/// </summary>
	public class InsertionSort : SortAlgorithm
	{
		public InsertionSort(ObservableCollection<Item> items)
			: base(items)
		{ }

		public override void Reset()
		{
			this.currentIndex = 1;
		}

		public override void Sort()
		{
			for (int i = 1; i < Items.Count; i++)
				InsertionSortStep(i);
		}

		public override void SortStep()
		{
			if (this.currentIndex >= Items.Count)
				this.currentIndex = 1;

			InsertionSortStep(this.currentIndex);

			this.currentIndex++;
		}

		private void InsertionSortStep(int i)
		{
			Item itemToInsert = Items[i];

			int j = i - 1;
			while (j >= 0 && Items[j].Value > itemToInsert.Value)
			{
				Items[j + 1] = Items[j];
				j--;
			}

			Items[j + 1] = itemToInsert;
		}
	}
}
