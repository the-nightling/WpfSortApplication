using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WpfSortApplication.SortAlgorithms;

namespace WpfSortApplication
{
	public class MainWindowViewModel
	{
		private const int NumberOfItems = 20;
		private readonly List<Item> initialCollection;
		private SortAlgorithm sortAlgorithm;

		public MainWindowViewModel()
		{
			var random = new Random();
			this.initialCollection = new List<Item>();
			Items = new ObservableCollection<Item>();

			for (int i = 0; i < NumberOfItems; i++)
			{
				var item = new Item(random.Next(ListBoxHeight), ListBoxHeight);
				this.initialCollection.Add(item);
				Items.Add(item);
			}

			ResetCommand = new RelayCommand((_) => Reset());

			//this.sortAlgorithm = new SelectionSort(Items);
			this.sortAlgorithm = new InsertionSort(Items);
			SortCommand = new RelayCommand((_) => sortAlgorithm.Sort());
			SortStepCommand = new RelayCommand((_) => sortAlgorithm.SortStep());
		}

		public int WindowWidth => 800;
		public int WindowHeight => 550;
		public int ListBoxHeight => 500;

		public ObservableCollection<Item> Items { get; }

		public ICommand ResetCommand { get; }
		public ICommand SortCommand { get; }
		public ICommand SortStepCommand { get; }

		private void Reset()
		{
			Items.Clear();
			for (int i = 0; i < this.initialCollection.Count; i++)
				Items.Add(this.initialCollection[i]);

			this.sortAlgorithm.Reset();
		}
	}
}
