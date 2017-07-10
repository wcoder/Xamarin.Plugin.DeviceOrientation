using System;
using UIKit;
using Plugin.DeviceOrientation;
using Plugin.DeviceOrientation.Abstractions;

namespace DeviceOrientation.Samples.iOS
{
    public partial class ViewController : UIViewController
    {
        private bool _isLocked;

        public ViewController(IntPtr handle)
            : base(handle)
        {
        }

        //++++++++++++++++++++++++
        public override bool ShouldAutorotate()
        {
            // set plugin for handle of this method
            return DeviceOrientationImplementation.ShouldAutorotate;
        }

        public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations()
        {
            // allow all orientations
            return UIInterfaceOrientationMask.AllButUpsideDown;
        }
        //++++++++++++++++++++++++


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            labelView.Text = CrossDeviceOrientation.Current.CurrentOrientation.ToString();
            lockButton.TouchUpInside += LockButton_TouchUpInside;

            CrossDeviceOrientation.Current.OrientationChanged += CrossDeviceOrientation_Current_OrientationChanged;
        }

        public override void ViewDidUnload()
        {
            base.ViewDidUnload();

            CrossDeviceOrientation.Current.OrientationChanged -= CrossDeviceOrientation_Current_OrientationChanged;
        }

        private void LockButton_TouchUpInside(object sender, EventArgs e)
        {
            _isLocked = !_isLocked;

            lockButton.SetTitle(_isLocked ? "Unlock" : "Lock", UIControlState.Normal);

            if (_isLocked)
                CrossDeviceOrientation.Current.LockOrientation(CrossDeviceOrientation.Current.CurrentOrientation);
            else
                CrossDeviceOrientation.Current.UnlockOrientation();
        }

        private void CrossDeviceOrientation_Current_OrientationChanged(object sender, OrientationChangedEventArgs e)
        {
            labelView.Text = e.Orientation.ToString();
        }
    }
}