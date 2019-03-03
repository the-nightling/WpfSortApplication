using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WpfSortApplication.SortAlgorithms;

namespace WpfSortApplication
{
	public enum Algorithm
	{
		SelectionSort,
		InsertionSort,
		BubbleSort,
		TreeSort,
		HeapSort,
		QuickSort,
		MergeSort
	}

	public class MainWindowViewModel : INotifyPropertyChanged
	{
		private const int NumberOfItems = 20;
		private readonly List<Item> initialCollection;
		private Algorithm selectedAlgorithm;
		private SortAlgorithm sortAlgorithm;
		private readonly Func<bool> canExecuteSortStep;

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

			SelectedAlgorithm = Algorithm.SelectionSort;
			this.canExecuteSortStep = () => (this.sortAlgorithm is SelectionSort) || (this.sortAlgorithm is InsertionSort) || (this.sortAlgorithm is BubbleSort);
			SortCommand = new RelayCommand((_) => this.sortAlgorithm.Sort());
			SortStepCommand = new RelayCommand((_) => this.sortAlgorithm.SortStep(), this.canExecuteSortStep);
		}

		public int WindowWidth => 800;
		public int WindowHeight => 550;
		public int ListBoxHeight => 500;

		public ObservableCollection<Item> Items { get; }

		public Array Algorithms => Enum.GetValues(typeof(Algorithm));

		public Algorithm SelectedAlgorithm
		{
			get => this.selectedAlgorithm;
			set
			{
				this.selectedAlgorithm = value;
				switch(this.selectedAlgorithm)
				{
					case Algorithm.SelectionSort: this.sortAlgorithm = new SelectionSort(Items); break;
					case Algorithm.InsertionSort: this.sortAlgorithm = new InsertionSort(Items); break;
					case Algorithm.BubbleSort: this.sortAlgorithm = new BubbleSort(Items); break;
					case Algorithm.TreeSort: this.sortAlgorithm = new TreeSort(Items); break;
					case Algorithm.HeapSort: this.sortAlgorithm = new HeapSort(Items); break;
					case Algorithm.QuickSort: this.sortAlgorithm = new QuickSort(Items); break;
					case Algorithm.MergeSort: this.sortAlgorithm = new MergeSort(Items); break;
				}

				Reset();
				NotifyPropertyChanged();
				NotifyPropertyChanged(nameof(CanExecuteSortStep));
			}
		}

		public ICommand ResetCommand { get; }
		public ICommand SortCommand { get; }
		public ICommand SortStepCommand { get; }
		public bool CanExecuteSortStep => this.canExecuteSortStep();

		private void Reset()
		{
			Items.Clear();
			for (int i = 0; i < this.initialCollection.Count; i++)
				Items.Add(this.initialCollection[i]);

			this.sortAlgorithm.Reset();
		}

		private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}
