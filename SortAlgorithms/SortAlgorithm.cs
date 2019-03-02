using System.Collections.ObjectModel;

namespace WpfSortApplication
{
	public abstract class SortAlgorithm
	{
		protected int currentIndex;

		public SortAlgorithm(ObservableCollection<Item> items)
		{
			Items = items;
			Reset();
		}

		protected ObservableCollection<Item> Items { get; }

		public abstract void Reset();
		public abstract void Sort();
		public abstract void SortStep();
	}
}
