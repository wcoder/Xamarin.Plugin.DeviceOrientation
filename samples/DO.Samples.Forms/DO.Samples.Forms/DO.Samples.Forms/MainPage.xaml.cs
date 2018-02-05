using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.DeviceOrientation;
using Plugin.DeviceOrientation.Abstractions;
using Xamarin.Forms;

namespace DO.Samples.Forms
{
    public partial class MainPage : ContentPage
    {
        private bool _isLocked = false;

        public MainPage()
        {
            InitializeComponent();

            var a = new DSImage(1, 2, 3, 4);

            CrossDeviceOrientation.Current.OrientationChanged += CurrentOnOrientationChanged;
        }

        private void CurrentOnOrientationChanged(object sender, OrientationChangedEventArgs orientationChangedEventArgs)
        {
            btn.Text = orientationChangedEventArgs.Orientation.ToString();
        }

        public void Button_Click(object sender, EventArgs args)
        {
            if (_isLocked)
                CrossDeviceOrientation.Current.LockOrientation(CrossDeviceOrientation.Current.CurrentOrientation);
            else
                CrossDeviceOrientation.Current.UnlockOrientation();

            _isLocked = !_isLocked;
        }
    }
}
