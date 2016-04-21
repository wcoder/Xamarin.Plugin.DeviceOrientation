// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DeviceOrientation.Samples.iOS
{
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel labelView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (labelView != null) {
				labelView.Dispose ();
				labelView = null;
			}
		}
	}
}
