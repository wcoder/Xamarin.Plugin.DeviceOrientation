using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Plugin.DeviceOrientation;
using Plugin.DeviceOrientation.Abstractions;

namespace DeviceOrientation.Samples.UWP
{
    public sealed partial class MainPage
    {
        private bool _isLocked;

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

        private void Current_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            MainLabel.Text = e.Orientation.ToString();
        }

        private void LockButton_OnClick(object sender, RoutedEventArgs e)
        {
            _isLocked = !_isLocked;

            LockButton.Content = _isLocked ? "Unlock" : "Lock";

            if (_isLocked)
                CrossDeviceOrientation.Current.LockOrientation(CrossDeviceOrientation.Current.CurrentOrientation);
            else
                CrossDeviceOrientation.Current.UnlockOrientation();
        }
    }
}