using Plugin.DeviceOrientation;
using Plugin.DeviceOrientation.Abstractions;
using Xamarin.Forms;

namespace DO.Samples.Forms
{
    public class DSImage : Image
    {
        public DSImage(int phonePortrait, int phoneLandscape, int tabletPortrait, int tabletLandscape)
        {
            if (Device.Idiom == TargetIdiom.Phone)
            {
                if (CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.Portrait || CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.PortraitFlipped)
                {
                    System.Diagnostics.Debug.WriteLine("Phone Portrait");
                    HeightRequest = phonePortrait;
                }
                else if (CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.Landscape || CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.LandscapeFlipped)
                {
                    System.Diagnostics.Debug.WriteLine("Phone Landscape");
                    HeightRequest = phoneLandscape;
                }
            }
            else if (Device.Idiom == TargetIdiom.Tablet)
            {
                if (CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.Portrait || CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.PortraitFlipped)
                {
                    System.Diagnostics.Debug.WriteLine("Tablet Portrait");
                    HeightRequest = tabletPortrait;
                }
                else if (CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.Landscape || CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.LandscapeFlipped)
                {
                    System.Diagnostics.Debug.WriteLine("Tablet Landscape");
                    HeightRequest = tabletLandscape;
                }
            }

            CrossDeviceOrientation.Current.OrientationChanged += (sender, args) =>
            {
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    if (CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.Portrait || CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.PortraitFlipped)
                    {
                        System.Diagnostics.Debug.WriteLine("Phone Portrait");
                        HeightRequest = phonePortrait;
                    }
                    else if (CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.Landscape || CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.LandscapeFlipped)
                    {
                        System.Diagnostics.Debug.WriteLine("Phone Landscape");
                        HeightRequest = phoneLandscape;
                    }
                }
                else if (Device.Idiom == TargetIdiom.Tablet)
                {
                    if (CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.Portrait || CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.PortraitFlipped)
                    {
                        System.Diagnostics.Debug.WriteLine("Tablet Portrait");
                        HeightRequest = tabletPortrait;
                    }
                    else if (CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.Landscape || CrossDeviceOrientation.Current.CurrentOrientation == DeviceOrientations.LandscapeFlipped)
                    {
                        System.Diagnostics.Debug.WriteLine("Tablet Landscape");
                        HeightRequest = tabletLandscape;
                    }
                }
            };
        }
    }
}
