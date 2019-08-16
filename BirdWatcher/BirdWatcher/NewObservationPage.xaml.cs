/**************************************************************************
* Contains NewObservationPage view functionality                          *
* 1. Handles creating, populating Observation grid control objects and    *
*       their sorting order in the ObservationStackLayout control object. *
* 2. Handles New Observation and Sort button click functionality.         *
***************************************************************************/
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BirdWatcher
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewObservationPage : ContentPage
	{
        // Temporary fields' values assigned via user input, assigned to new Observation objects on construction
        private string species = "";
        private string notes = "";
        private string rarity = "";


        public NewObservationPage ()
		{
			InitializeComponent ();
		}


        // Set new Observation object's rarity from NewObservationPage view on click rarity button
        private void OnButtonCommonClickedAsync(object sender, EventArgs args)
        {
            rarity = GlobalVariables.RARITY_COMMON;
        }
        private void OnButtonRareClickedAsync(object sender, EventArgs args)
        {
            rarity = GlobalVariables.RARITY_RARE;
        }
        private void OnButtonExtremelyRareClickedAsync(object sender, EventArgs args)
        {
            rarity = GlobalVariables.RARITY_EXTREMELY_RARE;
        }


        // Handle save new Observation object data to Preferences, notify MainPage view when done via message
        private async void OnButtonSaveClickedAsync(object sender, EventArgs args)
        {
            species = Species.Text;
            notes = Notes.Text;

            // Handle create Observation object, convert to JSON, save to Preferences
            Observation newObservation = CreateObservationObject(species, notes, rarity);
            ObservationSerialization.SaveObservationToPreferences(newObservation);

            NotifyObjectDataSaved();

            await Navigation.PopAsync();
        }

        // Create, return new Observation object with Properties assigned argument values on construction
        private Observation CreateObservationObject(string species, string notes, string rarity)
        {
            return new Observation(species, notes, rarity);
        }

        // Message MainPage that Observation data saved in Preferences
        private void NotifyObjectDataSaved()
        {
            MessagingCenter.Send<NewObservationPage>(this, GlobalVariables.MESSAGE_DATA_SAVED);
        }


        // Call to return to MainPage view without creating, sending new Observation object 
        private async void OnButtonCancelClickedAsync(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}