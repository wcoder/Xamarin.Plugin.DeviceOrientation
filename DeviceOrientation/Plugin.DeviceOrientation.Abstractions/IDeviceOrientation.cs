namespace Plugin.DeviceOrientation.Abstractions
{
	/// <summary>
	/// Interface for DeviceOrientation
	/// </summary>
	public interface IDeviceOrientation
	{
		DeviceOrientations CurrentOrientation { get; }
	}
}
