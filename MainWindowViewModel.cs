using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfSortApplication.SortAlgorithms;

namespace WpfSortApplication
{
	public class MainWindowViewModel
	{
		private const int NumberOfItems = 20;

		public MainWindowViewModel()
		{
			Items = new ObservableCollection<Item>();

			var random = new Random();

			for (int i = 0; i < NumberOfItems; i++)
				Items.Add(new Item(random.Next(ListBoxHeight), ListBoxHeight));

			var sortAlgorithm = new SelectionSort(Items);
			SortCommand = new RelayCommand((p) => sortAlgorithm.Sort());
			SortStepCommand = new RelayCommand((p) => sortAlgorithm.SortStep());
		}

		public int WindowWidth => 800;
		public int WindowHeight => 550;
		public int ListBoxHeight => 500;

		public ObservableCollection<Item> Items { get; }

		public ICommand SortCommand { get; }
		public ICommand SortStepCommand { get; }		
	}
}
