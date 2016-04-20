## Device Orientation Plugin for Xamarin and Windows

Simple cross platform plugin to get screen orientation of mobile device.

### Setup

> ...

**Platform Support**

|Platform|Supported|Version|
| ------------------- | :-----------: | :------------------: |
|Xamarin.iOS|+/-| |
|Xamarin.iOS Unified|+/-| |
|Xamarin.Android|Yes|API 3+|
|Windows Phone Silverlight|+/-|8.0+|
|Windows Phone RT|Yes|8.1+|
|Windows Store RT|Yes|8.1+|
|Windows 10 UWP|Yes|10+|
|Xamarin.Mac|No||

> +/- [not tested on device]

### API Usage

Call **CrossDeviceOrientation.Current** from any project or PCL to gain access to APIs.

**CurrentOrientation**
```csharp
/// <summary>
/// Gets current device orientation
/// </summary>
DeviceOrientations CurrentOrientation { get; }
```

#### Changes in Orientation

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

> ...

#### Contributors
* [Yauheni Pakala](https://github.com/wcoder)

---
&copy; 2016 MIT License
