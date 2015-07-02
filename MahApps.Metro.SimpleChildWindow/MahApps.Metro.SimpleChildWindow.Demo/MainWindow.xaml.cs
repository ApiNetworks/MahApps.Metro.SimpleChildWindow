using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
//using MahApps.Metro.SimpleChildWindow.Demo.Annotations;

namespace MahApps.Metro.SimpleChildWindow.Demo
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow, INotifyPropertyChanged
	{
		public MainWindow()
		{
			this.InitializeComponent();
		}

		private void FirstTest_OnClick(object sender, RoutedEventArgs e)
		{
			this.child01.IsOpen = true;
		}

		private void SecTest_OnClick(object sender, RoutedEventArgs e)
		{
			this.child02.IsOpen = true;
		}

		private async void ThirdTest_OnClick(object sender, RoutedEventArgs e)
		{
			await this.ShowChildWindowAsync(new CoolChildWindow() { IsModal = false }, RootGrid);
		}

		private void CloseFirst_OnClick(object sender, RoutedEventArgs e)
		{
			this.child01.IsOpen = false;
		}

		private void CloseSec_OnClick(object sender, RoutedEventArgs e)
		{
			this.child02.IsOpen = false;
		}

		private async void MovingTest_OnClick(object sender, RoutedEventArgs e)
		{
			//await this.ShowChildWindowAsync(new CoolChildWindow() { IsModal = true, AllowMove = true }, RootGrid);
			Task.Run(() => {
				while (true)
				{
					Thread.Sleep(1000);
					if (showwarning)
					{
						showwarning = false;
						Console.WriteLine("OFF");
					}
					else
					{
						showwarning = true;
						Console.WriteLine("ON");
					}
				}
			});
		}

		private bool _showwarning;

		public bool showwarning
		{
			get { return this._showwarning; }
			set
			{
				if (this.showwarning == value) {
					return;
				}
				this._showwarning = value;
				this.OnPropertyChanged("showwarning");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

//		[NotifyPropertyChangedInvocator]
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
