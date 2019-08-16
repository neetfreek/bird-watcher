# Description of Solution and Experience with Assignment
This file contains a brief overview of how the solution works, and how it was building it.  

### Description of Solution
0. The solution consists of two main types of files. Each is a partial definition of the same class, and each page view has one of each:  
	0.1. `.xaml` Markup files for creating static controls (UI elements the user sees in the application).  
	0.2. `.xaml.cs` "Code-behind files" which handle business logic.  
	0.3. Static controls are created in the `.xaml`files; which includes things like page view headings, buttons, and overall page structure.  
	0.4. Dynamic/Programmatic controls are created in the `.xaml.cs` files; this is used primarily when adding observation grids to the scrollable `ObservationStackLayout` control (see 1.1.1. for more).  
1. On launching the application, the **Main Page** view is displayed to the user. A call to a method handling the updating of the **Main Page** view stack layout is made. This:  
	1.1. Calls the load method from `ObservationSerialization.cs` which checks for any entries in the `Preferences` dictionary. If entries are found:  
		1.1.1. The values of all entries are converted from JSON string values to Observation objects. These are saved in a `List<Observation>` which is returned to the `MainPage.xaml.cs` caller. These objects are then used to dynamically create a number of observation grid controls which contain the values of the object fields. These are added to the main `ObservationStackLayout` control along with a separating `BoxView` control.  
	1.2. If no entries are found, an empty list is returned and so no observation grid controls are added to the `ObservationStackLayout` control.  
	1.3. Clicking on the *New Observation* button opens the **New Observations Page** view, clicking on the **Sort** button reverse the sorting-order of observations displayed. This is achieved by toggling the `reverseSort` bool in `MainPage.xaml.cs`, which reverse-sorts the list discussed in 1.1.1.  
2. Data entered by the user into input controls (editors for species name and observation notes; and buttons for rarity) in the **New Observations Page** view is saved as temporary private fields in `NewObservationPage.xaml.cs`.  
3. The solution treats observations as objects which are created when the user presses the *Save* button in the **New Observations Page** view. On saving, the input data is passed as parameters for the constructor for the creation of a new `Observation.cs` object. In the object's constructor, a timestamp is created as well. This occurs asynchronously to avoid thread-blocking problems.  
4. The new Observation object is passed to `ObservationSerialization.cs` where it is serialized into a JSON string format. This string is saved to the `Preferences` dictionary as a value. The key is an integer incremented to one above the key of the previous entry.  
5. Once new observation data is saved to the `Preferences` dictionary, a notification message is sent to `MainPage.xaml.cs`,which calls a method handling the updating of the **Main Page** view stack layout (see 1.1.1. for the process which occurs after this).  
6. The **New Observations Page** view is asynchronously popped off, restoring the view to the **Main Page** view.  


### Experience with Assignment
This is my first time developing a more fully-featured native mobile app. My only other experience with this kind of development was developing a small Unity game application using Android Studio about a year ago.  

I chose Xamarin.Forms as I am quite familiar with the .NET Framework, C#, markup languages, as well as the Visual Studio IDE.

It took me some time to complete the initial setup of the environment. This includes issues like the Android API in Visual Studio not being particularly modern (I downloaded a more recent version from Android Developers and things became smoother), and the designer not always displaying my controls (I ditched the designer and stuck with coding static controls in `.xaml` files instead). I also had some issues with setting up the emulator, getting to grips with things like the APK, and becoming properly familiar with the relationship between the `.xaml` and `.xaml.cs` class definitions.  

Once I got the environment set up things became a lot smoother. I used source control (GitHub) to control for any problems, keeping everything on the master branch as I was not working collaboratively.  

It was quite fun seeing the functionality come along at a decent rate, and I was pleased with the progress. I hit a major stumbling block implementing the geolocation functionality, however (using the Xamarin.Essentials library) - I managed to implement all the permission-seeking requirements but could not get reliable location data from my calls. I think it was related to the async methods somehow going on for eternity...

All in all I enjoyed the assignment; it was challenging, new for me, and I completed it to spec. It would have been nice to have completed all the bonus features, but I decided it better to deliver the work within my original time-frame of 72 hours. I have included "next steps" on how to begin implementing the additional features as well as cross-platform support in the README.md file.

