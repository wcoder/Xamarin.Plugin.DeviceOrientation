using Xamarin.Forms;
using Plugin.DeviceOrientation;

namespace TestNugetDeviceOrientationPlugin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            OrientationLabel.Text = CrossDeviceOrientation.Current.CurrentOrientation.ToString();
            CrossDeviceOrientation.Current.OrientationChanged += Current_OrientationChanged;
        }

        private void Current_OrientationChanged(object sender, Plugin.DeviceOrientation.Abstractions.OrientationChangedEventArgs e)
        {
            OrientationLabel.Text = e.Orientation.ToString();
        }
    }
}
