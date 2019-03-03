using System;
using System.Collections.ObjectModel;

namespace WpfSortApplication.SortAlgorithms
{
	/// <summary>
	/// Time Complexity:
	/// - Worst: O(nlog(n))
	/// - Average: Θ(nlog(n))
	/// - Best: Ω(nlog(n))
	/// Space Complexity: O(1)
	/// 
	/// Unstable
	/// Worse than QuickSort but has better
	/// worst case time complexity
	/// 
	/// </summary>
	public class HeapSort : SortAlgorithm
	{
		public HeapSort(ObservableCollection<Item> items)
			: base(items)
		{ }

		public override void Reset()
		{ }

		public override void Sort()
		{
			Heapify();

			int endIndex = Items.Count - 1;
			while (endIndex > 0)
			{
				Swap(endIndex, 0);

				endIndex--;
				SiftDown(0, endIndex);
			}
		}

		public override void SortStep()
		{
			throw new NotImplementedException();
		}

		private void Heapify()
		{
			int startIndex = GetParentIndex(Items.Count - 1);

			while (startIndex >= 0)
			{
				SiftDown(startIndex, Items.Count - 1);

				startIndex--;
			}
		}

		private void SiftDown(int startIndex, int endIndex)
		{
			int rootIndex = startIndex;

			while (GetLeftChildIndex(rootIndex) <= endIndex)
			{
				int leftChildIndex = GetLeftChildIndex(rootIndex);
				int rightChildIndex = GetRightChildIndex(rootIndex);
				int swapIndex = rootIndex;

				if (Items[swapIndex].Value < Items[leftChildIndex].Value)
					swapIndex = leftChildIndex;

				if (rightChildIndex <= endIndex
					&& Items[swapIndex].Value < Items[rightChildIndex].Value)
					swapIndex = rightChildIndex;

				if (swapIndex == rootIndex)
				{
					return;
				}
				else
				{
					Swap(rootIndex, swapIndex);
					rootIndex = swapIndex;
				}
			}
		}

		private int GetParentIndex(int index)
		{
			return (index - 1) / 2;
		}

		private int GetLeftChildIndex(int rootIndex)
		{
			return 2 * rootIndex + 1;
		}

		private int GetRightChildIndex(int rootIndex)
		{
			return 2 * rootIndex + 2;
		}
	}
}
