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
        // Contain created observations
        private static List<Observation> observations = new List<Observation>();

        public MainPage()
        {
            InitializeComponent();
            observations = ObservationSerialization.LoadObservationListFromPreferences();

            // Setup message subscriber for notification all Observation object data sent
            MessagingCenter.Subscribe<NewObservationPage>(this, "DataSaved", (sender) =>
            {
                observations = ObservationSerialization.LoadObservationListFromPreferences();
            });
        }

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
