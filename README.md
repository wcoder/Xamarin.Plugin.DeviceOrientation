## Device Orientation Plugin for Xamarin and Windows

Simple cross-platform plugin to work with screen orientation of mobile device.

[iOS demo](https://youtu.be/3eQDrHMPmE4)

[Xamarin.Forms sample](https://github.com/wcoder/Xamarin.Plugin.DeviceOrientation/tree/master/samples/Xamarin.Forms-sample)

#### Setup

* Available on NuGet: [![NuGet](https://img.shields.io/nuget/v/Plugin.DeviceOrientation.svg?label=NuGet)](https://www.nuget.org/packages/Plugin.DeviceOrientation/)
* Install into your PCL project and Platform Specific projects

#### Platform Support

|Platform|Version|
| ------------------- | :------------------: |
|Xamarin.iOS|iOS 5+|
|Xamarin.Android|API 14+|
|Windows 10 UWP|10.0.10240+|

#### Deprecated platforms

* Windows Phone Silverlight
* Windows Phone RT
* Windows Store RT

Implementations for unsupported platforms contains [here](https://github.com/wcoder/Xamarin.Plugin.DeviceOrientation/tree/deprecated/src/DeviceOrientation/).

## News
- Plugins have moved to .NET Standard and have some important changes!

## API Usage

Call `CrossDeviceOrientation.Current` from any project or PCL to gain access to APIs.

```csharp
/// <summary>
/// Gets current device orientation
/// </summary>
DeviceOrientations CurrentOrientation { get; }
```

When device orientation is changed you can register for an event to fire:

```csharp
/// <summary>
/// Event handler when orientation changes
/// </summary>
event OrientationChangedEventHandler OrientationChanged;
```

You will get a `OrientationChangedEventArgs` with the orientation type:

```csharp
public class OrientationChangedEventArgs : EventArgs
{
	public DeviceOrientations Orientation { get; set; }
}

public delegate void OrientationChangedEventHandler(object sender, OrientationChangedEventArgs e);
```

The **DeviceOrientations** enumeration has these members.

|Member|Value|Description|
| :----------------: | :-----------: | :------------------ |
|**Undefined**|0|No display orientation is specified.|
|**Landscape**|1|Specifies that the monitor is oriented in landscape mode where the width of the display viewing area is greater than the height.|
|**Portrait**|2|Specifies that the monitor rotated 90 degrees in the clockwise direction to orient the display in portrait mode where the height of the display viewing area is greater than the width.|
|**LandscapeFlipped**|4|Specifies that the monitor rotated another 90 degrees in the clockwise direction (to equal 180 degrees) to orient the display in landscape mode where the width of the display viewing area is greater than the height. This landscape mode is flipped 180 degrees from the **Landscape** mode.|
|**PortraitFlipped**|8|Specifies that the monitor rotated another 90 degrees in the clockwise direction (to equal 270 degrees) to orient the display in portrait mode where the height of the display viewing area is greater than the width. This portrait mode is flipped 180 degrees from the **Portrait** mode.|

Call `LockOrientation` for set orientation and lock with disabling device auto-rotation:
```csharp
/// <summary>
///     Lock orientation in the specified position
/// </summary>
/// <param name="orientation">Position for lock.</param>
void LockOrientation(DeviceOrientations orientation);
```
For disable the lock, call `UnlockOrientation` method:
```csharp
/// <summary>
///     Unlock orientation
/// </summary>
void UnlockOrientation();
```

### iOS Specific Support

Add this code for your ViewController where you want locking orientation:
```csharp
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
```
In your `Info.plist` need set all device orientations.

## Additional information
* [Android - Handling Rotation](https://developer.xamarin.com/guides/android/application_fundamentals/handling_rotation/)
* [Xamarin.Forms - Device Orientation](https://developer.xamarin.com/guides/xamarin-forms/user-interface/layouts/device-orientation/)


## Contributors
* [Yauheni Pakala](https://github.com/wcoder)

---
&copy; 2017 MIT License
