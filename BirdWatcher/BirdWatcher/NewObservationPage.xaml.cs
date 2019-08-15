using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BirdWatcher
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewObservationPage : ContentPage
	{
        // Temporary fields' values assigned via user input, used as fields for new Observation objects 
        private string species = "";
        private string notes = "";
        private string rarity = "";

        public NewObservationPage ()
		{
			InitializeComponent ();
		}

        // Set new Observation object's rarity from NewObservationPage view on click rarity button
        void OnButtonCommonClicked(object sender, EventArgs args)
        {
            rarity = "Common";
        }
        void OnButtonRareClicked(object sender, EventArgs args)
        {
            rarity = "Rare";
        }
        void OnButtonExtremelyRareClicked(object sender, EventArgs args)
        {
            rarity = "Extremely Rare";
        }

        // Handles saving new observation data to Preferences, notifies MainPage view when done via message
        async void OnButtonSaveClicked(object sender, EventArgs args)
        {
            species = Species.Text;
            notes = Notes.Text;

            // Handle create Observation object, convert to JSON, save to Preferences
            Observation newObservation = CreateObservationObject(species, notes, rarity);
            ObservationSerialization.SaveObservationToPreferences(newObservation);

            NotifyObjectDataSaved();

            await Navigation.PopAsync();
        }

        Observation CreateObservationObject(string species, string notes, string rarity)
        {
            return new Observation(species, notes, rarity);
        }

        // Message MainPage that Observation data saved in Preferences
        void NotifyObjectDataSaved()
        {
            MessagingCenter.Send<NewObservationPage>(this, "DataSaved");
        }

        // Call to return to MainPage view without creating, sending new Observation object 
        async void OnButtonCancelClicked(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}