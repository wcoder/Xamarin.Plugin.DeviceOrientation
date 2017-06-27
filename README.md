## Device Orientation Plugin for Xamarin and Windows

Simple cross platform plugin to get screen orientation of mobile device.

### Setup

> ...

#### Platform Support

|Platform|Supported|Version|
| ------------------- | :-----------: | :------------------: |
|Xamarin.iOS|Yes|iOS 2.0+|
|Xamarin.Android|Yes|API 3+|
|Universal Windows Platform|Yes|10.0.10240+|
|Xamarin.Forms|||

#### Deprecated platforms

* Windows Phone Silverlight
* Windows Phone RT
* Windows Store RT

Implementations for unsupported platforms contains [here](https://github.com/wcoder/Xamarin.Plugin.DeviceOrientation/tree/deprecated/src/DeviceOrientation/).


### API Usage

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

You will get a `ConnectivityChangeEventArgs` with the orientation type:

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

### Additional information
* [Android - Handling Rotation](https://developer.xamarin.com/guides/android/application_fundamentals/handling_rotation/)
* [Xamarin.Forms - Device Orientation](https://developer.xamarin.com/guides/xamarin-forms/user-interface/layouts/device-orientation/)


#### Contributors
* [Yauheni Pakala](https://github.com/wcoder)

---
&copy; 2017 MIT License
