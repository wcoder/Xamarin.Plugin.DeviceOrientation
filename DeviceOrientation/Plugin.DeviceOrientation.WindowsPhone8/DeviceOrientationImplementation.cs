using Plugin.DeviceOrientation.Abstractions;

namespace Plugin.DeviceOrientation
{
	public class DeviceOrientationImplementation : IDeviceOrientation
	{
		public DeviceOrientations CurrentOrientation
		{
			get
			{
				return DeviceOrientations.Undefined;
			}
		}
	}
}