using Android.App;
using Android.Widget;
using Android.OS;
using Plugin.DeviceOrientation;
 
namespace DeviceOrientation.Samples.Droid
{
	[Activity (Label = "DeviceOrientation.Samples.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private Button _textView;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			_textView = FindViewById<Button> (Resource.Id.textView1);

			_textView.Text = CrossDeviceOrientation.Current.CurrentOrientation.ToString();

			CrossDeviceOrientation.Current.OrientationChanged += Current_OrientationChanged;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			CrossDeviceOrientation.Current.OrientationChanged -= Current_OrientationChanged;
		}

		private void Current_OrientationChanged(object sender, Plugin.DeviceOrientation.Abstractions.OrientationChangedEventArgs e)
		{
			_textView.Text = CrossDeviceOrientation.Current.CurrentOrientation.ToString();
		}
	}
}


