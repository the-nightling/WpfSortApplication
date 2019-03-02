using System.Collections.ObjectModel;

namespace WpfSortApplication
{
	public abstract class SortAlgorithm
	{
		protected int currentStep = 0;

		public SortAlgorithm(ObservableCollection<Item> items)
		{
			Items = items;
		}

		protected ObservableCollection<Item> Items { get; }

		public abstract void Sort();

		public abstract void SortStep();
	}
}
