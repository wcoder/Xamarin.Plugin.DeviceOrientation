using UIKit;
using Foundation;
using Plugin.DeviceOrientation.Abstractions;

namespace Plugin.DeviceOrientation
{
	// https://docs.xamarin.com/api/property/UIKit.UIApplication.DidChangeStatusBarOrientationNotification/
	// http://stackoverflow.com/questions/4758363/how-to-subscribe-self-on-the-event-of-device-orientationnot-interface-orientati
	public class DeviceOrientationImplementation : BaseDeviceOrientationImplementation
	{
		private readonly NSObject _observer;
		private bool _disposed;

		public DeviceOrientationImplementation()
		{
			_observer = NSNotificationCenter.DefaultCenter.AddObserver(
				UIApplication.DidChangeStatusBarOrientationNotification,
				DeviceOrientationDidChange);
			UIDevice.CurrentDevice.BeginGeneratingDeviceOrientationNotifications();
		}

		public override DeviceOrientations CurrentOrientation => Convert(UIApplication.SharedApplication.StatusBarOrientation);

		public override void LockOrientation(DeviceOrientations orientation)
		{
			// TODO:
		}

		public override void UnlockOrientation()
		{
			// TODO:
		}

		/// <summary>
		/// Devices the orientation did change.
		/// </summary>
		private void DeviceOrientationDidChange(NSNotification notification)
		{
			OnOrientationChanged(new OrientationChangedEventArgs
			{
				Orientation = Convert(UIDevice.CurrentDevice.Orientation)
			});
		}

		public override void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing && _observer != null)
				{
					NSNotificationCenter.DefaultCenter.RemoveObserver(_observer);
				}

				_disposed = true;
			}

			base.Dispose(disposing);
		}

		/*private UIInterfaceOrientation Convert(DeviceOrientations orientation)
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
		}*/

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
	}
}