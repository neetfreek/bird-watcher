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
        public static List<Observation> Observations = new List<Observation>();

        public MainPage()
        {
            InitializeComponent();
        // Called from NewObservationPage on saving new Observation object
        public static void AddObservationToList(Observation newObservation)
        {
            Observations.Add(newObservation);
            Console.WriteLine($"Added Observation object {newObservation.Species} to list (FIRST TEST: {Observations[0].Species})");
        }
        // Method called by button clicks from MainPage view
        async void OnButtonNewObservationClicked(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new NewObservationPage());
        }
    }
}
