using Android.App;
using Android.Content.PM;
using Android.OS;
using Plugin.CurrentActivity;
using Android.Content.Res;
using Plugin.DeviceOrientation;

namespace DO.Samples.Forms.Droid
{
    [Activity(Label = "DO.Samples.Forms", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            // Step 1:
            CrossCurrentActivity.Current.Activity = this;

            // Step 2:
            DeviceOrientationImplementation.Init();

            // ...

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        // Step 3:
        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            DeviceOrientationImplementation.NotifyOrientationChange(newConfig);
        }
    }
}

