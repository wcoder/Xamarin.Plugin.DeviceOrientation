using UIKit;
using Foundation;
using Plugin.DeviceOrientation.Abstractions;

namespace Plugin.DeviceOrientation
{
	// https://docs.xamarin.com/api/property/UIKit.UIApplication.DidChangeStatusBarOrientationNotification/
	// http://stackoverflow.com/questions/4758363/how-to-subscribe-self-on-the-event-of-device-orientationnot-interface-orientati
	public class DeviceOrientationImplementation : BaseDeviceOrientationImplementation
	{
		private NSObject _observer;
		private bool _disposed;

		public DeviceOrientationImplementation()
		{
			_observer = NSNotificationCenter.DefaultCenter.AddObserver(
				UIApplication.DidChangeStatusBarOrientationNotification,
				DeviceOrientationDidChange);
			UIDevice.CurrentDevice.BeginGeneratingDeviceOrientationNotifications();
		}

		public override DeviceOrientations CurrentOrientation
		{
			get
			{
				switch (UIApplication.SharedApplication.StatusBarOrientation)
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
		}

		private DeviceOrientations CurrentDeviceOrientation
		{
			get
			{
				switch (UIDevice.CurrentDevice.Orientation)
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

		/// <summary>
		/// Devices the orientation did change.
		/// </summary>
		private void DeviceOrientationDidChange(NSNotification notification)
		{
			OnOrientationChanged(new OrientationChangedEventArgs
				{
					Orientation = CurrentDeviceOrientation
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
	}
}