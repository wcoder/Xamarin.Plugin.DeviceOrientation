using System;

namespace Plugin.DeviceOrientation.Abstractions
{
    public abstract class BaseDeviceOrientationImplementation : IDeviceOrientation, IDisposable
    {
        private bool _disposed;

        /// <summary>
        ///     Current device orientation
        /// </summary>
        public abstract DeviceOrientations CurrentOrientation { get; }

        /// <summary>
        ///     Lock orientation in the specified position
        /// </summary>
        /// <param name="orientation">Position for lock.</param>
        public abstract void LockOrientation(DeviceOrientations orientation);

        /// <summary>
        ///     Unlock orientation
        /// </summary>
        public abstract void UnlockOrientation();

        /// <summary>
        ///     Event that fires when orientation changes
        /// </summary>
        public event OrientationChangedEventHandler OrientationChanged;

        /// <summary>
        ///     Dispose of class and parent classes
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     When orientation changes
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnOrientationChanged(OrientationChangedEventArgs e)
        {
            OrientationChanged?.Invoke(this, e);
        }

        /// <summary>
        ///     Dispose up
        /// </summary>
        ~BaseDeviceOrientationImplementation()
        {
            Dispose(false);
        }

        /// <summary>
        ///     Dispose method
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