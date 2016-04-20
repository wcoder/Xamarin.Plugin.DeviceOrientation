using System.Windows;
using Microsoft.Phone.Controls;
using Plugin.DeviceOrientation.Abstractions;
using OrientationChangedEventArgs = Microsoft.Phone.Controls.OrientationChangedEventArgs;

namespace Plugin.DeviceOrientation
{
	// https://msdn.microsoft.com/en-us/library/windows/apps/jj207002(v=vs.105).aspx#BKMK_Orientations
	public class DeviceOrientationImplementation : BaseDeviceOrientationImplementation
	{
		private PhoneApplicationFrame _rootFrame;
		private bool _disposed;

		public override DeviceOrientations CurrentOrientation
		{
			get
			{
				if (_rootFrame == null)
					return DeviceOrientations.Undefined;

				return Convert(_rootFrame.Orientation);
			}
		}

		public DeviceOrientationImplementation()
		{
			_rootFrame = Application.Current.RootVisual as PhoneApplicationFrame;
			if (_rootFrame != null)
			{
				_rootFrame.OrientationChanged += RootFrameOnOrientationChanged;
			}
		}

		public override void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing && _rootFrame != null)
				{
					_rootFrame.OrientationChanged -= RootFrameOnOrientationChanged;
				}

				_disposed = true;
			}

			base.Dispose(disposing);
		}

		private void RootFrameOnOrientationChanged(object sender, OrientationChangedEventArgs args)
		{
			OnOrientationChanged(new Abstractions.OrientationChangedEventArgs
			{
				Orientation = Convert(args.Orientation)
			});
		}

		private DeviceOrientations Convert(PageOrientation orientation)
		{
			switch (orientation)
			{
				case PageOrientation.PortraitUp:
					return DeviceOrientations.Portrait;
				case PageOrientation.PortraitDown:
					return DeviceOrientations.PortraitFlipped;
				case PageOrientation.LandscapeLeft:
					return DeviceOrientations.Landscape;
				case PageOrientation.LandscapeRight:
					return DeviceOrientations.LandscapeFlipped;
				default:
					return DeviceOrientations.Undefined;
			}
		}
	}
}