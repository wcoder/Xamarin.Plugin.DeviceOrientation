using System;
using UIKit;
using Plugin.DeviceOrientation;
using Plugin.DeviceOrientation.Abstractions;

namespace DeviceOrientation.Samples.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController(IntPtr handle)
			: base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			labelView.Text = CrossDeviceOrientation.Current.CurrentOrientation.ToString();

			CrossDeviceOrientation.Current.OrientationChanged += CrossDeviceOrientation_Current_OrientationChanged;
		}

		public override void ViewDidUnload()
		{
			base.ViewDidUnload();

			CrossDeviceOrientation.Current.OrientationChanged -= CrossDeviceOrientation_Current_OrientationChanged;
		}

		void CrossDeviceOrientation_Current_OrientationChanged(object sender, OrientationChangedEventArgs e)
		{
			labelView.Text = e.Orientation.ToString();
		}

	}
}

