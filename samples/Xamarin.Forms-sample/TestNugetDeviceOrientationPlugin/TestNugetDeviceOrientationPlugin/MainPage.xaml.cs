using Xamarin.Forms;

using Plugin.DeviceOrientation;

namespace TestNugetDeviceOrientationPlugin
{
    public partial class MainPage : ContentPage
    {
        private bool _isLocked;

        public MainPage()
        {
            InitializeComponent();

            OrientationLabel.Text = CrossDeviceOrientation.Current.CurrentOrientation.ToString();

            // sample of screen orientation lock
            OrientationLabel.Clicked += (sender, args) =>
            {
                _isLocked = !_isLocked;

                if (_isLocked)
                    CrossDeviceOrientation.Current.LockOrientation(CrossDeviceOrientation.Current.CurrentOrientation);
                else
                    CrossDeviceOrientation.Current.UnlockOrientation();
            };

            // the sample of the event handler when screen orientation will change
            CrossDeviceOrientation.Current.OrientationChanged += (sender, args) =>
            {
                OrientationLabel.Text = args.Orientation.ToString();
            };
        }
    }
}
