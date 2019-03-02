using System.Collections.ObjectModel;

namespace WpfSortApplication.SortAlgorithms
{
	public class SelectionSort : SortAlgorithm
	{
		public SelectionSort(ObservableCollection<Item> items)
			: base(items)
		{ }

		public override void Sort()
		{
			for (int i = 0; i < Items.Count - 1; i++)
				SelectionSortStep(i);
		}

		public override void SortStep()
		{
			if (this.currentStep >= Items.Count - 1)
				this.currentStep = 0;

			SelectionSortStep(this.currentStep);

			this.currentStep++;
		}

		private void SelectionSortStep(int currentIndex)
		{
			int minIndex = FindMinIndex(currentIndex);

			if (minIndex != currentIndex)
			{
				Item tempItem = Items[currentIndex];
				Items[currentIndex] = Items[minIndex];
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
