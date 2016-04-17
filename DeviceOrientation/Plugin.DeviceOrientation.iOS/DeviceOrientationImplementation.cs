using UIKit;
using Plugin.DeviceOrientation.Abstractions;

namespace Plugin.DeviceOrientation
{
	public class DeviceOrientationImplementation : IDeviceOrientation
	{
		public DeviceOrientations CurrentOrientation
		{
			get
			{
				var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
				bool isPortrait = currentOrientation == UIInterfaceOrientation.Portrait
					|| currentOrientation == UIInterfaceOrientation.PortraitUpsideDown;

				return isPortrait ? DeviceOrientations.Portrait : DeviceOrientations.Landscape;
			}
		}
	}
}