using System;
using System.Windows.Input;

namespace WpfSortApplication
{
	public class RelayCommand : ICommand
	{
		private readonly Action<object> action;
		private readonly Func<bool> canExecute;

		public RelayCommand(Action<object> action, Func<bool> canExecute = null)
		{
			this.action = action;
			this.canExecute = canExecute;
		}

		public bool CanExecute(object parameter)
		{
			return this.canExecute == null
					? true
					: this.canExecute();
		}

		public void Execute(object parameter)
		{
			this.action(parameter);
		}

		public void RaiseCanExecuteChanged()
		{
			CanExecuteChanged?.Invoke(this, null);
		}

		public event EventHandler CanExecuteChanged;
	}
}
