using System;
using System.Threading;
using Plugin.DeviceOrientation.Abstractions;

namespace Plugin.DeviceOrientation
{
    /// <summary>
    ///     Cross platform DeviceOrientation implemenations
    /// </summary>
    public class CrossDeviceOrientation
    {
        private static readonly Lazy<IDeviceOrientation> Implementation =
            new Lazy<IDeviceOrientation>(() => CreateDeviceOrientation(), LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        ///     Current settings to use
        /// </summary>
        public static IDeviceOrientation Current
        {
            get
            {
                var ret = Implementation.Value;
                if (ret == null)
                    throw NotImplementedInReferenceAssembly();
                return ret;
            }
        }

        private static IDeviceOrientation CreateDeviceOrientation()
        {
#if NETSTANDARD1_0
            return null;
#else
            return new DeviceOrientationImplementation();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException(
                "This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}