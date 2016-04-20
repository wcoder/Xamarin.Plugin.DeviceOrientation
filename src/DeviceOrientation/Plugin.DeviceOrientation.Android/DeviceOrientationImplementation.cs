using System;
using Android.App;
using Android.Content;
using Android.Hardware;
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

		private OrientationListener _listener;

		public DeviceOrientationImplementation()
		{
			_listener = new OrientationListener(OnOrientationChanged);
			if (_listener.CanDetectOrientation())
			{
				_listener.Enable();
			}
		}

		private bool _disposed;

		public override void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing && _listener != null)
				{
					_listener.Disable();
					_listener.Dispose();
				}

				_disposed = true;
			}

			base.Dispose(disposing);
		}
	}


	/// <summary>
	/// OrientationEventListener Android API:
	/// http://developer.android.com/reference/android/view/OrientationEventListener.html
	/// </summary>
	public class OrientationListener : OrientationEventListener
	{
		private Action<OrientationChangedEventArgs> _onOrientationChanged;

		public OrientationListener(Action<OrientationChangedEventArgs> onOrientationChanged)
			: base(Application.Context, SensorDelay.Normal)
		{
			_onOrientationChanged = onOrientationChanged;
		}

		public OrientationListener(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		public OrientationListener(Context context)
			: base(context)
		{
		}

		public OrientationListener(Context context, SensorDelay rate)
			: base(context, rate)
		{
		}

		public override void OnOrientationChanged(int rotationDegrees)
		{
			var args = new OrientationChangedEventArgs();

			if (rotationDegrees >= 0
			    && rotationDegrees < 90)
			{
				args.Orientation = DeviceOrientations.Portrait;
			} else if (rotationDegrees >= 90
			           && rotationDegrees < 180)
			{
				args.Orientation = DeviceOrientations.Landscape;
			} else if (rotationDegrees >= 180
				&& rotationDegrees < 270)
			{
				args.Orientation = DeviceOrientations.PortraitFlipped;
			} else if (rotationDegrees >= 270
			           && rotationDegrees < 360)
			{
				args.Orientation = DeviceOrientations.LandscapeFlipped;
			}
			else
			{
				args.Orientation = DeviceOrientations.Undefined;
			}

			_onOrientationChanged(args);
		}
	}
}