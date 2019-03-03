using System;
using System.Collections.ObjectModel;

namespace WpfSortApplication.SortAlgorithms
{
	/// <summary>
	/// Time Complexity:
	/// - Worst: O(nlog(n))
	/// - Average: Θ(nlog(n))
	/// - Best: Ω(nlog(n))
	/// Space Complexity: O(n)
	/// 
	/// Stable
	/// Highly parallelizable
	/// 
	/// </summary>
	public class MergeSort : SortAlgorithm
	{
		public MergeSort(ObservableCollection<Item> items)
			: base(items)
		{ }

		public override void Reset()
		{ }

		public override void Sort()
		{
			ObservableCollection<Item> itemsCopy = new ObservableCollection<Item>(Items);

			TopDownSplitMerge(itemsCopy, 0, Items.Count, Items);
		}

		public override void SortStep()
		{
			throw new NotImplementedException();
		}

		private void TopDownSplitMerge(ObservableCollection<Item> itemsCopy, int startIndex, int endIndex, ObservableCollection<Item> items)
		{
			if (endIndex - startIndex < 2)
				return;

			int middleIndex = (startIndex + endIndex) / 2;

			TopDownSplitMerge(items, startIndex, middleIndex, itemsCopy);
			TopDownSplitMerge(items, middleIndex, endIndex, itemsCopy);

			TopDownMerge(itemsCopy, startIndex, middleIndex, endIndex, items);
		}

		private void TopDownMerge(ObservableCollection<Item> itemsCopy, int startIndex, int middeIndex, int endIndex, ObservableCollection<Item> items)
		{
			int i = startIndex;
			int j = middeIndex;

			for (int k = startIndex; k < endIndex; k++)
			{
				if (i < middeIndex && (j >= endIndex || itemsCopy[i].Value <= itemsCopy[j].Value))
				{
					items[k] = itemsCopy[i];
					i++;
				}
				else
				{
					items[k] = itemsCopy[j];
					j++;
				}
			}
		}
	}
}
