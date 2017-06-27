using Android.App;
using Android.Widget;
using Android.OS;
using Plugin.DeviceOrientation;
using Plugin.DeviceOrientation.Abstractions;

namespace DeviceOrientation.Samples.Droid
{
	[Activity (Label = "DeviceOrientation.Samples.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private static class StaticStore
		{
			public static bool IsLocked { get; set; }
		}

		private TextView _textView;
		private Button _lockButton;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			_textView = FindViewById<TextView> (Resource.Id.textView1);
			_textView.Text = CrossDeviceOrientation.Current.CurrentOrientation.ToString();

			_lockButton = FindViewById<Button>(Resource.Id.lockButton);
			_lockButton.Click += LockButton_Click;

			CrossDeviceOrientation.Current.OrientationChanged += Current_OrientationChanged;
		}

		private void LockButton_Click(object sender, System.EventArgs e)
		{
			StaticStore.IsLocked = !StaticStore.IsLocked;

			_lockButton.Text = StaticStore.IsLocked ? "Unlock" : "Lock";

			if (StaticStore.IsLocked)
			{
				CrossDeviceOrientation.Current.LockOrientation(CrossDeviceOrientation.Current.CurrentOrientation);
			}
			else
			{
				CrossDeviceOrientation.Current.UnlockOrientation();
			}
		}

		private void Current_OrientationChanged(object sender, OrientationChangedEventArgs e)
		{
			_textView.Text = CrossDeviceOrientation.Current.CurrentOrientation.ToString();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			CrossDeviceOrientation.Current.OrientationChanged -= Current_OrientationChanged;
		}
	}
}


