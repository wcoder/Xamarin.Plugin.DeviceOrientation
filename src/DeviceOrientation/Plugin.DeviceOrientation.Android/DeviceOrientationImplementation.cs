using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Plugin.DeviceOrientation.Abstractions;

namespace Plugin.DeviceOrientation
{
	public class DeviceOrientationImplementation : BaseDeviceOrientationImplementation
	{
		public override DeviceOrientations CurrentOrientation
		{
			get
			{
				IWindowManager windowManager = Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

				switch (windowManager.DefaultDisplay.Rotation)
				{
					case SurfaceOrientation.Rotation0:
						return DeviceOrientations.Portrait;
					case SurfaceOrientation.Rotation180:
						return DeviceOrientations.PortraitFlipped;
					case SurfaceOrientation.Rotation90:
						return DeviceOrientations.Landscape;
					case SurfaceOrientation.Rotation270:
						return DeviceOrientations.LandscapeFlipped;
					default:
						return DeviceOrientations.Undefined;
				}
			}
		}
	}
}