using System;
using System.Windows.Input;

namespace WpfSortApplication
{
	public class RelayCommand : ICommand
	{
		private readonly Action<object> action;

		public RelayCommand(Action<object> action)
		{
			this.action = action;
		}

		public bool CanExecute(object parameter)
		{
			return true;
		}

		public void Execute(object parameter)
		{
			this.action(parameter);
		}

		public event EventHandler CanExecuteChanged;
	}
}
