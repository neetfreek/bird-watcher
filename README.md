# Bird Watcher
 A native mobile application for adding birdwatching observations for Android devices. Build with Xamarin.Forms, a cross-platform UI toolkit for .NET native application development using C# and Visual Studio.  

<img src="/PreviewImages/MainPageView.png" alt="The main page view" align="left" width="410">
<img src="/PreviewImages/NewObservationView.png" alt="Adding a new observation" align="right" width="410">
 
## Description
 The application's **Main Page** view shows the user the following:  
 - A button to add new birdwatching observations  
 - A button to re-sort recorded observations, either from newest to oldest, or oldest to newest  
 - A scrolling list of recorded observations. Each observation contains the following information:  
	- The name of the species  
	- The rarity of the species  
	- An excerpt of the users notes on the species  
	- The date and time at which the observation was made   
	
 The application's **New Observation Page** view shows the user the following:  
 - A field for entering the name of the observed species  
 - A field for entering notes about the observation  
 - Three buttons for selecting the rarity of the observation; common, rare, extremely rare
 - Buttons to save the observation or cancel recording the observation  

## Using the Application
 - Users press the *Add Observation* button to record a new observation  
 - On pressing the *Add Observation* button, users are shown the **New Observation Page** view, where they can record:  
	- The name of the species using an input field  
	- Notes on the species by using an input field  
	- The rarity of the species by selecting the appropriate button  
 - Users can either press the *Save* or *Cancel* buttons:  
	- Saving automatically appends the time and date (formatted according to the device's language) the observation was made to the observation notes, saves the observation as persistent data to their device, and returns the user to the **Main Page** view, where their newly recorded observation can be seen.  
	- Cancelling discards any entered information and returns the user to the **Main Page** view  

## Requirements For Development and Testing
 1. *Java Deveelopment Kit*, or *JDK*; version 8 for Android API Levels 24 and more, and 7 for 23 and less. It is recommended to install *JDK 8*.  
 2. *Android SDK*. If this is missing, download it from [Android Developers](https://developer.android.com/studio/#downloads) install it, open the Android SDK Manager in Visual Studio (Tools -> Android -> Android SDK Manager...), and set the location in the Android SDK Manager to the directory where it was installed to.  
 3. *Android Emulator* makes testing quicker. Install it via by checking the appropriate checkbox in the Tools tab in Android SDK Manager. Emulators can be added and managed in Tools -> Android -> Android Device Manager...  
 4. The application's minimum Android version is 4.4 (API Level 19 - Kit Kat) and the target version is 8.1 (API Level 27 - Oreo).  
 
## Building and Testing the Application
 Open the BirdWatcher solution (.sln) file in the root directory of this repository.  

### Building the Application
 Select Build -> Build Solution. If already built, you can select Build -> Rebuild Solution (removes previous build artefacts before building).  
  
### Testing the Application

#### Older Android Device Emulators
 There may be issues with using older device emulators (like Android 4.4, API Level 19) like the application loading and immediately closing. This is caused by a perceived lack of network connection for the emulator device. To fix this:  
 1. Select the emulator from the run drop-down menu and launch (F5 or click the Play button).  
 2. Cancel deployment once the device emulator has opened.  
 3. Click on the chevron (>>) icon and select the Network tab.  
 4. Locate the preferred network IP address.  
 5. Open the Android Adb Command Prompt.  
 6. Execute the following: `adb [Preferred IP Address]:[Appended Local Host Port]`. For example: `adb connect 169.254.101.144:5555`  
 7. Only steps 5. and 6. need to be repeated for continued testing until the IDE is closed.  
 8. You may need to manually open the application.  
 
#### Later Android Device Emulators
 1. Open the Android Device Manager (Tools -> Android -> Android Device Manager...), add or highlight the desired device emulator and then click the *Start* button.  
 2. Wait for the emulator to completely launch.  
 3. Select the device emulator from the run drop-down menu and launch (F5 or click the Play button).  
 4. The application will launch automatically.  
 
#### Devices
 1. Enable Debugging on the device by checking the USB Debugging checkbox in the Developer Options menu.  
 2. Run the **android.bat** application in the **android-sdk** folder. 
 3. Download USB drivers. Galaxy Nexus device drivers are downloaded from [Samsung](https://www.samsung.com/us/support/downloads/) and other device drivers from [Android Developers](https://developer.android.com/studio/run/oem-usb#Drivers)
 4. Install the USB driver on the device.  
 5. Connect the device to your machine via USB cable (ensure USB mode is on by opening the Android Adb Command Prompt and executing `adb usb` or a WiFi connection (check device's IP address, open the Android Adb Command Prompt and executing `adb tcpip 5555` and then `adb connect [Device's IP Address]`).  
 
## Further Development
 Next steps for the development of additional features are detailed below.  

### Geolocation
 Geolocation functionality like adding location coordinates or a pinned image of the location of observations on a map image can be implemented via the Xamarin.Essentials library using the Geolocation feature. This library is already installed. This functionality requires:    
 1. Adding location access permission requesting in the `AssemblyInfo.cs` file or the `AndroidManifest.xml` file.  
 2. Referencing the Xamarin.Essentials library via a using statement at the top of the class implementing Geolocation functionality.  
 
### Pictures
 Pictures functionality like taking a picture on adding new observations or adding pictures to observations can be implemented via the [Xam.Plugin.Media](https://github.com/jamesmontemagno/MediaPlugin) plugin. This functionality requires:  
 1. Installing the NuGet package e.g. via the NuGet Package Manager.  
 2. Installing the [Plugin.Current.Activity](https://github.com/jamesmontemagno/CurrentActivityPlugin) plugin NuGet package e.g. via the NuGet Package Manager.  
 3. Add some lines of code to the `Activity.cs's onCreate` to enable Android Current Activity functionality.
 4. Add some lines of code to the `AndroidManifest.xml` file to adhere to strict mode.
 5. Create/ Add to `xml` folder in `Resources` folder `file_paths.xml` with some code in it.
 6. Please refer to *Android Current Activity Setup* and *Android Misc Setup* in the [plugin's project page.](https://github.com/jamesmontemagno/MediaPlugin)

### Cross-Platform Development
 Xamarin.Forms allows for fairly easy cross-platform development for Android, iOS, and UWP devices. This is most easily done thought creating Shared Projects / Shared Asset Projects which uses file-linking and allows for including platform-specific code. Code is compiled into each referencing project. This project has all development files within the platform-agnostic BirdWatcher directory, can be ported into a new Shared Project, and so is compatible with this approach. 

## Acknowledgements
 Application icon from DawnLike Tileset v1.81 by DawnBringer and DragonDePlatino, CC-BY 4.0 license.  