using System;
using System.Collections.ObjectModel;

namespace WpfSortApplication.SortAlgorithms
{
	/// <summary>
	/// Time Complexity:
	/// - Worst: O(n^2)
	/// - Average: Θ(nlog(n))
	/// - Best: Ω(nlog(n))
	/// Space Complexity: O(log(n))
	/// 
	/// Unstable
	/// Worst case behaviour is rare
	/// 
	/// </summary>
	public class QuickSort : SortAlgorithm
	{
		public QuickSort(ObservableCollection<Item> items)
			: base(items)
		{ }

		public override void Reset()
		{ }

		public override void Sort()
		{
			Sort(0, Items.Count - 1);
		}

		public override void SortStep()
		{
			throw new NotImplementedException();
		}

		private void Sort(int lowIndex, int highIndex)
		{
			if (lowIndex < highIndex)
			{
				int p = Partition(lowIndex, highIndex);
				Sort(lowIndex, p);
				Sort(p + 1, highIndex);
			}
		}

		private int Partition(int lowIndex, int highIndex)
		{
			Item pivot = Items[(lowIndex + highIndex) / 2];
			int i = lowIndex - 1;
			int j = highIndex + 1;

			while (true)
			{
				do
				{
					i++;
				} while (Items[i].Value < pivot.Value);

				do
				{
					j--;
				} while (Items[j].Value > pivot.Value);

				if (i >= j)
					return j;

				Swap(i, j);
			}
		}
	}
}
