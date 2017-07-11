using Windows.Graphics.Display;
using Plugin.DeviceOrientation.Abstractions;

namespace Plugin.DeviceOrientation
{
    public class DeviceOrientationImplementation : BaseDeviceOrientationImplementation
    {
        private readonly DisplayInformation _displayInformation;
        private bool _disposed;

        public DeviceOrientationImplementation()
        {
            _displayInformation = DisplayInformation.GetForCurrentView();
            _displayInformation.OrientationChanged += DisplayInformationOnOrientationChanged;
        }

        public override DeviceOrientations CurrentOrientation =>
            (DeviceOrientations) _displayInformation.CurrentOrientation;

        public override void LockOrientation(DeviceOrientations orientation)
        {
            DisplayInformation.AutoRotationPreferences = (DisplayOrientations) orientation;
        }

        public override void UnlockOrientation()
        {
            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape
                                                         | DisplayOrientations.LandscapeFlipped
                                                         | DisplayOrientations.Portrait
                                                         | DisplayOrientations.PortraitFlipped;
        }

        private void DisplayInformationOnOrientationChanged(DisplayInformation sender, object args)
        {
            OnOrientationChanged(new OrientationChangedEventArgs
            {
                Orientation = CurrentOrientation
            });
        }

        public override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                    _displayInformation.OrientationChanged -= DisplayInformationOnOrientationChanged;

                _disposed = true;
            }

            base.Dispose(disposing);
        }
    }
}