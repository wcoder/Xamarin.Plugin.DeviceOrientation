using UIKit;
using Plugin.DeviceOrientation.Abstractions;

namespace Plugin.DeviceOrientation
{
	public class DeviceOrientationImplementation : BaseDeviceOrientationImplementation
	{
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
						return DeviceOrientations.Landscape;
					case UIInterfaceOrientation.LandscapeLeft:
						return DeviceOrientations.LandscapeFlipped;
					default:
						return DeviceOrientations.Undefined;
				}
			}
		}
	}
}