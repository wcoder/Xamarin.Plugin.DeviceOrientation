using Windows.Graphics.Display;
using Plugin.DeviceOrientation.Abstractions;

namespace Plugin.DeviceOrientation
{
	public class DeviceOrientationImplementation : BaseDeviceOrientationImplementation
	{
		private DisplayInformation _displayInformation;

		public override DeviceOrientations CurrentOrientation =>
			(DeviceOrientations)_displayInformation.CurrentOrientation;

		public DeviceOrientationImplementation()
		{
			_displayInformation = DisplayInformation.GetForCurrentView();
			_displayInformation.OrientationChanged += DisplayInformationOnOrientationChanged;
		}

		private void DisplayInformationOnOrientationChanged(DisplayInformation sender, object args)
		{
			OnOrientationChanged(new OrientationChangedEventArgs
			{
				Orientation = CurrentOrientation
			});
		}

		private bool _disposed;

		public override void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_displayInformation.OrientationChanged -= DisplayInformationOnOrientationChanged;
				}

				_disposed = true;
			}

			base.Dispose(disposing);
		}
	}
}