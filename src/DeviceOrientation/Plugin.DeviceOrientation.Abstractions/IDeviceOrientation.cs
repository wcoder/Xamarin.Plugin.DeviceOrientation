using System;

namespace Plugin.DeviceOrientation.Abstractions
{
	/// <summary>
	/// Interface for DeviceOrientation
	/// </summary>
	public interface IDeviceOrientation
	{
		event OrientationChangedEventHandler OrientationChanged;

		DeviceOrientations CurrentOrientation { get; }
	}

	/// <summary>
	/// Arguments to pass to event handlers
	/// </summary>
	public class OrientationChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Gets device orientation
		/// </summary>
		public DeviceOrientations Orientation { get; set; }
	}

	/// <summary>
	/// Orientation changed event handlers
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	public delegate void OrientationChangedEventHandler(object sender, OrientationChangedEventArgs e);
}
