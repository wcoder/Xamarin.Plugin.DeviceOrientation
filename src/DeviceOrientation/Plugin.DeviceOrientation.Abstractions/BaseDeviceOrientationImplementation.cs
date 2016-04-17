using System;

namespace Plugin.DeviceOrientation.Abstractions
{
	public abstract class BaseDeviceOrientationImplementation : IDeviceOrientation, IDisposable
	{
		/// <summary>
		/// Current device orientation
		/// </summary>
		public abstract DeviceOrientations CurrentOrientation { get; }


		/// <summary>
		/// Event that fires when orientation changes
		/// </summary>
		public event OrientationChangedEventHandler OrientationChanged;

		/// <summary>
		/// When orientation changes
		/// </summary>
		/// <param name="e"></param>
		protected virtual void OnOrientationChanged(OrientationChangedEventArgs e)
		{
			OrientationChanged?.Invoke(this, e);
		}

		/// <summary>
		/// Dispose of class and parent classes
		/// </summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Dispose up
		/// </summary>
		~BaseDeviceOrientationImplementation()
		{
			Dispose(false);
		}

		private bool _disposed;

		/// <summary>
		/// Dispose method
		/// </summary>
		/// <param name="disposing"></param>
		public virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					//dispose only
				}

				_disposed = true;
			}
		}
	}
}
