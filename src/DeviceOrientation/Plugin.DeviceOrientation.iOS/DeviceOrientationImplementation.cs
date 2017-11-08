using CoreFoundation;
using Foundation;
using UIKit;
using Plugin.DeviceOrientation.Abstractions;

namespace Plugin.DeviceOrientation
{
    // https://docs.xamarin.com/api/property/UIKit.UIApplication.DidChangeStatusBarOrientationNotification/
    // https://stackoverflow.com/a/4759383
    public class DeviceOrientationImplementation : BaseDeviceOrientationImplementation
    {
        private static DeviceOrientations _lockedOrientation = DeviceOrientations.Undefined;

        private readonly NSObject _observer;
        private bool _disposed;


        public DeviceOrientationImplementation()
        {
            _observer = NSNotificationCenter.DefaultCenter.AddObserver(
                UIApplication.DidChangeStatusBarOrientationNotification,
                DeviceOrientationDidChange);
            UIDevice.CurrentDevice.BeginGeneratingDeviceOrientationNotifications();
        }

        private static UIDeviceOrientation CurrentDeviceOrientation => UIDevice.CurrentDevice.Orientation;

        public static bool ShouldAutorotate
        {
            get
            {
                var result = CurrentDeviceOrientation == UIDeviceOrientation.Unknown;
                switch (_lockedOrientation)
                {
                    case DeviceOrientations.Landscape:
                        result = result || CurrentDeviceOrientation == UIDeviceOrientation.LandscapeRight;
                        break;
                    case DeviceOrientations.LandscapeFlipped:
                        result = result || CurrentDeviceOrientation == UIDeviceOrientation.LandscapeLeft;
                        break;
                    case DeviceOrientations.Portrait:
                        result = result || CurrentDeviceOrientation == UIDeviceOrientation.PortraitUpsideDown;
                        break;
                    case DeviceOrientations.PortraitFlipped:
                        result = result || CurrentDeviceOrientation == UIDeviceOrientation.Portrait;
                        break;
                    default:
                        result = true;
                        break;
                }
                return result;
            }
        }


        public override DeviceOrientations CurrentOrientation =>
            Convert(UIApplication.SharedApplication.StatusBarOrientation);

        public static UIInterfaceOrientationMask SupportedInterfaceOrientations =>
            ConvertToMask(_lockedOrientation);

        public override void LockOrientation(DeviceOrientations orientation)
        {
            _lockedOrientation = orientation;

            SetDeviceOrientation(orientation);
        }

        public override void UnlockOrientation()
        {
            _lockedOrientation = DeviceOrientations.Undefined;

            SetDeviceOrientation(Reverse(Convert(CurrentDeviceOrientation)));
        }

        /// <summary>
        ///     Devices the orientation did change.
        /// </summary>
        private void DeviceOrientationDidChange(NSNotification notification)
        {
            OnOrientationChanged(new OrientationChangedEventArgs
            {
                Orientation = Convert(CurrentDeviceOrientation)
            });
        }

        public override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing && _observer != null)
                    NSNotificationCenter.DefaultCenter.RemoveObserver(_observer);

                _disposed = true;
            }

            base.Dispose(disposing);
        }

        private void SetDeviceOrientation(DeviceOrientations orientation)
        {
            DispatchQueue.MainQueue.DispatchAsync(() =>
            {
                UIDevice.CurrentDevice.SetValueForKey(
                    NSObject.FromObject(Convert(orientation)),
                    new NSString("orientation"));
                UIViewController.AttemptRotationToDeviceOrientation();
            });
        }

        private static UIInterfaceOrientationMask ConvertToMask(DeviceOrientations orientation)
        {
            switch (orientation)
            {
                case DeviceOrientations.Portrait:
                    return UIInterfaceOrientationMask.Portrait;
                case DeviceOrientations.PortraitFlipped:
                    return UIInterfaceOrientationMask.PortraitUpsideDown;
                case DeviceOrientations.LandscapeFlipped:
                    return UIInterfaceOrientationMask.LandscapeRight;
                case DeviceOrientations.Landscape:
                    return UIInterfaceOrientationMask.LandscapeLeft;
                default:
                    return UIInterfaceOrientationMask.AllButUpsideDown;
            }
        }

        private UIInterfaceOrientation Convert(DeviceOrientations orientation)
        {
            switch (orientation)
            {
                case DeviceOrientations.Portrait:
                    return UIInterfaceOrientation.Portrait;
                case DeviceOrientations.PortraitFlipped:
                    return UIInterfaceOrientation.PortraitUpsideDown;
                case DeviceOrientations.LandscapeFlipped:
                    return UIInterfaceOrientation.LandscapeRight;
                case DeviceOrientations.Landscape:
                    return UIInterfaceOrientation.LandscapeLeft;
                default:
                    return UIInterfaceOrientation.Unknown;
            }
        }

        private DeviceOrientations Convert(UIInterfaceOrientation orientation)
        {
            switch (orientation)
            {
                case UIInterfaceOrientation.Portrait:
                    return DeviceOrientations.Portrait;
                case UIInterfaceOrientation.PortraitUpsideDown:
                    return DeviceOrientations.PortraitFlipped;
                case UIInterfaceOrientation.LandscapeRight:
                    return DeviceOrientations.LandscapeFlipped;
                case UIInterfaceOrientation.LandscapeLeft:
                    return DeviceOrientations.Landscape;
                default:
                    return DeviceOrientations.Undefined;
            }
        }

        private DeviceOrientations Convert(UIDeviceOrientation orientation)
        {
            switch (orientation)
            {
                case UIDeviceOrientation.Portrait:
                    return DeviceOrientations.Portrait;
                case UIDeviceOrientation.PortraitUpsideDown:
                    return DeviceOrientations.PortraitFlipped;
                case UIDeviceOrientation.LandscapeRight:
                    return DeviceOrientations.LandscapeFlipped;
                case UIDeviceOrientation.LandscapeLeft:
                    return DeviceOrientations.Landscape;
                default:
                    return DeviceOrientations.Undefined;
            }
        }

        private DeviceOrientations Reverse(DeviceOrientations orientation)
        {
            switch (orientation)
            {
                case DeviceOrientations.Portrait:
                case DeviceOrientations.PortraitFlipped:
                    return DeviceOrientations.Portrait;
                case DeviceOrientations.Landscape:
                    return DeviceOrientations.LandscapeFlipped;
                case DeviceOrientations.LandscapeFlipped:
                    return DeviceOrientations.Landscape;
                default:
                    return DeviceOrientations.Undefined;
            }
        }
    }
}