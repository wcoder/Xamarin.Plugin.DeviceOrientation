using Windows.Graphics.Display;
using Plugin.DeviceOrientation.Abstractions;

namespace Plugin.DeviceOrientation
{
	public class DeviceOrientationImplementation : IDeviceOrientation
	{
		public DeviceOrientations CurrentOrientation
		{
			get
			{
				var orientation = DisplayInformation.GetForCurrentView().CurrentOrientation;
				switch (orientation)
				{
					case DisplayOrientations.Portrait:
					case DisplayOrientations.PortraitFlipped:
						return DeviceOrientations.Portrait;
					case DisplayOrientations.Landscape:
					case DisplayOrientations.LandscapeFlipped:
						return DeviceOrientations.Landscape;
					default:
						return DeviceOrientations.Undefined;
				}
			}
		}
	}
}