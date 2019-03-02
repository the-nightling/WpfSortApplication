using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows.Media;

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

			SortCommand = new RelayCommand((p) => Sort());
		}

		public int WindowWidth => 800;
		public int WindowHeight => 550;
		public int ListBoxHeight => 500;

		public ObservableCollection<Item> Items { get; }

		public ICommand SortCommand { get; }

		private bool CanExecuteSortCommand()
		{
			return true;
		}

		private void Sort()
		{
			Items.Move(0, 19);
		}

		public class Item
		{
			public Item(int value, int maxValue)
			{
				Value = value;

				var hue = (value / (double)maxValue) * 360;
				HsvToRgb(hue, 1, 1, out byte r, out byte g, out byte b);
				ItemColor = new SolidColorBrush(Color.FromRgb(r, g, b));
			}

			public int Value { get; }
			public SolidColorBrush ItemColor { get; }

			private void HsvToRgb(double h, double S, double V, out byte r, out byte g, out byte b)
			{
				double H = h;
				while (H < 0)
					H += 360;

				while (H >= 360)
					H -= 360;

				double R, G, B;
				if (V <= 0)
				{
					R = G = B = 0;
				}
				else if (S <= 0)
				{
					R = G = B = V;
				}
				else
				{
					double hf = H / 60.0;
					int i = (int)Math.Floor(hf);
					double f = hf - i;
					double pv = V * (1 - S);
					double qv = V * (1 - S * f);
					double tv = V * (1 - S * (1 - f));
					switch (i)
					{

						// Red is the dominant color

						case 0:
							R = V;
							G = tv;
							B = pv;
							break;

						// Green is the dominant color

						case 1:
							R = qv;
							G = V;
							B = pv;
							break;
						case 2:
							R = pv;
							G = V;
							B = tv;
							break;

						// Blue is the dominant color

						case 3:
							R = pv;
							G = qv;
							B = V;
							break;
						case 4:
							R = tv;
							G = pv;
							B = V;
							break;

						// Red is the dominant color

						case 5:
							R = V;
							G = pv;
							B = qv;
							break;

						// Just in case we overshoot on our math by a little, we put these here. Since its a switch it won't slow us down at all to put these here.

						case 6:
							R = V;
							G = tv;
							B = pv;
							break;
						case -1:
							R = V;
							G = pv;
							B = qv;
							break;

						// The color is not defined, we should throw an error.

						default:
							//LFATAL("i Value error in Pixel conversion, Value is %d", i);
							R = G = B = V; // Just pretend its black/white
							break;
					}
				}
				r = Clamp((int)(R * 255.0));
				g = Clamp((int)(G * 255.0));
				b = Clamp((int)(B * 255.0));

				byte Clamp(int i)
				{
					if (i < 0) return 0;
					if (i > 255) return 255;
					return (byte)i;
				}
			}
		}
	}
}
