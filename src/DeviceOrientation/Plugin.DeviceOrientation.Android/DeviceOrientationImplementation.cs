using System;
using System.Diagnostics;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Content.Res;
using Android.Hardware;
using Android.Runtime;
using Android.Views;
using Plugin.CurrentActivity;
using Plugin.DeviceOrientation.Abstractions;

namespace Plugin.DeviceOrientation
{
    public class DeviceOrientationImplementation : BaseDeviceOrientationImplementation
    {
        private const string FormsInvalidInitExceptionMessage = "This method only for Xamarin.Forms Android, for use this method firstly need to call Init method!";

        private readonly OrientationListener _listener;
        private bool _disposed;
        
        private static DeviceOrientationImplementation Instance { get; set; }

        public static bool IsForms { get; private set; }

        public DeviceOrientationImplementation()
        {
            Instance = this;

            _listener = new OrientationListener(OnOrientationChanged);
            if (_listener.CanDetectOrientation())
                _listener.Enable();
        }

        public override DeviceOrientations CurrentOrientation
        {
            get
            {
                var activity = CrossCurrentActivity.Current.Activity;
                var rotation = activity.WindowManager.DefaultDisplay.Rotation;

                return Convert(rotation);
            }
        }

        public override void LockOrientation(DeviceOrientations orientation)
        {
            var activity = CrossCurrentActivity.Current.Activity;

            activity.RequestedOrientation = Convert(orientation);
        }

        public override void UnlockOrientation()
        {
            var activity = CrossCurrentActivity.Current.Activity;

            activity.RequestedOrientation = Convert(DeviceOrientations.Undefined);
        }

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

        public static void Init(bool isForms = true)
        {
            IsForms = isForms;

            //var activity = CrossCurrentActivity.Current.Activity;
            //NotifyOrientationChange(activity.Resources.Configuration);
        }

        public static void NotifyOrientationChange(Configuration newConfig)
        {
            if (!IsForms)
            {
                throw new InvalidOperationException(FormsInvalidInitExceptionMessage);
            }

            if (Instance == null) return;

            Instance.OnOrientationChanged(new OrientationChangedEventArgs
            {
                Orientation = CrossDeviceOrientation.Current.CurrentOrientation
            });
        }

        private ScreenOrientation Convert(DeviceOrientations orientation)
        {
            switch (orientation)
            {
                case DeviceOrientations.Portrait:
                    return ScreenOrientation.Portrait;
                case DeviceOrientations.PortraitFlipped:
                    return ScreenOrientation.ReversePortrait;
                case DeviceOrientations.Landscape:
                    return ScreenOrientation.Landscape;
                case DeviceOrientations.LandscapeFlipped:
                    return ScreenOrientation.ReverseLandscape;
                default:
                    return ScreenOrientation.Unspecified;
            }
        }

        public DeviceOrientations Convert(SurfaceOrientation orientation)
        {
            switch (orientation)
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


    /// <summary>
    ///     OrientationEventListener Android API:
    ///     http://developer.android.com/reference/android/view/OrientationEventListener.html
    /// </summary>
    public class OrientationListener : OrientationEventListener
    {
        private readonly Action<OrientationChangedEventArgs> _onOrientationChanged;

        private DeviceOrientations _cachedOrientation;

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
            if (DeviceOrientationImplementation.IsForms) return;

            var currentOrientation = CrossDeviceOrientation.Current.CurrentOrientation;

            if (currentOrientation != _cachedOrientation)
            {
                _cachedOrientation = currentOrientation;

                _onOrientationChanged(new OrientationChangedEventArgs
                {
                    Orientation = currentOrientation
                });
            }
        }
    }
}