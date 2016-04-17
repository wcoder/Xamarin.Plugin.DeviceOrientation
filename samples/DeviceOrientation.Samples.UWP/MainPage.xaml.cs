using Windows.UI.Xaml.Navigation;
using Plugin.DeviceOrientation;

namespace DeviceOrientation.Samples.UWP
{
	public sealed partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();

			MainLabel.Text = CrossDeviceOrientation.Current.CurrentOrientation.ToString();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			base.OnNavigatedTo(e);

			CrossDeviceOrientation.Current.OrientationChanged += Current_OrientationChanged;
		}

		protected override void OnNavigatedFrom(NavigationEventArgs e)
		{
			base.OnNavigatedFrom(e);

			CrossDeviceOrientation.Current.OrientationChanged -= Current_OrientationChanged;
		}

		private void Current_OrientationChanged(object sender, Plugin.DeviceOrientation.Abstractions.OrientationChangedEventArgs e)
		{
			MainLabel.Text = e.Orientation.ToString();
		}
	}
}
