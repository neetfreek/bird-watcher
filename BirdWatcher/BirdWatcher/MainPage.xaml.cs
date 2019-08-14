using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BirdWatcher
{
    public partial class MainPage : ContentPage
    {
        // Temporary fields used to set Observation object values
        private string species = "";
        private string notes = "";
        private string rarity = "";

        public static List<Observation> Observations = new List<Observation>();

        public MainPage()
        {
            InitializeComponent();
            // Setup message subscribers for new Observation object data fields
            MessagingCenter.Subscribe<NewObservationPage, string>(this, "Species", (sender, arg) =>
            {
                species = arg;
                Console.WriteLine($"set species {species}");
            });
            MessagingCenter.Subscribe<NewObservationPage, string>(this, "Notes", (sender, arg) =>
            {
                notes = arg;
                Console.WriteLine($"set notes {notes}");            
            });
            MessagingCenter.Subscribe<NewObservationPage, string>(this, "Rarity", (sender, arg) =>
            {
                rarity = arg;
                Console.WriteLine($"set rarity {rarity}");
            });

            // Setup message subscriber for notification all Observation object data sent
            MessagingCenter.Subscribe<NewObservationPage>(this, "DataSent", (sender) =>
            {
                CreateNewObservation();
            });
        }

        // Create new Observation object from received data
        private void CreateNewObservation()
        {
            Observation newObservation = new Observation(species, notes, rarity);
            Console.WriteLine($"CREATED new Observation object {newObservation.Species}");

            Observations.Add(newObservation);
        }
        // Method called by button clicks from MainPage view
        async void OnButtonNewObservationClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NewObservationPage());
        }
    }
}
