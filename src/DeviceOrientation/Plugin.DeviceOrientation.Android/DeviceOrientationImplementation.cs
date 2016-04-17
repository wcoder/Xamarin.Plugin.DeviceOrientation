using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Plugin.DeviceOrientation.Abstractions;

namespace Plugin.DeviceOrientation
{
	public class DeviceOrientationImplementation : IDeviceOrientation
	{
		public DeviceOrientations CurrentOrientation
		{
			get
			{
				IWindowManager windowManager = Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

				var rotation = windowManager.DefaultDisplay.Rotation;
				bool isLandscape = rotation == SurfaceOrientation.Rotation90 || rotation == SurfaceOrientation.Rotation270;
				return isLandscape ? DeviceOrientations.Landscape : DeviceOrientations.Portrait;
			}
		}
	}
}