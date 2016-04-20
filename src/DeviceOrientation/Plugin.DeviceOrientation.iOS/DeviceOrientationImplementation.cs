using UIKit;
using Plugin.DeviceOrientation.Abstractions;

namespace Plugin.DeviceOrientation
{
	public class DeviceOrientationImplementation : BaseDeviceOrientationImplementation
	{
		public override DeviceOrientations CurrentOrientation =>
			Convert(UIApplication.SharedApplication.StatusBarOrientation);

		//		private static DeviceOrientations CurrentDeviceOrientation
		//		{
		//			get
		//			{
		//				switch (UIDevice.CurrentDevice.Orientation)
		//				{
		//					case UIDeviceOrientation.Portrait:
		//						return DeviceOrientations.Portrait;
		//					case UIDeviceOrientation.PortraitUpsideDown:
		//						return DeviceOrientations.PortraitFlipped;
		//					case UIDeviceOrientation.LandscapeRight:
		//						return DeviceOrientations.Landscape;
		//					case UIDeviceOrientation.LandscapeLeft:
		//						return DeviceOrientations.LandscapeFlipped;
		//					default:
		//						return DeviceOrientations.Undefined;
		//				}
		//			}
		//		}

		// https://docs.xamarin.com/api/property/UIKit.UIApplication.DidChangeStatusBarOrientationNotification/
		// http://stackoverflow.com/questions/4758363/how-to-subscribe-self-on-the-event-of-device-orientationnot-interface-orientati
		public DeviceOrientationImplementation()
		{
			//var notificationCenter = NSNotificationCenter.DefaultCenter;
			//notificationCenter.AddObserver(UIApplication.DidChangeStatusBarOrientationNotification, DeviceOrientationDidChange);
			//UIDevice.CurrentDevice.BeginGeneratingDeviceOrientationNotifications();

			UIApplication.Notifications.ObserveDidChangeStatusBarOrientation(DeviceOrientationDidChange);
		}

		/// <summary>
		/// Devices the orientation did change.
		/// </summary>
		public void DeviceOrientationDidChange(object sender, UIStatusBarOrientationChangeEventArgs args)
		{
			OnOrientationChanged(new OrientationChangedEventArgs
			{
				Orientation = Convert(args.StatusBarOrientation)
			});
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
					return DeviceOrientations.Landscape;
				case UIInterfaceOrientation.LandscapeLeft:
					return DeviceOrientations.LandscapeFlipped;
				default:
					return DeviceOrientations.Undefined;
			}
		}
	}
}