using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace BirdWatcher
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewObservationPage : ContentPage
	{
        // Temporary fields used to set Observation object values on Save
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

        // Call to create, send new Observation object to MainPage method from NewObservationPage view on click save button
        async void OnButtonSaveClicked(object sender, EventArgs args)
        {
            species = Species.Text;
            notes = Notes.Text;

            SendObjectData();
            NotifyObjectDataSent();

            await Navigation.PopAsync();
        }


        // Message Observation object data to subcribers in MainPage
        void SendObjectData()
        {
            MessagingCenter.Send<NewObservationPage, string>(this, "Species", species);
            MessagingCenter.Send<NewObservationPage, string>(this, "Notes", notes);
            MessagingCenter.Send<NewObservationPage, string>(this, "Rarity", rarity);
        }

        // Message to MainPage that all Observation data sent
        void NotifyObjectDataSent()
        {
            MessagingCenter.Send<NewObservationPage>(this, "DataSent");
        }

        // Call to return to MainPage view without creating, sending new Observation object 
        async void OnButtonCancelClicked(object sender, EventArgs args)
        {
            await Navigation.PopAsync();
        }
    }
}